"""
VEM 2.0 Kapsamli Bilgi JSON Olusturucu
Tum tablolar, kolonlar, iliskiler ve akis semasi
"""

import json
import os
from collections import defaultdict

def load_data():
    with open('vem2_data/VEM_2.0_all_tables.json', 'r', encoding='utf-8') as f:
        tables = json.load(f)
    with open('vem2_data/relations.json', 'r', encoding='utf-8') as f:
        relations = json.load(f)
    return tables, relations

def clean_name(name):
    if name and name.startswith('VEM_'):
        return name[4:]
    return name

def categorize_tables():
    """Tablolari kategorilere ayir"""
    return {
        "HASTA_YONETIMI": {
            "description": "Hasta kayit ve takip islemleri",
            "tables": [
                "HASTA", "HASTA_BASVURU", "HASTA_HIZMET", "HASTA_MALZEME",
                "HASTA_SEVK", "HASTA_ARSIV", "HASTA_ARSIV_DETAY", "HASTA_BORC",
                "HASTA_DIS", "HASTA_EPIKRIZ", "HASTA_FOTOGRAF", "HASTA_GIZLILIK",
                "HASTA_ILETISIM", "HASTA_ADLI_RAPOR", "HASTA_ODEME", "HASTA_PROTOKOL",
                "HASTA_RAPOR", "HASTA_YATIS"
            ]
        },
        "AMELIYAT_VE_CERRAHI": {
            "description": "Ameliyat ve cerrahi islemler",
            "tables": [
                "AMELIYAT", "AMELIYAT_EKIP", "AMELIYAT_ISLEM", "AMELIYAT_MALZEME"
            ]
        },
        "LABORATUVAR_VE_TETKIK": {
            "description": "Laboratuvar testleri ve tetkikler",
            "tables": [
                "TETKIK", "TETKIK_NUMUNE", "TETKIK_PARAMETRE", "TETKIK_SONUC",
                "BAKTERI_SONUC", "ANTIBIYOTIK_SONUC"
            ]
        },
        "KAN_MERKEZI": {
            "description": "Kan bankasi ve transfuzyon",
            "tables": [
                "KAN_BAGISCI", "KAN_STOK", "KAN_TALEP", "KAN_TALEP_DETAY",
                "KAN_URUN", "KAN_KULLANIM"
            ]
        },
        "ECZANE_VE_ILAC": {
            "description": "Ilac ve recete yonetimi",
            "tables": [
                "RECETE", "RECETE_ILAC"
            ]
        },
        "STOK_VE_MALZEME": {
            "description": "Stok ve malzeme yonetimi",
            "tables": [
                "STOK_KART", "STOK_HAREKET", "STOK_FIS", "STOK_ISTEK",
                "STOK_ISTEK_HAREKET", "DEPO"
            ]
        },
        "RADYOLOJI_VE_GORUNTULEME": {
            "description": "Radyoloji ve goruntuleme islemleri",
            "tables": [
                "RADYOLOJI", "RADYOLOJI_ISLEM"
            ]
        },
        "RANDEVU_VE_PLANLAMA": {
            "description": "Randevu ve kaynak planlama",
            "tables": [
                "RANDEVU", "RANDEVU_ENGEL"
            ]
        },
        "FATURALAMA_VE_FINANS": {
            "description": "Faturalama ve finansal islemler",
            "tables": [
                "FATURA", "FATURA_DETAY", "ICMAL", "ICMAL_DETAY",
                "VEZNE", "EK_ODEME", "EK_ODEME_DETAY", "EK_ODEME_DONEM",
                "MEDULA_TAKIP", "MEDULA_ISLEM"
            ]
        },
        "PERSONEL_VE_KULLANICI": {
            "description": "Personel ve kullanici yonetimi",
            "tables": [
                "PERSONEL", "KULLANICI", "KULLANICI_GRUP", "GRUP_UYELIK",
                "PERSONEL_IZIN", "PERSONEL_NOBETI", "PERSONEL_PUANTAJ"
            ]
        },
        "KURUM_VE_BIRIM": {
            "description": "Kurum ve birim yonetimi",
            "tables": [
                "KURUM", "BIRIM", "BINA", "ODA", "YATAK", "CIHAZ", "FIRMA"
            ]
        },
        "TANIM_VE_REFERANS": {
            "description": "Referans ve tanim tablolari",
            "tables": [
                "REFERANS_KODLAR", "HIZMET"
            ]
        },
        "OZEL_MODULLER": {
            "description": "Ozel saglik modulleri",
            "tables": [
                "DOGUM", "DOGUM_DETAY", "GEBE_IZLEM", "BEBEK_COCUK_IZLEM",
                "DIYABET", "COCUK_DIYABET", "GETAT", "OBEZITE",
                "DIS_TAAHHUT", "DIS_TAAHHUT_DETAY", "DISPROTEZ", "DISPROTEZ_DETAY",
                "STERILIZASYON_SET", "STERILIZASYON_PAKET", "STERILIZASYON_ISLEM"
            ]
        },
        "RAPORLAMA": {
            "description": "Kurul ve raporlama",
            "tables": [
                "KURUL", "KURUL_RAPOR", "KURUL_UYE", "RISK_SKORLAMA",
                "BILDIRIMI_ZORUNLU"
            ]
        },
        "TIBBI_ORDER": {
            "description": "Tibbi order ve talimatlar",
            "tables": [
                "TIBBI_ORDER", "TIBBI_ORDER_DETAY"
            ]
        },
        "SAGLIK_IZLEM": {
            "description": "Saglik izlem ve takip",
            "tables": [
                "ASI_BILGISI", "EVDE_SAGLIK_IZLEM", "OLUM_BILGISI",
                "ANLIK_YATAN_HASTA"
            ]
        }
    }

