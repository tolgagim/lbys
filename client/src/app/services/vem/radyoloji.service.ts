import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  RadyolojiDto,
  ListRadyolojiDto,
  CreateRadyolojiDto,
  UpdateRadyolojiDto,
  RadyolojiListFilter
} from '../../models/vem/radyoloji.model';

@Injectable({ providedIn: 'root' })
export class RadyolojiService extends BaseVemService<
  RadyolojiDto,
  ListRadyolojiDto,
  CreateRadyolojiDto,
  UpdateRadyolojiDto,
  RadyolojiListFilter
> {
  protected apiUrl = 'v1/vem/radyoloji';

  constructor(http: HttpService) {
    super(http);
  }
}
