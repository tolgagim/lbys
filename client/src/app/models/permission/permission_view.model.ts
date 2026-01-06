import { Permission } from "./permissions"; 

  export class PermissionViewModel {
    constructor(
      public group: string,
      public claims: Permission[],
      public selectedCount: number,
      public totalCount: number,
      public enabled: boolean
    ) {}
  }

 