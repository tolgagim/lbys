namespace Server.Domain.Catalog;
 
public class SmsSend : AuditableEntity, IAggregateRoot
{
    public string SmsCode { get; set; }
    public string Code { get; private set; }
    public string MessageId { get; private set; }

    public SmsSend(string smsCode, string code,string messageId)
    {
        SmsCode = smsCode;
        Code = code;
        MessageId = messageId;
    }
}