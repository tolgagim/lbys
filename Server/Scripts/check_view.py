import pyodbc

conn_str = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=192.168.1.20;"
    "DATABASE=TESTDATA;"
    "UID=sa;"
    "PWD=12;"
    "TrustServerCertificate=yes;"
)

conn = pyodbc.connect(conn_str, autocommit=True)
cursor = conn.cursor()

# Check current VEM_BINA definition
cursor.execute("""
    SELECT OBJECT_DEFINITION(OBJECT_ID('Lbys.VEM_BINA'))
""")
result = cursor.fetchone()
print("Current VEM_BINA definition:")
print(result[0] if result and result[0] else "Not found")

print("\n" + "="*50)
print("Updating VEM_BINA...")

# Update VEM_BINA
sql = """
CREATE OR ALTER VIEW [Lbys].[VEM_BINA] AS
SELECT
    t.[BINA_KODU] AS BINA_KODU
    ,'[Lbys].[BINA]' AS REFERANS_TABLO_ADI
    ,t.[BINA_ADI] AS BINA_ADI
    ,t.[BINA_ADRESI] AS BINA_ADRESI
    ,t.[SKRS_KURUM_KODU] AS SKRS_KURUM_KODU
    ,COALESCE(NULLIF(t.[EKLEYEN_KULLANICI_KODU], '00000000-0000-0000-0000-000000000000'), 'dd5f7300-2924-4902-829c-08e37906d72a') AS EKLEYEN_KULLANICI_KODU
    ,t.[KAYIT_ZAMANI] AS KAYIT_ZAMANI
    ,COALESCE(NULLIF(t.[GUNCELLEYEN_KULLANICI_KODU], '00000000-0000-0000-0000-000000000000'), 'dd5f7300-2924-4902-829c-08e37906d72a') AS GUNCELLEYEN_KULLANICI_KODU
    ,t.[GUNCELLEME_ZAMANI] AS GUNCELLEME_ZAMANI
FROM [Lbys].[BINA] t
"""

try:
    cursor.execute(sql)
    print("VEM_BINA updated successfully!")
except Exception as e:
    print(f"Error: {e}")

# Verify
cursor.execute("""
    SELECT OBJECT_DEFINITION(OBJECT_ID('Lbys.VEM_BINA'))
""")
result = cursor.fetchone()
print("\nNew VEM_BINA definition:")
print(result[0] if result and result[0] else "Not found")

cursor.close()
conn.close()
