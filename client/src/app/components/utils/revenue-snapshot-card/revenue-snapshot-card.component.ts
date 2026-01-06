import {
  Component,
  NgModule,
  Input,
} from '@angular/core';
import { CardAnalyticsComponent } from '../../library/card-analytics/card-analytics.component';
import { DxPieChartModule } from 'devextreme-angular/ui/pie-chart';
import { SalesByStateAndCity } from 'src/app/types/analytics';
import { DxiSeriesModule, DxoLabelModule, DxoFontModule, DxoLegendModule, DxoMarginModule, DxoSizeModule } from 'devextreme-angular/ui/nested';

@Component({
    selector: 'revenue-snapshot-card',
    templateUrl: './revenue-snapshot-card.component.html',
    standalone: true,
    imports: [
        CardAnalyticsComponent,
        DxPieChartModule,
        DxiSeriesModule,
        DxoLabelModule,
        DxoFontModule,
        DxoLegendModule,
        DxoMarginModule,
        DxoSizeModule,
    ],
})
export class RevenueSnapshotCardComponent {
  @Input() data: SalesByStateAndCity;

  customizeSaleText(arg: { percentText: string }) {
    return arg.percentText;
  }
}


