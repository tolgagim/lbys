 
 
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
import { CreateCustomerWithUserRequest,newData } from 'src/app/models/customer/createCustomerWithUserRequest .ts';

@Component({
    selector: 'customer-new-form',
    standalone: true,
     templateUrl: './customer-new-form.component.html',
     styleUrl: './customer-new-form.component.scss',
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
export class CustomerNewFormComponent {
  @ViewChild('confirmField', { static: true }) confirmField: PasswordTextBoxComponent;
  @ViewChild(FormPopupComponent, { static: true }) formPopup;

  @Input() set newCustomerData(data: CreateCustomerWithUserRequest) {
    if(data!==undefined){
      this.newCustomer = data; 
    } 
  }
 

  isSaveDisabled = true;
  newCustomer =  newData;
  emailEntered = false;
  isValidEmail = true;   
  getSizeQualifier = getSizeQualifier;

  confirmPasswordValidators: ValidationRule[] = [
    {
      type: 'compare',
      message: this.translate.instant('Users.PasswordMatch'),
      comparisonTarget: () => this.newCustomer.UserPassword,
    },
  ];

  confirmEmailValidators: ValidationRule[] = [
    {
      type: 'email',
      message: this.translate.instant('Users.EmailValidation'),
    },
  ];

  minLengthValidator: ValidationRule[] = [
    {
      type: 'stringLength',
      message: this.translate.instant('Users.MinLengthValidator'),
      min: 4,
    },
  ];
  

  constructor(private translate: TranslateService) {}

  
 

  async onFieldChanged() {
    const formValues = Object.entries(this.newCustomer);
    this.isSaveDisabled =  await (formValues.length != 3 || !!formValues.find(([_, value]) => !value) || !this.formPopup.isValid());
  }

  checkConfirm(): void {
    this.confirmField.revalidate();
  }

  onNewPasswordChanged() {
    this.checkConfirm();
    this.onFieldChanged();
  }
  
  getNewCustomerData = ()=> ({ ...this.newCustomer }) 
 
  
}
