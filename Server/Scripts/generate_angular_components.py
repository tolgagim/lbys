"""
VEM Angular Component Generator
Generates Angular components for all 141 LBYS tables

Usage: python generate_angular_components.py
"""

import pyodbc
import os
import re

# Database connection
CONNECTION_STRING = "DRIVER={ODBC Driver 17 for SQL Server};SERVER=192.168.1.20;DATABASE=TESTDATA;UID=sa;PWD=12"

# Output directories
CLIENT_PATH = r"C:\Proje\GitHub\lbys\client\src\app"
MODELS_PATH = os.path.join(CLIENT_PATH, "models", "vem")
SERVICES_PATH = os.path.join(CLIENT_PATH, "services", "vem")
PAGES_PATH = os.path.join(CLIENT_PATH, "pages", "vem")

# SQL type to TypeScript type mapping
TYPE_MAP = {
    'nvarchar': 'string',
    'varchar': 'string',
    'char': 'string',
    'nchar': 'string',
    'text': 'string',
    'ntext': 'string',
    'int': 'number',
    'bigint': 'number',
    'smallint': 'number',
    'tinyint': 'number',
    'decimal': 'number',
    'numeric': 'number',
    'float': 'number',
    'real': 'number',
    'money': 'number',
    'smallmoney': 'number',
    'bit': 'boolean',
    'datetime': 'Date',
    'datetime2': 'Date',
    'date': 'Date',
    'time': 'string',
    'uniqueidentifier': 'string',
    'varbinary': 'string',
    'binary': 'string',
    'image': 'string',
}

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

def get_ts_type(sql_type):
    """Get TypeScript type from SQL type"""
    sql_type_lower = sql_type.lower()
    for sql, ts in TYPE_MAP.items():
        if sql_type_lower.startswith(sql):
            return ts
    return 'string'

def get_tables(cursor):
    """Get all tables from Lbys schema"""
    cursor.execute("""
        SELECT TABLE_NAME
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_TYPE = 'BASE TABLE'
        ORDER BY TABLE_NAME
    """)
    return [row[0] for row in cursor.fetchall()]

def get_columns(cursor, table_name):
    """Get columns for a table"""
    cursor.execute("""
        SELECT
            COLUMN_NAME,
            DATA_TYPE,
            IS_NULLABLE,
            CHARACTER_MAXIMUM_LENGTH,
            COLUMN_DEFAULT
        FROM INFORMATION_SCHEMA.COLUMNS
        WHERE TABLE_SCHEMA = 'Lbys' AND TABLE_NAME = ?
        ORDER BY ORDINAL_POSITION
    """, table_name)

    columns = []
    for row in cursor.fetchall():
        columns.append({
            'name': row[0],
            'sql_type': row[1],
            'ts_type': get_ts_type(row[1]),
            'nullable': row[2] == 'YES',
            'max_length': row[3],
            'has_default': row[4] is not None
        })
    return columns

def get_primary_key(cursor, table_name):
    """Get primary key column"""
    cursor.execute("""
        SELECT COLUMN_NAME
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
        WHERE TABLE_SCHEMA = 'Lbys'
        AND TABLE_NAME = ?
        AND CONSTRAINT_NAME LIKE 'PK_%'
    """, table_name)
    row = cursor.fetchone()
    return row[0] if row else 'Id'

