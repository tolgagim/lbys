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

filepath = r"C:\Proje\GitHub\lbys\Server\Scripts\CreateDboViews.sql"

with open(filepath, 'r', encoding='utf-8') as f:
    content = f.read()

# Split by GO statements (case insensitive, handles newlines)
statements = re.split(r'\n\s*GO\s*\n', content, flags=re.IGNORECASE)

print(f"Found {len(statements)} statements to execute")

conn = pyodbc.connect(conn_str)
cursor = conn.cursor()

success_count = 0
error_count = 0

for i, stmt in enumerate(statements):
    stmt = stmt.strip()
    # Skip comments-only statements
    if not stmt or all(line.strip().startswith('--') or not line.strip() for line in stmt.split('\n')):
        continue

    try:
        cursor.execute(stmt)
        conn.commit()
        success_count += 1
        if success_count % 20 == 0:
            print(f"Progress: {success_count} views created...")
    except Exception as e:
        error_count += 1
        print(f"Error on statement {i+1}: {e}")
        # Show first 200 chars of the statement
        print(f"Statement: {stmt[:200]}...")

cursor.close()
conn.close()

print(f"\nCompleted: {success_count} successful, {error_count} errors")
