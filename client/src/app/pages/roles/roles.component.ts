
import {
  DxButtonModule,
  DxDataGridModule,
  DxDataGridComponent,
  DxSelectBoxModule,
  DxTextBoxModule,
} from 'devextreme-angular';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';
import { exportDataGrid as exportDataGridToPdf } from 'devextreme/pdf_exporter';
import { exportDataGrid as exportDataGridToXLSX } from 'devextreme/excel_exporter';
import { DxDropDownButtonModule as DxDropDownButtonModule_1 } from 'devextreme-angular/ui/drop-down-button';
import DataSource from 'devextreme/data/data_source';
import { DataService } from 'src/app/services';
import { Workbook } from 'exceljs';
import { saveAs } from 'file-saver-es';
import { jsPDF } from 'jspdf';
import { formatPhone } from 'src/app/pipes/phone.pipe';
import { ContactNewFormComponent as ContactNewFormComponent_1 } from '../../components/library/contact-new-form/contact-new-form.component';
import { FormPopupComponent } from '../../components/utils/form-popup/form-popup.component';
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxoLoadPanelModule, DxoScrollingModule, DxoSelectionModule, DxoSortingModule, DxoHeaderFilterModule, DxoColumnChooserModule, DxoSearchPanelModule, DxoExportModule, DxoToolbarModule, DxiItemModule, DxiColumnModule } from 'devextreme-angular/ui/nested';
import { HttpClientModule } from '@angular/common/http';

import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { RoleService } from './role.service';
import { RolePanelComponent } from "../../components/library/role-panel/role-panel.component";
import { RoleDto } from 'src/app/models/role/roleDto.model';
import { TranslateModule } from '@ngx-translate/core';
import { RoleNewFormComponent } from "../../components/library/role-new-form/role-new-form.component";
import { CreateOrUpdateRoleRequest } from 'src/app/models/role/createOrUpdateRole.Request';
import { Resources } from 'src/app/models/permission/resources';
import { Actions } from 'src/app/models/permission/actions';
import { SharedModule } from 'src/app/shared.module';
import { EncryptionService } from 'src/app/services/encryption.service';

@Component({
  selector: 'app-roles',
  standalone: true,
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.scss',
  providers: [DataService],
  imports: [
    DxDataGridModule,
    DxoLoadPanelModule,
    DxoScrollingModule,
    DxoSelectionModule,
    DxoSortingModule,
    DxoHeaderFilterModule,
    DxoColumnChooserModule,
    DxoSearchPanelModule,
    DxoExportModule,
    DxoToolbarModule,
    DxiItemModule,
    DxDropDownButtonModule_1,
    DxButtonModule,
    DxiColumnModule,
    DxTemplateModule,
    DxSelectBoxModule,
    DxTextBoxModule,
    RolePanelComponent,
    FormPopupComponent,
    ContactNewFormComponent_1,
    HttpClientModule,
    RolePanelComponent,
    TranslateModule,
    RoleNewFormComponent,
    SharedModule
  ]
})
export class RolesComponent implements AfterViewInit {

  @ViewChild(DxDataGridComponent, { static: true }) dataGrid: DxDataGridComponent;

  @ViewChild(RoleNewFormComponent, { static: false }) roleNewForm: RoleNewFormComponent;

  action = Actions;
  resource = Resources;
  isPanelOpened = false;

  isAddRolePopupOpened = false;

  id: string;

  initializing = false;

  dataSource = new DataSource<RoleDto, string>({
    key: 'id',
    load: () => new Promise((resolve, reject) => {
      this.roleServices.getRoles().then(
        data => resolve(data),
        error => reject(error)
      );
    }),
  });

  constructor(
    private roleServices: RoleService,
    private encryptionService: EncryptionService
  ) { }


  ngAfterViewInit(): void {
    this.loadColumnState();
  }

  loadColumnState() {
    const storedColumns = localStorage.getItem('dataGridColumnsRole');
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

      const previousColumns = localStorage.getItem('dataGridColumnsRole');
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

    localStorage.setItem('dataGridColumnsRole', JSON.stringify(currentColumns));
  }

  onContentReady(e: any) {
    if (this.initializing) {
      this.loadColumnState();
    }
  }

  chooseColumnDataGrid = () => this.showColumnChooser();

  showColumnChooser() {
    this.dataGrid.instance.showColumnChooser();
  }


  addContact() {
    this.isAddRolePopupOpened = true;
  };

  refresh = () => {
    this.dataGrid.instance.refresh();
  };

  rowClick(e: DxDataGridTypes.RowClickEvent) {
    const { data } = e;

    this.id = data.id;
    this.isPanelOpened = true;
  }

  onOpenedChange = (value: boolean) => {
    if (!value) {
      this.id = null;
    }
  };

  onPinnedChange = () => {
    this.dataGrid.instance.updateDimensions();
  };

  onDataChange = () => {
    this.refresh();
  };



  customizePhoneCell = ({ value }) => value ? formatPhone(value) : undefined;

  onExporting(e) {
    if (e.format === 'pdf') {
      const doc = new jsPDF();
      exportDataGridToPdf({
        jsPDFDocument: doc,
        component: e.component,
      }).then(() => {
        doc.save('Roles.pdf');
      });
    } else {
      const workbook = new Workbook();
      const worksheet = workbook.addWorksheet('Roles');

      exportDataGridToXLSX({
        component: e.component,
        worksheet,
        autoFilterEnabled: true,
      }).then(() => {
        workbook.xlsx.writeBuffer().then((buffer) => {
          saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'roles.xlsx');
        });
      });
      e.cancel = true;
    }
  }

  onClickSaveNewRole = async () => {

    const userId = this.encryptionService.decryptData(localStorage.getItem('userId'));
    const { id, name, description } = this.roleNewForm.getNewRoleData();
    const createOrUpdateRoleRequest: CreateOrUpdateRoleRequest = {
      name: name,
      description: description,
      customerId: userId
    };
    await this.roleServices.updateRole(createOrUpdateRoleRequest);
    this.refresh();
  };

}
