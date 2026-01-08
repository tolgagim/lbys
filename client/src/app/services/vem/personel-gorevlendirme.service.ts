import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelGorevlendirmeDto,
  ListPersonelGorevlendirmeDto,
  CreatePersonelGorevlendirmeDto,
  UpdatePersonelGorevlendirmeDto,
  PersonelGorevlendirmeListFilter
} from '../../models/vem/personel-gorevlendirme.model';

@Injectable({ providedIn: 'root' })
export class PersonelGorevlendirmeService extends BaseVemService<
  PersonelGorevlendirmeDto,
  ListPersonelGorevlendirmeDto,
  CreatePersonelGorevlendirmeDto,
  UpdatePersonelGorevlendirmeDto,
  PersonelGorevlendirmeListFilter
> {
  protected apiUrl = 'v1/vem/personel-gorevlendirme';

  constructor(http: HttpService) {
    super(http);
  }
}
