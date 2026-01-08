import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  GrupUyelikDto,
  ListGrupUyelikDto,
  CreateGrupUyelikDto,
  UpdateGrupUyelikDto,
  GrupUyelikListFilter
} from '../../models/vem/grup-uyelik.model';

@Injectable({ providedIn: 'root' })
export class GrupUyelikService extends BaseVemService<
  GrupUyelikDto,
  ListGrupUyelikDto,
  CreateGrupUyelikDto,
  UpdateGrupUyelikDto,
  GrupUyelikListFilter
> {
  protected apiUrl = 'v1/vem/grup-uyelik';

  constructor(http: HttpService) {
    super(http);
  }
}
