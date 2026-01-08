import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KanUrunImhaDto,
  ListKanUrunImhaDto,
  CreateKanUrunImhaDto,
  UpdateKanUrunImhaDto,
  KanUrunImhaListFilter
} from '../../models/vem/kan-urun-imha.model';

@Injectable({ providedIn: 'root' })
export class KanUrunImhaService extends BaseVemService<
  KanUrunImhaDto,
  ListKanUrunImhaDto,
  CreateKanUrunImhaDto,
  UpdateKanUrunImhaDto,
  KanUrunImhaListFilter
> {
  protected apiUrl = 'v1/vem/kan-urun-imha';

  constructor(http: HttpService) {
    super(http);
  }
}
