 export interface Base {
    name: string;
    description?: string; 
  }
  
  export interface CreateBrandRequest extends Base {
    name: string;
    description?: string; 
  }
  
  export const newData: Base = {
    name: '',
    description: '' 
  }