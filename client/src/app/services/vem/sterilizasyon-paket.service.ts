import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SterilizasyonPaketDto,
  ListSterilizasyonPaketDto,
  CreateSterilizasyonPaketDto,
  UpdateSterilizasyonPaketDto,
  SterilizasyonPaketListFilter
} from '../../models/vem/sterilizasyon-paket.model';

@Injectable({ providedIn: 'root' })
export class SterilizasyonPaketService extends BaseVemService<
  SterilizasyonPaketDto,
  ListSterilizasyonPaketDto,
  CreateSterilizasyonPaketDto,
  UpdateSterilizasyonPaketDto,
  SterilizasyonPaketListFilter
> {
  protected apiUrl = 'v1/vem/sterilizasyon-paket';

  constructor(http: HttpService) {
    super(http);
  }
}
