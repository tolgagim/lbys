import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  FaturaDto,
  ListFaturaDto,
  CreateFaturaDto,
  UpdateFaturaDto,
  FaturaListFilter
} from '../../models/vem/fatura.model';

@Injectable({ providedIn: 'root' })
export class FaturaService extends BaseVemService<
  FaturaDto,
  ListFaturaDto,
  CreateFaturaDto,
  UpdateFaturaDto,
  FaturaListFilter
> {
  protected apiUrl = 'v1/vem/fatura';

  constructor(http: HttpService) {
    super(http);
  }
}
