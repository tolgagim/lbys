import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KanTalepDetayDto,
  ListKanTalepDetayDto,
  CreateKanTalepDetayDto,
  UpdateKanTalepDetayDto,
  KanTalepDetayListFilter
} from '../../models/vem/kan-talep-detay.model';

@Injectable({ providedIn: 'root' })
export class KanTalepDetayService extends BaseVemService<
  KanTalepDetayDto,
  ListKanTalepDetayDto,
  CreateKanTalepDetayDto,
  UpdateKanTalepDetayDto,
  KanTalepDetayListFilter
> {
  protected apiUrl = 'v1/vem/kan-talep-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
