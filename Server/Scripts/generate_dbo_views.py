import pyodbc

# Database connection
conn_str = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=192.168.1.20;"
    "DATABASE=TESTDATA;"
    "UID=sa;"
    "PWD=12;"
    "TrustServerCertificate=yes;"
)

# Default user GUID for COALESCE
DEFAULT_USER_GUID = 'dd5f7300-2924-4902-829c-08e37906d72a'

def get_tables(cursor):
    """Get all tables in Lbys schema"""
    cursor.execute("""
        SELECT TABLE_NAME
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_TYPE = 'BASE TABLE'
        ORDER BY TABLE_NAME
    """)
    return [row[0] for row in cursor.fetchall()]

def get_columns(cursor, table_name):
    """Get all columns for a table"""
    cursor.execute("""
        SELECT COLUMN_NAME, DATA_TYPE
        FROM INFORMATION_SCHEMA.COLUMNS
        WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_NAME = ?
        ORDER BY ORDINAL_POSITION
    """, table_name)
    return [(row[0], row[1]) for row in cursor.fetchall()]

def generate_view_sql(table_name, columns):
    """Generate CREATE VIEW statement"""
    lines = []
    lines.append(f"-- {table_name}")
    lines.append(f"CREATE OR ALTER VIEW [dbo].[VEM_{table_name}] AS")
    lines.append("SELECT")

    col_lines = []
    first_col = True

    for col_name, data_type in columns:
        # Skip REFERANS_TABLO_ADI column from table - we add it as hardcoded value
        if col_name == 'REFERANS_TABLO_ADI':
            continue

        if first_col:
            # First column without comma
            col_lines.append(f"    t.[{col_name}] AS {col_name}")
            # Add REFERANS_TABLO_ADI as second column
            col_lines.append(f"    ,'[Lbys].[{table_name}]' AS REFERANS_TABLO_ADI")
            first_col = False
            continue

        # COALESCE for user columns
        if col_name in ('EKLEYEN_KULLANICI_KODU', 'GUNCELLEYEN_KULLANICI_KODU'):
            col_lines.append(f"    ,COALESCE(NULLIF(t.[{col_name}], '00000000-0000-0000-0000-000000000000'), '{DEFAULT_USER_GUID}') AS {col_name}")
        else:
            col_lines.append(f"    ,t.[{col_name}] AS {col_name}")

    lines.extend(col_lines)
    lines.append(f"FROM [Lbys].[{table_name}] t;")
    lines.append("GO")
    lines.append("")

    return "\n".join(lines)

def main():
    print("Connecting to database...")
    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()

    print("Getting tables from Lbys schema...")
    tables = get_tables(cursor)
    print(f"Found {len(tables)} tables")

    # Generate SQL script
    sql_parts = []
    sql_parts.append("-- =============================================================================")
    sql_parts.append("-- LBYS SQL Views Creation Script")
    sql_parts.append(f"-- Generated for {len(tables)} LBYS tables")
    sql_parts.append("-- Schema: [dbo] with VEM_ prefix")
    sql_parts.append("-- Includes REFERANS_TABLO_ADI column (hardcoded)")
    sql_parts.append("-- =============================================================================")
    sql_parts.append("")

    for table_name in tables:
        print(f"Processing {table_name}...")
        columns = get_columns(cursor, table_name)
        view_sql = generate_view_sql(table_name, columns)
        sql_parts.append(view_sql)

    sql_parts.append("-- =============================================================================")
    sql_parts.append(f"-- End of Script - Total Views: {len(tables)}")
    sql_parts.append("-- =============================================================================")

    # Write to file
    output_file = r"C:\Proje\GitHub\lbys\Server\Scripts\CreateDboViews.sql"
    with open(output_file, 'w', encoding='utf-8') as f:
        f.write("\n".join(sql_parts))

    print(f"\nScript generated: {output_file}")
    print(f"Total views: {len(tables)}")

    cursor.close()
    conn.close()

if __name__ == "__main__":
    main()
