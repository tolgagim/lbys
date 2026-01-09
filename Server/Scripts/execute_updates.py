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

def execute_sql_file(filepath):
    """Execute SQL file with GO separators"""
    with open(filepath, 'r', encoding='utf-8') as f:
        content = f.read()

    # Split by GO statements
    statements = re.split(r'[\r\n]+GO[\r\n]+', content, flags=re.IGNORECASE)

    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()

    success_count = 0
    error_count = 0

    for stmt in statements:
        stmt = stmt.strip()
        if stmt and not stmt.startswith('--'):
            try:
                cursor.execute(stmt)
                conn.commit()
                success_count += 1
            except Exception as e:
                error_count += 1
                print(f"Error: {e}")
                print(f"Statement: {stmt[:100]}...")

    cursor.close()
    conn.close()

    return success_count, error_count

print("Executing UpdateTables.sql...")
success, errors = execute_sql_file(r"C:\Proje\GitHub\lbys\Server\Scripts\UpdateTables.sql")
print(f"UpdateTables.sql: {success} successful, {errors} errors")

print("\nNow regenerating views...")
# Now regenerate views with the updated table columns
from generate_dbo_views import main as generate_views
generate_views()

print("\nNow executing CreateDboViews.sql...")
success, errors = execute_sql_file(r"C:\Proje\GitHub\lbys\Server\Scripts\CreateDboViews.sql")
print(f"CreateDboViews.sql: {success} successful, {errors} errors")

print("\nDone!")
