import { Component, NgModule, Input, ViewChild, ElementRef } from '@angular/core';
import { CommonModule, NgIf } from '@angular/common';

import { DxListModule, DxListTypes } from 'devextreme-angular/ui/list'; 
import { UserDetailsDto } from "src/app/models/user/userDetailsDto";
 

@Component({
    selector: 'user-menu-section',
    templateUrl: 'user-menu-section.component.html',
    styleUrls: ['./user-menu-section.component.scss'],
    standalone: true,
    imports: [NgIf, DxListModule],
})

export class UserMenuSectionComponent {
  @Input()
  menuItems: any;

  @Input()
  showAvatar!: boolean;

  @Input()
  user!: UserDetailsDto | null;
  

  @ViewChild('userInfoList', { read: ElementRef }) userInfoList: ElementRef<HTMLElement>;

  constructor() {}

  handleListItemClick(e: DxListTypes.ItemClickEvent) {
    e.itemData?.onClick(); 
    
  }
 
}


