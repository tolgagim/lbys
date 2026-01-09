import json
import os
import re

# Load table changes
with open(r"C:\Proje\GitHub\lbys\Server\Scripts\table_changes.json", 'r', encoding='utf-8') as f:
    changes = json.load(f)

# Type mapping based on VEM naming conventions
def get_sql_type(field_name):
    """Determine SQL type based on field name patterns"""
    if field_name.endswith('_TARIHI'):
        return 'DATETIME2'
    elif field_name.endswith('_ZAMANI'):
        return 'DATETIME2'
    elif field_name.endswith('_BILGISI'):
        return 'NVARCHAR(500)'
    elif field_name.endswith('_DURUMU'):
        return 'NVARCHAR(50)'
    elif field_name.endswith('_KODU'):
        return 'NVARCHAR(50)'
    elif field_name.endswith('_NUMARASI'):
        return 'NVARCHAR(100)'
    elif field_name.endswith('_ADI'):
        return 'NVARCHAR(200)'
    elif field_name.endswith('_ADRESI'):
        return 'NVARCHAR(500)'
    elif field_name.endswith('_SIRASI'):
        return 'INT'
    elif field_name.endswith('_SAYISI'):
        return 'INT'
    elif field_name.endswith('_SIFRESI'):
        return 'NVARCHAR(500)'
    elif field_name.endswith('_TURU'):
        return 'NVARCHAR(50)'
    elif field_name.endswith('_TIPI'):
        return 'NVARCHAR(50)'
    elif field_name.endswith('_SEKLI'):
        return 'NVARCHAR(50)'
    elif field_name in ('SOYADI', 'SOYAD'):
        return 'NVARCHAR(100)'
    elif field_name in ('AD', 'ADI'):
        return 'NVARCHAR(100)'
    elif field_name in ('PAROLA',):
        return 'NVARCHAR(500)'
    elif field_name in ('FOTOGRAF_DOSYA_YOLU', 'ACIK_ADRES'):
        return 'NVARCHAR(500)'
    else:
        return 'NVARCHAR(100)'

def get_csharp_type(field_name):
    """Determine C# type based on field name patterns"""
    if field_name.endswith('_TARIHI'):
        return 'DateTime?'
    elif field_name.endswith('_ZAMANI'):
        return 'DateTime?'
    elif field_name.endswith('_SIRASI'):
        return 'int?'
    elif field_name.endswith('_SAYISI'):
        return 'int?'
    else:
        return 'string?'

def get_typescript_type(field_name):
    """Determine TypeScript type based on field name patterns"""
    if field_name.endswith('_TARIHI'):
        return 'Date | null'
    elif field_name.endswith('_ZAMANI'):
        return 'Date | null'
    elif field_name.endswith('_SIRASI'):
        return 'number | null'
    elif field_name.endswith('_SAYISI'):
        return 'number | null'
    else:
        return 'string | null'

# Generate SQL script
sql_lines = []
sql_lines.append("-- =============================================================================")
sql_lines.append("-- Table Updates Script - Add/Remove Fields")
sql_lines.append("-- Generated from table_changes.json")
sql_lines.append("-- =============================================================================")
sql_lines.append("")

for table_info in changes:
    table_name = table_info['table']
    add_fields = table_info['add_fields']
    remove_fields = table_info['remove_fields']

    sql_lines.append(f"-- {table_name}")
    sql_lines.append(f"-- Add: {len(add_fields)} fields, Remove: {len(remove_fields)} fields")
    sql_lines.append("")

    # Add new columns
    for field in add_fields:
        sql_type = get_sql_type(field)
        sql_lines.append(f"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_NAME = '{table_name}' AND COLUMN_NAME = '{field}')")
        sql_lines.append(f"    ALTER TABLE [Lbys].[{table_name}] ADD [{field}] {sql_type} NULL;")
        sql_lines.append("GO")

    # Drop old columns
    for field in remove_fields:
        sql_lines.append(f"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_NAME = '{table_name}' AND COLUMN_NAME = '{field}')")
        sql_lines.append(f"    ALTER TABLE [Lbys].[{table_name}] DROP COLUMN [{field}];")
        sql_lines.append("GO")

    sql_lines.append("")

sql_lines.append("-- =============================================================================")
sql_lines.append("-- End of Script")
sql_lines.append("-- =============================================================================")

with open(r"C:\Proje\GitHub\lbys\Server\Scripts\UpdateTables.sql", 'w', encoding='utf-8') as f:
    f.write("\n".join(sql_lines))

print(f"Generated UpdateTables.sql")

# Table name to folder name mapping (Pascal case)
table_to_folder = {
    'PERSONEL': 'Personel',
    'KULLANICI': 'Kullanici',
    'HASTA_BASVURU': 'HastaBasvuru',
    'CIHAZ': 'Cihaz',
    'HIZMET': 'Hizmet',
    'KURUM': 'Kurum',
    'BIRIM': 'Birim',
    'DEPO': 'Depo',
    'HASTA': 'Hasta',
    'TETKIK': 'Tetkik',
    'TETKIK_PARAMETRE': 'TetkikParametre'
}

