import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KullaniciDto,
  ListKullaniciDto,
  CreateKullaniciDto,
  UpdateKullaniciDto,
  KullaniciListFilter
} from '../../models/vem/kullanici.model';

@Injectable({ providedIn: 'root' })
export class KullaniciService extends BaseVemService<
  KullaniciDto,
  ListKullaniciDto,
  CreateKullaniciDto,
  UpdateKullaniciDto,
  KullaniciListFilter
> {
  protected apiUrl = 'v1/vem/kullanici';

  constructor(http: HttpService) {
    super(http);
  }
}
