import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  BebekCocukIzlemDto,
  ListBebekCocukIzlemDto,
  CreateBebekCocukIzlemDto,
  UpdateBebekCocukIzlemDto,
  BebekCocukIzlemListFilter
} from '../../models/vem/bebek-cocuk-izlem.model';

@Injectable({ providedIn: 'root' })
export class BebekCocukIzlemService extends BaseVemService<
  BebekCocukIzlemDto,
  ListBebekCocukIzlemDto,
  CreateBebekCocukIzlemDto,
  UpdateBebekCocukIzlemDto,
  BebekCocukIzlemListFilter
> {
  protected apiUrl = 'v1/vem/bebek-cocuk-izlem';

  constructor(http: HttpService) {
    super(http);
  }
}
