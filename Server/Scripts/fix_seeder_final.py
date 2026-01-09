import re

seeder_file = r"C:\Proje\GitHub\lbys\Server\Server\src\Infrastructure\Persistence\Initialization\VemSeeder.cs"

with open(seeder_file, 'r', encoding='utf-8') as f:
    content = f.read()

# Fix CALISTIGI_BIRIM_KODU in entity types that don't have it
# Should be BIRIM_KODU for BIRIM, ODA, AMELIYAT, TETKIK_NUMUNE, etc.
# Only PERSONEL has CALISTIGI_BIRIM_KODU

# Direct field access patterns
content = content.replace('oda.CALISTIGI_BIRIM_KODU', 'oda.BIRIM_KODU')
content = content.replace('ameliyat.CALISTIGI_BIRIM_KODU', 'ameliyat.BIRIM_KODU')
content = content.replace('numune.CALISTIGI_BIRIM_KODU', 'numune.BIRIM_KODU')

# BIRIM entity - CALISTIGI_BIRIM_KODU doesn't exist
# In BIRIM seed context, it should use BIRIM_KODU
content = re.sub(r'new BIRIM\s*\{[^}]*CALISTIGI_BIRIM_KODU\s*=\s*([^,}]+)',
                 lambda m: m.group(0).replace('CALISTIGI_BIRIM_KODU', 'BIRIM_KODU'), content)

# PERSONEL - BIRIM_KODU should be CALISTIGI_BIRIM_KODU
# Actually keep it as BIRIM_KODU was removed and CALISTIGI_BIRIM_KODU was added
# So PERSONEL.BIRIM_KODU should become PERSONEL.CALISTIGI_BIRIM_KODU - already done

# The issue is the reverse - ODA, BIRIM entity types don't have CALISTIGI_BIRIM_KODU
# Remove KURUM_KODU from BIRIM (it's removed)
# Remove CALISTIGI_BIRIM_KODU from BIRIM (should be KLINIK_KODU based on replacement)

# Fix lines inside object initializers
lines = content.split('\n')
new_lines = []
in_birim_block = False
in_personel_block = False
in_hasta_block = False
in_kurum_block = False
in_basvuru_block = False

for i, line in enumerate(lines):
    # Detect block context
    if 'new BIRIM' in line or 'new() { BIRIM_KODU' in line:
        in_birim_block = True
    if 'new PERSONEL' in line or 'PERSONEL_KODU' in line and 'new()' in line:
        in_personel_block = True
    if 'new HASTA' in line and 'HASTA_BASVURU' not in line:
        in_hasta_block = True
    if 'new KURUM' in line:
        in_kurum_block = True
    if 'new HASTA_BASVURU' in line or 'HASTA_BASVURU_KODU' in line and 'new()' in line:
        in_basvuru_block = True

    # Reset context on block end
    if '};' in line or ');' in line:
        in_birim_block = False
        in_personel_block = False
        in_hasta_block = False
        in_kurum_block = False
        in_basvuru_block = False

    modified_line = line

    # Remove CALISTIGI_BIRIM_KODU from BIRIM (use KLINIK_KODU or remove)
    if 'CALISTIGI_BIRIM_KODU' in line and ('BIRIM' in ''.join(lines[max(0,i-5):i]) or in_birim_block):
        if 'BIRIM =' not in line:  # Not an assignment of BIRIM object
            modified_line = modified_line.replace('CALISTIGI_BIRIM_KODU', 'KLINIK_KODU')

    # Remove KURUM_KODU from BIRIM
    if 'KURUM_KODU' in line and in_birim_block:
        continue  # Skip this line

    # Remove BIRIM_KODU from PERSONEL (should be CALISTIGI_BIRIM_KODU)
    if in_personel_block and 'BIRIM_KODU' in line:
        modified_line = modified_line.replace('BIRIM_KODU', 'CALISTIGI_BIRIM_KODU')

    # Remove fields from HASTA
    if in_hasta_block:
        if any(x in line for x in ['KURUM_ADRESI', 'CEP_TELEFONU', 'CEP_CEP_TELEFONU', 'EPOSTA_ADRESI']):
            continue

    # Remove AKTIF from HASTA_BASVURU
    if in_basvuru_block and 'AKTIF' in line:
        continue

    # Remove CEP_TELEFONU and EPOSTA_ADRESI from KURUM
    if in_kurum_block:
        if any(x in line for x in ['CEP_TELEFONU', 'EPOSTA_ADRESI']):
            continue

    new_lines.append(modified_line)

content = '\n'.join(new_lines)

# Fix ODA.CALISTIGI_BIRIM_KODU -> ODA.BIRIM_KODU (property access)
content = re.sub(r'(\w+\.First\(\)|oda)\s*\.\s*CALISTIGI_BIRIM_KODU', r'\1.BIRIM_KODU', content)

# Remove duplicate HASTA_BASVURU_KODU assignments
content = re.sub(r'HASTA_BASVURU_KODU\s*=\s*basvuruTanilar[^,]*,\s*\n\s*HASTA_BASVURU_KODU', 'HASTA_BASVURU_KODU', content)
content = re.sub(r'HASTA_BASVURU_KODU\s*=\s*basvuru[^,]*,\s*\n\s*HASTA_BASVURU_KODU', 'HASTA_BASVURU_KODU', content)

# Fix DateTime? nullable issues
content = content.replace('.HASTA_KABUL_ZAMANI.AddDays', '.HASTA_KABUL_ZAMANI!.Value.AddDays')
content = content.replace('.HASTA_KABUL_ZAMANI.AddMinutes', '.HASTA_KABUL_ZAMANI!.Value.AddMinutes')
content = content.replace('.HASTA_KABUL_ZAMANI.Month', '.HASTA_KABUL_ZAMANI!.Value.Month')
content = content.replace('.HASTA_KABUL_ZAMANI.Year', '.HASTA_KABUL_ZAMANI!.Value.Year')

# Fix DIYABET_TANI and OLUM_TANI_KODU
content = content.replace('DIYABET_TANI = ', 'DIYABET_TURU = ')
content = content.replace('OLUM_TANI_KODU = ', 'OLUM_TANI = ')

with open(seeder_file, 'w', encoding='utf-8') as f:
    f.write(content)

print("VemSeeder.cs has been updated (final pass)")
