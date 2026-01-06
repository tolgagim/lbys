import {
  Component,
  NgModule,
  Input,
  Output,
  EventEmitter,
} from '@angular/core';
import { CardAnalyticsComponent } from '../../library/card-analytics/card-analytics.component';
import { DxChartModule } from 'devextreme-angular/ui/chart';
import { DxDropDownButtonModule } from 'devextreme-angular/ui/drop-down-button';
import { Sale } from 'src/app/types/analytics';
import { DxoArgumentAxisModule, DxoTooltipModule, DxoSeriesTemplateModule, DxoCommonSeriesSettingsModule, DxoPointModule, DxoLegendModule, DxoSizeModule } from 'devextreme-angular/ui/nested';

@Component({
    selector: 'sales-performance-card',
    templateUrl: './sales-performance-card.component.html',
    styleUrls: ['./sales-performance-card.component.scss'],
    standalone: true,
    imports: [
        CardAnalyticsComponent,
        DxDropDownButtonModule,
        DxChartModule,
        DxoArgumentAxisModule,
        DxoTooltipModule,
        DxoSeriesTemplateModule,
        DxoCommonSeriesSettingsModule,
        DxoPointModule,
        DxoLegendModule,
        DxoSizeModule,
    ],
})
export class SalesPerformanceCardComponent {
  @Input() groupByPeriods: string[];

  @Input() salesByDateAndCategory: Sale[];

  @Input() visualRange: unknown = {};

  @Output() performancePeriodChanged = new EventEmitter();

  customiseToolip({ seriesName }) {
    return { text: seriesName };
  }

  onDropDownSelectionChange(event) {
    this.performancePeriodChanged.emit(event);
  }
}