def generate_model(table_name, columns, pk_column):
    """Generate TypeScript model file"""
    pascal = to_pascal_case(table_name)
    camel = to_camel_case(table_name)

    # Filter out audit columns for CreateDto
    audit_columns = ['Id', 'CreatedAt', 'CreatedBy', 'UpdatedAt', 'UpdatedBy', 'IsDeleted']

    # Build interface properties
    dto_props = []
    list_props = []
    create_props = []
    filter_props = []
    new_entity_props = []

    for col in columns:
        col_camel = to_camel_case(col['name'])
        ts_type = col['ts_type']
        optional = '?' if col['nullable'] or col['has_default'] else ''

        # Skip Id for create
        is_audit = col['name'] in audit_columns

        dto_props.append(f"  {col_camel}{optional}: {ts_type};")

        # List DTO - only key columns and display columns
        if col['name'] == pk_column or not is_audit:
            if len(list_props) < 8:  # Limit list columns
                list_props.append(f"  {col_camel}{optional}: {ts_type};")

        # Create DTO - skip audit columns
        if not is_audit:
            create_props.append(f"  {col_camel}{optional}: {ts_type};")

            # Filter - only string columns
            if ts_type == 'string' and len(filter_props) < 5:
                filter_props.append(f"  {col_camel}?: string;")

            # New entity defaults
            if ts_type == 'string':
                new_entity_props.append(f"  {col_camel}: '',")
            elif ts_type == 'number':
                new_entity_props.append(f"  {col_camel}: 0,")
            elif ts_type == 'boolean':
                new_entity_props.append(f"  {col_camel}: false,")
            elif ts_type == 'Date':
                new_entity_props.append(f"  {col_camel}: undefined,")

    return f"""// {pascal} Model Definitions
import {{ VemBaseDto, BaseListFilter }} from './base.model';

export interface {pascal}Dto extends VemBaseDto {{
{chr(10).join(dto_props)}
}}

export interface List{pascal}Dto {{
  id: string;
{chr(10).join(list_props)}
}}

export interface Create{pascal}Dto {{
{chr(10).join(create_props)}
}}

export interface Update{pascal}Dto extends Create{pascal}Dto {{
  id: string;
}}

export interface {pascal}ListFilter extends BaseListFilter {{
{chr(10).join(filter_props) if filter_props else '  // No specific filters'}
}}

export const new{pascal}: Create{pascal}Dto = {{
{chr(10).join(new_entity_props)}
}};
"""

def generate_service(table_name):
    """Generate TypeScript service file"""
    pascal = to_pascal_case(table_name)
    kebab = to_kebab_case(table_name)

    return f"""import {{ Injectable }} from '@angular/core';
import {{ BaseVemService }} from './base-vem.service';
import {{ HttpService }} from '../http.service';
import {{
  {pascal}Dto,
  List{pascal}Dto,
  Create{pascal}Dto,
  Update{pascal}Dto,
  {pascal}ListFilter
}} from '../../models/vem/{kebab}.model';

@Injectable({{ providedIn: 'root' }})
export class {pascal}Service extends BaseVemService<
  {pascal}Dto,
  List{pascal}Dto,
  Create{pascal}Dto,
  Update{pascal}Dto,
  {pascal}ListFilter
> {{
  protected apiUrl = 'v1/vem/{kebab}';

  constructor(http: HttpService) {{
    super(http);
  }}
}}
"""

