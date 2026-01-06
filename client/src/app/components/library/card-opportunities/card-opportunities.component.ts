import {
  Component, Input, NgModule, OnChanges, SimpleChanges,
} from '@angular/core';
import { CommonModule, NgIf, NgFor } from '@angular/common';
import {
  DxButtonModule,
  DxLoadPanelModule,
} from 'devextreme-angular';
import notify from 'devextreme/ui/notify';
import { Opportunity } from 'src/app/types/opportunities';

import { DxLoadPanelModule as DxLoadPanelModule_1 } from 'devextreme-angular/ui/load-panel';
import { OpportunityTileComponent } from '../../utils/opportunity-tile/opportunity-tile.component';

@Component({
    selector: 'card-opportunities',
    templateUrl: './card-opportunities.component.html',
    styleUrls: ['./card-opportunities.component.scss'],
    standalone: true,
    imports: [
        NgIf,
        DxButtonModule,
        NgFor,
        OpportunityTileComponent,
        DxLoadPanelModule_1,
    ],
})
export class CardOpportunitiesComponent implements OnChanges {
  @Input() openedOpportunities: Opportunity[];

  @Input() closedOpportunities: Opportunity[];

  isLoading = true;

  ngOnChanges(changes: SimpleChanges) {
    const isLoadActive = !changes.openedOpportunities?.currentValue;
    const isLoadClosed = !changes.closedOpportunities?.currentValue;

    this.isLoading = isLoadActive || isLoadClosed;
  }
}


