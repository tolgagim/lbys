"""
VEM Routes and Navigation Generator
Generates app-routing.module.ts routes and app-navigation.ts items for VEM tables

Usage: python generate_routes_navigation.py
"""

import pyodbc
import os

# Database connection
CONNECTION_STRING = "DRIVER={ODBC Driver 17 for SQL Server};SERVER=192.168.1.20;DATABASE=TESTDATA;UID=sa;PWD=12"

# Output paths
CLIENT_PATH = r"C:\Proje\GitHub\lbys\client\src\app"

def to_camel_case(name):
    """Convert SNAKE_CASE to camelCase"""
    components = name.lower().split('_')
    return components[0] + ''.join(x.title() for x in components[1:])

def to_pascal_case(name):
    """Convert SNAKE_CASE to PascalCase"""
    return ''.join(x.title() for x in name.lower().split('_'))

def to_kebab_case(name):
    """Convert SNAKE_CASE to kebab-case"""
    return name.lower().replace('_', '-')

def get_tables(cursor):
    """Get all tables from Lbys schema"""
    cursor.execute("""
        SELECT TABLE_NAME
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_TYPE = 'BASE TABLE'
        ORDER BY TABLE_NAME
    """)
    return [row[0] for row in cursor.fetchall()]

# VEM categories for navigation grouping
VEM_CATEGORIES = {
    'Hasta Islemleri': [
        'HASTA', 'HASTA_BASVURU', 'HASTA_ARSIV', 'HASTA_ARSIV_DETAY', 'HASTA_BORC',
        'HASTA_DIS', 'HASTA_EPIKRIZ', 'HASTA_FOTOGRAF', 'HASTA_GIZLILIK', 'HASTA_HIZMET',
        'HASTA_ILETISIM', 'HASTA_MALZEME', 'HASTA_NOTLARI', 'HASTA_OLUM', 'HASTA_SEANS',
        'HASTA_SEVK', 'HASTA_TIBBI_BILGI', 'HASTA_UYARI', 'HASTA_VENTILATOR',
        'HASTA_VITAL_FIZIKI_BULGU', 'HASTA_YATAK', 'HASTA_ADLI_RAPOR', 'ANLIK_YATAN_HASTA'
    ],
    'Ameliyat ve Islemler': [
        'AMELIYAT', 'AMELIYAT_EKIP', 'AMELIYAT_ISLEM', 'TIBBI_ORDER', 'TIBBI_ORDER_DETAY',
        'KONSULTASYON', 'KLINIK_SEYIR', 'HEMSIRE_BAKIM'
    ],
    'Laboratuvar ve Tetkik': [
        'TETKIK', 'TETKIK_CIHAZ_ESLESME', 'TETKIK_NUMUNE', 'TETKIK_PARAMETRE',
        'TETKIK_REFERANS_ARALIK', 'TETKIK_SONUC', 'RADYOLOJI', 'RADYOLOJI_SONUC',
        'PATOLOJI', 'BAKTERI_SONUC', 'ANTIBIYOTIK_SONUC'
    ],
    'Kan Merkezi': [
        'KAN_BAGISCI', 'KAN_CIKIS', 'KAN_STOK', 'KAN_TALEP', 'KAN_TALEP_DETAY',
        'KAN_URUN', 'KAN_URUN_IMHA'
    ],
    'Recete ve Ilac': [
        'RECETE', 'RECETE_ILAC', 'RECETE_ILAC_ACIKLAMA', 'ILAC_UYUM', 'OPTIK_RECETE'
    ],
    'Izlem ve Takip': [
        'BEBEK_COCUK_IZLEM', 'COCUK_DIYABET', 'DIYABET', 'EVDE_SAGLIK_IZLEM',
        'GEBE_IZLEM', 'INTIHAR_IZLEM', 'KADIN_IZLEM', 'KUDUZ_IZLEM', 'LOHUSA_IZLEM',
        'MADDE_BAGIMLILIGI', 'OBEZITE_IZLEM', 'RISK_SKORLAMA', 'RISK_SKORLAMA_DETAY',
        'HEMOGLOBINOPATI', 'GETAT'
    ],
    'Kurul ve Raporlar': [
        'KURUL', 'KURUL_ASKERI', 'KURUL_ENGELLI', 'KURUL_ETKEN_MADDE', 'KURUL_HEKIM',
        'KURUL_RAPOR', 'KURUL_TESHIS', 'BILDIRIMI_ZORUNLU'
    ],
    'Fatura ve Odeme': [
        'FATURA', 'ICMAL', 'VEZNE', 'VEZNE_DETAY', 'MEDULA_TAKIP',
        'EK_ODEME', 'EK_ODEME_DETAY', 'EK_ODEME_DONEM'
    ],
    'Dis Islemleri': [
        'DIS_TAAHHUT', 'DIS_TAAHHUT_DETAY', 'DISPROTEZ', 'DISPROTEZ_DETAY',
        'ORTODONTI_ICON_SKOR'
    ],
    'Dogum ve Bebek': [
        'DOGUM', 'DOGUM_DETAY', 'ASI_BILGISI'
    ],
    'Sterilizasyon': [
        'STERILIZASYON_CIKIS', 'STERILIZASYON_GIRIS', 'STERILIZASYON_PAKET',
        'STERILIZASYON_PAKET_DETAY', 'STERILIZASYON_SET', 'STERILIZASYON_SET_DETAY',
        'STERILIZASYON_STOK_DURUM', 'STERILIZASYON_YIKAMA'
    ],
    'Stok Yonetimi': [
        'STOK_DURUM', 'STOK_EHU_TAKIP', 'STOK_FIS', 'STOK_HAREKET', 'STOK_ISTEK',
        'STOK_ISTEK_HAREKET', 'STOK_ISTEK_UYGULAMA', 'STOK_KART', 'DEPO'
    ],
    'Personel': [
        'PERSONEL', 'PERSONEL_BAKMAKLA_YUKUMLU', 'PERSONEL_BANKA', 'PERSONEL_BORDRO',
        'PERSONEL_BORDRO_SONDURUM', 'PERSONEL_EGITIM', 'PERSONEL_GOREVLENDIRME',
        'PERSONEL_IZIN', 'PERSONEL_IZIN_DURUMU', 'PERSONEL_ODUL_CEZA',
        'PERSONEL_OGRENIM', 'PERSONEL_YANDAL', 'NOBETCI_PERSONEL_BILGISI', 'DOKTOR_MESAJI'
    ],
    'Kurum ve Tanimlar': [
        'KURUM', 'FIRMA', 'BINA', 'BIRIM', 'ODA', 'YATAK', 'CIHAZ', 'HIZMET',
        'KULLANICI', 'KULLANICI_GRUP', 'GRUP_UYELIK', 'SYS_PAKET', 'RANDEVU',
        'BASVURU_TANI', 'BASVURU_YEMEK', 'REFERANS_KODLAR', 'SILINEN_KAYITLAR'
    ]
}

