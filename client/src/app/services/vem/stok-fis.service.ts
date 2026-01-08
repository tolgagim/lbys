import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  StokFisDto,
  ListStokFisDto,
  CreateStokFisDto,
  UpdateStokFisDto,
  StokFisListFilter
} from '../../models/vem/stok-fis.model';

@Injectable({ providedIn: 'root' })
export class StokFisService extends BaseVemService<
  StokFisDto,
  ListStokFisDto,
  CreateStokFisDto,
  UpdateStokFisDto,
  StokFisListFilter
> {
  protected apiUrl = 'v1/vem/stok-fis';

  constructor(http: HttpService) {
    super(http);
  }
}
