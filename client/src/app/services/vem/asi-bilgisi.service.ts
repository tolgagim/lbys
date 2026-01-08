import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  AsiBilgisiDto,
  ListAsiBilgisiDto,
  CreateAsiBilgisiDto,
  UpdateAsiBilgisiDto,
  AsiBilgisiListFilter
} from '../../models/vem/asi-bilgisi.model';

@Injectable({ providedIn: 'root' })
export class AsiBilgisiService extends BaseVemService<
  AsiBilgisiDto,
  ListAsiBilgisiDto,
  CreateAsiBilgisiDto,
  UpdateAsiBilgisiDto,
  AsiBilgisiListFilter
> {
  protected apiUrl = 'v1/vem/asi-bilgisi';

  constructor(http: HttpService) {
    super(http);
  }
}
