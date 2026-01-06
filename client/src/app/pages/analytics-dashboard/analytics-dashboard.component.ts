import {
  Component, OnInit,
} from '@angular/core';
import { map, share } from 'rxjs/operators';
import { Observable, forkJoin } from 'rxjs'; 
import { DxLoadPanelModule } from 'devextreme-angular/ui/load-panel'; 
import { DataService } from 'src/app/services'; 
import { analyticsPanelItems, Dates } from 'src/app/types/resource';
import { Sales, SalesByState, SalesByStateAndCity, SalesOrOpportunitiesByCategory} from 'src/app/types/analytics'; 
import { RevenueSnapshotCardComponent } from '../../components/utils/revenue-snapshot-card/revenue-snapshot-card.component';
import { RevenueAnalysisCardComponent } from '../../components/utils/revenue-analysis-card/revenue-analysis-card.component';
import { ConversionCardComponent } from '../../components/utils/conversion-card/conversion-card.component';
import { RevenueCardComponent } from '../../components/utils/revenue-card/revenue-card.component';
import { LeadsTickerComponent } from '../../components/utils/leads-ticker/leads-ticker.component';
import { ConversionTickerComponent } from '../../components/utils/conversion-ticker/conversion-ticker.component';
import { RevenueTotalTickerComponent } from '../../components/utils/revenue-total-ticker/revenue-total-ticker.component';
import { ToolbarAnalyticsComponent } from '../../components/utils/toolbar-analytics/toolbar-analytics.component';
import { DxScrollViewModule as DxScrollViewModule_1 } from 'devextreme-angular';
import { HttpClientModule } from '@angular/common/http';

type DashboardData = SalesOrOpportunitiesByCategory | Sales | SalesByState | SalesByStateAndCity | null;
type DataLoader = (startDate: string, endDate: string) => Observable<Object>;

@Component({
  templateUrl: './analytics-dashboard.component.html',
  styleUrls: ['./analytics-dashboard.component.scss'],
  providers: [DataService],
  standalone: true,
  imports: [
    DxScrollViewModule_1,
    ToolbarAnalyticsComponent,
    RevenueTotalTickerComponent,
    ConversionTickerComponent,
    LeadsTickerComponent,
    RevenueCardComponent,
    ConversionCardComponent,
    RevenueAnalysisCardComponent,
    RevenueSnapshotCardComponent,
    DxLoadPanelModule,
    HttpClientModule
  ],
})

export class AnalyticsDashboardComponent implements OnInit {
  analyticsPanelItems = analyticsPanelItems;

  opportunities: SalesOrOpportunitiesByCategory = null;
  sales: Sales = null;
  salesByState: SalesByState = null;
  salesByCategory: SalesByStateAndCity = null;

  isLoading: boolean = true;

  constructor(private service: DataService) { }

  selectionChange(dates: Dates) {
    this.loadData(dates.startDate, dates.endDate);
  }

  customizeSaleText(arg: { percentText: string }) {
    return arg.percentText;
  }

  loadData = (startDate: string, endDate: string) => {
    this.isLoading = true;
    const tasks: Observable<object>[] = [
      ['opportunities', this.service.getOpportunitiesByCategory],
      ['sales', this.service.getSales],
      ['salesByCategory', this.service.getSalesByCategory],
      ['salesByState', (startDate: string, endDate: string) => this.service.getSalesByStateAndCity(startDate, endDate).pipe(
        map((data) => this.service.getSalesByState(data))
      )
      ]
    ].map(([dataName, loader]: [string, DataLoader]) => {
      const loaderObservable = loader(startDate, endDate).pipe(share());

      loaderObservable.subscribe((result: DashboardData) => {
        this[dataName] = result;
      });

      return loaderObservable;
    });

    forkJoin(tasks).subscribe(() => {
      this.isLoading = false;
    });
  };

  ngOnInit(): void {
    const [startDate, endDate] = analyticsPanelItems[4].value.split('/');

    this.loadData(startDate, endDate);
  }
}


