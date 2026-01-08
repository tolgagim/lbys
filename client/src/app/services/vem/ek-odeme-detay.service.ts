import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  EkOdemeDetayDto,
  ListEkOdemeDetayDto,
  CreateEkOdemeDetayDto,
  UpdateEkOdemeDetayDto,
  EkOdemeDetayListFilter
} from '../../models/vem/ek-odeme-detay.model';

@Injectable({ providedIn: 'root' })
export class EkOdemeDetayService extends BaseVemService<
  EkOdemeDetayDto,
  ListEkOdemeDetayDto,
  CreateEkOdemeDetayDto,
  UpdateEkOdemeDetayDto,
  EkOdemeDetayListFilter
> {
  protected apiUrl = 'v1/vem/ek-odeme-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
