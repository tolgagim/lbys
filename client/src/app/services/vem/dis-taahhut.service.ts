import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DisTaahhutDto,
  ListDisTaahhutDto,
  CreateDisTaahhutDto,
  UpdateDisTaahhutDto,
  DisTaahhutListFilter
} from '../../models/vem/dis-taahhut.model';

@Injectable({ providedIn: 'root' })
export class DisTaahhutService extends BaseVemService<
  DisTaahhutDto,
  ListDisTaahhutDto,
  CreateDisTaahhutDto,
  UpdateDisTaahhutDto,
  DisTaahhutListFilter
> {
  protected apiUrl = 'v1/vem/dis-taahhut';

  constructor(http: HttpService) {
    super(http);
  }
}
