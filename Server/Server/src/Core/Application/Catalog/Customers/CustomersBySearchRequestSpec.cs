using System.Linq.Expressions;

namespace Server.Application.Catalog.Customers;

public class CustomersBySearchRequestSpec : EntitiesByPaginationFilterSpec<Customer, CustomerDto>
{
    public CustomersBySearchRequestSpec(SearchCustomersRequest request)
        : base(request)
    {
        Query.OrderBy(c => c.Name, !request.HasOrderBy());

        AddFilterIfNotNullOrEmpty(request.Name, p => p.Name.Equals(request.Name));
        AddFilterIfNotNullOrEmpty(request.TaxNumber, p => p.TaxNumber.Equals(request.TaxNumber));
        AddFilterIfNotNullOrEmpty(request.TaxOffice, p => p.TaxOffice.Equals(request.TaxOffice));
        AddFilterIfNotNullOrEmpty(request.PhoneNumber, p => p.PhoneNumber.Equals(request.PhoneNumber));
        AddFilterIfNotNullOrEmpty(request.MobileNumber, p => p.MobileNumber.Equals(request.MobileNumber));
    }

    private void AddFilterIfNotNullOrEmpty(string value, Expression<Func<Customer, bool>> filter)
    {
        if (!string.IsNullOrEmpty(value))
        {
            Query.Where(filter);
        }
    }
}
