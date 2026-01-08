import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  TetkikNumuneDto,
  ListTetkikNumuneDto,
  CreateTetkikNumuneDto,
  UpdateTetkikNumuneDto,
  TetkikNumuneListFilter
} from '../../models/vem/tetkik-numune.model';

@Injectable({ providedIn: 'root' })
export class TetkikNumuneService extends BaseVemService<
  TetkikNumuneDto,
  ListTetkikNumuneDto,
  CreateTetkikNumuneDto,
  UpdateTetkikNumuneDto,
  TetkikNumuneListFilter
> {
  protected apiUrl = 'v1/vem/tetkik-numune';

  constructor(http: HttpService) {
    super(http);
  }
}
