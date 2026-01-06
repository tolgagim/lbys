using Server.Domain.Common.Events;

namespace Server.Application.Catalog.Customers;
public class UpdateCustomerStatusRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public bool Status { get; set; }
}

public class UpdateCustomerStatusRequestHandler : IRequestHandler<UpdateCustomerStatusRequest, Guid>
{
    private readonly IRepository<Customer> _repository;

    public UpdateCustomerStatusRequestHandler(IRepository<Customer> repository) =>
        (_repository) = (repository);

    public async Task<Guid> Handle(UpdateCustomerStatusRequest request, CancellationToken cancellationToken)
    {
        var messages = new List<string>();
        messages.Add("CustomerNotFound");

        var customer = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _ = customer ?? throw new InternalServerException("CustomerNotFound", messages);
        var updatedCustomer = customer.UpdateStatus(request.Status);

        customer.DomainEvents.Add(EntityUpdatedEvent.WithEntity(customer));

        await _repository.UpdateAsync(updatedCustomer, cancellationToken);

        return request.Id;
    }
}