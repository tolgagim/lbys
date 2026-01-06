
namespace Server.Application.Catalog.Customers;
 
public class CustomerByMobileNumberSpec : Specification<Customer>, ISingleResultSpecification
{
    public CustomerByMobileNumberSpec(string name) =>
        Query.Where(p => p.MobileNumber == name);
}