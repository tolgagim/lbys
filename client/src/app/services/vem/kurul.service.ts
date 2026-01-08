import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KurulDto,
  ListKurulDto,
  CreateKurulDto,
  UpdateKurulDto,
  KurulListFilter
} from '../../models/vem/kurul.model';

@Injectable({ providedIn: 'root' })
export class KurulService extends BaseVemService<
  KurulDto,
  ListKurulDto,
  CreateKurulDto,
  UpdateKurulDto,
  KurulListFilter
> {
  protected apiUrl = 'v1/vem/kurul';

  constructor(http: HttpService) {
    super(http);
  }
}
