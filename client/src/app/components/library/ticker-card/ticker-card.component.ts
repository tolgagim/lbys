import { NgIf, CurrencyPipe } from '@angular/common';
import {
  Component,
  Input
} from '@angular/core';


import { ApplyPipe } from '../../../pipes/apply.pipe'; 
import { StatsDto } from 'src/app/models/statsDto';

@Component({
    selector: 'ticker-card',
    templateUrl: './ticker-card.component.html',
    styleUrls: ['./ticker-card.component.scss'],
    standalone: true,
    imports: [
        NgIf,
        ApplyPipe,
        CurrencyPipe,
    ],
})

export class TickerCardComponent {
  @Input() titleText: string;

  @Input() data: StatsDto | null = null;

  @Input() total: string | null = null;

  @Input() percentage: number;

  @Input() icon: string;

  @Input() tone?: 'warning' | 'info';

  @Input() contentClass: string | null = null;

  getTotal(data: Array<{value?: number, total?: number}> ): number {
    return (data || []).reduce((total, item) => total + (item.value || item.total), 0);
  }

  abs(value: number): number {
    return Math.abs(value);
  }

  getIconClass = () => this.tone || (this.percentage > 0 ? 'positive' : 'negative');
}


