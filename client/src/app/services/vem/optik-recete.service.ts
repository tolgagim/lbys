import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  OptikReceteDto,
  ListOptikReceteDto,
  CreateOptikReceteDto,
  UpdateOptikReceteDto,
  OptikReceteListFilter
} from '../../models/vem/optik-recete.model';

@Injectable({ providedIn: 'root' })
export class OptikReceteService extends BaseVemService<
  OptikReceteDto,
  ListOptikReceteDto,
  CreateOptikReceteDto,
  UpdateOptikReceteDto,
  OptikReceteListFilter
> {
  protected apiUrl = 'v1/vem/optik-recete';

  constructor(http: HttpService) {
    super(http);
  }
}
