import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HemsireBakimDto,
  ListHemsireBakimDto,
  CreateHemsireBakimDto,
  UpdateHemsireBakimDto,
  HemsireBakimListFilter
} from '../../models/vem/hemsire-bakim.model';

@Injectable({ providedIn: 'root' })
export class HemsireBakimService extends BaseVemService<
  HemsireBakimDto,
  ListHemsireBakimDto,
  CreateHemsireBakimDto,
  UpdateHemsireBakimDto,
  HemsireBakimListFilter
> {
  protected apiUrl = 'v1/vem/hemsire-bakim';

  constructor(http: HttpService) {
    super(http);
  }
}
