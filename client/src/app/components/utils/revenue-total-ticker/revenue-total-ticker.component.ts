import {
  Component, Input,
} from '@angular/core';
import { Sales } from 'src/app/types/analytics';

import { TickerCardComponent } from '../../library/ticker-card/ticker-card.component';

@Component({
    selector: 'revenue-total-ticker',
    templateUrl: 'revenue-total-ticker.component.html',
    standalone: true,
    imports: [TickerCardComponent],
})

export class RevenueTotalTickerComponent {
  @Input() data: Sales = null;
}

