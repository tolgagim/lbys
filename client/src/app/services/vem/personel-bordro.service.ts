import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelBordroDto,
  ListPersonelBordroDto,
  CreatePersonelBordroDto,
  UpdatePersonelBordroDto,
  PersonelBordroListFilter
} from '../../models/vem/personel-bordro.model';

@Injectable({ providedIn: 'root' })
export class PersonelBordroService extends BaseVemService<
  PersonelBordroDto,
  ListPersonelBordroDto,
  CreatePersonelBordroDto,
  UpdatePersonelBordroDto,
  PersonelBordroListFilter
> {
  protected apiUrl = 'v1/vem/personel-bordro';

  constructor(http: HttpService) {
    super(http);
  }
}
