import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  ReferansKodlarDto,
  ListReferansKodlarDto,
  CreateReferansKodlarDto,
  UpdateReferansKodlarDto,
  ReferansKodlarListFilter
} from '../../models/vem/referans-kodlar.model';

@Injectable({ providedIn: 'root' })
export class ReferansKodlarService extends BaseVemService<
  ReferansKodlarDto,
  ListReferansKodlarDto,
  CreateReferansKodlarDto,
  UpdateReferansKodlarDto,
  ReferansKodlarListFilter
> {
  protected apiUrl = 'v1/vem/referans-kodlar';

  constructor(http: HttpService) {
    super(http);
  }
}
