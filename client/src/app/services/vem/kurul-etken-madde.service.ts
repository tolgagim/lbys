import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KurulEtkenMaddeDto,
  ListKurulEtkenMaddeDto,
  CreateKurulEtkenMaddeDto,
  UpdateKurulEtkenMaddeDto,
  KurulEtkenMaddeListFilter
} from '../../models/vem/kurul-etken-madde.model';

@Injectable({ providedIn: 'root' })
export class KurulEtkenMaddeService extends BaseVemService<
  KurulEtkenMaddeDto,
  ListKurulEtkenMaddeDto,
  CreateKurulEtkenMaddeDto,
  UpdateKurulEtkenMaddeDto,
  KurulEtkenMaddeListFilter
> {
  protected apiUrl = 'v1/vem/kurul-etken-madde';

  constructor(http: HttpService) {
    super(http);
  }
}
