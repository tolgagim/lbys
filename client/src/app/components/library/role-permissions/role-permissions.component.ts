import { Component, Input, OnChanges, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxDataGridModule, DxTabPanelModule, DxCheckBoxModule } from 'devextreme-angular';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { RoleService } from 'src/app/pages/roles/role.service';
import { Permission, PermissionList } from 'src/app/models/permission/permissions';
import { PermissionViewModel } from 'src/app/models/permission/permission_view.model';
import { RoleDto } from 'src/app/models/role/roleDto.model';
import { AuthService } from 'src/app/services';

@Component({
  selector: 'role-permissions',
  standalone: true,
  imports: [CommonModule, DxTabPanelModule, DxDataGridModule, DxCheckBoxModule, TranslateModule],
  templateUrl: './role-permissions.component.html',
  styleUrls: ['./role-permissions.component.scss']
})
export class RolePermissionsComponent implements OnChanges {
  @Input() id: string;
  selectedIndex = 0;
  groupedRoleClaims: { [key: string]: PermissionViewModel[] } = {};
  groupKeys: string[] = [];
  groupHasClaims: { [key: string]: boolean } = {};
  groupSelectedCounts: { [key: string]: number } = {};

  constructor(
    private roleService: RoleService,
    private translate: TranslateService,
    private cdr: ChangeDetectorRef,
    private autservice: AuthService
  ) { }

  async ngOnChanges(changes: SimpleChanges): Promise<void> {
    if (changes.id && changes.id.currentValue) {
      this.selectedIndex = 0;
      const permissionsData = await this.roleService.getByIdWithPermissionsAsync(this.id);
      this.updateGroupedRoleClaims(permissionsData);
      this.cdr.detectChanges();
    }
  }


  private async updateGroupedRoleClaims(data: RoleDto): Promise<void> {
     
    let allPermissions = PermissionList.All;
    var user = await this.autservice.getUserProfile();
    if (user.customerId != null) {
       allPermissions = PermissionList.Admin;
    }

   

    const grouped = allPermissions.reduce((acc: { [key: string]: PermissionViewModel[] }, permission: Permission) => {
      const resourceName = this.translate.instant(permission.resource);
      if (!acc[resourceName]) {
        acc[resourceName] = [];
      }

      const enabled = data.permissions.includes(permission.name.replace('.Permissions', ''));
      // Burada, claims array'ini oluştururken permission.name'i düzeltilmiş haliyle kullanıyoruz
      const permissionViewModel = new PermissionViewModel(
        resourceName,
        [{ ...permission, name: permission.name.replace('.Permissions', '') }],
        enabled ? 1 : 0,
        1,
        enabled
      );

      acc[resourceName].push(permissionViewModel);
      return acc;
    }, {});

    this.groupedRoleClaims = grouped;
    this.groupKeys = Object.keys(this.groupedRoleClaims);

    this.groupHasClaims = this.groupKeys.reduce((acc: { [key: string]: boolean }, key: string) => {
      acc[key] = this.groupedRoleClaims[key] && this.groupedRoleClaims[key].length > 0;
      return acc;
    }, {});

    this.groupSelectedCounts = this.groupKeys.reduce((acc: { [key: string]: number }, key: string) => {
      acc[key] = this.getSelectedCount(this.groupedRoleClaims[key]);
      return acc;
    }, {});

    // Update selectedCount and totalCount in PermissionViewModel
    this.groupKeys.forEach(key => {
      const totalCount = this.groupedRoleClaims[key].length;
      const selectedCount = this.groupSelectedCounts[key];
      this.groupedRoleClaims[key].forEach(pvm => {
        pvm.totalCount = totalCount;
        pvm.selectedCount = selectedCount;
      });
    });

    this.cdr.detectChanges();
  }


  private getSelectedCount(permissions: PermissionViewModel[]): number {
    return permissions.filter(p => p.enabled).length;
  }


  onEnabledChange(data: any, event: any): void {
    // enabled alanını güncelle
    data.data.enabled = event.value;
    const parsedData: PermissionViewModel = data.data as PermissionViewModel;
    //  console.log(parsedData);

    // groupedRoleClaims içindeki ilgili PermissionViewModel'i bulup güncelle
    const group = parsedData.group;
    if (this.groupedRoleClaims[group]) {
      const index = this.groupedRoleClaims[group].findIndex(pvm =>
        pvm.group === parsedData.group &&
        JSON.stringify(pvm.claims) === JSON.stringify(parsedData.claims));
      if (index !== -1) {
        this.groupedRoleClaims[group][index] = parsedData;
      }

      // selectedCount ve totalCount değerlerini güncelle
      const totalCount = this.groupedRoleClaims[group].length;
      const selectedCount = this.getSelectedCount(this.groupedRoleClaims[group]);

      this.groupedRoleClaims[group].forEach(pvm => {
        pvm.totalCount = totalCount;
        pvm.selectedCount = selectedCount;
      });


    }

    var liste = this.getEnabledClaimsNames();
  }


  getEnabledClaimsNames(): string[] {
    let allEnabledClaimsNames: string[] = [];

    // Object.keys ile grup anahtarlarını dolaş
    Object.keys(this.groupedRoleClaims).forEach(group => {
      // Her grup için, 'enabled' özelliği true olanları filtrele ve claims[0].name al
      const enabledClaimsNames = this.groupedRoleClaims[group]
        .filter(pvm => pvm.enabled && pvm.claims.length > 0) // claims dizisi kontrolü
        .map(pvm => pvm.claims[0].name);

      // Toplanan claim isimlerini ana listeye ekle
      allEnabledClaimsNames = allEnabledClaimsNames.concat(enabledClaimsNames);
    });

    return allEnabledClaimsNames;
  }



}
