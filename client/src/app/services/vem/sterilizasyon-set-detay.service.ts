import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SterilizasyonSetDetayDto,
  ListSterilizasyonSetDetayDto,
  CreateSterilizasyonSetDetayDto,
  UpdateSterilizasyonSetDetayDto,
  SterilizasyonSetDetayListFilter
} from '../../models/vem/sterilizasyon-set-detay.model';

@Injectable({ providedIn: 'root' })
export class SterilizasyonSetDetayService extends BaseVemService<
  SterilizasyonSetDetayDto,
  ListSterilizasyonSetDetayDto,
  CreateSterilizasyonSetDetayDto,
  UpdateSterilizasyonSetDetayDto,
  SterilizasyonSetDetayListFilter
> {
  protected apiUrl = 'v1/vem/sterilizasyon-set-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
