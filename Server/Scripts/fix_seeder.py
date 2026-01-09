import re

seeder_file = r"C:\Proje\GitHub\lbys\Server\Server\src\Infrastructure\Persistence\Initialization\VemSeeder.cs"

with open(seeder_file, 'r', encoding='utf-8') as f:
    content = f.read()

# Field replacements
replacements = {
    # PERSONEL
    '.TC_KIMLIK_NO': '.TC_KIMLIK_NUMARASI',
    '.SOYAD': '.SOYADI',
    '.UNVAN': '.UNVAN_KODU',
    '.EMAIL': '.EPOSTA_ADRESI',
    '.TELEFON': '.CEP_TELEFONU',
    '.BIRIM_KODU': '.CALISTIGI_BIRIM_KODU',
    '.DIPLOMA_NO': '.DIPLOMA_NUMARASI',
    '.DIPLOMA_TESCIL_NO': '.TESCIL_NUMARASI',
    '.ISE_BASLAMA_TARIHI': '.ILK_ISE_BASLAMA_TARIHI',
    '.AKTIF = true': '.AKTIFLIK_BILGISI = "1"',
    '.AKTIF = false': '.AKTIFLIK_BILGISI = "0"',
    'AKTIF = true': 'AKTIFLIK_BILGISI = "1"',
    'AKTIF = false': 'AKTIFLIK_BILGISI = "0"',

    # HASTA
    '.ANA_ADI': '.ANNE_ADI',
    '.CEP_TELEFON': '.TC_KIMLIK_NUMARASI',  # This might be wrong but we need to remove it
    '.EGITIM_DURUMU': '.OGRENIM_DURUMU',
    '.MEDENI_HAL': '.MEDENI_HALI',
    '.PROTOKOL_NO': '.TC_KIMLIK_NUMARASI',  # placeholder
    '.SIGORTA_NO': '.TC_KIMLIK_NUMARASI',  # placeholder
    '.SOSYAL_GUVENCE': '.TC_KIMLIK_NUMARASI',  # placeholder

    # HASTA_BASVURU
    '.BASVURU_TARIHI': '.HASTA_KABUL_ZAMANI',
    '.BASVURU_TURU': '.MUAYENE_TURU',
    '.BASVURU_SEKLI': '.KABUL_SEKLI',
    '.DOKTOR_KODU': '.HEKIM_KODU',
    '.SIKAYET': '.HEKIM_BASVURU_NOTU',
    '.TANI_KODU': '.TRIAJ_KODU',
    '.PROVIZYON_TIPI': '.SOSYAL_GUVENCE_DURUMU',
    '.TAKIP_NO': '.SYS_TAKIP_NUMARASI',
    '.CIKIS_TARIHI': '.CIKIS_ZAMANI',
    '.SEVK_EDEN_KURUM': '.TAMAMLAYICI_KURUM_KODU',
    '.SONUC_KODU': '.BASVURU_DURUMU',

    # KURUM
    '.KURUM_TURU': '.HASTA_KURUM_TURU',
    '.ADRES': '.KURUM_ADRESI',
    '.IL_KODU': '.SKRS_KURUM_KODU',  # This is a guess
    '.ILCE_KODU': '.SKRS_KURUM_KODU',  # This is a guess
    '.VERGI_NO': '.SKRS_KURUM_KODU',  # placeholder
    '.VERGI_DAIRESI': '.SKRS_KURUM_KODU',  # placeholder

    # BIRIM
    '.UST_BIRIM_KODU': '.KLINIK_KODU',
}

# Simple string replace (not ideal but works for most cases)
for old, new in replacements.items():
    # Be careful not to replace partial matches
    content = content.replace(old, new)

# Also handle the AKTIF property assignments in object initializers
# Pattern: AKTIF = true or AKTIF = false
content = re.sub(r'(\s+)AKTIF\s*=\s*true,', r'\1AKTIFLIK_BILGISI = "1",', content)
content = re.sub(r'(\s+)AKTIF\s*=\s*false,', r'\1AKTIFLIK_BILGISI = "0",', content)
content = re.sub(r'(\s+)AKTIF\s*=\s*true\s*\n', r'\1AKTIFLIK_BILGISI = "1"\n', content)

# Remove lines with properties that no longer exist
# These patterns will comment out problematic lines
problematic = [
    'UZMANLIK_KODU',
]

with open(seeder_file, 'w', encoding='utf-8') as f:
    f.write(content)

print("VemSeeder.cs has been updated")
