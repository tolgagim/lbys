import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  BakteriSonucDto,
  ListBakteriSonucDto,
  CreateBakteriSonucDto,
  UpdateBakteriSonucDto,
  BakteriSonucListFilter
} from '../../models/vem/bakteri-sonuc.model';

@Injectable({ providedIn: 'root' })
export class BakteriSonucService extends BaseVemService<
  BakteriSonucDto,
  ListBakteriSonucDto,
  CreateBakteriSonucDto,
  UpdateBakteriSonucDto,
  BakteriSonucListFilter
> {
  protected apiUrl = 'v1/vem/bakteri-sonuc';

  constructor(http: HttpService) {
    super(http);
  }
}
