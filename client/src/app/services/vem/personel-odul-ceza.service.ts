import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelOdulCezaDto,
  ListPersonelOdulCezaDto,
  CreatePersonelOdulCezaDto,
  UpdatePersonelOdulCezaDto,
  PersonelOdulCezaListFilter
} from '../../models/vem/personel-odul-ceza.model';

@Injectable({ providedIn: 'root' })
export class PersonelOdulCezaService extends BaseVemService<
  PersonelOdulCezaDto,
  ListPersonelOdulCezaDto,
  CreatePersonelOdulCezaDto,
  UpdatePersonelOdulCezaDto,
  PersonelOdulCezaListFilter
> {
  protected apiUrl = 'v1/vem/personel-odul-ceza';

  constructor(http: HttpService) {
    super(http);
  }
}
