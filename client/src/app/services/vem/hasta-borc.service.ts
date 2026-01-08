import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaBorcDto,
  ListHastaBorcDto,
  CreateHastaBorcDto,
  UpdateHastaBorcDto,
  HastaBorcListFilter
} from '../../models/vem/hasta-borc.model';

@Injectable({ providedIn: 'root' })
export class HastaBorcService extends BaseVemService<
  HastaBorcDto,
  ListHastaBorcDto,
  CreateHastaBorcDto,
  UpdateHastaBorcDto,
  HastaBorcListFilter
> {
  protected apiUrl = 'v1/vem/hasta-borc';

  constructor(http: HttpService) {
    super(http);
  }
}
