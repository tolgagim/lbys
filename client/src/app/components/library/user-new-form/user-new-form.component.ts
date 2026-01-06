 
import {
  Component,
  Input,
  ViewChild,
} from '@angular/core';

import { CreateUserRequest, newData } from 'src/app/models/user/createUserRequest';
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

@Component({
    selector: 'user-new-form',
    standalone: true,
    templateUrl: './user-new-form.component.html',
    styleUrl: './user-new-form.component.scss',
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
export class UserNewFormComponent {
  @ViewChild('confirmField', { static: true }) confirmField: PasswordTextBoxComponent;
  @ViewChild(FormPopupComponent, { static: true }) formPopup;

  @Input() set newUserData(data: CreateUserRequest) {
    if(data!==undefined){
      this.newUser = data; 
    } 
  }
 

  isSaveDisabled = true;
  newUser =  newData;
  emailEntered = false;
  isValidEmail = true;   
  getSizeQualifier = getSizeQualifier;

  confirmPasswordValidators: ValidationRule[] = [
    {
      type: 'compare',
      message: this.translate.instant('Users.PasswordMatch'),
      comparisonTarget: () => this.newUser.password,
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

  
  // onEmailChange(email: string) {
  //   this.emailEntered = true; // Email alanından çıkıldığını belirt
  //   setTimeout(() => {
  //     this.isValidEmail = new EmailPipe().transform(email); // Email değerini doğrulav
  //   }, 3000); // 2 saniye beklet
  // }

  async onFieldChanged() {
    const formValues = Object.entries(this.newUser);
    this.isSaveDisabled =  await (formValues.length != 3 || !!formValues.find(([_, value]) => !value) || !this.formPopup.isValid());
  }

  checkConfirm(): void {
    this.confirmField.revalidate();
  }

  onNewPasswordChanged() {
    this.checkConfirm();
    this.onFieldChanged();
  }
  
  getNewUserData = ()=> ({ ...this.newUser }) 
 
  
}
