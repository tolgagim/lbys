import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  DoktorMesajiDto,
  ListDoktorMesajiDto,
  CreateDoktorMesajiDto,
  UpdateDoktorMesajiDto,
  DoktorMesajiListFilter
} from '../../models/vem/doktor-mesaji.model';

@Injectable({ providedIn: 'root' })
export class DoktorMesajiService extends BaseVemService<
  DoktorMesajiDto,
  ListDoktorMesajiDto,
  CreateDoktorMesajiDto,
  UpdateDoktorMesajiDto,
  DoktorMesajiListFilter
> {
  protected apiUrl = 'v1/vem/doktor-mesaji';

  constructor(http: HttpService) {
    super(http);
  }
}
