"""
VEM 2.0 Scraper - Dogru tablo ID'leri ile
"""

import sys
import io

if sys.platform == 'win32':
    sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8', errors='replace')

import requests
import json
import time
import os
from bs4 import BeautifulSoup
import urllib3

urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

class VEM2Scraper:
    def __init__(self):
        self.base_url = "https://vem.saglik.gov.tr"
        self.session = requests.Session()

        self.session.headers.update({
            'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36',
            'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8',
            'Accept-Language': 'tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7',
            'X-Requested-With': 'XMLHttpRequest',
        })

        self.output_dir = "vem2_data"

        # VEM 2.0 Tablo ID'leri (kullanicidan alinan)
        self.vem2_tables = {
            11785: "VEM_AMELIYAT",
            11786: "VEM_AMELIYAT_EKIP",
            11787: "VEM_AMELIYAT_ISLEM",
            11788: "VEM_ANLIK_YATAN_HASTA",
            11789: "VEM_ANTIBIYOTIK_SONUC",
            11790: "VEM_ASI_BILGISI",
            11791: "VEM_BAKTERI_SONUC",
            11792: "VEM_BASVURU_TANI",
            11793: "VEM_BASVURU_YEMEK",
            11794: "VEM_BEBEK_COCUK_IZLEM",
            11795: "VEM_BILDIRIMI_ZORUNLU",
            11796: "VEM_BINA",
            11797: "VEM_BIRIM",
            11798: "VEM_CIHAZ",
            11799: "VEM_COCUK_DIYABET",
            11800: "VEM_DEPO",
            11801: "VEM_DIS_TAAHHUT",
            11802: "VEM_DIS_TAAHHUT_DETAY",
            11803: "VEM_DISPROTEZ",
            11804: "VEM_DISPROTEZ_DETAY",
            11805: "VEM_DIYABET",
            11806: "VEM_DOGUM",
            11807: "VEM_DOGUM_DETAY",
            11808: "VEM_DOKTOR_MESAJI",
            11809: "VEM_EK_ODEME_DETAY",
            11925: "VEM_EK_ODEME",
            11810: "VEM_EK_ODEME_DONEM",
            11811: "VEM_EVDE_SAGLIK_IZLEM",
            11812: "VEM_FATURA",
            11813: "VEM_FIRMA",
            11814: "VEM_GEBE_IZLEM",
            11815: "VEM_GETAT",
            11816: "VEM_GRUP_UYELIK",
            11817: "VEM_HASTA",
            11818: "VEM_HASTA_ADLI_RAPOR",
            11819: "VEM_HASTA_ARSIV",
            11820: "VEM_HASTA_ARSIV_DETAY",
            11821: "VEM_HASTA_BASVURU",
            11822: "VEM_HASTA_BORC",
            11823: "VEM_HASTA_DIS",
            11824: "VEM_HASTA_EPIKRIZ",
            11825: "VEM_HASTA_FOTOGRAF",
            11826: "VEM_HASTA_GIZLILIK",
            11827: "VEM_HASTA_HIZMET",
            11828: "VEM_HASTA_ILETISIM",
            11829: "VEM_HASTA_MALZEME",
            11830: "VEM_HASTA_NOTLARI",
            11831: "VEM_HASTA_OLUM",
            11832: "VEM_HASTA_SEANS",
            11833: "VEM_HASTA_SEVK",
            11834: "VEM_HASTA_TIBBI_BILGI",
            11835: "VEM_HASTA_UYARI",
            11836: "VEM_HASTA_VENTILATOR",
            11837: "VEM_HASTA_VITAL_FIZIKI_BULGU",
            11838: "VEM_HASTA_YATAK",
            11839: "VEM_HEMOGLOBINOPATI",
            11840: "VEM_HEMSIRE_BAKIM",
            11841: "VEM_HIZMET",
            11842: "VEM_ICMAL",
            11843: "VEM_ILAC_UYUM",
            11844: "VEM_INTIHAR_IZLEM",
            11845: "VEM_KADIN_IZLEM",
            11846: "VEM_KAN_BAGISCI",
            11847: "VEM_KAN_CIKIS",
            11848: "VEM_KAN_STOK",
            11849: "VEM_KAN_TALEP",
            11850: "VEM_KAN_TALEP_DETAY",
            11851: "VEM_KAN_URUN",
            11852: "VEM_KAN_URUN_IMHA",
            11853: "VEM_KLINIK_SEYIR",
            11854: "VEM_KONSULTASYON",
            11855: "VEM_KUDUZ_IZLEM",
            11856: "VEM_KULLANICI",
            11857: "VEM_KULLANICI_GRUP",
            11858: "VEM_KURUL",
            11859: "VEM_KURUL_ASKERI",
            11860: "VEM_KURUL_ENGELLI",
            11861: "VEM_KURUL_ETKEN_MADDE",
            11862: "VEM_KURUL_HEKIM",
            11863: "VEM_KURUL_RAPOR",
            11864: "VEM_KURUL_TESHIS",
            11865: "VEM_KURUM",
            11866: "VEM_LOHUSA_IZLEM",
            11867: "VEM_MADDE_BAGIMLILIGI",
            11868: "VEM_MEDULA_TAKIP",
            11869: "VEM_NOBETCI_PERSONEL_BILGISI",
            11870: "VEM_OBEZITE_IZLEM",
            11871: "VEM_ODA",
            11872: "VEM_OPTIK_RECETE",
            11873: "VEM_ORTODONTI_ICON_SKOR",
            11874: "VEM_PATOLOJI",
            11875: "VEM_PERSONEL",
            11876: "VEM_PERSONEL_BAKMAKLA_YUKUMLU",
            11877: "VEM_PERSONEL_BANKA",
            11878: "VEM_PERSONEL_BORDRO",
            11879: "VEM_PERSONEL_BORDRO_SONDURUM",
            11880: "VEM_PERSONEL_EGITIM",
            11881: "VEM_PERSONEL_GOREVLENDIRME",
            11882: "VEM_PERSONEL_IZIN",
            11883: "VEM_PERSONEL_IZIN_DURUMU",
            11884: "VEM_PERSONEL_ODUL_CEZA",
            11885: "VEM_PERSONEL_OGRENIM",
            11886: "VEM_PERSONEL_YANDAL",
            11887: "VEM_RADYOLOJI",
            11888: "VEM_RADYOLOJI_SONUC",
            11889: "VEM_RANDEVU",
            11890: "VEM_RECETE",
            11891: "VEM_RECETE_ILAC",
            11892: "VEM_RECETE_ILAC_ACIKLAMA",
            11893: "VEM_RISK_SKORLAMA",
            11894: "VEM_RISK_SKORLAMA_DETAY",
            11895: "VEM_SILINEN_KAYITLAR",
            11896: "VEM_STERILIZASYON_CIKIS",
            11897: "VEM_STERILIZASYON_GIRIS",
            11898: "VEM_STERILIZASYON_PAKET",
            11899: "VEM_STERILIZASYON_PAKET_DETAY",
            11900: "VEM_STERILIZASYON_SET",
            11901: "VEM_STERILIZASYON_SET_DETAY",
            11902: "VEM_STERILIZASYON_STOK_DURUM",
            11903: "VEM_STERILIZASYON_YIKAMA",
            11904: "VEM_STOK_DURUM",
            11905: "VEM_STOK_EHU_TAKIP",
            11906: "VEM_STOK_FIS",
            11907: "VEM_STOK_HAREKET",
            11908: "VEM_STOK_ISTEK",
            11909: "VEM_STOK_ISTEK_HAREKET",
            11910: "VEM_STOK_ISTEK_UYGULAMA",
            11911: "VEM_STOK_KART",
            11912: "VEM_SYS_PAKET",
            11913: "VEM_TETKIK",
            11914: "VEM_TETKIK_CIHAZ_ESLESME",
            11915: "VEM_TETKIK_NUMUNE",
            11916: "VEM_TETKIK_PARAMETRE",
            11917: "VEM_TETKIK_REFERANS_ARALIK",
            11918: "VEM_TETKIK_SONUC",
            11919: "VEM_TIBBI_ORDER",
            11920: "VEM_TIBBI_ORDER_DETAY",
            11921: "VEM_VEZNE",
            11922: "VEM_VEZNE_DETAY",
            11923: "VEM_YATAK",
            11924: "VEM_REFERANS_KODLAR",
        }

    def fetch_page(self, url, retry=3):
        for attempt in range(retry):
            try:
                response = self.session.get(url, verify=False, timeout=30)
                response.raise_for_status()
                time.sleep(0.3)  # Rate limiting
                return response
            except Exception as e:
                print(f"    Hata (deneme {attempt+1}/{retry}): {e}")
                time.sleep(1)
        return None

    def get_table_detail(self, table_id, table_name):
        """Tablo detaylarini al"""
        url = f"{self.base_url}/Gorunum/Detay?id={table_id}"
        response = self.fetch_page(url)

        if not response:
            return None

        # HTML kaydet
        self.save_html(f"{table_name}.html", response.text)

        # Kolonlari parse et
        columns = self.parse_table_columns(response.text)

        return {
            "id": table_id,
            "name": table_name,
            "columns": columns
        }

    def parse_table_columns(self, html):
        """HTML'den kolon bilgilerini cikar"""
        soup = BeautifulSoup(html, 'html.parser')
        columns = []

        # Tablo satirlarini bul
        for tr in soup.find_all('tr'):
            tds = tr.find_all('td')
            if len(tds) >= 3:
                try:
                    no = tds[0].get_text().strip()
                    if no.isdigit():
                        column = {
                            "no": int(no),
                            "name": tds[1].get_text().strip() if len(tds) > 1 else "",
                            "type": tds[2].get_text().strip() if len(tds) > 2 else "",
                            "description": tds[3].get_text().strip() if len(tds) > 3 else "",
                            "nullable": tds[4].get_text().strip() if len(tds) > 4 else "",
                            "reference": tds[5].get_text().strip() if len(tds) > 5 else "",
                        }
                        columns.append(column)
                except:
                    pass

        return columns

    def save_html(self, filename, content):
        os.makedirs(self.output_dir, exist_ok=True)
        filepath = os.path.join(self.output_dir, filename)
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(content)

    def save_json(self, filename, data):
        os.makedirs(self.output_dir, exist_ok=True)
        filepath = os.path.join(self.output_dir, filename)
        with open(filepath, 'w', encoding='utf-8') as f:
            json.dump(data, f, ensure_ascii=False, indent=2)

    def run(self):
        print("="*60)
        print("VEM 2.0 Scraper - 140 Tablo")
        print("="*60)

        all_tables = {}
        total = len(self.vem2_tables)

        for i, (table_id, table_name) in enumerate(self.vem2_tables.items(), 1):
            print(f"[{i}/{total}] {table_name}...", end=" ")

            result = self.get_table_detail(table_id, table_name)
            if result:
                col_count = len(result['columns'])
                print(f"{col_count} kolon")
                all_tables[table_name] = result
            else:
                print("HATA!")

        # JSON kaydet
        self.save_json("VEM_2.0_all_tables.json", all_tables)

        # Ozet
        print("\n" + "="*60)
        print("SONUC")
        print("="*60)
        print(f"Toplam {len(all_tables)} tablo indirildi")

        total_cols = sum(len(t['columns']) for t in all_tables.values())
        print(f"Toplam {total_cols} kolon")

        print(f"\nDosyalar '{self.output_dir}' klasorune kaydedildi:")
        print(f"  - VEM_2.0_all_tables.json (tum veriler)")
        print(f"  - [TABLO_ADI].html (her tablo icin HTML)")


if __name__ == "__main__":
    scraper = VEM2Scraper()
    scraper.run()
