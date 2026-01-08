import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KullaniciGrupDto,
  ListKullaniciGrupDto,
  CreateKullaniciGrupDto,
  UpdateKullaniciGrupDto,
  KullaniciGrupListFilter
} from '../../models/vem/kullanici-grup.model';

@Injectable({ providedIn: 'root' })
export class KullaniciGrupService extends BaseVemService<
  KullaniciGrupDto,
  ListKullaniciGrupDto,
  CreateKullaniciGrupDto,
  UpdateKullaniciGrupDto,
  KullaniciGrupListFilter
> {
  protected apiUrl = 'v1/vem/kullanici-grup';

  constructor(http: HttpService) {
    super(http);
  }
}
