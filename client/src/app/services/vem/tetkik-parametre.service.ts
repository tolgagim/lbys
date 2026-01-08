import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  TetkikParametreDto,
  ListTetkikParametreDto,
  CreateTetkikParametreDto,
  UpdateTetkikParametreDto,
  TetkikParametreListFilter
} from '../../models/vem/tetkik-parametre.model';

@Injectable({ providedIn: 'root' })
export class TetkikParametreService extends BaseVemService<
  TetkikParametreDto,
  ListTetkikParametreDto,
  CreateTetkikParametreDto,
  UpdateTetkikParametreDto,
  TetkikParametreListFilter
> {
  protected apiUrl = 'v1/vem/tetkik-parametre';

  constructor(http: HttpService) {
    super(http);
  }
}
