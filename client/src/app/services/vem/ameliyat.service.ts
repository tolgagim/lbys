import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  AmeliyatDto,
  ListAmeliyatDto,
  CreateAmeliyatDto,
  UpdateAmeliyatDto,
  AmeliyatListFilter
} from '../../models/vem/ameliyat.model';

@Injectable({ providedIn: 'root' })
export class AmeliyatService extends BaseVemService<
  AmeliyatDto,
  ListAmeliyatDto,
  CreateAmeliyatDto,
  UpdateAmeliyatDto,
  AmeliyatListFilter
> {
  protected apiUrl = 'v1/vem/ameliyat';

  constructor(http: HttpService) {
    super(http);
  }
}
