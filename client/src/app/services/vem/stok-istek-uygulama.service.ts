import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  StokIstekUygulamaDto,
  ListStokIstekUygulamaDto,
  CreateStokIstekUygulamaDto,
  UpdateStokIstekUygulamaDto,
  StokIstekUygulamaListFilter
} from '../../models/vem/stok-istek-uygulama.model';

@Injectable({ providedIn: 'root' })
export class StokIstekUygulamaService extends BaseVemService<
  StokIstekUygulamaDto,
  ListStokIstekUygulamaDto,
  CreateStokIstekUygulamaDto,
  UpdateStokIstekUygulamaDto,
  StokIstekUygulamaListFilter
> {
  protected apiUrl = 'v1/vem/stok-istek-uygulama';

  constructor(http: HttpService) {
    super(http);
  }
}
