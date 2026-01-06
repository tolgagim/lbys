using Server.Domain.Common.Events;

namespace Server.Application.Catalog.Customers;
public class UpdateCustomerRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? TaxNumber { get; set; }
    public string? TaxOffice { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? MobileNumber { get; set; }
    public string? EntCode { get; set; }
}

public class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, Guid>
{
    private readonly IRepository<Customer> _repository;
    private readonly IStringLocalizer _t;
    private readonly IFileStorageService _file;

    public UpdateCustomerRequestHandler(IRepository<Customer> repository, IStringLocalizer<UpdateCustomerRequestHandler> localizer, IFileStorageService file) =>
        (_repository, _t, _file) = (repository, localizer, file);

    public async Task<Guid> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var Customer = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = Customer ?? throw new NotFoundException(_t["Customer {0} Not Found.", request.Id]);


        var updatedCustomer =   Customer.Update(request.Name, request.Description, request.TaxNumber, request.TaxOffice, request.Address, request.PhoneNumber, request.MobileNumber,request.EntCode);

        Customer.DomainEvents.Add(EntityUpdatedEvent.WithEntity(Customer));

        await _repository.UpdateAsync(updatedCustomer, cancellationToken);

        return request.Id;
    }
}