import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  OdaDto,
  ListOdaDto,
  CreateOdaDto,
  UpdateOdaDto,
  OdaListFilter
} from '../../models/vem/oda.model';

@Injectable({ providedIn: 'root' })
export class OdaService extends BaseVemService<
  OdaDto,
  ListOdaDto,
  CreateOdaDto,
  UpdateOdaDto,
  OdaListFilter
> {
  protected apiUrl = 'v1/vem/oda';

  constructor(http: HttpService) {
    super(http);
  }
}
