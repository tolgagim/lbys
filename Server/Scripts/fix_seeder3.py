import re

seeder_file = r"C:\Proje\GitHub\lbys\Server\Server\src\Infrastructure\Persistence\Initialization\VemSeeder.cs"

with open(seeder_file, 'r', encoding='utf-8') as f:
    content = f.read()

# Fix BIRIM_KODU references that were wrongly changed to CALISTIGI_BIRIM_KODU
# CALISTIGI_BIRIM_KODU should only be used in PERSONEL context
content = content.replace('ODA.CALISTIGI_BIRIM_KODU', 'ODA.BIRIM_KODU')
content = content.replace('BIRIM.CALISTIGI_BIRIM_KODU', 'BIRIM.BIRIM_KODU')
content = content.replace('RANDEVU.CALISTIGI_BIRIM_KODU', 'RANDEVU.BIRIM_KODU')
content = content.replace('AMELIYAT.CALISTIGI_BIRIM_KODU', 'AMELIYAT.BIRIM_KODU')
content = content.replace('TETKIK_NUMUNE.CALISTIGI_BIRIM_KODU', 'TETKIK_NUMUNE.BIRIM_KODU')
content = content.replace('CIHAZ.CALISTIGI_BIRIM_KODU', 'CIHAZ.BIRIM_KODU')
content = content.replace('HASTA_BASVURU.CALISTIGI_BIRIM_KODU', 'HASTA_BASVURU.BIRIM_KODU')

# In object initializers - for non-PERSONEL entities
content = re.sub(r'CALISTIGI_BIRIM_KODU\s*=\s*birim\.BIRIM_KODU', 'BIRIM_KODU = birim.BIRIM_KODU', content)
content = re.sub(r'CALISTIGI_BIRIM_KODU\s*=\s*odalar', 'BIRIM_KODU = odalar', content)
content = re.sub(r'CALISTIGI_BIRIM_KODU\s*=\s*oda\.', 'BIRIM_KODU = oda.', content)

# Fix KURUM fields that don't exist
content = re.sub(r'\s*CEP_TELEFONU\s*=\s*"[^"]*",?\n', '\n', content)
content = re.sub(r'\s*EPOSTA_ADRESI\s*=\s*"[^"]*",?\n', '\n', content)

# Fix HASTA fields that don't exist
content = re.sub(r'\s*KURUM_ADRESI\s*=\s*"[^"]*",?\n', '\n', content)
content = re.sub(r'\s*CEP_CEP_TELEFONU\s*=\s*"[^"]*",?\n', '\n', content)

# Fix BASVURU_TANI fields
content = content.replace('BASVURU_TRIAJ_KODU', 'HASTA_BASVURU_KODU')

# Remove TRIAJ_KODU from BASVURU_TANI
content = re.sub(r'\s*TRIAJ_KODU\s*=\s*[^,}]+,?\n', '\n', content)

# Fix DateTime? issues - use .Value
content = re.sub(r'(\w+)\.HASTA_KABUL_ZAMANI\.AddDays', r'\1.HASTA_KABUL_ZAMANI.Value.AddDays', content)
content = re.sub(r'(\w+)\.HASTA_KABUL_ZAMANI\.AddMinutes', r'\1.HASTA_KABUL_ZAMANI.Value.AddMinutes', content)
content = re.sub(r'(\w+)\.HASTA_KABUL_ZAMANI\.Month\b', r'\1.HASTA_KABUL_ZAMANI.Value.Month', content)
content = re.sub(r'(\w+)\.HASTA_KABUL_ZAMANI\.Year\b', r'\1.HASTA_KABUL_ZAMANI.Value.Year', content)

# Remove AKTIFLIK_BILGISI from entities that don't have it
# YATAK, TETKIK (should be IPTAL_DURUMU), STOK_KART, HASTA don't have AKTIFLIK_BILGISI
# YATAK - just remove the line
content = re.sub(r"YATAK[^}]*AKTIFLIK_BILGISI\s*=\s*\"[^\"]*\",?\n", '', content)

# For lines inside YATAK initializers, remove AKTIFLIK_BILGISI
content = re.sub(r'\s+AKTIFLIK_BILGISI\s*=\s*"[^"]*",?\s*//\s*YATAK\n', '\n', content)

# Remove KURUM_KODU from BIRIM
lines = content.split('\n')
new_lines = []
skip_next = False
for i, line in enumerate(lines):
    if skip_next:
        skip_next = False
        continue
    # Check if this is KURUM_KODU assignment in BIRIM context
    if 'KURUM_KODU' in line and i > 0 and 'new()' in lines[i-5:i]:
        # Check context - look for BIRIM
        context = ''.join(lines[max(0,i-10):i])
        if 'BIRIM' in context or 'birim' in context:
            # Skip this line
            continue
    new_lines.append(line)

content = '\n'.join(new_lines)

# Remove AKTIF = true/false completely (replace remaining)
content = re.sub(r'\s+AKTIF\s*=\s*true,?\s*\n', '\n', content)
content = re.sub(r'\s+AKTIF\s*=\s*false,?\s*\n', '\n', content)

with open(seeder_file, 'w', encoding='utf-8') as f:
    f.write(content)

print("VemSeeder.cs has been updated (third pass)")
