import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  RiskSkorlamaDto,
  ListRiskSkorlamaDto,
  CreateRiskSkorlamaDto,
  UpdateRiskSkorlamaDto,
  RiskSkorlamaListFilter
} from '../../models/vem/risk-skorlama.model';

@Injectable({ providedIn: 'root' })
export class RiskSkorlamaService extends BaseVemService<
  RiskSkorlamaDto,
  ListRiskSkorlamaDto,
  CreateRiskSkorlamaDto,
  UpdateRiskSkorlamaDto,
  RiskSkorlamaListFilter
> {
  protected apiUrl = 'v1/vem/risk-skorlama';

  constructor(http: HttpService) {
    super(http);
  }
}
