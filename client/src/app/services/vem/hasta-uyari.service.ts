import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaUyariDto,
  ListHastaUyariDto,
  CreateHastaUyariDto,
  UpdateHastaUyariDto,
  HastaUyariListFilter
} from '../../models/vem/hasta-uyari.model';

@Injectable({ providedIn: 'root' })
export class HastaUyariService extends BaseVemService<
  HastaUyariDto,
  ListHastaUyariDto,
  CreateHastaUyariDto,
  UpdateHastaUyariDto,
  HastaUyariListFilter
> {
  protected apiUrl = 'v1/vem/hasta-uyari';

  constructor(http: HttpService) {
    super(http);
  }
}
