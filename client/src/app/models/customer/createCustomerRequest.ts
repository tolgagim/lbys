
export interface Base {
    Name: string;
    Description?: string;
    TaxNumber?: string;
    TaxOffice?: string;
    Address?: string;
    PhoneNumber?: string;
    MobileNumber?: string; 
    entCode?:string;
  }
  
  export interface CreateCustomerRequest extends Base {
    Name: string;
    Description?: string;
    TaxNumber?: string;
    TaxOffice?: string;
    Address?: string;
    PhoneNumber?: string;
    MobileNumber?: string; 
    entCode?:string;
  }
  
  export const newData: Base = {
    Name: '',
    Description: '',
    TaxNumber: '',
    TaxOffice: '',
    Address: '',
    PhoneNumber: '',
    MobileNumber: '',
    entCode:''
  }