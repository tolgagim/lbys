import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SterilizasyonSetDto,
  ListSterilizasyonSetDto,
  CreateSterilizasyonSetDto,
  UpdateSterilizasyonSetDto,
  SterilizasyonSetListFilter
} from '../../models/vem/sterilizasyon-set.model';

@Injectable({ providedIn: 'root' })
export class SterilizasyonSetService extends BaseVemService<
  SterilizasyonSetDto,
  ListSterilizasyonSetDto,
  CreateSterilizasyonSetDto,
  UpdateSterilizasyonSetDto,
  SterilizasyonSetListFilter
> {
  protected apiUrl = 'v1/vem/sterilizasyon-set';

  constructor(http: HttpService) {
    super(http);
  }
}
