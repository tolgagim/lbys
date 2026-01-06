
import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { firstValueFrom } from "rxjs"; 
import { HttpService } from "src/app/services/http.service";
import notify from 'devextreme/ui/notify'; 
import { HttpHeaders } from "@angular/common/http";
import { CustomerSmsRequest } from "src/app/models/customer/customerSmsRequest ";
import { CheckSmsCodeRequest } from "src/app/models/customer/checkSmsCodeRequest"; 
import { CreateCustomerWithUserRequest } from "../models/customer/createCustomerWithUserRequest .ts";
 

@Injectable()
export class Smservice {

  constructor(private http: HttpService,private translate: TranslateService) { }

  public async createusersmsasync(requestData: CustomerSmsRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'tenant': 'root'
      });
      const res = await firstValueFrom(this.http.post<boolean>('v1/customers/createusersmsasync', requestData, headers)); 
      const message: string = this.translate.instant("Sms Gönderildi");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: res,
        data: res
      };
    } catch (error) {
      return {
        isOk: false,
        data: false
      };
    }
  }
 
  public async checkusersmsasync(requestData: CheckSmsCodeRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'tenant': 'root'
      });
      const res = await firstValueFrom(this.http.post<boolean>('v1/customers/checkusersmsasync', requestData, headers)); 
      const message: string = this.translate.instant("Şifre Onaylandı");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: res,
        data: res
      };
    } catch (error) {
      const message: string = this.translate.instant("Şifre Hatalı");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
      return {
        isOk: false,
        data: false
      };
    }
  }

  public async createcustomeruser(requestData: CreateCustomerWithUserRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'tenant': 'root'
      });
      const res = await firstValueFrom(this.http.post<boolean>('v1/customers/createcustomeruser', requestData, headers)); 
      const message: string = this.translate.instant("Firma Oluşturuldu");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: res,
        data: res
      };
    } catch (error) {
      // const message: string = this.translate.instant("Firma Oluşturulamadı "+error.Message);
      // notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
      return {
        isOk: false,
        data: false
      };
    }
  }

}

