import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KurulRaporDto,
  ListKurulRaporDto,
  CreateKurulRaporDto,
  UpdateKurulRaporDto,
  KurulRaporListFilter
} from '../../models/vem/kurul-rapor.model';

@Injectable({ providedIn: 'root' })
export class KurulRaporService extends BaseVemService<
  KurulRaporDto,
  ListKurulRaporDto,
  CreateKurulRaporDto,
  UpdateKurulRaporDto,
  KurulRaporListFilter
> {
  protected apiUrl = 'v1/vem/kurul-rapor';

  constructor(http: HttpService) {
    super(http);
  }
}
