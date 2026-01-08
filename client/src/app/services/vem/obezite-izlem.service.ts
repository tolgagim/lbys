import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  ObeziteIzlemDto,
  ListObeziteIzlemDto,
  CreateObeziteIzlemDto,
  UpdateObeziteIzlemDto,
  ObeziteIzlemListFilter
} from '../../models/vem/obezite-izlem.model';

@Injectable({ providedIn: 'root' })
export class ObeziteIzlemService extends BaseVemService<
  ObeziteIzlemDto,
  ListObeziteIzlemDto,
  CreateObeziteIzlemDto,
  UpdateObeziteIzlemDto,
  ObeziteIzlemListFilter
> {
  protected apiUrl = 'v1/vem/obezite-izlem';

  constructor(http: HttpService) {
    super(http);
  }
}
