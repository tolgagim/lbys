 
import {
  DxButtonModule,
  DxDataGridModule,
  DxDataGridComponent, 
  DxSelectBoxModule,
  DxTextBoxModule,
  DxCheckBoxModule,
} from 'devextreme-angular';
import { DxDropDownButtonModule as DxDropDownButtonModule_1 } from 'devextreme-angular/ui/drop-down-button';
import DataSource from 'devextreme/data/data_source'; 
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxoLoadPanelModule, DxoScrollingModule, DxoSelectionModule, DxoSortingModule, DxoHeaderFilterModule, DxoColumnChooserModule, DxoSearchPanelModule, DxoExportModule, DxoToolbarModule, DxiItemModule, DxiColumnModule } from 'devextreme-angular/ui/nested';
import { HttpClientModule } from '@angular/common/http';
 
import { Component, Input, OnInit, ViewChild } from '@angular/core'; 
import { TranslateModule } from '@ngx-translate/core'; 
import { RoleService } from 'src/app/pages/roles/role.service';
import { UserRoleDto } from 'src/app/models/user/userRoleDto';
import { UserService } from 'src/app/pages/users/user.service';
@Component({
  selector: 'user-role-form',
  standalone: true, 
  templateUrl: './user-role-form.component.html',
  styleUrl: './user-role-form.component.scss',
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
    HttpClientModule, 
    TranslateModule,
    DxCheckBoxModule
]
})
export class UserRoleFormComponent implements OnInit{
  @ViewChild(DxDataGridComponent, { static: true }) dataGrid: DxDataGridComponent;
  

  @Input() userId: string;
  @Input() userRoleList: UserRoleDto[] = [];
  
  dataSource = new DataSource<UserRoleDto>({
    key: 'roleId',
    load: () => {
      // Promise'i döndür ve then içinde userRoleList'i ata
      return this.userServices.getUserRoles(this.userId).then(
        data => {
          this.userRoleList = data;  // Burada veriyi userRoleList'e atıyoruz
          return data;  // Veriyi DataSource'a yükleme için döndürüyoruz
        },
        error => {
          throw error;  // Hata durumunda hata fırlat
        }
      );
    },
  });
 

  constructor(
    private userServices: UserService
  ) {}
 
  getUserRoleData = ()=> ({ ...this.userRoleList }) 

  ngOnInit(): void {

    var dd=this.userId;
    throw new Error('Method not implemented.');
  }


  onContentReady(e: any) {
     
  }

  refresh = () => {
    this.dataGrid.instance.refresh();
  };

  onEnabledChange(data: any, event: any): void {
    // Eğer dizi tanımlı değilse boş bir dizi ata
    if (!this.userRoleList) {
      this.userRoleList = [];
    }

    // enabled alanını güncelle
    const updatedRole: UserRoleDto = {
      ...data.data,
      enabled: event.value
    };

    // UserRoleDto listesinde mevcut öğeyi bul
    const index = this.userRoleList.findIndex(role => role.roleId === updatedRole.roleId);

    if (index !== -1) {
      // Eğer öğe listede varsa güncelle
      this.userRoleList[index] = updatedRole;
    } else {
      // Eğer öğe listede yoksa listeye ekle
      this.userRoleList.push(updatedRole);
    } 
  }
  
  
 

}
