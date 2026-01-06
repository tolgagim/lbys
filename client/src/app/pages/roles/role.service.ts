
import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { firstValueFrom } from "rxjs";
import { EncryptionService } from "src/app/services/encryption.service";
import { HttpService } from "src/app/services/http.service";
import notify from 'devextreme/ui/notify';
import { Router } from "@angular/router";
import { RoleDto } from "src/app/models/role/roleDto.model";
import { CreateOrUpdateRoleRequest } from "src/app/models/role/createOrUpdateRole.Request";
import { UpdateRolePermissionsRequest } from "src/app/models/role/updateRolePermissions.Request";



@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private http: HttpService, private encryptionService: EncryptionService, private translate: TranslateService, private router: Router) { }



  public async getRoles(): Promise<RoleDto[]> {
    try {
      const userId = this.encryptionService.decryptData(localStorage.getItem('userId'));
      const res = await firstValueFrom(this.http.get<RoleDto[]>('roles?id=' + userId));
      return res;
    } catch (error: any) {

    }
  }



  public async getIdRole(id: string): Promise<RoleDto> {
    try {
      const res = await firstValueFrom(this.http.get<RoleDto>('roles/' + id));
      return res;
    } catch (error: any) {

    }
  }

  public async getByIdWithPermissionsAsync(id: string): Promise<RoleDto> {
    try {
      const res = await firstValueFrom(this.http.get<RoleDto>('roles/' + id + '/permissions'));
      return res;
    } catch (error: any) {

    }
  }


  public async updateRole(requestData: CreateOrUpdateRoleRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const res = await firstValueFrom(this.http.post<any>('roles', requestData));
      const message: string = this.translate.instant("Success.UpdateIsSuccessful");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: true,
        data: null
      };
    } catch (error) {

    }
  }

  public async deleteRole(id: string): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const res = await firstValueFrom(this.http.delete<any>('roles/' + id));
      const message: string = this.translate.instant("Success.UpdateIsSuccessful");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: true,
        data: null
      };
    } catch (error) {

    }
  }



  public async updateRolePermissions(id: string, permissions: string[]): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {

      const Request: UpdateRolePermissionsRequest = {
        roleId: id,
        permissions: permissions
      };
      const res = await firstValueFrom(this.http.put<any>('roles/' + id + '/permissions', Request));

      if (res.status === 200) {
        const message: string = this.translate.instant("Success.UpdateIsSuccessful");
        notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
        return {
          isOk: true,
          data: res.body // Yanıt gövdesi
        };
      } else {
        throw new Error('Unexpected response status: ' + res.status);
      }
    } catch (error) {

    }
  }






}

