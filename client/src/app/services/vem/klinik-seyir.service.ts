import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KlinikSeyirDto,
  ListKlinikSeyirDto,
  CreateKlinikSeyirDto,
  UpdateKlinikSeyirDto,
  KlinikSeyirListFilter
} from '../../models/vem/klinik-seyir.model';

@Injectable({ providedIn: 'root' })
export class KlinikSeyirService extends BaseVemService<
  KlinikSeyirDto,
  ListKlinikSeyirDto,
  CreateKlinikSeyirDto,
  UpdateKlinikSeyirDto,
  KlinikSeyirListFilter
> {
  protected apiUrl = 'v1/vem/klinik-seyir';

  constructor(http: HttpService) {
    super(http);
  }
}
