import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  GebeIzlemDto,
  ListGebeIzlemDto,
  CreateGebeIzlemDto,
  UpdateGebeIzlemDto,
  GebeIzlemListFilter
} from '../../models/vem/gebe-izlem.model';

@Injectable({ providedIn: 'root' })
export class GebeIzlemService extends BaseVemService<
  GebeIzlemDto,
  ListGebeIzlemDto,
  CreateGebeIzlemDto,
  UpdateGebeIzlemDto,
  GebeIzlemListFilter
> {
  protected apiUrl = 'v1/vem/gebe-izlem';

  constructor(http: HttpService) {
    super(http);
  }
}
