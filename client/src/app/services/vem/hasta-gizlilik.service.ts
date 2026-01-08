import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaGizlilikDto,
  ListHastaGizlilikDto,
  CreateHastaGizlilikDto,
  UpdateHastaGizlilikDto,
  HastaGizlilikListFilter
} from '../../models/vem/hasta-gizlilik.model';

@Injectable({ providedIn: 'root' })
export class HastaGizlilikService extends BaseVemService<
  HastaGizlilikDto,
  ListHastaGizlilikDto,
  CreateHastaGizlilikDto,
  UpdateHastaGizlilikDto,
  HastaGizlilikListFilter
> {
  protected apiUrl = 'v1/vem/hasta-gizlilik';

  constructor(http: HttpService) {
    super(http);
  }
}
