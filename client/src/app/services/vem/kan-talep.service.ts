import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KanTalepDto,
  ListKanTalepDto,
  CreateKanTalepDto,
  UpdateKanTalepDto,
  KanTalepListFilter
} from '../../models/vem/kan-talep.model';

@Injectable({ providedIn: 'root' })
export class KanTalepService extends BaseVemService<
  KanTalepDto,
  ListKanTalepDto,
  CreateKanTalepDto,
  UpdateKanTalepDto,
  KanTalepListFilter
> {
  protected apiUrl = 'v1/vem/kan-talep';

  constructor(http: HttpService) {
    super(http);
  }
}
