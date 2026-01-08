import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  StokEhuTakipDto,
  ListStokEhuTakipDto,
  CreateStokEhuTakipDto,
  UpdateStokEhuTakipDto,
  StokEhuTakipListFilter
} from '../../models/vem/stok-ehu-takip.model';

@Injectable({ providedIn: 'root' })
export class StokEhuTakipService extends BaseVemService<
  StokEhuTakipDto,
  ListStokEhuTakipDto,
  CreateStokEhuTakipDto,
  UpdateStokEhuTakipDto,
  StokEhuTakipListFilter
> {
  protected apiUrl = 'v1/vem/stok-ehu-takip';

  constructor(http: HttpService) {
    super(http);
  }
}
