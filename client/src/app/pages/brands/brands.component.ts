import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import CustomStore from 'devextreme/data/custom_store';
import { DxButtonModule, DxCheckBoxComponent, DxCheckBoxModule, DxDataGridComponent, DxDataGridModule, DxSelectBoxModule, DxSwitchModule, DxTextBoxModule } from 'devextreme-angular';
import { Workbook } from 'exceljs';
import { PagerDisplayMode, PagerPageSize } from 'devextreme-angular/common/grids';
import { BrandService } from './brand.service';
import { DxoLoadPanelModule, DxoScrollingModule, DxoSelectionModule, DxoSortingModule, DxoHeaderFilterModule, DxoColumnChooserModule, DxoSearchPanelModule, DxoExportModule, DxoToolbarModule, DxiItemModule, DxiColumnModule } from 'devextreme-angular/ui/nested';
import { CommonModule } from '@angular/common';
import { DxDropDownButtonModule } from 'devextreme-angular/ui/drop-down-button';
import { DxTemplateModule } from 'devextreme-angular/core';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared.module';
import { Actions } from 'src/app/models/permission/actions';
import { Resources } from 'src/app/models/permission/resources';
import { BrandNewFormComponent } from "../../components/library/brand-new-form/brand-new-form.component";
import { FormPopupComponent } from "../../components/utils/form-popup/form-popup.component";  
import { BrandUpdateFormComponent } from "../../components/library/brand-update-form/brand-update-form.component";
import { UpdateBrandRequest } from 'src/app/models/brand/updateBrandRequest';
import { BrandDto } from 'src/app/models/brand/brandDto'; 
import { CreateBrandRequest } from 'src/app/models/brand/createBrandRequest';
import { custom } from 'devextreme/ui/dialog';

interface Params {
  pageNumber: number;
  pageSize: number;
  search: string;
  orderBy?: string[];
  keyword: string;
}

@Component({
  selector: 'app-brands',
  providers: [BrandService],
  standalone: true,
  imports: [
    TranslateModule,
    CommonModule,
    DxDataGridModule,
    DxoLoadPanelModule,
    DxoScrollingModule,
    DxoSelectionModule,
    DxoSortingModule, 
    DxSwitchModule,
    DxoHeaderFilterModule,
    DxoColumnChooserModule,
    DxoSearchPanelModule,
    DxoExportModule,
    DxoToolbarModule,
    DxiItemModule,
    DxDropDownButtonModule,
    DxButtonModule,
    DxiColumnModule,
    DxTemplateModule,
    DxSelectBoxModule,
    DxTextBoxModule,
    HttpClientModule,
    SharedModule,
    BrandNewFormComponent,
    FormPopupComponent,
    BrandUpdateFormComponent
  ],
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.scss']
})
export class BrandsComponent implements OnInit, AfterViewInit {
  @ViewChild(DxDataGridComponent, { static: true }) dataGrid: DxDataGridComponent;
  @ViewChild(BrandNewFormComponent, { static: false }) brandNewForm: BrandNewFormComponent;
  @ViewChild(BrandUpdateFormComponent, { static: false }) brandUpdateFormComponent: BrandUpdateFormComponent;
  action = Actions;
  resource = Resources;
  initializing = false;
  dataSource: any;
  search: string = "";
  showNavButtons = true;
  showInfo = true;
  allowedPageSizes: (number | PagerPageSize)[] = [8, 12, 20];
  displayMode: PagerDisplayMode = 'full';
  searchKeyword: string = '';
  updateBrandRequest: UpdateBrandRequest;

  createBrandRequest: CreateBrandRequest;
  brandDetailsDto:BrandDto;
  selectBrandId:string;

  isAddPopupOpened = false;
  isUpdateUserPopupOpened = false;

  constructor(
    private brandService: BrandService,
    private ref: ChangeDetectorRef,
    private translate: TranslateService 
  ) { }

  async ngOnInit(): Promise<void> {
    this.pagingGetAll();
  }
  ngAfterViewInit(): void {
    this.loadColumnState();
  }


  getOrder(loadOptions: any): string[] {
    if (loadOptions.sort && loadOptions.sort.length > 0) {
      return loadOptions.sort.map((sortOption: any) => `${sortOption.selector} ${sortOption.desc ? 'desc' : 'asc'}`);
    }
    return ['name'];
  }

  pagingGetAll() {
    this.dataSource = new CustomStore({
      key: "id",
      load: (loadOptions: any) => {
        const pageSize = loadOptions.take || 8;  // Varsayılan olarak 8
        const pageNumber = Math.floor((loadOptions.skip || 0) / pageSize) + 1;

        const params: Params = {
          pageNumber: pageNumber,
          pageSize: pageSize,
          search: this.search,
          orderBy: this.getOrder(loadOptions),
          keyword: this.searchKeyword  // searchKeyword değerini kullan
        };

        return this.brandService.getAllSearch(params).then(response => ({
          data: response.data.data,
          totalCount: response.data.totalCount
        })).catch(error => {
          console.error('Error fetching data:', error);
          return { data: [], totalCount: 0 };
        });
      },
      byKey: (key: string) => {
        return this.brandService.getAllSearch(key);
      }
    });
  }

  onExporting(e: any) {
    const workbook = new Workbook();
    const worksheet = workbook.addWorksheet('Brands');
    // Excel dışa aktarma işleminin devamı...
  }

