import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  ReceteDto,
  ListReceteDto,
  CreateReceteDto,
  UpdateReceteDto,
  ReceteListFilter
} from '../../models/vem/recete.model';

@Injectable({ providedIn: 'root' })
export class ReceteService extends BaseVemService<
  ReceteDto,
  ListReceteDto,
  CreateReceteDto,
  UpdateReceteDto,
  ReceteListFilter
> {
  protected apiUrl = 'v1/vem/recete';

  constructor(http: HttpService) {
    super(http);
  }
}
