import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DepoDto,
  ListDepoDto,
  CreateDepoDto,
  UpdateDepoDto,
  DepoListFilter
} from '../../models/vem/depo.model';

@Injectable({ providedIn: 'root' })
export class DepoService extends BaseVemService<
  DepoDto,
  ListDepoDto,
  CreateDepoDto,
  UpdateDepoDto,
  DepoListFilter
> {
  protected apiUrl = 'v1/vem/depo';

  constructor(http: HttpService) {
    super(http);
  }
}
