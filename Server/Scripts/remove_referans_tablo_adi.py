import os
import re

# Paths to search
PATHS = [
    r"C:\Proje\GitHub\lbys\Server\Server\src",
    r"C:\Proje\GitHub\lbys\client\src"
]

def remove_from_cs_file(filepath):
    """Remove REFERANS_TABLO_ADI from C# files"""
    with open(filepath, 'r', encoding='utf-8-sig') as f:
        content = f.read()

    original = content

    # Pattern 1: Property definition in DTOs
    # public string? REFERANS_TABLO_ADI { get; set; }
    # public string REFERANS_TABLO_ADI { get; set; }
    content = re.sub(
        r'\s*public\s+string\??\s+REFERANS_TABLO_ADI\s*\{\s*get;\s*set;\s*\}\s*\n?',
        '\n',
        content
    )

    # Pattern 2: Property assignment in mappings
    # REFERANS_TABLO_ADI = entity.REFERANS_TABLO_ADI,
    content = re.sub(
        r'\s*REFERANS_TABLO_ADI\s*=\s*[^,\n]+,?\s*\n?',
        '\n',
        content
    )

    # Pattern 3: Column attribute
    # [Column("REFERANS_TABLO_ADI")]
    content = re.sub(
        r'\s*\[Column\("REFERANS_TABLO_ADI"\)\]\s*\n?',
        '',
        content
    )

    if content != original:
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(content)
        return True
    return False

def remove_from_ts_file(filepath):
    """Remove REFERANS_TABLO_ADI from TypeScript files"""
    with open(filepath, 'r', encoding='utf-8') as f:
        content = f.read()

    original = content

    # Pattern 1: Property definition
    # REFERANS_TABLO_ADI?: string;
    # REFERANS_TABLO_ADI: string;
    content = re.sub(
        r'\s*REFERANS_TABLO_ADI\??\s*:\s*string\s*;?\s*\n?',
        '\n',
        content
    )

    # Pattern 2: In dataSource columns array
    # { dataField: 'REFERANS_TABLO_ADI', caption: '...' },
    content = re.sub(
        r"\s*\{\s*dataField\s*:\s*['\"]REFERANS_TABLO_ADI['\"][^}]*\}\s*,?\s*\n?",
        '\n',
        content
    )

    # Pattern 3: Simple column definition
    # 'REFERANS_TABLO_ADI',
    content = re.sub(
        r"\s*['\"]REFERANS_TABLO_ADI['\"]\s*,?\s*\n?",
        '\n',
        content
    )

    if content != original:
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(content)
        return True
    return False

def process_directory(path):
    """Process all files in directory"""
    modified_files = []

    for root, dirs, files in os.walk(path):
        # Skip node_modules and other irrelevant directories
        dirs[:] = [d for d in dirs if d not in ['node_modules', 'bin', 'obj', '.git', 'dist', 'build']]

        for filename in files:
            filepath = os.path.join(root, filename)

            # Check if file contains REFERANS_TABLO_ADI
            try:
                with open(filepath, 'r', encoding='utf-8-sig') as f:
                    if 'REFERANS_TABLO_ADI' not in f.read():
                        continue
            except:
                continue

            modified = False

            if filename.endswith('.cs'):
                modified = remove_from_cs_file(filepath)
            elif filename.endswith('.ts'):
                modified = remove_from_ts_file(filepath)

            if modified:
                modified_files.append(filepath)
                print(f"Modified: {filepath}")

    return modified_files

def main():
    print("Removing REFERANS_TABLO_ADI from all files...\n")

    all_modified = []

    for path in PATHS:
        if os.path.exists(path):
            print(f"Processing: {path}")
            modified = process_directory(path)
            all_modified.extend(modified)
            print(f"Modified {len(modified)} files in {path}\n")

    print(f"\nTotal files modified: {len(all_modified)}")

    # Write summary
    with open(r"C:\Proje\GitHub\lbys\Server\Scripts\removed_referans_tablo_adi.log", 'w', encoding='utf-8') as f:
        f.write(f"Total files modified: {len(all_modified)}\n\n")
        for filepath in all_modified:
            f.write(f"{filepath}\n")

    print(f"Log written to: C:\\Proje\\GitHub\\lbys\\Server\\Scripts\\removed_referans_tablo_adi.log")

if __name__ == "__main__":
    main()
