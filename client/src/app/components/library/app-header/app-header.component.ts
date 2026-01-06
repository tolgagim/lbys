import { Component, NgModule, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { CommonModule, NgIf } from '@angular/common';
import { DxButtonModule } from 'devextreme-angular/ui/button';
import { DxToolbarModule } from 'devextreme-angular/ui/toolbar';
import { DxSelectBoxModule } from 'devextreme-angular/ui/select-box';
import { UserPanelComponent } from '../user-panel/user-panel.component';
import { AuthService } from 'src/app/services';
import { DxButtonModule as DxButtonModule_1 } from 'devextreme-angular';
import { ThemeSwitcherComponent } from '../theme-switcher/theme-switcher.component'; 
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { UserDetailsDto } from "src/app/models/user/userDetailsDto";

@Component({
    selector: 'app-header',
    templateUrl: 'app-header.component.html',
    styleUrls: ['./app-header.component.scss'],
    standalone: true,
    imports: [
        DxToolbarModule,
        NgIf,
        ThemeSwitcherComponent,
        DxButtonModule_1,
        UserPanelComponent,
        DxSelectBoxModule,
        CommonModule,
        TranslateModule
    ],
})
export class AppHeaderComponent implements OnInit {
  @Output()
  menuToggle = new EventEmitter<boolean>();

  @Input()
  menuToggleEnabled = false;

  @Input()
  title!: string;

  user: UserDetailsDto ;

  userMenuItems = [
    {
      text: 'Hesap Ayarları',
      icon: 'user',
      onClick: () => { 
        this.router.navigate(['/user-profile']);
      },
    },
    {
      text: '',
      icon: 'runner',
      onClick: () => {
        this.authService.logOut();
      },
    },
  ];

  languages = [
    { code: 'en', name: 'Eng', flagUrl: '../../../../assets/flags/en.jpg' },
    { code: 'tr', name: 'Tr', flagUrl: '../../../../assets/flags/tr.jpg' }
  ];

  selectedLanguage = this.languages[0].code;

  constructor(private authService: AuthService, private translate: TranslateService,private router: Router) { }

  ngOnInit() {
 
    this.authService.getUser().then((e) => this.user = e.data); 
    this.selectedLanguage = this.authService.getLanguage(); 
    this.authService.language$.subscribe(lang => {
      this.selectedLanguage = lang; 
    });

    this.translate.onLangChange.subscribe(() => {
        this.updateMenuItems();
    });

    this.updateMenuItems(); // İlk yüklemede menü öğelerini güncelle
  }

  changeLanguage(lang: string) {
    this.authService.setLanguage(lang);
    this.translate.use(lang); // Yeni dilin anında aktif olmasını sağlar
  }

  toggleMenu = () => {
    this.menuToggle.emit();
  };

  updateMenuItems() {
    this.userMenuItems[1].text = this.translate.instant('General.LogOut'); 
  }
}
