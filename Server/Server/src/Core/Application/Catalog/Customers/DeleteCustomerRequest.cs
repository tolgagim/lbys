using Server.Domain.Common.Events;

namespace Server.Application.Catalog.Customers;
public class DeleteCustomerRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCustomerRequest(Guid id) => Id = id;
}

public class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest, Guid>
{
    private readonly IRepository<Customer> _repository;
    private readonly IStringLocalizer _t;

    public DeleteCustomerRequestHandler(IRepository<Customer> repository, IStringLocalizer<DeleteCustomerRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var Customer = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = Customer ?? throw new NotFoundException(_t["Customer {0} Not Found."]);

        // Add Domain Events to be raised after the commit
        Customer.DomainEvents.Add(EntityDeletedEvent.WithEntity(Customer));

        await _repository.DeleteAsync(Customer, cancellationToken);

        return request.Id;
    }
}