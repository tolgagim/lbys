import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaBasvuruDto,
  ListHastaBasvuruDto,
  CreateHastaBasvuruDto,
  UpdateHastaBasvuruDto,
  HastaBasvuruListFilter
} from '../../models/vem/hasta-basvuru.model';

@Injectable({ providedIn: 'root' })
export class HastaBasvuruService extends BaseVemService<
  HastaBasvuruDto,
  ListHastaBasvuruDto,
  CreateHastaBasvuruDto,
  UpdateHastaBasvuruDto,
  HastaBasvuruListFilter
> {
  protected apiUrl = 'v1/vem/hasta-basvuru';

  constructor(http: HttpService) {
    super(http);
  }
}
