import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  MaddeBagimliligiDto,
  ListMaddeBagimliligiDto,
  CreateMaddeBagimliligiDto,
  UpdateMaddeBagimliligiDto,
  MaddeBagimliligiListFilter
} from '../../models/vem/madde-bagimliligi.model';

@Injectable({ providedIn: 'root' })
export class MaddeBagimliligiService extends BaseVemService<
  MaddeBagimliligiDto,
  ListMaddeBagimliligiDto,
  CreateMaddeBagimliligiDto,
  UpdateMaddeBagimliligiDto,
  MaddeBagimliligiListFilter
> {
  protected apiUrl = 'v1/vem/madde-bagimliligi';

  constructor(http: HttpService) {
    super(http);
  }
}
