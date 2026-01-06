 
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
import { newData, UpdateBrandRequest } from 'src/app/models/brand/updateBrandRequest'; 
import { BrandService } from 'src/app/pages/brands/brand.service';
import { BrandDto } from 'src/app/models/brand/brandDto';


@Component({
  selector: 'brand-update-form',
  standalone: true,
  templateUrl: './brand-update-form.component.html',
  styleUrl: './brand-update-form.component.scss',
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
export class BrandUpdateFormComponent {
  @ViewChild('confirmField', { static: true }) confirmField: PasswordTextBoxComponent;
  @ViewChild(FormPopupComponent, { static: true }) formPopup;

  @Input() set updateBrandData(data: BrandDto) {
    if (data !== undefined) {
      this.updateBrand = data;
    }
  }
  private _brandId: string;

  @Input() 
  set brandId(data: string) {
    this._brandId = data; 
  }

 
  isSaveDisabled = true;
  updateBrand = newData;
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


  constructor(private translate: TranslateService, private brandService: BrandService) { }




  async onFieldChanged() {
    const formValues = Object.entries(this.updateBrand);
    this.isSaveDisabled = await (formValues.length != 3 || !!formValues.find(([_, value]) => !value) || !this.formPopup.isValid());
  }

  checkConfirm(): void {
    this.confirmField.revalidate();
  }

  onNewPasswordChanged() {
    this.checkConfirm();
    this.onFieldChanged();
  }

  getNewBrandData = () => ({ ...this.updateBrand })


  async setSavedData(data = this.updateBrand) {


    const updateUserRequest: UpdateBrandRequest = {
      id: data.id,
      name: data.name,
      description: data.description
    };
    await this.brandService.updateBrand(this._brandId,updateUserRequest);
  }

}
