import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaDisDto,
  ListHastaDisDto,
  CreateHastaDisDto,
  UpdateHastaDisDto,
  HastaDisListFilter
} from '../../models/vem/hasta-dis.model';

@Injectable({ providedIn: 'root' })
export class HastaDisService extends BaseVemService<
  HastaDisDto,
  ListHastaDisDto,
  CreateHastaDisDto,
  UpdateHastaDisDto,
  HastaDisListFilter
> {
  protected apiUrl = 'v1/vem/hasta-dis';

  constructor(http: HttpService) {
    super(http);
  }
}
