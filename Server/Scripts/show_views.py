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

views_to_check = ['VEM_AMELIYAT', 'VEM_HASTA', 'VEM_PERSONEL', 'VEM_BINA', 'VEM_KURUM']

for view_name in views_to_check:
    cursor.execute(f"SELECT OBJECT_DEFINITION(OBJECT_ID('Lbys.{view_name}'))")
    result = cursor.fetchone()

    print(f"\n{'='*60}")
    print(f"{view_name}:")
    print('='*60)
    if result and result[0]:
        print(result[0][:500])
    else:
        print("View not found!")

cursor.close()
conn.close()
