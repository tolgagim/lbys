"""
VEM Seed Data Generator
Generates consistent, related seed data for all VEM tables
"""

import random
import json
from datetime import datetime, timedelta
from typing import List, Dict, Any
import uuid

# Seed for reproducibility
random.seed(42)

# =============================================================================
# CONFIGURATION
# =============================================================================

NUM_PERSONEL = 50
NUM_HASTA = 100
NUM_BASVURU = 200
NUM_KULLANICI = NUM_PERSONEL + 1  # +1 for admin

# =============================================================================
# HELPER FUNCTIONS
# =============================================================================

def generate_tc_kimlik():
    """Generate valid-looking TC Kimlik No"""
    digits = [random.randint(1, 9)] + [random.randint(0, 9) for _ in range(9)]
    digits.append(sum(digits) % 10)
    return ''.join(map(str, digits))

def generate_date_range(start_year=2020, end_year=2025):
    """Generate random date"""
    start = datetime(start_year, 1, 1)
    end = datetime(end_year, 12, 31)
    delta = end - start
    random_days = random.randint(0, delta.days)
    return start + timedelta(days=random_days)

def random_choice(items):
    return random.choice(items) if items else None

# =============================================================================
# REFERENCE DATA
# =============================================================================

CINSIYET = ["E", "K"]
KAN_GRUPLARI = ["A_RH_POZITIF", "A_RH_NEGATIF", "B_RH_POZITIF", "B_RH_NEGATIF",
                "AB_RH_POZITIF", "AB_RH_NEGATIF", "0_RH_POZITIF", "0_RH_NEGATIF"]
MEDENI_HAL = ["EVLI", "BEKAR", "DUL", "BOSANMIS"]
ULKE_KODLARI = ["TC", "TR", "DE", "FR", "GB", "US", "RU", "AZ", "IR", "IQ", "SY"]
ILLER = ["06", "34", "35", "16", "01", "07", "42", "27", "33", "31"]  # Ankara, Istanbul, etc.
ILCELER = ["CANKAYA", "KECIOREN", "MAMAK", "ETIMESGUT", "YENIMAHALLE"]

BIRIM_TURLERI = ["POLIKLINIK", "SERVIS", "YOGUN_BAKIM", "AMELIYATHANE", "ACIL", "LABORATUVAR", "RADYOLOJI"]
KLINIK_KODLARI = ["DAHILIYE", "CERRAHI", "KARDIYOLOJI", "NOROLOJI", "ORTOPEDI", "PEDIATRI", "DERMATOLOJI", "PSIKIYATRI"]

UNVANLAR = ["PROF_DR", "DOC_DR", "UZM_DR", "DR", "HEMSIRE", "TEKNIKER", "SEKRETER", "TEMIZLIK"]
GOREV_TURLERI = ["HEKIM", "HEMSIRE", "TEKNIKER", "IDARI", "DESTEK"]

BASVURU_DURUMLARI = ["AKTIF", "TAMAMLANDI", "IPTAL"]
TEDAVI_TURLERI = ["AYAKTAN", "YATARAK", "GUNUBIRLIK"]
CIKIS_SEKILLERI = ["SIFA", "SEVK", "VEFAT", "KENDI_ISTEGI", "TABURCU"]

TANI_KODLARI = ["J06.9", "K29.7", "I10", "E11.9", "J45.9", "M54.5", "R51", "N39.0", "K80.2", "J18.9"]
TANI_TURLERI = ["KESIN", "ON", "SORGULANAN"]

HIZMET_GRUPLARI = ["MUAYENE", "AMELIYAT", "TETKIK", "RADYOLOJI", "LABORATUVAR"]
HIZMET_TURLERI = ["POLIKLINIK", "YATAN", "ACIL", "GUNUBIRLIK"]

DIYABET_KOMPLIKASYONLARI = ["YOK", "RETINOPATI", "NEFROPATI", "NOROPATI", "KAH", "AYAK_ULSERI"]
DIYABET_EGITIMI = ["VERILDI", "VERILMEDI", "PLANLI", "REDDETTI"]

FATURA_TURLERI = ["YATAN", "AYAKTAN", "ACIL", "GUNUBIRLIK"]
STOK_ISTEK_DURUMLARI = ["BEKLEMEDE", "ONAYLANDI", "TAMAMLANDI", "IPTAL"]

MESLEKLER = ["MEMUR", "ISCI", "ESNAF", "DOKTOR", "OGRETMEN", "MUHENDIS", "AVUKAT", "EMEKLI", "OGRENCI", "EV_HANIMI", "CIFTCI", "SERBEST_MESLEK"]

