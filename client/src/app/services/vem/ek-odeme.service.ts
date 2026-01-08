import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  EkOdemeDto,
  ListEkOdemeDto,
  CreateEkOdemeDto,
  UpdateEkOdemeDto,
  EkOdemeListFilter
} from '../../models/vem/ek-odeme.model';

@Injectable({ providedIn: 'root' })
export class EkOdemeService extends BaseVemService<
  EkOdemeDto,
  ListEkOdemeDto,
  CreateEkOdemeDto,
  UpdateEkOdemeDto,
  EkOdemeListFilter
> {
  protected apiUrl = 'v1/vem/ek-odeme';

  constructor(http: HttpService) {
    super(http);
  }
}
