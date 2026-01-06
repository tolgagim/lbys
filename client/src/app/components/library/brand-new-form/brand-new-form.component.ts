import {
  Component,
  Input,
  ViewChild,
} from '@angular/core'; 
 
import { getSizeQualifier } from 'src/app/services/screen.service';
import { FormTextboxComponent } from '../../utils/form-textbox/form-textbox.component';
import { FormPhotoUploaderComponent } from '../../utils/form-photo-uploader/form-photo-uploader.component';
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxiItemModule, DxoColCountByScreenModule } from 'devextreme-angular/ui/nested';
import { DxFormModule as DxFormModule_1 } from 'devextreme-angular/ui/form'; 
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { CommonModule } from '@angular/common';
import { EmailPipe } from "../../../pipes/email.pipe";
import { PasswordTextBoxComponent } from '../password-text-box/password-text-box.component';
import { FormPopupComponent } from '../../utils/form-popup/form-popup.component';
import { ValidationRule } from 'devextreme-angular/common';  
import { CreateBrandRequest, newData } from 'src/app/models/brand/createBrandRequest';

@Component({
    selector: 'brand-new-form',
    standalone: true,
     templateUrl: './brand-new-form.component.html',
     styleUrl: './brand-new-form.component.scss',
    imports: [
        DxFormModule_1,
        DxiItemModule,
        DxoColCountByScreenModule,
        DxTemplateModule,
        FormPhotoUploaderComponent,
        FormTextboxComponent,
        TranslateModule,
        CommonModule,
        EmailPipe,
        PasswordTextBoxComponent
    ]
})
export class BrandNewFormComponent {
  @ViewChild('confirmField', { static: true }) confirmField: PasswordTextBoxComponent;
  @ViewChild(FormPopupComponent, { static: true }) formPopup;

  @Input() set newBrandData(data: CreateBrandRequest) {
    if(data!==undefined){
      this.newBrand = data; 
    } 
  }
 

  isSaveDisabled = true;
  newBrand =  newData;
  emailEntered = false;
  isValidEmail = true;   
  getSizeQualifier = getSizeQualifier;

   

  minLengthValidator: ValidationRule[] = [
    {
      type: 'stringLength',
      message: this.translate.instant('Users.MinLengthValidator'),
      min: 4,
    },
  ];
  

  constructor(private translate: TranslateService) {}

  
 

  async onFieldChanged() {
    const formValues = Object.entries(this.newBrand);
    this.isSaveDisabled =  await (formValues.length != 3 || !!formValues.find(([_, value]) => !value) || !this.formPopup.isValid());
  }

  checkConfirm(): void {
    this.confirmField.revalidate();
  }

  
  
  getNewBrandData = ()=> ({ ...this.newBrand }) 
 
  
}
