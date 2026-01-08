import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  LohusaIzlemDto,
  ListLohusaIzlemDto,
  CreateLohusaIzlemDto,
  UpdateLohusaIzlemDto,
  LohusaIzlemListFilter
} from '../../models/vem/lohusa-izlem.model';

@Injectable({ providedIn: 'root' })
export class LohusaIzlemService extends BaseVemService<
  LohusaIzlemDto,
  ListLohusaIzlemDto,
  CreateLohusaIzlemDto,
  UpdateLohusaIzlemDto,
  LohusaIzlemListFilter
> {
  protected apiUrl = 'v1/vem/lohusa-izlem';

  constructor(http: HttpService) {
    super(http);
  }
}
