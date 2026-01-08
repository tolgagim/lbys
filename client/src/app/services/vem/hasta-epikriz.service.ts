import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaEpikrizDto,
  ListHastaEpikrizDto,
  CreateHastaEpikrizDto,
  UpdateHastaEpikrizDto,
  HastaEpikrizListFilter
} from '../../models/vem/hasta-epikriz.model';

@Injectable({ providedIn: 'root' })
export class HastaEpikrizService extends BaseVemService<
  HastaEpikrizDto,
  ListHastaEpikrizDto,
  CreateHastaEpikrizDto,
  UpdateHastaEpikrizDto,
  HastaEpikrizListFilter
> {
  protected apiUrl = 'v1/vem/hasta-epikriz';

  constructor(http: HttpService) {
    super(http);
  }
}
