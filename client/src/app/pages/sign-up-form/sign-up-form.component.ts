import { Component, NgModule } from '@angular/core';


import { CreateAccountFormComponent } from '../../components/library/create-account-form/create-account-form.component';
import { CardAuthComponent } from '../../components/library/card-auth/card-auth.component';

@Component({
    selector: 'app-sign-up-form',
    templateUrl: './sign-up-form.component.html',
    styleUrls: ['./sign-up-form.component.scss'],
    standalone: true,
    imports: [CardAuthComponent, CreateAccountFormComponent]
})
export class AppSignUpComponent {

  defaultLink = '/sign-in-form';

  buttonLink = '/sign-up-form';

  constructor() { }
}



