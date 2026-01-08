import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SterilizasyonGirisDto,
  ListSterilizasyonGirisDto,
  CreateSterilizasyonGirisDto,
  UpdateSterilizasyonGirisDto,
  SterilizasyonGirisListFilter
} from '../../models/vem/sterilizasyon-giris.model';

@Injectable({ providedIn: 'root' })
export class SterilizasyonGirisService extends BaseVemService<
  SterilizasyonGirisDto,
  ListSterilizasyonGirisDto,
  CreateSterilizasyonGirisDto,
  UpdateSterilizasyonGirisDto,
  SterilizasyonGirisListFilter
> {
  protected apiUrl = 'v1/vem/sterilizasyon-giris';

  constructor(http: HttpService) {
    super(http);
  }
}
