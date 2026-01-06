namespace Server.Application.Catalog.Customers;

public class GetCustomerRequest : IRequest<CustomerDetailsDto>
{
    public Guid Id { get; set; }

    public GetCustomerRequest(Guid id) => Id = id;
}

public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, CustomerDetailsDto>
{
    private readonly IRepository<Customer> _repository;
    private readonly IStringLocalizer _t;

    public GetCustomerRequestHandler(IRepository<Customer> repository, IStringLocalizer<GetCustomerRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<CustomerDetailsDto> Handle(GetCustomerRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Customer, CustomerDetailsDto>)new CustomerByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Customer {0} Not Found.", request.Id]);
}