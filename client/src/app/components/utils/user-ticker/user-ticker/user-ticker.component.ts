import {
  Component, Input,
} from '@angular/core';
import { TickerCardComponent } from 'src/app/components/library/ticker-card/ticker-card.component'; 

@Component({
  selector: 'user-ticker',
  templateUrl: './user-ticker.component.html',
  standalone: true,
  imports: [TickerCardComponent],
})

export class UserTickerComponent {
  @Input() percentage: number = 0;
  @Input() total: string | null = null;
}


