import { CommonModule, NgIf } from '@angular/common';
import { Component, NgModule, Input, OnInit } from '@angular/core';
import { Router, RouterModule, RouterLink } from '@angular/router';


import { DxFormModule } from 'devextreme-angular/ui/form';
import { DxLoadIndicatorModule } from 'devextreme-angular/ui/load-indicator';
import { DxButtonModule, DxButtonTypes } from 'devextreme-angular/ui/button';
import notify from 'devextreme/ui/notify';
import { AuthService, IResponse, ThemeService } from 'src/app/services';
import { LoginOauthComponent } from '../login-oauth/login-oauth.component';
import { DxButtonModule as DxButtonModule_1 } from 'devextreme-angular';
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxiItemModule, DxiValidationRuleModule, DxoLabelModule, DxoButtonOptionsModule } from 'devextreme-angular/ui/nested';

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.scss'],
    standalone: true,
    imports: [
        DxFormModule,
        DxiItemModule,
        DxiValidationRuleModule,
        DxoLabelModule,
        DxoButtonOptionsModule,
        DxTemplateModule,
        NgIf,
        DxLoadIndicatorModule,
        RouterLink,
        DxButtonModule_1,
        LoginOauthComponent,
    ],
})
export class LoginFormComponent implements OnInit {
  @Input() resetLink = '/auth/reset-password';
  @Input() createAccountLink = '/create-account'; 
  defaultAuthData: IResponse;

  btnStylingMode: DxButtonTypes.ButtonStyle;

  passwordMode = 'password';

  loading = false;

  formData: any = {
    email: 'admin@root.com',
    password: '123Pa$$word!'
  };

  passwordEditorOptions = {
    placeholder: 'Password',
    stylingMode:'filled',
    mode: this.passwordMode,
    value: '123Pa$$word!',
    // buttons: [{
    //   name: 'password',
    //   location: 'after',
    //   options: {
    //     icon: 'info',
    //     stylingMode:'text',
    //     onClick: () => this.changePasswordMode(),
    //   }
    // }]
  }

  constructor(private authService: AuthService, private router: Router, private themeService: ThemeService) {
    this.themeService.isDark.subscribe((value: boolean) => {
      this.btnStylingMode = value ? 'outlined' : 'contained';
    });
  }

  changePasswordMode() {
    debugger;
    this.passwordMode = this.passwordMode === 'text' ? 'password' : 'text';
  };

  async onSubmit(e: Event) {
    e.preventDefault();
    const { email, password } = this.formData;

    this.loading = true;

    const result = await this.authService.logIn(email, password);
    this.loading = false; 
    if (!result.isOk) {
      //notify(result.message, 'error', 2000);
    }
  }

  onCreateAccountClick = () => {
    this.router.navigate([this.createAccountLink]);
  };

  async ngOnInit(): Promise<void> {   
    this.defaultAuthData = await this.authService.getUser();
  }
}

