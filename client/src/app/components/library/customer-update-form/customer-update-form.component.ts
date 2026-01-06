

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
import { newData, UpdateCustomerRequest } from 'src/app/models/customer/updateCustomerRequest';
import { CustomerDetailsDto } from 'src/app/models/customer/CustomerDetailsDto';
import { CustomerService } from 'src/app/pages/customers/customer.service';


@Component({
  selector: 'customer-update-form',
  standalone: true,
  templateUrl: './customer-update-form.component.html',
  styleUrl: './customer-update-form.component.scss',
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
export class CustomerUpdateFormComponent {
  @ViewChild('confirmField', { static: true }) confirmField: PasswordTextBoxComponent;
  @ViewChild(FormPopupComponent, { static: true }) formPopup;

  @Input() set updateCustomerData(data: CustomerDetailsDto) {
    if (data !== undefined) {
      this.updateCustomer = data;
    }
  }
  private _customerId: string;

  @Input() 
  set customerId(data: string) {
    this._customerId = data; 
  }

 
  isSaveDisabled = true;
  updateCustomer = newData;
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


  constructor(private translate: TranslateService, private customerService: CustomerService) { }




  async onFieldChanged() {
    const formValues = Object.entries(this.updateCustomer);
    this.isSaveDisabled = await (formValues.length != 3 || !!formValues.find(([_, value]) => !value) || !this.formPopup.isValid());
  }

  checkConfirm(): void {
    this.confirmField.revalidate();
  }

  onNewPasswordChanged() {
    this.checkConfirm();
    this.onFieldChanged();
  }

  getNewCustomerData = () => ({ ...this.updateCustomer })


  async setSavedData(data = this.updateCustomer) {


    const updateUserRequest: UpdateCustomerRequest = {
      id: data.id,
      name: data.name,
      description: data.description,
      taxNumber: data.taxNumber,
      taxOffice: data.taxOffice,
      address: data.address,
      phoneNumber: data.phoneNumber,
      mobileNumber: data.mobileNumber,

    };
    await this.customerService.updateCustomer(this._customerId,updateUserRequest);
  }

}
