import pyodbc
import re

# Database connection
conn_str = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=192.168.1.20;"
    "DATABASE=TESTDATA;"
    "UID=sa;"
    "PWD=12;"
    "TrustServerCertificate=yes;"
)

def execute_sql_file(cursor, filepath, description):
    """Execute a SQL file with GO statements"""
    print(f"\n{'='*60}")
    print(f"Executing: {description}")
    print(f"File: {filepath}")
    print('='*60)

    with open(filepath, 'r', encoding='utf-8') as f:
        content = f.read()

    # Split by GO statements (on its own line, with optional whitespace)
    # Handle both \n and \r\n line endings
    batches = re.split(r'[\r\n]+GO[\r\n]+', content, flags=re.IGNORECASE)

    success_count = 0
    error_count = 0

    for i, batch in enumerate(batches):
        batch = batch.strip()
        if not batch:
            continue

        # Skip comment-only batches
        lines = [l for l in batch.split('\n') if l.strip() and not l.strip().startswith('--')]
        if not lines:
            continue

        try:
            cursor.execute(batch)
            cursor.commit()
            success_count += 1

            # Print progress every 20 statements
            if success_count % 20 == 0:
                print(f"  Executed {success_count} statements...")

        except Exception as e:
            error_count += 1
            error_msg = str(e)
            # Show first line of batch for context
            first_line = batch.split('\n')[0][:60] if batch else "unknown"
            print(f"  Error [{first_line}...]: {error_msg[:100]}")

    print(f"\nCompleted: {success_count} successful, {error_count} errors")
    return success_count, error_count

def main():
    print("Connecting to database...")
    conn = pyodbc.connect(conn_str, autocommit=False)
    cursor = conn.cursor()

    scripts = [
        (r"C:\Proje\GitHub\lbys\Server\Scripts\DropReferansTabloAdiColumn.sql",
         "Drop REFERANS_TABLO_ADI columns from 114 tables"),
        (r"C:\Proje\GitHub\lbys\Server\Scripts\CreateLbysViews.sql",
         "Create 141 VEM views with hardcoded REFERANS_TABLO_ADI"),
    ]

    total_success = 0
    total_errors = 0

    for filepath, description in scripts:
        success, errors = execute_sql_file(cursor, filepath, description)
        total_success += success
        total_errors += errors

    print(f"\n{'='*60}")
    print(f"TOTAL: {total_success} successful, {total_errors} errors")
    print('='*60)

    cursor.close()
    conn.close()

if __name__ == "__main__":
    main()
