import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  StokIstekHareketDto,
  ListStokIstekHareketDto,
  CreateStokIstekHareketDto,
  UpdateStokIstekHareketDto,
  StokIstekHareketListFilter
} from '../../models/vem/stok-istek-hareket.model';

@Injectable({ providedIn: 'root' })
export class StokIstekHareketService extends BaseVemService<
  StokIstekHareketDto,
  ListStokIstekHareketDto,
  CreateStokIstekHareketDto,
  UpdateStokIstekHareketDto,
  StokIstekHareketListFilter
> {
  protected apiUrl = 'v1/vem/stok-istek-hareket';

  constructor(http: HttpService) {
    super(http);
  }
}