def get_category(table_name):
    """Get category for a table"""
    for category, tables in VEM_CATEGORIES.items():
        if table_name in tables:
            return category
    return 'Diger'

def main():
    print("VEM Routes and Navigation Generator")
    print("=" * 50)

    # Connect to database
    print("\nConnecting to database...")
    conn = pyodbc.connect(CONNECTION_STRING)
    cursor = conn.cursor()

    # Get all tables
    print("Fetching tables from Lbys schema...")
    tables = get_tables(cursor)
    print(f"Found {len(tables)} tables")

    cursor.close()
    conn.close()

    # Generate imports for routing
    print("\nGenerating route imports...")
    imports = []
    routes = []

    for table in tables:
        pascal = to_pascal_case(table)
        kebab = to_kebab_case(table)
        imports.append(f"import {{ {pascal}Component }} from './pages/vem/{kebab}/{kebab}.component';")
        routes.append(f"""      {{
        path: 'vem/{kebab}',
        component: {pascal}Component,
        canActivate: [AuthGuardService],
      }},""")

    # Write route imports file
    imports_file = os.path.join(CLIENT_PATH, 'vem-route-imports.txt')
    with open(imports_file, 'w', encoding='utf-8') as f:
        f.write("// VEM Component Imports - Add these to app-routing.module.ts imports section\n\n")
        f.write('\n'.join(imports))

    # Write routes file
    routes_file = os.path.join(CLIENT_PATH, 'vem-routes.txt')
    with open(routes_file, 'w', encoding='utf-8') as f:
        f.write("// VEM Routes - Add these to app-routing.module.ts routes array (inside SideNavOuterToolbarComponent children)\n\n")
        f.write('\n'.join(routes))

    # Generate navigation items by category
    print("Generating navigation items...")

    nav_items = []
    nav_items.append("  // =====================================================")
    nav_items.append("  // VEM - Veri Entegrasyon Merkezi")
    nav_items.append("  // =====================================================")

    # Group tables by category
    categorized = {}
    for table in tables:
        cat = get_category(table)
        if cat not in categorized:
            categorized[cat] = []
        categorized[cat].append(table)

    # Generate navigation for each category
    for category, cat_tables in categorized.items():
        nav_items.append(f"  {{")
        nav_items.append(f"    text: 'VEM.{category.replace(' ', '')}',")
        nav_items.append(f"    icon: 'folder',")
        nav_items.append(f"    path: '',")
        nav_items.append(f"    items: [")

        for table in cat_tables:
            pascal = to_pascal_case(table)
            kebab = to_kebab_case(table)
            display_name = table.replace('_', ' ').title()
            nav_items.append(f"      {{")
            nav_items.append(f"        text: '{display_name}',")
            nav_items.append(f"        path: '/vem/{kebab}',")
            nav_items.append(f"      }},")

        nav_items.append(f"    ],")
        nav_items.append(f"  }},")

    # Write navigation file
    nav_file = os.path.join(CLIENT_PATH, 'vem-navigation.txt')
    with open(nav_file, 'w', encoding='utf-8') as f:
        f.write("// VEM Navigation Items - Add these to app-navigation.ts navigation array\n\n")
        f.write('\n'.join(nav_items))

    print("\n" + "=" * 50)
    print("Generation complete!")
    print(f"\nGenerated files:")
    print(f"  1. {imports_file}")
    print(f"  2. {routes_file}")
    print(f"  3. {nav_file}")
    print("\nNext steps:")
    print("  1. Copy vem-route-imports.txt content to app-routing.module.ts (imports)")
    print("  2. Copy vem-routes.txt content to app-routing.module.ts (routes)")
    print("  3. Copy vem-navigation.txt content to app-navigation.ts")

if __name__ == "__main__":
    main()
