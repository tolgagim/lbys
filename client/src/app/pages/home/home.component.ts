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
import { UserTickerComponent } from 'src/app/components/utils/user-ticker/user-ticker/user-ticker.component';
import { UserDetailsDto } from 'src/app/models/user/userDetailsDto';
import { DashBoardService } from 'src/app/services/dashboard.service';

type DashboardData = SalesOrOpportunitiesByCategory | Sales | SalesByState | SalesByStateAndCity | null;
type DataLoader = (startDate: string, endDate: string) => Observable<Object>; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
   styleUrl: './home.component.scss',
  providers: [DataService,DashBoardService],
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
    HttpClientModule,
    UserTickerComponent
  ],
}) 

export class HomeComponent implements OnInit {
  analyticsPanelItems = analyticsPanelItems;

  userCount: string="100 Adet";


  isLoading: boolean = true;

  constructor(private serviceDashBoard: DashBoardService) { }

  selectionChange(dates: Dates) {
     this.loadData(dates.startDate, dates.endDate);
  }

  customizeSaleText(arg: { percentText: string }) {
    return arg.percentText;
  }

  loadData = (startDate: string, endDate: string) => {
    this.isLoading = true;
    // const tasks: Observable<object>[] = [
    //   ['userData', this.service.getOpportunitiesByCategory],
    //   ['sales', this.service.getSales],
    //   ['salesByCategory', this.service.getSalesByCategory],
    //   ['salesByState', (startDate: string, endDate: string) => this.service.getSalesByStateAndCity(startDate, endDate).pipe(map((data) => this.service.getSalesByState(data)))]
    //   ].map(([dataName, loader]: [string, DataLoader]) => {
    //   const loaderObservable = loader(startDate, endDate).pipe(share());

    //   loaderObservable.subscribe((result: DashboardData) => {
    //     this[dataName] = result;
    //   });

    //   return loaderObservable;
    // });

    // forkJoin(tasks).subscribe(() => {
    //   this.isLoading = false;
    // });
  };

  
  async ngOnInit(): Promise<void> {
    const [startDate, endDate] = analyticsPanelItems[4].value.split('/');
    //  this.loadData(startDate, endDate);  
    const data = await this.serviceDashBoard.get();
    this.userCount = data.userCount.toString();


    this.isLoading = false;
  }
}


