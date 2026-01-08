import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KuduzIzlemDto,
  ListKuduzIzlemDto,
  CreateKuduzIzlemDto,
  UpdateKuduzIzlemDto,
  KuduzIzlemListFilter
} from '../../models/vem/kuduz-izlem.model';

@Injectable({ providedIn: 'root' })
export class KuduzIzlemService extends BaseVemService<
  KuduzIzlemDto,
  ListKuduzIzlemDto,
  CreateKuduzIzlemDto,
  UpdateKuduzIzlemDto,
  KuduzIzlemListFilter
> {
  protected apiUrl = 'v1/vem/kuduz-izlem';

  constructor(http: HttpService) {
    super(http);
  }
}
