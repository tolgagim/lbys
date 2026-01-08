import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KanCikisDto,
  ListKanCikisDto,
  CreateKanCikisDto,
  UpdateKanCikisDto,
  KanCikisListFilter
} from '../../models/vem/kan-cikis.model';

@Injectable({ providedIn: 'root' })
export class KanCikisService extends BaseVemService<
  KanCikisDto,
  ListKanCikisDto,
  CreateKanCikisDto,
  UpdateKanCikisDto,
  KanCikisListFilter
> {
  protected apiUrl = 'v1/vem/kan-cikis';

  constructor(http: HttpService) {
    super(http);
  }
}
