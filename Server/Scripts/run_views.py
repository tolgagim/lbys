import pyodbc
import re

conn_str = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=192.168.1.20;"
    "DATABASE=TESTDATA;"
    "UID=sa;"
    "PWD=12;"
    "TrustServerCertificate=yes;"
)

def main():
    print("Connecting to database...")
    conn = pyodbc.connect(conn_str, autocommit=True)
    cursor = conn.cursor()

    filepath = r"C:\Proje\GitHub\lbys\Server\Scripts\CreateLbysViews.sql"

    print(f"Reading: {filepath}")
    with open(filepath, 'r', encoding='utf-8') as f:
        content = f.read()

    # Split by GO
    batches = re.split(r'[\r\n]+GO[\r\n]+', content, flags=re.IGNORECASE)

    success = 0
    errors = 0

    for batch in batches:
        batch = batch.strip()
        if not batch or batch.startswith('--'):
            continue

        # Skip comment-only
        lines = [l for l in batch.split('\n') if l.strip() and not l.strip().startswith('--')]
        if not lines:
            continue

        try:
            cursor.execute(batch)
            success += 1
            if success % 20 == 0:
                print(f"  Created {success} views...")
        except Exception as e:
            errors += 1
            print(f"  Error: {str(e)[:80]}")

    print(f"\nCompleted: {success} views created, {errors} errors")

    # Verify
    cursor.execute("SELECT COUNT(*) FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_NAME LIKE 'VEM_%'")
    count = cursor.fetchone()[0]
    print(f"Total VEM views in Lbys schema: {count}")

    cursor.close()
    conn.close()

if __name__ == "__main__":
    main()
