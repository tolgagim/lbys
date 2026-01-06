
import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { firstValueFrom } from "rxjs";
import { EncryptionService } from "src/app/services/encryption.service";
import { HttpService } from "src/app/services/http.service";
import { Router } from "@angular/router";
import { ResponseModel } from "src/app/models/response.model";
import { CustomerDto } from "src/app/models/customer/customerDto";
import { UpdateCustomerRequest } from "src/app/models/customer/updateCustomerRequest";
import { HttpHeaders } from "@angular/common/http";
import notify from 'devextreme/ui/notify'; 
import { UpdateCustomerStatusRequest } from "src/app/models/customer/updateCustomerStatusRequest";
import { CustomerDetailsDto } from "src/app/models/customer/CustomerDetailsDto";

//LocalStorage den geçmeden direk servisden son kullanıcı bilgilerini alıyorum ve localstorege yi güncelliyorum

@Injectable()
export class CustomerService {

  constructor(private http: HttpService, private encryptionService: EncryptionService, private translate: TranslateService, private router: Router) { }





  public async getAllSearch(params: any): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {

      const res = await firstValueFrom(this.http.post<ResponseModel<CustomerDto[]>>('v1/customers/search', params));

      return {
        isOk: true,
        data: res
      };
    } catch (error) {

    }
  }

  public async getCustomerid(id: string): Promise<CustomerDetailsDto> {
    try {
      if (id !== undefined) {
        const res = await firstValueFrom(this.http.get<CustomerDetailsDto>('v1/customers/' + id));


        return res;
      }

    } catch (error) {

    }
  }


  public async updateCustomer(id: string, requestData: UpdateCustomerRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
    
      const res = await firstValueFrom(this.http.put<string>('v1/customers/' + id, requestData));
      const message: string = this.translate.instant("Müşteri Güncellendi");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: true,
        data: res
      };
    } catch (error) {
      return {
        isOk: false,
        data: false
      };
    }
  }

  public async updateStatusCustomer(id: string, requestData: UpdateCustomerStatusRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
    
      const res = await firstValueFrom(this.http.put<string>('v1/customers/status/' + id, requestData));
      const message: string = this.translate.instant("Müşteri Güncellendi");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      return {
        isOk: true,
        data: res
      };
    } catch (error) {
      return {
        isOk: false,
        data: false
      };
    }
  }

}



 
