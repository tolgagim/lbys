 

namespace Server.Domain.Catalog;

/// <summary>
/// Fatura Fis
/// </summary>
    public class Receipt : AuditableEntity, IAggregateRoot
    {
        public int ReceiptType { get; private set; } // 0 fatura 1 irsaliye 2 sipariş cemdeki documentTypeId
        public string ReceiptTypeName { get; private set; }
        public int SalesManRef { get; private set; }
        public string SalesManCode { get; private set; }
        public short Type { get; private set; } // 1 alış -2 satış
        public short Status { get; private set; }
        public string PayPlanCode { get; private set; } // ÖDEME PLANI KODU Logoda olması gerekir
        public Guid? CustomerId { get; private set; }
        public virtual Customer Customer { get; private set; }
        public Guid? RetailId { get; private set; }
        public virtual Retail Retail { get; private set; }
        public DateTime ReceiptDate { get; private set; } // Tarih
        public string ReceiptNo { get; private set; } // Fatura Numarası
        public string DocumentNo { get; private set; }
        public string TrackingNumber { get; private set; }
        public string SpeCode { get; private set; } // SpeCode 
        public string PolicyCode { get; private set; } // CYPHcODE
        public decimal Total { get; private set; } // Toplam Tutar
        public decimal TotalVat { get; private set; } // Toplam KDV
        public decimal VateRate { get; private set; } //
        public decimal TotalDiscount { get; private set; } // Toplam İndirim
        public decimal DiscountRate { get; private set; } //
        public decimal NetTotal { get; private set; }
        public virtual List<ReceiptItem>? ReceiptItems { get; private set; }
        public virtual List<ReceiptPayment>? ReceiptPayments { get; private set; }
        public bool LogoTransStatus { get; private set; } = false;
        public string? LogoTransDesc { get; private set; }
        public string Note1 { get; private set; }
        public string Note2 { get; private set; }
        public string Note3 { get; private set; }
        public string Note4 { get; private set; }
        public string Note5 { get; private set; }
        public string Note6 { get; private set; }
        public short EInvoiceType { get; private set; } // 0 kağıt 1 efatura 2 earşiv  
        public string CrossDocumentNo { get; private set; } // Müşterinin sipariş numarası var ise
        public short RiskAffect { get; private set; } // Müşterinin fiş bazlı risk var mı?
        public string CostCenter { get; private set; } // Masraf Merkezi
        public string Ettn { get; private set; }
        public short IsCancelled { get; private set; }
        public short Returned { get; private set; }
        public string LogoNumber { get; private set; }
        public int LogicalRef { get; private set; }
        public int WareHouseSourceCode { get; private set; }
        public int WareHouseTargetCode { get; private set; }
        public bool Locked { get; private set; }

        public Receipt()
        {
        }

        public Receipt(int receiptType, string receiptTypeName, int salesManRef, string salesManCode, short type, short status, string payPlanCode,
                       Guid? customerId, Customer customer, Guid? retailId, Retail retail, DateTime receiptDate, string receiptNo, string documentNo,
                       string trackingNumber, string speCode, string policyCode, decimal total, decimal totalVat, decimal vateRate,
                       decimal totalDiscount, decimal discountRate, decimal netTotal, List<ReceiptItem>? receiptItems,
                       List<ReceiptPayment>? receiptPayments, bool logoTransStatus, string? logoTransDesc, string note1, string note2,
                       string note3, string note4, string note5, string note6, short eInvoiceType, string crossDocumentNo,
                       short riskAffect, string costCenter, string ettn, short isCancelled, short returned, string logoNumber,
                       int logicalRef, int wareHouseSourceCode, int wareHouseTargetCode, bool locked)
        {
            ReceiptType = receiptType;
            ReceiptTypeName = receiptTypeName;
            SalesManRef = salesManRef;
            SalesManCode = salesManCode;
            Type = type;
            Status = status;
            PayPlanCode = payPlanCode;
            CustomerId = customerId;
            Customer = customer;
            RetailId = retailId;
            Retail = retail;
            ReceiptDate = receiptDate;
            ReceiptNo = receiptNo;
            DocumentNo = documentNo;
            TrackingNumber = trackingNumber;
            SpeCode = speCode;
            PolicyCode = policyCode;
            Total = total;
            TotalVat = totalVat;
            VateRate = vateRate;
            TotalDiscount = totalDiscount;
            DiscountRate = discountRate;
            NetTotal = netTotal;
            ReceiptItems = receiptItems;
            ReceiptPayments = receiptPayments;
            LogoTransStatus = logoTransStatus;
            LogoTransDesc = logoTransDesc;
            Note1 = note1;
            Note2 = note2;
            Note3 = note3;
            Note4 = note4;
            Note5 = note5;
            Note6 = note6;
            EInvoiceType = eInvoiceType;
            CrossDocumentNo = crossDocumentNo;
            RiskAffect = riskAffect;
            CostCenter = costCenter;
            Ettn = ettn;
            IsCancelled = isCancelled;
            Returned = returned;
            LogoNumber = logoNumber;
            LogicalRef = logicalRef;
            WareHouseSourceCode = wareHouseSourceCode;
            WareHouseTargetCode = wareHouseTargetCode;
            Locked = locked;
        }

        public Receipt Update(int? receiptType, string? receiptTypeName, int? salesManRef, string? salesManCode, short? type, short? status,
                              string? payPlanCode, Guid? customerId, Customer? customer, Guid? retailId, Retail? retail, DateTime? receiptDate,
                              string? receiptNo, string? documentNo, string? trackingNumber, string? speCode, string? policyCode, decimal? total,
                              decimal? totalVat, decimal? vateRate, decimal? totalDiscount, decimal? discountRate, decimal? netTotal,
                              List<ReceiptItem>? receiptItems, List<ReceiptPayment>? receiptPayments, bool? logoTransStatus, string? logoTransDesc,
                              string? note1, string? note2, string? note3, string? note4, string? note5, string? note6, short? eInvoiceType,
                              string? crossDocumentNo, short? riskAffect, string? costCenter, string? ettn, short? isCancelled, short? returned,
                              string? logoNumber, int? logicalRef, int? wareHouseSourceCode, int? wareHouseTargetCode, bool? locked)
        {
            if (receiptType.HasValue && ReceiptType != receiptType.Value) ReceiptType = receiptType.Value;
            if (!string.IsNullOrEmpty(receiptTypeName) && !ReceiptTypeName.Equals(receiptTypeName)) ReceiptTypeName = receiptTypeName;
            if (salesManRef.HasValue && SalesManRef != salesManRef.Value) SalesManRef = salesManRef.Value;
            if (!string.IsNullOrEmpty(salesManCode) && !SalesManCode.Equals(salesManCode)) SalesManCode = salesManCode;
            if (type.HasValue && Type != type.Value) Type = type.Value;
            if (status.HasValue && Status != status.Value) Status = status.Value;
            if (!string.IsNullOrEmpty(payPlanCode) && !PayPlanCode.Equals(payPlanCode)) PayPlanCode = payPlanCode;
            if (customerId.HasValue && CustomerId != customerId.Value) CustomerId = customerId.Value;
            if (customer != null && Customer != customer) Customer = customer;
            if (retailId.HasValue && RetailId != retailId.Value) RetailId = retailId.Value;
            if (retail != null && Retail != retail) Retail = retail;
            if (receiptDate.HasValue && ReceiptDate != receiptDate.Value) ReceiptDate = receiptDate.Value;
            if (!string.IsNullOrEmpty(receiptNo) && !ReceiptNo.Equals(receiptNo)) ReceiptNo = receiptNo;
            if (!string.IsNullOrEmpty(documentNo) && !DocumentNo.Equals(documentNo)) DocumentNo = documentNo;
            if (!string.IsNullOrEmpty(trackingNumber) && !TrackingNumber.Equals(trackingNumber)) TrackingNumber = trackingNumber;
            if (!string.IsNullOrEmpty(speCode) && !SpeCode.Equals(speCode)) SpeCode = speCode;
            if (!string.IsNullOrEmpty(policyCode) && !PolicyCode.Equals(policyCode)) PolicyCode = policyCode;
            if (total.HasValue && Total != total.Value) Total = total.Value;
            if (totalVat.HasValue && TotalVat != totalVat.Value) TotalVat = totalVat.Value;
            if (vateRate.HasValue && VateRate != vateRate.Value) VateRate = vateRate.Value;
            if (totalDiscount.HasValue && TotalDiscount != totalDiscount.Value) TotalDiscount = totalDiscount.Value;
            if (discountRate.HasValue && DiscountRate != discountRate.Value) DiscountRate = discountRate.Value;
            if (netTotal.HasValue && NetTotal != netTotal.Value) NetTotal = netTotal.Value;
            if (receiptItems != null) ReceiptItems = receiptItems;
            if (receiptPayments != null) ReceiptPayments = receiptPayments;
            if (logoTransStatus.HasValue && LogoTransStatus != logoTransStatus.Value) LogoTransStatus = logoTransStatus.Value;
            if (!string.IsNullOrEmpty(logoTransDesc) && !LogoTransDesc.Equals(logoTransDesc)) LogoTransDesc = logoTransDesc;
            if (!string.IsNullOrEmpty(note1) && !Note1.Equals(note1)) Note1 = note1;
            if (!string.IsNullOrEmpty(note2) && !Note2.Equals(note2)) Note2 = note2;
            if (!string.IsNullOrEmpty(note3) && !Note3.Equals(note3)) Note3 = note3;
            if (!string.IsNullOrEmpty(note4) && !Note4.Equals(note4)) Note4 = note4;
            if (!string.IsNullOrEmpty(note5) && !Note5.Equals(note5)) Note5 = note5;
            if (!string.IsNullOrEmpty(note6) && !Note6.Equals(note6)) Note6 = note6;
            if (eInvoiceType.HasValue && EInvoiceType != eInvoiceType.Value) EInvoiceType = eInvoiceType.Value;
            if (!string.IsNullOrEmpty(crossDocumentNo) && !CrossDocumentNo.Equals(crossDocumentNo)) CrossDocumentNo = crossDocumentNo;
            if (riskAffect.HasValue && RiskAffect != riskAffect.Value) RiskAffect = riskAffect.Value;
            if (!string.IsNullOrEmpty(costCenter) && !CostCenter.Equals(costCenter)) CostCenter = costCenter;
            if (!string.IsNullOrEmpty(ettn) && !Ettn.Equals(ettn)) Ettn = ettn;
            if (isCancelled.HasValue && IsCancelled != isCancelled.Value) IsCancelled = isCancelled.Value;
            if (returned.HasValue && Returned != returned.Value) Returned = returned.Value;
            if (!string.IsNullOrEmpty(logoNumber) && !LogoNumber.Equals(logoNumber)) LogoNumber = logoNumber;
            if (logicalRef.HasValue && LogicalRef != logicalRef.Value) LogicalRef = logicalRef.Value;
            if (wareHouseSourceCode.HasValue && WareHouseSourceCode != wareHouseSourceCode.Value) WareHouseSourceCode = wareHouseSourceCode.Value;
            if (wareHouseTargetCode.HasValue && WareHouseTargetCode != wareHouseTargetCode.Value) WareHouseTargetCode = wareHouseTargetCode.Value;
            if (locked.HasValue && Locked != locked.Value) Locked = locked.Value;

            return this;
        }
    }
 
