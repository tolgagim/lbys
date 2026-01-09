import os
import re

migration_files = [
    r"C:\Proje\GitHub\lbys\Server\Server\src\Migrators\Migrators.MSSQL\Migrations\20260107052941_InitialVem141Tables.cs",
    r"C:\Proje\GitHub\lbys\Server\Server\src\Migrators\Migrators.MSSQL\Migrations\20260107052941_InitialVem141Tables.Designer.cs",
    r"C:\Proje\GitHub\lbys\Server\Server\src\Migrators\Migrators.MSSQL\Migrations\ApplicationDbContextModelSnapshot.cs"
]

def fix_file(filepath):
    if not os.path.exists(filepath):
        print(f"File not found: {filepath}")
        return False

    with open(filepath, 'r', encoding='utf-8-sig') as f:
        content = f.read()

    original = content

    # Pattern 1: Remove orphaned "nullable: false)," or "nullable: true)," lines
    content = re.sub(r'\n\s*nullable:\s*(false|true)\),?\s*\n', '\n', content)

    # Pattern 2: Remove REFERANS_TABLO_ADI property definitions in EF migrations
    # Pattern like: REFERANS_TABLO_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
    content = re.sub(
        r'\s*REFERANS_TABLO_ADI\s*=\s*table\.Column<[^>]+>\([^)]+\),?\s*\n?',
        '\n',
        content
    )

    # Pattern 3: Remove .Property lines for REFERANS_TABLO_ADI
    # b.Property<string>("REFERANS_TABLO_ADI")...
    content = re.sub(
        r'\s*b\.Property<[^>]+>\("REFERANS_TABLO_ADI"\)[^;]*;\s*\n?',
        '\n',
        content
    )

    # Pattern 4: Remove from HasColumnName mappings
    content = re.sub(
        r'\s*\.HasColumnName\("REFERANS_TABLO_ADI"\)[^;]*;?\s*\n?',
        '',
        content
    )

    if content != original:
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(content)
        print(f"Fixed: {filepath}")
        return True
    else:
        print(f"No changes needed: {filepath}")
        return False

def main():
    print("Fixing migration files...\n")

    fixed_count = 0
    for filepath in migration_files:
        if fix_file(filepath):
            fixed_count += 1

    print(f"\nFixed {fixed_count} files")

if __name__ == "__main__":
    main()
