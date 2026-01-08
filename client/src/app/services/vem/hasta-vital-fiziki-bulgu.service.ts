import { Injectable } from '@angular/core';
import { BaseVemService } from './base-vem.service';
import { HttpService } from '../http.service';
import {
  HastaVitalFizikiBulguDto,
  ListHastaVitalFizikiBulguDto,
  CreateHastaVitalFizikiBulguDto,
  UpdateHastaVitalFizikiBulguDto,
  HastaVitalFizikiBulguListFilter
} from '../../models/vem/hasta-vital-fiziki-bulgu.model';

@Injectable({ providedIn: 'root' })
export class HastaVitalFizikiBulguService extends BaseVemService<
  HastaVitalFizikiBulguDto,
  ListHastaVitalFizikiBulguDto,
  CreateHastaVitalFizikiBulguDto,
  UpdateHastaVitalFizikiBulguDto,
  HastaVitalFizikiBulguListFilter
> {
  protected apiUrl = 'v1/vem/hasta-vital-fiziki-bulgu';

  constructor(http: HttpService) {
    super(http);
  }
}
