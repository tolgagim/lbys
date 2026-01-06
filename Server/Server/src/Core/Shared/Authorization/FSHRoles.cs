using System.Collections.ObjectModel;

namespace Server.Shared.Authorization;
public static class FSHRoles
{
    public const string Admin = nameof(Admin);
    public const string Basic = nameof(Basic);
    public const string CustomerAdmin = nameof(CustomerAdmin);

    public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
    {
        Admin,
        Basic,
        CustomerAdmin
    });

    public static bool IsDefault(string roleName) => DefaultRoles.Any(r => r == roleName);
}