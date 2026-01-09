import pandas as pd
import sys
import io

# Set stdout to UTF-8
sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8')

# Read Excel file
filepath = r"C:\Proje\GitHub\lbys\Server\Scripts\eksik.xls"

try:
    df = pd.read_excel(filepath, engine='xlrd')
    print("Columns:", df.columns.tolist())
    print("\nShape:", df.shape)
    print("\nData:")
    pd.set_option('display.max_columns', None)
    pd.set_option('display.width', None)
    pd.set_option('display.max_colwidth', 100)
    print(df.to_string())
except Exception as e:
    print(f"Error: {e}")
    import traceback
    traceback.print_exc()
