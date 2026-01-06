import { CommonModule, NgIf } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';


import { ValidationCallbackData } from 'devextreme-angular/common';
import { DxFormModule } from 'devextreme-angular/ui/form';
import { DxLoadIndicatorModule } from 'devextreme-angular/ui/load-indicator';
import notify from 'devextreme/ui/notify'; 
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxiItemModule, DxiValidationRuleModule, DxoLabelModule, DxoButtonOptionsModule, DxiButtonModule } from 'devextreme-angular/ui/nested';
import { DxButtonModule, DxTextBoxModule } from 'devextreme-angular';
import { CheckSmsCodeRequest } from 'src/app/models/customer/checkSmsCodeRequest';
import { FormsModule } from '@angular/forms';
import { Smservice } from 'src/app/services/sms.service';
import { CustomerSmsRequest } from 'src/app/models/customer/customerSmsRequest ';
import { CreateCustomerWithUserRequest } from 'src/app/models/customer/createCustomerWithUserRequest .ts';

@Component({
  selector: 'app-create-account-form',
  providers: [Smservice],
  templateUrl: './create-account-form.component.html',
  styleUrls: ['./create-account-form.component.scss'],
  standalone: true,
  imports: [
    DxFormModule,
    DxiItemModule,
    DxiValidationRuleModule,
    DxoLabelModule,
    RouterLink,
    DxoButtonOptionsModule,
    DxTemplateModule,
    NgIf,
    DxLoadIndicatorModule,
    DxTextBoxModule,
    DxButtonModule,
    CommonModule, FormsModule,
  ],
})
export class CreateAccountFormComponent implements OnInit {
  @Input() redirectLink = ''; //'/auth/login';
  @Input() buttonLink = ''; //'/auth/login';
  loading = false;


  saveCustomer: boolean = false;
  codeSentFirst: boolean = true;
  codeSent: boolean = false;
   
  phoneNumber: string = '';
  verificationCode: string = '';
 
  timerDisplay: string;
  timer: any;


  newCustomer: CreateCustomerWithUserRequest = {
    Name: '',
    Description: '',
    TaxNumber: '',
    TaxOffice: '',
    Address: '',
    PhoneNumber: '',
    MobileNumber: '',
    UserFirstName: '',
    UserLastName: '',
    UserEmail: '',
    UserName: '',
    UserPassword: '',
    UserConfirmPassword: '',
    Origin: '',
    SmsCode: ''
  };

  constructor(private router: Router, private smservice: Smservice) { }

  async onSubmit(e: Event) {
    e.preventDefault();
    this.loading = true;
    var result = await this.smservice.createcustomeruser(this.newCustomer);
    if (result.isOk) {
      if (result.isOk) {
        this.router.navigate([this.buttonLink]);
      } else {
        notify(result.message, 'error', 2000);
      }
    }
    this.loading = false;
  }

  confirmPassword = (e: ValidationCallbackData) => e.value === this.newCustomer.UserPassword;

  // eslint-disable-next-line @angular-eslint/no-empty-lifecycle-method
  async ngOnInit(): Promise<void> {
     
  }



  async sendCode() {
    const customerSms = new CustomerSmsRequest();
    customerSms.number = this.phoneNumber;
    customerSms.origin = "";
    var smsSent = await this.smservice.createusersmsasync(customerSms);
    if (smsSent.isOk) {
      this.codeSentFirst = false;
      this.codeSent = true;
      this.startTimer(2);
    }
  }

  async verifyCode() {
    const data = new CheckSmsCodeRequest();
    data.smsCode = this.verificationCode;
    data.mobileNumber = this.phoneNumber;
    data.origin = "";
    var sonuc = await this.smservice.checkusersmsasync(data);
    if (sonuc.isOk) {
      this.saveCustomer = true;
      this.codeSent = false;

      
      this.newCustomer.MobileNumber= this.phoneNumber;
      this.newCustomer.SmsCode= this.verificationCode;
    }
  }

  startTimer(minutes: number) {
    let endTime = new Date();
    endTime.setMinutes(endTime.getMinutes() + minutes);

    this.timer = setInterval(() => {
      let now = new Date();
      let distance = endTime.getTime() - now.getTime();

      if (distance < 0) {
        clearInterval(this.timer);
        this.timerDisplay = "Süre doldu";
        if(!this.saveCustomer){
          this.navigateToLogin();   
        }
       
      } else {
        let minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        let seconds = Math.floor((distance % (1000 * 60)) / 1000);
        this.timerDisplay = `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;
      }
    }, 1000);
  }

  navigateToLogin() {
    this.router.navigate(['/auth/login']);  // 'auth/login' yoluna yönlendir
  }
}

