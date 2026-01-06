 
  
export interface Base {
    firstName: string;
    lastName: string;
    email: string;
    userName: string;
    password: string;
    confirmPassword: string;
    phoneNumber?: string;  
    customerId?: string;  
    entCode?:string;
  }
  
  export interface CreateUserRequest extends Base {
    firstName: string;
    lastName: string;
    email: string;
    userName: string;
    password: string;
    confirmPassword: string;
    phoneNumber?: string;  
    customerId?: string;  
    entCode?:string;
  }
  
  export const newData: Base = {
        firstName: '',
        lastName: '',
        email: '',
        userName: '',
        password: '',
        confirmPassword: '',
        phoneNumber: '',
        customerId:'',
        entCode:''
  }