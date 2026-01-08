import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  IlacUyumDto,
  ListIlacUyumDto,
  CreateIlacUyumDto,
  UpdateIlacUyumDto,
  IlacUyumListFilter
} from '../../models/vem/ilac-uyum.model';

@Injectable({ providedIn: 'root' })
export class IlacUyumService extends BaseVemService<
  IlacUyumDto,
  ListIlacUyumDto,
  CreateIlacUyumDto,
  UpdateIlacUyumDto,
  IlacUyumListFilter
> {
  protected apiUrl = 'v1/vem/ilac-uyum';

  constructor(http: HttpService) {
    super(http);
  }
}
