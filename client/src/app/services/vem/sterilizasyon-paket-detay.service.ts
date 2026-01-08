import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SterilizasyonPaketDetayDto,
  ListSterilizasyonPaketDetayDto,
  CreateSterilizasyonPaketDetayDto,
  UpdateSterilizasyonPaketDetayDto,
  SterilizasyonPaketDetayListFilter
} from '../../models/vem/sterilizasyon-paket-detay.model';

@Injectable({ providedIn: 'root' })
export class SterilizasyonPaketDetayService extends BaseVemService<
  SterilizasyonPaketDetayDto,
  ListSterilizasyonPaketDetayDto,
  CreateSterilizasyonPaketDetayDto,
  UpdateSterilizasyonPaketDetayDto,
  SterilizasyonPaketDetayListFilter
> {
  protected apiUrl = 'v1/vem/sterilizasyon-paket-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
