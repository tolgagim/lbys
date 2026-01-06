import {
  Component, EventEmitter, Input, NgModule, Output,
} from '@angular/core';
import { CommonModule, LowerCasePipe } from '@angular/common';
import { DxSelectBoxModule, DxTextBoxModule } from 'devextreme-angular';
import { EditorStyle } from 'devextreme-angular/common';
import { contactStatusList } from 'src/app/types/contact';

import { ThemeService } from 'src/app/services/theme.service';
import { ContactStatusComponent } from '../../utils/contact-status/contact-status.component';
import { DxTemplateModule } from 'devextreme-angular/core';

@Component({
    selector: 'status-select-box',
    templateUrl: 'status-select-box.component.html',
    styleUrls: ['./status-select-box.component.scss'],
    standalone: true,
    imports: [
        DxSelectBoxModule,
        DxTemplateModule,
        ContactStatusComponent,
        DxTextBoxModule,
        LowerCasePipe,
    ],
})
export class StatusSelectBoxComponent {
  @Input() value: string;

  @Input() label = '';

  @Input() items = contactStatusList;

  @Input() readOnly = false;

  @Input() stylingMode: EditorStyle = 'filled';

  @Input() labelMode: any = this.theme.isFluent() ? 'outside' : undefined;

  @Input() classList;

  @Output() valueChange = new EventEmitter<string>();

  constructor(private theme: ThemeService) {}

}


