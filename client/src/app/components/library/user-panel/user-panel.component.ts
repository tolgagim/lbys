import { Component, Input, ViewChild } from '@angular/core';
import { NgIf } from '@angular/common';

import { DxDropDownButtonModule } from 'devextreme-angular/ui/drop-down-button';
import { UserMenuSectionComponent } from '../user-menu-section/user-menu-section.component'; 
import { UserDetailsDto } from "src/app/models/user/userDetailsDto";
 
 
@Component({
    selector: 'user-panel',
    templateUrl: 'user-panel.component.html',
    styleUrls: ['./user-panel.component.scss'],
    standalone: true,
    imports: [
        NgIf,
        DxDropDownButtonModule,
        UserMenuSectionComponent,
    ],
})

export class UserPanelComponent {
  @Input()
  menuItems: any;

  @Input()
  menuMode!: string;

  @Input()
  user!: UserDetailsDto | null;

  @ViewChild(UserMenuSectionComponent) userMenuSection: UserMenuSectionComponent;

  constructor() {}

  handleDropDownButtonContentReady({ component }) {
    component.registerKeyHandler('downArrow', () => {
      this.userMenuSection.userInfoList.nativeElement.focus();
    });
  }
}


