import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaHizmetDto,
  ListHastaHizmetDto,
  CreateHastaHizmetDto,
  UpdateHastaHizmetDto,
  HastaHizmetListFilter
} from '../../models/vem/hasta-hizmet.model';

@Injectable({ providedIn: 'root' })
export class HastaHizmetService extends BaseVemService<
  HastaHizmetDto,
  ListHastaHizmetDto,
  CreateHastaHizmetDto,
  UpdateHastaHizmetDto,
  HastaHizmetListFilter
> {
  protected apiUrl = 'v1/vem/hasta-hizmet';

  constructor(http: HttpService) {
    super(http);
  }
}
