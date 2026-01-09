import pandas as pd
import json

filepath = r"C:\Proje\GitHub\lbys\Server\Scripts\eksik.xls"
df = pd.read_excel(filepath, engine='xlrd')

results = []

for idx, row in df.iterrows():
    view_name = row['Görüntü Adı (*)']
    eksik = row['Eksik Tanımlanmış Veri Elemanları (*)']
    fazla = row['Fazla Tanımlanmış Veri Elemanları (*)']

    if pd.isna(view_name):
        continue

    eksik_list = [x.strip() for x in str(eksik).split(',')] if pd.notna(eksik) else []
    fazla_list = [x.strip() for x in str(fazla).split(',')] if pd.notna(fazla) else []

    eksik_list = [x for x in eksik_list if x and x != 'nan']
    fazla_list = [x for x in fazla_list if x and x != 'nan']

    if eksik_list or fazla_list:
        results.append({
            'view': view_name,
            'table': view_name.replace('VEM_', ''),
            'add_fields': eksik_list,
            'remove_fields': fazla_list
        })

with open(r"C:\Proje\GitHub\lbys\Server\Scripts\table_changes.json", 'w', encoding='utf-8') as f:
    json.dump(results, f, ensure_ascii=False, indent=2)

print(f"Saved {len(results)} tables to table_changes.json")
