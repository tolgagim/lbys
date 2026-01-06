namespace Server.Application.Catalog.Customers;

public class CreateCustomerRequestValidator : CustomValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator(IReadRepository<Customer> CustomerRepo)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await CustomerRepo.FirstOrDefaultAsync(new CustomerByNameSpec(name), ct) is null)
                .WithMessage((_, name) => "CustomerNameAlreadyExists");

        RuleFor(p => p.EntCode)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await CustomerRepo.FirstOrDefaultAsync(new CustomerByCodeSpec(name), ct) is null)
                .WithMessage((_, name) => "CustomerCodeAlreadyExists");

    }
}