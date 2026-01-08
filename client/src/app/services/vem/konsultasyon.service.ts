import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KonsultasyonDto,
  ListKonsultasyonDto,
  CreateKonsultasyonDto,
  UpdateKonsultasyonDto,
  KonsultasyonListFilter
} from '../../models/vem/konsultasyon.model';

@Injectable({ providedIn: 'root' })
export class KonsultasyonService extends BaseVemService<
  KonsultasyonDto,
  ListKonsultasyonDto,
  CreateKonsultasyonDto,
  UpdateKonsultasyonDto,
  KonsultasyonListFilter
> {
  protected apiUrl = 'v1/vem/konsultasyon';

  constructor(http: HttpService) {
    super(http);
  }
}
