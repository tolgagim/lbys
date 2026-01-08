import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DogumDetayDto,
  ListDogumDetayDto,
  CreateDogumDetayDto,
  UpdateDogumDetayDto,
  DogumDetayListFilter
} from '../../models/vem/dogum-detay.model';

@Injectable({ providedIn: 'root' })
export class DogumDetayService extends BaseVemService<
  DogumDetayDto,
  ListDogumDetayDto,
  CreateDogumDetayDto,
  UpdateDogumDetayDto,
  DogumDetayListFilter
> {
  protected apiUrl = 'v1/vem/dogum-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
