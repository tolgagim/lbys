import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  RadyolojiSonucDto,
  ListRadyolojiSonucDto,
  CreateRadyolojiSonucDto,
  UpdateRadyolojiSonucDto,
  RadyolojiSonucListFilter
} from '../../models/vem/radyoloji-sonuc.model';

@Injectable({ providedIn: 'root' })
export class RadyolojiSonucService extends BaseVemService<
  RadyolojiSonucDto,
  ListRadyolojiSonucDto,
  CreateRadyolojiSonucDto,
  UpdateRadyolojiSonucDto,
  RadyolojiSonucListFilter
> {
  protected apiUrl = 'v1/vem/radyoloji-sonuc';

  constructor(http: HttpService) {
    super(http);
  }
}
