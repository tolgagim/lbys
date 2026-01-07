using Microsoft.AspNetCore.Identity;

namespace Server.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public DateTime BirthDate { get; set; }
    public string? ObjectId { get; set; }
    public bool Admin { get; set; }
    public string? EntCode { get; set; }

    // VEM PERSONEL baglantisi
    public string? PersonelKodu { get; set; }
}
