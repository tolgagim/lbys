import {
  Component, NgModule,
} from '@angular/core';
import { CommonModule } from '@angular/common';

import { TickerCardComponent } from '../../library/ticker-card/ticker-card.component';

@Component({
    selector: 'conversion-ticker',
    templateUrl: 'conversion-ticker.component.html',
    standalone: true,
    imports: [TickerCardComponent],
})

export class ConversionTickerComponent {
}

