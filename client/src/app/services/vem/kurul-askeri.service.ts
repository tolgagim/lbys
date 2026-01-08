import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KurulAskeriDto,
  ListKurulAskeriDto,
  CreateKurulAskeriDto,
  UpdateKurulAskeriDto,
  KurulAskeriListFilter
} from '../../models/vem/kurul-askeri.model';

@Injectable({ providedIn: 'root' })
export class KurulAskeriService extends BaseVemService<
  KurulAskeriDto,
  ListKurulAskeriDto,
  CreateKurulAskeriDto,
  UpdateKurulAskeriDto,
  KurulAskeriListFilter
> {
  protected apiUrl = 'v1/vem/kurul-askeri';

  constructor(http: HttpService) {
    super(http);
  }
}
