import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  MedulaTakipDto,
  ListMedulaTakipDto,
  CreateMedulaTakipDto,
  UpdateMedulaTakipDto,
  MedulaTakipListFilter
} from '../../models/vem/medula-takip.model';

@Injectable({ providedIn: 'root' })
export class MedulaTakipService extends BaseVemService<
  MedulaTakipDto,
  ListMedulaTakipDto,
  CreateMedulaTakipDto,
  UpdateMedulaTakipDto,
  MedulaTakipListFilter
> {
  protected apiUrl = 'v1/vem/medula-takip';

  constructor(http: HttpService) {
    super(http);
  }
}
