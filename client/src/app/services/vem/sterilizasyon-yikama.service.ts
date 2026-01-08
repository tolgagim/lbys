import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SterilizasyonYikamaDto,
  ListSterilizasyonYikamaDto,
  CreateSterilizasyonYikamaDto,
  UpdateSterilizasyonYikamaDto,
  SterilizasyonYikamaListFilter
} from '../../models/vem/sterilizasyon-yikama.model';

@Injectable({ providedIn: 'root' })
export class SterilizasyonYikamaService extends BaseVemService<
  SterilizasyonYikamaDto,
  ListSterilizasyonYikamaDto,
  CreateSterilizasyonYikamaDto,
  UpdateSterilizasyonYikamaDto,
  SterilizasyonYikamaListFilter
> {
  protected apiUrl = 'v1/vem/sterilizasyon-yikama';

  constructor(http: HttpService) {
    super(http);
  }
}
