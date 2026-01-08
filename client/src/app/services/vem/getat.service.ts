import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  GetatDto,
  ListGetatDto,
  CreateGetatDto,
  UpdateGetatDto,
  GetatListFilter
} from '../../models/vem/getat.model';

@Injectable({ providedIn: 'root' })
export class GetatService extends BaseVemService<
  GetatDto,
  ListGetatDto,
  CreateGetatDto,
  UpdateGetatDto,
  GetatListFilter
> {
  protected apiUrl = 'v1/vem/getat';

  constructor(http: HttpService) {
    super(http);
  }
}
