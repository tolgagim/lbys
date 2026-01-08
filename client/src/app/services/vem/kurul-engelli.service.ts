import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KurulEngelliDto,
  ListKurulEngelliDto,
  CreateKurulEngelliDto,
  UpdateKurulEngelliDto,
  KurulEngelliListFilter
} from '../../models/vem/kurul-engelli.model';

@Injectable({ providedIn: 'root' })
export class KurulEngelliService extends BaseVemService<
  KurulEngelliDto,
  ListKurulEngelliDto,
  CreateKurulEngelliDto,
  UpdateKurulEngelliDto,
  KurulEngelliListFilter
> {
  protected apiUrl = 'v1/vem/kurul-engelli';

  constructor(http: HttpService) {
    super(http);
  }
}
