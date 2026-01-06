
namespace Server.Application.Catalog.Customers; 
public class CustomerByTaxNumberSpec : Specification<Customer>, ISingleResultSpecification
{
    public CustomerByTaxNumberSpec(string name) =>
        Query.Where(p => p.TaxNumber == name);
}