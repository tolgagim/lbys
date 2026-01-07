using System.ComponentModel.DataAnnotations.Schema;
using Server.Domain.Common.Contracts;

namespace Server.Domain.Lbys.Common;

/// <summary>
/// VEM Entity Base Class
/// String primary key ve VEM audit alanlari ile
/// </summary>
public abstract class VemEntity : IEntity, IAggregateRoot
{
    // Her entity kendi PK'sini tanimlar (HASTA_KODU, AMELIYAT_KODU vs.)

    // VEM Audit Fields
    public string? EKLEYEN_KULLANICI_KODU { get; set; }
    public DateTime? KAYIT_ZAMANI { get; set; }
    public string? GUNCELLEYEN_KULLANICI_KODU { get; set; }
    public DateTime? GUNCELLEME_ZAMANI { get; set; }

    [NotMapped]
    [System.Text.Json.Serialization.JsonIgnore]
    public List<DomainEvent> DomainEvents { get; } = new();
}
