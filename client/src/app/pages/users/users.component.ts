import {
  DxButtonModule,
  DxDataGridModule,
  DxDataGridComponent,
  DxSelectBoxModule,
  DxTextBoxModule,
} from 'devextreme-angular';
import { exportDataGrid as exportDataGridToPdf } from 'devextreme/pdf_exporter';
import { exportDataGrid as exportDataGridToXLSX } from 'devextreme/excel_exporter';
import { DxDropDownButtonModule } from 'devextreme-angular/ui/drop-down-button';
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

import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { RolePanelComponent } from "../../components/library/role-panel/role-panel.component";
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { UserDetailsDto } from "src/app/models/user/userDetailsDto";
import { UserService } from './user.service';
import { UserListProfileComponent } from "../../components/library/user-list-profile/user-list-profile.component";
import { CommonModule } from '@angular/common';
import { UserNewFormComponent } from "../../components/library/user-new-form/user-new-form.component";
import { CreateUserRequest } from 'src/app/models/user/createUserRequest';
import { custom } from 'devextreme/ui/dialog';
import { UserRoleFormComponent } from "../../components/library/user-role-form/user-role-form.component";
import { UserRolesRequest } from 'src/app/models/user/userRoleDto';
import { SharedModule } from 'src/app/shared.module';
import { Actions } from "src/app/models/permission/actions";
import { Resources } from 'src/app/models/permission/resources';

@Component({
  selector: 'app-users',
  standalone: true,
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
  providers: [DataService, UserService],
  imports: [
    CommonModule,
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
    DxDropDownButtonModule,
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
    UserListProfileComponent,
    UserNewFormComponent,
    UserRoleFormComponent,
    SharedModule
  ]
})
export class UsersComponent implements AfterViewInit {

  @ViewChild(DxDataGridComponent, { static: true }) dataGrid: DxDataGridComponent;

  @ViewChild(UserListProfileComponent, { static: false }) userProfileNewForm: UserListProfileComponent;
  @ViewChild(UserNewFormComponent, { static: false }) userNewForm: UserNewFormComponent;
  @ViewChild(UserRoleFormComponent, { static: false }) userRoleForm: UserRoleFormComponent;

  action = Actions;
  resource = Resources;
  isPanelOpened = false;
  isAddPopupOpened = false;
  isRolePopupOpened = false;
  isUpdateUserPopupOpened = false;
  userDetailsDto: UserDetailsDto;
  createUserRequest: CreateUserRequest;
  selectUserId: string;

  initializing = false;

  dataSource = new DataSource<UserDetailsDto, string>({
    key: 'id',
    load: () => new Promise((resolve, reject) => {
      this.userServices.getUsers().then(
        data => resolve(data),
        error => reject(error)
      );
    }),
  });

  // dataSource:  UserDetailsDto[] = [];

  constructor(
    private userServices: UserService,
    private ref: ChangeDetectorRef,
    private translate: TranslateService
  ) { }

  // async ngOnInit(): Promise<void> {
  //   var data= await this.userServices.getUsers();
  //   this.dataSource=data; 
  // }


  ngAfterViewInit(): void {
    this.loadColumnState();
  }

  loadColumnState() {
    const storedColumns = localStorage.getItem('dataGridColumnsUser');
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

      const previousColumns = localStorage.getItem('dataGridColumnsUser');
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

    localStorage.setItem('dataGridColumnsUser', JSON.stringify(currentColumns));
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




  refresh = () => {
    this.dataGrid.instance.refresh();
  };


  async editRow(id: string): Promise<void> {
    this.isUpdateUserPopupOpened = false;  // İlk olarak popup'ı kapat
    const userDetails = await this.userServices.getUserid(id);
    setTimeout(() => {
      this.userDetailsDto = { ...userDetails };
      this.isUpdateUserPopupOpened = true;  // Bir miktar gecikmeden sonra popup'ı aç
      this.ref.detectChanges();  // Değişiklikleri zorla algıla
    }, 100);  // 100 milisaniye gecikme genellikle yeterli olur
  }

  async editRole(id: string): Promise<void> {
    this.selectUserId = id;
    this.isRolePopupOpened = true;  // İlk olarak popup'ı kapat 
  }

  onClickEditRoleUser = async () => {
    var data = this.userRoleForm.getUserRoleData();
    const newData: UserRolesRequest = {
      userRoles: data
    };
    await this.userServices.updateUserRoles(this.selectUserId, newData);
    this.selectUserId = "";
  };


  async deleteRow(id: string): Promise<void> {

    let myDialog = custom({
      title: this.translate.instant('Users.DeleteUser'),
      messageHtml: this.translate.instant('Users.ConfirmDeleteUser'),
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
        await this.userServices.deleteUser(id);
        this.refresh();
      }
    });

  }



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

  onClickUpdateUser = async () => {
    this.userProfileNewForm.setSavedData();
    this.refresh();
  };

  onClickSaveNewUser = async () => {

    var data = this.userNewForm.getNewUserData();
    const newData: CreateUserRequest = {
      firstName: data.firstName,
      lastName: data.lastName,
      email: data.email,
      userName: data.userName,
      password: data.password,
      confirmPassword: data.confirmPassword,
      phoneNumber: data.phoneNumber
    };
    var sonuc = await this.userServices.createUser(newData);
    if (!sonuc.isOk) {
      this.createUserRequest = data;
    }
    else {
      this.refresh();
    }

  };

  addUser() {

    this.isAddPopupOpened = true;
    if (this.createUserRequest !== undefined) {
      this.userNewForm.newUserData = this.createUserRequest;
    }

  };

}
