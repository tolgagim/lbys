import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DisprotezDetayDto,
  ListDisprotezDetayDto,
  CreateDisprotezDetayDto,
  UpdateDisprotezDetayDto,
  DisprotezDetayListFilter
} from '../../models/vem/disprotez-detay.model';

@Injectable({ providedIn: 'root' })
export class DisprotezDetayService extends BaseVemService<
  DisprotezDetayDto,
  ListDisprotezDetayDto,
  CreateDisprotezDetayDto,
  UpdateDisprotezDetayDto,
  DisprotezDetayListFilter
> {
  protected apiUrl = 'v1/vem/disprotez-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