def create_flow_diagram():
    """Ana akis semasi"""
    return {
        "hasta_kabul_akisi": {
            "name": "Hasta Kabul Akisi",
            "steps": [
                {"step": 1, "table": "HASTA", "action": "Hasta kaydi olustur/guncelle"},
                {"step": 2, "table": "HASTA_BASVURU", "action": "Basvuru kaydi olustur"},
                {"step": 3, "table": "RANDEVU", "action": "Randevu planla (opsiyonel)"},
                {"step": 4, "table": "BIRIM", "action": "Birimi belirle"},
                {"step": 5, "table": "PERSONEL", "action": "Doktor ata"}
            ]
        },
        "poliklinik_akisi": {
            "name": "Poliklinik Muayene Akisi",
            "steps": [
                {"step": 1, "table": "HASTA_BASVURU", "action": "Basvuruyu ac"},
                {"step": 2, "table": "BASVURU_TANI", "action": "Tani gir"},
                {"step": 3, "table": "RECETE", "action": "Recete yaz"},
                {"step": 4, "table": "RECETE_ILAC", "action": "Ilac ekle"},
                {"step": 5, "table": "TETKIK_SONUC", "action": "Tetkik iste"},
                {"step": 6, "table": "HASTA_HIZMET", "action": "Hizmet kaydet"},
                {"step": 7, "table": "FATURA", "action": "Fatura olustur"}
            ]
        },
        "yatis_akisi": {
            "name": "Yatan Hasta Akisi",
            "steps": [
                {"step": 1, "table": "HASTA_YATIS", "action": "Yatis kaydi olustur"},
                {"step": 2, "table": "YATAK", "action": "Yatak ata"},
                {"step": 3, "table": "TIBBI_ORDER", "action": "Tibbi order gir"},
                {"step": 4, "table": "HASTA_MALZEME", "action": "Malzeme kullanimi"},
                {"step": 5, "table": "HASTA_EPIKRIZ", "action": "Epikriz yaz"},
                {"step": 6, "table": "FATURA", "action": "Taburcu faturasi"}
            ]
        },
        "ameliyat_akisi": {
            "name": "Ameliyat Akisi",
            "steps": [
                {"step": 1, "table": "AMELIYAT", "action": "Ameliyat planla"},
                {"step": 2, "table": "AMELIYAT_EKIP", "action": "Ekibi belirle"},
                {"step": 3, "table": "AMELIYAT_MALZEME", "action": "Malzeme hazirla"},
                {"step": 4, "table": "AMELIYAT_ISLEM", "action": "Islemleri kaydet"},
                {"step": 5, "table": "HASTA_HIZMET", "action": "Hizmet faturalandir"}
            ]
        },
        "laboratuvar_akisi": {
            "name": "Laboratuvar Akisi",
            "steps": [
                {"step": 1, "table": "TETKIK", "action": "Tetkik tanimla"},
                {"step": 2, "table": "TETKIK_NUMUNE", "action": "Numune al"},
                {"step": 3, "table": "TETKIK_PARAMETRE", "action": "Parametreleri isle"},
                {"step": 4, "table": "TETKIK_SONUC", "action": "Sonuc gir"},
                {"step": 5, "table": "BAKTERI_SONUC", "action": "Kultur sonucu (opsiyonel)"}
            ]
        },
        "stok_akisi": {
            "name": "Stok Yonetim Akisi",
            "steps": [
                {"step": 1, "table": "STOK_KART", "action": "Malzeme tanimla"},
                {"step": 2, "table": "DEPO", "action": "Depo tanimla"},
                {"step": 3, "table": "STOK_FIS", "action": "Giris/cikis fisi olustur"},
                {"step": 4, "table": "STOK_HAREKET", "action": "Hareket kaydet"},
                {"step": 5, "table": "STOK_ISTEK", "action": "Istek olustur"}
            ]
        },
        "kan_bankasi_akisi": {
            "name": "Kan Bankasi Akisi",
            "steps": [
                {"step": 1, "table": "KAN_BAGISCI", "action": "Bagisci kaydi"},
                {"step": 2, "table": "KAN_URUN", "action": "Urun tanimla"},
                {"step": 3, "table": "KAN_STOK", "action": "Stok guncelle"},
                {"step": 4, "table": "KAN_TALEP", "action": "Talep olustur"},
                {"step": 5, "table": "KAN_TALEP_DETAY", "action": "Talep detayi"},
                {"step": 6, "table": "KAN_KULLANIM", "action": "Kullanim kaydi"}
            ]
        },
        "faturalama_akisi": {
            "name": "Faturalama Akisi",
            "steps": [
                {"step": 1, "table": "HASTA_HIZMET", "action": "Hizmetleri topla"},
                {"step": 2, "table": "MEDULA_TAKIP", "action": "Medula takip no al"},
                {"step": 3, "table": "FATURA", "action": "Fatura olustur"},
                {"step": 4, "table": "FATURA_DETAY", "action": "Detaylari ekle"},
                {"step": 5, "table": "ICMAL", "action": "Icmal olustur"},
                {"step": 6, "table": "VEZNE", "action": "Tahsilat yap"}
            ]
        }
    }

