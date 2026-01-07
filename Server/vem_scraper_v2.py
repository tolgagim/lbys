"""
VEM Saglik Bakanligi Veri Modeli Scraper v2
Tum tablo detaylarini indirir
"""

import sys
import io

if sys.platform == 'win32':
    sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8', errors='replace')

import requests
import json
import time
import re
import os
from bs4 import BeautifulSoup
import urllib3

urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

class VEMScraperV2:
    def __init__(self):
        self.base_url = "https://vem.saglik.gov.tr"
        self.session = requests.Session()

        self.session.headers.update({
            'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36',
            'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8',
            'Accept-Language': 'tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7',
            'X-Requested-With': 'XMLHttpRequest',
        })

        self.output_dir = "vem_data"
        self.tables = {}

        # Surum ID'leri (HTML'den)
        self.versions = {
            510: "AHBS_VEM_1.2",
            501: "VEM 2.0",
            366: "AHBS_VEM_1.1",
            7: "SAMILOG.1.0",
            6: "AHBS_VEM.1.0",
            4: "Vem.1.2",
            3: "PVem.1.0",
            2: "Vem.1.1",
            1: "Vem 1.0"
        }

        # AHBS_VEM_1.2 tablo ID'leri (HTML'den)
        self.ahbs_tables = {
            12043: "AHBS_ASI_BILGISI",
            12044: "AHBS_ASI_ERTELEME",
            12045: "AHBS_ASI_SONRA_ISTENMEYEN_ETKI",
            12046: "AHBS_BEBEK_COCUK_IZLEM",
            12047: "AHBS_BEBEK_COCUK_IZLEM_DETAY",
            12048: "AHBS_BULASICI_HASTALIK",
            12049: "AHBS_COCUK_GENCLIK_IZLEM",
            12050: "AHBS_DIYABET",
            12051: "AHBS_DOGUM",
            12052: "AHBS_EVDE_SAGLIK_IZLEM",
            12053: "AHBS_EVDE_SAGLIK_IZLEM_DETAY",
            12054: "AHBS_GEBE_BILDIRIM",
            12055: "AHBS_GEBE_BILDIRIM_DETAY",
            12056: "AHBS_GEBE_IZLEM",
            12057: "AHBS_GEBE_IZLEM_DETAY",
            12058: "AHBS_GEBELIK_SONUCU",
            12059: "AHBS_HEMOGLOBINOPATI_TARAMA",
            12060: "AHBS_KISI_ILETISIM",
            12061: "AHBS_KADIN_IZLEM",
            12062: "AHBS_KADIN_IZLEM_DETAY",
            12063: "AHBS_KADINA_SIDDET",
            12064: "AHBS_KANSER_TARAMA",
            12065: "AHBS_KANSER_TARAMA_DETAY",
            12066: "AHBS_KISI",
            12067: "AHBS_KISI_BASVURU",
            12068: "AHBS_KISI_OZLUK",
            12069: "AHBS_KISI_OZLUK_DETAY",
            12070: "AHBS_KRONIK_HASTALIKLAR",
            12071: "AHBS_KUDUZ_PROFILAKSI_IZLEM",
            12072: "AHBS_KUDUZ_RISKLI_TEMAS",
            12073: "AHBS_KULLANICI",
            12074: "AHBS_LOHUSA_IZLEM",
            12075: "AHBS_LOHUSA_IZLEM_DETAY",
            12076: "AHBS_MELIS_ISTEM",
            12077: "AHBS_MELIS_ISTEM_IPTAL",
            12078: "AHBS_OBEZITE_IZLEM",
            12079: "AHBS_OZELLIKLI_IZLEM",
            12080: "AHBS_RAPOR",
            12081: "AHBS_RECETE",
            12082: "AHBS_SEVK",
            12083: "AHBS_TANI",
            12084: "AHBS_TETKIK_ISTEM",
            12085: "AHBS_TETKIK_SONUC",
            12042: "AHBS_REFERANS_KODLAR",
        }

    def fetch_page(self, url, retry=3):
        for attempt in range(retry):
            try:
                response = self.session.get(url, verify=False, timeout=30)
                response.raise_for_status()
                time.sleep(0.5)
                return response
            except Exception as e:
                print(f"  Hata (deneme {attempt+1}/{retry}): {e}")
                time.sleep(2)
        return None

    def change_version(self, version_id):
        """Surum degistir"""
        print(f"\nSurum degistiriliyor: {self.versions.get(version_id, version_id)}")

        # Cookie ile surum degistir
        self.session.cookies.set('AktifSurum', str(version_id))

        # Ana sayfaya git
        response = self.fetch_page(f"{self.base_url}/Home/Index")
        return response is not None

    def get_table_list_for_version(self, version_id):
        """Belirli surum icin tablo listesini al"""
        self.change_version(version_id)

        url = f"{self.base_url}/Home/Index"
        response = self.fetch_page(url)

        if not response:
            return {}

        soup = BeautifulSoup(response.text, 'html.parser')
        tables = {}

        # onclick="Detay(ID)" pattern'ini bul
        for a in soup.find_all('a', onclick=True):
            onclick = a.get('onclick', '')
            match = re.search(r'Detay\((\d+)\)', onclick)
            if match:
                table_id = int(match.group(1))
                table_name = a.get_text().strip()
                tables[table_id] = table_name

        return tables

    def get_table_detail(self, table_id, table_name):
        """Tablo detaylarini al"""
        print(f"  Indiriliyor: {table_name} (ID: {table_id})")

        url = f"{self.base_url}/Gorunum/Detay?id={table_id}"
        response = self.fetch_page(url)

        if not response:
            return None

        # HTML kaydet
        self.save_html(f"table_{table_name}.html", response.text)

        # Kolonlari parse et
        columns = self.parse_table_columns(response.text, table_name)

        return {
            "id": table_id,
            "name": table_name,
            "columns": columns,
            "html": response.text
        }

    def parse_table_columns(self, html, table_name):
        """HTML'den kolon bilgilerini cikar"""
        soup = BeautifulSoup(html, 'html.parser')
        columns = []

        # Tablo satirlarini bul
        for tr in soup.find_all('tr'):
            tds = tr.find_all('td')
            if len(tds) >= 3:
                try:
                    # Tipik yapi: No, Kolon Adi, Veri Tipi, ...
                    no = tds[0].get_text().strip()
                    if no.isdigit():
                        column = {
                            "no": int(no),
                            "name": tds[1].get_text().strip() if len(tds) > 1 else "",
                            "type": tds[2].get_text().strip() if len(tds) > 2 else "",
                            "length": tds[3].get_text().strip() if len(tds) > 3 else "",
                            "nullable": tds[4].get_text().strip() if len(tds) > 4 else "",
                            "description": tds[5].get_text().strip() if len(tds) > 5 else "",
                        }
                        columns.append(column)
                except:
                    pass

        if columns:
            print(f"    {len(columns)} kolon bulundu")

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
        print("VEM Saglik Bakanligi Scraper v2 - Tablo Detaylari")
        print("="*60)

        all_tables = {}

        # 1. AHBS_VEM_1.2 tablolarini indir (varsayilan)
        print("\n" + "="*60)
        print("AHBS_VEM_1.2 Tablolari Indiriliyor...")
        print("="*60)

        ahbs_data = {}
        for table_id, table_name in self.ahbs_tables.items():
            result = self.get_table_detail(table_id, table_name)
            if result:
                ahbs_data[table_name] = result

        all_tables["AHBS_VEM_1.2"] = ahbs_data
        self.save_json("AHBS_VEM_1.2_tables.json", ahbs_data)

        # 2. VEM 2.0 tablolarini dene
        print("\n" + "="*60)
        print("VEM 2.0 Tablolari Aranıyor...")
        print("="*60)

        vem2_tables = self.get_table_list_for_version(501)
        print(f"VEM 2.0'da {len(vem2_tables)} tablo bulundu")

        if vem2_tables:
            vem2_data = {}
            for table_id, table_name in vem2_tables.items():
                result = self.get_table_detail(table_id, table_name)
                if result:
                    vem2_data[table_name] = result

            all_tables["VEM_2.0"] = vem2_data
            self.save_json("VEM_2.0_tables.json", vem2_data)

        # Sonuclari kaydet
        self.save_json("all_tables.json", all_tables)

        # Ozet
        print("\n" + "="*60)
        print("SONUC")
        print("="*60)

        for version, tables in all_tables.items():
            print(f"\n{version}: {len(tables)} tablo")
            for name, data in tables.items():
                col_count = len(data.get('columns', []))
                print(f"  - {name}: {col_count} kolon")

        print(f"\nTum dosyalar '{self.output_dir}' klasorune kaydedildi.")


if __name__ == "__main__":
    scraper = VEMScraperV2()
    scraper.run()
