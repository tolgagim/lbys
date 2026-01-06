using System.Collections.ObjectModel;

namespace Server.Shared.Authorization;
public static class FSHAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
    public const string PayEasy = nameof(PayEasy);  //payment yetkisinizn PayEasy yetkisi

}

public static class FSHResource
{
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string OtherUsers = nameof(OtherUsers);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
    public const string Customers = nameof(Customers);
    public const string Brands = nameof(Brands);
    public const string Payments = nameof(Payments);
}

public static class FSHPermissions
{
    private static readonly FSHPermission[] _all = new FSHPermission[]
    {
        new("View Dashboard", FSHAction.View, FSHResource.Dashboard,IsRoot: true),
        new("View Hangfire", FSHAction.View, FSHResource.Hangfire),
        new("View Users", FSHAction.View, FSHResource.Users,IsRoot: true),
        new("Search Users", FSHAction.Search, FSHResource.Users,IsRoot: true),
        new("Create Users", FSHAction.Create, FSHResource.Users,IsRoot: true),
        new("Update Users", FSHAction.Update, FSHResource.Users, IsRoot: true),
        new("Delete Users", FSHAction.Delete, FSHResource.Users,IsRoot: true),
        new("Export Users", FSHAction.Export, FSHResource.Users, IsRoot: true),
        new("View UserRoles", FSHAction.View, FSHResource.UserRoles, IsRoot: true),
        new("Update UserRoles", FSHAction.Update, FSHResource.UserRoles, IsRoot: true),
        new("Update OtherUsers", FSHAction.Update, FSHResource.OtherUsers, IsRoot: true),
        new("View Roles", FSHAction.View, FSHResource.Roles,IsRoot: true),
        new("Create Roles", FSHAction.Create, FSHResource.Roles, IsRoot: true),
        new("Update Roles", FSHAction.Update, FSHResource.Roles, IsRoot: true),
        new("Delete Roles", FSHAction.Delete, FSHResource.Roles, IsRoot: true),
        new("View RoleClaims", FSHAction.View, FSHResource.RoleClaims, IsRoot: true),
        new("Update RoleClaims", FSHAction.Update, FSHResource.RoleClaims, IsRoot: true),
        new("View Products", FSHAction.View, FSHResource.Products, IsBasic: true),
        new("Search Products", FSHAction.Search, FSHResource.Products),
        new("Create Products", FSHAction.Create, FSHResource.Products),
        new("Update Products", FSHAction.Update, FSHResource.Products),
        new("Delete Products", FSHAction.Delete, FSHResource.Products),
        new("Export Products", FSHAction.Export, FSHResource.Products),
        new("View Brands", FSHAction.View, FSHResource.Brands, IsBasic: true),
        new("Search Brands", FSHAction.Search, FSHResource.Brands, IsBasic: true),
        new("Create Brands", FSHAction.Create, FSHResource.Brands),
        new("Update Brands", FSHAction.Update, FSHResource.Brands),
        new("Delete Brands", FSHAction.Delete, FSHResource.Brands),
        new("Generate Brands", FSHAction.Generate, FSHResource.Brands),
        new("Clean Brands", FSHAction.Clean, FSHResource.Brands),
        new("View Customers",    FSHAction.View, FSHResource.Customers),
        new("Search Customers", FSHAction.Search, FSHResource.Customers),
        new("Create Customers", FSHAction.Create, FSHResource.Customers),
        new("Update Customers", FSHAction.Update, FSHResource.Customers),
        new("Delete Customers", FSHAction.Delete, FSHResource.Customers),
        new("Export Customers", FSHAction.Export, FSHResource.Customers),
        new("Pay Easy", FSHAction.PayEasy, FSHResource.Payments),
    };

    public static IReadOnlyList<FSHPermission> All { get; } = new ReadOnlyCollection<FSHPermission>(_all);
    public static IReadOnlyList<FSHPermission> Root { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Admin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Basic { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsBasic).ToArray());
    public static IReadOnlyList<FSHPermission> CustomerAdmin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
}

public record FSHPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
