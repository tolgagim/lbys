import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SysPaketDto,
  ListSysPaketDto,
  CreateSysPaketDto,
  UpdateSysPaketDto,
  SysPaketListFilter
} from '../../models/vem/sys-paket.model';

@Injectable({ providedIn: 'root' })
export class SysPaketService extends BaseVemService<
  SysPaketDto,
  ListSysPaketDto,
  CreateSysPaketDto,
  UpdateSysPaketDto,
  SysPaketListFilter
> {
  protected apiUrl = 'v1/vem/sys-paket';

  constructor(http: HttpService) {
    super(http);
  }
}
