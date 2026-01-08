import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PatolojiDto,
  ListPatolojiDto,
  CreatePatolojiDto,
  UpdatePatolojiDto,
  PatolojiListFilter
} from '../../models/vem/patoloji.model';

@Injectable({ providedIn: 'root' })
export class PatolojiService extends BaseVemService<
  PatolojiDto,
  ListPatolojiDto,
  CreatePatolojiDto,
  UpdatePatolojiDto,
  PatolojiListFilter
> {
  protected apiUrl = 'v1/vem/patoloji';

  constructor(http: HttpService) {
    super(http);
  }
}
