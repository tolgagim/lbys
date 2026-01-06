

namespace Server.Domain.Catalog;

public class ReceiptPayment : AuditableEntity, IAggregateRoot
{
    public Guid ReceiptId { get; private set; }
    public double Receivable { get; private set; } // Alacak
    public double Debt { get; private set; } // Borç
    public double Cash { get; private set; } // Nakit
    public double Credit { get; private set; } // Kredi
    public double Finance { get; private set; } // Cari
    public double Bank { get; private set; } // Banka
    public double Cheque { get; private set; } // Çek
    public double Promissory { get; private set; } // Senet
    public double Total { get; private set; } // Toplam
    public string PaymentType { get; private set; } // Ödeme Türü
    public string CaseReceipt { get; private set; } // Kasa
    public string CrossReceiptId { get; private set; } // Evrak Id
    public string Installment { get; private set; } // Taksit
    public Guid? CustomerId { get; private set; }
    public string CrossCustomerId { get; private set; }
    public string CrossCaseId { get; private set; }
    public double Exchange { get; private set; } // Kur
    public DateTime ReceiptDate { get; private set; } // Fiş Tarihi
    public string ChequeNo { get; private set; } // Çek No
    public bool LogoTransStatus { get; private set; } = false;
    public string? LogoTransDesc { get; private set; }
    public string CaseIntegrationCode { get; private set; }
    public string LogoNumber { get; private set; }
    public int LogicalRef { get; private set; }

    public ReceiptPayment()
    {
    }

    public ReceiptPayment(Guid receiptId, double receivable, double debt, double cash, double credit, double finance,
                          double bank, double cheque, double promissory, double total, string paymentType, string caseReceipt,
                          string crossReceiptId, string installment, Guid? customerId, string crossCustomerId, string crossCaseId,
                          double exchange, DateTime receiptDate, string chequeNo, bool logoTransStatus, string? logoTransDesc,
                          string caseIntegrationCode, string logoNumber, int logicalRef)
    {
        ReceiptId = receiptId;
        Receivable = receivable;
        Debt = debt;
        Cash = cash;
        Credit = credit;
        Finance = finance;
        Bank = bank;
        Cheque = cheque;
        Promissory = promissory;
        Total = total;
        PaymentType = paymentType;
        CaseReceipt = caseReceipt;
        CrossReceiptId = crossReceiptId;
        Installment = installment;
        CustomerId = customerId;
        CrossCustomerId = crossCustomerId;
        CrossCaseId = crossCaseId;
        Exchange = exchange;
        ReceiptDate = receiptDate;
        ChequeNo = chequeNo;
        LogoTransStatus = logoTransStatus;
        LogoTransDesc = logoTransDesc;
        CaseIntegrationCode = caseIntegrationCode;
        LogoNumber = logoNumber;
        LogicalRef = logicalRef;
    }

    public ReceiptPayment Update(Guid? receiptId, double? receivable, double? debt, double? cash, double? credit,
                                 double? finance, double? bank, double? cheque, double? promissory, double? total,
                                 string? paymentType, string? caseReceipt, string? crossReceiptId, string? installment,
                                 Guid? customerId, string? crossCustomerId, string? crossCaseId, double? exchange,
                                 DateTime? receiptDate, string? chequeNo, bool? logoTransStatus, string? logoTransDesc,
                                 string? caseIntegrationCode, string? logoNumber, int? logicalRef)
    {
        if (receiptId.HasValue && ReceiptId != receiptId.Value) ReceiptId = receiptId.Value;
        if (receivable.HasValue && Receivable != receivable.Value) Receivable = receivable.Value;
        if (debt.HasValue && Debt != debt.Value) Debt = debt.Value;
        if (cash.HasValue && Cash != cash.Value) Cash = cash.Value;
        if (credit.HasValue && Credit != credit.Value) Credit = credit.Value;
        if (finance.HasValue && Finance != finance.Value) Finance = finance.Value;
        if (bank.HasValue && Bank != bank.Value) Bank = bank.Value;
        if (cheque.HasValue && Cheque != cheque.Value) Cheque = cheque.Value;
        if (promissory.HasValue && Promissory != promissory.Value) Promissory = promissory.Value;
        if (total.HasValue && Total != total.Value) Total = total.Value;
        if (!string.IsNullOrEmpty(paymentType) && !PaymentType.Equals(paymentType)) PaymentType = paymentType;
        if (!string.IsNullOrEmpty(caseReceipt) && !CaseReceipt.Equals(caseReceipt)) CaseReceipt = caseReceipt;
        if (!string.IsNullOrEmpty(crossReceiptId) && !CrossReceiptId.Equals(crossReceiptId)) CrossReceiptId = crossReceiptId;
        if (!string.IsNullOrEmpty(installment) && !Installment.Equals(installment)) Installment = installment;
        if (customerId.HasValue && CustomerId != customerId.Value) CustomerId = customerId.Value;
        if (!string.IsNullOrEmpty(crossCustomerId) && !CrossCustomerId.Equals(crossCustomerId)) CrossCustomerId = crossCustomerId;
        if (!string.IsNullOrEmpty(crossCaseId) && !CrossCaseId.Equals(crossCaseId)) CrossCaseId = crossCaseId;
        if (exchange.HasValue && Exchange != exchange.Value) Exchange = exchange.Value;
        if (receiptDate.HasValue && ReceiptDate != receiptDate.Value) ReceiptDate = receiptDate.Value;
        if (!string.IsNullOrEmpty(chequeNo) && !ChequeNo.Equals(chequeNo)) ChequeNo = chequeNo;
        if (logoTransStatus.HasValue && LogoTransStatus != logoTransStatus.Value) LogoTransStatus = logoTransStatus.Value;
        if (!string.IsNullOrEmpty(logoTransDesc) && !LogoTransDesc.Equals(logoTransDesc)) LogoTransDesc = logoTransDesc;
        if (!string.IsNullOrEmpty(caseIntegrationCode) && !CaseIntegrationCode.Equals(caseIntegrationCode)) CaseIntegrationCode = caseIntegrationCode;
        if (!string.IsNullOrEmpty(logoNumber) && !LogoNumber.Equals(logoNumber)) LogoNumber = logoNumber;
        if (logicalRef.HasValue && LogicalRef != logicalRef.Value) LogicalRef = logicalRef.Value;

        return this;
    }

    
}
