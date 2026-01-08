import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  TetkikReferansAralikDto,
  ListTetkikReferansAralikDto,
  CreateTetkikReferansAralikDto,
  UpdateTetkikReferansAralikDto,
  TetkikReferansAralikListFilter
} from '../../models/vem/tetkik-referans-aralik.model';

@Injectable({ providedIn: 'root' })
export class TetkikReferansAralikService extends BaseVemService<
  TetkikReferansAralikDto,
  ListTetkikReferansAralikDto,
  CreateTetkikReferansAralikDto,
  UpdateTetkikReferansAralikDto,
  TetkikReferansAralikListFilter
> {
  protected apiUrl = 'v1/vem/tetkik-referans-aralik';

  constructor(http: HttpService) {
    super(http);
  }
}
