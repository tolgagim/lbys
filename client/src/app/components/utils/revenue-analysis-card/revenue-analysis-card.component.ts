import {
  Component,
  NgModule,
  Input,
} from '@angular/core';
import { CardAnalyticsComponent } from '../../library/card-analytics/card-analytics.component';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';
import { DxBulletModule } from 'devextreme-angular/ui/bullet';
import { SalesByState } from 'src/app/types/analytics';
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxiColumnModule, DxoTooltipModule, DxoSizeModule } from 'devextreme-angular/ui/nested';
import { DxDataGridModule as DxDataGridModule_1 } from 'devextreme-angular';

@Component({
    selector: 'revenue-analysis-card',
    templateUrl: './revenue-analysis-card.component.html',
    styleUrls: ['./revenue-analysis-card.component.scss'],
    standalone: true,
    imports: [
        CardAnalyticsComponent,
        DxDataGridModule_1,
        DxiColumnModule,
        DxTemplateModule,
        DxBulletModule,
        DxoTooltipModule,
        DxoSizeModule,
    ],
})
export class RevenueAnalysisCardComponent {
  @Input() data: SalesByState;
}

