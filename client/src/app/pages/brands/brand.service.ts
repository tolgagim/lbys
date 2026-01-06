
import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { firstValueFrom } from "rxjs";
import { EncryptionService } from "src/app/services/encryption.service";
import { HttpService } from "src/app/services/http.service";
import { Router } from "@angular/router";
import { ResponseModel } from "src/app/models/response.model";
import { BrandDto } from "src/app/models/brand/brandDto";
import { UpdateBrandRequest } from "src/app/models/brand/updateBrandRequest";
import notify from 'devextreme/ui/notify';
import { HttpHeaders } from "@angular/common/http";
import { CreateBrandRequest } from "src/app/models/brand/createBrandRequest";

//LocalStorage den geçmeden direk servisden son kullanıcı bilgilerini alıyorum ve localstorege yi güncelliyorum

@Injectable()
export class BrandService {

  constructor(private http: HttpService, private encryptionService: EncryptionService, private translate: TranslateService, private router: Router) { } 

  public async getAllSearch(params: any): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {

      const res = await firstValueFrom(this.http.post<ResponseModel<BrandDto[]>>('v1/brands/search', params));

      return {
        isOk: true,
        data: res
      };
    } catch (error) {

    }
  }

  public async getBrandid(id: string): Promise<BrandDto> {
    try {
      if (id !== undefined) {
        const res = await firstValueFrom(this.http.get<BrandDto>('v1/brands/' + id));


        return res;
      }

    } catch (error) {

    }
  }


  public async updateBrand(id: string, requestData: UpdateBrandRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {

      const res = await firstValueFrom(this.http.put<string>('v1/brands/' + id, requestData));
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

  public async createBrand(requestData: CreateBrandRequest): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const headers = new HttpHeaders({
        'Content-Type': 'application/json'
      });
      const res = await firstValueFrom(this.http.post<boolean>('v1/brands', requestData, headers));
      const message: string = this.translate.instant("Marka Oluşturuldu");
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
  public async deleteBrand(id: string): Promise<{ isOk: boolean, data?: any, message?: string }> {
    try {
      const res = await firstValueFrom(this.http.delete<any>('v1/brands/' + id));
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