def create_comprehensive_json():
    tables, relations = load_data()
    categories = categorize_tables()
    flows = create_flow_diagram()

    # Tablo detaylarini hazirla
    table_details = {}
    for table_name, table_data in tables.items():
        clean_table = clean_name(table_name)
        columns = table_data.get('columns', [])

        # FK bilgilerini topla
        fk_columns = []
        for col in columns:
            ref = col.get('reference', '-')
            if ref and ref != '-' and ref.startswith('VEM_'):
                fk_columns.append({
                    "column": col.get('name'),
                    "references": clean_name(ref)
                })

        table_details[clean_table] = {
            "original_name": table_name,
            "entity_name": clean_table,
            "column_count": len(columns),
            "columns": [
                {
                    "name": col.get('name'),
                    "type": col.get('type'),
                    "nullable": col.get('nullable', 'Evet'),
                    "description": col.get('description', '')[:100] if col.get('description') else '',
                    "reference": clean_name(col.get('reference')) if col.get('reference', '-') != '-' else None
                }
                for col in columns
            ],
            "foreign_keys": fk_columns
        }

    # Iliski grafikini olustur
    relation_graph = {
        "nodes": [],
        "edges": []
    }

    for table in table_details.keys():
        # Node ekle
        master_info = next((m for m in relations['master_tables'] if m['table'] == table), None)
        relation_graph["nodes"].append({
            "id": table,
            "label": table,
            "columns": table_details[table]["column_count"],
            "fk_in": master_info['fk_in'] if master_info else 0,
            "fk_out": master_info['fk_out'] if master_info else 0
        })

    # Edge'leri ekle
    for rel in relations.get('relations', []):
        relation_graph["edges"].append({
            "from": rel['from'],
            "to": rel['to'],
            "column": rel['column']
        })

    # Sonuc JSON
    result = {
        "meta": {
            "title": "VEM 2.0 - Saglik Bakanligi Veri Entegrasyon Modeli",
            "version": "2.0",
            "total_tables": len(table_details),
            "total_columns": sum(t["column_count"] for t in table_details.values()),
            "total_relations": len(relation_graph["edges"]),
            "generated_date": "2026-01-06",
            "source": "https://vem.saglik.gov.tr"
        },
        "statistics": {
            "master_tables": relations['master_tables'][:20],
            "tables_by_category": {
                cat: len(info["tables"])
                for cat, info in categories.items()
            }
        },
        "categories": categories,
        "flow_diagrams": flows,
        "tables": table_details,
        "relation_graph": relation_graph,
        "reverse_relations": relations.get('reverse_relations', {})
    }

    return result

def main():
    print("VEM 2.0 Kapsamli Bilgi JSON Olusturuluyor...")

    result = create_comprehensive_json()

    # bilgi klasorune kaydet
    output_path = '../bilgi/vem2_complete_schema.json'
    os.makedirs('../bilgi', exist_ok=True)

    with open(output_path, 'w', encoding='utf-8') as f:
        json.dump(result, f, ensure_ascii=False, indent=2)

    print(f"\nJSON dosyasi olusturuldu: {output_path}")
    print(f"  - Toplam Tablo: {result['meta']['total_tables']}")
    print(f"  - Toplam Kolon: {result['meta']['total_columns']}")
    print(f"  - Toplam Iliski: {result['meta']['total_relations']}")
    print(f"  - Kategori Sayisi: {len(result['categories'])}")
    print(f"  - Akis Diyagrami: {len(result['flow_diagrams'])}")

if __name__ == '__main__':
    main()
