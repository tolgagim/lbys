import {
  Component, NgModule,
} from '@angular/core';
import { CommonModule } from '@angular/common';

import { TickerCardComponent } from '../../library/ticker-card/ticker-card.component';

@Component({
    selector: 'leads-ticker',
    templateUrl: 'leads-ticker.component.html',
    standalone: true,
    imports: [TickerCardComponent],
})

export class LeadsTickerComponent {
}


