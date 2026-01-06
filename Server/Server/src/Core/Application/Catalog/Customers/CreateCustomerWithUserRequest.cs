using Server.Application.Identity.Users;
using Server.Domain.Common.Events;
using Server.Shared.Authorization;
using System.Globalization;

namespace Server.Application.Catalog.Customers
{
    public class CreateCustomerWithUserRequest : IRequest<bool>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }

        public string UserFirstName { get; set; } = default!;
        public string UserLastName { get; set; } = default!;
        public string UserEmail { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string UserPassword { get; set; } = default!;
        public string UserConfirmPassword { get; set; } = default!;
        public string? UserPhoneNumber { get; set; }
        public string SmsCode { get; set; }
        public string? Origin { get; set; }
    }

    public class CreateCustomerWithUserRequestHandler : IRequestHandler<CreateCustomerWithUserRequest, bool>
    {
        private readonly IRepository<SmsSend> _repositorySms;
        private readonly IRepositoryWithTransaction<Customer> _repository;
        private readonly IUserService _userManager;


        public CreateCustomerWithUserRequestHandler(IRepository<SmsSend> repositorySms, IRepositoryWithTransaction<Customer> repository, IUserService userManager) =>
            (_repositorySms, _repository, _userManager) = (repositorySms, repository, userManager);

        public async Task<bool> Handle(CreateCustomerWithUserRequest request, CancellationToken cancellationToken)
        {
            var messages = new List<string>();
            var smscheckSpec = new SendSmsSendSpecification(request.MobileNumber, request.SmsCode);
            if (request.SmsCode != "AdminKaydi") //içerde admin kullanıcı kaydı yaparsa aynı sorguyu kullandığım için böyle kontrol ekledim
            {
                if (!await _repositorySms.AnyAsync(smscheckSpec, cancellationToken))
                {
                    messages.Add("SMS KODU HATALI");
                    throw new InternalServerException("SMS KODU HATALI", messages);
                }
            }

            await _repository.BeginTransactionAsync();
            try
            {
                var lastCustomerSpec = new LastCustomerSpecification();
                var lastCustomer = await _repository.FirstOrDefaultAsync(lastCustomerSpec, cancellationToken);

                string newCode;
                string year = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);

                if (lastCustomer != null && lastCustomer.Code.Length == 15 && lastCustomer.Code.StartsWith($"C{year}"))
                {
                    long lastNumber = long.Parse(lastCustomer.Code.Substring(5)); // C ve yıl kısmını çıkar
                    newCode = $"C{year}{(lastNumber + 1).ToString().PadLeft(10, '0')}"; // C, yıl ve numarayı birleştir
                }
                else
                {
                    newCode = $"C{year}0000000001"; // İlk numara
                }

                var customer = new Customer(newCode, request.Name, request.Description, request.TaxNumber, request.TaxOffice, request.Address, request.PhoneNumber, request.MobileNumber,"");

                // Add Domain Events to be raised after the commit
                customer.DomainEvents.Add(EntityCreatedEvent.WithEntity(customer));

                await _repository.AddAsync(customer, cancellationToken);
                 

                var user = new CreateUserRequest
                {
                    Email = request.UserEmail,
                    FirstName = request.UserFirstName,
                    LastName = request.UserLastName,
                    UserName = request.UserName,
                    PhoneNumber = request.UserPhoneNumber,
                    Password = request.UserPassword,
                    ConfirmPassword = request.UserPassword,
                    CustomerId = customer.Id,
                    Admin = true
                };

                string userCreate = await _userManager.CreateAsync(user, request.Origin);

               // await _userManager.AddToRoleAsync(userCreate, FSHRoles.Admin, cancellationToken);

                // Transaction başarılı oldu, commit yap
                await _repository.CommitTransactionAsync();

                return true;
            }
            catch (Exception ex)
            {
                await _repository.RollbackTransactionAsync();
                messages.Add(ex.Message);
                throw new InternalServerException(ex.Message, messages);
            }
        }

        public class LastCustomerSpecification : Specification<Customer>
        {
            public LastCustomerSpecification()
            {
                Query.OrderByDescending(c => c.Code).Take(1);
            }
        }

        public class SendSmsSendSpecification : Specification<SmsSend>
        {
            public SendSmsSendSpecification(string code, string smsCode)
            {
                Query.Where(c => c.Code == code && c.SmsCode == smsCode);
            }
        }
    }
}
