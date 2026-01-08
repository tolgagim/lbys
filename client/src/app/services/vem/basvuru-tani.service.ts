import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  BasvuruTaniDto,
  ListBasvuruTaniDto,
  CreateBasvuruTaniDto,
  UpdateBasvuruTaniDto,
  BasvuruTaniListFilter
} from '../../models/vem/basvuru-tani.model';

@Injectable({ providedIn: 'root' })
export class BasvuruTaniService extends BaseVemService<
  BasvuruTaniDto,
  ListBasvuruTaniDto,
  CreateBasvuruTaniDto,
  UpdateBasvuruTaniDto,
  BasvuruTaniListFilter
> {
  protected apiUrl = 'v1/vem/basvuru-tani';

  constructor(http: HttpService) {
    super(http);
  }
}
