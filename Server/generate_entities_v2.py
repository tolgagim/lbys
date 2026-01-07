"""
VEM 2.0 C# Entity Generator v2
141 tablo icin Entity siniflarini olusturur - Duzeltilmis versiyon
"""

import json
import os
import re

def load_tables():
    with open('vem2_data/VEM_2.0_all_tables.json', 'r', encoding='utf-8') as f:
        return json.load(f)

def convert_type(vem_type):
    """VEM veri tipini C# tipine donustur"""
    if not vem_type:
        return 'string'

    vem_type_lower = vem_type.lower().strip()

    if 'alfanumerik' in vem_type_lower or 'alfa' in vem_type_lower:
        return 'string'
    elif 'tarihsaat' in vem_type_lower:
        return 'DateTime?'
    elif 'tarih' in vem_type_lower:
        return 'DateTime?'
    elif 'sayisaltam' in vem_type_lower or 'sayısal' in vem_type_lower and 'tam' in vem_type_lower:
        return 'int?'
    elif 'sayisalondalik' in vem_type_lower or 'ondalik' in vem_type_lower or 'ondalık' in vem_type_lower:
        return 'decimal?'
    elif 'mantiksal' in vem_type_lower or 'mantıksal' in vem_type_lower:
        return 'bool?'
    else:
        return 'string'

def clean_name(name):
    """VEM_ prefix'ini kaldir"""
    if name and name.startswith('VEM_'):
        return name[4:]
    return name

def to_pascal_case(name):
    """SNAKE_CASE'i PascalCase'e cevir"""
    if not name:
        return ''
    parts = name.lower().split('_')
    return ''.join(word.capitalize() for word in parts)

def is_valid_column_name(name):
    """Gecerli kolon adi mi kontrol et"""
    if not name:
        return False
    # VEM_ ile baslayan ve ; iceren satirlar gecersiz
    if 'VEM_' in name and ';' in name:
        return False
    # Sadece harf, rakam ve _ icermeli
    return bool(re.match(r'^[A-Za-z_][A-Za-z0-9_]*$', name))

def generate_entity(table_name, table_data, all_tables):
    """Tek bir entity sinifi olustur"""
    clean_table_name = clean_name(table_name)
    columns = table_data.get('columns', [])

    lines = []
    lines.append(f'/// <summary>')
    lines.append(f'/// {table_name} tablosu - {len(columns)} kolon')
    lines.append(f'/// </summary>')
    lines.append(f'public class {clean_table_name}')
    lines.append('{')

    # Foreign key referanslarini topla (unique)
    fk_references = {}
    added_columns = set()

    for col in columns:
        col_name = col.get('name', '').strip()
        col_type = col.get('type', 'AlfaNumerik')
        description = col.get('description', '')
        nullable = col.get('nullable', 'Evet')
        reference = col.get('reference', '-')

        # Gecersiz kolon adlarini atla
        if not is_valid_column_name(col_name):
            continue

        # Duplicate kolonlari atla
        if col_name in added_columns:
            continue
        added_columns.add(col_name)

        # C# tipini belirle
        csharp_type = convert_type(col_type)

        # Nullable kontrolu (Hayir = zorunlu alan)
        if nullable and ('Hayir' in nullable or 'Hayır' in nullable):
            if csharp_type == 'string':
                pass  # string zaten nullable
            elif csharp_type.endswith('?'):
                csharp_type = csharp_type[:-1]

        # Property yaz
        if description and description != '-':
            desc_clean = description.replace('\n', ' ').replace('\r', ' ').strip()
            if len(desc_clean) > 80:
                desc_clean = desc_clean[:80] + '...'
            lines.append(f'    /// <summary>{desc_clean}</summary>')

        lines.append(f'    public {csharp_type} {col_name} {{ get; set; }}')
        lines.append('')

        # Foreign key referansi varsa kaydet
        if reference and reference != '-' and reference.startswith('VEM_'):
            clean_ref = clean_name(reference)
            # Unique navigation property adi olustur
            nav_name = to_pascal_case(col_name.replace('_KODU', '').replace('_KODU', ''))
            if nav_name not in fk_references:
                fk_references[nav_name] = clean_ref

    # Navigation properties ekle
    if fk_references:
        lines.append('    #region Navigation Properties')
        for nav_name, ref_table in fk_references.items():
            lines.append(f'    public virtual {ref_table}? {nav_name}Navigation {{ get; set; }}')
        lines.append('    #endregion')
        lines.append('')

    lines.append('}')

    return '\n'.join(lines)

