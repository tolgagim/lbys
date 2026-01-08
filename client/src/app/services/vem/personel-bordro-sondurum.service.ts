import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  PersonelBordroSondurumDto,
  ListPersonelBordroSondurumDto,
  CreatePersonelBordroSondurumDto,
  UpdatePersonelBordroSondurumDto,
  PersonelBordroSondurumListFilter
} from '../../models/vem/personel-bordro-sondurum.model';

@Injectable({ providedIn: 'root' })
export class PersonelBordroSondurumService extends BaseVemService<
  PersonelBordroSondurumDto,
  ListPersonelBordroSondurumDto,
  CreatePersonelBordroSondurumDto,
  UpdatePersonelBordroSondurumDto,
  PersonelBordroSondurumListFilter
> {
  protected apiUrl = 'v1/vem/personel-bordro-sondurum';

  constructor(http: HttpService) {
    super(http);
  }
}
