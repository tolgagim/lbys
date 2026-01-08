import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaArsivDto,
  ListHastaArsivDto,
  CreateHastaArsivDto,
  UpdateHastaArsivDto,
  HastaArsivListFilter
} from '../../models/vem/hasta-arsiv.model';

@Injectable({ providedIn: 'root' })
export class HastaArsivService extends BaseVemService<
  HastaArsivDto,
  ListHastaArsivDto,
  CreateHastaArsivDto,
  UpdateHastaArsivDto,
  HastaArsivListFilter
> {
  protected apiUrl = 'v1/vem/hasta-arsiv';

  constructor(http: HttpService) {
    super(http);
  }
}
