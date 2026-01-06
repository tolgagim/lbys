namespace Server.Application.Catalog.Customers;

public class CustomerByNameSpec : Specification<Customer>, ISingleResultSpecification
{
    public CustomerByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}