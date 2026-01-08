import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  BinaDto,
  ListBinaDto,
  CreateBinaDto,
  UpdateBinaDto,
  BinaListFilter
} from '../../models/vem/bina.model';

@Injectable({ providedIn: 'root' })
export class BinaService extends BaseVemService<
  BinaDto,
  ListBinaDto,
  CreateBinaDto,
  UpdateBinaDto,
  BinaListFilter
> {
  protected apiUrl = 'v1/vem/bina';

  constructor(http: HttpService) {
    super(http);
  }
}
