import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaNotlariDto,
  ListHastaNotlariDto,
  CreateHastaNotlariDto,
  UpdateHastaNotlariDto,
  HastaNotlariListFilter
} from '../../models/vem/hasta-notlari.model';

@Injectable({ providedIn: 'root' })
export class HastaNotlariService extends BaseVemService<
  HastaNotlariDto,
  ListHastaNotlariDto,
  CreateHastaNotlariDto,
  UpdateHastaNotlariDto,
  HastaNotlariListFilter
> {
  protected apiUrl = 'v1/vem/hasta-notlari';

  constructor(http: HttpService) {
    super(http);
  }
}
