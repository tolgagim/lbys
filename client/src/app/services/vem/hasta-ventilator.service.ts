import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaVentilatorDto,
  ListHastaVentilatorDto,
  CreateHastaVentilatorDto,
  UpdateHastaVentilatorDto,
  HastaVentilatorListFilter
} from '../../models/vem/hasta-ventilator.model';

@Injectable({ providedIn: 'root' })
export class HastaVentilatorService extends BaseVemService<
  HastaVentilatorDto,
  ListHastaVentilatorDto,
  CreateHastaVentilatorDto,
  UpdateHastaVentilatorDto,
  HastaVentilatorListFilter
> {
  protected apiUrl = 'v1/vem/hasta-ventilator';

  constructor(http: HttpService) {
    super(http);
  }
}
