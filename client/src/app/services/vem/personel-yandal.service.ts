import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelYandalDto,
  ListPersonelYandalDto,
  CreatePersonelYandalDto,
  UpdatePersonelYandalDto,
  PersonelYandalListFilter
} from '../../models/vem/personel-yandal.model';

@Injectable({ providedIn: 'root' })
export class PersonelYandalService extends BaseVemService<
  PersonelYandalDto,
  ListPersonelYandalDto,
  CreatePersonelYandalDto,
  UpdatePersonelYandalDto,
  PersonelYandalListFilter
> {
  protected apiUrl = 'v1/vem/personel-yandal';

  constructor(http: HttpService) {
    super(http);
  }
}
