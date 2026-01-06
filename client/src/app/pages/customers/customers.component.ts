import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import CustomStore from 'devextreme/data/custom_store';
import { DxButtonModule, DxCheckBoxComponent, DxCheckBoxModule, DxDataGridComponent, DxDataGridModule, DxSelectBoxModule, DxSwitchModule, DxTextBoxModule } from 'devextreme-angular';
import { Workbook } from 'exceljs';
import { PagerDisplayMode, PagerPageSize } from 'devextreme-angular/common/grids';
import { CustomerService } from './customer.service';
import { DxoLoadPanelModule, DxoScrollingModule, DxoSelectionModule, DxoSortingModule, DxoHeaderFilterModule, DxoColumnChooserModule, DxoSearchPanelModule, DxoExportModule, DxoToolbarModule, DxiItemModule, DxiColumnModule } from 'devextreme-angular/ui/nested';
import { CommonModule } from '@angular/common';
import { DxDropDownButtonModule } from 'devextreme-angular/ui/drop-down-button';
import { DxTemplateModule } from 'devextreme-angular/core';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared.module';
import { Actions } from 'src/app/models/permission/actions';
import { Resources } from 'src/app/models/permission/resources';
import { CustomerNewFormComponent } from "../../components/library/customer-new-form/customer-new-form.component";
import { FormPopupComponent } from "../../components/utils/form-popup/form-popup.component";
import { CreateCustomerWithUserRequest } from 'src/app/models/customer/createCustomerWithUserRequest .ts';
import { Smservice } from 'src/app/services/sms.service';
import { CustomerUpdateFormComponent } from "../../components/library/customer-update-form/customer-update-form.component";
import { UpdateCustomerRequest } from 'src/app/models/customer/updateCustomerRequest';
import { CustomerDetailsDto } from 'src/app/models/customer/CustomerDetailsDto';
import { UpdateCustomerStatusRequest } from 'src/app/models/customer/updateCustomerStatusRequest';

interface Params {
  pageNumber: number;
  pageSize: number;
  search: string;
  orderBy?: string[];
  keyword: string;
}

@Component({
  selector: 'app-customers',
  providers: [CustomerService, Smservice],
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
    CustomerNewFormComponent,
    FormPopupComponent,
    CustomerUpdateFormComponent
  ],
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit, AfterViewInit {
  @ViewChild(DxDataGridComponent, { static: true }) dataGrid: DxDataGridComponent;
  @ViewChild(CustomerNewFormComponent, { static: false }) customerNewForm: CustomerNewFormComponent;
  @ViewChild(CustomerUpdateFormComponent, { static: false }) customerUpdateFormComponent: CustomerUpdateFormComponent;
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
  updateCustomerRequest: UpdateCustomerRequest;

  createCustomerRequest: CreateCustomerWithUserRequest;
  customerDetailsDto:CustomerDetailsDto;
  selectCustomerId:string;

  isAddPopupOpened = false;
  isUpdateUserPopupOpened = false;

  constructor(
    private customerService: CustomerService,
    private ref: ChangeDetectorRef,
    private translate: TranslateService,
    private smservice: Smservice
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
    return ['code'];
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

        return this.customerService.getAllSearch(params).then(response => ({
          data: response.data.data,
          totalCount: response.data.totalCount
        })).catch(error => {
          console.error('Error fetching data:', error);
          return { data: [], totalCount: 0 };
        });
      },
      byKey: (key: string) => {
        return this.customerService.getAllSearch(key);
      }
    });
  }

  onExporting(e: any) {
    const workbook = new Workbook();
    const worksheet = workbook.addWorksheet('Customers');
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

      const previousColumns = localStorage.getItem('dataGridColumnsCustomer');
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

    localStorage.setItem('dataGridColumnsCustomer', JSON.stringify(currentColumns));
  }

  chooseColumnDataGrid = () => this.showColumnChooser();

  showColumnChooser() {
    this.dataGrid.instance.showColumnChooser();
  }



  refresh = () => {
    this.dataGrid.instance.refresh();
  };

  loadColumnState() {
    const storedColumns = localStorage.getItem('dataGridColumnsCustomer');
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

  onClickSaveNewCustomer = async () => {
    var data = this.customerNewForm.getNewCustomerData();

    const newCustomer: CreateCustomerWithUserRequest = {
      Name: data.Name,
      Description: data.Description,
      TaxNumber: data.TaxNumber,
      TaxOffice: data.TaxOffice,
      Address: data.Address,
      PhoneNumber: data.PhoneNumber,
      MobileNumber: data.MobileNumber,
      UserFirstName: data.UserFirstName,
      UserLastName: data.UserLastName,
      UserEmail: data.UserEmail,
      UserName: data.UserName,
      UserPassword: data.UserPassword,
      UserConfirmPassword: data.UserConfirmPassword,
      Origin: data.Origin,
      SmsCode: "AdminKaydi", //içerde admin kullanıcı kaydı yaparsa aynı sorguyu kullandığım için böyle kontrol ekledim.. bu şekilde gönderilecek
    };
    var sonuc = await this.smservice.createcustomeruser(newCustomer);

    if (!sonuc.isOk) {
      this.createCustomerRequest = data;
    }
    else {
      this.refresh();
    }

  };

  addCustomer() {
    this.isAddPopupOpened = true;
    if (this.createCustomerRequest !== undefined) {
      this.customerNewForm.newCustomerData = this.createCustomerRequest;
    }
  };

  onClickUpdateCustomer = async () => {
    this.customerUpdateFormComponent.setSavedData();
    this.refresh();
  };


  async editRow(id: string): Promise<void> {
    this.selectCustomerId=id;
    this.isUpdateUserPopupOpened = false;  // İlk olarak popup'ı kapat
    const data = await this.customerService.getCustomerid(id);
    setTimeout(() => {
      this.customerDetailsDto = { ...data };
      this.isUpdateUserPopupOpened = true;  // Bir miktar gecikmeden sonra popup'ı aç
      this.ref.detectChanges();  // Değişiklikleri zorla algıla
    }, 100);  // 100 milisaniye gecikme genellikle yeterli olur
  }

  handleSwitchChange(e: any, rowData: any) {
    const newStatus = e.value; // Switch'in yeni değeri
    rowData.data.status = newStatus; // rowData'nın status alanını güncelle,
    const updateStatusRequest: UpdateCustomerStatusRequest = {
      id: rowData.data.id,
      status: rowData.data.status
  };
    this.customerService.updateStatusCustomer(rowData.data.id,updateStatusRequest);
  }
  
  
}
