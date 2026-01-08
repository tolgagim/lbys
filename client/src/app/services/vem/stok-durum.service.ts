import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  StokDurumDto,
  ListStokDurumDto,
  CreateStokDurumDto,
  UpdateStokDurumDto,
  StokDurumListFilter
} from '../../models/vem/stok-durum.model';

@Injectable({ providedIn: 'root' })
export class StokDurumService extends BaseVemService<
  StokDurumDto,
  ListStokDurumDto,
  CreateStokDurumDto,
  UpdateStokDurumDto,
  StokDurumListFilter
> {
  protected apiUrl = 'v1/vem/stok-durum';

  constructor(http: HttpService) {
    super(http);
  }
}
