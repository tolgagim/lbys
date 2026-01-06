
namespace Server.Application.Catalog.Customers;

public class CheckSmsRequest : IRequest<bool>
{
    public string SmsCode { get; set; }
    public string MobileNumber { get; set; }
    public string? Origin { get; set; }
}

public class CheckSmsRequestHandler : IRequestHandler<CheckSmsRequest, bool>
{
    private readonly IRepository<SmsSend> _repository;
    public CheckSmsRequestHandler(IRepository<SmsSend> repository) =>
        (_repository) = (repository);

    public async Task<bool> Handle(CheckSmsRequest request, CancellationToken cancellationToken)
    {
        var messages = new List<string>();
        try
        {
            var smscheckSpec = new SendSmsSendSpecification(request.MobileNumber, request.SmsCode);
            if (!await _repository.AnyAsync(smscheckSpec, cancellationToken))
            {
                messages.Add("SMS KODU HATALI");
                throw new InternalServerException("SMS KODU HATALI", messages);
            }
            return true;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Transaction failed, all changes rolled back.", ex);
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
