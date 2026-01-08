import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelOgrenimDto,
  ListPersonelOgrenimDto,
  CreatePersonelOgrenimDto,
  UpdatePersonelOgrenimDto,
  PersonelOgrenimListFilter
} from '../../models/vem/personel-ogrenim.model';

@Injectable({ providedIn: 'root' })
export class PersonelOgrenimService extends BaseVemService<
  PersonelOgrenimDto,
  ListPersonelOgrenimDto,
  CreatePersonelOgrenimDto,
  UpdatePersonelOgrenimDto,
  PersonelOgrenimListFilter
> {
  protected apiUrl = 'v1/vem/personel-ogrenim';

  constructor(http: HttpService) {
    super(http);
  }
}
