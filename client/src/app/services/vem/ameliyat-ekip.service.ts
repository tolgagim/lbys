import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  AmeliyatEkipDto,
  ListAmeliyatEkipDto,
  CreateAmeliyatEkipDto,
  UpdateAmeliyatEkipDto,
  AmeliyatEkipListFilter
} from '../../models/vem/ameliyat-ekip.model';

@Injectable({ providedIn: 'root' })
export class AmeliyatEkipService extends BaseVemService<
  AmeliyatEkipDto,
  ListAmeliyatEkipDto,
  CreateAmeliyatEkipDto,
  UpdateAmeliyatEkipDto,
  AmeliyatEkipListFilter
> {
  protected apiUrl = 'v1/vem/ameliyat-ekip';

  constructor(http: HttpService) {
    super(http);
  }
}
