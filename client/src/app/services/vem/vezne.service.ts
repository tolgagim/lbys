import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  VezneDto,
  ListVezneDto,
  CreateVezneDto,
  UpdateVezneDto,
  VezneListFilter
} from '../../models/vem/vezne.model';

@Injectable({ providedIn: 'root' })
export class VezneService extends BaseVemService<
  VezneDto,
  ListVezneDto,
  CreateVezneDto,
  UpdateVezneDto,
  VezneListFilter
> {
  protected apiUrl = 'v1/vem/vezne';

  constructor(http: HttpService) {
    super(http);
  }
}
