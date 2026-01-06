 
import { Actions } from './actions';
import { Resources } from './resources';

export class Permission {
  constructor(
    public description: string,
    public action: string,
    public resource: string,
    public isBasic: boolean = false,
    public isRoot: boolean = false
  ) {}

  get name(): string {
    return Permission.nameFor(this.action, this.resource);
  }

  private static nameFor(action: string, resource: string): string {
    return `Permissions.${resource}.${action}`;
  }
}

export class PermissionList {
  private static readonly all: Permission[] = [
    new Permission('View Dashboard', Actions.View, Resources.Dashboard,false,true),
    new Permission('View Hangfire', Actions.View, Resources.Hangfire,false,false),
    new Permission('View Users', Actions.View, Resources.Users,false,true),
    new Permission('Search Users', Actions.Search, Resources.Users,false,true),
    new Permission('Create Users', Actions.Create, Resources.Users,false,true),
    new Permission('Update Users', Actions.Update, Resources.Users,false,true),
    new Permission('Delete Users', Actions.Delete, Resources.Users,false,true),
    new Permission('Export Users', Actions.Export, Resources.Users,false,false),
    new Permission('Update OtherUsers', Actions.Update, Resources.OtherUsers,false,true),
    new Permission('View UserRoles', Actions.View, Resources.UserRoles,false,true),
    new Permission('Update UserRoles', Actions.Update, Resources.UserRoles,false,true),
    new Permission('View Roles', Actions.View, Resources.Roles,false,true),
    new Permission('Create Roles', Actions.Create, Resources.Roles,false,true),
    new Permission('Update Roles', Actions.Update, Resources.Roles,false,true),
    new Permission('Delete Roles', Actions.Delete, Resources.Roles,false,true),
    new Permission('View RoleClaims', Actions.View, Resources.RoleClaims,false,true),
    new Permission('Update RoleClaims', Actions.Update, Resources.RoleClaims,false,true),
    new Permission('View Products', Actions.View, Resources.Products,false,false),
    new Permission('Search Products', Actions.Search, Resources.Products,false,false),
    new Permission('Create Products', Actions.Create, Resources.Products,false,false),
    new Permission('Update Products', Actions.Update, Resources.Products,false,false),
    new Permission('Delete Products', Actions.Delete, Resources.Products,false,false),
    new Permission('Export Products', Actions.Export, Resources.Products,false,false),
    new Permission('View Brands', Actions.View, Resources.Brands,false,false),
    new Permission('Search Brands', Actions.Search, Resources.Brands,false,false),
    new Permission('Create Brands', Actions.Create, Resources.Brands,false,false),
    new Permission('Update Brands', Actions.Update, Resources.Brands,false,false),
    new Permission('Delete Brands', Actions.Delete, Resources.Brands,false,false),
    new Permission('Generate Brands', Actions.Generate, Resources.Brands,false,false),
    new Permission('Clean Brands', Actions.Clean, Resources.Brands,false,false),
    new Permission('View Tenants', Actions.View, Resources.Tenants, false, false),
    new Permission('Create Tenants', Actions.Create, Resources.Tenants, false, false),
    new Permission('Update Tenants', Actions.Update, Resources.Tenants, false, false),
    new Permission('Upgrade Tenant Subscription', Actions.UpgradeSubscription, Resources.Tenants, false, false),
  ];

  public static get All(): ReadonlyArray<Permission> {
    return Object.freeze(this.all);
  }

  public static get Root(): ReadonlyArray<Permission> {
    return Object.freeze(this.all.filter(p => p.isRoot));
  }

  public static get Admin(): ReadonlyArray<Permission> {
    return Object.freeze(this.all.filter(p => p.isRoot==true));
  }

  public static get Basic(): ReadonlyArray<Permission> {
    return Object.freeze(this.all.filter(p => p.isBasic));
  }
}
