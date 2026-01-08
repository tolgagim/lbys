import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelDto,
  ListPersonelDto,
  CreatePersonelDto,
  UpdatePersonelDto,
  PersonelListFilter
} from '../../models/vem/personel.model';

@Injectable({ providedIn: 'root' })
export class PersonelService extends BaseVemService<
  PersonelDto,
  ListPersonelDto,
  CreatePersonelDto,
  UpdatePersonelDto,
  PersonelListFilter
> {
  protected apiUrl = 'v1/vem/personel';

  constructor(http: HttpService) {
    super(http);
  }
}
