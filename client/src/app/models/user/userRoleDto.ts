export interface UserRoleDto {
    roleId?: string;
    roleName?: string;
    description?: string;
    enabled: boolean;
  }
  

  export class UserRolesRequest {
    userRoles: UserRoleDto[];
  }
  