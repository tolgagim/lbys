import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaIletisimDto,
  ListHastaIletisimDto,
  CreateHastaIletisimDto,
  UpdateHastaIletisimDto,
  HastaIletisimListFilter
} from '../../models/vem/hasta-iletisim.model';

@Injectable({ providedIn: 'root' })
export class HastaIletisimService extends BaseVemService<
  HastaIletisimDto,
  ListHastaIletisimDto,
  CreateHastaIletisimDto,
  UpdateHastaIletisimDto,
  HastaIletisimListFilter
> {
  protected apiUrl = 'v1/vem/hasta-iletisim';

  constructor(http: HttpService) {
    super(http);
  }
}