def generate_component_ts(table_name, columns):
    """Generate component TypeScript file"""
    pascal = to_pascal_case(table_name)
    camel = to_camel_case(table_name)
    kebab = to_kebab_case(table_name)

    # Get display name (Turkish-friendly)
    display_name = pascal.replace('_', ' ')

    return f"""import {{ Component, OnInit, ViewChild }} from '@angular/core';
import {{ CommonModule }} from '@angular/common';
import {{
  DxDataGridModule,
  DxDataGridComponent,
  DxButtonModule,
  DxTextBoxModule,
  DxDateBoxModule,
  DxSelectBoxModule,
  DxNumberBoxModule,
  DxCheckBoxModule,
  DxValidatorModule,
  DxValidationGroupModule,
  DxTextAreaModule,
}} from 'devextreme-angular';
import {{ FormPopupComponent }} from '../../../components/shared/form-popup/form-popup.component';
import {{ {pascal}Service }} from '../../../services/vem/{kebab}.service';
import {{
  {pascal}Dto,
  Create{pascal}Dto,
  Update{pascal}Dto,
  new{pascal}
}} from '../../../models/vem/{kebab}.model';
import notify from 'devextreme/ui/notify';
import {{ custom }} from 'devextreme/ui/dialog';

@Component({{
  selector: 'app-{kebab}',
  templateUrl: './{kebab}.component.html',
  styleUrls: ['./{kebab}.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    DxDataGridModule,
    DxButtonModule,
    DxTextBoxModule,
    DxDateBoxModule,
    DxSelectBoxModule,
    DxNumberBoxModule,
    DxCheckBoxModule,
    DxValidatorModule,
    DxValidationGroupModule,
    DxTextAreaModule,
    FormPopupComponent
  ]
}})
export class {pascal}Component implements OnInit {{
  @ViewChild('dataGrid', {{ static: false }}) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selected{pascal}: {pascal}Dto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: Create{pascal}Dto | Update{pascal}Dto = {{ ...new{pascal} }};

  constructor(private {camel}Service: {pascal}Service) {{}}

  ngOnInit(): void {{
    this.loadData();
  }}

  loadData(): void {{
    this.dataSource = this.{camel}Service.createCustomStore();
  }}

  refresh(): void {{
    this.dataGrid.instance.refresh();
  }}

  onSelectionChanged(e: any): void {{
    this.selected{pascal} = e.selectedRowsData[0] || null;
  }}

  onRowDblClick(e: any): void {{
    this.selected{pascal} = e.data;
    this.onEditClick();
  }}

  // ADD
  onAddClick(): void {{
    this.isNewRecord = true;
    this.popupTitle = 'Yeni {display_name}';
    this.formData = {{ ...new{pascal} }};
    this.isEditPopupVisible = true;
  }}

  // EDIT
  async onEditClick(): Promise<void> {{
    if (!this.selected{pascal}) {{
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }}

    this.isNewRecord = false;
    this.popupTitle = '{display_name} Duzenle';

    try {{
      const entity = await this.{camel}Service.getById(this.selected{pascal}.id);
      this.formData = {{ ...entity }};
      this.isEditPopupVisible = true;
    }} catch (error) {{
      notify('Kayit yuklenemedi', 'error', 2000);
    }}
  }}

  // DELETE
  async onDeleteClick(): Promise<void> {{
    if (!this.selected{pascal}) {{
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }}

    const result = await custom({{
      title: 'Silme Onayi',
      messageHtml: `Bu kaydi silmek istediginize emin misiniz?`,
      buttons: [
        {{ text: 'Evet', onClick: () => true }},
        {{ text: 'Hayir', onClick: () => false }}
      ]
    }}).show();

    if (result) {{
      try {{
        await this.{camel}Service.delete(this.selected{pascal}.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selected{pascal} = null;
      }} catch (error) {{
        notify('Kayit silinemedi', 'error', 2000);
      }}
    }}
  }}

  // SAVE
  async onSaveClick(): Promise<void> {{
    this.isLoading = true;
    try {{
      if (this.isNewRecord) {{
        await this.{camel}Service.create(this.formData as Create{pascal}Dto);
        notify('Kayit olusturuldu', 'success', 2000);
      }} else {{
        const updateData = this.formData as Update{pascal}Dto;
        await this.{camel}Service.update(updateData.id, updateData);
        notify('Kayit guncellendi', 'success', 2000);
      }}

      this.isEditPopupVisible = false;
      this.refresh();
    }} catch (error: any) {{
      const message = error?.error?.message || 'Islem basarisiz';
      notify(message, 'error', 3000);
    }} finally {{
      this.isLoading = false;
    }}
  }}

  onCancelClick(): void {{
    this.isEditPopupVisible = false;
  }}
}}
"""

