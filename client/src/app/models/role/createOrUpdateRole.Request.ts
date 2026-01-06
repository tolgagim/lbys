 
  
export interface RoleBase {
    id?: string;        
    name: string;     
    description?: string; 
    customerId?: string; 
  }
  
  export interface CreateOrUpdateRoleRequest extends RoleBase {
    id?: string;        
    name: string;     
    description?: string; 
    customerId?: string; 
  }
  
  export const newRole: RoleBase = {
    id: '',
    name: '',
    description: '',
    customerId:''
  }