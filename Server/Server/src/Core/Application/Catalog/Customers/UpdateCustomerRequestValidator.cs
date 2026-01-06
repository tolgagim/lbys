namespace Server.Application.Catalog.Customers;

public class UpdateCustomerRequestValidator : CustomValidator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator(IReadRepository<Customer> CustomerRepo, IReadRepository<Brand> brandRepo)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (Customer, name, ct) =>
                    await CustomerRepo.FirstOrDefaultAsync(new CustomerByNameSpec(name), ct)
                        is not Customer existingCustomer || existingCustomer.Id == Customer.Id)
                .WithMessage((_, name) => "CustomerNameAlreadyExists");

        RuleFor(p => p.EntCode)
           .NotEmpty()
           .MaximumLength(75)
           .MustAsync(async (Customer, name, ct) =>
                   await CustomerRepo.FirstOrDefaultAsync(new CustomerByCodeSpec(name), ct)
                       is not Customer existingCustomer || existingCustomer.Id == Customer.Id)
               .WithMessage((_, name) => "CustomerCodeAlreadyExists");
    }
}