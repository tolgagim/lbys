import os
import re

CONTROLLERS_PATH = r"C:\Proje\GitHub\lbys\Server\Server\src\Host\Controllers\Vem"

def fix_file(filepath):
    with open(filepath, 'r', encoding='utf-8-sig') as f:
        content = f.read()

    original = content

    # Pattern 1: Fix broken "entity.\nentity." pattern
    # This happens when REFERANS_TABLO_ADI was removed but left "entity." behind
    content = re.sub(r'entity\.\s*\n\s*entity\.', 'entity.', content)

    # Pattern 2: Fix broken "entity.\n\n" pattern (orphaned entity.)
    content = re.sub(r'entity\.\s*\n\s*\n', '\n', content)

    # Pattern 3: Fix any remaining "        entity.\n" (just entity. on its own)
    content = re.sub(r'\s+entity\.\s*\n', '\n', content)

    if content != original:
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(content)
        return True
    return False

def main():
    print("Fixing controller files...\n")

    fixed_count = 0
    for filename in os.listdir(CONTROLLERS_PATH):
        if filename.endswith('Controller.cs'):
            filepath = os.path.join(CONTROLLERS_PATH, filename)
            if fix_file(filepath):
                print(f"Fixed: {filename}")
                fixed_count += 1

    print(f"\nFixed {fixed_count} files")

if __name__ == "__main__":
    main()
