"""
VEM 2.0 Tablo Iliskileri Analizi
"""

import json
from collections import defaultdict

def load_tables():
    with open('vem2_data/VEM_2.0_all_tables.json', 'r', encoding='utf-8') as f:
        return json.load(f)

def clean_name(name):
    if name and name.startswith('VEM_'):
        return name[4:]
    return name

def analyze_relations():
    tables = load_tables()

    # Iliskiler: {tablo: [(kolon, referans_tablo), ...]}
    relations = defaultdict(list)

    # Ters iliskiler: {referans_tablo: [bagli_tablolar]}
    reverse_relations = defaultdict(list)

    # Tablo istatistikleri
    table_stats = {}

    for table_name, table_data in tables.items():
        clean_table = clean_name(table_name)
        columns = table_data.get('columns', [])

        fk_count = 0
        for col in columns:
            col_name = col.get('name', '')
            reference = col.get('reference', '-')

            if reference and reference != '-' and reference.startswith('VEM_'):
                clean_ref = clean_name(reference)
                relations[clean_table].append((col_name, clean_ref))
                reverse_relations[clean_ref].append(clean_table)
                fk_count += 1

        table_stats[clean_table] = {
            'columns': len(columns),
            'fk_out': fk_count,  # Bu tablodan dışarı giden FK
            'fk_in': 0  # Bu tabloya gelen FK (sonra hesaplanacak)
        }

    # Gelen FK sayısını hesapla
    for ref_table, dependent_tables in reverse_relations.items():
        if ref_table in table_stats:
            table_stats[ref_table]['fk_in'] = len(dependent_tables)

    return relations, reverse_relations, table_stats

def print_relations():
    relations, reverse_relations, table_stats = analyze_relations()

    print("=" * 80)
    print("VEM 2.0 - TABLO ILISKILERI ANALIZI")
    print("=" * 80)

    # En cok referans alan tablolar (Master tablolar)
    print("\n" + "=" * 80)
    print("MASTER TABLOLAR (En cok referans alan)")
    print("=" * 80)

    sorted_by_fk_in = sorted(table_stats.items(), key=lambda x: x[1]['fk_in'], reverse=True)

    print(f"\n{'Tablo':<40} {'Kolon':<8} {'Gelen FK':<10} {'Giden FK':<10}")
    print("-" * 70)
    for table, stats in sorted_by_fk_in[:20]:
        print(f"{table:<40} {stats['columns']:<8} {stats['fk_in']:<10} {stats['fk_out']:<10}")

    # Detayli iliski listesi
    print("\n" + "=" * 80)
    print("DETAYLI ILISKI LISTESI")
    print("=" * 80)

    all_relations = []
    for table, rels in relations.items():
        for col, ref in rels:
            all_relations.append((table, col, ref))

    # Referans tablosuna gore grupla
    grouped = defaultdict(list)
    for table, col, ref in all_relations:
        grouped[ref].append((table, col))

    for ref_table in sorted(grouped.keys()):
        deps = grouped[ref_table]
        print(f"\n{ref_table} <-- ({len(deps)} tablo bagimli)")
        for dep_table, col in sorted(deps):
            print(f"    <- {dep_table}.{col}")

    # Markdown tablosu olustur
    print("\n" + "=" * 80)
    print("MARKDOWN TABLO (kopyalanabilir)")
    print("=" * 80)

    print("\n### Master Tablolar\n")
    print("| Tablo | Kolon | Gelen FK | Giden FK | Aciklama |")
    print("|-------|-------|----------|----------|----------|")

    for table, stats in sorted_by_fk_in[:30]:
        desc = get_table_description(table)
        print(f"| {table} | {stats['columns']} | {stats['fk_in']} | {stats['fk_out']} | {desc} |")

    # Iliski matrisi
    print("\n### Tum Iliskiler\n")
    print("| Kaynak Tablo | FK Kolon | Hedef Tablo |")
    print("|--------------|----------|-------------|")

    for table, col, ref in sorted(all_relations):
        print(f"| {table} | {col} | {ref} |")

    # JSON olarak kaydet
    output = {
        'master_tables': [{'table': t, **s} for t, s in sorted_by_fk_in],
        'relations': [{'from': t, 'column': c, 'to': r} for t, c, r in all_relations],
        'reverse_relations': {k: list(set(v)) for k, v in reverse_relations.items()}
    }

    with open('vem2_data/relations.json', 'w', encoding='utf-8') as f:
        json.dump(output, f, ensure_ascii=False, indent=2)

    print(f"\n\nToplam {len(all_relations)} iliski bulundu")
    print("Iliskiler kaydedildi: vem2_data/relations.json")

    return relations, reverse_relations, table_stats

def get_table_description(table):
    """Tablo aciklamasi"""
    descriptions = {
        'REFERANS_KODLAR': 'Tum referans/lookup verileri',
        'HASTA': 'Hasta ana kayitlari',
        'HASTA_BASVURU': 'Hasta basvuru/muayene kayitlari',
        'KULLANICI': 'Sistem kullanicilari',
        'BIRIM': 'Hastane birimleri/klinikleri',
        'PERSONEL': 'Personel kayitlari',
        'KURUM': 'Kurum/hastane bilgileri',
        'CIHAZ': 'Tibbi cihaz kayitlari',
        'HIZMET': 'Saglik hizmetleri tanimlari',
        'DEPO': 'Stok/depo tanimlari',
        'STOK_KART': 'Malzeme/ilac kartlari',
        'RECETE': 'Recete kayitlari',
        'TETKIK': 'Tetkik/test tanimlari',
        'FIRMA': 'Tedarikci firmalari',
        'BINA': 'Bina tanimlari',
        'ODA': 'Oda tanimlari',
        'YATAK': 'Yatak tanimlari',
    }
    return descriptions.get(table, '')

if __name__ == '__main__':
    print_relations()
