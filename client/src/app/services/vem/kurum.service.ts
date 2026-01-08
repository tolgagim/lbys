import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KurumDto,
  ListKurumDto,
  CreateKurumDto,
  UpdateKurumDto,
  KurumListFilter
} from '../../models/vem/kurum.model';

@Injectable({ providedIn: 'root' })
export class KurumService extends BaseVemService<
  KurumDto,
  ListKurumDto,
  CreateKurumDto,
  UpdateKurumDto,
  KurumListFilter
> {
  protected apiUrl = 'v1/vem/kurum';

  constructor(http: HttpService) {
    super(http);
  }
}
