import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  BirimDto,
  ListBirimDto,
  CreateBirimDto,
  UpdateBirimDto,
  BirimListFilter
} from '../../models/vem/birim.model';

@Injectable({ providedIn: 'root' })
export class BirimService extends BaseVemService<
  BirimDto,
  ListBirimDto,
  CreateBirimDto,
  UpdateBirimDto,
  BirimListFilter
> {
  protected apiUrl = 'v1/vem/birim';

  constructor(http: HttpService) {
    super(http);
  }
}
