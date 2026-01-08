import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DisTaahhutDetayDto,
  ListDisTaahhutDetayDto,
  CreateDisTaahhutDetayDto,
  UpdateDisTaahhutDetayDto,
  DisTaahhutDetayListFilter
} from '../../models/vem/dis-taahhut-detay.model';

@Injectable({ providedIn: 'root' })
export class DisTaahhutDetayService extends BaseVemService<
  DisTaahhutDetayDto,
  ListDisTaahhutDetayDto,
  CreateDisTaahhutDetayDto,
  UpdateDisTaahhutDetayDto,
  DisTaahhutDetayListFilter
> {
  protected apiUrl = 'v1/vem/dis-taahhut-detay';

  constructor(http: HttpService) {
    super(http);
  }
}
