import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  StokIstekDto,
  ListStokIstekDto,
  CreateStokIstekDto,
  UpdateStokIstekDto,
  StokIstekListFilter
} from '../../models/vem/stok-istek.model';

@Injectable({ providedIn: 'root' })
export class StokIstekService extends BaseVemService<
  StokIstekDto,
  ListStokIstekDto,
  CreateStokIstekDto,
  UpdateStokIstekDto,
  StokIstekListFilter
> {
  protected apiUrl = 'v1/vem/stok-istek';

  constructor(http: HttpService) {
    super(http);
  }
}