def generate_component_html(table_name, columns):
    """Generate component HTML file"""
    pascal = to_pascal_case(table_name)
    kebab = to_kebab_case(table_name)

    # Get display name
    display_name = pascal.replace('_', ' ')

    # Filter out audit columns and Id for grid
    audit_columns = ['Id', 'CreatedAt', 'CreatedBy', 'UpdatedAt', 'UpdatedBy', 'IsDeleted']
    grid_columns = [c for c in columns if c['name'] not in audit_columns][:10]  # Max 10 columns in grid

    # Generate grid columns
    grid_cols_html = []
    for col in grid_columns:
        camel = to_camel_case(col['name'])
        caption = col['name'].replace('_', ' ').title()
        width = 150 if col['ts_type'] == 'string' else 100

        if col['ts_type'] == 'Date':
            grid_cols_html.append(f'    <dxi-column dataField="{camel}" caption="{caption}" dataType="date" format="dd.MM.yyyy" [width]="{width}"></dxi-column>')
        elif col['ts_type'] == 'boolean':
            grid_cols_html.append(f'    <dxi-column dataField="{camel}" caption="{caption}" dataType="boolean" [width]="80"></dxi-column>')
        else:
            grid_cols_html.append(f'    <dxi-column dataField="{camel}" caption="{caption}" [width]="{width}"></dxi-column>')

    # Filter for form fields (exclude audit columns)
    form_columns = [c for c in columns if c['name'] not in audit_columns]

    # Generate form fields (in rows of 2)
    form_rows = []
    for i in range(0, len(form_columns), 2):
        row_fields = []
        for j in range(2):
            if i + j < len(form_columns):
                col = form_columns[i + j]
                camel = to_camel_case(col['name'])
                label = col['name'].replace('_', ' ').title()
                required = '*' if not col['nullable'] and not col['has_default'] else ''

                if col['ts_type'] == 'Date':
                    field = f'''      <div class="form-field" style="flex: 1;">
        <label>{label} {required}</label>
        <dx-date-box [(value)]="formData.{camel}" displayFormat="dd.MM.yyyy" type="date"></dx-date-box>
      </div>'''
                elif col['ts_type'] == 'boolean':
                    field = f'''      <div class="form-field" style="flex: 1;">
        <label>{label}</label>
        <dx-check-box [(value)]="formData.{camel}"></dx-check-box>
      </div>'''
                elif col['ts_type'] == 'number':
                    field = f'''      <div class="form-field" style="flex: 1;">
        <label>{label} {required}</label>
        <dx-number-box [(value)]="formData.{camel}"></dx-number-box>
      </div>'''
                else:
                    max_len = col['max_length'] or 255
                    if max_len > 500:
                        field = f'''      <div class="form-field" style="flex: 1;">
        <label>{label} {required}</label>
        <dx-text-area [(value)]="formData.{camel}" [height]="80"></dx-text-area>
      </div>'''
                    else:
                        field = f'''      <div class="form-field" style="flex: 1;">
        <label>{label} {required}</label>
        <dx-text-box [(value)]="formData.{camel}" [maxLength]="{max_len}"></dx-text-box>
      </div>'''
                row_fields.append(field)

        if row_fields:
            form_rows.append(f'''    <div class="form-row">
{chr(10).join(row_fields)}
    </div>''')

    return f'''<div class="content-block">
  <dx-data-grid
    #dataGrid
    [dataSource]="dataSource"
    [remoteOperations]="true"
    [focusedRowEnabled]="true"
    keyExpr="id"
    [showBorders]="true"
    [columnAutoWidth]="true"
    [allowColumnResizing]="true"
    [rowAlternationEnabled]="true"
    (onSelectionChanged)="onSelectionChanged($event)"
    (onRowDblClick)="onRowDblClick($event)"
    [height]="'100%'">

    <!-- Toolbar -->
    <dxo-toolbar>
      <dxi-item location="before">
        <div class="grid-header">{display_name}</div>
      </dxi-item>
      <dxi-item location="after">
        <dx-button icon="plus" text="Yeni" type="default" stylingMode="contained" (onClick)="onAddClick()"></dx-button>
      </dxi-item>
      <dxi-item location="after">
        <dx-button icon="edit" text="Duzenle" (onClick)="onEditClick()"></dx-button>
      </dxi-item>
      <dxi-item location="after">
        <dx-button icon="trash" text="Sil" type="danger" (onClick)="onDeleteClick()"></dx-button>
      </dxi-item>
      <dxi-item location="after">
        <dx-button icon="refresh" hint="Yenile" (onClick)="refresh()"></dx-button>
      </dxi-item>
      <dxi-item name="searchPanel" location="after"></dxi-item>
    </dxo-toolbar>

    <!-- Grid Options -->
    <dxo-paging [enabled]="true" [pageSize]="50"></dxo-paging>
    <dxo-pager [showPageSizeSelector]="true" [allowedPageSizes]="[20, 50, 100]" [showInfo]="true"></dxo-pager>
    <dxo-filter-row [visible]="true"></dxo-filter-row>
    <dxo-header-filter [visible]="true"></dxo-header-filter>
    <dxo-sorting mode="multiple"></dxo-sorting>
    <dxo-selection mode="single"></dxo-selection>
    <dxo-search-panel [visible]="true" [width]="200" placeholder="Ara..."></dxo-search-panel>
    <dxo-state-storing [enabled]="true" type="localStorage" storageKey="vem-{kebab}-grid"></dxo-state-storing>

    <!-- Columns -->
{chr(10).join(grid_cols_html)}
  </dx-data-grid>
</div>

<!-- Edit Popup -->
<app-form-popup
  [(visible)]="isEditPopupVisible"
  [titleText]="popupTitle"
  [width]="700"
  [height]="500"
  [isLoading]="isLoading"
  (save)="onSaveClick()"
  (cancel)="onCancelClick()">

  <div class="form-container">
{chr(10).join(form_rows)}
  </div>
</app-form-popup>
'''

