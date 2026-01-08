import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaMalzemeDto,
  ListHastaMalzemeDto,
  CreateHastaMalzemeDto,
  UpdateHastaMalzemeDto,
  HastaMalzemeListFilter
} from '../../models/vem/hasta-malzeme.model';

@Injectable({ providedIn: 'root' })
export class HastaMalzemeService extends BaseVemService<
  HastaMalzemeDto,
  ListHastaMalzemeDto,
  CreateHastaMalzemeDto,
  UpdateHastaMalzemeDto,
  HastaMalzemeListFilter
> {
  protected apiUrl = 'v1/vem/hasta-malzeme';

  constructor(http: HttpService) {
    super(http);
  }
}
