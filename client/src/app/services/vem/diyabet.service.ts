import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DiyabetDto,
  ListDiyabetDto,
  CreateDiyabetDto,
  UpdateDiyabetDto,
  DiyabetListFilter
} from '../../models/vem/diyabet.model';

@Injectable({ providedIn: 'root' })
export class DiyabetService extends BaseVemService<
  DiyabetDto,
  ListDiyabetDto,
  CreateDiyabetDto,
  UpdateDiyabetDto,
  DiyabetListFilter
> {
  protected apiUrl = 'v1/vem/diyabet';

  constructor(http: HttpService) {
    super(http);
  }
}
