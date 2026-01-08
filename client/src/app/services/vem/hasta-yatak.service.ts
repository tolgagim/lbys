import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaYatakDto,
  ListHastaYatakDto,
  CreateHastaYatakDto,
  UpdateHastaYatakDto,
  HastaYatakListFilter
} from '../../models/vem/hasta-yatak.model';

@Injectable({ providedIn: 'root' })
export class HastaYatakService extends BaseVemService<
  HastaYatakDto,
  ListHastaYatakDto,
  CreateHastaYatakDto,
  UpdateHastaYatakDto,
  HastaYatakListFilter
> {
  protected apiUrl = 'v1/vem/hasta-yatak';

  constructor(http: HttpService) {
    super(http);
  }
}
