import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaSeansDto,
  ListHastaSeansDto,
  CreateHastaSeansDto,
  UpdateHastaSeansDto,
  HastaSeansListFilter
} from '../../models/vem/hasta-seans.model';

@Injectable({ providedIn: 'root' })
export class HastaSeansService extends BaseVemService<
  HastaSeansDto,
  ListHastaSeansDto,
  CreateHastaSeansDto,
  UpdateHastaSeansDto,
  HastaSeansListFilter
> {
  protected apiUrl = 'v1/vem/hasta-seans';

  constructor(http: HttpService) {
    super(http);
  }
}
