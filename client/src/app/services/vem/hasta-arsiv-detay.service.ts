import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaArsivDetayDto,
  ListHastaArsivDetayDto,
  CreateHastaArsivDetayDto,
  UpdateHastaArsivDetayDto,
  HastaArsivDetayListFilter
} from '../../models/vem/hasta-arsiv-detay.model';

@Injectable({ providedIn: 'root' })
export class HastaArsivDetayService extends BaseVemService<
  HastaArsivDetayDto,
  ListHastaArsivDetayDto,
  CreateHastaArsivDetayDto,
  UpdateHastaArsivDetayDto,
  HastaArsivDetayListFilter
> {
  protected apiUrl = 'v1/vem/hasta-arsiv-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
