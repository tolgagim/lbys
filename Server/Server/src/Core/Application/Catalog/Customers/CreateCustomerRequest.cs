using Server.Application.Identity.Users;
using Server.Domain.Common.Events;
using System.Globalization;

namespace Server.Application.Catalog.Customers;

public class CreateCustomerRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? TaxNumber { get; set; }
    public string? TaxOffice { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? MobileNumber { get; set; }
    public string? EntCode { get; set; }
}

public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, Guid>
{
    private readonly IRepository<Customer> _repository;
    private readonly IUserService _userManager;

    public CreateCustomerRequestHandler(IRepository<Customer> repository, IUserService userManager) =>
        (_repository, _userManager) = (repository, userManager);

    public async Task<Guid> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var lastCustomerSpec = new LastCustomerSpecification();
        var lastCustomer = await _repository.FirstOrDefaultAsync(lastCustomerSpec, cancellationToken);

        string newCode;
        string year = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);

        if (lastCustomer != null && lastCustomer.Code.Length == 15 && lastCustomer.Code.StartsWith($"C{year}"))
        {
            long lastNumber = long.Parse(lastCustomer.Code.Substring(5)); // C ve yıl kısmını çıkar
            newCode = $"C{year}{(lastNumber + 1).ToString().PadLeft(10, '0')}"; // C, yıl ve numarayı birleştir
        }
        else
        {
            newCode = $"C{year}0000000001"; // İlk numara
        }

        var customer = new Customer(newCode, request.Name, request.Description, request.TaxNumber, request.TaxOffice, request.Address, request.PhoneNumber, request.MobileNumber,request.EntCode);

        // Add Domain Events to be raised after the commit
        customer.DomainEvents.Add(EntityCreatedEvent.WithEntity(customer));

        await _repository.AddAsync(customer, cancellationToken);

        return customer.Id;
    }

    public class LastCustomerSpecification : Specification<Customer>
    {
        public LastCustomerSpecification()
        {
            Query.OrderByDescending(c => c.Code).Take(1);
        }
    }
} 