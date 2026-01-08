import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  SilinenKayitlarDto,
  ListSilinenKayitlarDto,
  CreateSilinenKayitlarDto,
  UpdateSilinenKayitlarDto,
  SilinenKayitlarListFilter
} from '../../models/vem/silinen-kayitlar.model';

@Injectable({ providedIn: 'root' })
export class SilinenKayitlarService extends BaseVemService<
  SilinenKayitlarDto,
  ListSilinenKayitlarDto,
  CreateSilinenKayitlarDto,
  UpdateSilinenKayitlarDto,
  SilinenKayitlarListFilter
> {
  protected apiUrl = 'v1/vem/silinen-kayitlar';

  constructor(http: HttpService) {
    super(http);
  }
}