  onRowPrepared(e: any) {
    if (e.rowType === 'data') {
      e.rowElement.style.borderBottom = '1px solid #ccc';
    }
  }

  onContentReady(e: any) {
    let index = 1;
    e.component.beginUpdate();
    try {
      e.component.dataSource().forEach((item: any) => {
        item.index = index++;
      });
    } catch (error) {

    } finally {
      e.component.endUpdate();
    }

    if (this.initializing) {
      this.loadColumnState();
    }
  }

  updateSearchKeyword(value: any) {
    this.searchKeyword = value;
    this.pagingGetAll();  // Arama kelimesi güncellendiğinde veriyi yeniden yükle
  }

  onOptionChanged(e: any) {
    if (!this.initializing && (e.fullName && (e.fullName.includes('columns') || e.fullName.includes('columnIndex')))) {
      const columns = this.dataGrid.instance.getVisibleColumns().map((col: any, index: number) => ({
        dataField: col.dataField,
        visible: col.visible !== undefined ? col.visible : true,
        index
      }));
      const allColumns = this.dataGrid.instance.option('columns');

      // Gizli sütunları ekle
      allColumns.forEach((col: any) => {
        if (!columns.some((visibleCol: any) => visibleCol.dataField === col.dataField)) {
          columns.push({
            dataField: col.dataField,
            visible: false,
            index: col.visibleIndex !== undefined ? col.visibleIndex : col.index
          });
        }
      });

      const previousColumns = localStorage.getItem('dataGridColumnsBrand');
      const previousColumnsState = previousColumns ? JSON.parse(previousColumns) : [];
      if (JSON.stringify(previousColumnsState) !== JSON.stringify(columns)) {
        this.saveColumnState(columns);
      }
    }
  }

  saveColumnState(columns: any[]) {
    const currentColumns = columns.map((col: any) => {
      if (col && typeof col === 'object' && 'dataField' in col) {
        return {
          dataField: col.dataField,
          visible: col.visible !== undefined ? col.visible : false,
          index: col.index
        };
      }
      return null;
    }).filter(col => col !== null);

    localStorage.setItem('dataGridColumnsBrand', JSON.stringify(currentColumns));
  }

  chooseColumnDataGrid = () => this.showColumnChooser();

  showColumnChooser() {
    this.dataGrid.instance.showColumnChooser();
  }



  refresh = () => {
    this.dataGrid.instance.refresh();
  };

  loadColumnState() {
    const storedColumns = localStorage.getItem('dataGridColumnsBrand');
    if (storedColumns) {
      const columnsState = JSON.parse(storedColumns);
      this.applyColumnState(columnsState);
    }
  }


  applyColumnState(columnsState: any[]) {
    if (this.dataGrid && this.dataGrid.instance) {
      columnsState.forEach(col => {
        if (col && typeof col === 'object' && 'dataField' in col) {
          this.dataGrid.instance.columnOption(col.dataField, {
            visible: col.visible,
            visibleIndex: col.index // visibleIndex olarak da ayarlayın
          });
        }
      });
    }
    setTimeout(() => {
      this.initializing = false; // Başlangıç durumunu tamamladı
    });
  }

  onClickSaveNewBrand = async () => {
    var data = this.brandNewForm.getNewBrandData();

    const newBrand: CreateBrandRequest = {
      name: data.name,
      description: data.description 
    };
    var sonuc = await this.brandService.createBrand(newBrand);

    if (!sonuc.isOk) {
      this.createBrandRequest = data;
    }
    else {
      this.refresh();
    }

  };

  addBrand() {
    this.isAddPopupOpened = true;
    if (this.createBrandRequest !== undefined) {
      this.brandNewForm.newBrandData = this.createBrandRequest;
    }
  };

  onClickUpdateBrand = async () => {
    this.brandUpdateFormComponent.setSavedData();
    this.refresh();
  };


  async editRow(id: string): Promise<void> {
    this.selectBrandId=id;
    this.isUpdateUserPopupOpened = false;  // İlk olarak popup'ı kapat
    const data = await this.brandService.getBrandid(id);
    setTimeout(() => {
      this.brandDetailsDto = { ...data };
      this.isUpdateUserPopupOpened = true;  // Bir miktar gecikmeden sonra popup'ı aç
      this.ref.detectChanges();  // Değişiklikleri zorla algıla
    }, 100);  // 100 milisaniye gecikme genellikle yeterli olur
  }
 
  async deleteRow(id: string): Promise<void> {

    let myDialog = custom({
      title: this.translate.instant('Brands.DeleteBrand'),
      messageHtml: this.translate.instant('Brands.ConfirmDeleteBrand'),
      buttons: [
        {
          text: this.translate.instant('General.No'),
          onClick: (e) => {
            return { buttonClicked: "No" };
          }
        },
        {
          text: this.translate.instant('General.Yes'),
          onClick: (e) => {
            return { buttonClicked: "Yes" };
          }
        }

      ]
    });
    myDialog.show().then(async (dialogResult) => {
      console.log(dialogResult.buttonClicked); // Logs which button was clicked
      if (dialogResult.buttonClicked === "Yes") {
        await this.brandService.deleteBrand(id);
        this.refresh();
      }
    });

  }
}
 
