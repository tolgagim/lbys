import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  AnlikYatanHastaDto,
  ListAnlikYatanHastaDto,
  CreateAnlikYatanHastaDto,
  UpdateAnlikYatanHastaDto,
  AnlikYatanHastaListFilter
} from '../../models/vem/anlik-yatan-hasta.model';

@Injectable({ providedIn: 'root' })
export class AnlikYatanHastaService extends BaseVemService<
  AnlikYatanHastaDto,
  ListAnlikYatanHastaDto,
  CreateAnlikYatanHastaDto,
  UpdateAnlikYatanHastaDto,
  AnlikYatanHastaListFilter
> {
  protected apiUrl = 'v1/vem/anlik-yatan-hasta';

  constructor(http: HttpService) {
    super(http);
  }
}
