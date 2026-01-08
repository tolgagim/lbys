import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  TetkikCihazEslesmeDto,
  ListTetkikCihazEslesmeDto,
  CreateTetkikCihazEslesmeDto,
  UpdateTetkikCihazEslesmeDto,
  TetkikCihazEslesmeListFilter
} from '../../models/vem/tetkik-cihaz-eslesme.model';

@Injectable({ providedIn: 'root' })
export class TetkikCihazEslesmeService extends BaseVemService<
  TetkikCihazEslesmeDto,
  ListTetkikCihazEslesmeDto,
  CreateTetkikCihazEslesmeDto,
  UpdateTetkikCihazEslesmeDto,
  TetkikCihazEslesmeListFilter
> {
  protected apiUrl = 'v1/vem/tetkik-cihaz-eslesme';

  constructor(http: HttpService) {
    super(http);
  }
}
