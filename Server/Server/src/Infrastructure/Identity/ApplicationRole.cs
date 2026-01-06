using Microsoft.AspNetCore.Identity;

namespace Server.Infrastructure.Identity;
public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }
    public Guid? CustomerId { get; set; }

    public ApplicationRole(string name, Guid? customerId, string? description = null)
        : base(name)
    {
        Description = description; // Optional parametre
        CustomerId = customerId;   // Required parametre
        NormalizedName = name.ToUpperInvariant();
    }
}
