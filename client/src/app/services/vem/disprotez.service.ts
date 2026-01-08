import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DisprotezDto,
  ListDisprotezDto,
  CreateDisprotezDto,
  UpdateDisprotezDto,
  DisprotezListFilter
} from '../../models/vem/disprotez.model';

@Injectable({ providedIn: 'root' })
export class DisprotezService extends BaseVemService<
  DisprotezDto,
  ListDisprotezDto,
  CreateDisprotezDto,
  UpdateDisprotezDto,
  DisprotezListFilter
> {
  protected apiUrl = 'v1/vem/disprotez';

  constructor(http: HttpService) {
    super(http);
  }
}
