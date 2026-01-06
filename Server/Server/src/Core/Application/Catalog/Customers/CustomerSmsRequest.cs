using Server.Application.Identity.Users;
using Server.Domain.Common.Events;
using Server.Shared.Extensions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace Server.Application.Catalog.Customers;

public class CustomerSmsRequest : IRequest<bool>
{ 
    public string Number { get; set; }
    public string? Origin { get; set; }
}

public class CustomerSmsRequestHandler : IRequestHandler<CustomerSmsRequest, bool>
{
    private readonly IRepository<Customer> _repositoryCustomer;
    private readonly IRepository<SmsSend> _repository;
    private readonly IUserService _userManager;

    public CustomerSmsRequestHandler(IRepository<Customer> repositoryCustomer,IRepository<SmsSend> repository, IUserService userManager) =>
        (_repositoryCustomer,_repository, _userManager) = (repositoryCustomer,repository, userManager);

    public async Task<bool> Handle(CustomerSmsRequest request, CancellationToken cancellationToken)
    {
        var messages = new List<string>();
        if (!IsValidGsmNumber(request.Number))
        {
            messages.Add("Geçerli Bir Numara Giriniz.");
            throw new InternalServerException("Geçerli Bir Numara Giriniz.", messages);
        }

        var checkMobileNumberSpec = new CustomerSpecification(request.Number); 

        if (await _repositoryCustomer.AnyAsync(checkMobileNumberSpec, cancellationToken))
        {

        }

        try
        {
            string randomCodeString = StringExtensions.GenerateRandomString();

            string baseUrl = "http://www.postaguvercini.com/api_http/sendsms.asp";
            string username = "Emoda1";
            string password = "Emoda246@";


            string formatliNumara = request.Number.CheckPhoneNumber();
            if (formatliNumara == "Geçersiz telefon numarası!")
            {
                messages.Add(formatliNumara);
                throw new InternalServerException(formatliNumara, messages);
            }
            if (formatliNumara.Length < 10)
            {
                messages.Add(formatliNumara);
                throw new InternalServerException(formatliNumara, messages);
            }

            string gsmNumber = formatliNumara;


            string encodedUsername = WebUtility.UrlEncode(username);
            string encodedPassword = WebUtility.UrlEncode(password);
            string encodedGsmNumber = WebUtility.UrlEncode(gsmNumber);
            string encodedText = "SIFRENIZ " + randomCodeString; //request.Encodedmessage.TurkishUrlEncode();
            string postData = $"user={encodedUsername}&password={encodedPassword}&gsm={encodedGsmNumber}&text={encodedText}";
            byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
            string MessageId = string.Empty;

            var requestSms = (HttpWebRequest)WebRequest.Create(baseUrl);
            requestSms.Method = "POST";
            requestSms.ContentType = "application/x-www-form-urlencoded";
            requestSms.ContentLength = postDataBytes.Length;

            // POST verisini yazma
            using (var stream = requestSms.GetRequestStream())
            {
                stream.Write(postDataBytes, 0, postDataBytes.Length);
            }
            Dictionary<string, string> responses = new Dictionary<string, string>();

            // Yanıtı alma
            using (var response = (HttpWebResponse)requestSms.GetResponse())
            {
                // Yanıtı okuma
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-9"))) // ISO-8859-9 karakter kodlaması
                {
                    string responseText = reader.ReadToEnd();
                    Console.WriteLine(responseText);

                    string[] responseParts = responseText.Split('&');
                    foreach (var part in responseParts)
                    {
                        string[] keyValue = part.Split('=');
                        if (keyValue.Length == 2)
                        {
                            string key = keyValue[0];
                            string value = keyValue[1];
                            responses.Add(key, value);
                            if (key == "errno")
                            {
                                if (value != "0")
                                {
                                    messages.Add("Hata Kodu: " + value);
                                    throw new InternalServerException("Hata Kodu: " + value, messages);
                                }
                            }
                            else if (key == "errtext")
                            {
                                if (value != "")
                                {
                                    messages.Add("Hata Kodu: " + value);
                                    throw new InternalServerException("Hata Kodu: " + value, messages);
                                }
                            }
                            else if (key == "message_id")
                            {
                                MessageId = value;
                            }
                            else if (key == "charge")
                            {
                                messages.Add("Hata Kodu: " + value);
                              //  throw new InternalServerException("Hata Kodu: " + value, messages);
                            }
                        }
                    }
                }
            }


            var isGetValue = responses.TryGetValue("errno", out string durum);
            if (durum == "0")
            {
                var smsSend = new SmsSend(randomCodeString, request.Number, MessageId);
                smsSend.DomainEvents.Add(EntityCreatedEvent.WithEntity(smsSend));
                await _repository.AddAsync(smsSend, cancellationToken);
                return true;

            }
            else
            {
                messages.Add("Mesaj Gönderilemedi");
                throw new InternalServerException("Mesaj Gönderilemedi", messages);
            }

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Transaction failed, all changes rolled back.", ex);
        }
    }

    public static bool IsValidGsmNumber(string number)
    {
        // Düzenli ifade (regex) ile Türkiye GSM numarası formatını kontrol et
        var regex = new Regex(@"^(5(\d{9})$)");
        // Regex, boşluk ve diğer ayraçları kaldır
        string cleanNumber = Regex.Replace(number, @"\s+|[-()]", "");

        // Numaranın uygun formatta olup olmadığını kontrol et
        return regex.IsMatch(cleanNumber);
    }
    public class CustomerSpecification : Specification<Customer>
    {
        public CustomerSpecification(string mobileNumber)
        {
            Query.Where(c => c.MobileNumber == mobileNumber);
        }
    }

}
