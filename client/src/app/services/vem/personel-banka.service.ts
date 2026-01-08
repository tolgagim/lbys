import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelBankaDto,
  ListPersonelBankaDto,
  CreatePersonelBankaDto,
  UpdatePersonelBankaDto,
  PersonelBankaListFilter
} from '../../models/vem/personel-banka.model';

@Injectable({ providedIn: 'root' })
export class PersonelBankaService extends BaseVemService<
  PersonelBankaDto,
  ListPersonelBankaDto,
  CreatePersonelBankaDto,
  UpdatePersonelBankaDto,
  PersonelBankaListFilter
> {
  protected apiUrl = 'v1/vem/personel-banka';

  constructor(http: HttpService) {
    super(http);
  }
}
