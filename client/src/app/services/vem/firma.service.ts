import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  FirmaDto,
  ListFirmaDto,
  CreateFirmaDto,
  UpdateFirmaDto,
  FirmaListFilter
} from '../../models/vem/firma.model';

@Injectable({ providedIn: 'root' })
export class FirmaService extends BaseVemService<
  FirmaDto,
  ListFirmaDto,
  CreateFirmaDto,
  UpdateFirmaDto,
  FirmaListFilter
> {
  protected apiUrl = 'v1/vem/firma';

  constructor(http: HttpService) {
    super(http);
  }
}
