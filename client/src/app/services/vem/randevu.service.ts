import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  RandevuDto,
  ListRandevuDto,
  CreateRandevuDto,
  UpdateRandevuDto,
  RandevuListFilter
} from '../../models/vem/randevu.model';

@Injectable({ providedIn: 'root' })
export class RandevuService extends BaseVemService<
  RandevuDto,
  ListRandevuDto,
  CreateRandevuDto,
  UpdateRandevuDto,
  RandevuListFilter
> {
  protected apiUrl = 'v1/vem/randevu';

  constructor(http: HttpService) {
    super(http);
  }
}
