import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  CocukDiyabetDto,
  ListCocukDiyabetDto,
  CreateCocukDiyabetDto,
  UpdateCocukDiyabetDto,
  CocukDiyabetListFilter
} from '../../models/vem/cocuk-diyabet.model';

@Injectable({ providedIn: 'root' })
export class CocukDiyabetService extends BaseVemService<
  CocukDiyabetDto,
  ListCocukDiyabetDto,
  CreateCocukDiyabetDto,
  UpdateCocukDiyabetDto,
  CocukDiyabetListFilter
> {
  protected apiUrl = 'v1/vem/cocuk-diyabet';

  constructor(http: HttpService) {
    super(http);
  }
}
