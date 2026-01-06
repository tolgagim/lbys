namespace Server.Application.Catalog.Customers;

public class CustomerByIdSpec : Specification<Customer, CustomerDetailsDto>, ISingleResultSpecification
{
    public CustomerByIdSpec(Guid id) =>
        Query
            .Where(p => p.Id == id);
}