import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HizmetDto,
  ListHizmetDto,
  CreateHizmetDto,
  UpdateHizmetDto,
  HizmetListFilter
} from '../../models/vem/hizmet.model';

@Injectable({ providedIn: 'root' })
export class HizmetService extends BaseVemService<
  HizmetDto,
  ListHizmetDto,
  CreateHizmetDto,
  UpdateHizmetDto,
  HizmetListFilter
> {
  protected apiUrl = 'v1/vem/hizmet';

  constructor(http: HttpService) {
    super(http);
  }
}
