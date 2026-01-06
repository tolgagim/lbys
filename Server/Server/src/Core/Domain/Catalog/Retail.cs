 
namespace Server.Domain.Catalog;


/// <summary>
/// MAĞAZA
/// </summary>
public class Retail : AuditableEntity, IAggregateRoot
{
    public string Code { get; set; }
    public string Name { get; private set; }
    public string CustomerCode { get; private set; }
    public string CaseCode { get; private set; }
    public string SpeCode { get; private set; }
    public string BankCode { get; private set; }
    public string CreditCode { get; private set; }

    public Retail()
    {
    }

    public Retail(string code, string name, string customerCode, string caseCode, string speCode, string bankCode, string creditCode)
    {
        Code = code;
        Name = name;
        CustomerCode = customerCode;
        CaseCode = caseCode;
        SpeCode = speCode;
        BankCode = bankCode;
        CreditCode = creditCode;
    }

    public Retail Update(string? name, string? customerCode, string? caseCode, string? speCode, string? bankCode, string? creditCode)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (customerCode is not null && CustomerCode?.Equals(customerCode) is not true) CustomerCode = customerCode;
        if (caseCode is not null && CaseCode?.Equals(caseCode) is not true) CaseCode = caseCode;
        if (speCode is not null && SpeCode?.Equals(speCode) is not true) SpeCode = speCode;
        if (bankCode is not null && BankCode?.Equals(bankCode) is not true) BankCode = bankCode;
        if (creditCode is not null && CreditCode?.Equals(creditCode) is not true) CreditCode = creditCode;
        return this;
    }
}