import {
  Component,
  OnInit,
  OnChanges,
  OnDestroy,
  NgModule,
  Output,
  Input,
  SimpleChanges,
  EventEmitter,
  AfterViewChecked,
  ViewChild,
} from '@angular/core';
import { CommonModule, NgClass, NgIf, NgFor, CurrencyPipe } from '@angular/common';
import { Router } from '@angular/router';
import {
  DxAccordionModule,
  DxButtonModule,
  DxDropDownButtonModule,
  DxToolbarModule,
  DxLoadPanelModule,
  DxScrollViewModule,
  DxFormModule,
  DxValidatorModule,
  DxValidationGroupModule,
} from 'devextreme-angular';
import { DxButtonTypes } from 'devextreme-angular/ui/button';

import { ScreenService, DataService } from 'src/app/services';
import { distinctUntilChanged, Subject, Subscription } from 'rxjs';
import { Contact } from 'src/app/types/contact';
import { DxLoadPanelModule as DxLoadPanelModule_1 } from 'devextreme-angular/ui/load-panel';
import { CardActivitiesComponent } from '../card-activities/card-activities.component';
import { FormTextboxComponent } from '../../utils/form-textbox/form-textbox.component';
import { FormPhotoComponent } from '../../utils/form-photo/form-photo.component';
import { DxoColCountByScreenModule } from 'devextreme-angular/ui/nested';
import { DxFormModule as DxFormModule_1 } from 'devextreme-angular/ui/form';
import { ContactStatusComponent } from '../../utils/contact-status/contact-status.component';
import { DxToolbarModule as DxToolbarModule_1 } from 'devextreme-angular/ui/toolbar';
import { RoleService } from 'src/app/pages/roles/role.service'; 
import { TranslateModule } from '@ngx-translate/core';
import { RoleDto } from 'src/app/models/role/roleDto.model';
import { CreateOrUpdateRoleRequest } from 'src/app/models/role/createOrUpdateRole.Request';
import { RolePermissionsComponent } from "../role-permissions/role-permissions.component";
import { FormPopupComponent } from "../../utils/form-popup/form-popup.component";
import { Actions } from 'src/app/models/permission/actions';
import { Resources } from 'src/app/models/permission/resources';
import { SharedModule } from 'src/app/shared.module';

@Component({
    selector: 'role-panel',
    standalone: true,
    templateUrl: './role-panel.component.html',
    styleUrl: './role-panel.component.scss',
    providers: [DataService],
    imports: [
        NgClass,
        NgIf,
        DxToolbarModule_1,
        DxAccordionModule,
        ContactStatusComponent,
        DxButtonModule,
        DxScrollViewModule,
        DxValidationGroupModule,
        DxFormModule_1,
        DxoColCountByScreenModule,
        FormPhotoComponent,
        FormTextboxComponent,
        NgFor,
        CardActivitiesComponent,
        DxLoadPanelModule_1,
        CurrencyPipe,
        TranslateModule,
        RolePermissionsComponent,
        FormPopupComponent,
        SharedModule
    ]
}) 

export class RolePanelComponent implements OnInit, OnChanges, AfterViewChecked, OnDestroy {

  
  @Input() isOpened = false;

  @Input() isDataChange = false;

  @Input() id: string;

  @Output() isOpenedChange = new EventEmitter<boolean>();

  @Output() pinnedChange = new EventEmitter<boolean>();

  @Output() dataChange = new EventEmitter<boolean>();

  
  @ViewChild(RolePermissionsComponent, { static: false }) rolePermissionForm: RolePermissionsComponent;

  private pinEventSubject = new Subject<boolean>();

  action = Actions;
  resource = Resources;

  role: RoleDto;

  pinned = false;

  isLoading = true;

  isEditing = false;

  isPinEnabled = false;

  isRolePermissionsPopupOpened = false;

  userPanelSubscriptions: Subscription[] = [];

  constructor( private roleServices: RoleService,private screen: ScreenService, private service: DataService, private router: Router) {
    this.userPanelSubscriptions.push(
      this.screen.changed.subscribe(this.calculatePin),
      this
        .pinEventSubject
        .pipe(distinctUntilChanged())
        .subscribe(this.pinnedChange)
    );
  }

  ngOnInit(): void {
    this.calculatePin();
  }



  ngAfterViewChecked(): void {
    this.pinEventSubject.next(this.pinned);
  }

  ngOnChanges(changes: SimpleChanges): void {
    const { id } = changes;

    if (id?.currentValue) {
      this.loadUserById(id.currentValue);
    }
  }

  ngOnDestroy(): void {
    this.userPanelSubscriptions.forEach((sub) => sub.unsubscribe());
  }

  loadUserById = (id: string) => {
    this.isLoading = true;

    this.roleServices.getIdRole(id).then((data) => {
      this.role = data;
      this.isLoading = false;
      this.isEditing = false;
    })
  };

 

  onClosePanel = () => {
    this.isOpened = false;
    this.pinned = false;
    this.isOpenedChange.emit(this.isOpened); 
  };
 
  onPinClick = () => {
    this.pinned = !this.pinned;
  };

  onSaveClick = async ({ validationGroup } : DxButtonTypes.ClickEvent) => {
    if (!validationGroup.validate().isValid) return;
    const createOrUpdateRoleRequest: CreateOrUpdateRoleRequest = {
      id: this.role.id,
      name: this.role.name,
      description: this.role.description 
    };
    await this.roleServices.updateRole(createOrUpdateRoleRequest);
    this.isEditing = !this.isEditing;
    this.isDataChange=true;
    this.dataChange.emit(this.isDataChange);
    this.onClosePanel();
  }

  calculatePin = () => {
    this.isPinEnabled = this.screen.sizes['screen-large'] || this.screen.sizes['screen-medium'];
    if (this.pinned && !this.isPinEnabled) {
      this.pinned = false;
    }
  };

  toggleEdit = () => {
    this.isEditing = !this.isEditing;
  };

  deleteRole = async () => { 
    await this.roleServices.deleteRole(this.role.id);
    this.isEditing = !this.isEditing;
    this.isDataChange=true;
    this.dataChange.emit(this.isDataChange);
    this.onClosePanel();
  };

  // navigateToDetails = () => {
  //   this.router.navigate(['/roles']);
  // };

  addpermissions() {
    this.isRolePermissionsPopupOpened = true;
  };

  
  
  onClickSavePermissions = async () => {
    var liste = this.rolePermissionForm.getEnabledClaimsNames(); 
    await this.roleServices.updateRolePermissions(this.id,liste); 
    this.onClosePanel();
  };
}