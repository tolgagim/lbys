import re

seeder_file = r"C:\Proje\GitHub\lbys\Server\Server\src\Infrastructure\Persistence\Initialization\VemSeeder.cs"

with open(seeder_file, 'r', encoding='utf-8') as f:
    content = f.read()

# Field replacements - exact matches only
replacements = [
    # PERSONEL - object initializers
    ('TC_KIMLIK_NO = ', 'TC_KIMLIK_NUMARASI = '),
    ('SOYAD = ', 'SOYADI = '),
    ('UNVAN = ', 'UNVAN_KODU = '),
    ('EMAIL = ', 'EPOSTA_ADRESI = '),
    ('TELEFON = ', 'CEP_TELEFONU = '),
    ('DIPLOMA_NO = ', 'DIPLOMA_NUMARASI = '),
    ('ISE_BASLAMA_TARIHI = ', 'ILK_ISE_BASLAMA_TARIHI = '),
    ('BIRIM_KODU = ', 'CALISTIGI_BIRIM_KODU = '),

    # HASTA - object initializers
    ('ANA_ADI = ', 'ANNE_ADI = '),
    ('MEDENI_HAL = ', 'MEDENI_HALI = '),
    ('CEP_TELEFON = ', 'TC_KIMLIK_NUMARASI = '),  # Remove - no replacement

    # HASTA_BASVURU - object initializers
    ('BASVURU_TARIHI = ', 'HASTA_KABUL_ZAMANI = '),
    ('BASVURU_TURU = ', 'MUAYENE_TURU = '),
    ('BASVURU_SEKLI = ', 'KABUL_SEKLI = '),
    ('DOKTOR_KODU = ', 'HEKIM_KODU = '),
    ('SIKAYET = ', 'HEKIM_BASVURU_NOTU = '),
    ('TANI_KODU = ', 'TRIAJ_KODU = '),
    ('PROVIZYON_TIPI = ', 'SOSYAL_GUVENCE_DURUMU = '),
    ('TAKIP_NO = ', 'SYS_TAKIP_NUMARASI = '),
    ('CIKIS_TARIHI = ', 'CIKIS_ZAMANI = '),

    # KURUM - object initializers
    ('KURUM_TURU = ', 'HASTA_KURUM_TURU = '),
    ('ADRES = ', 'KURUM_ADRESI = '),

    # BIRIM - object initializers
    ('UST_BIRIM_KODU = ', 'KLINIK_KODU = '),

    # AKTIF to AKTIFLIK_BILGISI
    ('AKTIF = true', 'AKTIFLIK_BILGISI = "1"'),
    ('AKTIF = false', 'AKTIFLIK_BILGISI = "0"'),
]

for old, new in replacements:
    content = content.replace(old, new)

# Remove lines with properties that no longer exist
# These are properties that were removed and have no replacement
lines_to_remove = [
    'UZMANLIK_KODU = ',
    'IL_KODU = ',
    'ILCE_KODU = ',
    'VERGI_NO = ',
    'VERGI_DAIRESI = ',
    'SOSYAL_GUVENCE = ',
    'SIGORTA_NO = ',
    'PROTOKOL_NO = ',
    'KURUM_KODU = birim',  # This specifically
]

# Process line by line to remove unwanted lines
lines = content.split('\n')
new_lines = []
for line in lines:
    should_keep = True
    for pattern in lines_to_remove:
        if pattern in line:
            should_keep = False
            break
    if should_keep:
        new_lines.append(line)

content = '\n'.join(new_lines)

# Fix BIRIM.CALISTIGI_BIRIM_KODU -> BIRIM.BIRIM_KODU
content = content.replace('BIRIM.CALISTIGI_BIRIM_KODU', 'BIRIM.BIRIM_KODU')
content = content.replace('birim.CALISTIGI_BIRIM_KODU', 'birim.BIRIM_KODU')
content = content.replace('BIRIM).CALISTIGI_BIRIM_KODU', 'BIRIM).BIRIM_KODU')
content = content.replace('ODA).CALISTIGI_BIRIM_KODU', 'ODA).BIRIM_KODU')

# Fix PERSONEL.UNVAN property access
content = re.sub(r'personel\.UNVAN_KODU\b', 'personel.UNVAN_KODU', content)

# Fix TETKIK AKTIFLIK_BILGISI -> IPTAL_DURUMU
content = re.sub(r'TETKIK[^}]*AKTIFLIK_BILGISI\s*=\s*"1"', lambda m: m.group(0).replace('AKTIFLIK_BILGISI = "1"', 'IPTAL_DURUMU = "0"'), content)

# Remove AKTIFLIK_BILGISI from entities that don't have it (TETKIK, STOK_KART, YATAK, HASTA)
# These should use IPTAL_DURUMU instead for TETKIK and TETKIK_PARAMETRE

with open(seeder_file, 'w', encoding='utf-8') as f:
    f.write(content)

print("VemSeeder.cs has been updated (second pass)")
