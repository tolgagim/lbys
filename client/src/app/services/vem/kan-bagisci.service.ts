import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  KanBagisciDto,
  ListKanBagisciDto,
  CreateKanBagisciDto,
  UpdateKanBagisciDto,
  KanBagisciListFilter
} from '../../models/vem/kan-bagisci.model';

@Injectable({ providedIn: 'root' })
export class KanBagisciService extends BaseVemService<
  KanBagisciDto,
  ListKanBagisciDto,
  CreateKanBagisciDto,
  UpdateKanBagisciDto,
  KanBagisciListFilter
> {
  protected apiUrl = 'v1/vem/kan-bagisci';

  constructor(http: HttpService) {
    super(http);
  }
}
