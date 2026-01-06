namespace Server.Application.Catalog.Customers;

public class SearchCustomersRequest : PaginationFilter, IRequest<PaginationResponse<CustomerDto>>
{ 
    public string? Name { get; set; } = default!;
    public string? TaxNumber { get; set; }
    public string? TaxOffice { get; set; }
    public string? PhoneNumber { get; set; }
    public string? MobileNumber { get; set; }
}

public class SearchCustomersRequestHandler : IRequestHandler<SearchCustomersRequest, PaginationResponse<CustomerDto>>
{
    private readonly IReadRepository<Customer> _repository;

    public SearchCustomersRequestHandler(IReadRepository<Customer> repository) => _repository = repository;

    public async Task<PaginationResponse<CustomerDto>> Handle(SearchCustomersRequest request, CancellationToken cancellationToken)
    {
        var spec = new CustomersBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}