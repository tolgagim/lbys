import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  NobetciPersonelBilgisiDto,
  ListNobetciPersonelBilgisiDto,
  CreateNobetciPersonelBilgisiDto,
  UpdateNobetciPersonelBilgisiDto,
  NobetciPersonelBilgisiListFilter
} from '../../models/vem/nobetci-personel-bilgisi.model';

@Injectable({ providedIn: 'root' })
export class NobetciPersonelBilgisiService extends BaseVemService<
  NobetciPersonelBilgisiDto,
  ListNobetciPersonelBilgisiDto,
  CreateNobetciPersonelBilgisiDto,
  UpdateNobetciPersonelBilgisiDto,
  NobetciPersonelBilgisiListFilter
> {
  protected apiUrl = 'v1/vem/nobetci-personel-bilgisi';

  constructor(http: HttpService) {
    super(http);
  }
}
