import {
  Component,
  NgModule,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxTextBoxModule, 
  DxFormModule,
  DxValidatorModule,
} from 'devextreme-angular';

import { newContact } from 'src/app/types/contact';
import { getSizeQualifier } from 'src/app/services/screen.service';
import { FormTextboxComponent } from '../../utils/form-textbox/form-textbox.component';
import { FormPhotoUploaderComponent } from '../../utils/form-photo-uploader/form-photo-uploader.component';
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxiItemModule, DxoColCountByScreenModule } from 'devextreme-angular/ui/nested';
import { DxFormModule as DxFormModule_1 } from 'devextreme-angular/ui/form';

@Component({
    selector: 'contact-new-form',
    templateUrl: './contact-new-form.component.html',
    providers: [],
    standalone: true,
    imports: [
        DxFormModule_1,
        DxiItemModule,
        DxoColCountByScreenModule,
        DxTemplateModule,
        FormPhotoUploaderComponent,
        FormTextboxComponent,
    ],
})

export class ContactNewFormComponent {
  newUser = newContact;
  getSizeQualifier = getSizeQualifier;
  constructor() { }

  getNewContactData = ()=> ({ ...this.newUser })
}


