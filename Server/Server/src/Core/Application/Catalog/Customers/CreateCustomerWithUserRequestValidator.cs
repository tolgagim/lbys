namespace Server.Application.Catalog.Customers;

public class CreateCustomerWithUserRequestValidator : CustomValidator<CreateCustomerWithUserRequest>
{
    public CreateCustomerWithUserRequestValidator(IReadRepository<Customer> CustomerRepo)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await CustomerRepo.FirstOrDefaultAsync(new CustomerByNameSpec(name), ct) is null)
                .WithMessage((_, name) => "NameAlreadyExists");


        RuleFor(p => p.TaxNumber)
           .NotEmpty()
           .MaximumLength(11)
           .MustAsync(async (name, ct) => await CustomerRepo.FirstOrDefaultAsync(new CustomerByTaxNumberSpec(name), ct) is null)
               .WithMessage((_, name) => "TaxNumberAlreadyExists");

        RuleFor(p => p.MobileNumber)
         .NotEmpty()
         .MaximumLength(11)
         .MustAsync(async (name, ct) => await CustomerRepo.FirstOrDefaultAsync(new CustomerByMobileNumberSpec(name), ct) is null)
             .WithMessage((_, name) => "MobileNumberAlreadyExists");
    }
}