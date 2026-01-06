 
export interface Base {
    Name: string;
    Description?: string;
    TaxNumber?: string;
    TaxOffice?: string;
    Address?: string;
    PhoneNumber?: string;
    MobileNumber?: string; 
    UserFirstName: string;
    UserLastName: string;
    UserEmail: string;
    UserName: string;
    UserPassword: string;
    UserConfirmPassword: string;
    UserPhoneNumber?: string;
    SmsCode: string;
    Origin?: string;
   }
   
   export interface CreateCustomerWithUserRequest extends Base {
     Name: string;
     Description?: string;
     TaxNumber?: string;
     TaxOffice?: string;
     Address?: string;
     PhoneNumber?: string;
     MobileNumber?: string; 
     UserFirstName: string;
     UserLastName: string;
     UserEmail: string;
     UserName: string;
     UserPassword: string;
     UserConfirmPassword: string;
     UserPhoneNumber?: string;
     SmsCode: string;
     Origin?: string;
   }
   
   export const newData: Base = {
     Name: '',
     Description: '',
     TaxNumber: '',
     TaxOffice: '',
     Address: '',
     PhoneNumber: '',
     MobileNumber: '',
     UserFirstName:  '',
     UserLastName:  '',
     UserEmail:  '',
     UserName:  '',
     UserPassword: '',
     UserConfirmPassword:  '',
     UserPhoneNumber:  '',
     SmsCode: '',
     Origin:  '',
   }