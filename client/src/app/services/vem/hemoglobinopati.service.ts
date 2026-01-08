import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HemoglobinopatiDto,
  ListHemoglobinopatiDto,
  CreateHemoglobinopatiDto,
  UpdateHemoglobinopatiDto,
  HemoglobinopatiListFilter
} from '../../models/vem/hemoglobinopati.model';

@Injectable({ providedIn: 'root' })
export class HemoglobinopatiService extends BaseVemService<
  HemoglobinopatiDto,
  ListHemoglobinopatiDto,
  CreateHemoglobinopatiDto,
  UpdateHemoglobinopatiDto,
  HemoglobinopatiListFilter
> {
  protected apiUrl = 'v1/vem/hemoglobinopati';

  constructor(http: HttpService) {
    super(http);
  }
}
