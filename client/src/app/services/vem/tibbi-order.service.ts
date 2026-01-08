import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  TibbiOrderDto,
  ListTibbiOrderDto,
  CreateTibbiOrderDto,
  UpdateTibbiOrderDto,
  TibbiOrderListFilter
} from '../../models/vem/tibbi-order.model';

@Injectable({ providedIn: 'root' })
export class TibbiOrderService extends BaseVemService<
  TibbiOrderDto,
  ListTibbiOrderDto,
  CreateTibbiOrderDto,
  UpdateTibbiOrderDto,
  TibbiOrderListFilter
> {
  protected apiUrl = 'v1/vem/tibbi-order';

  constructor(http: HttpService) {
    super(http);
  }
}
