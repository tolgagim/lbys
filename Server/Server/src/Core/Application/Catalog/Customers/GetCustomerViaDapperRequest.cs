
namespace Server.Application.Catalog.Customers;
public class GetCustomerViaDapperRequest : IRequest<CustomerDto>
{
    public Guid Id { get; set; }

    public GetCustomerViaDapperRequest(Guid id) => Id = id;
}

public class GetCustomerViaDapperRequestHandler : IRequestHandler<GetCustomerViaDapperRequest, CustomerDto>
{
    private readonly IDapperRepository _repository;
    private readonly IStringLocalizer _t;

    public GetCustomerViaDapperRequestHandler(IDapperRepository repository, IStringLocalizer<GetCustomerViaDapperRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<CustomerDto> Handle(GetCustomerViaDapperRequest request, CancellationToken cancellationToken)
    {
        var Customer = await _repository.QueryFirstOrDefaultAsync<Customer>(
            $"SELECT * FROM Catalog.\"Customers\" WHERE \"Id\" = '{request.Id}'", cancellationToken: cancellationToken);

        _ = Customer ?? throw new NotFoundException(_t["Customer {0} Not Found.", request.Id]);


        return new CustomerDto
        {
            Id = Customer.Id,
            Code = Customer.Code,
            Name = Customer.Name,
            TaxNumber = Customer.TaxNumber,
            TaxOffice = Customer.TaxOffice
        };
    }
}