import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  YatakDto,
  ListYatakDto,
  CreateYatakDto,
  UpdateYatakDto,
  YatakListFilter
} from '../../models/vem/yatak.model';

@Injectable({ providedIn: 'root' })
export class YatakService extends BaseVemService<
  YatakDto,
  ListYatakDto,
  CreateYatakDto,
  UpdateYatakDto,
  YatakListFilter
> {
  protected apiUrl = 'v1/vem/yatak';

  constructor(http: HttpService) {
    super(http);
  }
}
