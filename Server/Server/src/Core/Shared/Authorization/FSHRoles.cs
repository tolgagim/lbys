using System.Collections.ObjectModel;

namespace Server.Shared.Authorization;

public static class FSHRoles
{
    public const string Admin = nameof(Admin);
    public const string Basic = nameof(Basic);
    public const string Doctor = nameof(Doctor);
    public const string Nurse = nameof(Nurse);

    public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
    {
        Admin,
        Basic,
        Doctor,
        Nurse
    });

    public static bool IsDefault(string roleName) => DefaultRoles.Any(r => r == roleName);
}
