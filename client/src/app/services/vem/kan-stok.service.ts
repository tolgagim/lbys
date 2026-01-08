import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KanStokDto,
  ListKanStokDto,
  CreateKanStokDto,
  UpdateKanStokDto,
  KanStokListFilter
} from '../../models/vem/kan-stok.model';

@Injectable({ providedIn: 'root' })
export class KanStokService extends BaseVemService<
  KanStokDto,
  ListKanStokDto,
  CreateKanStokDto,
  UpdateKanStokDto,
  KanStokListFilter
> {
  protected apiUrl = 'v1/vem/kan-stok';

  constructor(http: HttpService) {
    super(http);
  }
}
