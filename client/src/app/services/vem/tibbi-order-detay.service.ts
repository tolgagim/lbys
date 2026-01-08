import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  TibbiOrderDetayDto,
  ListTibbiOrderDetayDto,
  CreateTibbiOrderDetayDto,
  UpdateTibbiOrderDetayDto,
  TibbiOrderDetayListFilter
} from '../../models/vem/tibbi-order-detay.model';

@Injectable({ providedIn: 'root' })
export class TibbiOrderDetayService extends BaseVemService<
  TibbiOrderDetayDto,
  ListTibbiOrderDetayDto,
  CreateTibbiOrderDetayDto,
  UpdateTibbiOrderDetayDto,
  TibbiOrderDetayListFilter
> {
  protected apiUrl = 'v1/vem/tibbi-order-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
