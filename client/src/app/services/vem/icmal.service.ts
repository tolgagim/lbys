import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  IcmalDto,
  ListIcmalDto,
  CreateIcmalDto,
  UpdateIcmalDto,
  IcmalListFilter
} from '../../models/vem/icmal.model';

@Injectable({ providedIn: 'root' })
export class IcmalService extends BaseVemService<
  IcmalDto,
  ListIcmalDto,
  CreateIcmalDto,
  UpdateIcmalDto,
  IcmalListFilter
> {
  protected apiUrl = 'v1/vem/icmal';

  constructor(http: HttpService) {
    super(http);
  }
}
