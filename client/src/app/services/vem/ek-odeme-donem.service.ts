import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  EkOdemeDonemDto,
  ListEkOdemeDonemDto,
  CreateEkOdemeDonemDto,
  UpdateEkOdemeDonemDto,
  EkOdemeDonemListFilter
} from '../../models/vem/ek-odeme-donem.model';

@Injectable({ providedIn: 'root' })
export class EkOdemeDonemService extends BaseVemService<
  EkOdemeDonemDto,
  ListEkOdemeDonemDto,
  CreateEkOdemeDonemDto,
  UpdateEkOdemeDonemDto,
  EkOdemeDonemListFilter
> {
  protected apiUrl = 'v1/vem/ek-odeme-donem';

  constructor(http: HttpService) {
    super(http);
  }
}
