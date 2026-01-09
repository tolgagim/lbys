import pyodbc

conn_str = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=192.168.1.20;"
    "DATABASE=TESTDATA;"
    "UID=sa;"
    "PWD=12;"
    "TrustServerCertificate=yes;"
)

conn = pyodbc.connect(conn_str)
cursor = conn.cursor()

# Get all VEM views
cursor.execute("""
    SELECT TABLE_NAME
    FROM INFORMATION_SCHEMA.VIEWS
    WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_NAME LIKE 'VEM_%'
    ORDER BY TABLE_NAME
""")
views = [row[0] for row in cursor.fetchall()]

print(f"Total VEM views: {len(views)}")
print("\nChecking REFERANS_TABLO_ADI in views...")

has_referans = 0
missing_referans = []

for view_name in views:
    cursor.execute(f"SELECT OBJECT_DEFINITION(OBJECT_ID('Lbys.{view_name}'))")
    definition = cursor.fetchone()[0]

    if definition and 'REFERANS_TABLO_ADI' in definition:
        has_referans += 1
    else:
        missing_referans.append(view_name)

print(f"\nViews with REFERANS_TABLO_ADI: {has_referans}")
print(f"Views missing REFERANS_TABLO_ADI: {len(missing_referans)}")

if missing_referans:
    print("\nMissing views:")
    for v in missing_referans[:10]:
        print(f"  - {v}")
    if len(missing_referans) > 10:
        print(f"  ... and {len(missing_referans) - 10} more")

cursor.close()
conn.close()
