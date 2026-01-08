import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaAdliRaporDto,
  ListHastaAdliRaporDto,
  CreateHastaAdliRaporDto,
  UpdateHastaAdliRaporDto,
  HastaAdliRaporListFilter
} from '../../models/vem/hasta-adli-rapor.model';

@Injectable({ providedIn: 'root' })
export class HastaAdliRaporService extends BaseVemService<
  HastaAdliRaporDto,
  ListHastaAdliRaporDto,
  CreateHastaAdliRaporDto,
  UpdateHastaAdliRaporDto,
  HastaAdliRaporListFilter
> {
  protected apiUrl = 'v1/vem/hasta-adli-rapor';

  constructor(http: HttpService) {
    super(http);
  }
}
