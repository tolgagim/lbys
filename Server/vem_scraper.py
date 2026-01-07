"""
VEM Saglik Bakanligi Veri Modeli Scraper
Site icerigini indirir ve JSON olarak kaydeder
"""

import sys
import io

# Windows console encoding fix
if sys.platform == 'win32':
    sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8', errors='replace')

import requests
import json
import time
import re
import os
from urllib.parse import urljoin, urlparse
from bs4 import BeautifulSoup
import urllib3

# SSL uyarilarini kapat
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)

class VEMScraper:
    def __init__(self):
        self.base_url = "https://vem.saglik.gov.tr"
        self.session = requests.Session()

        # Gercek tarayici gibi gorunmek icin headers
        self.session.headers.update({
            'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36',
            'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8',
            'Accept-Language': 'tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7',
            'Accept-Encoding': 'gzip, deflate, br',
            'Connection': 'keep-alive',
            'Upgrade-Insecure-Requests': '1',
        })

        self.visited_urls = set()
        self.veri_setleri = {}
        self.output_dir = "vem_data"

    def fetch_page(self, url, retry=3):
        """Sayfayi indir, hata durumunda tekrar dene"""
        for attempt in range(retry):
            try:
                print(f"  Indiriliyor: {url}")
                response = self.session.get(url, verify=False, timeout=30)
                response.raise_for_status()
                time.sleep(1)  # Rate limiting
                return response
            except Exception as e:
                print(f"  Hata (deneme {attempt+1}/{retry}): {e}")
                time.sleep(2)
        return None

    def get_main_page(self):
        """Ana sayfayi al ve menu linklerini bul"""
        print("\n[1/4] Ana sayfa indiriliyor...")
        response = self.fetch_page(self.base_url)
        if not response:
            return []

        # HTML'i kaydet
        self.save_html("anasayfa.html", response.text)

        soup = BeautifulSoup(response.text, 'html.parser')

        # Tum linkleri bul
        links = []
        for a in soup.find_all('a', href=True):
            href = a['href']
            full_url = urljoin(self.base_url, href)
            if self.base_url in full_url and full_url not in self.visited_urls:
                links.append(full_url)
                self.visited_urls.add(full_url)

        print(f"  Bulunan link sayisi: {len(links)}")
        return links

    def get_veri_seti_list(self):
        """Veri seti listesini al"""
        print("\n[2/4] Veri seti sayfasi kontrol ediliyor...")

        # Farkli endpoint'leri dene
        endpoints = [
            "/Home/Index",
            "/VeriSeti/Index",
            "/AppRel/Index",
            "/VeriSeti",
            "/api/VeriSeti/GetAll",
            "/api/veriseti/list",
        ]

        for endpoint in endpoints:
            url = self.base_url + endpoint
            response = self.fetch_page(url)
            if response and response.status_code == 200:
                filename = f"veriseti{endpoint.replace('/', '_')}.html"
                self.save_html(filename, response.text)

                # Sayfadan veri seti isimlerini cikar
                self.extract_veri_setleri(response.text)

    def extract_veri_setleri(self, html):
        """HTML'den veri seti isimlerini cikar"""
        soup = BeautifulSoup(html, 'html.parser')

        # VEM_ ile baslayan metinleri bul
        vem_pattern = re.compile(r'VEM_[A-Z_]+|AHBS_[A-Z_]+')

        # Tum metinlerde ara
        text = soup.get_text()
        matches = vem_pattern.findall(text)

        for match in set(matches):
            if match not in self.veri_setleri:
                self.veri_setleri[match] = {"name": match, "columns": []}
                print(f"  Bulunan veri seti: {match}")

        # Ayrica menu ogelerini kontrol et
        for li in soup.find_all('li'):
            text = li.get_text().strip()
            if text.startswith('VEM_') or text.startswith('AHBS_'):
                if text not in self.veri_setleri:
                    self.veri_setleri[text] = {"name": text, "columns": []}
                    print(f"  Bulunan veri seti (menu): {text}")

    def scrape_all_pages(self, links):
        """Tum sayfalari tara"""
        print(f"\n[3/4] {len(links)} sayfa taraniyor...")

        for i, url in enumerate(links):
            print(f"\n  [{i+1}/{len(links)}] {url}")
            response = self.fetch_page(url)
            if response:
                # Dosya adi olustur
                parsed = urlparse(url)
                filename = parsed.path.replace('/', '_') or 'index'
                filename = f"page{filename}.html"

                self.save_html(filename, response.text)
                self.extract_veri_setleri(response.text)
                self.extract_table_columns(response.text)

    def extract_table_columns(self, html):
        """HTML'den tablo kolon bilgilerini cikar"""
        soup = BeautifulSoup(html, 'html.parser')

        # Tablo yapilarini bul
        tables = soup.find_all('table')
        for table in tables:
            headers = []
            for th in table.find_all('th'):
                headers.append(th.get_text().strip())

            rows = []
            for tr in table.find_all('tr'):
                row = []
                for td in tr.find_all('td'):
                    row.append(td.get_text().strip())
                if row:
                    rows.append(row)

            # Kolon bilgisi gibi gorunuyorsa kaydet
            if headers and any('kolon' in h.lower() or 'alan' in h.lower() or 'tip' in h.lower() for h in headers):
                print(f"  Tablo yapisi bulundu: {headers[:3]}...")

    def try_api_endpoints(self):
        """API endpoint'lerini dene"""
        print("\n[4/4] API endpoint'leri deneniyor...")

        api_endpoints = [
            "/api/VeriSeti/GetAll",
            "/api/VeriSeti/List",
            "/api/veri-seti",
            "/VeriSeti/GetList",
            "/Home/GetVeriSetleri",
            "/AppRel/GetData",
        ]

        for endpoint in api_endpoints:
            url = self.base_url + endpoint
            try:
                response = self.session.get(url, verify=False, timeout=10)
                if response.status_code == 200:
                    print(f"  API bulundu: {endpoint}")

                    # JSON ise parse et
                    try:
                        data = response.json()
                        self.save_json(f"api{endpoint.replace('/', '_')}.json", data)
                        print(f"  JSON veri kaydedildi")
                    except:
                        self.save_html(f"api{endpoint.replace('/', '_')}.html", response.text)
            except:
                pass

    def save_html(self, filename, content):
        """HTML dosyasini kaydet"""
        os.makedirs(self.output_dir, exist_ok=True)
        filepath = os.path.join(self.output_dir, filename)
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(content)

    def save_json(self, filename, data):
        """JSON dosyasini kaydet"""
        os.makedirs(self.output_dir, exist_ok=True)
        filepath = os.path.join(self.output_dir, filename)
        with open(filepath, 'w', encoding='utf-8') as f:
            json.dump(data, f, ensure_ascii=False, indent=2)

    def save_results(self):
        """Sonuclari kaydet"""
        print("\n" + "="*50)
        print("SONUCLAR")
        print("="*50)

        # Bulunan veri setlerini kaydet
        self.save_json("veri_setleri.json", self.veri_setleri)

        print(f"\nBulunan veri seti sayisi: {len(self.veri_setleri)}")
        print("\nVeri setleri:")
        for name in sorted(self.veri_setleri.keys()):
            print(f"  - {name}")

        print(f"\nTum dosyalar '{self.output_dir}' klasorune kaydedildi.")

    def run(self):
        """Ana calistirma fonksiyonu"""
        print("="*50)
        print("VEM Saglik Bakanligi Scraper")
        print("="*50)

        # 1. Ana sayfayi al
        links = self.get_main_page()

        # 2. Veri seti listesini al
        self.get_veri_seti_list()

        # 3. API endpoint'lerini dene
        self.try_api_endpoints()

        # 4. Tum sayfalari tara (ilk 20 link)
        self.scrape_all_pages(links[:20])

        # 5. Sonuclari kaydet
        self.save_results()


if __name__ == "__main__":
    scraper = VEMScraper()
    scraper.run()
