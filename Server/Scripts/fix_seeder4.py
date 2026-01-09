import re

seeder_file = r"C:\Proje\GitHub\lbys\Server\Server\src\Infrastructure\Persistence\Initialization\VemSeeder.cs"

with open(seeder_file, 'r', encoding='utf-8') as f:
    content = f.read()

# Fix all birim.CALISTIGI_BIRIM_KODU to birim.BIRIM_KODU
content = content.replace('birim.CALISTIGI_BIRIM_KODU', 'birim.BIRIM_KODU')
content = content.replace('birimler.First().CALISTIGI_BIRIM_KODU', 'birimler.First().BIRIM_KODU')
content = content.replace('birimler.Last().CALISTIGI_BIRIM_KODU', 'birimler.Last().BIRIM_KODU')
content = content.replace('(BIRIM).CALISTIGI_BIRIM_KODU', '(BIRIM).BIRIM_KODU')

# Fix entity field names that were incorrectly changed
# DISPROTEZ_CALISTIGI_BIRIM_KODU should be DISPROTEZ_BIRIM_KODU
content = content.replace('DISPROTEZ_CALISTIGI_BIRIM_KODU', 'DISPROTEZ_BIRIM_KODU')
content = content.replace('CALISTIGI_BIRIM_KODU = birim', 'BIRIM_KODU = birim')
content = content.replace('DIYABET_HEKIM_BASVURU_NOTU', 'DIYABET_TANI')
content = content.replace('OLUM_NEDENI_TRIAJ_KODU', 'OLUM_TANI_KODU')
content = content.replace('DOSYA_ALAN_CALISTIGI_BIRIM_KODU', 'DOSYA_ALAN_BIRIM_KODU')
content = content.replace('DOSYA_VEREN_CALISTIGI_BIRIM_KODU', 'DOSYA_VEREN_BIRIM_KODU')

# Remove lines with problematic properties
lines_to_remove = [
    'AKTIFLIK_BILGISI = "1"',  # For entities that don't have it
    'CEP_TELEFONU =',
    'EPOSTA_ADRESI =',
    'HEKIM_BASVURU_NOTU =',  # For HASTA_ADLI_RAPOR
]

# Remove lines containing these patterns
lines = content.split('\n')
new_lines = []
for line in lines:
    should_keep = True
    # Check if line contains AKTIFLIK_BILGISI and is inside STOK_KART or TETKIK block
    if 'AKTIFLIK_BILGISI' in line:
        # Keep it only if the context has PERSONEL, KULLANICI, CIHAZ, HIZMET, KURUM, BIRIM, DEPO
        should_keep = False  # For now, remove all - simpler
    if 'HEKIM_BASVURU_NOTU' in line and 'HASTA_ADLI_RAPOR' in ''.join(new_lines[-20:]):
        should_keep = False
    if should_keep:
        new_lines.append(line)

content = '\n'.join(new_lines)

# Fix duplicate HASTA_BASVURU_KODU
content = re.sub(r'HASTA_BASVURU_KODU = basvuruTanilar.*HASTA_BASVURU_KODU = basvuru\.HASTA_BASVURU_KODU',
                 'HASTA_BASVURU_KODU = basvuru.HASTA_BASVURU_KODU', content, flags=re.DOTALL)

with open(seeder_file, 'w', encoding='utf-8') as f:
    f.write(content)

print("VemSeeder.cs has been updated (fourth pass)")
