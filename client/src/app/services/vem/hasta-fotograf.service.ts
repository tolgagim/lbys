import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaFotografDto,
  ListHastaFotografDto,
  CreateHastaFotografDto,
  UpdateHastaFotografDto,
  HastaFotografListFilter
} from '../../models/vem/hasta-fotograf.model';

@Injectable({ providedIn: 'root' })
export class HastaFotografService extends BaseVemService<
  HastaFotografDto,
  ListHastaFotografDto,
  CreateHastaFotografDto,
  UpdateHastaFotografDto,
  HastaFotografListFilter
> {
  protected apiUrl = 'v1/vem/hasta-fotograf';

  constructor(http: HttpService) {
    super(http);
  }
}
