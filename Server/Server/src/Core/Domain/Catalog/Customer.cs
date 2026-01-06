
namespace Server.Domain.Catalog;
public class Customer : AuditableEntity, IAggregateRoot
{
    public string? Code { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? TaxNumber { get; private set; }
    public string? TaxOffice { get; private set; }
    public string? Address { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? MobileNumber { get; private set; }
    public string? EntCode { get; private set; }
    public bool Status { get; private set; }

    public short CardType { get; private set; } = 1;
    public string? CountryCode { get; private set; }
    public string? Country { get; private set; }
    public string? CityCode { get; private set; }
    public string? City { get; private set; }
    public string? DistrictCode { get; private set; }
    public string? District { get; private set; }
    public string? PostCode { get; private set; }
    public string? Address2 { get; private set; }
    public string? Email { get; private set; }
    public string? SourceRef { get; private set; }
    public short? SourceTypeRef { get; private set; }
    public string? SpeCode { get; private set; }
    public string? SpeCode2 { get; private set; }
    public string? SpeCode3 { get; private set; }
    public string? SpeCode4 { get; private set; }
    public string? SpeCode5 { get; private set; }
    public string? Contact { get; private set; }
    public int PayPlan { get; private set; }
    public string? BranchName { get; private set; }


    public Customer()
    {
    }

    public Customer(string code, string name, string? description, string? taxNumber, string? taxOffice, string? address, string? phoneNumber, string? mobileNumber, string? entCode)
    {
        Code = code;
        Name = name;
        Description = description;
        TaxNumber = taxNumber;
        TaxOffice = taxOffice;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        Status = true;
        EntCode = entCode;
    }
    public Customer(string code, string name, string? description, string? taxNumber, string? taxOffice, string? address, string? phoneNumber, string? mobileNumber, string? entCode, short cardType, string? countryCode, string? country, string? cityCode, string? city, string? districtCode, string? district, string? postCode, string? address2, string? email, string? sourceRef, short? sourceTypeRef, string? speCode, string? speCode2, string? speCode3, string? speCode4, string? speCode5, string contact, int payPlan, string branchName)
    {
        Code = code;
        Name = name;
        Description = description;
        TaxNumber = taxNumber;
        TaxOffice = taxOffice;
        Address = address;
        PhoneNumber = phoneNumber;
        MobileNumber = mobileNumber;
        EntCode = entCode;
        Status = true;
        CardType = cardType;
        CountryCode = countryCode;
        Country = country;
        CityCode = cityCode;
        City = city;
        DistrictCode = districtCode;
        District = district;
        PostCode = postCode;
        Address2 = address2;
        Email = email;
        SourceRef = sourceRef;
        SourceTypeRef = sourceTypeRef;
        SpeCode = speCode;
        SpeCode2 = speCode2;
        SpeCode3 = speCode3;
        SpeCode4 = speCode4;
        SpeCode5 = speCode5;
        Contact = contact;
        PayPlan = payPlan;
        BranchName = branchName;
    }


    public Customer Update(string? name, string? description, string? taxNumber, string? taxOffice, string? address, string? phoneNumber, string? mobileNumber, string? entCode)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (taxNumber is not null && TaxNumber?.Equals(taxNumber) is not true) TaxNumber = taxNumber;
        if (taxOffice is not null && TaxOffice?.Equals(taxOffice) is not true) TaxOffice = taxOffice;
        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (phoneNumber is not null && PhoneNumber?.Equals(phoneNumber) is not true) PhoneNumber = phoneNumber;
        if (mobileNumber is not null && MobileNumber?.Equals(mobileNumber) is not true) MobileNumber = mobileNumber;
        if (entCode is not null && Name?.Equals(entCode) is not true) EntCode = entCode;
        return this;
    }

    public Customer Update(string? code, string? name, string? description, string? taxNumber, string? taxOffice, string? address, string? phoneNumber, string? mobileNumber, string? entCode, short? cardType, string? countryCode, string? country, string? cityCode, string? city, string? districtCode, string? district, string? postCode, string? address2, string? email, string? sourceRef, short? sourceTypeRef, string? speCode, string? speCode2, string? speCode3, string? speCode4, string? speCode5, string? contact, int? payPlan, string? branchName)
    {
        if (code != null && Code != code) Code = code;
        if (name != null && Name != name) Name = name;
        if (description != null && Description != description) Description = description;
        if (taxNumber != null && TaxNumber != taxNumber) TaxNumber = taxNumber;
        if (taxOffice != null && TaxOffice != taxOffice) TaxOffice = taxOffice;
        if (address != null && Address != address) Address = address;
        if (phoneNumber != null && PhoneNumber != phoneNumber) PhoneNumber = phoneNumber;
        if (mobileNumber != null && MobileNumber != mobileNumber) MobileNumber = mobileNumber;
        if (entCode != null && EntCode != entCode) EntCode = entCode;
        if (cardType != null && CardType != cardType) CardType = cardType.Value;
        if (countryCode != null && CountryCode != countryCode) CountryCode = countryCode;
        if (country != null && Country != country) Country = country;
        if (cityCode != null && CityCode != cityCode) CityCode = cityCode;
        if (city != null && City != city) City = city;
        if (districtCode != null && DistrictCode != districtCode) DistrictCode = districtCode;
        if (district != null && District != district) District = district;
        if (postCode != null && PostCode != postCode) PostCode = postCode;
        if (address2 != null && Address2 != address2) Address2 = address2;
        if (email != null && Email != email) Email = email;
        if (sourceRef != null && SourceRef != sourceRef) SourceRef = sourceRef;
        if (sourceTypeRef != null && SourceTypeRef != sourceTypeRef) SourceTypeRef = sourceTypeRef;
        if (speCode != null && SpeCode != speCode) SpeCode = speCode;
        if (speCode2 != null && SpeCode2 != speCode2) SpeCode2 = speCode2;
        if (speCode3 != null && SpeCode3 != speCode3) SpeCode3 = speCode3;
        if (speCode4 != null && SpeCode4 != speCode4) SpeCode4 = speCode4;
        if (speCode5 != null && SpeCode5 != speCode5) SpeCode5 = speCode5;
        if (contact != null && Contact != contact) Contact = contact;
        if (payPlan != null && PayPlan != payPlan) PayPlan = payPlan.Value;
        if (branchName != null && BranchName != branchName) BranchName = branchName;
        return this;
    }


    public Customer UpdateStatus(bool status)
    {
        Status = status;
        return this;
    }
}

