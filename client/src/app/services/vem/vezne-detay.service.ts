import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  VezneDetayDto,
  ListVezneDetayDto,
  CreateVezneDetayDto,
  UpdateVezneDetayDto,
  VezneDetayListFilter
} from '../../models/vem/vezne-detay.model';

@Injectable({ providedIn: 'root' })
export class VezneDetayService extends BaseVemService<
  VezneDetayDto,
  ListVezneDetayDto,
  CreateVezneDetayDto,
  UpdateVezneDetayDto,
  VezneDetayListFilter
> {
  protected apiUrl = 'v1/vem/vezne-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
