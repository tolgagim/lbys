 
 
export interface Base {
    id: string;
    name: string;
    description?: string;
    taxNumber?: string;
    taxOffice?: string;
    address?: string;
    phoneNumber?: string;
    mobileNumber?: string;
    entCode?:string;
   }
   
   export interface UpdateCustomerRequest extends Base {
    id: string;
    name: string;
    description?: string;
    taxNumber?: string;
    taxOffice?: string;
    address?: string;
    phoneNumber?: string;
    mobileNumber?: string;
    entCode?:string;
   }
   
   export const newData: Base = {
     id: '',
     name: '',
     description: '',
     taxNumber: '',
     taxOffice: '',
     address: '',
     phoneNumber: '',
     mobileNumber: '',
     entCode:''
   }