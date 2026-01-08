import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  IntiharIzlemDto,
  ListIntiharIzlemDto,
  CreateIntiharIzlemDto,
  UpdateIntiharIzlemDto,
  IntiharIzlemListFilter
} from '../../models/vem/intihar-izlem.model';

@Injectable({ providedIn: 'root' })
export class IntiharIzlemService extends BaseVemService<
  IntiharIzlemDto,
  ListIntiharIzlemDto,
  CreateIntiharIzlemDto,
  UpdateIntiharIzlemDto,
  IntiharIzlemListFilter
> {
  protected apiUrl = 'v1/vem/intihar-izlem';

  constructor(http: HttpService) {
    super(http);
  }
}
