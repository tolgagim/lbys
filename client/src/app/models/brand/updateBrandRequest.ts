export interface Base {
    id: string;
    name: string;
    description?: string;
   }
   
   export interface UpdateBrandRequest extends Base {
    id: string;
    name: string;
    description?: string;
   }
   
   export const newData: Base = {
     id: '',
     name: '',
     description: '',
   }