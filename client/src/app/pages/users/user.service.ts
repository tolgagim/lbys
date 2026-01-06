
import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { firstValueFrom } from "rxjs";
import { UserDetailsDto } from "src/app/models/user/userDetailsDto";
import { EncryptionService } from "src/app/services/encryption.service";
import { HttpService } from "src/app/services/http.service";
import notify from 'devextreme/ui/notify';
import { Router } from "@angular/router";
import { UpdateUserRequest } from "src/app/models/user/updateUserRequest";
import { CreateUserRequest } from "src/app/models/user/createUserRequest";
import { UserRoleDto, UserRolesRequest } from "src/app/models/user/userRoleDto";
import { HttpHeaders } from "@angular/common/http";
import { AppConfigService } from "src/app/services/app-config.service";

//LocalStorage den geçmeden direk servisden son kullanıcı bilgilerini alıyorum ve localstorege yi güncelliyorum

@Injectable()
export class UserService {

  constructor(private http: HttpService, private encryptionService: EncryptionService, private translate: TranslateService, private router: Router) { }


  public async getUsers(): Promise<UserDetailsDto[]> {
    try {
      const userId = this.encryptionService.decryptData(localStorage.getItem('userId'));
      const res = await firstValueFrom(this.http.get<UserDetailsDto[]>('users?id=' + userId));
      return res;
    } catch (error: any) {

    }
  }

  public async getUser(): Promise<UserDetailsDto> {
    try {
      const res = await firstValueFrom(this.http.get<UserDetailsDto>('personal/profile'));
      if (res.imageUrl == null) {
        res.imageUrl = '../../../../assets/images/no-user-image.gif';
      }
      else {
        res.imageUrl = AppConfigService.settings.apiEndpoint.endpoint1 + "/" + res.imageUrl;
      }
      const encrypted = this.encryptionService.encryptData(res);
      localStorage.setItem('userProfile', encrypted);
      return res;
    } catch (error) {

    }
  }

  public async getUserid(id: string): Promise<UserDetailsDto> {
    try {
      if (id !== undefined) {
        const res = await firstValueFrom(this.http.get<UserDetailsDto>('users/' + id));
        if (res.imageUrl == null) {
          res.imageUrl = '../../../../assets/images/no-user-image.gif';
        }
        else {
          res.imageUrl = AppConfigService.settings.apiEndpoint.endpoint1 + "/" + res.imageUrl;
        }
        return res;
      }

    } catch (error) {

    }
  }

  public async getUserRoles(id: string): Promise<UserRoleDto[]> {
    try {
      const res = await firstValueFrom(this.http.get<UserRoleDto[]>('users/' + id + '/roles'));
      return res;
    } catch (error: any) {
    }
  }



  public async updateUserRoles(id: string, requestData: UserRolesRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const rolesArray = Object.values(requestData.userRoles);
      const headers = new HttpHeaders().set('Content-Type', 'application/json');
      const res = await firstValueFrom(this.http.post<any>('users/' + id + '/roles', { userRoles: rolesArray }, headers));
      const message: string = this.translate.instant("Success.UpdateIsSuccessful");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: true,
        data: null
      };
    } catch (error) {

    }
  }




  public async updateProfile(requestData: UpdateUserRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {

    try {
      const res = await firstValueFrom(this.http.put<UpdateUserRequest>('personal/profile', requestData));
      const message: string = this.translate.instant("Success.UpdateIsSuccessful");

      // await this.getUser();
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      localStorage.removeItem('authToken');
      this.router.navigateByUrl("/login");
      return {
        isOk: true,
        data: null
      };
    } catch (error) {

    }
  }

  public async updateUser(requestData: UpdateUserRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const res = await firstValueFrom(this.http.put<UpdateUserRequest>('users/' + requestData.id + '/profile', requestData));
      const message: string = this.translate.instant("Success.UpdateIsSuccessful");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');

      return {
        isOk: true,
        data: null
      };
    } catch (error) {

    }
  }


  public async createUser(requestData: CreateUserRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const userId = this.encryptionService.decryptData(localStorage.getItem('userId'));
      requestData.customerId = userId;
      const res = await firstValueFrom(this.http.post<any>('users', requestData));
      const message: string = this.translate.instant("Success.CreateIsSuccessful");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: true,
        data: null
      };
    } catch (error) {
      if (error.status === 200) {
        return {
          isOk: true,
          data: null
        };
      }
      return {
        isOk: false,
        message: error.message
      };
    }
  }


  public async changePassword(password: string, newPassword: string, confirmNewPassword: string): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const requestData = { password, newPassword, confirmNewPassword };
      const res = await firstValueFrom(this.http.put<any>('personal/change-password', requestData));

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


  public async deleteUser(id: string): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const res = await firstValueFrom(this.http.delete<any>('users/' + id));
      const message: string = this.translate.instant("Success.DeleteIsSuccessful");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');

      return {
        isOk: true,
        data: null
      };
    } catch (error) {

    }
  }



}

