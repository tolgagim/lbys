
import { Injectable } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { firstValueFrom } from "rxjs";
import { EncryptionService } from "src/app/services/encryption.service";
import { HttpService } from "src/app/services/http.service";
import { Router } from "@angular/router";
import { StatsDto } from "../models/statsDto";

//LocalStorage den geçmeden direk servisden son kullanıcı bilgilerini alıyorum ve localstorege yi güncelliyorum

@Injectable()
export class DashBoardService {

  constructor(private http: HttpService, private encryptionService: EncryptionService, private translate: TranslateService, private router: Router) { }


  public async get(): Promise<StatsDto> {
    try {
      const userId = this.encryptionService.decryptData(localStorage.getItem('userId'));
      const res = await firstValueFrom(this.http.get<StatsDto>('v1/dashboard?id=' + userId));
      return res;
    } catch (error: any) {

    }
  }



}

