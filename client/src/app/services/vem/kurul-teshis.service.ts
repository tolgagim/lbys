import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KurulTeshisDto,
  ListKurulTeshisDto,
  CreateKurulTeshisDto,
  UpdateKurulTeshisDto,
  KurulTeshisListFilter
} from '../../models/vem/kurul-teshis.model';

@Injectable({ providedIn: 'root' })
export class KurulTeshisService extends BaseVemService<
  KurulTeshisDto,
  ListKurulTeshisDto,
  CreateKurulTeshisDto,
  UpdateKurulTeshisDto,
  KurulTeshisListFilter
> {
  protected apiUrl = 'v1/vem/kurul-teshis';

  constructor(http: HttpService) {
    super(http);
  }
}
