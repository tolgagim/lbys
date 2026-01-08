import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelEgitimDto,
  ListPersonelEgitimDto,
  CreatePersonelEgitimDto,
  UpdatePersonelEgitimDto,
  PersonelEgitimListFilter
} from '../../models/vem/personel-egitim.model';

@Injectable({ providedIn: 'root' })
export class PersonelEgitimService extends BaseVemService<
  PersonelEgitimDto,
  ListPersonelEgitimDto,
  CreatePersonelEgitimDto,
  UpdatePersonelEgitimDto,
  PersonelEgitimListFilter
> {
  protected apiUrl = 'v1/vem/personel-egitim';

  constructor(http: HttpService) {
    super(http);
  }
}
