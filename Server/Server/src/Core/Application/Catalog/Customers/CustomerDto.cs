namespace Server.Application.Catalog.Customers;

public class CustomerDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? TaxNumber { get; set; }
    public string? TaxOffice { get; set; }
    public bool Status { get; set; }
    public string? EntCode { get; set; }
}