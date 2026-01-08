import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaOlumDto,
  ListHastaOlumDto,
  CreateHastaOlumDto,
  UpdateHastaOlumDto,
  HastaOlumListFilter
} from '../../models/vem/hasta-olum.model';

@Injectable({ providedIn: 'root' })
export class HastaOlumService extends BaseVemService<
  HastaOlumDto,
  ListHastaOlumDto,
  CreateHastaOlumDto,
  UpdateHastaOlumDto,
  HastaOlumListFilter
> {
  protected apiUrl = 'v1/vem/hasta-olum';

  constructor(http: HttpService) {
    super(http);
  }
}