def generate_all_entities():
    """Tum entity siniflarini olustur"""
    tables = load_tables()

    output_dir = 'Entities'
    os.makedirs(output_dir, exist_ok=True)

    all_entities = []

    for table_name, table_data in tables.items():
        entity_code = generate_entity(table_name, table_data, tables)
        clean_name_str = clean_name(table_name)
        all_entities.append((clean_name_str, entity_code))

        # Ayri dosyaya yaz
        file_path = os.path.join(output_dir, f'{clean_name_str}.cs')
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write('namespace Lbys.Entities;\n\n')
            f.write(entity_code)

        col_count = len(table_data.get('columns', []))
        print(f'  {clean_name_str}.cs ({col_count} kolon)')

    # Tek dosyada tum entity'leri birlestir
    combined_path = os.path.join(output_dir, '_AllEntities.cs')
    with open(combined_path, 'w', encoding='utf-8') as f:
        f.write('namespace Lbys.Entities;\n\n')
        f.write('#region VEM 2.0 - 141 Tablo Entity Siniflari\n')
        f.write('// Otomatik olusturuldu - VEM 2.0 Saglik Bakanligi Veri Modeli\n')
        f.write('// Toplam: 141 Tablo, 3892 Kolon\n')
        f.write('#endregion\n\n')
        for name, code in sorted(all_entities):
            f.write(code)
            f.write('\n\n')

    print(f'\n{len(all_entities)} entity sinifi olusturuldu')
    return all_entities

def generate_dbcontext(entities):
    """DbContext sinifini olustur"""
    lines = []
    lines.append('using Microsoft.EntityFrameworkCore;')
    lines.append('using Lbys.Entities;')
    lines.append('')
    lines.append('namespace Lbys.Data;')
    lines.append('')
    lines.append('/// <summary>')
    lines.append('/// VEM 2.0 Veritabani Context')
    lines.append('/// 141 Tablo, 3892 Kolon')
    lines.append('/// </summary>')
    lines.append('public class VemDbContext : DbContext')
    lines.append('{')
    lines.append('    public VemDbContext(DbContextOptions<VemDbContext> options) : base(options) { }')
    lines.append('')
    lines.append('    #region DbSets')

    for name, _ in sorted(entities):
        lines.append(f'    public DbSet<{name}> {name} {{ get; set; }}')

    lines.append('    #endregion')
    lines.append('')
    lines.append('    protected override void OnModelCreating(ModelBuilder modelBuilder)')
    lines.append('    {')
    lines.append('        base.OnModelCreating(modelBuilder);')
    lines.append('')
    lines.append('        // Tablo adlarini VEM_ prefix ile ayarla')
    for name, _ in sorted(entities):
        lines.append(f'        modelBuilder.Entity<{name}>().ToTable("VEM_{name}");')
    lines.append('    }')
    lines.append('}')

    os.makedirs('Data', exist_ok=True)
    with open('Data/VemDbContext.cs', 'w', encoding='utf-8') as f:
        f.write('\n'.join(lines))

    print('DbContext olusturuldu: Data/VemDbContext.cs')

if __name__ == '__main__':
    print('='*60)
    print('VEM 2.0 C# Entity Generator v2')
    print('='*60)
    print('')

    entities = generate_all_entities()
    print('')
    generate_dbcontext(entities)

    print('')
    print('Dosyalar:')
    print('  Entities/*.cs - Her tablo icin ayri dosya')
    print('  Entities/_AllEntities.cs - Tum entity\'ler tek dosyada')
    print('  Data/VemDbContext.cs - DbContext sinifi')
