import {Component, EventEmitter, Input, NgModule, Output, ViewChild} from '@angular/core';
import { CommonModule, NgFor, NgIf, NgSwitch, NgSwitchCase, AsyncPipe } from '@angular/common';
import {
  DxButtonModule, DxDateBoxModule, DxFormComponent, DxFormModule, DxNumberBoxModule, DxSelectBoxModule,
  DxTextBoxModule, DxToolbarModule,
  DxValidatorModule,
  DxScrollViewModule
} from 'devextreme-angular';




import { ScreenService } from 'src/app/services';

import { getSizeQualifier } from 'src/app/services/screen.service';
import { ApplyPipe } from '../../../pipes/apply.pipe';
import { PicturedItemSelectBoxComponent } from '../pictured-item-select-box/pictured-item-select-box.component';
import { StatusSelectBoxComponent } from '../status-select-box/status-select-box.component';
import { DxiItemModule, DxoLabelModule, DxiValidationRuleModule } from 'devextreme-angular/ui/nested';
import { DxFormModule as DxFormModule_1 } from 'devextreme-angular/ui/form';

type CardData = Record<string, any>;

@Component({
    selector: 'profile-card',
    templateUrl: './profile-card.component.html',
    styleUrls: ['profile-card.component.scss'],
    standalone: true,
    imports: [
        DxFormModule_1,
        NgFor,
        DxiItemModule,
        NgIf,
        DxoLabelModule,
        DxiValidationRuleModule,
        NgSwitch,
        NgSwitchCase,
        DxDateBoxModule,
        StatusSelectBoxComponent,
        PicturedItemSelectBoxComponent, 
        ApplyPipe,
        AsyncPipe,
    ],
})
export class ProfileCardComponent {
  @ViewChild('form', { static: true }) form: DxFormComponent;

  @Input() items: Record<string, any>[] = [];

  @Input() colCount: number = 2;

  @Input() title: string = '';

  @Output() dataChanged = new EventEmitter<any>();

  @Input() cardData: CardData;

  getSizeQualifier = getSizeQualifier;

  assign = Object.assign;

  constructor(public screen: ScreenService) {}

  onFieldChange(fieldName?, value?) {
    const {isValid} = this.form.instance.validate();

    if (!isValid) {
      return;
    }

    if (fieldName) {
      this.cardData[fieldName] = value;
    }

    this.dataChanged.emit(this.cardData);
  }

  getFieldValue(cardData, fieldName) {
    
    return cardData[fieldName];
  }
}


