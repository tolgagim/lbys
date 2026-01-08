import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelIzinDto,
  ListPersonelIzinDto,
  CreatePersonelIzinDto,
  UpdatePersonelIzinDto,
  PersonelIzinListFilter
} from '../../models/vem/personel-izin.model';

@Injectable({ providedIn: 'root' })
export class PersonelIzinService extends BaseVemService<
  PersonelIzinDto,
  ListPersonelIzinDto,
  CreatePersonelIzinDto,
  UpdatePersonelIzinDto,
  PersonelIzinListFilter
> {
  protected apiUrl = 'v1/vem/personel-izin';

  constructor(http: HttpService) {
    super(http);
  }
}
