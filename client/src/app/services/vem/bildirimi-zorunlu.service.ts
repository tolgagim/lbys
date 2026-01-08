import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  BildirimiZorunluDto,
  ListBildirimiZorunluDto,
  CreateBildirimiZorunluDto,
  UpdateBildirimiZorunluDto,
  BildirimiZorunluListFilter
} from '../../models/vem/bildirimi-zorunlu.model';

@Injectable({ providedIn: 'root' })
export class BildirimiZorunluService extends BaseVemService<
  BildirimiZorunluDto,
  ListBildirimiZorunluDto,
  CreateBildirimiZorunluDto,
  UpdateBildirimiZorunluDto,
  BildirimiZorunluListFilter
> {
  protected apiUrl = 'v1/vem/bildirimi-zorunlu';

  constructor(http: HttpService) {
    super(http);
  }
}
