import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  OrtodontiIconSkorDto,
  ListOrtodontiIconSkorDto,
  CreateOrtodontiIconSkorDto,
  UpdateOrtodontiIconSkorDto,
  OrtodontiIconSkorListFilter
} from '../../models/vem/ortodonti-icon-skor.model';

@Injectable({ providedIn: 'root' })
export class OrtodontiIconSkorService extends BaseVemService<
  OrtodontiIconSkorDto,
  ListOrtodontiIconSkorDto,
  CreateOrtodontiIconSkorDto,
  UpdateOrtodontiIconSkorDto,
  OrtodontiIconSkorListFilter
> {
  protected apiUrl = 'v1/vem/ortodonti-icon-skor';

  constructor(http: HttpService) {
    super(http);
  }
}
