import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  BasvuruYemekDto,
  ListBasvuruYemekDto,
  CreateBasvuruYemekDto,
  UpdateBasvuruYemekDto,
  BasvuruYemekListFilter
} from '../../models/vem/basvuru-yemek.model';

@Injectable({ providedIn: 'root' })
export class BasvuruYemekService extends BaseVemService<
  BasvuruYemekDto,
  ListBasvuruYemekDto,
  CreateBasvuruYemekDto,
  UpdateBasvuruYemekDto,
  BasvuruYemekListFilter
> {
  protected apiUrl = 'v1/vem/basvuru-yemek';

  constructor(http: HttpService) {
    super(http);
  }
}
