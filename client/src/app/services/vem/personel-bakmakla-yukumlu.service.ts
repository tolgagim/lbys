import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelBakmaklaYukumluDto,
  ListPersonelBakmaklaYukumluDto,
  CreatePersonelBakmaklaYukumluDto,
  UpdatePersonelBakmaklaYukumluDto,
  PersonelBakmaklaYukumluListFilter
} from '../../models/vem/personel-bakmakla-yukumlu.model';

@Injectable({ providedIn: 'root' })
export class PersonelBakmaklaYukumluService extends BaseVemService<
  PersonelBakmaklaYukumluDto,
  ListPersonelBakmaklaYukumluDto,
  CreatePersonelBakmaklaYukumluDto,
  UpdatePersonelBakmaklaYukumluDto,
  PersonelBakmaklaYukumluListFilter
> {
  protected apiUrl = 'v1/vem/personel-bakmakla-yukumlu';

  constructor(http: HttpService) {
    super(http);
  }
}
