
import {Component, EventEmitter, Input, NgModule, Output, ViewChild} from '@angular/core';
import { DxFormModule } from 'devextreme-angular/ui/form';
import { FormPopupComponent } from 'src/app/components/utils/form-popup/form-popup.component';
import { PasswordTextBoxComponent } from 'src/app/components/library/password-text-box/password-text-box.component';

import { ValidationRule } from 'devextreme-angular/common';
import { PasswordTextBoxComponent as PasswordTextBoxComponent_1 } from '../password-text-box/password-text-box.component';
import { DxiItemModule, DxoLabelModule } from 'devextreme-angular/ui/nested';
import { FormPopupComponent as FormPopupComponent_1 } from '../../utils/form-popup/form-popup.component';
import { UserService } from 'src/app/pages/users/user.service';
import { TranslateModule } from '@ngx-translate/core';

@Component({
    selector: 'change-profile-password-form',
    templateUrl: './change-profile-password-form.component.html',
    styleUrls: ['./change-profile-password-form.component.scss'],
    standalone: true,
    imports: [FormPopupComponent_1, DxFormModule, DxiItemModule, DxoLabelModule, PasswordTextBoxComponent_1,TranslateModule]
})
export class ChangeProfilePasswordFormComponent {
  @ViewChild(FormPopupComponent, { static: true }) formPopup;

  @ViewChild('confirmField', { static: true }) confirmField: PasswordTextBoxComponent;

  @Input() visible = false;

  @Output() visibleChange = new EventEmitter<boolean>();

  isSaveDisabled = true;

  formData: Record<string, any> = {};

  confirmPasswordValidators: ValidationRule[] = [
    {
      type: 'compare',
      message: 'Passwords do not match',
      comparisonTarget: () => this.formData.password,
    },
  ];

  constructor(
    private userServices: UserService) {

   
  }

 

  async onFieldChanged() {
    const formValues = Object.entries(this.formData);
    const allFieldsFilled = formValues.length === 3 && !formValues.find(([_, value]) => !value);
    const formIsValid = this.formPopup.isValid();

    this.isSaveDisabled = !(allFieldsFilled && formIsValid);
  }


  async saveNewPassword(): Promise<void> { 
    await this.userServices.changePassword(this.formData['currentPassword'],this.formData['password'],this.formData['confirmedPassword']);  
  }

  checkConfirm(): void {
    this.confirmField.revalidate();
  }

  onNewPasswordChanged() {
    this.checkConfirm();
    this.onFieldChanged();
  }

  changeVisible(visible: boolean): void {
    this.visible = visible;
    this.visibleChange.emit(this.visible);
  }
}


