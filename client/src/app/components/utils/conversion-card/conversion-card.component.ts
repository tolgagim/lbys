import {
  Component, NgModule, Input,
} from '@angular/core';
import { CommonModule } from '@angular/common';

import { DxFunnelModule } from 'devextreme-angular/ui/funnel';
import { SalesOrOpportunitiesByCategory } from 'src/app/types/analytics';
import { CardAnalyticsComponent } from '../../library/card-analytics/card-analytics.component';

@Component({
    selector: 'conversion-card',
    templateUrl: 'conversion-card.component.html',
    standalone: true,
    imports: [CardAnalyticsComponent, DxFunnelModule],
})
export class ConversionCardComponent {
  @Input() data: SalesOrOpportunitiesByCategory;

  customizeOppText(arg: { valueText: string }) {
    return `$${arg.valueText}`;
  }
}


