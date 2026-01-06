import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
} from '@angular/core';
import { NgIf, AsyncPipe } from '@angular/common';
import notify from 'devextreme/ui/notify';
import {
  DxButtonModule,
  DxScrollViewModule,
} from 'devextreme-angular';


import { DataService, ScreenService } from 'src/app/services';
import { DxLoadPanelModule as DxLoadPanelModule_1 } from 'devextreme-angular/ui/load-panel';
import { DxiItemModule } from 'devextreme-angular/ui/nested';
import { DxToolbarModule as DxToolbarModule_1 } from 'devextreme-angular/ui/toolbar';
import { HttpClientModule } from '@angular/common/http';
import { UserDetailsDto } from "src/app/models/user/userDetailsDto"; 
import { FileUploadRequest } from 'src/app/models/fileUploadRequest';
import { FileService } from 'src/app/services/file.service';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { FormPhotoComponent } from '../../utils/form-photo/form-photo.component';
import { ChangeProfilePasswordFormComponent } from '../change-profile-password-form/change-profile-password-form.component';
import { ProfileCardComponent } from '../profile-card/profile-card.component';
import { PhonePipe } from 'src/app/pipes/phone.pipe';
import { UserService } from 'src/app/pages/users/user.service';
import { getSizeQualifier } from 'src/app/services/screen.service';
import { UpdateUserRequest } from 'src/app/models/user/updateUserRequest';
@Component({
  selector: 'user-list-profile',
  standalone: true,
  providers: [DataService, UserService],
  imports: [DxToolbarModule_1,
    DxiItemModule,
    DxButtonModule,
    DxLoadPanelModule_1,
    DxScrollViewModule,
    NgIf,
    ProfileCardComponent,
    FormPhotoComponent,
    ChangeProfilePasswordFormComponent,
    AsyncPipe,
    PhonePipe,
    HttpClientModule,
    TranslateModule],
  templateUrl: './user-list-profile.component.html',
  styleUrl: './user-list-profile.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserListProfileComponent implements OnChanges {
 
  @Output() userDetailsChange = new EventEmitter<UserDetailsDto>();

  tempData: string;

  isLoading = true;

  supervisorsList = [];

  isChangePasswordPopupOpened = false;

  isDataChanged = false;

  isContentScrolled = false;

  basicInfoItems: Record<string, any>[] = this.getBasicInfoItems();

  contactItems: Record<string, any>[] = this.getContactItems();

  addressItems: Record<string, any>[] = this.getAddressItems();
  languageSubscription: Subscription;
  getSizeQualifier = getSizeQualifier;


  private _userDetails: UserDetailsDto;

  @Input() set userDetails(data: UserDetailsDto) {
    this._userDetails = data;
    this.handleDataChange(data);
  }
  
  get userDetails(): UserDetailsDto {
    return this._userDetails;
  }

  constructor(
    private translate: TranslateService,
    private userServices: UserService,
    public screen: ScreenService,
    private ref: ChangeDetectorRef,
    private fileService: FileService) { 
    this.subscribeToLanguageChanges(); 
    this.isLoading = false;
  }
 
 
  ngOnChanges(changes: SimpleChanges) {
    this.tempData=this._userDetails.imageUrl;
    this.ref.detectChanges(); 
  }

  handleDataChange(data: UserDetailsDto) {
    // İhtiyaca göre burada UI güncellemeleri veya başka işlemler yapın
    this.ref.detectChanges(); // Değişiklikleri zorla algıla 
  }

  subscribeToLanguageChanges() {
    this.languageSubscription = this.translate.onLangChange.subscribe(() => {
      this.basicInfoItems = this.getBasicInfoItems(); // Dil değiştiğinde form öğelerini yeniden yükle
      this.ref.detectChanges(); // Değişiklikleri algıla ve UI'ı güncelle
    });
  }


  getBasicInfoItems() {
    return [
      {
        dataField: 'firstName',
        colSpan: 2,
        label: this.translate.instant('Users.FirstName')
      },
      { dataField: 'lastName', colSpan: 2 },
      // {
      //   dataField: 'department',
      //   editorType: 'dxSelectBox',
      //   colSpan: 1,
      //   editorOptions: {
      //     items: ['UI/UX', 'Backend Developers'],
      //   }
      // },
      // {
      //   dataField: 'position',
      //   editorType: 'dxSelectBox',
      //   colSpan: 1,
      //   editorOptions: {
      //     items: ['Designer', 'Developer', 'Technical Writer'],
      //   }
      // },
      {
        dataField: 'email',
        colSpan: 1,
        label: this.translate.instant('Users.Email'),
        editorOptions: {
          disabled: true
        }
      },
      {
        dataField: 'phoneNumber',
        colSpan: 1,
        label: this.translate.instant('Users.PhoneNumber'),
      },
      {
        dataField: 'birthDate',
        colSpan: 1,
        label: this.translate.instant('Users.DateOfBirth'),
        editorType: 'dxDateBox',
        editorOptions: {
          max: new Date(),
          displayFormat: 'dd/MM/yyyy',
          pickerType: 'calendar',
          onValueChanged: (e: any) => {
            if (e.value && new Date(e.value).getTime() === new Date('0001-01-01T00:00:00').getTime()) {
              e.component.option('value', new Date('1900-01-01'));
            }
          }
        }
      },
    ]
  }

  getContactItems() {
    return [
      {
        dataField: 'phone',
        editorOptions: {
          mask: '+1(000)000-0000',
        }
      },
      {
        dataField: 'email',
        validators: [
          { type: 'email' }
        ]
      },
      {
        dataField: 'domainUsername',
        colSpan: 2,
      },
      {
        dataField: 'status',
        colSpan: 2,
      },
      {
        dataField: 'supervisor',
        label: 'Supervisor',
        colSpan: 2,
        itemsList: this.supervisorsList,
        editorType: 'dxSelectBox',
      },
    ];
  }

  getAddressItems() {
    return [
      { dataField: 'country' },
      { dataField: 'city' },
      {
        dataField: 'state',
        colSpan: 2,
        label: 'State/province/area',
        editorOptions: {
          label: 'State/province/area',
        }
      },
      {
        dataField: 'address',
        colSpan: 2,
      },
      {
        dataField: 'zipCode',
        editorType: 'dxNumberBox',
        colSpan: 2,
      },
    ];
  }

  dataChanged() {
    this.isDataChanged = true;
  }

  async setSavedData(data = this.userDetails) { 

    var ext;
    if (data.imageUrl === this.tempData) {
      ext = "";
    }
    else {
      ext = this.fileService.parseImageData(data.imageUrl).extension;
    }

    const newImage: FileUploadRequest | null = ext ? {
      name: data.id,
      extension: '.' + ext,
      data: data.imageUrl
    } : null;

    const updateUserRequest: UpdateUserRequest = {
      id: data.id,
      firstName: data.firstName,
      lastName: data.lastName,
      phoneNumber: data.phoneNumber,
      email: data.email,
      image: newImage,  // Opsiyonel: Yeni resim bilgisi
      birthDate: data.birthDate,
      deleteCurrentImage: newImage === null ? false : true  // Mevcut resmin silinmesi isteniyor
    };
    await this.userServices.updateUser(updateUserRequest);
  }

  handleImageUrlChange(newImageUrl: string) {
    this.userDetails.imageUrl = newImageUrl; // Kullanıcı detaylarını güncelle
    this.dataChanged(); // Veri değişikliklerini işle
    this.ref.detectChanges(); 
  }

  copyToClipboard(text, evt) {
    window.navigator.clipboard?.writeText(text);
    const tipText = 'Text copied';
    notify({
      message: tipText,
      minWidth: `${tipText.length + 2}ch`,
      width: 'auto',
      position: { of: evt.target, offset: '0 -30' }
    },
      'info', 500);
  };

  changePassword() {
    this.isChangePasswordPopupOpened = true;
  };

  cancel() {

    this.ref.detectChanges();
    this.setSavedData();

    setTimeout(() => {
      this.isDataChanged = false;
    });
  }





  scroll({ reachedTop = false }) {
    this.isContentScrolled = !reachedTop;
  }

}
