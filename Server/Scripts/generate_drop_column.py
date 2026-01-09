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

def get_tables_with_referans_column(cursor):
    """Get all tables in Lbys schema that have REFERANS_TABLO_ADI column"""
    cursor.execute("""
        SELECT TABLE_NAME
        FROM INFORMATION_SCHEMA.COLUMNS
        WHERE TABLE_SCHEMA = 'Lbys'
          AND COLUMN_NAME = 'REFERANS_TABLO_ADI'
        ORDER BY TABLE_NAME
    """)
    return [row[0] for row in cursor.fetchall()]

def main():
    print("Connecting to database...")
    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()

    print("Finding tables with REFERANS_TABLO_ADI column...")
    tables = get_tables_with_referans_column(cursor)
    print(f"Found {len(tables)} tables with REFERANS_TABLO_ADI column")

    # Generate SQL script
    sql_parts = []
    sql_parts.append("-- =============================================================================")
    sql_parts.append("-- Drop REFERANS_TABLO_ADI column from all Lbys tables")
    sql_parts.append(f"-- Tables affected: {len(tables)}")
    sql_parts.append("-- =============================================================================")
    sql_parts.append("")

    for table_name in tables:
        sql_parts.append(f"-- {table_name}")
        sql_parts.append(f"ALTER TABLE [Lbys].[{table_name}] DROP COLUMN [REFERANS_TABLO_ADI];")
        sql_parts.append("GO")
        sql_parts.append("")
        print(f"Added: {table_name}")

    sql_parts.append("-- =============================================================================")
    sql_parts.append(f"-- End of Script - Total columns dropped: {len(tables)}")
    sql_parts.append("-- =============================================================================")

    # Write to file
    output_file = r"C:\Proje\GitHub\lbys\Server\Scripts\DropReferansTabloAdiColumn.sql"
    with open(output_file, 'w', encoding='utf-8') as f:
        f.write("\n".join(sql_parts))

    print(f"\nScript generated: {output_file}")
    print(f"Total tables: {len(tables)}")

    cursor.close()
    conn.close()

if __name__ == "__main__":
    main()
