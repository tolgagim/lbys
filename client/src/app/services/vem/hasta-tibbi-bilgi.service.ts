import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaTibbiBilgiDto,
  ListHastaTibbiBilgiDto,
  CreateHastaTibbiBilgiDto,
  UpdateHastaTibbiBilgiDto,
  HastaTibbiBilgiListFilter
} from '../../models/vem/hasta-tibbi-bilgi.model';

@Injectable({ providedIn: 'root' })
export class HastaTibbiBilgiService extends BaseVemService<
  HastaTibbiBilgiDto,
  ListHastaTibbiBilgiDto,
  CreateHastaTibbiBilgiDto,
  UpdateHastaTibbiBilgiDto,
  HastaTibbiBilgiListFilter
> {
  protected apiUrl = 'v1/vem/hasta-tibbi-bilgi';

  constructor(http: HttpService) {
    super(http);
  }
}
