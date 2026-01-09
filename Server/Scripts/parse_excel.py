import pandas as pd
import json

filepath = r"C:\Proje\GitHub\lbys\Server\Scripts\eksik.xls"
df = pd.read_excel(filepath, engine='xlrd')

# Extract relevant columns
results = []

for idx, row in df.iterrows():
    view_name = row['Görüntü Adı (*)']
    eksik = row['Eksik Tanımlanmış Veri Elemanları (*)']  # Fields to ADD
    fazla = row['Fazla Tanımlanmış Veri Elemanları (*)']  # Fields to REMOVE

    if pd.isna(view_name):
        continue

    eksik_list = [x.strip() for x in str(eksik).split(',')] if pd.notna(eksik) else []
    fazla_list = [x.strip() for x in str(fazla).split(',')] if pd.notna(fazla) else []

    # Filter out 'nan' strings
    eksik_list = [x for x in eksik_list if x and x != 'nan']
    fazla_list = [x for x in fazla_list if x and x != 'nan']

    if eksik_list or fazla_list:
        results.append({
            'view': view_name,
            'table': view_name.replace('VEM_', ''),
            'add_fields': eksik_list,
            'remove_fields': fazla_list
        })

print(f"Toplam {len(results)} tablo güncellenecek:\n")

for r in results:
    print(f"{'='*60}")
    print(f"VIEW: {r['view']}")
    print(f"TABLE: Lbys.{r['table']}")
    print(f"\nEKLENECEK ({len(r['add_fields'])} alan):")
    for f in r['add_fields']:
        print(f"  + {f}")
    print(f"\nKALDIRILACAK ({len(r['remove_fields'])} alan):")
    for f in r['remove_fields']:
        print(f"  - {f}")
    print()

# Save to JSON for further processing
with open(r"C:\Proje\GitHub\lbys\Server\Scripts\table_changes.json", 'w', encoding='utf-8') as f:
    json.dump(results, f, ensure_ascii=False, indent=2)

print(f"\nJSON dosyası kaydedildi: table_changes.json")
