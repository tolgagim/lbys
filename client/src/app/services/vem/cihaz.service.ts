import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  CihazDto,
  ListCihazDto,
  CreateCihazDto,
  UpdateCihazDto,
  CihazListFilter
} from '../../models/vem/cihaz.model';

@Injectable({ providedIn: 'root' })
export class CihazService extends BaseVemService<
  CihazDto,
  ListCihazDto,
  CreateCihazDto,
  UpdateCihazDto,
  CihazListFilter
> {
  protected apiUrl = 'v1/vem/cihaz';

  constructor(http: HttpService) {
    super(http);
  }
}
