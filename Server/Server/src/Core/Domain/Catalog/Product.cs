namespace Server.Domain.Catalog;

public class Product : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public decimal Rate { get; private set; }
    public string? ImagePath { get; private set; }
    public Guid BrandId { get; private set; }
    public virtual Brand Brand { get; private set; } = default!;
    public int? CardType { get; private set; }
    public short Status { get; private set; } = 1;
    public string? Code { get; private set; }
    public string? ProducerCode { get; private set; }
    public string? GroupCode { get; private set; }
    public int? UnitSetRef { get; private set; }
    public string? UnitSetCode { get; private set; }
    public string? UnitSetName { get; private set; }
    public string? Barcode { get; private set; }
    public double? PurchaseVat { get; private set; }
    public bool? PurchaseBrowse { get; private set; }
    public bool? SellBrowse { get; private set; }
    public double? SellVat { get; private set; }
    public double? SellPrice { get; private set; }
    public double? PurchasePrice { get; private set; }
    public string? Note { get; private set; }
    public string? SourceRef { get; private set; }
    public short? SourceTypeRef { get; private set; }
    public string? SpeCode { get; private set; }
    public string? SpeCode2 { get; private set; }
    public string? SpeCode3 { get; private set; }
    public string? SpeCode4 { get; private set; }
    public string? SpeCode5 { get; private set; }

    public Product()
    {
       
    }

    public Product(string name, string? code, string? description, decimal rate, Guid brandId, string? imagePath)
    {
        Name = name;
        Code = code;
        Description = description;
        Rate = rate;
        ImagePath = imagePath;
        BrandId = brandId;
    }
    public Product(string name, string? description, decimal rate, string? imagePath, Guid brandId, int cardType, short status, string? code, string? producerCode, string? groupCode, int? unitSetRef, string? unitSetCode, string unitSetName, string? barcode, double? purchaseVat, bool? purchaseBrowse, bool? sellBrowse, double? sellVat, double? sellPrice, double? purchasePrice, string? note, string sourceRef, short sourceTypeRef, string? speCode, string? speCode2, string? speCode3, string? speCode4, string? speCode5)
    {
        Name = name;
        Description = description;
        Rate = rate;
        ImagePath = imagePath;
        BrandId = brandId;
        CardType = cardType;
        Status = status;
        Code = code;
        ProducerCode = producerCode;
        GroupCode = groupCode;
        UnitSetRef = unitSetRef;
        UnitSetCode = unitSetCode;
        UnitSetName = unitSetName;
        Barcode = barcode;
        PurchaseVat = purchaseVat;
        PurchaseBrowse = purchaseBrowse;
        SellBrowse = sellBrowse;
        SellVat = sellVat;
        SellPrice = sellPrice;
        PurchasePrice = purchasePrice;
        Note = note;
        SourceRef = sourceRef;
        SourceTypeRef = sourceTypeRef;
        SpeCode = speCode;
        SpeCode2 = speCode2;
        SpeCode3 = speCode3;
        SpeCode4 = speCode4;
        SpeCode5 = speCode5;
    }


    public Product Update(string? name, string? description, decimal? rate, Guid? brandId, string? imagePath)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (rate.HasValue && Rate != rate) Rate = rate.Value;
        if (brandId.HasValue && brandId.Value != Guid.Empty && !BrandId.Equals(brandId.Value)) BrandId = brandId.Value;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;
        return this;
    }


    public Product Update(string? name, string? description, string? imagePath, decimal? rate, Guid? brandId, int? cardType, short? status, string? code, string? producerCode, string? groupCode, int? unitSetRef, string? unitSetCode, string? barcode, double? purchaseVat, bool? purchaseBrowse, bool? sellBrowse, double? sellVat, double? sellPrice, double? purchasePrice, string? note, string? speCode, string? speCode2, string? speCode3, string? speCode4, string? speCode5)
    {
        if (name != null && Name != name) Name = name;
        if (description != null && Description != description) Description = description;
        if (imagePath != null && ImagePath != imagePath) ImagePath = imagePath;
        if (rate != null && Rate != rate) Rate = rate.Value;
        if (brandId != null && BrandId != brandId) BrandId = brandId.Value;
        if (cardType != null && CardType != cardType) CardType = cardType.Value;
        if (status != null && Status != status) Status = status.Value;
        if (code != null && Code != code) Code = code;
        if (producerCode != null && ProducerCode != producerCode) ProducerCode = producerCode;
        if (groupCode != null && GroupCode != groupCode) GroupCode = groupCode;
        if (unitSetRef != null && UnitSetRef != unitSetRef) UnitSetRef = unitSetRef;
        if (unitSetCode != null && UnitSetCode != unitSetCode) UnitSetCode = unitSetCode;
        if (barcode != null && Barcode != barcode) Barcode = barcode;
        if (purchaseVat != null && PurchaseVat != purchaseVat) PurchaseVat = purchaseVat;
        if (purchaseBrowse != null && PurchaseBrowse != purchaseBrowse) PurchaseBrowse = purchaseBrowse;
        if (sellBrowse != null && SellBrowse != sellBrowse) SellBrowse = sellBrowse;
        if (sellVat != null && SellVat != sellVat) SellVat = sellVat;
        if (sellPrice != null && SellPrice != sellPrice) SellPrice = sellPrice;
        if (purchasePrice != null && PurchasePrice != purchasePrice) PurchasePrice = purchasePrice;
        if (note != null && Note != note) Note = note;
        if (speCode != null && SpeCode != speCode) SpeCode = speCode;
        if (speCode2 != null && SpeCode2 != speCode2) SpeCode2 = speCode2;
        if (speCode3 != null && SpeCode3 != speCode3) SpeCode3 = speCode3;
        if (speCode4 != null && SpeCode4 != speCode4) SpeCode4 = speCode4;
        if (speCode5 != null && SpeCode5 != speCode5) SpeCode5 = speCode5;
        return this;
    }
    public Product ClearImagePath()
    {
        ImagePath = string.Empty;
        return this;
    }
}