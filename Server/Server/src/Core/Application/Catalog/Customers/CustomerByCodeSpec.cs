 
namespace Server.Application.Catalog.Customers;

public class CustomerByCodeSpec : Specification<Customer>, ISingleResultSpecification
{
    public CustomerByCodeSpec(string name) =>
        Query.Where(p => p.EntCode == name);
}