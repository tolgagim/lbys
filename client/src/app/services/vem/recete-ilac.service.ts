import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  ReceteIlacDto,
  ListReceteIlacDto,
  CreateReceteIlacDto,
  UpdateReceteIlacDto,
  ReceteIlacListFilter
} from '../../models/vem/recete-ilac.model';

@Injectable({ providedIn: 'root' })
export class ReceteIlacService extends BaseVemService<
  ReceteIlacDto,
  ListReceteIlacDto,
  CreateReceteIlacDto,
  UpdateReceteIlacDto,
  ReceteIlacListFilter
> {
  protected apiUrl = 'v1/vem/recete-ilac';

  constructor(http: HttpService) {
    super(http);
  }
}