AD_LISTESI = ["Ahmet", "Mehmet", "Mustafa", "Ali", "Hasan", "Huseyin", "Ibrahim", "Osman", "Yusuf", "Ismail",
              "Ayse", "Fatma", "Emine", "Hatice", "Zeynep", "Elif", "Merve", "Esra", "Kubra", "Seda"]
SOYAD_LISTESI = ["Yilmaz", "Kaya", "Demir", "Celik", "Sahin", "Yildiz", "Ozturk", "Aydin", "Ozdemir", "Arslan",
                  "Dogan", "Kilic", "Aslan", "Cetin", "Kara", "Koc", "Kurt", "Ozkan", "Simsek", "Polat"]

# =============================================================================
# SEED DATA GENERATORS
# =============================================================================

class SeedDataGenerator:
    def __init__(self):
        self.kullanicilar: List[Dict] = []
        self.personeller: List[Dict] = []
        self.birimler: List[Dict] = []
        self.hastalar: List[Dict] = []
        self.basvurular: List[Dict] = []
        self.referans_kodlar: List[Dict] = []

    def get_random_kullanici_kodu(self) -> str:
        """Get a random valid KULLANICI_KODU"""
        if self.kullanicilar:
            return random.choice(self.kullanicilar)["KULLANICI_KODU"]
        return "KLN-001"

    def get_random_personel_kodu(self, gorev_turu=None) -> str:
        """Get a random PERSONEL_KODU, optionally filtered by role"""
        if gorev_turu:
            filtered = [p for p in self.personeller if p.get("GOREV_TURU") == gorev_turu]
            if filtered:
                return random.choice(filtered)["PERSONEL_KODU"]
        if self.personeller:
            return random.choice(self.personeller)["PERSONEL_KODU"]
        return "PRS-001"

    def get_random_hekim_kodu(self) -> str:
        """Get a random doctor's PERSONEL_KODU"""
        hekimler = [p for p in self.personeller if p.get("GOREV_TURU") == "HEKIM"]
        if hekimler:
            return random.choice(hekimler)["PERSONEL_KODU"]
        return self.get_random_personel_kodu()

    def get_random_birim_kodu(self) -> str:
        if self.birimler:
            return random.choice(self.birimler)["BIRIM_KODU"]
        return "BRM-001"

    def get_random_hasta_kodu(self) -> str:
        if self.hastalar:
            return random.choice(self.hastalar)["HASTA_KODU"]
        return "HST-001"

    def get_random_basvuru_kodu(self) -> str:
        if self.basvurular:
            return random.choice(self.basvurular)["HASTA_BASVURU_KODU"]
        return "BSV-001"

    def get_audit_fields(self) -> Dict:
        """Get standard audit fields with valid KULLANICI_KODU"""
        kullanici = self.get_random_kullanici_kodu()
        now = datetime.now()
        return {
            "EKLEYEN_KULLANICI_KODU": kullanici,
            "KAYIT_ZAMANI": now.isoformat(),
            "GUNCELLEYEN_KULLANICI_KODU": kullanici,
            "GUNCELLEME_ZAMANI": now.isoformat()
        }

    # -------------------------------------------------------------------------
    # REFERANS KODLAR
    # -------------------------------------------------------------------------
    def generate_referans_kodlar(self):
        """Generate all reference codes"""
        ref_data = {
            "ULKE_KODU": {
                "TC": "Turkiye Cumhuriyeti",
                "TR": "Turkiye",
                "DE": "Almanya",
                "FR": "Fransa",
                "GB": "Birlesik Krallik",
                "US": "Amerika Birlesik Devletleri",
                "RU": "Rusya",
                "AZ": "Azerbaycan",
                "IR": "Iran",
                "IQ": "Irak",
                "SY": "Suriye"
            },
            "CINSIYET": {"E": "Erkek", "K": "Kadin"},
            "MEDENI_HALI": {"EVLI": "Evli", "BEKAR": "Bekar", "DUL": "Dul", "BOSANMIS": "Bosanmis"},
            "KAN_GRUBU": {k: k.replace("_", " ") for k in KAN_GRUPLARI},
            "DIYABET_KOMPLIKASYONLARI": {
                "YOK": "Komplikasyon Yok",
                "RETINOPATI": "Diyabetik Retinopati",
                "NEFROPATI": "Diyabetik Nefropati",
                "NOROPATI": "Diyabetik Noropati",
                "KAH": "Koroner Arter Hastaligi",
                "AYAK_ULSERI": "Diyabetik Ayak Ulseri"
            },
            "DIYABET_EGITIMI": {
                "VERILDI": "Egitim Verildi",
                "VERILMEDI": "Egitim Verilmedi",
                "PLANLI": "Egitim Planlandi",
                "REDDETTI": "Hasta Reddetti"
            },
            "MESLEK": {k: k.replace("_", " ").title() for k in MESLEKLER},
            "FATURA_TURU": {k: k.replace("_", " ").title() for k in FATURA_TURLERI},
            "STOK_ISTEK_DURUMU": {k: k.replace("_", " ").title() for k in STOK_ISTEK_DURUMLARI},
            "TANI_TURU": {"KESIN": "Kesin Tani", "ON": "On Tani", "SORGULANAN": "Sorgulanan Tani"},
            "BIRIM_TURU": {k: k.replace("_", " ").title() for k in BIRIM_TURLERI},
            "KLINIK_KODU": {f"KLINIK_KODU_{k}": k.title() for k in KLINIK_KODLARI},
            "TEDAVI_TURU": {k: k.replace("_", " ").title() for k in TEDAVI_TURLERI},
            "CIKIS_SEKLI": {k: k.replace("_", " ").title() for k in CIKIS_SEKILLERI},
            "BASVURU_DURUMU": {k: k.replace("_", " ").title() for k in BASVURU_DURUMLARI},
            "UNVAN_KODU": {k: k.replace("_", " ").title() for k in UNVANLAR},
            "GOREV_TURU": {k: k.replace("_", " ").title() for k in GOREV_TURLERI},
            "HIZMET_ISLEM_GRUBU": {f"HZG-{k[:3].upper()}": k.title() for k in HIZMET_GRUPLARI},
            "HIZMET_ISLEM_TURU": {k: k.title() for k in HIZMET_TURLERI},
        }

        # Add ICD-10 codes
        icd_data = {
            "J06.9": "Akut ust solunum yolu enfeksiyonu",
            "K29.7": "Gastrit, tanimlanmamis",
            "I10": "Esansiyel hipertansiyon",
            "E11.9": "Tip 2 diabetes mellitus",
            "J45.9": "Astim",
            "M54.5": "Bel agrisi",
            "R51": "Bas agrisi",
            "N39.0": "Idrar yolu enfeksiyonu",
            "K80.2": "Safra kesesi tasi",
            "J18.9": "Pnomoni"
        }
        ref_data["ICD10_TANI"] = icd_data

        for kod_turu, kodlar in ref_data.items():
            for kod, ad in kodlar.items():
                self.referans_kodlar.append({
                    "REFERANS_KODU": kod,
                    "KOD_TURU": kod_turu,
                    "REFERANS_ADI": ad,
                    "MEDULA_KODU": kod,
                    "SKRS_KODU": kod,
                    "SUT_KODU": kod,
                    "SBIS_KODU": kod
                })

        return self.referans_kodlar

    # -------------------------------------------------------------------------
    # KULLANICI
    # -------------------------------------------------------------------------
    def generate_kullanicilar(self):
        """Generate users - must be called after personeller"""
        # First create admin user
        self.kullanicilar.append({
            "KULLANICI_KODU": "KLN-ADMIN",
            "KULLANICI_ADI": "admin",
            "AD": "Admin",
            "SOYADI": "User",
            "AKTIFLIK_BILGISI": "1",
            "KAYIT_ZAMANI": datetime.now().isoformat()
        })

        # Create users for each personnel
        for i, personel in enumerate(self.personeller, 1):
            self.kullanicilar.append({
                "KULLANICI_KODU": f"KLN-{i:03d}",
                "PERSONEL_KODU": personel["PERSONEL_KODU"],
                "KULLANICI_ADI": f"{personel['AD'].lower()}.{personel['SOYADI'].lower()}",
                "AD": personel["AD"],
                "SOYADI": personel["SOYADI"],
                "TC_KIMLIK_NUMARASI": personel.get("TC_KIMLIK_NUMARASI"),
                "AKTIFLIK_BILGISI": "1",
                "EKLEYEN_KULLANICI_KODU": "KLN-ADMIN",
                "KAYIT_ZAMANI": datetime.now().isoformat()
            })

        return self.kullanicilar

    # -------------------------------------------------------------------------
    # PERSONEL
    # -------------------------------------------------------------------------
    def generate_personeller(self):
        """Generate personnel"""
        for i in range(1, NUM_PERSONEL + 1):
            cinsiyet = random.choice(CINSIYET)
            if cinsiyet == "E":
                ad = random.choice(AD_LISTESI[:10])
            else:
                ad = random.choice(AD_LISTESI[10:])

            soyad = random.choice(SOYAD_LISTESI)
            gorev_turu = random.choice(GOREV_TURLERI)
            unvan = random.choice(UNVANLAR[:4]) if gorev_turu == "HEKIM" else random.choice(UNVANLAR[4:])

            dogum = generate_date_range(1960, 2000)

            self.personeller.append({
                "PERSONEL_KODU": f"PRS-{i:03d}",
                "AD": ad,
                "SOYADI": soyad,
                "TC_KIMLIK_NUMARASI": generate_tc_kimlik(),
                "CINSIYET": cinsiyet,
                "DOGUM_TARIHI": dogum.strftime("%Y-%m-%d"),
                "UNVAN_KODU": unvan,
                "GOREV_TURU": gorev_turu,
                "CALISTIGI_BIRIM_KODU": f"BRM-{random.randint(1, 10):03d}",
                "AKTIFLIK_BILGISI": "1",
                "EKLEYEN_KULLANICI_KODU": "KLN-ADMIN",
                "KAYIT_ZAMANI": datetime.now().isoformat()
            })

        return self.personeller

    # -------------------------------------------------------------------------
    # BIRIM
    # -------------------------------------------------------------------------
    def generate_birimler(self):
        """Generate departments/units"""
        birim_adlari = [
            ("Dahiliye Poliklinigi", "POLIKLINIK", "DAHILIYE"),
            ("Cerrahi Poliklinigi", "POLIKLINIK", "CERRAHI"),
            ("Kardiyoloji Poliklinigi", "POLIKLINIK", "KARDIYOLOJI"),
            ("Noroloji Poliklinigi", "POLIKLINIK", "NOROLOJI"),
            ("Ortopedi Poliklinigi", "POLIKLINIK", "ORTOPEDI"),
            ("Dahiliye Servisi", "SERVIS", "DAHILIYE"),
            ("Cerrahi Servisi", "SERVIS", "CERRAHI"),
            ("Yogun Bakim Unitesi", "YOGUN_BAKIM", "DAHILIYE"),
            ("Acil Servis", "ACIL", None),
            ("Laboratuvar", "LABORATUVAR", None),
        ]

        for i, (ad, tur, klinik) in enumerate(birim_adlari, 1):
            birim = {
                "BIRIM_KODU": f"BRM-{i:03d}",
                "BIRIM_ADI": ad,
                "BIRIM_TURU": tur,
                "AKTIFLIK_BILGISI": "1",
                **self.get_audit_fields()
            }
            if klinik:
                birim["KLINIK_KODU"] = f"KLINIK_KODU_{klinik}"
            self.birimler.append(birim)

        return self.birimler

    # -------------------------------------------------------------------------
    # HASTA
    # -------------------------------------------------------------------------
    def generate_hastalar(self):
        """Generate patients"""
        for i in range(1, NUM_HASTA + 1):
            cinsiyet = random.choice(CINSIYET)
            if cinsiyet == "E":
                ad = random.choice(AD_LISTESI[:10])
            else:
                ad = random.choice(AD_LISTESI[10:])

            soyad = random.choice(SOYAD_LISTESI)
            dogum = generate_date_range(1940, 2020)

            self.hastalar.append({
                "HASTA_KODU": f"HST-{i:05d}",
                "AD": ad,
                "SOYADI": soyad,
                "TC_KIMLIK_NUMARASI": generate_tc_kimlik(),
                "CINSIYET": cinsiyet,
                "DOGUM_TARIHI": dogum.strftime("%Y-%m-%d"),
                "UYRUK": "TC",  # Using valid ULKE_KODU reference
                "MEDENI_HALI": random.choice(MEDENI_HAL),
                "KAN_GRUBU": random.choice(KAN_GRUPLARI),
                "MESLEK": random.choice(MESLEKLER),
                "IL_KODU": random.choice(ILLER),
                "ILCE_KODU": random.choice(ILCELER),
                "ANNE_ADI": random.choice(AD_LISTESI[10:]),
                "BABA_ADI": random.choice(AD_LISTESI[:10]),
                "AKTIFLIK_BILGISI": "1",
                **self.get_audit_fields()
            })

        return self.hastalar

    # -------------------------------------------------------------------------
    # HASTA_BASVURU
    # -------------------------------------------------------------------------
    def generate_basvurular(self):
        """Generate patient visits"""
        for i in range(1, NUM_BASVURU + 1):
            hasta = random.choice(self.hastalar)
            birim = random.choice(self.birimler)
            hekim = self.get_random_hekim_kodu()
            basvuru_zamani = generate_date_range(2023, 2025)

            self.basvurular.append({
                "HASTA_BASVURU_KODU": f"BSV-{i:05d}",
                "HASTA_KODU": hasta["HASTA_KODU"],
                "BIRIM_KODU": birim["BIRIM_KODU"],
                "HEKIM_KODU": hekim,
                "TEDAVI_TURU": random.choice(TEDAVI_TURLERI),
                "BASVURU_DURUMU": random.choice(BASVURU_DURUMLARI),
                "HASTA_KABUL_ZAMANI": basvuru_zamani.isoformat(),
                "KURUM_KODU": "KRM-001",
                **self.get_audit_fields()
            })

        return self.basvurular

    # -------------------------------------------------------------------------
    # GENERATE ALL
    # -------------------------------------------------------------------------
    def generate_all(self):
        """Generate all seed data in correct order"""
        print("Generating reference codes...")
        self.generate_referans_kodlar()

        print("Generating personnel...")
        self.generate_personeller()

        print("Generating users...")
        self.generate_kullanicilar()

        print("Generating departments...")
        self.generate_birimler()

        print("Generating patients...")
        self.generate_hastalar()

        print("Generating visits...")
        self.generate_basvurular()

        return {
            "REFERANS_KODLAR": self.referans_kodlar,
            "PERSONEL": self.personeller,
            "KULLANICI": self.kullanicilar,
            "BIRIM": self.birimler,
            "HASTA": self.hastalar,
            "HASTA_BASVURU": self.basvurular
        }

    def to_csharp_seeder(self, output_path: str):
        """Generate C# seeder code"""
        data = self.generate_all()

        with open(output_path, 'w', encoding='utf-8') as f:
            f.write("// Auto-generated seed data\n")
            f.write("// Generated at: " + datetime.now().isoformat() + "\n\n")

            # Write kullanici list for reference
            f.write("// Valid KULLANICI_KODU values:\n")
            for k in self.kullanicilar[:10]:
                f.write(f"// - {k['KULLANICI_KODU']}\n")
            f.write("// ... and more\n\n")

            # Write SQL inserts
            f.write("-- SQL INSERT statements\n\n")

            # KULLANICI inserts
            f.write("-- KULLANICI\n")
            for k in self.kullanicilar:
                cols = ", ".join(k.keys())
                vals = ", ".join([f"'{v}'" if v else "NULL" for v in k.values()])
                f.write(f"INSERT INTO [Lbys].[KULLANICI] ({cols}) VALUES ({vals});\n")

            f.write("\n-- REFERANS_KODLAR (ULKE_KODU)\n")
            for r in self.referans_kodlar:
                if r["KOD_TURU"] == "ULKE_KODU":
                    f.write(f"INSERT INTO [Lbys].[REFERANS_KODLAR] (REFERANS_KODU, KOD_TURU, REFERANS_ADI, MEDULA_KODU, SKRS_KODU, SUT_KODU, SBIS_KODU) VALUES ('{r['REFERANS_KODU']}', '{r['KOD_TURU']}', '{r['REFERANS_ADI']}', '{r['MEDULA_KODU']}', '{r['SKRS_KODU']}', '{r['SUT_KODU']}', '{r['SBIS_KODU']}');\n")

        print(f"Generated C# seeder code at: {output_path}")

    def to_json(self, output_path: str):
        """Export all data to JSON"""
        data = self.generate_all()
        with open(output_path, 'w', encoding='utf-8') as f:
            json.dump(data, f, indent=2, ensure_ascii=False, default=str)
        print(f"Generated JSON at: {output_path}")


if __name__ == "__main__":
    generator = SeedDataGenerator()

    # Generate JSON for reference
    generator.to_json("C:\\Proje\\GitHub\\lbys\\Server\\Scripts\\seed_data.json")

    # Generate SQL/C# code
    generator.to_csharp_seeder("C:\\Proje\\GitHub\\lbys\\Server\\Scripts\\seed_inserts.sql")

    print("\nDone! Files generated:")
    print("1. seed_data.json - Full seed data in JSON format")
    print("2. seed_inserts.sql - SQL INSERT statements")
    print("\nKey fix: All EKLEYEN_KULLANICI_KODU now use valid KULLANICI_KODU values (KLN-001, KLN-002, etc.)")
