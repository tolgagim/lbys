"""
VEM 2.0 C# Entity Generator v3
Primary Key ve Data Annotations ile
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
    elif 'sayisaltam' in vem_type_lower or ('sayısal' in vem_type_lower and 'tam' in vem_type_lower):
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
    if 'VEM_' in name and ';' in name:
        return False
    return bool(re.match(r'^[A-Za-z_][A-Za-z0-9_]*$', name))

def get_primary_key_name(table_name, columns):
    """Tablonun primary key kolonunu belirle"""
    clean_table = clean_name(table_name)

    # Oncelik 1: TABLO_KODU (ornegin AMELIYAT tablosu icin AMELIYAT_KODU)
    expected_pk = f"{clean_table}_KODU"
    for col in columns:
        if col.get('name') == expected_pk:
            return expected_pk

    # Oncelik 2: Ilk kolon _KODU ile bitiyorsa
    if columns and len(columns) > 0:
        first_col = columns[0].get('name', '')
        if first_col.endswith('_KODU'):
            return first_col

    # Oncelik 3: _KODU ile biten ilk kolon
    for col in columns:
        col_name = col.get('name', '')
        if col_name.endswith('_KODU'):
            return col_name

    # Oncelik 4: ID ile biten kolon
    for col in columns:
        col_name = col.get('name', '')
        if col_name.endswith('_ID') or col_name == 'ID':
            return col_name

    # Fallback: Ilk kolon
    if columns and len(columns) > 0:
        return columns[0].get('name', 'ID')

    return 'ID'

def generate_entity(table_name, table_data, all_tables):
    """Tek bir entity sinifi olustur"""
    clean_table_name = clean_name(table_name)
    columns = table_data.get('columns', [])

    # Primary key belirle
    pk_name = get_primary_key_name(table_name, columns)

    lines = []
    lines.append('using System.ComponentModel.DataAnnotations;')
    lines.append('using System.ComponentModel.DataAnnotations.Schema;')
    lines.append('')
    lines.append(f'namespace Lbys.Entities;')
    lines.append('')
    lines.append(f'/// <summary>')
    lines.append(f'/// {table_name} tablosu - {len(columns)} kolon')
    lines.append(f'/// </summary>')
    lines.append(f'[Table("VEM_{clean_table_name}")]')
    lines.append(f'public class {clean_table_name}')
    lines.append('{')

    fk_references = {}
    added_columns = set()

    for col in columns:
        col_name = col.get('name', '').strip()
        col_type = col.get('type', 'AlfaNumerik')
        description = col.get('description', '')
        nullable = col.get('nullable', 'Evet')
        reference = col.get('reference', '-')

        if not is_valid_column_name(col_name):
            continue

        if col_name in added_columns:
            continue
        added_columns.add(col_name)

        csharp_type = convert_type(col_type)

        # Primary Key ise nullable olmamali
        is_pk = (col_name == pk_name)

        # Nullable kontrolu
        is_required = nullable and ('Hayir' in nullable or 'Hayır' in nullable)

        if is_pk or is_required:
            if csharp_type == 'string':
                pass
            elif csharp_type.endswith('?'):
                csharp_type = csharp_type[:-1]

        # Property yaz
        if description and description != '-':
            desc_clean = description.replace('\n', ' ').replace('\r', ' ').strip()
            if len(desc_clean) > 80:
                desc_clean = desc_clean[:80] + '...'
            lines.append(f'    /// <summary>{desc_clean}</summary>')

        # Primary Key attribute
        if is_pk:
            lines.append('    [Key]')

        # Required attribute (zorunlu alanlar icin)
        if is_required and csharp_type == 'string' and not is_pk:
            lines.append('    [Required]')

        # Foreign Key attribute
        if reference and reference != '-' and reference.startswith('VEM_'):
            clean_ref = clean_name(reference)
            nav_name = to_pascal_case(col_name.replace('_KODU', ''))
            if nav_name not in fk_references:
                lines.append(f'    [ForeignKey("{nav_name}Navigation")]')
                fk_references[nav_name] = clean_ref

        lines.append(f'    public {csharp_type} {col_name} {{ get; set; }}')
        lines.append('')

    # Navigation properties
    if fk_references:
        lines.append('    #region Navigation Properties')
        for nav_name, ref_table in fk_references.items():
            lines.append(f'    public virtual {ref_table}? {nav_name}Navigation {{ get; set; }}')
        lines.append('    #endregion')
        lines.append('')

    lines.append('}')

    return '\n'.join(lines), pk_name

def generate_all_entities():
    """Tum entity siniflarini olustur"""
    tables = load_tables()

    output_dir = 'Entities'
    os.makedirs(output_dir, exist_ok=True)

    all_entities = []
    pk_info = {}

    for table_name, table_data in tables.items():
        entity_code, pk_name = generate_entity(table_name, table_data, tables)
        clean_name_str = clean_name(table_name)
        all_entities.append((clean_name_str, entity_code))
        pk_info[clean_name_str] = pk_name

        # Ayri dosyaya yaz
        file_path = os.path.join(output_dir, f'{clean_name_str}.cs')
        with open(file_path, 'w', encoding='utf-8') as f:
            f.write(entity_code)

        col_count = len(table_data.get('columns', []))
        print(f'  {clean_name_str}.cs ({col_count} kolon) - PK: {pk_name}')

    # Tek dosyada tum entity'leri birlestir
    combined_path = os.path.join(output_dir, '_AllEntities.cs')
    with open(combined_path, 'w', encoding='utf-8') as f:
        f.write('using System.ComponentModel.DataAnnotations;\n')
        f.write('using System.ComponentModel.DataAnnotations.Schema;\n\n')
        f.write('namespace Lbys.Entities;\n\n')
        f.write('#region VEM 2.0 - 141 Tablo Entity Siniflari\n')
        f.write('// Otomatik olusturuldu - VEM 2.0 Saglik Bakanligi Veri Modeli\n')
        f.write('// Toplam: 141 Tablo, 3892 Kolon\n')
        f.write('#endregion\n\n')
        for name, code in sorted(all_entities):
            # using ve namespace satirlarini cikar (tek dosya icin)
            code_lines = code.split('\n')
            filtered_lines = [l for l in code_lines if not l.startswith('using ') and not l.startswith('namespace ') and l.strip() != '']
            f.write('\n'.join(filtered_lines))
            f.write('\n\n')

    print(f'\n{len(all_entities)} entity sinifi olusturuldu')
    return all_entities, pk_info

def generate_dbcontext(entities, pk_info):
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
    lines.append('        // Primary Key tanimlamalari')
    for name, _ in sorted(entities):
        pk = pk_info.get(name, f'{name}_KODU')
        lines.append(f'        modelBuilder.Entity<{name}>().HasKey(e => e.{pk});')
    lines.append('    }')
    lines.append('}')

    os.makedirs('Data', exist_ok=True)
    with open('Data/VemDbContext.cs', 'w', encoding='utf-8') as f:
        f.write('\n'.join(lines))

    print('DbContext olusturuldu: Data/VemDbContext.cs')

if __name__ == '__main__':
    print('='*60)
    print('VEM 2.0 C# Entity Generator v3 - Primary Key ile')
    print('='*60)
    print('')

    entities, pk_info = generate_all_entities()
    print('')
    generate_dbcontext(entities, pk_info)

    print('')
    print('Dosyalar:')
    print('  Entities/*.cs - Her tablo icin ayri dosya')
    print('  Entities/_AllEntities.cs - Tum entityler tek dosyada')
    print('  Data/VemDbContext.cs - DbContext sinifi')
