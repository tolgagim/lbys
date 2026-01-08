import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaSevkDto,
  ListHastaSevkDto,
  CreateHastaSevkDto,
  UpdateHastaSevkDto,
  HastaSevkListFilter
} from '../../models/vem/hasta-sevk.model';

@Injectable({ providedIn: 'root' })
export class HastaSevkService extends BaseVemService<
  HastaSevkDto,
  ListHastaSevkDto,
  CreateHastaSevkDto,
  UpdateHastaSevkDto,
  HastaSevkListFilter
> {
  protected apiUrl = 'v1/vem/hasta-sevk';

  constructor(http: HttpService) {
    super(http);
  }
}
