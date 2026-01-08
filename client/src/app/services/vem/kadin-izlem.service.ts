import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KadinIzlemDto,
  ListKadinIzlemDto,
  CreateKadinIzlemDto,
  UpdateKadinIzlemDto,
  KadinIzlemListFilter
} from '../../models/vem/kadin-izlem.model';

@Injectable({ providedIn: 'root' })
export class KadinIzlemService extends BaseVemService<
  KadinIzlemDto,
  ListKadinIzlemDto,
  CreateKadinIzlemDto,
  UpdateKadinIzlemDto,
  KadinIzlemListFilter
> {
  protected apiUrl = 'v1/vem/kadin-izlem';

  constructor(http: HttpService) {
    super(http);
  }
}
