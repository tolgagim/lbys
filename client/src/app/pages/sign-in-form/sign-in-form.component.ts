import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { LoginFormComponent } from '../../components/library/login-form/login-form.component';
import { CardAuthComponent } from '../../components/library/card-auth/card-auth.component';

@Component({
    selector: 'app-sign-in-form',
    templateUrl: './sign-in-form.component.html',
    styleUrls: ['./sign-in-form.component.scss'],
    standalone: true,
    imports: [CardAuthComponent, LoginFormComponent]
})
export class AppSignInComponent {
  constructor() { }
}


