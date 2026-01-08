import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  EvdeSaglikIzlemDto,
  ListEvdeSaglikIzlemDto,
  CreateEvdeSaglikIzlemDto,
  UpdateEvdeSaglikIzlemDto,
  EvdeSaglikIzlemListFilter
} from '../../models/vem/evde-saglik-izlem.model';

@Injectable({ providedIn: 'root' })
export class EvdeSaglikIzlemService extends BaseVemService<
  EvdeSaglikIzlemDto,
  ListEvdeSaglikIzlemDto,
  CreateEvdeSaglikIzlemDto,
  UpdateEvdeSaglikIzlemDto,
  EvdeSaglikIzlemListFilter
> {
  protected apiUrl = 'v1/vem/evde-saglik-izlem';

  constructor(http: HttpService) {
    super(http);
  }
}
