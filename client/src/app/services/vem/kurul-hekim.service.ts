import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KurulHekimDto,
  ListKurulHekimDto,
  CreateKurulHekimDto,
  UpdateKurulHekimDto,
  KurulHekimListFilter
} from '../../models/vem/kurul-hekim.model';

@Injectable({ providedIn: 'root' })
export class KurulHekimService extends BaseVemService<
  KurulHekimDto,
  ListKurulHekimDto,
  CreateKurulHekimDto,
  UpdateKurulHekimDto,
  KurulHekimListFilter
> {
  protected apiUrl = 'v1/vem/kurul-hekim';

  constructor(http: HttpService) {
    super(http);
  }
}
