import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  RiskSkorlamaDetayDto,
  ListRiskSkorlamaDetayDto,
  CreateRiskSkorlamaDetayDto,
  UpdateRiskSkorlamaDetayDto,
  RiskSkorlamaDetayListFilter
} from '../../models/vem/risk-skorlama-detay.model';

@Injectable({ providedIn: 'root' })
export class RiskSkorlamaDetayService extends BaseVemService<
  RiskSkorlamaDetayDto,
  ListRiskSkorlamaDetayDto,
  CreateRiskSkorlamaDetayDto,
  UpdateRiskSkorlamaDetayDto,
  RiskSkorlamaDetayListFilter
> {
  protected apiUrl = 'v1/vem/risk-skorlama-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
