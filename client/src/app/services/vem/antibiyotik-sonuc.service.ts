import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  AntibiyotikSonucDto,
  ListAntibiyotikSonucDto,
  CreateAntibiyotikSonucDto,
  UpdateAntibiyotikSonucDto,
  AntibiyotikSonucListFilter
} from '../../models/vem/antibiyotik-sonuc.model';

@Injectable({ providedIn: 'root' })
export class AntibiyotikSonucService extends BaseVemService<
  AntibiyotikSonucDto,
  ListAntibiyotikSonucDto,
  CreateAntibiyotikSonucDto,
  UpdateAntibiyotikSonucDto,
  AntibiyotikSonucListFilter
> {
  protected apiUrl = 'v1/vem/antibiyotik-sonuc';

  constructor(http: HttpService) {
    super(http);
  }
}
