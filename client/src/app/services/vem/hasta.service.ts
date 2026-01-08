import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaDto,
  ListHastaDto,
  CreateHastaDto,
  UpdateHastaDto,
  HastaListFilter
} from '../../models/vem/hasta.model';

@Injectable({ providedIn: 'root' })
export class HastaService extends BaseVemService<
  HastaDto,
  ListHastaDto,
  CreateHastaDto,
  UpdateHastaDto,
  HastaListFilter
> {
  protected apiUrl = 'v1/vem/hasta';

  constructor(http: HttpService) {
    super(http);
  }
}
