import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  StokHareketDto,
  ListStokHareketDto,
  CreateStokHareketDto,
  UpdateStokHareketDto,
  StokHareketListFilter
} from '../../models/vem/stok-hareket.model';

@Injectable({ providedIn: 'root' })
export class StokHareketService extends BaseVemService<
  StokHareketDto,
  ListStokHareketDto,
  CreateStokHareketDto,
  UpdateStokHareketDto,
  StokHareketListFilter
> {
  protected apiUrl = 'v1/vem/stok-hareket';

  constructor(http: HttpService) {
    super(http);
  }
}
