import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  StokKartDto,
  ListStokKartDto,
  CreateStokKartDto,
  UpdateStokKartDto,
  StokKartListFilter
} from '../../models/vem/stok-kart.model';

@Injectable({ providedIn: 'root' })
export class StokKartService extends BaseVemService<
  StokKartDto,
  ListStokKartDto,
  CreateStokKartDto,
  UpdateStokKartDto,
  StokKartListFilter
> {
  protected apiUrl = 'v1/vem/stok-kart';

  constructor(http: HttpService) {
    super(http);
  }
}