# Table name to Angular model name mapping (kebab-case)
table_to_angular = {
    'PERSONEL': 'personel',
    'KULLANICI': 'kullanici',
    'HASTA_BASVURU': 'hasta-basvuru',
    'CIHAZ': 'cihaz',
    'HIZMET': 'hizmet',
    'KURUM': 'kurum',
    'BIRIM': 'birim',
    'DEPO': 'depo',
    'HASTA': 'hasta',
    'TETKIK': 'tetkik',
    'TETKIK_PARAMETRE': 'tetkik-parametre'
}

# Update DTOs
dto_base_path = r"C:\Proje\GitHub\lbys\Server\Server\src\Core\Application\Vem"

for table_info in changes:
    table_name = table_info['table']
    add_fields = table_info['add_fields']
    remove_fields = table_info['remove_fields']

    folder_name = table_to_folder.get(table_name)
    if not folder_name:
        print(f"Warning: No folder mapping for {table_name}")
        continue

    dto_folder = os.path.join(dto_base_path, folder_name)
    if not os.path.exists(dto_folder):
        print(f"Warning: DTO folder not found: {dto_folder}")
        continue

    for filename in os.listdir(dto_folder):
        if filename.endswith('.cs'):
            dto_file = os.path.join(dto_folder, filename)

            with open(dto_file, 'r', encoding='utf-8') as f:
                content = f.read()

            original_content = content

            # Remove fields
            for field in remove_fields:
                patterns = [
                    rf'\s*public\s+bool\s+{field}\s*\{{\s*get;\s*set;\s*\}}\s*\n',
                    rf'\s*public\s+bool\?\s+{field}\s*\{{\s*get;\s*set;\s*\}}\s*\n',
                    rf'\s*public\s+string\?\s+{field}\s*\{{\s*get;\s*set;\s*\}}\s*\n',
                    rf'\s*public\s+string\s+{field}\s*\{{\s*get;\s*set;\s*\}}\s*\n',
                    rf'\s*public\s+DateTime\?\s+{field}\s*\{{\s*get;\s*set;\s*\}}\s*\n',
                    rf'\s*public\s+DateTime\s+{field}\s*\{{\s*get;\s*set;\s*\}}\s*\n',
                ]
                for pattern in patterns:
                    content = re.sub(pattern, '\n', content)

            # Find insertion point (before closing brace of class/record)
            # Look for the last closing brace
            lines = content.split('\n')
            insert_idx = None
            brace_count = 0
            for i in range(len(lines)):
                line = lines[i]
                brace_count += line.count('{') - line.count('}')

            # Find last closing brace at depth 1
            depth = 0
            for i in range(len(lines)):
                line = lines[i]
                for c in line:
                    if c == '{':
                        depth += 1
                    elif c == '}':
                        depth -= 1
                        if depth == 0:
                            insert_idx = i
                            break
                if insert_idx:
                    break

            if insert_idx:
                # Build new field declarations
                new_fields = []
                for field in add_fields:
                    csharp_type = get_csharp_type(field)
                    # Check if field already exists
                    if field not in content:
                        new_fields.append(f"    public {csharp_type} {field} {{ get; set; }}")

                if new_fields:
                    lines.insert(insert_idx, "\n".join(new_fields))
                    content = '\n'.join(lines)

            if content != original_content:
                with open(dto_file, 'w', encoding='utf-8') as f:
                    f.write(content)
                print(f"Updated DTO: {filename}")

print("DTOs updated")

# Update Angular models
angular_models_path = r"C:\Proje\GitHub\lbys\client\src\app\models\vem"

for table_info in changes:
    table_name = table_info['table']
    add_fields = table_info['add_fields']
    remove_fields = table_info['remove_fields']

    model_name = table_to_angular.get(table_name)
    if not model_name:
        print(f"Warning: No Angular mapping for {table_name}")
        continue

    model_filename = f"{model_name}.model.ts"
    model_file = os.path.join(angular_models_path, model_filename)

    if not os.path.exists(model_file):
        print(f"Warning: Angular model not found: {model_file}")
        continue

    with open(model_file, 'r', encoding='utf-8') as f:
        content = f.read()

    original_content = content

    # Remove fields
    for field in remove_fields:
        patterns = [
            rf'\s*{field}\?:\s*(string|boolean|number|Date)(\s*\|\s*null)?;\s*\n',
            rf'\s*{field}:\s*(string|boolean|number|Date)(\s*\|\s*null)?;\s*\n',
        ]
        for pattern in patterns:
            content = re.sub(pattern, '\n', content)

    # Find the last closing brace (end of interface/class)
    lines = content.split('\n')
    insert_idx = None
    for i in range(len(lines) - 1, -1, -1):
        if lines[i].strip() == '}':
            insert_idx = i
            break

    if insert_idx:
        # Build new field declarations
        new_fields = []
        for field in add_fields:
            ts_type = get_typescript_type(field)
            # Check if field already exists
            if field not in content:
                new_fields.append(f"  {field}?: {ts_type};")

        if new_fields:
            lines.insert(insert_idx, "\n".join(new_fields))
            content = '\n'.join(lines)

    if content != original_content:
        with open(model_file, 'w', encoding='utf-8') as f:
            f.write(content)
        print(f"Updated Angular model: {model_filename}")

print("Angular models updated")
print("\nDone! Now run UpdateTables.sql on the database, then regenerate views.")
