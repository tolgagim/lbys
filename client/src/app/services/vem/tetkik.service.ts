import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  TetkikDto,
  ListTetkikDto,
  CreateTetkikDto,
  UpdateTetkikDto,
  TetkikListFilter
} from '../../models/vem/tetkik.model';

@Injectable({ providedIn: 'root' })
export class TetkikService extends BaseVemService<
  TetkikDto,
  ListTetkikDto,
  CreateTetkikDto,
  UpdateTetkikDto,
  TetkikListFilter
> {
  protected apiUrl = 'v1/vem/tetkik';

  constructor(http: HttpService) {
    super(http);
  }
}
