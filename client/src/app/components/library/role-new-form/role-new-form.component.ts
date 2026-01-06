import {
  Component,
} from '@angular/core';

import { getSizeQualifier } from 'src/app/services/screen.service';
import { FormTextboxComponent } from '../../utils/form-textbox/form-textbox.component';
import { FormPhotoUploaderComponent } from '../../utils/form-photo-uploader/form-photo-uploader.component';
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxiItemModule, DxoColCountByScreenModule } from 'devextreme-angular/ui/nested';
import { DxFormModule as DxFormModule_1 } from 'devextreme-angular/ui/form';
import { newRole } from 'src/app/models/role/createOrUpdateRole.Request';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'role-new-form',
  standalone: true, 
  templateUrl: './role-new-form.component.html',
  providers: [], 
  imports: [
      DxFormModule_1,
      DxiItemModule,
      DxoColCountByScreenModule,
      DxTemplateModule,
      FormPhotoUploaderComponent,
      FormTextboxComponent,
      TranslateModule
  ],
})  

export class RoleNewFormComponent {
  newRole =  newRole;
  getSizeQualifier = getSizeQualifier;
  constructor() { }

  getNewRoleData = ()=> ({ ...this.newRole })
}


