import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SterilizasyonCikisDto,
  ListSterilizasyonCikisDto,
  CreateSterilizasyonCikisDto,
  UpdateSterilizasyonCikisDto,
  SterilizasyonCikisListFilter
} from '../../models/vem/sterilizasyon-cikis.model';

@Injectable({ providedIn: 'root' })
export class SterilizasyonCikisService extends BaseVemService<
  SterilizasyonCikisDto,
  ListSterilizasyonCikisDto,
  CreateSterilizasyonCikisDto,
  UpdateSterilizasyonCikisDto,
  SterilizasyonCikisListFilter
> {
  protected apiUrl = 'v1/vem/sterilizasyon-cikis';

  constructor(http: HttpService) {
    super(http);
  }
}