def generate_component_scss():
    """Generate component SCSS file"""
    return """.content-block {
  height: 100%;
  padding: 20px;

  dx-data-grid {
    height: 100%;
  }
}

.form-container {
  padding: 16px;

  label {
    display: block;
    font-weight: 600;
    font-size: 12px;
    color: #333;
    margin-bottom: 4px;
  }
}

.form-row {
  display: flex;
  gap: 16px;
  margin-bottom: 16px;
}

.form-field {
  display: flex;
  flex-direction: column;
}
"""

def ensure_dir(path):
    """Create directory if it doesn't exist"""
    if not os.path.exists(path):
        os.makedirs(path)

def main():
    print("VEM Angular Component Generator")
    print("=" * 50)

    # Connect to database
    print("\nConnecting to database...")
    conn = pyodbc.connect(CONNECTION_STRING)
    cursor = conn.cursor()

    # Get all tables
    print("Fetching tables from Lbys schema...")
    tables = get_tables(cursor)
    print(f"Found {len(tables)} tables")

    # Skip already created (Hasta)
    skip_tables = ['HASTA']  # Already manually created
    tables_to_generate = [t for t in tables if t not in skip_tables]

    print(f"\nGenerating components for {len(tables_to_generate)} tables...")

    # Ensure directories exist
    ensure_dir(MODELS_PATH)
    ensure_dir(SERVICES_PATH)

    generated = 0
    errors = []

    for table in tables_to_generate:
        try:
            print(f"  Generating: {table}...", end=" ")

            kebab = to_kebab_case(table)

            # Get table metadata
            columns = get_columns(cursor, table)
            pk_column = get_primary_key(cursor, table)

            if not columns:
                print("SKIPPED (no columns)")
                continue

            # Create component directory
            component_dir = os.path.join(PAGES_PATH, kebab)
            ensure_dir(component_dir)

            # Generate and write model
            model_content = generate_model(table, columns, pk_column)
            model_path = os.path.join(MODELS_PATH, f"{kebab}.model.ts")
            with open(model_path, 'w', encoding='utf-8') as f:
                f.write(model_content)

            # Generate and write service
            service_content = generate_service(table)
            service_path = os.path.join(SERVICES_PATH, f"{kebab}.service.ts")
            with open(service_path, 'w', encoding='utf-8') as f:
                f.write(service_content)

            # Generate and write component files
            ts_content = generate_component_ts(table, columns)
            ts_path = os.path.join(component_dir, f"{kebab}.component.ts")
            with open(ts_path, 'w', encoding='utf-8') as f:
                f.write(ts_content)

            html_content = generate_component_html(table, columns)
            html_path = os.path.join(component_dir, f"{kebab}.component.html")
            with open(html_path, 'w', encoding='utf-8') as f:
                f.write(html_content)

            scss_content = generate_component_scss()
            scss_path = os.path.join(component_dir, f"{kebab}.component.scss")
            with open(scss_path, 'w', encoding='utf-8') as f:
                f.write(scss_content)

            print("OK")
            generated += 1

        except Exception as e:
            print(f"ERROR: {e}")
            errors.append((table, str(e)))

    cursor.close()
    conn.close()

    print("\n" + "=" * 50)
    print(f"Generation complete!")
    print(f"  Generated: {generated} components")
    print(f"  Errors: {len(errors)}")

    if errors:
        print("\nErrors:")
        for table, err in errors:
            print(f"  {table}: {err}")

    print("\nNext steps:")
    print("  1. Update app.routes.ts with VEM routes")
    print("  2. Add VEM menu items to navigation")
    print("  3. Run 'ng serve' to test")

if __name__ == "__main__":
    main()
