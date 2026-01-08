import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SterilizasyonStokDurumDto,
  ListSterilizasyonStokDurumDto,
  CreateSterilizasyonStokDurumDto,
  UpdateSterilizasyonStokDurumDto,
  SterilizasyonStokDurumListFilter
} from '../../models/vem/sterilizasyon-stok-durum.model';

@Injectable({ providedIn: 'root' })
export class SterilizasyonStokDurumService extends BaseVemService<
  SterilizasyonStokDurumDto,
  ListSterilizasyonStokDurumDto,
  CreateSterilizasyonStokDurumDto,
  UpdateSterilizasyonStokDurumDto,
  SterilizasyonStokDurumListFilter
> {
  protected apiUrl = 'v1/vem/sterilizasyon-stok-durum';

  constructor(http: HttpService) {
    super(http);
  }
}
