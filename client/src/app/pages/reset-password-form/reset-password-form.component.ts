import { Component, NgModule } from '@angular/core';



import { ResetPasswordFormComponent } from '../../components/library/reset-password-form/reset-password-form.component';
import { CardAuthComponent } from '../../components/library/card-auth/card-auth.component';

@Component({
    selector: 'app-reset-password-form',
    templateUrl: './reset-password-form.component.html',
    styleUrls: ['./reset-password-form.component.scss'],
    standalone: true,
    imports: [CardAuthComponent, ResetPasswordFormComponent]
})
export class AppResetPasswordComponent {

  defaultLink = '/sign-in-form';

  buttonLink = '/reset-password-form';

  constructor() { }

}



