import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  AmeliyatIslemDto,
  ListAmeliyatIslemDto,
  CreateAmeliyatIslemDto,
  UpdateAmeliyatIslemDto,
  AmeliyatIslemListFilter
} from '../../models/vem/ameliyat-islem.model';

@Injectable({ providedIn: 'root' })
export class AmeliyatIslemService extends BaseVemService<
  AmeliyatIslemDto,
  ListAmeliyatIslemDto,
  CreateAmeliyatIslemDto,
  UpdateAmeliyatIslemDto,
  AmeliyatIslemListFilter
> {
  protected apiUrl = 'v1/vem/ameliyat-islem';

  constructor(http: HttpService) {
    super(http);
  }
}
