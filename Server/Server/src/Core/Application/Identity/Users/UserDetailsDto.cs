namespace Server.Application.Identity.Users;

public class UserDetailsDto
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; } = true;

    public bool EmailConfirmed { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ImageUrl { get; set; }
    public DateTime BirthDate { get; set; } = Convert.ToDateTime("01/01/1900");
    public string? CustomerName { get; set; }
    public string? CustomerId { get; set; }
    public string? EntCode { get; set; }
}