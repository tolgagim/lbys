

namespace Server.Domain.Catalog;

public class ReceiptItem : AuditableEntity, IAggregateRoot
{
    public Guid ReceiptId { get; private set; }
    public int PayPlanRefId { get; private set; }
    public string PayPlanCode { get; private set; }
    public Guid ProductId { get; private set; }
    public virtual Product Product { get; private set; }
    public string BarCode { get; private set; }
    public int UnitCodeId { get; private set; }
    public string UnitCode { get; private set; }
    public decimal UnitConvFact1 { get; private set; }
    public decimal UnitConvFact2 { get; private set; }
    public DateTime Date { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal Price { get; private set; }
    public short IncludeVat { get; private set; } = 1;
    public decimal VatRate { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Discount { get; private set; }
    public decimal DiscountRate { get; private set; }
    public decimal NetTotal { get; private set; }
    public decimal TotalVat { get; private set; }
    public decimal GrossTotal { get; private set; }
    public string LineDescription { get; private set; }
    public short IsReserve { get; private set; } = 1;
    public DateTime ReserveDate { get; private set; }
    public decimal RezerveQuantity { get; private set; }
    public short Status { get; private set; }
    public short Cancelled { get; private set; } = 0;
    public int CrossReceiptId { get; private set; }
    public int SourceRefId { get; private set; }
    public string ExemptionCode { get; private set; }
    public bool IncludeDiscoundVat { get; private set; }
    public int WareHouseId { get; private set; }
    public string WareHouseName { get; private set; }
    public decimal ItemIn { get; private set; }
    public decimal ItemOut { get; private set; }

    public ReceiptItem()
    {
    }

    public ReceiptItem(Guid receiptId, int payPlanRefId, string payPlanCode, Guid productId, Product product, string barCode,
                       int unitCodeId, string unitCode, decimal unitConvFact1, decimal unitConvFact2, DateTime date, decimal quantity,
                       decimal price, short includeVat, decimal vatRate, decimal amount, decimal discount, decimal discountRate,
                       decimal netTotal, decimal totalVat, decimal grossTotal, string lineDescription, short isReserve,
                       DateTime reserveDate, decimal rezerveQuantity, short status, short cancelled, int crossReceiptId,
                       int sourceRefId, string exemptionCode, bool includeDiscoundVat, int wareHouseId, string wareHouseName,
                       decimal itemIn, decimal itemOut)
    {
        ReceiptId = receiptId;
        PayPlanRefId = payPlanRefId;
        PayPlanCode = payPlanCode;
        ProductId = productId;
        Product = product;
        BarCode = barCode;
        UnitCodeId = unitCodeId;
        UnitCode = unitCode;
        UnitConvFact1 = unitConvFact1;
        UnitConvFact2 = unitConvFact2;
        Date = date;
        Quantity = quantity;
        Price = price;
        IncludeVat = includeVat;
        VatRate = vatRate;
        Amount = amount;
        Discount = discount;
        DiscountRate = discountRate;
        NetTotal = netTotal;
        TotalVat = totalVat;
        GrossTotal = grossTotal;
        LineDescription = lineDescription;
        IsReserve = isReserve;
        ReserveDate = reserveDate;
        RezerveQuantity = rezerveQuantity;
        Status = status;
        Cancelled = cancelled;
        CrossReceiptId = crossReceiptId;
        SourceRefId = sourceRefId;
        ExemptionCode = exemptionCode;
        IncludeDiscoundVat = includeDiscoundVat;
        WareHouseId = wareHouseId;
        WareHouseName = wareHouseName;
        ItemIn = itemIn;
        ItemOut = itemOut;
    }

    public ReceiptItem Update(Guid? receiptId, int? payPlanRefId, string? payPlanCode, Guid? productId, Product? product,
                              string? barCode, int? unitCodeId, string? unitCode, decimal? unitConvFact1, decimal? unitConvFact2,
                              DateTime? date, decimal? quantity, decimal? price, short? includeVat, decimal? vatRate,
                              decimal? amount, decimal? discount, decimal? discountRate, decimal? netTotal, decimal? totalVat,
                              decimal? grossTotal, string? lineDescription, short? isReserve, DateTime? reserveDate,
                              decimal? rezerveQuantity, short? status, short? cancelled, int? crossReceiptId, int? sourceRefId,
                              string? exemptionCode, bool? includeDiscoundVat, int? wareHouseId, string? wareHouseName,
                              decimal? itemIn, decimal? itemOut)
    {
        if (receiptId.HasValue && ReceiptId != receiptId.Value) ReceiptId = receiptId.Value;
        if (payPlanRefId.HasValue && PayPlanRefId != payPlanRefId.Value) PayPlanRefId = payPlanRefId.Value;
        if (!string.IsNullOrEmpty(payPlanCode) && !PayPlanCode.Equals(payPlanCode)) PayPlanCode = payPlanCode;
        if (productId.HasValue && ProductId != productId.Value) ProductId = productId.Value;
        if (product != null && Product != product) Product = product;
        if (!string.IsNullOrEmpty(barCode) && !BarCode.Equals(barCode)) BarCode = barCode;
        if (unitCodeId.HasValue && UnitCodeId != unitCodeId.Value) UnitCodeId = unitCodeId.Value;
        if (!string.IsNullOrEmpty(unitCode) && !UnitCode.Equals(unitCode)) UnitCode = unitCode;
        if (unitConvFact1.HasValue && UnitConvFact1 != unitConvFact1.Value) UnitConvFact1 = unitConvFact1.Value;
        if (unitConvFact2.HasValue && UnitConvFact2 != unitConvFact2.Value) UnitConvFact2 = unitConvFact2.Value;
        if (date.HasValue && Date != date.Value) Date = date.Value;
        if (quantity.HasValue && Quantity != quantity.Value) Quantity = quantity.Value;
        if (price.HasValue && Price != price.Value) Price = price.Value;
        if (includeVat.HasValue && IncludeVat != includeVat.Value) IncludeVat = includeVat.Value;
        if (vatRate.HasValue && VatRate != vatRate.Value) VatRate = vatRate.Value;
        if (amount.HasValue && Amount != amount.Value) Amount = amount.Value;
        if (discount.HasValue && Discount != discount.Value) Discount = discount.Value;
        if (discountRate.HasValue && DiscountRate != discountRate.Value) DiscountRate = discountRate.Value;
        if (netTotal.HasValue && NetTotal != netTotal.Value) NetTotal = netTotal.Value;
        if (totalVat.HasValue && TotalVat != totalVat.Value) TotalVat = totalVat.Value;
        if (grossTotal.HasValue && GrossTotal != grossTotal.Value) GrossTotal = grossTotal.Value;
        if (!string.IsNullOrEmpty(lineDescription) && !LineDescription.Equals(lineDescription)) LineDescription = lineDescription;
        if (isReserve.HasValue && IsReserve != isReserve.Value) IsReserve = isReserve.Value;
        if (reserveDate.HasValue && ReserveDate != reserveDate.Value) ReserveDate = reserveDate.Value;
        if (rezerveQuantity.HasValue && RezerveQuantity != rezerveQuantity.Value) RezerveQuantity = rezerveQuantity.Value;
        if (status.HasValue && Status != status.Value) Status = status.Value;
        if (cancelled.HasValue && Cancelled != cancelled.Value) Cancelled = cancelled.Value;
        if (crossReceiptId.HasValue && CrossReceiptId != crossReceiptId.Value) CrossReceiptId = crossReceiptId.Value;
        if (sourceRefId.HasValue && SourceRefId != sourceRefId.Value) SourceRefId = sourceRefId.Value;
        if (!string.IsNullOrEmpty(exemptionCode) && !ExemptionCode.Equals(exemptionCode)) ExemptionCode = exemptionCode;
        if (includeDiscoundVat.HasValue && IncludeDiscoundVat != includeDiscoundVat.Value) IncludeDiscoundVat = includeDiscoundVat.Value;
        if (wareHouseId.HasValue && WareHouseId != wareHouseId.Value) WareHouseId = wareHouseId.Value;
        if (!string.IsNullOrEmpty(wareHouseName) && !WareHouseName.Equals(wareHouseName)) WareHouseName = wareHouseName;
        if (itemIn.HasValue && ItemIn != itemIn.Value) ItemIn = itemIn.Value;
        if (itemOut.HasValue && ItemOut != itemOut.Value) ItemOut = itemOut.Value;

        return this;
    }
     
}

