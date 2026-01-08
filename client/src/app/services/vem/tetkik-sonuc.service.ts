import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  TetkikSonucDto,
  ListTetkikSonucDto,
  CreateTetkikSonucDto,
  UpdateTetkikSonucDto,
  TetkikSonucListFilter
} from '../../models/vem/tetkik-sonuc.model';

@Injectable({ providedIn: 'root' })
export class TetkikSonucService extends BaseVemService<
  TetkikSonucDto,
  ListTetkikSonucDto,
  CreateTetkikSonucDto,
  UpdateTetkikSonucDto,
  TetkikSonucListFilter
> {
  protected apiUrl = 'v1/vem/tetkik-sonuc';

  constructor(http: HttpService) {
    super(http);
  }
}
