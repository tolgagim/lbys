import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KanUrunDto,
  ListKanUrunDto,
  CreateKanUrunDto,
  UpdateKanUrunDto,
  KanUrunListFilter
} from '../../models/vem/kan-urun.model';

@Injectable({ providedIn: 'root' })
export class KanUrunService extends BaseVemService<
  KanUrunDto,
  ListKanUrunDto,
  CreateKanUrunDto,
  UpdateKanUrunDto,
  KanUrunListFilter
> {
  protected apiUrl = 'v1/vem/kan-urun';

  constructor(http: HttpService) {
    super(http);
  }
}
