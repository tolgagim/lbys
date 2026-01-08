import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DogumDto,
  ListDogumDto,
  CreateDogumDto,
  UpdateDogumDto,
  DogumListFilter
} from '../../models/vem/dogum.model';

@Injectable({ providedIn: 'root' })
export class DogumService extends BaseVemService<
  DogumDto,
  ListDogumDto,
  CreateDogumDto,
  UpdateDogumDto,
  DogumListFilter
> {
  protected apiUrl = 'v1/vem/dogum';

  constructor(http: HttpService) {
    super(http);
  }
}
