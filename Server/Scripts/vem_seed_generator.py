#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
VEM 2.0 Seed Data Generator - Corrected Version
Entity yapılarına uygun kolon isimleri ile
"""

import random
import json
from datetime import datetime, timedelta
from typing import Dict, List
import os

random.seed(42)

MIN_ROWS = 35
OUTPUT_DIR = os.path.dirname(os.path.abspath(__file__))
ADMIN_USER = "KLN-ADMIN"

TURKISH_MALE_NAMES = ["Ahmet", "Mehmet", "Mustafa", "Ali", "Huseyin", "Hasan", "Ibrahim", "Osman", "Murat", "Omer", "Fatih", "Emre", "Burak", "Yusuf", "Kemal", "Cem", "Tolga", "Serkan", "Onur", "Baris"]
TURKISH_FEMALE_NAMES = ["Fatma", "Ayse", "Emine", "Hatice", "Zeynep", "Elif", "Zehra", "Merve", "Busra", "Seda", "Derya", "Esra", "Sibel", "Gul", "Nur", "Deniz", "Ozge", "Pinar", "Asli", "Ceren"]
TURKISH_SURNAMES = ["Yilmaz", "Kaya", "Demir", "Celik", "Sahin", "Yildiz", "Yildirim", "Ozturk", "Aydin", "Ozdemir", "Arslan", "Dogan", "Kilic", "Aslan", "Cetin", "Koc", "Kurt", "Ozkan", "Simsek", "Polat"]
CITIES = ["Istanbul", "Ankara", "Izmir", "Bursa", "Antalya", "Adana", "Konya", "Gaziantep", "Mersin", "Diyarbakir"]


class VemSeedGenerator:
    def __init__(self):
        self.data: Dict[str, List[Dict]] = {}
        self.now = datetime.now()

    def get_audit_fields(self, user_code: str = ADMIN_USER) -> Dict:
        return {
            "EKLEYEN_KULLANICI_KODU": user_code,
            "KAYIT_ZAMANI": self.now.strftime("%Y-%m-%d %H:%M:%S")
        }

    def random_date(self, start_days_ago: int = 365, end_days_ago: int = 0) -> datetime:
        days = random.randint(end_days_ago, start_days_ago)
        return self.now - timedelta(days=days)

    def random_tc(self) -> str:
        return f"{random.randint(10000000000, 99999999999)}"

    def random_phone(self) -> str:
        return f"05{random.randint(30, 59)}{random.randint(1000000, 9999999)}"

    def random_iban(self) -> str:
        return f"TR{random.randint(10, 99)}{random.randint(1000, 9999)}{random.randint(10000000000000, 99999999999999)}"

    def generate_referans_kodlar(self):
        """REFERANS_KODLAR - actual entity columns: REFERANS_KODU, KOD_TURU, REFERANS_ADI, SKRS_KODU, MEDULA_KODU, MKYS_KODU, TIG_KODU"""
        print("Generating REFERANS_KODLAR...")
        codes = []

        def add_code(kod, kod_turu, adi, skrs="", medula="", mkys="", tig=""):
            codes.append({
                "REFERANS_KODU": kod,
                "KOD_TURU": kod_turu,
                "REFERANS_ADI": adi,
                "SKRS_KODU": skrs or kod,
                "MEDULA_KODU": medula or kod,
                "MKYS_KODU": mkys or kod,
                "TIG_KODU": tig or kod,
                **self.get_audit_fields()
            })

        # Cinsiyet
        add_code("CNS-E", "CINSIYET", "Erkek", "1", "E", "E", "E")
        add_code("CNS-K", "CINSIYET", "Kadin", "2", "K", "K", "K")

        # Kan Grubu
        for i, (k, a) in enumerate([("A+", "A Rh+"), ("A-", "A Rh-"), ("B+", "B Rh+"), ("B-", "B Rh-"), ("AB+", "AB Rh+"), ("AB-", "AB Rh-"), ("0+", "0 Rh+"), ("0-", "0 Rh-")], 1):
            add_code(f"KAN-{k}", "KAN_GRUBU", a, str(i), k, k, k)

        # Medeni Hal
        for i, (k, a) in enumerate([("BKR", "Bekar"), ("EVL", "Evli"), ("BOS", "Bosanmis"), ("DUL", "Dul")], 1):
            add_code(f"MDN-{k}", "MEDENI_HALI", a, str(i), k, k, k)

        # Tedavi Turu
        for i, (k, a) in enumerate([("AYAKTAN", "Ayaktan"), ("YATAN", "Yatan"), ("GUNUBIRLIK", "Gunubirlik"), ("ACIL", "Acil")], 1):
            add_code(f"TDV-{k}", "TEDAVI_TURU", a, str(i), k, k, k)

        # Cikis Sekli
        for i, (k, a) in enumerate([("TABURCU", "Taburcu"), ("SEVK", "Sevk"), ("EXITUS", "Olum"), ("ISTEK", "Kendi Istegi")], 1):
            add_code(f"CKS-{k}", "CIKIS_SEKLI", a, str(i), k, k, k)

        # Birim Turu
        for i, (k, a) in enumerate([("POL", "Poliklinik"), ("SRV", "Servis"), ("ACL", "Acil"), ("AML", "Ameliyathane"), ("LAB", "Laboratuvar"), ("RAD", "Radyoloji"), ("YBU", "Yogun Bakim")], 1):
            add_code(f"BRM-{k}", "BIRIM_TURU", a, str(i), k, k, k)

        # Unvan Kodu
        for i, (k, a) in enumerate([("UZM", "Uzman Doktor"), ("ASS", "Asistan"), ("HEM", "Hemsire"), ("TKN", "Teknisyen"), ("IDR", "Idari")], 1):
            add_code(f"UNV-{k}", "UNVAN_KODU", a, str(i), k, k, k)

        # Depo Turu
        for i, (k, a) in enumerate([("ANA", "Ana Depo"), ("BRM", "Birim Deposu"), ("ECZ", "Eczane")], 1):
            add_code(f"DPO-{k}", "DEPO_TURU", a, str(i), k, k, k)

        # Ulke Kodu
        for i, (k, a) in enumerate([("TC", "Turkiye"), ("DE", "Almanya"), ("FR", "Fransa"), ("GB", "Ingiltere"), ("US", "ABD")], 1):
            add_code(k, "ULKE_KODU", a, str(i), k, k, k)

        # Fatura Turu
        for i, (k, a) in enumerate([("YATAN", "Yatan Fatura"), ("AYAKTAN", "Ayaktan Fatura"), ("ACIL", "Acil Fatura"), ("SGK", "SGK Fatura")], 1):
            add_code(k, "FATURA_TURU", a, str(i), k, k, k)

        # Tani Turu
        for i, (k, a) in enumerate([("ANA", "Ana Tani"), ("YAN", "Yan Tani"), ("ONTAN", "On Tani")], 1):
            add_code(k, "TANI_TURU", a, str(i), k, k, k)

        # Ilac Kullanim Yolu
        for i, (k, a) in enumerate([("ORAL", "Oral"), ("IV", "Intravenoz"), ("IM", "Intramuskuler"), ("SC", "Subkutan")], 1):
            add_code(k, "ILAC_KULLANIM_YOLU", a, str(i), k, k, k)

        # Doz Periyot
        for i, (k, a) in enumerate([("GUN1", "Gunde 1"), ("GUN2", "Gunde 2"), ("GUN3", "Gunde 3")], 1):
            add_code(k, "DOZ_PERIYOT", a, str(i), k, k, k)

        # Doz Birim
        for i, (k, a) in enumerate([("MG", "Miligram"), ("ML", "Mililitre"), ("ADET", "Adet")], 1):
            add_code(k, "DOZ_BIRIM", a, str(i), k, k, k)

        # Numune Turu
        for i, (k, a) in enumerate([("KAN", "Kan"), ("IDRAR", "Idrar"), ("BALGAM", "Balgam"), ("DOKU", "Doku")], 1):
            add_code(k, "NUMUNE_TURU", a, str(i), k, k, k)

        self.data["REFERANS_KODLAR"] = codes
        return codes

    def generate_kurum(self):
        """KURUM - KURUM_KODU, KURUM_ADI, AKTIFLIK_BILGISI, etc."""
        print("Generating KURUM...")
        self.data["KURUM"] = [
            {"KURUM_KODU": "KRM-001", "KURUM_ADI": "Merkez Hastanesi", "AKTIFLIK_BILGISI": "1", **self.get_audit_fields()}
        ]
        return self.data["KURUM"]

    def generate_bina(self):
        """BINA - BINA_KODU, BINA_ADI, BINA_ADRESI, SKRS_KURUM_KODU"""
        print("Generating BINA...")
        binalar = []
        for i in range(MIN_ROWS):
            binalar.append({
                "BINA_KODU": f"BNA-{i+1:03d}",
                "BINA_ADI": f"Bina {chr(65 + i % 26)}" if i < 26 else f"Bina {i+1}",
                "BINA_ADRESI": f"{random.choice(CITIES)} Saglik Kampusu",
                **self.get_audit_fields()
            })
        self.data["BINA"] = binalar
        return binalar

    def generate_birim(self):
        """BIRIM - BIRIM_KODU, BIRIM_ADI, BIRIM_TURU, AKTIFLIK_BILGISI, BINA_KODU, etc."""
        print("Generating BIRIM...")
        birimler = []
        binalar = self.data.get("BINA", [])
        birim_tipleri = [
            ("Dahiliye Poliklinigi", "BRM-POL"), ("Cerrahi Poliklinigi", "BRM-POL"),
            ("Kadin Dogum Poliklinigi", "BRM-POL"), ("Cocuk Hastaliklari Poliklinigi", "BRM-POL"),
            ("Acil Servis", "BRM-ACL"), ("Dahiliye Servisi", "BRM-SRV"),
            ("Cerrahi Servisi", "BRM-SRV"), ("Laboratuvar", "BRM-LAB"),
            ("Radyoloji", "BRM-RAD"), ("Ameliyathane", "BRM-AML"),
            ("Yogun Bakim", "BRM-YBU"), ("Kardiyoloji Poliklinigi", "BRM-POL"),
            ("Noroloji Poliklinigi", "BRM-POL"), ("Ortopedi Poliklinigi", "BRM-POL"),
            ("Goz Hastaliklari Poliklinigi", "BRM-POL")
        ]
        for i in range(max(MIN_ROWS, len(birim_tipleri))):
            if i < len(birim_tipleri):
                ad, tur = birim_tipleri[i]
            else:
                ad = f"Birim {i+1}"
                tur = random.choice(["BRM-POL", "BRM-SRV", "BRM-LAB"])
            bina = binalar[i % len(binalar)] if binalar else None
            birimler.append({
                "BIRIM_KODU": f"BRM-{i+1:03d}",
                "BIRIM_ADI": ad,
                "BIRIM_TURU": tur,
                "BINA_KODU": bina["BINA_KODU"] if bina else None,
                "AKTIFLIK_BILGISI": "1",
                **self.get_audit_fields()
            })
        self.data["BIRIM"] = birimler
        return birimler

    def generate_oda(self):
        """ODA - ODA_KODU, ODA_ADI, BIRIM_KODU (references BIRIM)"""
        print("Generating ODA...")
        odalar = []
        birimler = self.data.get("BIRIM", [])
        for i in range(MIN_ROWS):
            birim = birimler[i % len(birimler)] if birimler else {"BIRIM_KODU": "BRM-001"}
            odalar.append({
                "ODA_KODU": f"ODA-{i+1:03d}",
                "ODA_ADI": f"Oda {i+1:03d}",
                "BIRIM_KODU": birim["BIRIM_KODU"],
                **self.get_audit_fields()
            })
        self.data["ODA"] = odalar
        return odalar

    def generate_yatak(self):
        """YATAK - YATAK_KODU, YATAK_ADI, ODA_KODU, YATAK_TURU, AKTIF (bool)"""
        print("Generating YATAK...")
        yataklar = []
        odalar = self.data.get("ODA", [])
        for i in range(MIN_ROWS):
            oda = odalar[i % len(odalar)] if odalar else {"ODA_KODU": "ODA-001"}
            yataklar.append({
                "YATAK_KODU": f"YTK-{i+1:03d}",
                "YATAK_ADI": f"Yatak {i+1:03d}",
                "ODA_KODU": oda["ODA_KODU"],
                "AKTIF": 1,
                **self.get_audit_fields()
            })
        self.data["YATAK"] = yataklar
        return yataklar

    def generate_cihaz(self):
        """CIHAZ - CIHAZ_KODU, CIHAZ_ADI, CIHAZ_GRUBU, BIRIM_KODU, CIHAZ_MODELI, CIHAZ_MARKASI, SERI_NUMARASI, AKTIFLIK_BILGISI"""
        print("Generating CIHAZ...")
        cihazlar = []
        birimler = self.data.get("BIRIM", [])
        cihaz_tipleri = [
            ("Biyokimya Analizoru", "Siemens", "BYK-1000"),
            ("Hemogram Cihazi", "Sysmex", "HEM-2000"),
            ("Idrar Analizoru", "Roche", "IDR-500"),
            ("Rontgen Cihazi", "GE", "RTG-3000"),
            ("Ultrason Cihazi", "Philips", "USG-4000"),
            ("BT Cihazi", "Toshiba", "CT-5000"),
            ("MR Cihazi", "Siemens", "MR-6000"),
            ("Ventilator", "Drager", "VNT-100"),
            ("Monitor", "Philips", "MON-200"),
            ("EKG Cihazi", "GE", "EKG-300"),
            ("Defibrilator", "Zoll", "DEF-400"),
            ("Anestezi Cihazi", "Drager", "ANS-500")
        ]
        for i in range(max(MIN_ROWS, len(cihaz_tipleri))):
            if i < len(cihaz_tipleri):
                ad, marka, model = cihaz_tipleri[i]
            else:
                ad = f"Cihaz {i+1}"
                marka = "Generic"
                model = f"GEN-{i+1:03d}"
            birim = birimler[i % len(birimler)] if birimler else {"BIRIM_KODU": "BRM-001"}
            cihazlar.append({
                "CIHAZ_KODU": f"CHZ-{i+1:03d}",
                "CIHAZ_ADI": ad,
                "CIHAZ_MARKASI": marka,
                "CIHAZ_MODELI": model,
                "SERI_NUMARASI": f"SN{random.randint(100000, 999999)}",
                "BIRIM_KODU": birim["BIRIM_KODU"],
                "AKTIFLIK_BILGISI": "1",
                **self.get_audit_fields()
            })
        self.data["CIHAZ"] = cihazlar
        return cihazlar

    def generate_depo(self):
        """DEPO - DEPO_KODU, DEPO_ADI, DEPO_TURU, BINA_KODU, MKYS_KODU, AKTIFLIK_BILGISI"""
        print("Generating DEPO...")
        depolar = []
        binalar = self.data.get("BINA", [])
        depo_tipleri = [
            ("Ana Ecza Deposu", "DPO-ANA"), ("Laboratuvar Deposu", "DPO-BRM"),
            ("Radyoloji Deposu", "DPO-BRM"), ("Ameliyathane Deposu", "DPO-BRM"), ("Eczane", "DPO-ECZ")
        ]
        for i in range(max(MIN_ROWS, len(depo_tipleri))):
            if i < len(depo_tipleri):
                ad, tur = depo_tipleri[i]
            else:
                ad = f"Depo {i+1}"
                tur = "DPO-BRM"
            bina = binalar[i % len(binalar)] if binalar else {"BINA_KODU": "BNA-001"}
            depolar.append({
                "DEPO_KODU": f"DEP-{i+1:03d}",
                "DEPO_ADI": ad,
                "DEPO_TURU": tur,
                "BINA_KODU": bina["BINA_KODU"],
                "AKTIFLIK_BILGISI": "1",
                **self.get_audit_fields()
            })
        self.data["DEPO"] = depolar
        return depolar

    def generate_stok_kart(self):
        """STOK_KART - STOK_KART_KODU, MALZEME_ADI, BARKOD, MALZEME_TIPI, AKTIF (bool)"""
        print("Generating STOK_KART...")
        stok_kartlar = []
        ilaclar = [
            "Parasetamol 500mg", "Ibuprofen 400mg", "Amoksisilin 500mg",
            "Metformin 850mg", "Omeprazol 20mg", "Aspirin 100mg",
            "Serum Fizyolojik", "Enjektor 5ml", "Eldiven M",
            "Gazli Bez", "Flaster", "Igne"
        ]
        for i in range(max(MIN_ROWS, len(ilaclar))):
            ad = ilaclar[i] if i < len(ilaclar) else f"Urun {i+1}"
            stok_kartlar.append({
                "STOK_KART_KODU": f"STK-{i+1:03d}",
                "MALZEME_ADI": ad,
                "BARKOD": f"869{random.randint(1000000000, 9999999999)}",
                "AKTIF": 1,
                **self.get_audit_fields()
            })
        self.data["STOK_KART"] = stok_kartlar
        return stok_kartlar

    def generate_firma(self):
        print("Generating FIRMA...")
        firmalar = []
        firma_isimleri = [
            "Medikal Tedarik AS", "Saglik Malzemeleri Ltd", "Laboratuvar Sistemleri AS",
            "Tibbi Cihaz Tic AS", "Ecza Deposu Ltd", "Goruntuleme Teknolojileri",
            "Cerrahi Aletler Ltd", "Protez Malzemeleri AS", "Biyomedikal Cozumler"
        ]
        for i in range(max(MIN_ROWS, len(firma_isimleri))):
            ad = firma_isimleri[i] if i < len(firma_isimleri) else f"Firma {i+1}"
            firmalar.append({
                "FIRMA_KODU": f"FRM-{i+1:03d}",
                "FIRMA_ADI": ad,
                "TELEFON_NUMARASI": self.random_phone(),
                "YETKILI_KISI": f"{random.choice(TURKISH_MALE_NAMES + TURKISH_FEMALE_NAMES)} {random.choice(TURKISH_SURNAMES)}",
                "FIRMA_ADRESI": random.choice(CITIES),
                "AKTIFLIK_BILGISI": "1",
                "VERGI_DAIRESI": f"{random.choice(CITIES)} VD",
                "VERGI_NUMARASI": f"{random.randint(1000000000, 9999999999)}",
                "EPOSTA_ADRESI": f"info{i+1}@firma{i+1}.com",
                "IBAN_NUMARASI": self.random_iban(),
                **self.get_audit_fields()
            })
        self.data["FIRMA"] = firmalar
        return firmalar

    def generate_personel(self):
        """PERSONEL - AD (required), TC_KIMLIK_NUMARASI (required), SOYADI, CINSIYET, etc."""
        print("Generating PERSONEL...")
        personeller = []
        unvanlar = ["UNV-UZM", "UNV-ASS", "UNV-HEM", "UNV-TKN", "UNV-IDR"]
        for i in range(MIN_ROWS):
            cinsiyet = random.choice(["E", "K"])
            ad = random.choice(TURKISH_MALE_NAMES if cinsiyet == "E" else TURKISH_FEMALE_NAMES)
            soyad = random.choice(TURKISH_SURNAMES)
            personeller.append({
                "PERSONEL_KODU": f"PRS-{i+1:03d}",
                "AD": ad,
                "TC_KIMLIK_NUMARASI": self.random_tc(),
                "SOYADI": soyad,
                "CINSIYET": f"CNS-{cinsiyet}",
                "UNVAN_KODU": random.choice(unvanlar),
                "AKTIFLIK_BILGISI": "1",
                **self.get_audit_fields()
            })
        self.data["PERSONEL"] = personeller
        return personeller

    def generate_kullanici(self):
        print("Generating KULLANICI...")
        kullanicilar = []
        personeller = self.data.get("PERSONEL", [])
        # Admin user
        kullanicilar.append({
            "KULLANICI_KODU": ADMIN_USER,
            "KULLANICI_ADI": "admin",
            "AD": "Admin",
            "SOYADI": "User",
            "AKTIFLIK_BILGISI": "1",
            "KAYIT_ZAMANI": self.now.strftime("%Y-%m-%d %H:%M:%S")
        })
        # Users for personnel
        for i, p in enumerate(personeller):
            kullanicilar.append({
                "KULLANICI_KODU": f"KLN-{i+1:03d}",
                "PERSONEL_KODU": p["PERSONEL_KODU"],
                "KULLANICI_ADI": f"{p['AD'].lower()}.{p['SOYADI'].lower()}",
                "AD": p["AD"],
                "SOYADI": p["SOYADI"],
                "AKTIFLIK_BILGISI": "1",
                **self.get_audit_fields()
            })
        self.data["KULLANICI"] = kullanicilar
        return kullanicilar

    def generate_hizmet(self):
        print("Generating HIZMET...")
        hizmetler = []
        hizmet_listesi = [
            ("HZM-TTK-001", "Hemogram"), ("HZM-TTK-002", "Biyokimya Panel"),
            ("HZM-TTK-003", "Idrar Tahlili"), ("HZM-MYN-001", "Poliklinik Muayenesi"),
            ("HZM-MYN-002", "Acil Muayene"), ("HZM-GRN-001", "Direkt Rontgen"),
            ("HZM-GRN-002", "Ultrasonografi"), ("HZM-GRN-003", "BT"),
            ("HZM-GRN-004", "MR"), ("HZM-AML-001", "Ameliyat Hizmeti")
        ]
        for i in range(max(MIN_ROWS, len(hizmet_listesi))):
            if i < len(hizmet_listesi):
                kod, ad = hizmet_listesi[i]
            else:
                kod = f"HZM-{i+1:03d}"
                ad = f"Hizmet {i+1}"
            hizmetler.append({
                "HIZMET_KODU": kod,
                "HIZMET_ADI": ad,
                "AKTIFLIK_BILGISI": "1",
                **self.get_audit_fields()
            })
        self.data["HIZMET"] = hizmetler
        return hizmetler

    def generate_tetkik(self):
        print("Generating TETKIK...")
        tetkikler = []
        hizmetler = self.data.get("HIZMET", [])
        tetkik_listesi = [
            ("TTK-HEM-001", "Hemoglobin", "718-7"), ("TTK-HEM-002", "Hematokrit", "4544-3"),
            ("TTK-HEM-003", "Lokosit", "6690-2"), ("TTK-HEM-004", "Trombosit", "777-3"),
            ("TTK-BYO-001", "Glukoz", "2345-7"), ("TTK-BYO-002", "Ure", "3094-0"),
            ("TTK-BYO-003", "Kreatinin", "2160-0"), ("TTK-BYO-004", "AST", "1920-8"),
            ("TTK-BYO-005", "ALT", "1742-6"), ("TTK-IDR-001", "Idrar pH", "2756-5")
        ]
        for i in range(max(MIN_ROWS, len(tetkik_listesi))):
            if i < len(tetkik_listesi):
                kod, ad, loinc = tetkik_listesi[i]
            else:
                kod = f"TTK-{i+1:03d}"
                ad = f"Tetkik {i+1}"
                loinc = f"LOINC-{i+1}"
            hizmet = hizmetler[0] if hizmetler else {"HIZMET_KODU": "HZM-TTK-001"}
            tetkikler.append({
                "TETKIK_KODU": kod,
                "TETKIK_ADI": ad,
                "LOINC_KODU": loinc,
                "HIZMET_KODU": hizmet["HIZMET_KODU"],
                "IPTAL_DURUMU": "0",
                **self.get_audit_fields()
            })
        self.data["TETKIK"] = tetkikler
        return tetkikler

    def generate_tetkik_parametre(self):
        """TETKIK_PARAMETRE - TETKIK_PARAMETRE_KODU, TETKIK_PARAMETRE_ADI, TETKIK_KODU, CIHAZ_KODU, LOINC_KODU, IPTAL_DURUMU"""
        print("Generating TETKIK_PARAMETRE...")
        parametreler = []
        tetkikler = self.data.get("TETKIK", [])
        cihazlar = self.data.get("CIHAZ", [])
        for i, t in enumerate(tetkikler):
            cihaz = cihazlar[i % len(cihazlar)] if cihazlar else {"CIHAZ_KODU": "CHZ-001"}
            parametreler.append({
                "TETKIK_PARAMETRE_KODU": f"TPR-{i+1:03d}",
                "TETKIK_KODU": t["TETKIK_KODU"],
                "TETKIK_PARAMETRE_ADI": f"{t['TETKIK_ADI']} Param",
                "LOINC_KODU": t.get("LOINC_KODU"),
                "CIHAZ_KODU": cihaz["CIHAZ_KODU"],
                "IPTAL_DURUMU": "0",
                **self.get_audit_fields()
            })
        self.data["TETKIK_PARAMETRE"] = parametreler
        return parametreler

    def generate_hasta(self):
        """HASTA - AD (required), TC_KIMLIK_NUMARASI, SOYADI, CINSIYET, DOGUM_TARIHI, etc."""
        print("Generating HASTA...")
        hastalar = []
        for i in range(MIN_ROWS):
            cinsiyet = random.choice(["E", "K"])
            ad = random.choice(TURKISH_MALE_NAMES if cinsiyet == "E" else TURKISH_FEMALE_NAMES)
            soyad = random.choice(TURKISH_SURNAMES)
            dogum = self.random_date(365*80, 0)
            hastalar.append({
                "HASTA_KODU": f"HST-{i+1:05d}",
                "AD": ad,
                "TC_KIMLIK_NUMARASI": self.random_tc(),
                "SOYADI": soyad,
                "CINSIYET": f"CNS-{cinsiyet}",
                "DOGUM_TARIHI": dogum.strftime("%Y-%m-%d"),
                "DOGUM_YERI": random.choice(CITIES),
                "BABA_ADI": random.choice(TURKISH_MALE_NAMES),
                "ANNE_ADI": random.choice(TURKISH_FEMALE_NAMES),
                "UYRUK": "TC",
                "KAN_GRUBU": random.choice(["KAN-A+", "KAN-A-", "KAN-B+", "KAN-B-", "KAN-AB+", "KAN-AB-", "KAN-0+", "KAN-0-"]),
                "MEDENI_HALI": random.choice(["MDN-BKR", "MDN-EVL", "MDN-BOS", "MDN-DUL"]),
                **self.get_audit_fields()
            })
        self.data["HASTA"] = hastalar
        return hastalar

    def generate_hasta_basvuru(self):
        print("Generating HASTA_BASVURU...")
        basvurular = []
        hastalar = self.data.get("HASTA", [])
        birimler = self.data.get("BIRIM", [])
        tedaviler = ["TDV-AYAKTAN", "TDV-YATAN", "TDV-GUNUBIRLIK", "TDV-ACIL"]
        cikislar = ["CKS-TABURCU", "CKS-SEVK", "CKS-ISTEK"]
        for i in range(MIN_ROWS):
            hasta = hastalar[i % len(hastalar)]
            birim = birimler[i % len(birimler)] if birimler else {"BIRIM_KODU": "BRM-001"}
            kabul = self.random_date(180, 1)
            cikis = kabul + timedelta(days=random.randint(0, 14))
            basvurular.append({
                "HASTA_BASVURU_KODU": f"BSV-{i+1:05d}",
                "HASTA_KODU": hasta["HASTA_KODU"],
                "BIRIM_KODU": birim["BIRIM_KODU"],
                "TEDAVI_TURU": random.choice(tedaviler),
                "CIKIS_SEKLI": random.choice(cikislar),
                "HASTA_KABUL_ZAMANI": kabul.strftime("%Y-%m-%d %H:%M:%S"),
                "CIKIS_ZAMANI": cikis.strftime("%Y-%m-%d %H:%M:%S"),
                **self.get_audit_fields()
            })
        self.data["HASTA_BASVURU"] = basvurular
        return basvurular

    def generate_all(self):
        print("=" * 60)
        print("VEM 2.0 Seed Data Generator (Corrected)")
        print("=" * 60)
        self.generate_referans_kodlar()
        self.generate_kurum()
        self.generate_bina()
        self.generate_birim()
        self.generate_oda()
        self.generate_yatak()
        self.generate_cihaz()
        self.generate_depo()
        self.generate_stok_kart()
        self.generate_firma()
        self.generate_hizmet()
        self.generate_personel()
        self.generate_kullanici()
        self.generate_tetkik()
        self.generate_tetkik_parametre()
        self.generate_hasta()
        self.generate_hasta_basvuru()
        print("=" * 60)
        print(f"Generated {sum(len(v) for v in self.data.values())} total rows")
        print("=" * 60)

    def to_sql(self) -> str:
        lines = ["-- VEM 2.0 Seed Data", f"-- Generated: {datetime.now()}", ""]
        for table, rows in self.data.items():
            if not rows:
                continue
            lines.append(f"-- {table} ({len(rows)} rows)")
            for row in rows:
                cols = []
                vals = []
                for c, v in row.items():
                    cols.append(f"[{c}]")
                    if v is None:
                        vals.append("NULL")
                    elif isinstance(v, str):
                        vals.append(f"N'{v.replace(chr(39), chr(39)+chr(39))}'")
                    else:
                        vals.append(str(v))
                lines.append(f"INSERT INTO [Lbys].[{table}] ({', '.join(cols)}) VALUES ({', '.join(vals)});")
            lines.append("GO")
            lines.append("")
        return "\n".join(lines)

    def to_json(self) -> str:
        return json.dumps(self.data, ensure_ascii=False, indent=2, default=str)

    def save(self):
        sql_path = os.path.join(OUTPUT_DIR, "vem_seed_data.sql")
        with open(sql_path, "w", encoding="utf-8") as f:
            f.write(self.to_sql())
        print(f"SQL: {sql_path}")
        json_path = os.path.join(OUTPUT_DIR, "vem_seed_data.json")
        with open(json_path, "w", encoding="utf-8") as f:
            f.write(self.to_json())
        print(f"JSON: {json_path}")


if __name__ == "__main__":
    g = VemSeedGenerator()
    g.generate_all()
    g.save()
    print("\nSummary:")
    for t, r in g.data.items():
        print(f"  {t}: {len(r)} rows")
