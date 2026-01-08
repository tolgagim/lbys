import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelIzinDurumuDto,
  ListPersonelIzinDurumuDto,
  CreatePersonelIzinDurumuDto,
  UpdatePersonelIzinDurumuDto,
  PersonelIzinDurumuListFilter
} from '../../models/vem/personel-izin-durumu.model';

@Injectable({ providedIn: 'root' })
export class PersonelIzinDurumuService extends BaseVemService<
  PersonelIzinDurumuDto,
  ListPersonelIzinDurumuDto,
  CreatePersonelIzinDurumuDto,
  UpdatePersonelIzinDurumuDto,
  PersonelIzinDurumuListFilter
> {
  protected apiUrl = 'v1/vem/personel-izin-durumu';

  constructor(http: HttpService) {
    super(http);
  }
}
