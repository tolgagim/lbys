import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  ReceteIlacAciklamaDto,
  ListReceteIlacAciklamaDto,
  CreateReceteIlacAciklamaDto,
  UpdateReceteIlacAciklamaDto,
  ReceteIlacAciklamaListFilter
} from '../../models/vem/recete-ilac-aciklama.model';

@Injectable({ providedIn: 'root' })
export class ReceteIlacAciklamaService extends BaseVemService<
  ReceteIlacAciklamaDto,
  ListReceteIlacAciklamaDto,
  CreateReceteIlacAciklamaDto,
  UpdateReceteIlacAciklamaDto,
  ReceteIlacAciklamaListFilter
> {
  protected apiUrl = 'v1/vem/recete-ilac-aciklama';

  constructor(http: HttpService) {
    super(http);
  }
}
