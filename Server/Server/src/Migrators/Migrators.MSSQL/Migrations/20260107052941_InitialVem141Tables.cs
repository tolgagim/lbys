using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialVem141Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lbys");

            migrationBuilder.EnsureSchema(
                name: "Auditing");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                schema: "Auditing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EK_ODEME_DONEM",
                schema: "Lbys",
                columns: table => new
                {
                    EK_ODEME_DONEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BORDRO_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIRISIMSEL_ISLEM_PUAN_TOPLAMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OZELLIKLI_ISLEM_PUAN_TOPLAMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACGK_TOPLAMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAGITILACAK_EKODEME_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EK_ODEME_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HASTANE_PUAN_ORTALAMASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EK_ODEME_DONEM", x => x.EK_ODEME_DONEM_KODU);
                });

            migrationBuilder.CreateTable(
                name: "FIRMA",
                schema: "Lbys",
                columns: table => new
                {
                    FIRMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FIRMA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEFON_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YETKILI_KISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRMA_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AKTIFLIK_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VERGI_DAIRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VERGI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPOSTA_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBAN_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIRMA", x => x.FIRMA_KODU);
                });

            migrationBuilder.CreateTable(
                name: "KULLANICI_GRUP",
                schema: "Lbys",
                columns: table => new
                {
                    KULLANICI_GRUP_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULLANICI_GRUP_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AKTIFLIK_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KULLANICI_GRUP", x => x.KULLANICI_GRUP_KODU);
                });

            migrationBuilder.CreateTable(
                name: "REFERANS_KODLAR",
                schema: "Lbys",
                columns: table => new
                {
                    REFERANS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KOD_TURU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERANS_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKRS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MKYS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIG_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFERANS_KODLAR", x => x.REFERANS_KODU);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SILINEN_KAYITLAR",
                schema: "Lbys",
                columns: table => new
                {
                    SILINEN_KAYITLAR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    REFERANS_GORUNTU_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SILINME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SILINEN_KAYDIN_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SILINEN_KAYITLAR", x => x.SILINEN_KAYITLAR_KODU);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObjectId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    EntCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BINA",
                schema: "Lbys",
                columns: table => new
                {
                    BINA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BINA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BINA_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKRS_KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BINA", x => x.BINA_KODU);
                    table.ForeignKey(
                        name: "FK_BINA_REFERANS_KODLAR_SKRS_KURUM_KODU",
                        column: x => x.SKRS_KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TC_KIMLIK_NO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOYAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CINSIYET = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DOGUM_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOGUM_YERI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ANA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BABA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAN_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MEDENI_HAL = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UYRUK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MESLEK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EGITIM_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IL_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ILCE_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADRES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TELEFON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP_TELEFON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SOSYAL_GUVENCE = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SIGORTA_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROTOKOL_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    OLUM_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA", x => x.HASTA_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_REFERANS_KODLAR_CINSIYET",
                        column: x => x.CINSIYET,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_REFERANS_KODLAR_KAN_GRUBU",
                        column: x => x.KAN_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_REFERANS_KODLAR_MEDENI_HAL",
                        column: x => x.MEDENI_HAL,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_REFERANS_KODLAR_SOSYAL_GUVENCE",
                        column: x => x.SOSYAL_GUVENCE,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HIZMET",
                schema: "Lbys",
                columns: table => new
                {
                    HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HIZMET_ISLEM_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HIZMET_ISLEM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SUT_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HIZMET_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIBBI_ISLEM_PUAN_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HIZMET", x => x.HIZMET_KODU);
                    table.ForeignKey(
                        name: "FK_HIZMET_REFERANS_KODLAR_HIZMET_ISLEM_GRUBU",
                        column: x => x.HIZMET_ISLEM_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HIZMET_REFERANS_KODLAR_HIZMET_ISLEM_TURU",
                        column: x => x.HIZMET_ISLEM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HIZMET_REFERANS_KODLAR_TIBBI_ISLEM_PUAN_BILGISI",
                        column: x => x.TIBBI_ISLEM_PUAN_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ILAC_UYUM",
                schema: "Lbys",
                columns: table => new
                {
                    ILAC_UYUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILAC_UYUMSUZLUK_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRINCI_ILAC_BARKODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRINCI_ETKEN_MADDE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IKINCI_ILAC_BARKODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IKINCI_ETKEN_MADDE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BESIN_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YAS_BASLANGIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YAS_BITIS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CINSIYET = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RENK_SEVIYE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ILAC_UYUM", x => x.ILAC_UYUM_KODU);
                    table.ForeignKey(
                        name: "FK_ILAC_UYUM_REFERANS_KODLAR_BESIN_KODU",
                        column: x => x.BESIN_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ILAC_UYUM_REFERANS_KODLAR_BIRINCI_ETKEN_MADDE_KODU",
                        column: x => x.BIRINCI_ETKEN_MADDE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ILAC_UYUM_REFERANS_KODLAR_BIRINCI_ILAC_BARKODU",
                        column: x => x.BIRINCI_ILAC_BARKODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ILAC_UYUM_REFERANS_KODLAR_CINSIYET",
                        column: x => x.CINSIYET,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ILAC_UYUM_REFERANS_KODLAR_IKINCI_ETKEN_MADDE_KODU",
                        column: x => x.IKINCI_ETKEN_MADDE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ILAC_UYUM_REFERANS_KODLAR_IKINCI_ILAC_BARKODU",
                        column: x => x.IKINCI_ILAC_BARKODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ILAC_UYUM_REFERANS_KODLAR_ILAC_UYUMSUZLUK_TURU",
                        column: x => x.ILAC_UYUMSUZLUK_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ILAC_UYUM_REFERANS_KODLAR_RENK_SEVIYE_KODU",
                        column: x => x.RENK_SEVIYE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KURUL",
                schema: "Lbys",
                columns: table => new
                {
                    KURUL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUL_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAPOR_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEDULA_RAPOR_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEDULA_ALT_RAPOR_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KURUL", x => x.KURUL_KODU);
                    table.ForeignKey(
                        name: "FK_KURUL_REFERANS_KODLAR_MEDULA_ALT_RAPOR_TURU",
                        column: x => x.MEDULA_ALT_RAPOR_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_REFERANS_KODLAR_MEDULA_RAPOR_TURU",
                        column: x => x.MEDULA_RAPOR_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_REFERANS_KODLAR_RAPOR_TURU",
                        column: x => x.RAPOR_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KURUL_ASKERI",
                schema: "Lbys",
                columns: table => new
                {
                    KURUL_ASKERI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUL_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_RAPOR_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEDULA_ALT_RAPOR_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ALKOL_MADDE_BAGIMLILIGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BEDEN_RUH_ILERI_TETKIK_BULGUSU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GECMIS_HASTALIGA_DAIR_KAYIT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GORME_ISITME_KAYBI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PSIKIYATRIK_RAHATSIZLIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UZUVKAYBI_ORTOPEDI_RAHATSIZLIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASAL_HASTALIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASAL_HASTALIK_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KURUL_ASKERI", x => x.KURUL_ASKERI_KODU);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_ALKOL_MADDE_BAGIMLILIGI",
                        column: x => x.ALKOL_MADDE_BAGIMLILIGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_ASAL_HASTALIK",
                        column: x => x.ASAL_HASTALIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_ASAL_HASTALIK_TIPI",
                        column: x => x.ASAL_HASTALIK_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_BEDEN_RUH_ILERI_TETKIK_BULGUSU",
                        column: x => x.BEDEN_RUH_ILERI_TETKIK_BULGUSU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_GECMIS_HASTALIGA_DAIR_KAYIT",
                        column: x => x.GECMIS_HASTALIGA_DAIR_KAYIT,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_GORME_ISITME_KAYBI",
                        column: x => x.GORME_ISITME_KAYBI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_MEDULA_ALT_RAPOR_TURU",
                        column: x => x.MEDULA_ALT_RAPOR_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_MEDULA_RAPOR_TURU",
                        column: x => x.MEDULA_RAPOR_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_PSIKIYATRIK_RAHATSIZLIK",
                        column: x => x.PSIKIYATRIK_RAHATSIZLIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ASKERI_REFERANS_KODLAR_UZUVKAYBI_ORTOPEDI_RAHATSIZLIK",
                        column: x => x.UZUVKAYBI_ORTOPEDI_RAHATSIZLIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KURUM",
                schema: "Lbys",
                columns: table => new
                {
                    KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUM_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KURUM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IL_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ILCE_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADRES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TELEFON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERGI_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VERGI_DAIRESI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KURUM", x => x.KURUM_KODU);
                    table.ForeignKey(
                        name: "FK_KURUM_REFERANS_KODLAR_KURUM_TURU",
                        column: x => x.KURUM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOBETCI_PERSONEL_BILGISI",
                schema: "Lbys",
                columns: table => new
                {
                    NOBETCI_PERSONEL_BILGISI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SKRS_KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KLINIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GOREV_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_GOREV_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NOBET_BASLANGIC_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOBET_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TELEFON_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOBETCI_PERSONEL_BILGISI", x => x.NOBETCI_PERSONEL_BILGISI_KODU);
                    table.ForeignKey(
                        name: "FK_NOBETCI_PERSONEL_BILGISI_REFERANS_KODLAR_GOREV_TURU",
                        column: x => x.GOREV_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOBETCI_PERSONEL_BILGISI_REFERANS_KODLAR_KLINIK_KODU",
                        column: x => x.KLINIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOBETCI_PERSONEL_BILGISI_REFERANS_KODLAR_PERSONEL_GOREV_KODU",
                        column: x => x.PERSONEL_GOREV_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NOBETCI_PERSONEL_BILGISI_REFERANS_KODLAR_SKRS_KURUM_KODU",
                        column: x => x.SKRS_KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STERILIZASYON_PAKET",
                schema: "Lbys",
                columns: table => new
                {
                    STERILIZASYON_PAKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_PAKET_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAKET_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STERILIZASYON_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_PAKET_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PAKET_RAF_OMRU_BITIS_GUN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STERILIZASYON_PAKET", x => x.STERILIZASYON_PAKET_KODU);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_PAKET_REFERANS_KODLAR_STERILIZASYON_PAKET_GRUBU",
                        column: x => x.STERILIZASYON_PAKET_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_PAKET_REFERANS_KODLAR_STERILIZASYON_YONTEMI",
                        column: x => x.STERILIZASYON_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOK_KART",
                schema: "Lbys",
                columns: table => new
                {
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MALZEME_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MKYS_MALZEME_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TASINIR_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MALZEME_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BARKOD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MALZEME_SUT_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RECETE_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MEDULA_CARPANI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EHU_ILAC_GUN_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EHU_ILAC_MAKSIMUM_ADET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EHU_ONAY_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOK_KART", x => x.STOK_KART_KODU);
                    table.ForeignKey(
                        name: "FK_STOK_KART_REFERANS_KODLAR_MALZEME_TIPI",
                        column: x => x.MALZEME_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_KART_REFERANS_KODLAR_RECETE_TURU",
                        column: x => x.RECETE_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEPO",
                schema: "Lbys",
                columns: table => new
                {
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPO_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BINA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MKYS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MKYS_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPO", x => x.DEPO_KODU);
                    table.ForeignKey(
                        name: "FK_DEPO_BINA_BINA_KODU",
                        column: x => x.BINA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BINA",
                        principalColumn: "BINA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DEPO_REFERANS_KODLAR_DEPO_TURU",
                        column: x => x.DEPO_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_ARSIV",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_ARSIV_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ARSIV_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESKI_ARSIV_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARSIV_DEFTER_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ARSIV_YERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARSIV_ILK_GIRIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_ARSIV", x => x.HASTA_ARSIV_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_REFERANS_KODLAR_ARSIV_DEFTER_TURU",
                        column: x => x.ARSIV_DEFTER_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KAN_URUN",
                schema: "Lbys",
                columns: table => new
                {
                    KAN_URUN_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_URUN_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_MIAT_SURESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_MIAT_PERIYODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KIZILAY_BILESEN_TURU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_FILTRELEME_UYGUNLUK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_YIKAMA_UYGUNLUK_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_ISINLAMA_UYGUNLUK_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_HAVUZLAMA_UYGUNLUK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_AYIRMA_UYGUNLUK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_BOLME_UYGUNLUK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUFFYCOAT_UZAKLASTIRMAYA_UYGUN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KAN_URUN", x => x.KAN_URUN_KODU);
                    table.ForeignKey(
                        name: "FK_KAN_URUN_HIZMET_HIZMET_KODU",
                        column: x => x.HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HIZMET",
                        principalColumn: "HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TETKIK",
                schema: "Lbys",
                columns: table => new
                {
                    TETKIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOINC_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RAPOR_SONUC_SIRASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HESAPLAMALI_TETKIK_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HESAPLAMALI_TETKIK_FORMULU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TETKIK", x => x.TETKIK_KODU);
                    table.ForeignKey(
                        name: "FK_TETKIK_HIZMET_HIZMET_KODU",
                        column: x => x.HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HIZMET",
                        principalColumn: "HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BIRIM",
                schema: "Lbys",
                columns: table => new
                {
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRIM_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIRIM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UST_BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIRIM", x => x.BIRIM_KODU);
                    table.ForeignKey(
                        name: "FK_BIRIM_BIRIM_UST_BIRIM_KODU",
                        column: x => x.UST_BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIRIM_KURUM_KURUM_KODU",
                        column: x => x.KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BIRIM_REFERANS_KODLAR_BIRIM_TURU",
                        column: x => x.BIRIM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ICMAL",
                schema: "Lbys",
                columns: table => new
                {
                    ICMAL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ICMAL_DONEMI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICMAL_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICMAL_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ICMAL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ICMAL_TUTARI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMAL", x => x.ICMAL_KODU);
                    table.ForeignKey(
                        name: "FK_ICMAL_KURUM_KURUM_KODU",
                        column: x => x.KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STERILIZASYON_PAKET_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    STERILIZASYON_PAKET_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_PAKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_MALZEME_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OLCU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STERILIZASYON_PAKET_DETAY", x => x.STERILIZASYON_PAKET_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_PAKET_DETAY_REFERANS_KODLAR_OLCU_KODU",
                        column: x => x.OLCU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_PAKET_DETAY_STERILIZASYON_PAKET_STERILIZASYON_PAKET_KODU",
                        column: x => x.STERILIZASYON_PAKET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STERILIZASYON_PAKET",
                        principalColumn: "STERILIZASYON_PAKET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_PAKET_DETAY_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STERILIZASYON_STOK_DURUM",
                schema: "Lbys",
                columns: table => new
                {
                    STERILIZASYON_STOK_DURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STERIL_OLMAYAN_STOK_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STERIL_STOK_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STERILIZASYON_STOK_DURUM", x => x.STERILIZASYON_STOK_DURUM_KODU);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_STOK_DURUM_DEPO_DEPO_KODU",
                        column: x => x.DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_STOK_DURUM_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOK_DURUM",
                schema: "Lbys",
                columns: table => new
                {
                    STOK_DURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MAKSIMUM_STOK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MINIMUM_STOK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KRITIK_STOK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOPLAM_GIRIS_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOPLAM_CIKIS_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STOK_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OLCU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOK_DURUM", x => x.STOK_DURUM_KODU);
                    table.ForeignKey(
                        name: "FK_STOK_DURUM_DEPO_DEPO_KODU",
                        column: x => x.DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_DURUM_REFERANS_KODLAR_OLCU_KODU",
                        column: x => x.OLCU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_DURUM_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CIHAZ",
                schema: "Lbys",
                columns: table => new
                {
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CIHAZ_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIHAZ_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CIHAZ_MODELI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIHAZ_MARKASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SERI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MKYS_KUNYE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIHAZ", x => x.CIHAZ_KODU);
                    table.ForeignKey(
                        name: "FK_CIHAZ_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CIHAZ_REFERANS_KODLAR_CIHAZ_GRUBU",
                        column: x => x.CIHAZ_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ODA",
                schema: "Lbys",
                columns: table => new
                {
                    ODA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ODA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ODA", x => x.ODA_KODU);
                    table.ForeignKey(
                        name: "FK_ODA_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TC_KIMLIK_NO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOYAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNVAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UZMANLIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CINSIYET = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DOGUM_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TELEFON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIPLOMA_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIPLOMA_TESCIL_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISE_BASLAMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL", x => x.PERSONEL_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_REFERANS_KODLAR_CINSIYET",
                        column: x => x.CINSIYET,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_REFERANS_KODLAR_UZMANLIK_KODU",
                        column: x => x.UZMANLIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TETKIK_PARAMETRE",
                schema: "Lbys",
                columns: table => new
                {
                    TETKIK_PARAMETRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_PARAMETRE_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TETKIK_PARAMETRE_BIRIMI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TETKIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MEDULA_PARAMETRE_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOINC_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAPOR_SONUC_SIRASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TETKIK_PARAMETRE", x => x.TETKIK_PARAMETRE_KODU);
                    table.ForeignKey(
                        name: "FK_TETKIK_PARAMETRE_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_PARAMETRE_TETKIK_TETKIK_KODU",
                        column: x => x.TETKIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK",
                        principalColumn: "TETKIK_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YATAK",
                schema: "Lbys",
                columns: table => new
                {
                    YATAK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YATAK_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ODA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    YATAK_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    YOGUN_BAKIM_YATAK_SEVIYESI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VENTILATOR_CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YATAK", x => x.YATAK_KODU);
                    table.ForeignKey(
                        name: "FK_YATAK_CIHAZ_VENTILATOR_CIHAZ_KODU",
                        column: x => x.VENTILATOR_CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YATAK_ODA_ODA_KODU",
                        column: x => x.ODA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "ODA",
                        principalColumn: "ODA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YATAK_REFERANS_KODLAR_YATAK_TURU",
                        column: x => x.YATAK_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YATAK_REFERANS_KODLAR_YOGUN_BAKIM_YATAK_SEVIYESI",
                        column: x => x.YOGUN_BAKIM_YATAK_SEVIYESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EK_ODEME",
                schema: "Lbys",
                columns: table => new
                {
                    EK_ODEME_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EK_ODEME_DONEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HESAPLAMA_YONTEMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAAS_DERECESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAAS_KADEMESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAAS_GOSTERGESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AYLIK_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OZEL_HIZMET_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EK_GOSTERGE_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YAN_ODEME_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOGU_TAZMINATI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EK_ODEME_MATRAHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BASKA_KURUMDAKI_EKODEME_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DSSO_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENGELLILIK_INDIRIM_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KOMISYON_EK_PUANI_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EK_PUAN_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIRIM_PERFORMANS_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EK_ODEME", x => x.EK_ODEME_KODU);
                    table.ForeignKey(
                        name: "FK_EK_ODEME_EK_ODEME_DONEM_EK_ODEME_DONEM_KODU",
                        column: x => x.EK_ODEME_DONEM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "EK_ODEME_DONEM",
                        principalColumn: "EK_ODEME_DONEM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EK_ODEME_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_BASVURU",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BASVURU_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BASVURU_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BASVURU_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DOKTOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SIKAYET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TANI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TEDAVI_TURU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEVK_EDEN_KURUM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROVIZYON_TIPI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TAKIP_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIKIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CIKIS_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SONUC_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_BASVURU", x => x.HASTA_BASVURU_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_BASVURU_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_BASVURU_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_BASVURU_PERSONEL_DOKTOR_KODU",
                        column: x => x.DOKTOR_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_BASVURU_REFERANS_KODLAR_BASVURU_SEKLI",
                        column: x => x.BASVURU_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_BASVURU_REFERANS_KODLAR_BASVURU_TURU",
                        column: x => x.BASVURU_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_BASVURU_REFERANS_KODLAR_CIKIS_SEKLI",
                        column: x => x.CIKIS_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KULLANICI",
                schema: "Lbys",
                columns: table => new
                {
                    KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KULLANICI_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AKTIF = table.Column<bool>(type: "bit", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KULLANICI", x => x.KULLANICI_KODU);
                    table.ForeignKey(
                        name: "FK_KULLANICI_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_BAKMAKLA_YUKUMLU",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_BAKMAKLA_YUKUMLU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_YAKINLIK_DERECESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOGUM_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OGRENIM_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ENGELLILIK_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_BAKMAKLA_YUKUMLU", x => x.PERSONEL_BAKMAKLA_YUKUMLU_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BAKMAKLA_YUKUMLU_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BAKMAKLA_YUKUMLU_REFERANS_KODLAR_ENGELLILIK_DURUMU",
                        column: x => x.ENGELLILIK_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BAKMAKLA_YUKUMLU_REFERANS_KODLAR_OGRENIM_DURUMU",
                        column: x => x.OGRENIM_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BAKMAKLA_YUKUMLU_REFERANS_KODLAR_PERSONEL_YAKINLIK_DERECESI",
                        column: x => x.PERSONEL_YAKINLIK_DERECESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_BANKA",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_BANKA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BANKA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HESAP_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUBE_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBAN_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BORDRO_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HESAP_AKTIFLIK_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_BANKA", x => x.PERSONEL_BANKA_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BANKA_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BANKA_REFERANS_KODLAR_BANKA",
                        column: x => x.BANKA,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BANKA_REFERANS_KODLAR_BORDRO_TURU",
                        column: x => x.BORDRO_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_BORDRO",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_BORDRO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BORDRO_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BORDRO_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAAS_DERECESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAAS_KADEMESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAAS_GOSTERGESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAAS_EK_GOSTERGESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_DERECESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_KADEMESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_GOSTERGESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_EK_GOSTERGESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TABAN_AYLIK_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AYLIK_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KIDEM_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EK_GOSTERGE_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YAN_ODEME_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OZEL_HIZMET_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AILE_YARDIMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCUK_YARDIMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCUK_SAYISI_6_YAS_ALTI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCUK_SAYISI_6_YAS_USTU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AGI_ESAS_COCUK_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ES_CALISMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BES_FIRMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BES_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BES_KESINTI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YABANCI_DIL_TAZMINATI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YABANCI_DIL_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YABANCI_DIL_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SENDIKA_ODENEGI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SENDIKA_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SENDIKA_SIRA_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SENDIKA_KESINTI_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SENDIKA_AIDATI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEVLET_EMEKLI_KESENEGI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAHIS_EMEKLI_KESENEGI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_KESENEGI_MATRAHI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OZEL_SIGORTA_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VERGI_INDIRIMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAMGA_VERGISI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GELIR_VERGISI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GELIR_VERGISI_MATRAHI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KUMULATIF_GELIR_VERGISI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICRA_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAFAKA_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YUZDE_YUZ_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOGU_TAZMINATI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SGK_SAHIS_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SGK_ISVEREN_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SGK_MATRAHI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KEFALET_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOZLESME_UCRETI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOJMAN_KESINTISI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASGARI_GECIM_INDIRIMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISSIZLIK_SAHIS_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISSIZLIK_ISVEREN_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISSIZLIK_PRIMI_MATRAHI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MALULLUK_DEVLET_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MALULLUK_SAHIS_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIYECEK_YARDIMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FARK_TAZMINATI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HIZMET_ZAMMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VASITA_YARDIMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KIRA_YARDIMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YEMEK_YARDIMI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAZLA_MESAI_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOBET_BIRIM_UCRET_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOBET_BIRIM_UCRET_20_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOBET_BIRIM_UCRET_50_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOBET_SAATI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOBET_20_SAATI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOBET_50_SAATI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YEVMIYE_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CALISMA_SAATI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TAHAKKUK_TOPLAMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NET_TUTAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KESINTI_TOPLAMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_BORDRO", x => x.PERSONEL_BORDRO_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BORDRO_FIRMA_BES_FIRMA_KODU",
                        column: x => x.BES_FIRMA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "FIRMA",
                        principalColumn: "FIRMA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BORDRO_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BORDRO_REFERANS_KODLAR_BORDRO_TURU",
                        column: x => x.BORDRO_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BORDRO_REFERANS_KODLAR_ES_CALISMA_DURUMU",
                        column: x => x.ES_CALISMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BORDRO_REFERANS_KODLAR_SENDIKA_BILGISI",
                        column: x => x.SENDIKA_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BORDRO_REFERANS_KODLAR_YABANCI_DIL_BILGISI",
                        column: x => x.YABANCI_DIL_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_BORDRO_SONDURUM",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_SONDURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KADEMESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERSONEL_DERECESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_DERECESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_KADEMESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SENDIKA_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KIDEM_YILI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KIDEM_AYI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KIDEM_GUNU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EK_GOSTERGE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_EK_GOSTERGESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GOSTERGE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMEKLI_GOSTERGESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YAN_ODEME_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OZEL_HIZMET_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_BORDRO_SONDURUM", x => x.PERSONEL_SONDURUM_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_BORDRO_SONDURUM_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_EGITIM",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_EGITIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_EGITIM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SERTIFIKA_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SERTIFIKA_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BELGE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EGITIM_BASLANGIC_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EGITIM_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EGITIM_VEREN_KISI_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EGITIM_YERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ONAYLAYAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_EGITIM", x => x.PERSONEL_EGITIM_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_EGITIM_PERSONEL_ONAYLAYAN_PERSONEL_KODU",
                        column: x => x.ONAYLAYAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_EGITIM_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_EGITIM_REFERANS_KODLAR_PERSONEL_EGITIM_TURU",
                        column: x => x.PERSONEL_EGITIM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_EGITIM_REFERANS_KODLAR_SERTIFIKA_TIPI",
                        column: x => x.SERTIFIKA_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_GOREVLENDIRME",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_GOREVLENDIRME_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GOREV_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GOREVLENDIRME_BASLAMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GOREVLENDIRME_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GOREVLENDIRME_IL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GOREVLENDIRME_ILCE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GOREVLENDIRILDIGI_KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_GOREVLENDIRME", x => x.PERSONEL_GOREVLENDIRME_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_GOREVLENDIRME_KURUM_GOREVLENDIRILDIGI_KURUM_KODU",
                        column: x => x.GOREVLENDIRILDIGI_KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_GOREVLENDIRME_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_GOREVLENDIRME_REFERANS_KODLAR_GOREVLENDIRME_ILCE_KODU",
                        column: x => x.GOREVLENDIRME_ILCE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_GOREVLENDIRME_REFERANS_KODLAR_GOREVLENDIRME_IL_KODU",
                        column: x => x.GOREVLENDIRME_IL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_GOREVLENDIRME_REFERANS_KODLAR_GOREV_TURU",
                        column: x => x.GOREV_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_IZIN_DURUMU",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_IZIN_DURUMU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KALAN_IZIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YILLIK_IZIN_HAKKI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERSONEL_IZIN_YILI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_IZIN_DURUMU", x => x.PERSONEL_IZIN_DURUMU_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_IZIN_DURUMU_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_ODUL_CEZA",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_ODUL_CEZA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ODUL_CEZA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ODUL_CEZA_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CEZA_BASLANGIC_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CEZA_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ODUL_CEZA_VEREN_KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ODUL_CEZA_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TEBLIG_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TEBLIG_EVRAK_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TEBLIG_EVRAK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_ODUL_CEZA", x => x.PERSONEL_ODUL_CEZA_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_ODUL_CEZA_KURUM_ODUL_CEZA_VEREN_KURUM_KODU",
                        column: x => x.ODUL_CEZA_VEREN_KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_ODUL_CEZA_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_ODUL_CEZA_REFERANS_KODLAR_ODUL_CEZA_TURU",
                        column: x => x.ODUL_CEZA_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_OGRENIM",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_OGRENIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OGRENIM_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OKUL_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OKULA_BASLANGIC_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MEZUNIYET_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BELGE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ONAYLAYAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_OGRENIM", x => x.PERSONEL_OGRENIM_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_OGRENIM_PERSONEL_ONAYLAYAN_PERSONEL_KODU",
                        column: x => x.ONAYLAYAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_OGRENIM_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_OGRENIM_REFERANS_KODLAR_OGRENIM_DURUMU",
                        column: x => x.OGRENIM_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_YANDAL",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_YANDAL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YANDAL_BASLANGIC_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YANDAL_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MEDULA_BRANS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_YANDAL", x => x.PERSONEL_YANDAL_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_YANDAL_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STERILIZASYON_GIRIS",
                schema: "Lbys",
                columns: table => new
                {
                    STERILIZASYON_GIRIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_GIRIS_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESLIM_EDEN_BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TESLIM_EDEN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TESLIM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TESLIM_ALAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STERILIZASYON_GIRIS", x => x.STERILIZASYON_GIRIS_KODU);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_GIRIS_BIRIM_TESLIM_EDEN_BIRIM_KODU",
                        column: x => x.TESLIM_EDEN_BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_GIRIS_DEPO_DEPO_KODU",
                        column: x => x.DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_GIRIS_PERSONEL_TESLIM_ALAN_PERSONEL_KODU",
                        column: x => x.TESLIM_ALAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_GIRIS_PERSONEL_TESLIM_EDEN_PERSONEL_KODU",
                        column: x => x.TESLIM_EDEN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_GIRIS_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STERILIZASYON_YIKAMA",
                schema: "Lbys",
                columns: table => new
                {
                    STERILIZASYON_YIKAMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YIKANAN_ALET_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STERILIZASYON_YIKAMA_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YIKAMA_YAPAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YIKAMA_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YIKAMA_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STERILIZASYON_YIKAMA", x => x.STERILIZASYON_YIKAMA_KODU);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_YIKAMA_DEPO_DEPO_KODU",
                        column: x => x.DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_YIKAMA_PERSONEL_YIKAMA_YAPAN_PERSONEL_KODU",
                        column: x => x.YIKAMA_YAPAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_YIKAMA_REFERANS_KODLAR_STERILIZASYON_YIKAMA_TURU",
                        column: x => x.STERILIZASYON_YIKAMA_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_YIKAMA_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TETKIK_CIHAZ_ESLESME",
                schema: "Lbys",
                columns: table => new
                {
                    TETKIK_CIHAZ_ESLESME_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_PARAMETRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CIHAZDAN_GELEN_TEST_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIHAZA_GIDEN_TEST_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPTAL_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TETKIK_CIHAZ_ESLESME", x => x.TETKIK_CIHAZ_ESLESME_KODU);
                    table.ForeignKey(
                        name: "FK_TETKIK_CIHAZ_ESLESME_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_CIHAZ_ESLESME_TETKIK_PARAMETRE_TETKIK_PARAMETRE_KODU",
                        column: x => x.TETKIK_PARAMETRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK_PARAMETRE",
                        principalColumn: "TETKIK_PARAMETRE_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_CIHAZ_ESLESME_TETKIK_TETKIK_KODU",
                        column: x => x.TETKIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK",
                        principalColumn: "TETKIK_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TETKIK_REFERANS_ARALIK",
                schema: "Lbys",
                columns: table => new
                {
                    TETKIK_REFERANS_ARALIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_PARAMETRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_CINSIYET = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YAS_ARALIGI_BASLANGIC_GUN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YAS_ARALIGI_BITIS_GUN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REFERANS_BASLANGIC_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REFERANS_BITIS_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALT_KRITIK_DEGER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UST_KRITIK_DEGER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TETKIK_REFERANS_ARALIK", x => x.TETKIK_REFERANS_ARALIK_KODU);
                    table.ForeignKey(
                        name: "FK_TETKIK_REFERANS_ARALIK_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_REFERANS_ARALIK_REFERANS_KODLAR_TETKIK_CINSIYET",
                        column: x => x.TETKIK_CINSIYET,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_REFERANS_ARALIK_TETKIK_PARAMETRE_TETKIK_PARAMETRE_KODU",
                        column: x => x.TETKIK_PARAMETRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK_PARAMETRE",
                        principalColumn: "TETKIK_PARAMETRE_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_REFERANS_ARALIK_TETKIK_TETKIK_KODU",
                        column: x => x.TETKIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK",
                        principalColumn: "TETKIK_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EK_ODEME_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    EK_ODEME_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EK_ODEME_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GOREV_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KADRO_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KADRO_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIRISIMSEL_ISLEM_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OZELLIKLI_ISLEM_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TAVAN_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CALISILAN_GUN_TOPLAMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CALISILAN_SAAT_TOPLAMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AKTIF_CALISILAN_GUN_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HASTANE_PUAN_ORTALAMASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KLINIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KLINIK_PUAN_ORTALAMASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BRUT_PERFORMANS_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EK_PERFORMANS_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NET_PERFORMANS_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EGITICI_DESTEKLEME_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BILIMSEL_CALISMA_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SERBEST_MESLEK_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EK_ODEME_DETAY", x => x.EK_ODEME_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_EK_ODEME_DETAY_EK_ODEME_EK_ODEME_KODU",
                        column: x => x.EK_ODEME_KODU,
                        principalSchema: "Lbys",
                        principalTable: "EK_ODEME",
                        principalColumn: "EK_ODEME_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EK_ODEME_DETAY_REFERANS_KODLAR_KLINIK_KODU",
                        column: x => x.KLINIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AMELIYAT",
                schema: "Lbys",
                columns: table => new
                {
                    AMELIYAT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AMELIYAT_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMELIYAT_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMELIYAT_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AMELIYAT_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MASA_CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DEFTER_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMELIYAT_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ANESTEZI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ANESTEZI_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ANESTEZI_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ANESTEZI_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AMELIYAT_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SKOPI_SURESI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROFILAKSI_PERIYODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PROFILAKSI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AMELIYAT", x => x.AMELIYAT_KODU);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_CIHAZ_MASA_CIHAZ_KODU",
                        column: x => x.MASA_CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_REFERANS_KODLAR_AMELIYAT_DURUMU",
                        column: x => x.AMELIYAT_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_REFERANS_KODLAR_AMELIYAT_TIPI",
                        column: x => x.AMELIYAT_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_REFERANS_KODLAR_AMELIYAT_TURU",
                        column: x => x.AMELIYAT_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_REFERANS_KODLAR_ANESTEZI_TURU",
                        column: x => x.ANESTEZI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_REFERANS_KODLAR_PROFILAKSI_KODU",
                        column: x => x.PROFILAKSI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_REFERANS_KODLAR_PROFILAKSI_PERIYODU",
                        column: x => x.PROFILAKSI_PERIYODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANLIK_YATAN_HASTA",
                schema: "Lbys",
                columns: table => new
                {
                    ANLIK_YATAN_HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YATIS_PROTOKOL_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YATAK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ODA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YATIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANLIK_YATAN_HASTA", x => x.ANLIK_YATAN_HASTA_KODU);
                    table.ForeignKey(
                        name: "FK_ANLIK_YATAN_HASTA_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ANLIK_YATAN_HASTA_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ANLIK_YATAN_HASTA_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ANLIK_YATAN_HASTA_ODA_ODA_KODU",
                        column: x => x.ODA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "ODA",
                        principalColumn: "ODA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ANLIK_YATAN_HASTA_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ANLIK_YATAN_HASTA_YATAK_YATAK_KODU",
                        column: x => x.YATAK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "YATAK",
                        principalColumn: "YATAK_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ASI_BILGISI",
                schema: "Lbys",
                columns: table => new
                {
                    ASI_BILGISI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASININ_DOZU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASININ_UYGULAMA_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASI_UYGULAMA_YERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASI_SORGU_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASI_ISLEM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BILGI_ALINAN_KISI_AD_SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BILGI_ALINAN_KISI_TELEFON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASI_YAPILMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ASI_OZEL_DURUM_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASIE_ORTAYA_CIKIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ASIE_NEDENLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASI_ERTELEME_SURESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASI_YAPILMAMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASI_YAPILMAMA_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ALTTA_YATAN_HASTALIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASI_BILGISI", x => x.ASI_BILGISI_KODU);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ALTTA_YATAN_HASTALIK",
                        column: x => x.ALTTA_YATAN_HASTALIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASIE_NEDENLERI",
                        column: x => x.ASIE_NEDENLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASININ_DOZU",
                        column: x => x.ASININ_DOZU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASININ_UYGULAMA_SEKLI",
                        column: x => x.ASININ_UYGULAMA_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASI_ISLEM_TURU",
                        column: x => x.ASI_ISLEM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASI_KODU",
                        column: x => x.ASI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASI_OZEL_DURUM_NEDENI",
                        column: x => x.ASI_OZEL_DURUM_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASI_UYGULAMA_YERI",
                        column: x => x.ASI_UYGULAMA_YERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASI_YAPILMAMA_DURUMU",
                        column: x => x.ASI_YAPILMAMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ASI_BILGISI_REFERANS_KODLAR_ASI_YAPILMAMA_NEDENI",
                        column: x => x.ASI_YAPILMAMA_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BASVURU_TANI",
                schema: "Lbys",
                columns: table => new
                {
                    BASVURU_TANI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TANI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TANI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BIRINCIL_TANI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TANI_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KURUL_RAPOR_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HASTA_SEVK_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASVURU_TANI", x => x.BASVURU_TANI_KODU);
                    table.ForeignKey(
                        name: "FK_BASVURU_TANI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BASVURU_TANI_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BASVURU_TANI_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BASVURU_TANI_REFERANS_KODLAR_TANI_KODU",
                        column: x => x.TANI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BASVURU_TANI_REFERANS_KODLAR_TANI_TURU",
                        column: x => x.TANI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BASVURU_YEMEK",
                schema: "Lbys",
                columns: table => new
                {
                    BASVURU_YEMEK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YEMEK_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YEMEK_ZAMANI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YEMEK_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASVURU_YEMEK", x => x.BASVURU_YEMEK_KODU);
                    table.ForeignKey(
                        name: "FK_BASVURU_YEMEK_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BASVURU_YEMEK_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BASVURU_YEMEK_REFERANS_KODLAR_YEMEK_TURU",
                        column: x => x.YEMEK_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BASVURU_YEMEK_REFERANS_KODLAR_YEMEK_ZAMANI_TURU",
                        column: x => x.YEMEK_ZAMANI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BEBEK_COCUK_IZLEM",
                schema: "Lbys",
                columns: table => new
                {
                    BEBEK_COCUK_IZLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KACINCI_IZLEM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AGIZDAN_SIVI_TEDAVISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAS_CEVRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEMIR_LOJISTIGI_VE_DESTEGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOGUM_AGIRLIGI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DVITAMINI_LOJISTIGI_VE_DESTEGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GKD_TARAMA_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMATOKRIT_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEMOGLOBIN_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOPUK_KANI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TOPUK_KANI_ALINMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IZLEMIN_YAPILDIGI_YER = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IZLEMI_YAPAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BILGI_ALINAN_KISI_AD_SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BILGI_ALINAN_KISI_TELEFON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BEBEKTE_RISK_FAKTORLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TARAMA_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ANNE_SUTUNDEN_KESILDIGI_AY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BEBEGIN_BESLENME_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EK_GIDAYA_BASLADIGI_AY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SADECE_ANNE_SUTU_ALDIGI_SURE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GELISIM_TABLOSU_BILGILERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NTP_TAKIP_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BC_BEYIN_GELISIM_RISKLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EBEVEYN_DESTEK_AKTIVITELERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BC_PSIKOLOJIK_RISK_EGITIM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BC_RISK_YAPILAN_MUDAHALE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BC_RISKLI_OLGU_TAKIBI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BEBEK_COCUK_IZLEM", x => x.BEBEK_COCUK_IZLEM_KODU);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_PERSONEL_IZLEMI_YAPAN_PERSONEL_KODU",
                        column: x => x.IZLEMI_YAPAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_AGIZDAN_SIVI_TEDAVISI",
                        column: x => x.AGIZDAN_SIVI_TEDAVISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_BC_BEYIN_GELISIM_RISKLERI",
                        column: x => x.BC_BEYIN_GELISIM_RISKLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_BC_PSIKOLOJIK_RISK_EGITIM",
                        column: x => x.BC_PSIKOLOJIK_RISK_EGITIM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_BC_RISKLI_OLGU_TAKIBI",
                        column: x => x.BC_RISKLI_OLGU_TAKIBI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_BC_RISK_YAPILAN_MUDAHALE",
                        column: x => x.BC_RISK_YAPILAN_MUDAHALE,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_BEBEGIN_BESLENME_DURUMU",
                        column: x => x.BEBEGIN_BESLENME_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_BEBEKTE_RISK_FAKTORLERI",
                        column: x => x.BEBEKTE_RISK_FAKTORLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_DEMIR_LOJISTIGI_VE_DESTEGI",
                        column: x => x.DEMIR_LOJISTIGI_VE_DESTEGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_DVITAMINI_LOJISTIGI_VE_DESTEGI",
                        column: x => x.DVITAMINI_LOJISTIGI_VE_DESTEGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_EBEVEYN_DESTEK_AKTIVITELERI",
                        column: x => x.EBEVEYN_DESTEK_AKTIVITELERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_GELISIM_TABLOSU_BILGILERI",
                        column: x => x.GELISIM_TABLOSU_BILGILERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_GKD_TARAMA_SONUCU",
                        column: x => x.GKD_TARAMA_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_IZLEMIN_YAPILDIGI_YER",
                        column: x => x.IZLEMIN_YAPILDIGI_YER,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_KACINCI_IZLEM",
                        column: x => x.KACINCI_IZLEM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_NTP_TAKIP_BILGISI",
                        column: x => x.NTP_TAKIP_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_TARAMA_SONUCU",
                        column: x => x.TARAMA_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BEBEK_COCUK_IZLEM_REFERANS_KODLAR_TOPUK_KANI",
                        column: x => x.TOPUK_KANI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BILDIRIMI_ZORUNLU",
                schema: "Lbys",
                columns: table => new
                {
                    BILDIRIMI_ZORUNLU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BILDIRIM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BILDIRIM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TANI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AILESINDE_INTIHAR_GIRISIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AILESINDE_PSIKIYATRIK_VAKA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_KRIZ_VAKA_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OLAY_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PSIKIYATRIK_TEDAVI_GECMISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_GIRISIM_KRIZ_NEDENLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_GIRISIMI_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_GIRISIMI_GECMISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_KRIZ_VAKA_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PSIKIYATRIK_TANI_GECMISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HAYVANIN_MEVCUT_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HAYVANIN_SAHIPLIK_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IMMUNGLOBULIN_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IMMUNGLOBULIN_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KATEGORIZASYON = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TEMAS_DEGERLENDIRME_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KUDUZ_SEBEP_OLAN_HAYVAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YAPTIRACAGINI_BEYAN_ETTIGI_TSM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RISKLI_TEMAS_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EV_TELEFONU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP_TELEFONU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EV_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILCE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BCG_SKAR_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DGT_UYGULAMASINI_YAPAN_KISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DGT_UYGULAMA_YERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTANIN_TEDAVIYE_UYUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULTUR_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TUBERKULIN_DERI_TESTI_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VEREM_HASTASI_TEDAVI_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VEREM_OLGU_TANIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YAYMA_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VEREM_HASTALIGI_TUTULUM_YERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VEREM_HASTASI_KLINIK_ORNEGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VEREM_ILAC_ADI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VEREM_TEDAVI_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BULASICI_HASTALIK_VAKA_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BELIRTILERIN_BASLADIGI_TARIH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SIDDET_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SIDDET_DEGERLENDIRME_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILDIRIMI_ZORUNLU", x => x.BILDIRIMI_ZORUNLU_KODU);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_KURUM_YAPTIRACAGINI_BEYAN_ETTIGI_TSM",
                        column: x => x.YAPTIRACAGINI_BEYAN_ETTIGI_TSM,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_AILESINDE_INTIHAR_GIRISIMI",
                        column: x => x.AILESINDE_INTIHAR_GIRISIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_AILESINDE_PSIKIYATRIK_VAKA",
                        column: x => x.AILESINDE_PSIKIYATRIK_VAKA,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_BILDIRIM_TURU",
                        column: x => x.BILDIRIM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_BULASICI_HASTALIK_VAKA_TIPI",
                        column: x => x.BULASICI_HASTALIK_VAKA_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_DGT_UYGULAMASINI_YAPAN_KISI",
                        column: x => x.DGT_UYGULAMASINI_YAPAN_KISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_DGT_UYGULAMA_YERI",
                        column: x => x.DGT_UYGULAMA_YERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_HASTANIN_TEDAVIYE_UYUMU",
                        column: x => x.HASTANIN_TEDAVIYE_UYUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_HAYVANIN_MEVCUT_DURUMU",
                        column: x => x.HAYVANIN_MEVCUT_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_HAYVANIN_SAHIPLIK_DURUMU",
                        column: x => x.HAYVANIN_SAHIPLIK_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_ILCE_KODU",
                        column: x => x.ILCE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_IL_KODU",
                        column: x => x.IL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_IMMUNGLOBULIN_TURU",
                        column: x => x.IMMUNGLOBULIN_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_INTIHAR_GIRISIMI_GECMISI",
                        column: x => x.INTIHAR_GIRISIMI_GECMISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_INTIHAR_GIRISIMI_YONTEMI",
                        column: x => x.INTIHAR_GIRISIMI_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_INTIHAR_GIRISIM_KRIZ_NEDENLERI",
                        column: x => x.INTIHAR_GIRISIM_KRIZ_NEDENLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_INTIHAR_KRIZ_VAKA_SONUCU",
                        column: x => x.INTIHAR_KRIZ_VAKA_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_INTIHAR_KRIZ_VAKA_TURU",
                        column: x => x.INTIHAR_KRIZ_VAKA_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_KATEGORIZASYON",
                        column: x => x.KATEGORIZASYON,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_KUDUZ_SEBEP_OLAN_HAYVAN",
                        column: x => x.KUDUZ_SEBEP_OLAN_HAYVAN,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_KULTUR_SONUCU",
                        column: x => x.KULTUR_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_PSIKIYATRIK_TANI_GECMISI",
                        column: x => x.PSIKIYATRIK_TANI_GECMISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_PSIKIYATRIK_TEDAVI_GECMISI",
                        column: x => x.PSIKIYATRIK_TEDAVI_GECMISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_RISKLI_TEMAS_TIPI",
                        column: x => x.RISKLI_TEMAS_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_SIDDET_DEGERLENDIRME_SONUCU",
                        column: x => x.SIDDET_DEGERLENDIRME_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_SIDDET_TURU",
                        column: x => x.SIDDET_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_TANI_KODU",
                        column: x => x.TANI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_TEMAS_DEGERLENDIRME_DURUMU",
                        column: x => x.TEMAS_DEGERLENDIRME_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_TUBERKULIN_DERI_TESTI_SONUCU",
                        column: x => x.TUBERKULIN_DERI_TESTI_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_VEREM_HASTALIGI_TUTULUM_YERI",
                        column: x => x.VEREM_HASTALIGI_TUTULUM_YERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_VEREM_HASTASI_KLINIK_ORNEGI",
                        column: x => x.VEREM_HASTASI_KLINIK_ORNEGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_VEREM_HASTASI_TEDAVI_YONTEMI",
                        column: x => x.VEREM_HASTASI_TEDAVI_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_VEREM_ILAC_ADI",
                        column: x => x.VEREM_ILAC_ADI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_VEREM_OLGU_TANIMI",
                        column: x => x.VEREM_OLGU_TANIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_VEREM_TEDAVI_SONUCU",
                        column: x => x.VEREM_TEDAVI_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDIRIMI_ZORUNLU_REFERANS_KODLAR_YAYMA_SONUCU",
                        column: x => x.YAYMA_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COCUK_DIYABET",
                schema: "Lbys",
                columns: table => new
                {
                    COCUK_DIYABET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILK_TANI_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AGIRLIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BOY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIYABET_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KIZ_COCUKLARDA_MENARS_YASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BEYIN_ODEMI_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KETOASIDOZ_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYABET_SIKAYET = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SIKAYETIN_SURESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AKSILLER_KILLANMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PUBIK_KILLANMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEME_EVRE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TESTIS_VOLUM_SAG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESTIS_VOLUM_SOL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESLIKEDEN_HASTALIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ESLIKEDEN_HASTALIK_TANI_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DIYABET_ILAC_TEDAVI_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYET_TIBBI_BESLENME_TEDAVISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYABETLI_HASTA_AILE_OYKUSU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYABET_EGITIMI_VERILME_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TIROID_MUAYENESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYABET_KOMPLIKASYONLARI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCUK_DIYABET", x => x.COCUK_DIYABET_KODU);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_AKSILLER_KILLANMA_DURUMU",
                        column: x => x.AKSILLER_KILLANMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_BEYIN_ODEMI_DURUMU",
                        column: x => x.BEYIN_ODEMI_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_DIYABETLI_HASTA_AILE_OYKUSU",
                        column: x => x.DIYABETLI_HASTA_AILE_OYKUSU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_DIYABET_EGITIMI_VERILME_DURUMU",
                        column: x => x.DIYABET_EGITIMI_VERILME_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_DIYABET_ILAC_TEDAVI_SEKLI",
                        column: x => x.DIYABET_ILAC_TEDAVI_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_DIYABET_KOMPLIKASYONLARI",
                        column: x => x.DIYABET_KOMPLIKASYONLARI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_DIYABET_SIKAYET",
                        column: x => x.DIYABET_SIKAYET,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_DIYABET_TIPI",
                        column: x => x.DIYABET_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_DIYET_TIBBI_BESLENME_TEDAVISI",
                        column: x => x.DIYET_TIBBI_BESLENME_TEDAVISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_ESLIKEDEN_HASTALIK",
                        column: x => x.ESLIKEDEN_HASTALIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_KETOASIDOZ_DURUMU",
                        column: x => x.KETOASIDOZ_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_MEME_EVRE",
                        column: x => x.MEME_EVRE,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_PUBIK_KILLANMA_DURUMU",
                        column: x => x.PUBIK_KILLANMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COCUK_DIYABET_REFERANS_KODLAR_TIROID_MUAYENESI",
                        column: x => x.TIROID_MUAYENESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIS_TAAHHUT",
                schema: "Lbys",
                columns: table => new
                {
                    DIS_TAAHHUT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIS_TAAHHUT_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SGK_TAKIP_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CADDE_SOKAK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIS_KAPI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPOSTA_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IC_KAPI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TELEFON_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ILCE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEDULA_SONUC_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_SONUC_MESAJI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPTAL_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIS_TAAHHUT", x => x.DIS_TAAHHUT_KODU);
                    table.ForeignKey(
                        name: "FK_DIS_TAAHHUT_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIS_TAAHHUT_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIS_TAAHHUT_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIS_TAAHHUT_REFERANS_KODLAR_ILCE_KODU",
                        column: x => x.ILCE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIS_TAAHHUT_REFERANS_KODLAR_IL_KODU",
                        column: x => x.IL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DISPROTEZ",
                schema: "Lbys",
                columns: table => new
                {
                    DISPROTEZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DISPROTEZ_BASLAMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TEKNISYEN_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DISPROTEZ_IS_TURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DISPROTEZ_IS_TURU_ALT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PARCA_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DISPROTEZ_AYAK_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DISPROTEZ_GOVDE_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DISPROTEZ_BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RPT_SEBEBI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RPT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RPT_EDEN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BARKOD_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DISPROTEZ_KASIK_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DISPROTEZ_RENGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIS_BOYUT_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DISPROTEZ_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISPROTEZ", x => x.DISPROTEZ_KODU);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_BIRIM_DISPROTEZ_BIRIM_KODU",
                        column: x => x.DISPROTEZ_BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_PERSONEL_RPT_EDEN_PERSONEL_KODU",
                        column: x => x.RPT_EDEN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_PERSONEL_TEKNISYEN_KODU",
                        column: x => x.TEKNISYEN_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_REFERANS_KODLAR_DISPROTEZ_IS_TURU_ALT_KODU",
                        column: x => x.DISPROTEZ_IS_TURU_ALT_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_REFERANS_KODLAR_DISPROTEZ_IS_TURU_KODU",
                        column: x => x.DISPROTEZ_IS_TURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_REFERANS_KODLAR_DISPROTEZ_KASIK_TURU",
                        column: x => x.DISPROTEZ_KASIK_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_REFERANS_KODLAR_DISPROTEZ_RENGI",
                        column: x => x.DISPROTEZ_RENGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_REFERANS_KODLAR_DIS_BOYUT_BILGISI",
                        column: x => x.DIS_BOYUT_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_REFERANS_KODLAR_RPT_SEBEBI",
                        column: x => x.RPT_SEBEBI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIYABET",
                schema: "Lbys",
                columns: table => new
                {
                    DIYABET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILK_TANI_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AGIRLIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BOY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIYABET_EGITIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYABET_KOMPLIKASYONLARI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIYABET", x => x.DIYABET_KODU);
                    table.ForeignKey(
                        name: "FK_DIYABET_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIYABET_REFERANS_KODLAR_DIYABET_EGITIMI",
                        column: x => x.DIYABET_EGITIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIYABET_REFERANS_KODLAR_DIYABET_KOMPLIKASYONLARI",
                        column: x => x.DIYABET_KOMPLIKASYONLARI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOKTOR_MESAJI",
                schema: "Lbys",
                columns: table => new
                {
                    DOKTOR_MESAJI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_MESAJLARI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MESAJ_DETAYI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MESAJ_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOKTOR_MESAJI", x => x.DOKTOR_MESAJI_KODU);
                    table.ForeignKey(
                        name: "FK_DOKTOR_MESAJI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOKTOR_MESAJI_REFERANS_KODLAR_HASTA_MESAJLARI_TURU",
                        column: x => x.HASTA_MESAJLARI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EVDE_SAGLIK_IZLEM",
                schema: "Lbys",
                columns: table => new
                {
                    EVDE_SAGLIK_IZLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AGRI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AYDINLATMA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAKIM_VE_DESTEK_IHTIYACI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BASI_DEGERLENDIRMESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BASVURU_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BESLENME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ESH_ESAS_HASTALIK_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EV_HIJYENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GUVENLIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISINMA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KISISEL_BAKIM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KISISEL_HIJYEN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KONUT_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULLANILAN_HELA_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YATAGA_BAGIMLILIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULLANDIGI_YARDIMCI_ARACLAR = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PSIKOLOJIK_DURUM_DEGERLENDIRME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ESH_SONLANDIRILMASI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ESH_HASTA_NAKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ESH_ALINACAK_IL = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIR_SONRAKI_HIZMET_IHTIYACI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VERILEN_EGITIMLER = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVDE_SAGLIK_IZLEM", x => x.EVDE_SAGLIK_IZLEM_KODU);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_AGRI",
                        column: x => x.AGRI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_AYDINLATMA",
                        column: x => x.AYDINLATMA,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_BAKIM_VE_DESTEK_IHTIYACI",
                        column: x => x.BAKIM_VE_DESTEK_IHTIYACI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_BASI_DEGERLENDIRMESI",
                        column: x => x.BASI_DEGERLENDIRMESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_BASVURU_TURU",
                        column: x => x.BASVURU_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_BESLENME",
                        column: x => x.BESLENME,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_BIR_SONRAKI_HIZMET_IHTIYACI",
                        column: x => x.BIR_SONRAKI_HIZMET_IHTIYACI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_ESH_ALINACAK_IL",
                        column: x => x.ESH_ALINACAK_IL,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_ESH_ESAS_HASTALIK_GRUBU",
                        column: x => x.ESH_ESAS_HASTALIK_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_ESH_HASTA_NAKLI",
                        column: x => x.ESH_HASTA_NAKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_ESH_SONLANDIRILMASI",
                        column: x => x.ESH_SONLANDIRILMASI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_EV_HIJYENI",
                        column: x => x.EV_HIJYENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_GUVENLIK",
                        column: x => x.GUVENLIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_ISINMA",
                        column: x => x.ISINMA,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_KISISEL_BAKIM",
                        column: x => x.KISISEL_BAKIM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_KISISEL_HIJYEN",
                        column: x => x.KISISEL_HIJYEN,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_KONUT_TIPI",
                        column: x => x.KONUT_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_KULLANDIGI_YARDIMCI_ARACLAR",
                        column: x => x.KULLANDIGI_YARDIMCI_ARACLAR,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_KULLANILAN_HELA_TIPI",
                        column: x => x.KULLANILAN_HELA_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_PSIKOLOJIK_DURUM_DEGERLENDIRME",
                        column: x => x.PSIKOLOJIK_DURUM_DEGERLENDIRME,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_VERILEN_EGITIMLER",
                        column: x => x.VERILEN_EGITIMLER,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVDE_SAGLIK_IZLEM_REFERANS_KODLAR_YATAGA_BAGIMLILIK",
                        column: x => x.YATAGA_BAGIMLILIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FATURA",
                schema: "Lbys",
                columns: table => new
                {
                    FATURA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FATURA_DONEMI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICMAL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FATURA_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FATURA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATURA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FATURA_TUTARI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FATURA_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEDULA_TESLIM_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FATURA_KESILEN_KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BUTCE_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FATURA", x => x.FATURA_KODU);
                    table.ForeignKey(
                        name: "FK_FATURA_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FATURA_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FATURA_ICMAL_ICMAL_KODU",
                        column: x => x.ICMAL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "ICMAL",
                        principalColumn: "ICMAL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FATURA_KURUM_FATURA_KESILEN_KURUM_KODU",
                        column: x => x.FATURA_KESILEN_KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FATURA_REFERANS_KODLAR_FATURA_TURU",
                        column: x => x.FATURA_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GEBE_IZLEM",
                schema: "Lbys",
                columns: table => new
                {
                    GEBE_IZLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KACINCI_GEBE_IZLEM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SON_ADET_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ONCEKI_DOGUM_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GEBE_IZLEM_ISLEM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GESTASYONEL_DIYABET_TARAMASI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDRARDA_PROTEIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMOGLOBIN_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEMIR_LOJISTIGI_VE_DESTEGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DVITAMINI_LOJISTIGI_VE_DESTEGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KONJENITAL_ANOMALI_VARLIGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FETUS_KALP_SESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIASTOLIK_KAN_BASINCI_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SISTOLIK_KAN_BASINCI_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GEBELIKTE_RISK_FAKTORLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BC_BEYIN_GELISIM_RISKLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PSIKOLOJIK_GELISIM_RISK_EGITIM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RISK_FAKTORLERINE_MUDAHALE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RISK_ALTINDAKI_OLGU_TAKIBI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GEBE_IZLEM", x => x.GEBE_IZLEM_KODU);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_BC_BEYIN_GELISIM_RISKLERI",
                        column: x => x.BC_BEYIN_GELISIM_RISKLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_DEMIR_LOJISTIGI_VE_DESTEGI",
                        column: x => x.DEMIR_LOJISTIGI_VE_DESTEGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_DVITAMINI_LOJISTIGI_VE_DESTEGI",
                        column: x => x.DVITAMINI_LOJISTIGI_VE_DESTEGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_GEBELIKTE_RISK_FAKTORLERI",
                        column: x => x.GEBELIKTE_RISK_FAKTORLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_GEBE_IZLEM_ISLEM_TURU",
                        column: x => x.GEBE_IZLEM_ISLEM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_GESTASYONEL_DIYABET_TARAMASI",
                        column: x => x.GESTASYONEL_DIYABET_TARAMASI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_IDRARDA_PROTEIN",
                        column: x => x.IDRARDA_PROTEIN,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_KACINCI_GEBE_IZLEM",
                        column: x => x.KACINCI_GEBE_IZLEM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_KONJENITAL_ANOMALI_VARLIGI",
                        column: x => x.KONJENITAL_ANOMALI_VARLIGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_ONCEKI_DOGUM_DURUMU",
                        column: x => x.ONCEKI_DOGUM_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_PSIKOLOJIK_GELISIM_RISK_EGITIM",
                        column: x => x.PSIKOLOJIK_GELISIM_RISK_EGITIM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_RISK_ALTINDAKI_OLGU_TAKIBI",
                        column: x => x.RISK_ALTINDAKI_OLGU_TAKIBI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GEBE_IZLEM_REFERANS_KODLAR_RISK_FAKTORLERINE_MUDAHALE",
                        column: x => x.RISK_FAKTORLERINE_MUDAHALE,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GETAT",
                schema: "Lbys",
                columns: table => new
                {
                    GETAT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GETAT_UYGULAMA_BIRIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KOMPLIKASYON_TANISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GETAT_TEDAVI_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GETAT_UYGULAMA_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GETAT_UYGULANDIGI_DURUMLAR = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GETAT_UYGULAMA_BOLGESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GETAT", x => x.GETAT_KODU);
                    table.ForeignKey(
                        name: "FK_GETAT_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GETAT_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GETAT_REFERANS_KODLAR_GETAT_TEDAVI_SONUCU",
                        column: x => x.GETAT_TEDAVI_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GETAT_REFERANS_KODLAR_GETAT_UYGULAMA_BIRIMI",
                        column: x => x.GETAT_UYGULAMA_BIRIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GETAT_REFERANS_KODLAR_GETAT_UYGULAMA_BOLGESI",
                        column: x => x.GETAT_UYGULAMA_BOLGESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GETAT_REFERANS_KODLAR_GETAT_UYGULAMA_TURU",
                        column: x => x.GETAT_UYGULAMA_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GETAT_REFERANS_KODLAR_GETAT_UYGULANDIGI_DURUMLAR",
                        column: x => x.GETAT_UYGULANDIGI_DURUMLAR,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GETAT_REFERANS_KODLAR_KOMPLIKASYON_TANISI",
                        column: x => x.KOMPLIKASYON_TANISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_BORC",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_BORC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ODENEN_BORC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOPLAM_BORC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KALAN_BORC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_BORC", x => x.HASTA_BORC_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_BORC_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_BORC_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_EPIKRIZ",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_EPIKRIZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EPIKRIZ_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EPIKRIZ_BASLIK_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EPIKRIZ_BILGISI_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_EPIKRIZ", x => x.HASTA_EPIKRIZ_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_EPIKRIZ_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_EPIKRIZ_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_EPIKRIZ_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_EPIKRIZ_REFERANS_KODLAR_EPIKRIZ_BASLIK_BILGISI",
                        column: x => x.EPIKRIZ_BASLIK_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_FOTOGRAF",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_FOTOGRAF_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FOTOGRAF_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FOTOGRAF_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FOTOGRAF_DOSYA_YOLU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_FOTOGRAF", x => x.HASTA_FOTOGRAF_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_FOTOGRAF_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_FOTOGRAF_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_FOTOGRAF_REFERANS_KODLAR_FOTOGRAF_TURU",
                        column: x => x.FOTOGRAF_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_GIZLILIK",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_GIZLILIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GIZLILIK_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GORUNECEK_HASTA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GORUNECEK_HASTA_SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIZLILIK_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GIZLILIK_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GIZLILIK_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_GIZLILIK", x => x.HASTA_GIZLILIK_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_GIZLILIK_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_GIZLILIK_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_GIZLILIK_REFERANS_KODLAR_GIZLILIK_NEDENI",
                        column: x => x.GIZLILIK_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_GIZLILIK_REFERANS_KODLAR_GIZLILIK_TURU",
                        column: x => x.GIZLILIK_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_ILETISIM",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_ILETISIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ADRES_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ADRES_KODU_SEVIYESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BEYAN_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NVI_ADRES = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADRES_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILCE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BUCAK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KOY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MAHALLE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CSBM_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIS_KAPI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IC_KAPI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EV_TELEFONU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP_TELEFONU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_TELEFONU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPOSTA_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_ILETISIM", x => x.HASTA_ILETISIM_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_REFERANS_KODLAR_ADRES_KODU_SEVIYESI",
                        column: x => x.ADRES_KODU_SEVIYESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_REFERANS_KODLAR_ADRES_TIPI",
                        column: x => x.ADRES_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_REFERANS_KODLAR_BUCAK_KODU",
                        column: x => x.BUCAK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_REFERANS_KODLAR_ILCE_KODU",
                        column: x => x.ILCE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_REFERANS_KODLAR_IL_KODU",
                        column: x => x.IL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_REFERANS_KODLAR_KOY_KODU",
                        column: x => x.KOY_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ILETISIM_REFERANS_KODLAR_MAHALLE_KODU",
                        column: x => x.MAHALLE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_NOTLARI",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_NOTLARI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_NOT_TURU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HASTA_NOT_ACIKLAMASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_NOTLARI", x => x.HASTA_NOTLARI_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_NOTLARI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_NOTLARI_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_OLUM",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_OLUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OLUM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OLUM_YERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ANNE_OLUM_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTOPSI_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OLUM_BELGESI_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OLUM_NEDENI_TANI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OLUM_NEDENI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OLUM_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EX_KARARINI_VEREN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TUTANAK_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TESLIM_ALAN_TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESLIM_ALAN_ADI_SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESLIM_ALAN_TELEFON_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESLIM_ALAN_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESLIM_EDEN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_OLUM", x => x.HASTA_OLUM_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_PERSONEL_EX_KARARINI_VEREN_HEKIM_KODU",
                        column: x => x.EX_KARARINI_VEREN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_PERSONEL_OLUM_BELGESI_PERSONEL_KODU",
                        column: x => x.OLUM_BELGESI_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_PERSONEL_TESLIM_EDEN_PERSONEL_KODU",
                        column: x => x.TESLIM_EDEN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_REFERANS_KODLAR_ANNE_OLUM_NEDENI",
                        column: x => x.ANNE_OLUM_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_REFERANS_KODLAR_OLUM_NEDENI_TANI_KODU",
                        column: x => x.OLUM_NEDENI_TANI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_REFERANS_KODLAR_OLUM_NEDENI_TURU",
                        column: x => x.OLUM_NEDENI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_REFERANS_KODLAR_OLUM_SEKLI",
                        column: x => x.OLUM_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_REFERANS_KODLAR_OLUM_YERI",
                        column: x => x.OLUM_YERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_OLUM_REFERANS_KODLAR_OTOPSI_DURUMU",
                        column: x => x.OTOPSI_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_SEANS",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_SEANS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEANS_ISLEM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PLANLANAN_SEANS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SEANS_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SEANS_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ANTIHIPERTANSIF_ILAC_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ONCEKI_RRT_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMODIYALIZE_GECME_NEDENLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DAMAR_ERISIM_YOLU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYALIZE_GIRME_SIKLIGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYALIZOR_ALANI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYALIZOR_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_AKIM_HIZI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AGIRLIK_OLCUM_ZAMANI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULLANILAN_DIYALIZ_TEDAVISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERITONEAL_GECIRGENLIK_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERITON_KACINCI_KATETER = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERITON_KATETER_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERITON_KATETER_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERITON_TUNEL_YONU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SINEKALSET = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TEDAVININ_SEYRI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AKTIF_VITAMIN_D_KULLANIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ANEMI_TEDAVISI_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FOSFOR_BAGLAYICI_AJAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERITON_KOMPLIKASYON = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_SEANS", x => x.HASTA_SEANS_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_AGIRLIK_OLCUM_ZAMANI",
                        column: x => x.AGIRLIK_OLCUM_ZAMANI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_AKTIF_VITAMIN_D_KULLANIMI",
                        column: x => x.AKTIF_VITAMIN_D_KULLANIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_ANEMI_TEDAVISI_YONTEMI",
                        column: x => x.ANEMI_TEDAVISI_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_ANTIHIPERTANSIF_ILAC_DURUMU",
                        column: x => x.ANTIHIPERTANSIF_ILAC_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_DAMAR_ERISIM_YOLU",
                        column: x => x.DAMAR_ERISIM_YOLU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_DIYALIZE_GIRME_SIKLIGI",
                        column: x => x.DIYALIZE_GIRME_SIKLIGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_DIYALIZOR_ALANI",
                        column: x => x.DIYALIZOR_ALANI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_DIYALIZOR_TIPI",
                        column: x => x.DIYALIZOR_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_FOSFOR_BAGLAYICI_AJAN",
                        column: x => x.FOSFOR_BAGLAYICI_AJAN,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_HEMODIYALIZE_GECME_NEDENLERI",
                        column: x => x.HEMODIYALIZE_GECME_NEDENLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_KAN_AKIM_HIZI",
                        column: x => x.KAN_AKIM_HIZI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_KULLANILAN_DIYALIZ_TEDAVISI",
                        column: x => x.KULLANILAN_DIYALIZ_TEDAVISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_ONCEKI_RRT_YONTEMI",
                        column: x => x.ONCEKI_RRT_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_PERITONEAL_GECIRGENLIK_DURUMU",
                        column: x => x.PERITONEAL_GECIRGENLIK_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_PERITON_KACINCI_KATETER",
                        column: x => x.PERITON_KACINCI_KATETER,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_PERITON_KATETER_TIPI",
                        column: x => x.PERITON_KATETER_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_PERITON_KATETER_YONTEMI",
                        column: x => x.PERITON_KATETER_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_PERITON_KOMPLIKASYON",
                        column: x => x.PERITON_KOMPLIKASYON,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_PERITON_TUNEL_YONU",
                        column: x => x.PERITON_TUNEL_YONU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_SEANS_ISLEM_TURU",
                        column: x => x.SEANS_ISLEM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_SINEKALSET",
                        column: x => x.SINEKALSET,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEANS_REFERANS_KODLAR_TEDAVININ_SEYRI",
                        column: x => x.TEDAVININ_SEYRI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_SEVK",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_SEVK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_TAKIP_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEVK_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_EDILEN_BRANS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEVK_EDILEN_KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SEVK_TANISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_VASITASI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_TEDAVI_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEVK_EDEN_1_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_EDEN_2_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEVK_EDEN_3_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    REFAKATCI_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_E_SEVK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMBULANS_PROTOKOL_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_SEVK", x => x.HASTA_SEVK_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_KURUM_SEVK_EDILEN_KURUM_KODU",
                        column: x => x.SEVK_EDILEN_KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_PERSONEL_SEVK_EDEN_1_PERSONEL_KODU",
                        column: x => x.SEVK_EDEN_1_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_PERSONEL_SEVK_EDEN_2_PERSONEL_KODU",
                        column: x => x.SEVK_EDEN_2_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_PERSONEL_SEVK_EDEN_3_PERSONEL_KODU",
                        column: x => x.SEVK_EDEN_3_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_REFERANS_KODLAR_SEVK_NEDENI",
                        column: x => x.SEVK_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_REFERANS_KODLAR_SEVK_SEKLI",
                        column: x => x.SEVK_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_REFERANS_KODLAR_SEVK_TANISI",
                        column: x => x.SEVK_TANISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_REFERANS_KODLAR_SEVK_TEDAVI_TIPI",
                        column: x => x.SEVK_TEDAVI_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_SEVK_REFERANS_KODLAR_SEVK_VASITASI_KODU",
                        column: x => x.SEVK_VASITASI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_TIBBI_BILGI",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_TIBBI_BILGI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TIBBI_BILGI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TIBBI_BILGI_ALT_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_TIBBI_BILGI", x => x.HASTA_TIBBI_BILGI_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_TIBBI_BILGI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_TIBBI_BILGI_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_TIBBI_BILGI_REFERANS_KODLAR_TIBBI_BILGI_ALT_TURU",
                        column: x => x.TIBBI_BILGI_ALT_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_TIBBI_BILGI_REFERANS_KODLAR_TIBBI_BILGI_TURU",
                        column: x => x.TIBBI_BILGI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_UYARI",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_UYARI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UYARI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISLEME_IZIN_VERME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HASTA_UYARI_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HASTA_UYARI_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_UYARI", x => x.HASTA_UYARI_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_UYARI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_UYARI_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_UYARI_REFERANS_KODLAR_UYARI_TURU",
                        column: x => x.UYARI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_VENTILATOR",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_VENTILATOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VENTILATOR_CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YOGUN_BAKIM_SEVIYE_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VENTILATOR_BAGLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VENTILATOR_AYRILMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_VENTILATOR", x => x.HASTA_VENTILATOR_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_VENTILATOR_CIHAZ_VENTILATOR_CIHAZ_KODU",
                        column: x => x.VENTILATOR_CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_VENTILATOR_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_VENTILATOR_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_VENTILATOR_REFERANS_KODLAR_YOGUN_BAKIM_SEVIYE_BILGISI",
                        column: x => x.YOGUN_BAKIM_SEVIYE_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_VITAL_FIZIKI_BULGU",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_VITAL_FIZIKI_BULGU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISLEM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SISTOLIK_KAN_BASINCI_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIASTOLIK_KAN_BASINCI_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NABIZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOLUNUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ATES = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BAS_CEVRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BOY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AGIRLIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SATURASYON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BEL_CEVRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KALCA_CEVRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KOL_CEVRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KARIN_CEVRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEMSIRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_VITAL_FIZIKI_BULGU", x => x.HASTA_VITAL_FIZIKI_BULGU_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_VITAL_FIZIKI_BULGU_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_VITAL_FIZIKI_BULGU_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_VITAL_FIZIKI_BULGU_PERSONEL_HEMSIRE_KODU",
                        column: x => x.HEMSIRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_YATAK",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_YATAK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    YATAK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    YATIS_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YATIS_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_YATAK", x => x.HASTA_YATAK_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_YATAK_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_YATAK_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_YATAK_YATAK_YATAK_KODU",
                        column: x => x.YATAK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "YATAK",
                        principalColumn: "YATAK_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HEMOGLOBINOPATI",
                schema: "Lbys",
                columns: table => new
                {
                    HEMOGLOBINOPATI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMOGLOBINOPATI_TARAMA_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ES_ADAYI_TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ES_ADAYI_TELEFON_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEMOGLOBINOPATI_TESTI_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMOGLOBINOPATI_ISLEM_TIPI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEMOGLOBINOPATI_SONUC_HASTALIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMOGLOBINOPATI_TASIYICILIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HEMOGLOBINOPATI", x => x.HEMOGLOBINOPATI_KODU);
                    table.ForeignKey(
                        name: "FK_HEMOGLOBINOPATI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMOGLOBINOPATI_REFERANS_KODLAR_HEMOGLOBINOPATI_SONUC_HASTALIK",
                        column: x => x.HEMOGLOBINOPATI_SONUC_HASTALIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMOGLOBINOPATI_REFERANS_KODLAR_HEMOGLOBINOPATI_TARAMA_SONUCU",
                        column: x => x.HEMOGLOBINOPATI_TARAMA_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMOGLOBINOPATI_REFERANS_KODLAR_HEMOGLOBINOPATI_TASIYICILIK",
                        column: x => x.HEMOGLOBINOPATI_TASIYICILIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMOGLOBINOPATI_REFERANS_KODLAR_HEMOGLOBINOPATI_TESTI_SONUCU",
                        column: x => x.HEMOGLOBINOPATI_TESTI_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HEMSIRE_BAKIM",
                schema: "Lbys",
                columns: table => new
                {
                    HEMSIRE_BAKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMSIRE_DEGERLENDIRME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HEMSIRELIK_TANI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAKIM_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMSIRE_BAKIM_HEDEF_SONUC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMSIRELIK_GIRISIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMSIRE_DEGERLENDIRME_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMSIRE_DEGERLENDIRME_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEMSIRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HEMSIRE_BAKIM", x => x.HEMSIRE_BAKIM_KODU);
                    table.ForeignKey(
                        name: "FK_HEMSIRE_BAKIM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMSIRE_BAKIM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMSIRE_BAKIM_PERSONEL_HEMSIRE_KODU",
                        column: x => x.HEMSIRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMSIRE_BAKIM_REFERANS_KODLAR_BAKIM_NEDENI",
                        column: x => x.BAKIM_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMSIRE_BAKIM_REFERANS_KODLAR_HEMSIRELIK_GIRISIMI",
                        column: x => x.HEMSIRELIK_GIRISIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMSIRE_BAKIM_REFERANS_KODLAR_HEMSIRELIK_TANI_KODU",
                        column: x => x.HEMSIRELIK_TANI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMSIRE_BAKIM_REFERANS_KODLAR_HEMSIRE_BAKIM_HEDEF_SONUC",
                        column: x => x.HEMSIRE_BAKIM_HEDEF_SONUC,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HEMSIRE_BAKIM_REFERANS_KODLAR_HEMSIRE_DEGERLENDIRME_DURUMU",
                        column: x => x.HEMSIRE_DEGERLENDIRME_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INTIHAR_IZLEM",
                schema: "Lbys",
                columns: table => new
                {
                    INTIHAR_IZLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_KRIZ_VAKA_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_GIRISIM_KRIZ_NEDENLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_GIRISIMI_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    INTIHAR_KRIZ_VAKA_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTIHAR_IZLEM", x => x.INTIHAR_IZLEM_KODU);
                    table.ForeignKey(
                        name: "FK_INTIHAR_IZLEM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INTIHAR_IZLEM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INTIHAR_IZLEM_REFERANS_KODLAR_INTIHAR_GIRISIMI_YONTEMI",
                        column: x => x.INTIHAR_GIRISIMI_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INTIHAR_IZLEM_REFERANS_KODLAR_INTIHAR_GIRISIM_KRIZ_NEDENLERI",
                        column: x => x.INTIHAR_GIRISIM_KRIZ_NEDENLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INTIHAR_IZLEM_REFERANS_KODLAR_INTIHAR_KRIZ_VAKA_SONUCU",
                        column: x => x.INTIHAR_KRIZ_VAKA_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INTIHAR_IZLEM_REFERANS_KODLAR_INTIHAR_KRIZ_VAKA_TURU",
                        column: x => x.INTIHAR_KRIZ_VAKA_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KADIN_IZLEM",
                schema: "Lbys",
                columns: table => new
                {
                    KADIN_IZLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KONJENITAL_ANOMALI_VARLIGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CANLI_DOGAN_BEBEK_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OLU_DOGAN_BEBEK_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEMOGLOBIN_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ONCEKI_DOGUM_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IZLEMIN_YAPILDIGI_YER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KULLANILAN_AP_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIR_ONCE_KULLANILAN_AP_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AP_YONTEMI_LOJISTIGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KADIN_SAGLIGI_ISLEMLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AP_YONTEMI_KULLANMAMA_NEDENI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KADIN_IZLEM", x => x.KADIN_IZLEM_KODU);
                    table.ForeignKey(
                        name: "FK_KADIN_IZLEM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KADIN_IZLEM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KADIN_IZLEM_REFERANS_KODLAR_AP_YONTEMI_LOJISTIGI",
                        column: x => x.AP_YONTEMI_LOJISTIGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KADIN_IZLEM_REFERANS_KODLAR_BIR_ONCE_KULLANILAN_AP_YONTEMI",
                        column: x => x.BIR_ONCE_KULLANILAN_AP_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KADIN_IZLEM_REFERANS_KODLAR_KADIN_SAGLIGI_ISLEMLERI",
                        column: x => x.KADIN_SAGLIGI_ISLEMLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KADIN_IZLEM_REFERANS_KODLAR_KONJENITAL_ANOMALI_VARLIGI",
                        column: x => x.KONJENITAL_ANOMALI_VARLIGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KADIN_IZLEM_REFERANS_KODLAR_KULLANILAN_AP_YONTEMI",
                        column: x => x.KULLANILAN_AP_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KADIN_IZLEM_REFERANS_KODLAR_ONCEKI_DOGUM_DURUMU",
                        column: x => x.ONCEKI_DOGUM_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KAN_BAGISCI",
                schema: "Lbys",
                columns: table => new
                {
                    KAN_BAGISCI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAGISCI_HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAGISCI_HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_BAGIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KAN_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REZERV_HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAGISLANAN_KAN_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    REAKSIYON_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REAKSIYON_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    REAKSIYON_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KIZILAY_IZIN_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SISTOLIK_KAN_BASINCI_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIASTOLIK_KAN_BASINCI_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ATES = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BOY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AGIRLIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UZMAN_DEGERLENDIRME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOT_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_HACIM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEGMENT_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BAGISCI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_BAGIS_DEGERLENDIRME_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEGERLENDIREN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_BAGIS_DEGERLENDIRME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KAN_BAGISCISI_RET_NEDENLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RET_SURESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KAN_BAGISCI", x => x.KAN_BAGISCI_KODU);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_HASTA_BAGISCI_HASTA_KODU",
                        column: x => x.BAGISCI_HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_HASTA_BASVURU_BAGISCI_HASTA_BASVURU_KODU",
                        column: x => x.BAGISCI_HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_HASTA_REZERV_HASTA_KODU",
                        column: x => x.REZERV_HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_PERSONEL_DEGERLENDIREN_PERSONEL_KODU",
                        column: x => x.DEGERLENDIREN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_REFERANS_KODLAR_BAGISCI_TURU",
                        column: x => x.BAGISCI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_REFERANS_KODLAR_BAGISLANAN_KAN_TURU",
                        column: x => x.BAGISLANAN_KAN_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_REFERANS_KODLAR_KAN_BAGISCISI_RET_NEDENLERI",
                        column: x => x.KAN_BAGISCISI_RET_NEDENLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_REFERANS_KODLAR_KAN_BAGIS_DEGERLENDIRME_SONUCU",
                        column: x => x.KAN_BAGIS_DEGERLENDIRME_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_REFERANS_KODLAR_KAN_GRUBU",
                        column: x => x.KAN_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_BAGISCI_REFERANS_KODLAR_REAKSIYON_TURU",
                        column: x => x.REAKSIYON_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KAN_TALEP",
                schema: "Lbys",
                columns: table => new
                {
                    KAN_TALEP_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_TALEP_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KAN_TALEP_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_TALEP_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_ISTEYEN_BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTEYEN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTENEN_KAN_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PLANLANAN_TRANSFUZYON_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PLANLANAN_TRANSFUZYON_SURESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_TALEP_ACILIYET_SEVIYESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CROSS_MATCH_YAPILMA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_ACIL_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_ANTIKOR_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANSPLANTASYON_GECIRME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANSFUZYON_GECIRME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANSFUZYON_REAKSIYON_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GEBELIK_GECIRME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FETOMATERNAL_UYUSMAZLIK_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_TALEP_OZEL_DURUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEMATOKRIT_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TROMBOSIT_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_ENDIKASYON_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KAN_TALEP", x => x.KAN_TALEP_KODU);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_BIRIM_KAN_ISTEYEN_BIRIM_KODU",
                        column: x => x.KAN_ISTEYEN_BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_PERSONEL_ISTEYEN_HEKIM_KODU",
                        column: x => x.ISTEYEN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_REFERANS_KODLAR_ISTENEN_KAN_GRUBU",
                        column: x => x.ISTENEN_KAN_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_REFERANS_KODLAR_KAN_ENDIKASYON_TURU",
                        column: x => x.KAN_ENDIKASYON_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_REFERANS_KODLAR_KAN_TALEP_ACILIYET_SEVIYESI",
                        column: x => x.KAN_TALEP_ACILIYET_SEVIYESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_REFERANS_KODLAR_KAN_TALEP_NEDENI",
                        column: x => x.KAN_TALEP_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KLINIK_SEYIR",
                schema: "Lbys",
                columns: table => new
                {
                    KLINIK_SEYIR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEYIR_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEYIR_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SEYIR_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEPTIK_SOK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEPSIS_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KLINIK_SEYIR", x => x.KLINIK_SEYIR_KODU);
                    table.ForeignKey(
                        name: "FK_KLINIK_SEYIR_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KLINIK_SEYIR_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KLINIK_SEYIR_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KLINIK_SEYIR_REFERANS_KODLAR_SEPSIS_DURUMU",
                        column: x => x.SEPSIS_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KLINIK_SEYIR_REFERANS_KODLAR_SEPTIK_SOK",
                        column: x => x.SEPTIK_SOK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KLINIK_SEYIR_REFERANS_KODLAR_SEYIR_TIPI",
                        column: x => x.SEYIR_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KUDUZ_IZLEM",
                schema: "Lbys",
                columns: table => new
                {
                    KUDUZ_IZLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PROFILAKSI_TAMAMLANMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UYGULANAN_KUDUZ_PROFILAKSISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BEYAN_TSM_KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IMMUNGLOBULIN_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KUDUZ_IZLEM", x => x.KUDUZ_IZLEM_KODU);
                    table.ForeignKey(
                        name: "FK_KUDUZ_IZLEM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KUDUZ_IZLEM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KUDUZ_IZLEM_KURUM_BEYAN_TSM_KURUM_KODU",
                        column: x => x.BEYAN_TSM_KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KUDUZ_IZLEM_REFERANS_KODLAR_PROFILAKSI_TAMAMLANMA_DURUMU",
                        column: x => x.PROFILAKSI_TAMAMLANMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KUDUZ_IZLEM_REFERANS_KODLAR_UYGULANAN_KUDUZ_PROFILAKSISI",
                        column: x => x.UYGULANAN_KUDUZ_PROFILAKSISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KURUL_RAPOR",
                schema: "Lbys",
                columns: table => new
                {
                    KURUL_RAPOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RAPOR_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAPOR_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAPOR_KARAR_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAPOR_SIRA_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAPOR_TAKIP_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KURUL_RAPOR_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAPOR_BASLAMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RAPOR_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LABORATUVAR_BULGU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KURUL_RAPOR_MUAYENE_BULGUSU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KURUL_TANI_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KURUL_RAPOR_KARARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KARAR_ICERIK_FORMATI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MURACAAT_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENGELLILIK_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ILAC_RAPOR_DUZELTME_ACIKLAMASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KURUL_RAPOR", x => x.KURUL_RAPOR_KODU);
                    table.ForeignKey(
                        name: "FK_KURUL_RAPOR_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_RAPOR_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_RAPOR_KURUL_KURUL_KODU",
                        column: x => x.KURUL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUL",
                        principalColumn: "KURUL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_RAPOR_REFERANS_KODLAR_KARAR_ICERIK_FORMATI",
                        column: x => x.KARAR_ICERIK_FORMATI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOHUSA_IZLEM",
                schema: "Lbys",
                columns: table => new
                {
                    LOHUSA_IZLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KACINCI_LOHUSA_IZLEM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IZLEMIN_YAPILDIGI_YER = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEMIR_LOJISTIGI_VE_DESTEGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DVITAMINI_LOJISTIGI_VE_DESTEGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GEBELIK_SONLANMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    POSTPARTUM_DEPRESYON = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UTERUS_INVOLUSYON = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BILGI_ALINAN_KISI_AD_SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BILGI_ALINAN_KISI_TELEFON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KONJENITAL_ANOMALI_VARLIGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEMOGLOBIN_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KOMPLIKASYON_TANISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEYIR_TEHLIKE_ISARETI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KADIN_SAGLIGI_ISLEMLERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOHUSA_IZLEM", x => x.LOHUSA_IZLEM_KODU);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_DEMIR_LOJISTIGI_VE_DESTEGI",
                        column: x => x.DEMIR_LOJISTIGI_VE_DESTEGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_DVITAMINI_LOJISTIGI_VE_DESTEGI",
                        column: x => x.DVITAMINI_LOJISTIGI_VE_DESTEGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_IZLEMIN_YAPILDIGI_YER",
                        column: x => x.IZLEMIN_YAPILDIGI_YER,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_KACINCI_LOHUSA_IZLEM",
                        column: x => x.KACINCI_LOHUSA_IZLEM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_KADIN_SAGLIGI_ISLEMLERI",
                        column: x => x.KADIN_SAGLIGI_ISLEMLERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_KOMPLIKASYON_TANISI",
                        column: x => x.KOMPLIKASYON_TANISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_KONJENITAL_ANOMALI_VARLIGI",
                        column: x => x.KONJENITAL_ANOMALI_VARLIGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_POSTPARTUM_DEPRESYON",
                        column: x => x.POSTPARTUM_DEPRESYON,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_SEYIR_TEHLIKE_ISARETI",
                        column: x => x.SEYIR_TEHLIKE_ISARETI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LOHUSA_IZLEM_REFERANS_KODLAR_UTERUS_INVOLUSYON",
                        column: x => x.UTERUS_INVOLUSYON,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MADDE_BAGIMLILIGI",
                schema: "Lbys",
                columns: table => new
                {
                    MADDE_BAGIMLILIGI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BILGI_ALINAN_KAYNAK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DANISMA_TEDAVI_HIZMET_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DANISMA_TEDAVI_HIZMET_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IKAME_TEDAVI_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SON_IKAME_TEDAVI_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CEZAEVI_OYKUSU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SOSYAL_YARDIM_ALMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YASADIGI_BOLGE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YASAM_BICIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    COCUKLARIYLA_YASAMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ENJEKSIYON_ILE_MADDE_KULLANIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ENJEKSIYON_ILK_KULLANIM_YASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENJEKTOR_PAYLASIM_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILK_ENJEKTOR_PAYLASIM_YASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HIV_TEST_YAPILMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HCV_TEST_YAPILMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HBV_TEST_YAPILMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GORUSME_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GONDEREN_BIRIM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YASAM_ORTAMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BULASICI_HASTALIK_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BASLANAN_TEDAVI_TIPI_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRINCIL_KULLANILAN_ESAS_MADDE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULLANILAN_DIGER_MADDE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MADDE_BAGIMLILIGI", x => x.MADDE_BAGIMLILIGI_KODU);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_BASLANAN_TEDAVI_TIPI_BILGISI",
                        column: x => x.BASLANAN_TEDAVI_TIPI_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_BILGI_ALINAN_KAYNAK",
                        column: x => x.BILGI_ALINAN_KAYNAK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_BIRINCIL_KULLANILAN_ESAS_MADDE",
                        column: x => x.BIRINCIL_KULLANILAN_ESAS_MADDE,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_BULASICI_HASTALIK_DURUMU",
                        column: x => x.BULASICI_HASTALIK_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_CEZAEVI_OYKUSU",
                        column: x => x.CEZAEVI_OYKUSU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_COCUKLARIYLA_YASAMA_DURUMU",
                        column: x => x.COCUKLARIYLA_YASAMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_DANISMA_TEDAVI_HIZMET_DURUMU",
                        column: x => x.DANISMA_TEDAVI_HIZMET_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_ENJEKSIYON_ILE_MADDE_KULLANIMI",
                        column: x => x.ENJEKSIYON_ILE_MADDE_KULLANIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_ENJEKTOR_PAYLASIM_DURUMU",
                        column: x => x.ENJEKTOR_PAYLASIM_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_GONDEREN_BIRIM",
                        column: x => x.GONDEREN_BIRIM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_GORUSME_SONUCU",
                        column: x => x.GORUSME_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_HBV_TEST_YAPILMA_DURUMU",
                        column: x => x.HBV_TEST_YAPILMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_HCV_TEST_YAPILMA_DURUMU",
                        column: x => x.HCV_TEST_YAPILMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_HIV_TEST_YAPILMA_DURUMU",
                        column: x => x.HIV_TEST_YAPILMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_IKAME_TEDAVI_DURUMU",
                        column: x => x.IKAME_TEDAVI_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_KULLANILAN_DIGER_MADDE",
                        column: x => x.KULLANILAN_DIGER_MADDE,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_SOSYAL_YARDIM_ALMA_DURUMU",
                        column: x => x.SOSYAL_YARDIM_ALMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_YASADIGI_BOLGE",
                        column: x => x.YASADIGI_BOLGE,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_YASAM_BICIMI",
                        column: x => x.YASAM_BICIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MADDE_BAGIMLILIGI_REFERANS_KODLAR_YASAM_ORTAMI",
                        column: x => x.YASAM_ORTAMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MEDULA_TAKIP",
                schema: "Lbys",
                columns: table => new
                {
                    MEDULA_TAKIP_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SGK_TAKIP_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SGK_ILKTAKIP_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_TESIS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_BRANS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PROVIZYON_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PROVIZYON_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CINSIYET = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FATURA_TESLIM_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FATURA_TESLIM_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TEDAVI_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SIGORTALI_TURU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEVREDILEN_KURUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SONUC_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SONUC_MESAJI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TAKIP_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BASVURU_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TEDAVI_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TEDAVI_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDULA_TAKIP", x => x.MEDULA_TAKIP_KODU);
                    table.ForeignKey(
                        name: "FK_MEDULA_TAKIP_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MEDULA_TAKIP_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MEDULA_TAKIP_REFERANS_KODLAR_PROVIZYON_TURU",
                        column: x => x.PROVIZYON_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MEDULA_TAKIP_REFERANS_KODLAR_TAKIP_TIPI",
                        column: x => x.TAKIP_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MEDULA_TAKIP_REFERANS_KODLAR_TEDAVI_SEKLI",
                        column: x => x.TEDAVI_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MEDULA_TAKIP_REFERANS_KODLAR_TEDAVI_TIPI",
                        column: x => x.TEDAVI_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MEDULA_TAKIP_REFERANS_KODLAR_TEDAVI_TURU",
                        column: x => x.TEDAVI_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OBEZITE_IZLEM",
                schema: "Lbys",
                columns: table => new
                {
                    OBEZITE_IZLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIYET_TIBBI_BESLENME_TEDAVISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILK_TANI_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MORBIT_OBEZ_LENFATIK_ODEM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OBEZITE_ILAC_TEDAVISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PSIKOLOJIK_TEDAVI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRLIKTE_GORULEN_EK_HASTALIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EGZERSIZ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OBEZITE_IZLEM", x => x.OBEZITE_IZLEM_KODU);
                    table.ForeignKey(
                        name: "FK_OBEZITE_IZLEM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OBEZITE_IZLEM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OBEZITE_IZLEM_REFERANS_KODLAR_BIRLIKTE_GORULEN_EK_HASTALIK",
                        column: x => x.BIRLIKTE_GORULEN_EK_HASTALIK,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OBEZITE_IZLEM_REFERANS_KODLAR_DIYET_TIBBI_BESLENME_TEDAVISI",
                        column: x => x.DIYET_TIBBI_BESLENME_TEDAVISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OBEZITE_IZLEM_REFERANS_KODLAR_EGZERSIZ",
                        column: x => x.EGZERSIZ,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OBEZITE_IZLEM_REFERANS_KODLAR_MORBIT_OBEZ_LENFATIK_ODEM",
                        column: x => x.MORBIT_OBEZ_LENFATIK_ODEM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OBEZITE_IZLEM_REFERANS_KODLAR_OBEZITE_ILAC_TEDAVISI",
                        column: x => x.OBEZITE_ILAC_TEDAVISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OBEZITE_IZLEM_REFERANS_KODLAR_PSIKOLOJIK_TEDAVI",
                        column: x => x.PSIKOLOJIK_TEDAVI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPTIK_RECETE",
                schema: "Lbys",
                columns: table => new
                {
                    OPTIK_RECETE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GOZLUK_RECETE_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RECETE_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GOZLUK_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SAG_CAM_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SAG_CAM_RENGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SAG_CAM_SFERIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_CAM_SILINDIRIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_CAM_AKS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_CAM_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SOL_CAM_RENGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SOL_CAM_SFERIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_CAM_SILINDIRIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_CAM_AKS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_LENS_CAM_SFERIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_LENS_CAM_SILINDIRIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_LENS_CAM_CAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_LENS_CAM_EGIM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_LENS_CAM_AKS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_LENS_CAM_SFERIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_LENS_CAM_SILINDIRIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_LENS_CAM_CAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_LENS_CAM_EGIM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_LENS_CAM_AKS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_KERATAKONUS_CAM_SFERIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_KERATAKONUS_CAM_SILINDIR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_KERATAKONUS_CAM_CAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_KERATAKONUS_CAM_EGIM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAG_KERATAKONUS_CAM_AKS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_KERATAKONUS_CAM_SFERIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_KERATAKONUS_CAM_SILINDIR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_KERATAKONUS_CAM_CAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_KERATAKONUS_CAM_EGIM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOL_KERATAKONUS_CAM_AKS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELESKOPIK_GOZLUK_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TELESKOPIK_GOZLUK_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TELESKOPIK_SAG_CAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELESKOPIK_SOL_CAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPTIK_RECETE", x => x.OPTIK_RECETE_KODU);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_REFERANS_KODLAR_GOZLUK_RECETE_TIPI",
                        column: x => x.GOZLUK_RECETE_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_REFERANS_KODLAR_GOZLUK_TURU",
                        column: x => x.GOZLUK_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_REFERANS_KODLAR_SAG_CAM_RENGI",
                        column: x => x.SAG_CAM_RENGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_REFERANS_KODLAR_SAG_CAM_TIPI",
                        column: x => x.SAG_CAM_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_REFERANS_KODLAR_SOL_CAM_RENGI",
                        column: x => x.SOL_CAM_RENGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_REFERANS_KODLAR_SOL_CAM_TIPI",
                        column: x => x.SOL_CAM_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_REFERANS_KODLAR_TELESKOPIK_GOZLUK_TIPI",
                        column: x => x.TELESKOPIK_GOZLUK_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPTIK_RECETE_REFERANS_KODLAR_TELESKOPIK_GOZLUK_TURU",
                        column: x => x.TELESKOPIK_GOZLUK_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORTODONTI_ICON_SKOR",
                schema: "Lbys",
                columns: table => new
                {
                    ORTODONTI_ICON_SKOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OIS_DEGERLENDIRME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OIS_ESTETIK_BOZUKLUK_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OIS_ESTETIK_PUAN_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OIS_ESTETIK_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UST_DIS_ARKA_CAPRASIKLIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UST_ARKA_CAPRASIKLIK_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UST_ARKA_CAPRASIKLIK_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UST_DIS_ARKA_BOSLUK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UST_ARKA_BOSLUK_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UST_ARKA_BOSLUK_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIS_CAPRAZLIK_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIS_CAPRAZLIK_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIS_CAPRAZLIK_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ON_ACIK_KAPANIS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ON_ACIK_KAPANIS_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ON_ACIK_KAPANIS_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ON_DERIN_KAPANIS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ON_DERIN_KAPANIS_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ON_DERIN_KAPANIS_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUKKAL_BOLGE_SAG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUKKAL_BOLGE_SAG_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUKKAL_BOLGE_SAG_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUKKAL_BOLGE_SOL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUKKAL_BOLGE_SOL_KATSAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUKKAL_BOLGE_SOL_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUKKAL_TOPLAM_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOPLAM_ICON_SKOR_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OIS_DEGERLENDIREN_1_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OIS_DEGERLENDIREN_2_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OIS_DEGERLENDIREN_3_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORTODONTI_ICON_SKOR", x => x.ORTODONTI_ICON_SKOR_KODU);
                    table.ForeignKey(
                        name: "FK_ORTODONTI_ICON_SKOR_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORTODONTI_ICON_SKOR_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORTODONTI_ICON_SKOR_PERSONEL_OIS_DEGERLENDIREN_1_HEKIM_KODU",
                        column: x => x.OIS_DEGERLENDIREN_1_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORTODONTI_ICON_SKOR_PERSONEL_OIS_DEGERLENDIREN_2_HEKIM_KODU",
                        column: x => x.OIS_DEGERLENDIREN_2_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORTODONTI_ICON_SKOR_PERSONEL_OIS_DEGERLENDIREN_3_HEKIM_KODU",
                        column: x => x.OIS_DEGERLENDIREN_3_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RECETE",
                schema: "Lbys",
                columns: table => new
                {
                    RECETE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RECETE_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RECETE_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RECETE_ALT_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DEFTER_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEDULA_E_RECETE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RENKLI_RECETE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SERI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RECETE_E_IMZA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SGK_TAKIP_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECETE", x => x.RECETE_KODU);
                    table.ForeignKey(
                        name: "FK_RECETE_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_REFERANS_KODLAR_RECETE_ALT_TURU",
                        column: x => x.RECETE_ALT_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_REFERANS_KODLAR_RECETE_TURU",
                        column: x => x.RECETE_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOK_FIS",
                schema: "Lbys",
                columns: table => new
                {
                    STOK_FIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAGLI_STOK_FIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HAREKET_TURU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MKYS_AYNIYAT_MAKBUZ_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HAREKET_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHCEK_PAYI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HAZINE_PAYI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAGLIK_BAKANLIGI_PAYI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BEDELSIZ_FIS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIS_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HAREKET_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISLEMI_YAPAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISLEM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FIRMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IHALE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IHALE_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IHALE_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MUAYENE_KABUL_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MUAYENE_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TESLIM_EDEN_KISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESLIM_EDEN_KISI_UNVANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUTCE_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FATURA_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FATURA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IRSALIYE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IRSALIYE_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MKYS_KURUM_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOK_FIS", x => x.STOK_FIS_KODU);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_DEPO_DEPO_KODU",
                        column: x => x.DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_FIRMA_FIRMA_KODU",
                        column: x => x.FIRMA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "FIRMA",
                        principalColumn: "FIRMA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_PERSONEL_ISLEMI_YAPAN_PERSONEL_KODU",
                        column: x => x.ISLEMI_YAPAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_REFERANS_KODLAR_BUTCE_TURU",
                        column: x => x.BUTCE_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_REFERANS_KODLAR_HAREKET_SEKLI",
                        column: x => x.HAREKET_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_REFERANS_KODLAR_IHALE_TURU",
                        column: x => x.IHALE_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_FIS_STOK_FIS_BAGLI_STOK_FIS_KODU",
                        column: x => x.BAGLI_STOK_FIS_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_FIS",
                        principalColumn: "STOK_FIS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYS_PAKET",
                schema: "Lbys",
                columns: table => new
                {
                    SYS_PAKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VERI_PAKETI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VERI_PAKETI_GONDERILME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VERI_PAKETI_GONDERIM_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GONDERILEN_PAKET_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GELEN_CEVAP_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_PAKET", x => x.SYS_PAKET_KODU);
                    table.ForeignKey(
                        name: "FK_SYS_PAKET_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYS_PAKET_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIBBI_ORDER",
                schema: "Lbys",
                columns: table => new
                {
                    TIBBI_ORDER_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TIBBI_ORDER_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ORDER_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIBBI_ORDER", x => x.TIBBI_ORDER_KODU);
                    table.ForeignKey(
                        name: "FK_TIBBI_ORDER_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TIBBI_ORDER_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TIBBI_ORDER_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TIBBI_ORDER_REFERANS_KODLAR_TIBBI_ORDER_TURU",
                        column: x => x.TIBBI_ORDER_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEZNE",
                schema: "Lbys",
                columns: table => new
                {
                    VEZNE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MAKBUZ_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VEZNE_OZEL_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VEZNE_GIRIS_CIKIS_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAKBUZ_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VEZNE_BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MAKBUZ_SERI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPTAL_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPTAL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPTAL_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TAHSIL_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MAKBUZ_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAKBUZ_SAHIBI_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRMA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEZNE", x => x.VEZNE_KODU);
                    table.ForeignKey(
                        name: "FK_VEZNE_BIRIM_VEZNE_BIRIM_KODU",
                        column: x => x.VEZNE_BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEZNE_FIRMA_FIRMA_KODU",
                        column: x => x.FIRMA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "FIRMA",
                        principalColumn: "FIRMA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEZNE_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEZNE_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEZNE_REFERANS_KODLAR_TAHSIL_TURU",
                        column: x => x.TAHSIL_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRUP_UYELIK",
                schema: "Lbys",
                columns: table => new
                {
                    GRUP_UYELIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULLANICI_GRUP_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUP_UYELIK", x => x.GRUP_UYELIK_KODU);
                    table.ForeignKey(
                        name: "FK_GRUP_UYELIK_KULLANICI_GRUP_KULLANICI_GRUP_KODU",
                        column: x => x.KULLANICI_GRUP_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI_GRUP",
                        principalColumn: "KULLANICI_GRUP_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GRUP_UYELIK_KULLANICI_KULLANICI_KODU",
                        column: x => x.KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_ADLI_RAPOR",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_ADLI_RAPOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ADLI_RAPOR_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RAPOR_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ADLI_MUAYENEYE_GONDEREN_KURUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RESMI_YAZI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RESMI_YAZI_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ADLI_MUAYENE_EDILME_NEDENI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GUVENLIK_SICIL_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GUVENLIK_ADI_SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OLAY_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ADLI_OLAY_OYKUSU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SIKAYET = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OZGECMISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOYGECMISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MUAYENE_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TIBBI_MUDAHALE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UYGUN_SART_SAGLANMA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UYGUN_SART_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ELBISE_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KONSULTASYON_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LEZYON_BULGULARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SISTEM_BULGULARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BILINC_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PUPILLA_DEGERLENDIRMESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISIK_REFLEKSI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NABIZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TENDON_REFLEKSI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PSIKIYATRIK_MUAYENE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSIKIYATRIK_SONUC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HIZMET_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEVK_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEVK_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESLIM_ALAN_ADI_SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TESLIM_ALAN_TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VUCUT_DIYAGRAMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADLI_MUAYENE_RIZA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RIZA_VEREN_KISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RIZA_VERENIN_YAKINLIK_DERECESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SON_CINSEL_ILISKI_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HAMILELIK_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HAMILELIK_OYKUSU_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VENERYAL_HASTALIK_OYKUSU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMOSYONEL_HASTALIK_OYKUSU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOLUNUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADLI_MUAYENE_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALINAN_MATERYAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MUAYENEDEKI_KISI_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MUAYENEDEKI_KISI_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALKOL_KULLANIMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SIDDET_TEHDIT_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SILAH_ALET_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HAYATI_TEHLIKE_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SISTOLIK_KAN_BASINCI_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIASTOLIK_KAN_BASINCI_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPTAL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPTAL_EDEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ADLI_RAPOR_IPTAL_GEREKCESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ONAYLAYAN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ADLI_RAPOR_ONAYLANMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_ADLI_RAPOR", x => x.HASTA_ADLI_RAPOR_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_KULLANICI_IPTAL_EDEN_KULLANICI_KODU",
                        column: x => x.IPTAL_EDEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_KULLANICI_ONAYLAYAN_KULLANICI_KODU",
                        column: x => x.ONAYLAYAN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_REFERANS_KODLAR_ADLI_MUAYENE_RIZA_DURUMU",
                        column: x => x.ADLI_MUAYENE_RIZA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_REFERANS_KODLAR_ADLI_RAPOR_TURU",
                        column: x => x.ADLI_RAPOR_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_REFERANS_KODLAR_ELBISE_DURUMU",
                        column: x => x.ELBISE_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_REFERANS_KODLAR_ISIK_REFLEKSI",
                        column: x => x.ISIK_REFLEKSI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_REFERANS_KODLAR_PUPILLA_DEGERLENDIRMESI",
                        column: x => x.PUPILLA_DEGERLENDIRMESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_REFERANS_KODLAR_RIZA_VERENIN_YAKINLIK_DERECESI",
                        column: x => x.RIZA_VERENIN_YAKINLIK_DERECESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ADLI_RAPOR_REFERANS_KODLAR_TENDON_REFLEKSI",
                        column: x => x.TENDON_REFLEKSI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_ARSIV_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_ARSIV_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_ARSIV_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOSYA_ALAN_BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOSYANIN_ALINDIGI_ZAMAN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOSYA_ALAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOSYA_VEREN_BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOSYANIN_VERILDIGI_ZAMAN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOSYA_VEREN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_ARSIV_DETAY", x => x.HASTA_ARSIV_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_DETAY_BIRIM_DOSYA_ALAN_BIRIM_KODU",
                        column: x => x.DOSYA_ALAN_BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_DETAY_BIRIM_DOSYA_VEREN_BIRIM_KODU",
                        column: x => x.DOSYA_VEREN_BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_DETAY_HASTA_ARSIV_HASTA_ARSIV_KODU",
                        column: x => x.HASTA_ARSIV_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_ARSIV",
                        principalColumn: "HASTA_ARSIV_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_DETAY_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_DETAY_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_DETAY_KULLANICI_DOSYA_VEREN_KULLANICI_KODU",
                        column: x => x.DOSYA_VEREN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_ARSIV_DETAY_PERSONEL_DOSYA_ALAN_PERSONEL_KODU",
                        column: x => x.DOSYA_ALAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONEL_IZIN",
                schema: "Lbys",
                columns: table => new
                {
                    PERSONEL_IZIN_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERSONEL_IZIN_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KULLANILAN_IZIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GECEN_YILDAN_KULLANILAN_IZIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AKTIF_YILDAN_KULLANILAN_IZIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IZIN_BASLAMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IZIN_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PERSONEL_IZIN_YILI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERSONEL_DONUS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IZIN_ADRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SBYS_ENGELLENME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SBYS_KULLANIM_ENGELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SBYS_ENGELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ONAYLAYAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONEL_IZIN", x => x.PERSONEL_IZIN_KODU);
                    table.ForeignKey(
                        name: "FK_PERSONEL_IZIN_KULLANICI_SBYS_ENGELLEYEN_KULLANICI_KODU",
                        column: x => x.SBYS_ENGELLEYEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_IZIN_PERSONEL_ONAYLAYAN_PERSONEL_KODU",
                        column: x => x.ONAYLAYAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_IZIN_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERSONEL_IZIN_REFERANS_KODLAR_PERSONEL_IZIN_TURU",
                        column: x => x.PERSONEL_IZIN_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RANDEVU",
                schema: "Lbys",
                columns: table => new
                {
                    RANDEVU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RANDEVU_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RANDEVU_ALT_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RANDEVU_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RANDEVU_KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MHRS_HRN_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MHRS_RANDEVU_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RANDEVU_GELME_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SOYADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CINSIYET = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TELEFON_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPTAL_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPTAL_EDEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IPTAL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPTAL_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RANDEVU", x => x.RANDEVU_KODU);
                    table.ForeignKey(
                        name: "FK_RANDEVU_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_KULLANICI_IPTAL_EDEN_KULLANICI_KODU",
                        column: x => x.IPTAL_EDEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_REFERANS_KODLAR_CINSIYET",
                        column: x => x.CINSIYET,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_REFERANS_KODLAR_RANDEVU_ALT_TURU",
                        column: x => x.RANDEVU_ALT_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_REFERANS_KODLAR_RANDEVU_GELME_DURUMU",
                        column: x => x.RANDEVU_GELME_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANDEVU_REFERANS_KODLAR_RANDEVU_TURU",
                        column: x => x.RANDEVU_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STERILIZASYON_SET",
                schema: "Lbys",
                columns: table => new
                {
                    STERILIZASYON_SET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_PAKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BARKOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BARKOD_BASAN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BARKOD_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_CEVRIM_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SET_IADE_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SET_IADE_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SET_IADE_EDEN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SET_IADE_ALAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PAKET_RAF_OMRU_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PAKETLEYEN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISLEM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STERILIZASYON_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STERILIZASYON_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STERILIZASYON_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STERILIZASYON_SET", x => x.STERILIZASYON_SET_KODU);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_DEPO_DEPO_KODU",
                        column: x => x.DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_KULLANICI_BARKOD_BASAN_KULLANICI_KODU",
                        column: x => x.BARKOD_BASAN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_PERSONEL_PAKETLEYEN_PERSONEL_KODU",
                        column: x => x.PAKETLEYEN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_PERSONEL_SET_IADE_ALAN_PERSONEL_KODU",
                        column: x => x.SET_IADE_ALAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_PERSONEL_SET_IADE_EDEN_PERSONEL_KODU",
                        column: x => x.SET_IADE_EDEN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_PERSONEL_STERILIZASYON_PERSONEL_KODU",
                        column: x => x.STERILIZASYON_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_STERILIZASYON_PAKET_STERILIZASYON_PAKET_KODU",
                        column: x => x.STERILIZASYON_PAKET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STERILIZASYON_PAKET",
                        principalColumn: "STERILIZASYON_PAKET_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TETKIK_NUMUNE",
                schema: "Lbys",
                columns: table => new
                {
                    TETKIK_NUMUNE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NUMUNE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUMUNE_TURU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NUMUNE_ALMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NUMUNE_KABUL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BARKOD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARKOD_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NUMUNE_ALAN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KABUL_EDEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NUMUNE_RET_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RET_EDEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RET_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NUMUNE_ACILIYET_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENTEGRASYON_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TETKIK_NUMUNE", x => x.TETKIK_NUMUNE_KODU);
                    table.ForeignKey(
                        name: "FK_TETKIK_NUMUNE_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_NUMUNE_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_NUMUNE_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_NUMUNE_KULLANICI_KABUL_EDEN_KULLANICI_KODU",
                        column: x => x.KABUL_EDEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_NUMUNE_KULLANICI_NUMUNE_ALAN_KULLANICI_KODU",
                        column: x => x.NUMUNE_ALAN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_NUMUNE_KULLANICI_RET_EDEN_KULLANICI_KODU",
                        column: x => x.RET_EDEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_NUMUNE_REFERANS_KODLAR_NUMUNE_RET_NEDENI",
                        column: x => x.NUMUNE_RET_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_NUMUNE_REFERANS_KODLAR_NUMUNE_TURU",
                        column: x => x.NUMUNE_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOK_ISTEK",
                schema: "Lbys",
                columns: table => new
                {
                    STOK_ISTEK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTEK_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ISTEK_DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_ISTEK_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_ISTEK_HEKIM_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMELIYAT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOK_ISTEK", x => x.STOK_ISTEK_KODU);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_AMELIYAT_AMELIYAT_KODU",
                        column: x => x.AMELIYAT_KODU,
                        principalSchema: "Lbys",
                        principalTable: "AMELIYAT",
                        principalColumn: "AMELIYAT_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_DEPO_ISTEK_DEPO_KODU",
                        column: x => x.ISTEK_DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_REFERANS_KODLAR_STOK_ISTEK_DURUMU",
                        column: x => x.STOK_ISTEK_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DIS_TAAHHUT_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    DIS_TAAHHUT_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIS_TAAHHUT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SUT_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CENE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIS_TAAHHUT_DETAY", x => x.DIS_TAAHHUT_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_DIS_TAAHHUT_DETAY_DIS_TAAHHUT_DIS_TAAHHUT_KODU",
                        column: x => x.DIS_TAAHHUT_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DIS_TAAHHUT",
                        principalColumn: "DIS_TAAHHUT_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIS_TAAHHUT_DETAY_REFERANS_KODLAR_CENE_KODU",
                        column: x => x.CENE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DIS_TAAHHUT_DETAY_REFERANS_KODLAR_DIS_KODU",
                        column: x => x.DIS_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_HIZMET",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DOGUM_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMELIYAT_ISLEM_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HASTA_HIZMET_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HIZMET_FATURA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TIBBI_ISLEM_PUAN_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TARAF_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HIZMET_PUAN_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISLEM_GERCEKLESME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PUAN_HAKEDIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ISLEM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RANDEVU_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CIHAZ_KUNYE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HIZMET_ADETI = table.Column<int>(type: "int", nullable: true),
                    FATURA_ADET = table.Column<int>(type: "int", nullable: true),
                    HASTA_TUTARI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KURUM_TUTARI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MEDULA_TUTARI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MEDULA_ISLEM_SIRA_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEDULA_HIZMET_REF_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SYS_REFERANS_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEDULA_TAKIP_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEDULA_OZEL_DURUM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ONAYLAYAN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ISTEYEN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FATURA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FATURA_TUTARI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ISBT_UNITE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBT_BILESEN_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPTAL_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_HIZMET", x => x.HASTA_HIZMET_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_FATURA_FATURA_KODU",
                        column: x => x.FATURA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "FATURA",
                        principalColumn: "FATURA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_HIZMET_HIZMET_KODU",
                        column: x => x.HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HIZMET",
                        principalColumn: "HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_PERSONEL_ISTEYEN_HEKIM_KODU",
                        column: x => x.ISTEYEN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_PERSONEL_ONAYLAYAN_HEKIM_KODU",
                        column: x => x.ONAYLAYAN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_REFERANS_KODLAR_HASTA_HIZMET_DURUMU",
                        column: x => x.HASTA_HIZMET_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_REFERANS_KODLAR_HIZMET_FATURA_DURUMU",
                        column: x => x.HIZMET_FATURA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_REFERANS_KODLAR_TARAF_BILGISI",
                        column: x => x.TARAF_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_HIZMET_REFERANS_KODLAR_TIBBI_ISLEM_PUAN_BILGISI",
                        column: x => x.TIBBI_ISLEM_PUAN_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KAN_STOK",
                schema: "Lbys",
                columns: table => new
                {
                    KAN_STOK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_STOK_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_STOK_GIRIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DEFTER_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_URUN_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_BAGISCI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAGLI_KAN_STOK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISBT_UNITE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBT_BILESEN_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_HACIM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_BAGIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KAN_FILTRELEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KAN_ISINLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KAN_YIKAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KAN_AYIRMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KAN_BOLME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BUFFYCOAT_UZAKLASTIRMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KAN_HAVUZLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SON_KULLANMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KAN_STOK", x => x.KAN_STOK_KODU);
                    table.ForeignKey(
                        name: "FK_KAN_STOK_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_STOK_KAN_BAGISCI_KAN_BAGISCI_KODU",
                        column: x => x.KAN_BAGISCI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KAN_BAGISCI",
                        principalColumn: "KAN_BAGISCI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_STOK_KAN_STOK_BAGLI_KAN_STOK_KODU",
                        column: x => x.BAGLI_KAN_STOK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KAN_STOK",
                        principalColumn: "KAN_STOK_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_STOK_KAN_URUN_KAN_URUN_KODU",
                        column: x => x.KAN_URUN_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KAN_URUN",
                        principalColumn: "KAN_URUN_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_STOK_KURUM_KURUM_KODU",
                        column: x => x.KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_STOK_REFERANS_KODLAR_KAN_GRUBU",
                        column: x => x.KAN_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_STOK_REFERANS_KODLAR_KAN_STOK_DURUMU",
                        column: x => x.KAN_STOK_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KAN_TALEP_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    KAN_TALEP_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_TALEP_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_URUN_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTENEN_KAN_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RET_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RET_EDEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_TALEP_RET_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_TALEP_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_HACIM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BUFFYCOAT_UZAKLASTIRMA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_FILTRELEME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_ISINLAMA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_YIKAMA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KAN_TALEP_DETAY", x => x.KAN_TALEP_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_DETAY_KAN_TALEP_KAN_TALEP_KODU",
                        column: x => x.KAN_TALEP_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KAN_TALEP",
                        principalColumn: "KAN_TALEP_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_DETAY_KAN_URUN_KAN_URUN_KODU",
                        column: x => x.KAN_URUN_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KAN_URUN",
                        principalColumn: "KAN_URUN_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_DETAY_KULLANICI_RET_EDEN_KULLANICI_KODU",
                        column: x => x.RET_EDEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_DETAY_REFERANS_KODLAR_ISTENEN_KAN_GRUBU",
                        column: x => x.ISTENEN_KAN_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_TALEP_DETAY_REFERANS_KODLAR_KAN_TALEP_RET_NEDENI",
                        column: x => x.KAN_TALEP_RET_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KURUL_ENGELLI",
                schema: "Lbys",
                columns: table => new
                {
                    KURUL_ENGELLI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUL_RAPOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CALISTIRILAMAYACAK_ISNITELIGI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENGELLI_SUREKLILIK_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AGIR_ENGELLI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENGELLI_GRUBU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENGELLI_RAPOR_KULLANIM_AMACI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KURUL_ENGELLI", x => x.KURUL_ENGELLI_KODU);
                    table.ForeignKey(
                        name: "FK_KURUL_ENGELLI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ENGELLI_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ENGELLI_KURUL_RAPOR_KURUL_RAPOR_KODU",
                        column: x => x.KURUL_RAPOR_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUL_RAPOR",
                        principalColumn: "KURUL_RAPOR_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KURUL_ETKEN_MADDE",
                schema: "Lbys",
                columns: table => new
                {
                    KURUL_ETKEN_MADDE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUL_RAPOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILAC_ETKEN_MADDE_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOZ_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOZ_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOZ_BIRIM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILAC_KULLANIM_PERIYODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ILAC_PERIYOT_BIRIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KURUL_ETKEN_MADDE", x => x.KURUL_ETKEN_MADDE_KODU);
                    table.ForeignKey(
                        name: "FK_KURUL_ETKEN_MADDE_KURUL_RAPOR_KURUL_RAPOR_KODU",
                        column: x => x.KURUL_RAPOR_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUL_RAPOR",
                        principalColumn: "KURUL_RAPOR_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ETKEN_MADDE_REFERANS_KODLAR_DOZ_BIRIM",
                        column: x => x.DOZ_BIRIM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_ETKEN_MADDE_REFERANS_KODLAR_ILAC_PERIYOT_BIRIMI",
                        column: x => x.ILAC_PERIYOT_BIRIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KURUL_HEKIM",
                schema: "Lbys",
                columns: table => new
                {
                    KURUL_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUL_RAPOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEDULA_BRANS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SISTEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUL_SONUC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENGELLILIK_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEKIM_KURUL_GOREVI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HEKIM_SIRA_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KURUL_HEKIM", x => x.KURUL_HEKIM_KODU);
                    table.ForeignKey(
                        name: "FK_KURUL_HEKIM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_HEKIM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_HEKIM_KURUL_RAPOR_KURUL_RAPOR_KODU",
                        column: x => x.KURUL_RAPOR_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUL_RAPOR",
                        principalColumn: "KURUL_RAPOR_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_HEKIM_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_HEKIM_REFERANS_KODLAR_SISTEM_KODU",
                        column: x => x.SISTEM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KURUL_TESHIS",
                schema: "Lbys",
                columns: table => new
                {
                    KURUL_TESHIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KURUL_RAPOR_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILAC_TESHIS_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TANI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RAPOR_BASLAMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RAPOR_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KURUL_TESHIS", x => x.KURUL_TESHIS_KODU);
                    table.ForeignKey(
                        name: "FK_KURUL_TESHIS_KURUL_RAPOR_KURUL_RAPOR_KODU",
                        column: x => x.KURUL_RAPOR_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUL_RAPOR",
                        principalColumn: "KURUL_RAPOR_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KURUL_TESHIS_REFERANS_KODLAR_TANI_KODU",
                        column: x => x.TANI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RECETE_ILAC",
                schema: "Lbys",
                columns: table => new
                {
                    RECETE_ILAC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RECETE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOZ_BIRIM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BARKOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ILAC_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KUTU_ADETI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ILAC_KULLANIM_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILAC_KULLANIM_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ILAC_KULLANIM_DOZU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ILAC_KULLANIM_PERIYODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ILAC_KULLANIM_PERIYODU_BIRIMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILAC_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECETE_ILAC", x => x.RECETE_ILAC_KODU);
                    table.ForeignKey(
                        name: "FK_RECETE_ILAC_RECETE_RECETE_KODU",
                        column: x => x.RECETE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "RECETE",
                        principalColumn: "RECETE_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_ILAC_REFERANS_KODLAR_DOZ_BIRIM",
                        column: x => x.DOZ_BIRIM,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_ILAC_REFERANS_KODLAR_ILAC_KULLANIM_PERIYODU_BIRIMI",
                        column: x => x.ILAC_KULLANIM_PERIYODU_BIRIMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_ILAC_REFERANS_KODLAR_ILAC_KULLANIM_SEKLI",
                        column: x => x.ILAC_KULLANIM_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIBBI_ORDER_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    TIBBI_ORDER_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TIBBI_ORDER_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PLANLANAN_UYGULANMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UYGULAYAN_HEMSIRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UYGULAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UYGULANMA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIBBI_ORDER_IPTAL_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPTAL_EDEN_HEMSIRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPTAL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIBBI_ORDER_DETAY", x => x.TIBBI_ORDER_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_TIBBI_ORDER_DETAY_PERSONEL_IPTAL_EDEN_HEMSIRE_KODU",
                        column: x => x.IPTAL_EDEN_HEMSIRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TIBBI_ORDER_DETAY_PERSONEL_UYGULAYAN_HEMSIRE_KODU",
                        column: x => x.UYGULAYAN_HEMSIRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TIBBI_ORDER_DETAY_REFERANS_KODLAR_TIBBI_ORDER_IPTAL_NEDENI",
                        column: x => x.TIBBI_ORDER_IPTAL_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TIBBI_ORDER_DETAY_TIBBI_ORDER_TIBBI_ORDER_KODU",
                        column: x => x.TIBBI_ORDER_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TIBBI_ORDER",
                        principalColumn: "TIBBI_ORDER_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DISPROTEZ_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    DISPROTEZ_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DISPROTEZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DISPROTEZ_PLANLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DISPROTEZ_IS_TURU_ASAMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DISPROTEZ_ASAMA_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FIRMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FIRMA_DISPROTEZ_ALIM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PLANLANAN_BITIS_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FIRMA_TESLIM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DISPROTEZ_ASAMA_ONAY_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RPT_ONAY_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RANDEVU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASAMA_RPT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ASAMA_RPT_SEBEBI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASAMA_RPT_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OLCU_DOKUM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISPROTEZ_DETAY", x => x.DISPROTEZ_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_DETAY_DISPROTEZ_DISPROTEZ_KODU",
                        column: x => x.DISPROTEZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DISPROTEZ",
                        principalColumn: "DISPROTEZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_DETAY_FIRMA_FIRMA_KODU",
                        column: x => x.FIRMA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "FIRMA",
                        principalColumn: "FIRMA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_DETAY_KULLANICI_ASAMA_RPT_KULLANICI_KODU",
                        column: x => x.ASAMA_RPT_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_DETAY_RANDEVU_RANDEVU_KODU",
                        column: x => x.RANDEVU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "RANDEVU",
                        principalColumn: "RANDEVU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_DETAY_REFERANS_KODLAR_ASAMA_RPT_SEBEBI",
                        column: x => x.ASAMA_RPT_SEBEBI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DISPROTEZ_DETAY_REFERANS_KODLAR_DISPROTEZ_IS_TURU_ASAMA_KODU",
                        column: x => x.DISPROTEZ_IS_TURU_ASAMA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STERILIZASYON_CIKIS",
                schema: "Lbys",
                columns: table => new
                {
                    STERILIZASYON_CIKIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_SET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_CIKIS_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STERILIZASYON_CIKIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CIKIS_YAPILAN_BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TESLIM_EDEN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TESLIM_ALAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STERILIZASYON_CIKIS", x => x.STERILIZASYON_CIKIS_KODU);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_CIKIS_BIRIM_CIKIS_YAPILAN_BIRIM_KODU",
                        column: x => x.CIKIS_YAPILAN_BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_CIKIS_DEPO_DEPO_KODU",
                        column: x => x.DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_CIKIS_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_CIKIS_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_CIKIS_PERSONEL_TESLIM_ALAN_PERSONEL_KODU",
                        column: x => x.TESLIM_ALAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_CIKIS_PERSONEL_TESLIM_EDEN_PERSONEL_KODU",
                        column: x => x.TESLIM_EDEN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_CIKIS_STERILIZASYON_SET_STERILIZASYON_SET_KODU",
                        column: x => x.STERILIZASYON_SET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STERILIZASYON_SET",
                        principalColumn: "STERILIZASYON_SET_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STERILIZASYON_SET_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    STERILIZASYON_SET_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_SET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STERILIZASYON_MALZEME_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STERILIZASYON_SET_DETAY", x => x.STERILIZASYON_SET_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_DETAY_STERILIZASYON_SET_STERILIZASYON_SET_KODU",
                        column: x => x.STERILIZASYON_SET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STERILIZASYON_SET",
                        principalColumn: "STERILIZASYON_SET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STERILIZASYON_SET_DETAY_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PATOLOJI",
                schema: "Lbys",
                columns: table => new
                {
                    PATOLOJI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PATOLOJI_RAPOR_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOKUNUN_TEMEL_OZELLIGI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NUMUNE_ALINMA_SEKLI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PATOLOJI_PREPARATI_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PATOLOJI_DEFTER_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TETKIK_NUMUNE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PATOLOJI_MATERYALI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ORGAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUMUNE_ALINMA_YERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PATOLOJIK_BULGU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PATOLOJIK_TANI_MORFOLOJI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PATOLOJIK_TANI_YERLESIM_YERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MAKROSKOPI_SONUCU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIKROSKOPI_SONUCU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SONUC_ICERIK_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RAPOR_YAZAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PARCA_KABUL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RAPOR_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PATOLOJI_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HISTOPATOLOJIK_TANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SITOPATOLOJIK_TANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HISTOKIMYASAL_BOYAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMMUNHISTOKIMYA_BOYAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FROZEN_TANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUMUNE_BOYAMA_YONTEMI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ONAYLAYAN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASISTAN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PATOLOJI_DIGER_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YORUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATOLOJI", x => x.PATOLOJI_KODU);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_PERSONEL_ASISTAN_HEKIM_KODU",
                        column: x => x.ASISTAN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_PERSONEL_ONAYLAYAN_HEKIM_KODU",
                        column: x => x.ONAYLAYAN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_PERSONEL_PATOLOJI_DIGER_HEKIM_KODU",
                        column: x => x.PATOLOJI_DIGER_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_PERSONEL_RAPOR_YAZAN_PERSONEL_KODU",
                        column: x => x.RAPOR_YAZAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_REFERANS_KODLAR_DOKUNUN_TEMEL_OZELLIGI",
                        column: x => x.DOKUNUN_TEMEL_OZELLIGI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_REFERANS_KODLAR_NUMUNE_ALINMA_SEKLI",
                        column: x => x.NUMUNE_ALINMA_SEKLI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_REFERANS_KODLAR_NUMUNE_ALINMA_YERI",
                        column: x => x.NUMUNE_ALINMA_YERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_REFERANS_KODLAR_PATOLOJIK_TANI_MORFOLOJI_KODU",
                        column: x => x.PATOLOJIK_TANI_MORFOLOJI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_REFERANS_KODLAR_PATOLOJIK_TANI_YERLESIM_YERI",
                        column: x => x.PATOLOJIK_TANI_YERLESIM_YERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_REFERANS_KODLAR_PATOLOJI_PREPARATI_DURUMU",
                        column: x => x.PATOLOJI_PREPARATI_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_REFERANS_KODLAR_PATOLOJI_RAPOR_TURU",
                        column: x => x.PATOLOJI_RAPOR_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_REFERANS_KODLAR_SONUC_ICERIK_TURU",
                        column: x => x.SONUC_ICERIK_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PATOLOJI_TETKIK_NUMUNE_TETKIK_NUMUNE_KODU",
                        column: x => x.TETKIK_NUMUNE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK_NUMUNE",
                        principalColumn: "TETKIK_NUMUNE_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOK_ISTEK_HAREKET",
                schema: "Lbys",
                columns: table => new
                {
                    STOK_ISTEK_HAREKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_ISTEK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTENEN_STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTENEN_ILAC_JENERIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VERILEN_STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTEK_GEREKLILIK_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TEDAVIDE_KULLANILAN_ILAC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISTENEN_MIKTAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEPODAN_VERILEN_MIKTAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STOK_ISTEK_RET_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_ISTEK_RET_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STOK_ISTEK_RET_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOK_ISTEK_HAREKET", x => x.STOK_ISTEK_HAREKET_KODU);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_HAREKET_KULLANICI_STOK_ISTEK_RET_KULLANICI_KODU",
                        column: x => x.STOK_ISTEK_RET_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_HAREKET_REFERANS_KODLAR_ISTENEN_ILAC_JENERIK_KODU",
                        column: x => x.ISTENEN_ILAC_JENERIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_HAREKET_REFERANS_KODLAR_STOK_ISTEK_RET_NEDENI",
                        column: x => x.STOK_ISTEK_RET_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_HAREKET_STOK_ISTEK_STOK_ISTEK_KODU",
                        column: x => x.STOK_ISTEK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_ISTEK",
                        principalColumn: "STOK_ISTEK_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_HAREKET_STOK_KART_ISTENEN_STOK_KART_KODU",
                        column: x => x.ISTENEN_STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_HAREKET_STOK_KART_VERILEN_STOK_KART_KODU",
                        column: x => x.VERILEN_STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AMELIYAT_ISLEM",
                schema: "Lbys",
                columns: table => new
                {
                    AMELIYAT_ISLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMELIYAT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMELIYAT_GRUBU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KESI_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KESI_ORANI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KESI_SEANS_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TARAF_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KOMPLIKASYON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMELIYAT_SONUCU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMELIYAT_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASA_SKORU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EUROSCORE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YARA_SINIFI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AMELIYAT_ISLEM", x => x.AMELIYAT_ISLEM_KODU);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_ISLEM_AMELIYAT_AMELIYAT_KODU",
                        column: x => x.AMELIYAT_KODU,
                        principalSchema: "Lbys",
                        principalTable: "AMELIYAT",
                        principalColumn: "AMELIYAT_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_ISLEM_HASTA_HIZMET_HASTA_HIZMET_KODU",
                        column: x => x.HASTA_HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_HIZMET",
                        principalColumn: "HASTA_HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_ISLEM_REFERANS_KODLAR_ASA_SKORU",
                        column: x => x.ASA_SKORU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_ISLEM_REFERANS_KODLAR_EUROSCORE",
                        column: x => x.EUROSCORE,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_ISLEM_REFERANS_KODLAR_KESI_ORANI",
                        column: x => x.KESI_ORANI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_ISLEM_REFERANS_KODLAR_KESI_SEANS_BILGISI",
                        column: x => x.KESI_SEANS_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_ISLEM_REFERANS_KODLAR_TARAF_BILGISI",
                        column: x => x.TARAF_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_ISLEM_REFERANS_KODLAR_YARA_SINIFI",
                        column: x => x.YARA_SINIFI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOGUM",
                schema: "Lbys",
                columns: table => new
                {
                    DOGUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMELIYAT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BABA_TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KOMPLIKASYON_TANISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOGUM_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOGUM_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOGUM_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EBE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEFTER_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOGUM", x => x.DOGUM_KODU);
                    table.ForeignKey(
                        name: "FK_DOGUM_AMELIYAT_AMELIYAT_KODU",
                        column: x => x.AMELIYAT_KODU,
                        principalSchema: "Lbys",
                        principalTable: "AMELIYAT",
                        principalColumn: "AMELIYAT_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_HASTA_HIZMET_HASTA_HIZMET_KODU",
                        column: x => x.HASTA_HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_HIZMET",
                        principalColumn: "HASTA_HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_PERSONEL_EBE_KODU",
                        column: x => x.EBE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_PERSONEL_HEKIM_KODU",
                        column: x => x.HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_REFERANS_KODLAR_KOMPLIKASYON_TANISI",
                        column: x => x.KOMPLIKASYON_TANISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_DIS",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_DIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIS_ISLEM_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIS_TAAHHUT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEVCUT_DIS_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CENE_BOLGESI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CENE_BOLGESI_DISLERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DISPROTEZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SONUC_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SONUC_MESAJI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_DIS", x => x.HASTA_DIS_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_DISPROTEZ_DISPROTEZ_KODU",
                        column: x => x.DISPROTEZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DISPROTEZ",
                        principalColumn: "DISPROTEZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_DIS_TAAHHUT_DIS_TAAHHUT_KODU",
                        column: x => x.DIS_TAAHHUT_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DIS_TAAHHUT",
                        principalColumn: "DIS_TAAHHUT_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_HASTA_HIZMET_HASTA_HIZMET_KODU",
                        column: x => x.HASTA_HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_HIZMET",
                        principalColumn: "HASTA_HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_REFERANS_KODLAR_CENE_BOLGESI",
                        column: x => x.CENE_BOLGESI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_REFERANS_KODLAR_DIS_ISLEM_TURU",
                        column: x => x.DIS_ISLEM_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_REFERANS_KODLAR_DIS_KODU",
                        column: x => x.DIS_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_DIS_REFERANS_KODLAR_MEVCUT_DIS_DURUMU",
                        column: x => x.MEVCUT_DIS_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KONSULTASYON",
                schema: "Lbys",
                columns: table => new
                {
                    KONSULTASYON_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KONSULTASYON_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KONSULTASYON_ISTEK_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KONSULTASYON_CEVAP_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KONSULTASYONA_CAGRILMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KONSULTASYONA_GELIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KONSULTASYON_YERI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KONSULTASYON", x => x.KONSULTASYON_KODU);
                    table.ForeignKey(
                        name: "FK_KONSULTASYON_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KONSULTASYON_HASTA_BASVURU_KONSULTASYON_BASVURU_KODU",
                        column: x => x.KONSULTASYON_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KONSULTASYON_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KONSULTASYON_HASTA_HIZMET_HASTA_HIZMET_KODU",
                        column: x => x.HASTA_HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_HIZMET",
                        principalColumn: "HASTA_HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KONSULTASYON_REFERANS_KODLAR_KONSULTASYON_YERI",
                        column: x => x.KONSULTASYON_YERI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RADYOLOJI",
                schema: "Lbys",
                columns: table => new
                {
                    RADYOLOJI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BIRIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_CEKIM_KABUL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BARKOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BARKOD_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CALISMA_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CALISMA_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KABUL_EDEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_CEKEN_TEKNISYEN_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LOINC_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TETKIK_ISTENME_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ERISIM_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RADYOLOJI", x => x.RADYOLOJI_KODU);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_BIRIM_BIRIM_KODU",
                        column: x => x.BIRIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BIRIM",
                        principalColumn: "BIRIM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_HASTA_HIZMET_HASTA_HIZMET_KODU",
                        column: x => x.HASTA_HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_HIZMET",
                        principalColumn: "HASTA_HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_KULLANICI_KABUL_EDEN_KULLANICI_KODU",
                        column: x => x.KABUL_EDEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_PERSONEL_TETKIK_CEKEN_TEKNISYEN_KODU",
                        column: x => x.TETKIK_CEKEN_TEKNISYEN_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_REFERANS_KODLAR_TETKIK_ISTENME_DURUMU",
                        column: x => x.TETKIK_ISTENME_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TETKIK_SONUC",
                schema: "Lbys",
                columns: table => new
                {
                    TETKIK_SONUC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_NUMUNE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TETKIK_PARAMETRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TETKIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TETKIK_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TETKIK_SONUCU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SONUC_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TETKIK_SONUC_GIZLENME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WEB_SONUC_GIZLENME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUMUNE_RET_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RET_EDEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RET_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KRITIK_DEGER_ARALIGI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CALISMA_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CALISMA_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ONAYLAYAN_TEKNISYEN_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TEKNISYEN_ONAY_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ONAYLAYAN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TETKIK_UZMAN_ONAY_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LOINC_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TEKRAR_CALISMA_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MANUEL_TETKIK_SONUC_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UREME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CIHAZ_TETKIK_SONUCU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TETKIK_SONUCU_BIRIMI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TETKIK_SONUCU_REFERANS_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TETKIK_SONUCU_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TETKIK_SONUC_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAPOR_YAZAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SONUC_DIS_ERISIM_BILGISI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TETKIK_SONUC", x => x.TETKIK_SONUC_KODU);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_HASTA_HIZMET_HASTA_HIZMET_KODU",
                        column: x => x.HASTA_HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_HIZMET",
                        principalColumn: "HASTA_HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_KULLANICI_RET_EDEN_KULLANICI_KODU",
                        column: x => x.RET_EDEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_PERSONEL_ONAYLAYAN_HEKIM_KODU",
                        column: x => x.ONAYLAYAN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_PERSONEL_ONAYLAYAN_TEKNISYEN_KODU",
                        column: x => x.ONAYLAYAN_TEKNISYEN_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_PERSONEL_RAPOR_YAZAN_PERSONEL_KODU",
                        column: x => x.RAPOR_YAZAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_REFERANS_KODLAR_NUMUNE_RET_NEDENI",
                        column: x => x.NUMUNE_RET_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_REFERANS_KODLAR_TETKIK_SONUCU_DURUMU",
                        column: x => x.TETKIK_SONUCU_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_TETKIK_NUMUNE_TETKIK_NUMUNE_KODU",
                        column: x => x.TETKIK_NUMUNE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK_NUMUNE",
                        principalColumn: "TETKIK_NUMUNE_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_TETKIK_PARAMETRE_TETKIK_PARAMETRE_KODU",
                        column: x => x.TETKIK_PARAMETRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK_PARAMETRE",
                        principalColumn: "TETKIK_PARAMETRE_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TETKIK_SONUC_TETKIK_TETKIK_KODU",
                        column: x => x.TETKIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK",
                        principalColumn: "TETKIK_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KAN_URUN_IMHA",
                schema: "Lbys",
                columns: table => new
                {
                    KAN_URUN_IMHA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_STOK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_IMHA_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_IMHA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KAN_IMHA_ONAYLAYAN_HEKIM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_IMHA_ONAYLAYAN_TEKNISYEN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_IMHA_EDEN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KAN_URUN_IMHA", x => x.KAN_URUN_IMHA_KODU);
                    table.ForeignKey(
                        name: "FK_KAN_URUN_IMHA_KAN_STOK_KAN_STOK_KODU",
                        column: x => x.KAN_STOK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KAN_STOK",
                        principalColumn: "KAN_STOK_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_URUN_IMHA_PERSONEL_KAN_IMHA_EDEN_PERSONEL_KODU",
                        column: x => x.KAN_IMHA_EDEN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_URUN_IMHA_PERSONEL_KAN_IMHA_ONAYLAYAN_HEKIM",
                        column: x => x.KAN_IMHA_ONAYLAYAN_HEKIM,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_URUN_IMHA_PERSONEL_KAN_IMHA_ONAYLAYAN_TEKNISYEN",
                        column: x => x.KAN_IMHA_ONAYLAYAN_TEKNISYEN,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_URUN_IMHA_REFERANS_KODLAR_KAN_IMHA_NEDENI",
                        column: x => x.KAN_IMHA_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KAN_CIKIS",
                schema: "Lbys",
                columns: table => new
                {
                    KAN_CIKIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_TALEP_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_STOK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KANI_TESLIM_ALAN_KISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KAN_CIKIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KURUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KAN_CIKIS_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    REZERVE_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    REZERVE_EDEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CROSS_MATCH_KULLANICI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CROSS_MATCH_CALISMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CROSS_MATCH_CALISMA_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CROSS_MATCH_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KAN_CIKIS", x => x.KAN_CIKIS_KODU);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_KAN_STOK_KAN_STOK_KODU",
                        column: x => x.KAN_STOK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KAN_STOK",
                        principalColumn: "KAN_STOK_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_KAN_TALEP_DETAY_KAN_TALEP_DETAY_KODU",
                        column: x => x.KAN_TALEP_DETAY_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KAN_TALEP_DETAY",
                        principalColumn: "KAN_TALEP_DETAY_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_KULLANICI_CROSS_MATCH_KULLANICI_KODU",
                        column: x => x.CROSS_MATCH_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_KULLANICI_REZERVE_EDEN_KULLANICI_KODU",
                        column: x => x.REZERVE_EDEN_KULLANICI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KULLANICI",
                        principalColumn: "KULLANICI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_KURUM_KURUM_KODU",
                        column: x => x.KURUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "KURUM",
                        principalColumn: "KURUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_PERSONEL_KAN_CIKIS_PERSONEL_KODU",
                        column: x => x.KAN_CIKIS_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_REFERANS_KODLAR_CROSS_MATCH_CALISMA_YONTEMI",
                        column: x => x.CROSS_MATCH_CALISMA_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KAN_CIKIS_REFERANS_KODLAR_CROSS_MATCH_SONUCU",
                        column: x => x.CROSS_MATCH_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RECETE_ILAC_ACIKLAMA",
                schema: "Lbys",
                columns: table => new
                {
                    RECETE_ILAC_ACIKLAMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RECETE_ILAC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RECETE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILAC_ACIKLAMA_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECETE_ILAC_ACIKLAMA", x => x.RECETE_ILAC_ACIKLAMA_KODU);
                    table.ForeignKey(
                        name: "FK_RECETE_ILAC_ACIKLAMA_RECETE_ILAC_RECETE_ILAC_KODU",
                        column: x => x.RECETE_ILAC_KODU,
                        principalSchema: "Lbys",
                        principalTable: "RECETE_ILAC",
                        principalColumn: "RECETE_ILAC_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_ILAC_ACIKLAMA_RECETE_RECETE_KODU",
                        column: x => x.RECETE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "RECETE",
                        principalColumn: "RECETE_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECETE_ILAC_ACIKLAMA_REFERANS_KODLAR_ILAC_ACIKLAMA_TURU",
                        column: x => x.ILAC_ACIKLAMA_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RISK_SKORLAMA",
                schema: "Lbys",
                columns: table => new
                {
                    RISK_SKORLAMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RISK_SKORLAMA_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISLEM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RISK_SKORLAMA_TOPLAM_PUANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BEKLENEN_OLUM_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GLASGOW_SKALASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DUZELTILMISBEKLENEN_OLUM_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIBBI_ORDER_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RISK_SKORLAMA", x => x.RISK_SKORLAMA_KODU);
                    table.ForeignKey(
                        name: "FK_RISK_SKORLAMA_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RISK_SKORLAMA_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RISK_SKORLAMA_REFERANS_KODLAR_RISK_SKORLAMA_TURU",
                        column: x => x.RISK_SKORLAMA_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RISK_SKORLAMA_TIBBI_ORDER_DETAY_TIBBI_ORDER_DETAY_KODU",
                        column: x => x.TIBBI_ORDER_DETAY_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TIBBI_ORDER_DETAY",
                        principalColumn: "TIBBI_ORDER_DETAY_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOK_EHU_TAKIP",
                schema: "Lbys",
                columns: table => new
                {
                    STOK_EHU_TAKIP_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_ISTEK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_ISTEK_HAREKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EHU_ONAY_BASLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EHU_ONAY_BITIS_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EHU_ILAC_MAKSIMUM_MIKTAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EHU_ONAYLAMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ONAYLAYAN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EHU_RET_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EHU_RET_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EHU_RET_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EHU_RET_ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOK_EHU_TAKIP", x => x.STOK_EHU_TAKIP_KODU);
                    table.ForeignKey(
                        name: "FK_STOK_EHU_TAKIP_PERSONEL_EHU_RET_PERSONEL_KODU",
                        column: x => x.EHU_RET_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_EHU_TAKIP_PERSONEL_ONAYLAYAN_HEKIM_KODU",
                        column: x => x.ONAYLAYAN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_EHU_TAKIP_REFERANS_KODLAR_EHU_RET_NEDENI",
                        column: x => x.EHU_RET_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_EHU_TAKIP_STOK_ISTEK_HAREKET_STOK_ISTEK_HAREKET_KODU",
                        column: x => x.STOK_ISTEK_HAREKET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_ISTEK_HAREKET",
                        principalColumn: "STOK_ISTEK_HAREKET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_EHU_TAKIP_STOK_ISTEK_STOK_ISTEK_KODU",
                        column: x => x.STOK_ISTEK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_ISTEK",
                        principalColumn: "STOK_ISTEK_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_EHU_TAKIP_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOK_HAREKET",
                schema: "Lbys",
                columns: table => new
                {
                    STOK_HAREKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAGLI_STOK_HAREKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILK_GIRIS_STOK_HAREKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_ISTEK_HAREKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_FIS_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BARKOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOT_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SERI_SIRA_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRMA_TANIMLAYICI_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MALZEME_SUT_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STOK_HAREKET_MIKTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TASINIR_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALIS_BIRIM_FIYATI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SATIS_BIRIM_FIYATI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OLCU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISLEMI_YAPAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KDV_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISKONTO_ORANI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISKONTO_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SON_KULLANMA_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MKYS_STOK_HAREKET_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPTAL_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MKYS_KARSI_STOK_HAREKET_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MKYS_KUNYE_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UTS_KAYIT_UDI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BAYILIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIHAZ_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ATS_SORGU_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALLOGREFT_DONOR_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOK_HAREKET", x => x.STOK_HAREKET_KODU);
                    table.ForeignKey(
                        name: "FK_STOK_HAREKET_CIHAZ_CIHAZ_KODU",
                        column: x => x.CIHAZ_KODU,
                        principalSchema: "Lbys",
                        principalTable: "CIHAZ",
                        principalColumn: "CIHAZ_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_HAREKET_PERSONEL_ISLEMI_YAPAN_PERSONEL_KODU",
                        column: x => x.ISLEMI_YAPAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_HAREKET_REFERANS_KODLAR_OLCU_KODU",
                        column: x => x.OLCU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_HAREKET_STOK_FIS_STOK_FIS_KODU",
                        column: x => x.STOK_FIS_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_FIS",
                        principalColumn: "STOK_FIS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_HAREKET_STOK_HAREKET_BAGLI_STOK_HAREKET_KODU",
                        column: x => x.BAGLI_STOK_HAREKET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_HAREKET",
                        principalColumn: "STOK_HAREKET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_HAREKET_STOK_HAREKET_ILK_GIRIS_STOK_HAREKET_KODU",
                        column: x => x.ILK_GIRIS_STOK_HAREKET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_HAREKET",
                        principalColumn: "STOK_HAREKET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_HAREKET_STOK_ISTEK_HAREKET_STOK_ISTEK_HAREKET_KODU",
                        column: x => x.STOK_ISTEK_HAREKET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_ISTEK_HAREKET",
                        principalColumn: "STOK_ISTEK_HAREKET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_HAREKET_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STOK_ISTEK_UYGULAMA",
                schema: "Lbys",
                columns: table => new
                {
                    STOK_ISTEK_UYGULAMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_ISTEK_HAREKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ORDER_PLANLANAN_ZAMAN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ORDER_UYGULANAN_ZAMAN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UYGULAYAN_HEMSIRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTEK_IPTAL_NEDENI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPTAL_EDEN_HEMSIRE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPTAL_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UYGULANAN_MIKTAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOK_ISTEK_UYGULAMA", x => x.STOK_ISTEK_UYGULAMA_KODU);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_UYGULAMA_PERSONEL_IPTAL_EDEN_HEMSIRE_KODU",
                        column: x => x.IPTAL_EDEN_HEMSIRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_UYGULAMA_PERSONEL_UYGULAYAN_HEMSIRE_KODU",
                        column: x => x.UYGULAYAN_HEMSIRE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_UYGULAMA_REFERANS_KODLAR_ISTEK_IPTAL_NEDENI",
                        column: x => x.ISTEK_IPTAL_NEDENI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STOK_ISTEK_UYGULAMA_STOK_ISTEK_HAREKET_STOK_ISTEK_HAREKET_KODU",
                        column: x => x.STOK_ISTEK_HAREKET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_ISTEK_HAREKET",
                        principalColumn: "STOK_ISTEK_HAREKET_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AMELIYAT_EKIP",
                schema: "Lbys",
                columns: table => new
                {
                    AMELIYAT_EKIP_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMELIYAT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMELIYAT_ISLEM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKIP_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMELIYAT_PERSONEL_GOREV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AMELIYAT_EKIP", x => x.AMELIYAT_EKIP_KODU);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_EKIP_AMELIYAT_AMELIYAT_KODU",
                        column: x => x.AMELIYAT_KODU,
                        principalSchema: "Lbys",
                        principalTable: "AMELIYAT",
                        principalColumn: "AMELIYAT_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_EKIP_AMELIYAT_ISLEM_AMELIYAT_ISLEM_KODU",
                        column: x => x.AMELIYAT_ISLEM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "AMELIYAT_ISLEM",
                        principalColumn: "AMELIYAT_ISLEM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_EKIP_PERSONEL_PERSONEL_KODU",
                        column: x => x.PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AMELIYAT_EKIP_REFERANS_KODLAR_AMELIYAT_PERSONEL_GOREV",
                        column: x => x.AMELIYAT_PERSONEL_GOREV,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DOGUM_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    DOGUM_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOGUM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOGUM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CINSIYET = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOGUM_YONTEMI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AGIRLIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BOY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BAS_CEVRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APGAR_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APGAR_5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APGAR_NOTU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KOMPLIKASYON_TANISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DOGUM_SIRASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GOGUS_CEVRESI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PROGNOZ_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SURMATURE_BILGISI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    K_VITAMINI_UYGULANMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BEBEGIN_HEPATIT_ASI_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YENIDOGAN_ISITME_TARAMA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ILK_BESLENME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOPUK_KANI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TOPUK_KANI_ALINMA_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BEBEK_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BABA_TC_KIMLIK_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BEBEGIN_YASAM_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SEZARYEN_ENDIKASYONLAR = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ROBSON_GRUBU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOGUM_DETAY", x => x.DOGUM_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_DOGUM_DOGUM_KODU",
                        column: x => x.DOGUM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DOGUM",
                        principalColumn: "DOGUM_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_BEBEGIN_HEPATIT_ASI_DURUMU",
                        column: x => x.BEBEGIN_HEPATIT_ASI_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_BEBEGIN_YASAM_DURUMU",
                        column: x => x.BEBEGIN_YASAM_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_CINSIYET",
                        column: x => x.CINSIYET,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_DOGUM_YONTEMI",
                        column: x => x.DOGUM_YONTEMI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_KOMPLIKASYON_TANISI",
                        column: x => x.KOMPLIKASYON_TANISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_K_VITAMINI_UYGULANMA_DURUMU",
                        column: x => x.K_VITAMINI_UYGULANMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_PROGNOZ_BILGISI",
                        column: x => x.PROGNOZ_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_ROBSON_GRUBU",
                        column: x => x.ROBSON_GRUBU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_SEZARYEN_ENDIKASYONLAR",
                        column: x => x.SEZARYEN_ENDIKASYONLAR,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_SURMATURE_BILGISI",
                        column: x => x.SURMATURE_BILGISI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_TOPUK_KANI",
                        column: x => x.TOPUK_KANI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOGUM_DETAY_REFERANS_KODLAR_YENIDOGAN_ISITME_TARAMA_DURUMU",
                        column: x => x.YENIDOGAN_ISITME_TARAMA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RADYOLOJI_SONUC",
                schema: "Lbys",
                columns: table => new
                {
                    RADYOLOJI_SONUC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RADYOLOJI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_SONUCU_METIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RADYOLOJI_TETKIK_SONUCU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RADYOLOJI_RAPOR_FORMATI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RAPOR_TIPI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RAPOR_YAZAN_PERSONEL_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ONAYLAYAN_PERSONEL_KODU_1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ONAYLAYAN_PERSONEL_KODU_2 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ONAYLAYAN_PERSONEL_KODU_3 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RAPOR_UZMAN_ONAY_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RAPOR_KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RADYOLOJI_SONUC", x => x.RADYOLOJI_SONUC_KODU);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_SONUC_PERSONEL_ONAYLAYAN_PERSONEL_KODU_1",
                        column: x => x.ONAYLAYAN_PERSONEL_KODU_1,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_SONUC_PERSONEL_ONAYLAYAN_PERSONEL_KODU_2",
                        column: x => x.ONAYLAYAN_PERSONEL_KODU_2,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_SONUC_PERSONEL_ONAYLAYAN_PERSONEL_KODU_3",
                        column: x => x.ONAYLAYAN_PERSONEL_KODU_3,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_SONUC_PERSONEL_RAPOR_YAZAN_PERSONEL_KODU",
                        column: x => x.RAPOR_YAZAN_PERSONEL_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_SONUC_RADYOLOJI_RADYOLOJI_KODU",
                        column: x => x.RADYOLOJI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "RADYOLOJI",
                        principalColumn: "RADYOLOJI_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_SONUC_REFERANS_KODLAR_RADYOLOJI_RAPOR_FORMATI",
                        column: x => x.RADYOLOJI_RAPOR_FORMATI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RADYOLOJI_SONUC_REFERANS_KODLAR_RAPOR_TIPI",
                        column: x => x.RAPOR_TIPI,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BAKTERI_SONUC",
                schema: "Lbys",
                columns: table => new
                {
                    BAKTERI_SONUC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_SONUC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAKTERI_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KOLONI_SAYISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAPOR_SONUC_SIRASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAKTERI_SONUC", x => x.BAKTERI_SONUC_KODU);
                    table.ForeignKey(
                        name: "FK_BAKTERI_SONUC_REFERANS_KODLAR_BAKTERI_KODU",
                        column: x => x.BAKTERI_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BAKTERI_SONUC_TETKIK_SONUC_TETKIK_SONUC_KODU",
                        column: x => x.TETKIK_SONUC_KODU,
                        principalSchema: "Lbys",
                        principalTable: "TETKIK_SONUC",
                        principalColumn: "TETKIK_SONUC_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RISK_SKORLAMA_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    RISK_SKORLAMA_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RISK_SKORLAMA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GLASGOW_SKALASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RISK_SKORLAMA_ALT_TURU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RISK_SKOR_DEGERI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RISK_SKORLAMA_DETAY", x => x.RISK_SKORLAMA_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_RISK_SKORLAMA_DETAY_REFERANS_KODLAR_RISK_SKORLAMA_ALT_TURU",
                        column: x => x.RISK_SKORLAMA_ALT_TURU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RISK_SKORLAMA_DETAY_RISK_SKORLAMA_RISK_SKORLAMA_KODU",
                        column: x => x.RISK_SKORLAMA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "RISK_SKORLAMA",
                        principalColumn: "RISK_SKORLAMA_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HASTA_MALZEME",
                schema: "Lbys",
                columns: table => new
                {
                    HASTA_MALZEME_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_BASVURU_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_KART_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STOK_HAREKET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MALZEME_FATURA_DURUMU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISLEM_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ISLEM_GERCEKLESME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ATS_SORGU_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALLOGREFT_DONOR_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MALZEME_ADETI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FATURA_ADET = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FATURA_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FATURA_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HASTA_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KURUM_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_ISLEM_SIRA_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_HIZMET_REF_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SYS_REFERANS_NUMARASI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEDULA_TAKIP_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEDULA_OZEL_DURUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMELIYAT_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ISTEYEN_HEKIM_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DEPO_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPTAL_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HASTA_MALZEME", x => x.HASTA_MALZEME_KODU);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_AMELIYAT_AMELIYAT_KODU",
                        column: x => x.AMELIYAT_KODU,
                        principalSchema: "Lbys",
                        principalTable: "AMELIYAT",
                        principalColumn: "AMELIYAT_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_DEPO_DEPO_KODU",
                        column: x => x.DEPO_KODU,
                        principalSchema: "Lbys",
                        principalTable: "DEPO",
                        principalColumn: "DEPO_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_FATURA_FATURA_KODU",
                        column: x => x.FATURA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "FATURA",
                        principalColumn: "FATURA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_HASTA_BASVURU_HASTA_BASVURU_KODU",
                        column: x => x.HASTA_BASVURU_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_BASVURU",
                        principalColumn: "HASTA_BASVURU_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_HASTA_HASTA_KODU",
                        column: x => x.HASTA_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA",
                        principalColumn: "HASTA_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_MEDULA_TAKIP_MEDULA_TAKIP_KODU",
                        column: x => x.MEDULA_TAKIP_KODU,
                        principalSchema: "Lbys",
                        principalTable: "MEDULA_TAKIP",
                        principalColumn: "MEDULA_TAKIP_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_PERSONEL_ISTEYEN_HEKIM_KODU",
                        column: x => x.ISTEYEN_HEKIM_KODU,
                        principalSchema: "Lbys",
                        principalTable: "PERSONEL",
                        principalColumn: "PERSONEL_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_REFERANS_KODLAR_MALZEME_FATURA_DURUMU",
                        column: x => x.MALZEME_FATURA_DURUMU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_STOK_HAREKET_STOK_HAREKET_KODU",
                        column: x => x.STOK_HAREKET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_HAREKET",
                        principalColumn: "STOK_HAREKET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HASTA_MALZEME_STOK_KART_STOK_KART_KODU",
                        column: x => x.STOK_KART_KODU,
                        principalSchema: "Lbys",
                        principalTable: "STOK_KART",
                        principalColumn: "STOK_KART_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ANTIBIYOTIK_SONUC",
                schema: "Lbys",
                columns: table => new
                {
                    ANTIBIYOTIK_SONUC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAKTERI_SONUC_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ANTIBIYOTIK_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TETKIK_SONUCU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ZON_CAPI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAPORDA_GORULME_DURUMU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANTIBIYOTIK_SONUC", x => x.ANTIBIYOTIK_SONUC_KODU);
                    table.ForeignKey(
                        name: "FK_ANTIBIYOTIK_SONUC_BAKTERI_SONUC_BAKTERI_SONUC_KODU",
                        column: x => x.BAKTERI_SONUC_KODU,
                        principalSchema: "Lbys",
                        principalTable: "BAKTERI_SONUC",
                        principalColumn: "BAKTERI_SONUC_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ANTIBIYOTIK_SONUC_REFERANS_KODLAR_ANTIBIYOTIK_KODU",
                        column: x => x.ANTIBIYOTIK_KODU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ANTIBIYOTIK_SONUC_REFERANS_KODLAR_TETKIK_SONUCU",
                        column: x => x.TETKIK_SONUCU,
                        principalSchema: "Lbys",
                        principalTable: "REFERANS_KODLAR",
                        principalColumn: "REFERANS_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEZNE_DETAY",
                schema: "Lbys",
                columns: table => new
                {
                    VEZNE_DETAY_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VEZNE_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_HIZMET_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HASTA_MALZEME_KODU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BUTCE_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAKBUZ_KALEM_TUTARI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EKLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KAYIT_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GUNCELLEYEN_KULLANICI_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GUNCELLEME_ZAMANI = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEZNE_DETAY", x => x.VEZNE_DETAY_KODU);
                    table.ForeignKey(
                        name: "FK_VEZNE_DETAY_HASTA_HIZMET_HASTA_HIZMET_KODU",
                        column: x => x.HASTA_HIZMET_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_HIZMET",
                        principalColumn: "HASTA_HIZMET_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEZNE_DETAY_HASTA_MALZEME_HASTA_MALZEME_KODU",
                        column: x => x.HASTA_MALZEME_KODU,
                        principalSchema: "Lbys",
                        principalTable: "HASTA_MALZEME",
                        principalColumn: "HASTA_MALZEME_KODU",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEZNE_DETAY_VEZNE_VEZNE_KODU",
                        column: x => x.VEZNE_KODU,
                        principalSchema: "Lbys",
                        principalTable: "VEZNE",
                        principalColumn: "VEZNE_KODU",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_AMELIYAT_DURUMU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "AMELIYAT_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_AMELIYAT_TIPI",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "AMELIYAT_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_AMELIYAT_TURU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "AMELIYAT_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ANESTEZI_TURU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "ANESTEZI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_BIRIM_KODU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_HASTA_KODU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_MASA_CIHAZ_KODU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "MASA_CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_PROFILAKSI_KODU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "PROFILAKSI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_PROFILAKSI_PERIYODU",
                schema: "Lbys",
                table: "AMELIYAT",
                column: "PROFILAKSI_PERIYODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_EKIP_AMELIYAT_ISLEM_KODU",
                schema: "Lbys",
                table: "AMELIYAT_EKIP",
                column: "AMELIYAT_ISLEM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_EKIP_AMELIYAT_KODU",
                schema: "Lbys",
                table: "AMELIYAT_EKIP",
                column: "AMELIYAT_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_EKIP_AMELIYAT_PERSONEL_GOREV",
                schema: "Lbys",
                table: "AMELIYAT_EKIP",
                column: "AMELIYAT_PERSONEL_GOREV");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_EKIP_PERSONEL_KODU",
                schema: "Lbys",
                table: "AMELIYAT_EKIP",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ISLEM_AMELIYAT_KODU",
                schema: "Lbys",
                table: "AMELIYAT_ISLEM",
                column: "AMELIYAT_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ISLEM_ASA_SKORU",
                schema: "Lbys",
                table: "AMELIYAT_ISLEM",
                column: "ASA_SKORU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ISLEM_EUROSCORE",
                schema: "Lbys",
                table: "AMELIYAT_ISLEM",
                column: "EUROSCORE");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ISLEM_HASTA_HIZMET_KODU",
                schema: "Lbys",
                table: "AMELIYAT_ISLEM",
                column: "HASTA_HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ISLEM_KESI_ORANI",
                schema: "Lbys",
                table: "AMELIYAT_ISLEM",
                column: "KESI_ORANI");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ISLEM_KESI_SEANS_BILGISI",
                schema: "Lbys",
                table: "AMELIYAT_ISLEM",
                column: "KESI_SEANS_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ISLEM_TARAF_BILGISI",
                schema: "Lbys",
                table: "AMELIYAT_ISLEM",
                column: "TARAF_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_AMELIYAT_ISLEM_YARA_SINIFI",
                schema: "Lbys",
                table: "AMELIYAT_ISLEM",
                column: "YARA_SINIFI");

            migrationBuilder.CreateIndex(
                name: "IX_ANLIK_YATAN_HASTA_BIRIM_KODU",
                schema: "Lbys",
                table: "ANLIK_YATAN_HASTA",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ANLIK_YATAN_HASTA_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "ANLIK_YATAN_HASTA",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ANLIK_YATAN_HASTA_HASTA_KODU",
                schema: "Lbys",
                table: "ANLIK_YATAN_HASTA",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ANLIK_YATAN_HASTA_HEKIM_KODU",
                schema: "Lbys",
                table: "ANLIK_YATAN_HASTA",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ANLIK_YATAN_HASTA_ODA_KODU",
                schema: "Lbys",
                table: "ANLIK_YATAN_HASTA",
                column: "ODA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ANLIK_YATAN_HASTA_YATAK_KODU",
                schema: "Lbys",
                table: "ANLIK_YATAN_HASTA",
                column: "YATAK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ANTIBIYOTIK_SONUC_ANTIBIYOTIK_KODU",
                schema: "Lbys",
                table: "ANTIBIYOTIK_SONUC",
                column: "ANTIBIYOTIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ANTIBIYOTIK_SONUC_BAKTERI_SONUC_KODU",
                schema: "Lbys",
                table: "ANTIBIYOTIK_SONUC",
                column: "BAKTERI_SONUC_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ANTIBIYOTIK_SONUC_TETKIK_SONUCU",
                schema: "Lbys",
                table: "ANTIBIYOTIK_SONUC",
                column: "TETKIK_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ALTTA_YATAN_HASTALIK",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ALTTA_YATAN_HASTALIK");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASI_ISLEM_TURU",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASI_ISLEM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASI_KODU",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASI_OZEL_DURUM_NEDENI",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASI_OZEL_DURUM_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASI_UYGULAMA_YERI",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASI_UYGULAMA_YERI");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASI_YAPILMAMA_DURUMU",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASI_YAPILMAMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASI_YAPILMAMA_NEDENI",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASI_YAPILMAMA_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASIE_NEDENLERI",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASIE_NEDENLERI");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASININ_DOZU",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASININ_DOZU");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_ASININ_UYGULAMA_SEKLI",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "ASININ_UYGULAMA_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ASI_BILGISI_HASTA_KODU",
                schema: "Lbys",
                table: "ASI_BILGISI",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BAKTERI_SONUC_BAKTERI_KODU",
                schema: "Lbys",
                table: "BAKTERI_SONUC",
                column: "BAKTERI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BAKTERI_SONUC_TETKIK_SONUC_KODU",
                schema: "Lbys",
                table: "BAKTERI_SONUC",
                column: "TETKIK_SONUC_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_TANI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "BASVURU_TANI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_TANI_HASTA_KODU",
                schema: "Lbys",
                table: "BASVURU_TANI",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_TANI_HEKIM_KODU",
                schema: "Lbys",
                table: "BASVURU_TANI",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_TANI_TANI_KODU",
                schema: "Lbys",
                table: "BASVURU_TANI",
                column: "TANI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_TANI_TANI_TURU",
                schema: "Lbys",
                table: "BASVURU_TANI",
                column: "TANI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_YEMEK_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "BASVURU_YEMEK",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_YEMEK_HASTA_KODU",
                schema: "Lbys",
                table: "BASVURU_YEMEK",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_YEMEK_YEMEK_TURU",
                schema: "Lbys",
                table: "BASVURU_YEMEK",
                column: "YEMEK_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_BASVURU_YEMEK_YEMEK_ZAMANI_TURU",
                schema: "Lbys",
                table: "BASVURU_YEMEK",
                column: "YEMEK_ZAMANI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_AGIZDAN_SIVI_TEDAVISI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "AGIZDAN_SIVI_TEDAVISI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_BC_BEYIN_GELISIM_RISKLERI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "BC_BEYIN_GELISIM_RISKLERI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_BC_PSIKOLOJIK_RISK_EGITIM",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "BC_PSIKOLOJIK_RISK_EGITIM");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_BC_RISK_YAPILAN_MUDAHALE",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "BC_RISK_YAPILAN_MUDAHALE");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_BC_RISKLI_OLGU_TAKIBI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "BC_RISKLI_OLGU_TAKIBI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_BEBEGIN_BESLENME_DURUMU",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "BEBEGIN_BESLENME_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_BEBEKTE_RISK_FAKTORLERI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "BEBEKTE_RISK_FAKTORLERI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_DEMIR_LOJISTIGI_VE_DESTEGI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "DEMIR_LOJISTIGI_VE_DESTEGI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_DVITAMINI_LOJISTIGI_VE_DESTEGI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "DVITAMINI_LOJISTIGI_VE_DESTEGI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_EBEVEYN_DESTEK_AKTIVITELERI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "EBEVEYN_DESTEK_AKTIVITELERI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_GELISIM_TABLOSU_BILGILERI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "GELISIM_TABLOSU_BILGILERI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_GKD_TARAMA_SONUCU",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "GKD_TARAMA_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_HASTA_KODU",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_IZLEMI_YAPAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "IZLEMI_YAPAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_IZLEMIN_YAPILDIGI_YER",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "IZLEMIN_YAPILDIGI_YER");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_KACINCI_IZLEM",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "KACINCI_IZLEM");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_NTP_TAKIP_BILGISI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "NTP_TAKIP_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_TARAMA_SONUCU",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "TARAMA_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_BEBEK_COCUK_IZLEM_TOPUK_KANI",
                schema: "Lbys",
                table: "BEBEK_COCUK_IZLEM",
                column: "TOPUK_KANI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_AILESINDE_INTIHAR_GIRISIMI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "AILESINDE_INTIHAR_GIRISIMI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_AILESINDE_PSIKIYATRIK_VAKA",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "AILESINDE_PSIKIYATRIK_VAKA");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_BILDIRIM_TURU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "BILDIRIM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_BULASICI_HASTALIK_VAKA_TIPI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "BULASICI_HASTALIK_VAKA_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_DGT_UYGULAMA_YERI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "DGT_UYGULAMA_YERI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_DGT_UYGULAMASINI_YAPAN_KISI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "DGT_UYGULAMASINI_YAPAN_KISI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_HASTA_KODU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_HASTANIN_TEDAVIYE_UYUMU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "HASTANIN_TEDAVIYE_UYUMU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_HAYVANIN_MEVCUT_DURUMU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "HAYVANIN_MEVCUT_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_HAYVANIN_SAHIPLIK_DURUMU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "HAYVANIN_SAHIPLIK_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_IL_KODU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "IL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_ILCE_KODU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "ILCE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_IMMUNGLOBULIN_TURU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "IMMUNGLOBULIN_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_INTIHAR_GIRISIM_KRIZ_NEDENLERI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "INTIHAR_GIRISIM_KRIZ_NEDENLERI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_INTIHAR_GIRISIMI_GECMISI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "INTIHAR_GIRISIMI_GECMISI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_INTIHAR_GIRISIMI_YONTEMI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "INTIHAR_GIRISIMI_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_INTIHAR_KRIZ_VAKA_SONUCU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "INTIHAR_KRIZ_VAKA_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_INTIHAR_KRIZ_VAKA_TURU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "INTIHAR_KRIZ_VAKA_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_KATEGORIZASYON",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "KATEGORIZASYON");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_KUDUZ_SEBEP_OLAN_HAYVAN",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "KUDUZ_SEBEP_OLAN_HAYVAN");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_KULTUR_SONUCU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "KULTUR_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_PSIKIYATRIK_TANI_GECMISI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "PSIKIYATRIK_TANI_GECMISI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_PSIKIYATRIK_TEDAVI_GECMISI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "PSIKIYATRIK_TEDAVI_GECMISI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_RISKLI_TEMAS_TIPI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "RISKLI_TEMAS_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_SIDDET_DEGERLENDIRME_SONUCU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "SIDDET_DEGERLENDIRME_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_SIDDET_TURU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "SIDDET_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_TANI_KODU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "TANI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_TEMAS_DEGERLENDIRME_DURUMU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "TEMAS_DEGERLENDIRME_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_TUBERKULIN_DERI_TESTI_SONUCU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "TUBERKULIN_DERI_TESTI_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_VEREM_HASTALIGI_TUTULUM_YERI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "VEREM_HASTALIGI_TUTULUM_YERI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_VEREM_HASTASI_KLINIK_ORNEGI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "VEREM_HASTASI_KLINIK_ORNEGI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_VEREM_HASTASI_TEDAVI_YONTEMI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "VEREM_HASTASI_TEDAVI_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_VEREM_ILAC_ADI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "VEREM_ILAC_ADI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_VEREM_OLGU_TANIMI",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "VEREM_OLGU_TANIMI");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_VEREM_TEDAVI_SONUCU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "VEREM_TEDAVI_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_YAPTIRACAGINI_BEYAN_ETTIGI_TSM",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "YAPTIRACAGINI_BEYAN_ETTIGI_TSM");

            migrationBuilder.CreateIndex(
                name: "IX_BILDIRIMI_ZORUNLU_YAYMA_SONUCU",
                schema: "Lbys",
                table: "BILDIRIMI_ZORUNLU",
                column: "YAYMA_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_BINA_SKRS_KURUM_KODU",
                schema: "Lbys",
                table: "BINA",
                column: "SKRS_KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BIRIM_BIRIM_TURU",
                schema: "Lbys",
                table: "BIRIM",
                column: "BIRIM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_BIRIM_KURUM_KODU",
                schema: "Lbys",
                table: "BIRIM",
                column: "KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_BIRIM_UST_BIRIM_KODU",
                schema: "Lbys",
                table: "BIRIM",
                column: "UST_BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_CIHAZ_BIRIM_KODU",
                schema: "Lbys",
                table: "CIHAZ",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_CIHAZ_CIHAZ_GRUBU",
                schema: "Lbys",
                table: "CIHAZ",
                column: "CIHAZ_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_AKSILLER_KILLANMA_DURUMU",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "AKSILLER_KILLANMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_BEYIN_ODEMI_DURUMU",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "BEYIN_ODEMI_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_DIYABET_EGITIMI_VERILME_DURUMU",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "DIYABET_EGITIMI_VERILME_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_DIYABET_ILAC_TEDAVI_SEKLI",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "DIYABET_ILAC_TEDAVI_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_DIYABET_KOMPLIKASYONLARI",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "DIYABET_KOMPLIKASYONLARI");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_DIYABET_SIKAYET",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "DIYABET_SIKAYET");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_DIYABET_TIPI",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "DIYABET_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_DIYABETLI_HASTA_AILE_OYKUSU",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "DIYABETLI_HASTA_AILE_OYKUSU");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_DIYET_TIBBI_BESLENME_TEDAVISI",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "DIYET_TIBBI_BESLENME_TEDAVISI");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_ESLIKEDEN_HASTALIK",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "ESLIKEDEN_HASTALIK");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_KETOASIDOZ_DURUMU",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "KETOASIDOZ_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_MEME_EVRE",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "MEME_EVRE");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_PUBIK_KILLANMA_DURUMU",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "PUBIK_KILLANMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_COCUK_DIYABET_TIROID_MUAYENESI",
                schema: "Lbys",
                table: "COCUK_DIYABET",
                column: "TIROID_MUAYENESI");

            migrationBuilder.CreateIndex(
                name: "IX_DEPO_BINA_KODU",
                schema: "Lbys",
                table: "DEPO",
                column: "BINA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DEPO_DEPO_TURU",
                schema: "Lbys",
                table: "DEPO",
                column: "DEPO_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_DIS_TAAHHUT_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "DIS_TAAHHUT",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DIS_TAAHHUT_HASTA_KODU",
                schema: "Lbys",
                table: "DIS_TAAHHUT",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DIS_TAAHHUT_HEKIM_KODU",
                schema: "Lbys",
                table: "DIS_TAAHHUT",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DIS_TAAHHUT_IL_KODU",
                schema: "Lbys",
                table: "DIS_TAAHHUT",
                column: "IL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DIS_TAAHHUT_ILCE_KODU",
                schema: "Lbys",
                table: "DIS_TAAHHUT",
                column: "ILCE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DIS_TAAHHUT_DETAY_CENE_KODU",
                schema: "Lbys",
                table: "DIS_TAAHHUT_DETAY",
                column: "CENE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DIS_TAAHHUT_DETAY_DIS_KODU",
                schema: "Lbys",
                table: "DIS_TAAHHUT_DETAY",
                column: "DIS_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DIS_TAAHHUT_DETAY_DIS_TAAHHUT_KODU",
                schema: "Lbys",
                table: "DIS_TAAHHUT_DETAY",
                column: "DIS_TAAHHUT_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_BIRIM_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DIS_BOYUT_BILGISI",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "DIS_BOYUT_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DISPROTEZ_BIRIM_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "DISPROTEZ_BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DISPROTEZ_IS_TURU_ALT_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "DISPROTEZ_IS_TURU_ALT_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DISPROTEZ_IS_TURU_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "DISPROTEZ_IS_TURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DISPROTEZ_KASIK_TURU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "DISPROTEZ_KASIK_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DISPROTEZ_RENGI",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "DISPROTEZ_RENGI");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_HASTA_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_HEKIM_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_RPT_EDEN_PERSONEL_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "RPT_EDEN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_RPT_SEBEBI",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "RPT_SEBEBI");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_TEKNISYEN_KODU",
                schema: "Lbys",
                table: "DISPROTEZ",
                column: "TEKNISYEN_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DETAY_ASAMA_RPT_KULLANICI_KODU",
                schema: "Lbys",
                table: "DISPROTEZ_DETAY",
                column: "ASAMA_RPT_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DETAY_ASAMA_RPT_SEBEBI",
                schema: "Lbys",
                table: "DISPROTEZ_DETAY",
                column: "ASAMA_RPT_SEBEBI");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DETAY_DISPROTEZ_IS_TURU_ASAMA_KODU",
                schema: "Lbys",
                table: "DISPROTEZ_DETAY",
                column: "DISPROTEZ_IS_TURU_ASAMA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DETAY_DISPROTEZ_KODU",
                schema: "Lbys",
                table: "DISPROTEZ_DETAY",
                column: "DISPROTEZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DETAY_FIRMA_KODU",
                schema: "Lbys",
                table: "DISPROTEZ_DETAY",
                column: "FIRMA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DISPROTEZ_DETAY_RANDEVU_KODU",
                schema: "Lbys",
                table: "DISPROTEZ_DETAY",
                column: "RANDEVU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DIYABET_DIYABET_EGITIMI",
                schema: "Lbys",
                table: "DIYABET",
                column: "DIYABET_EGITIMI");

            migrationBuilder.CreateIndex(
                name: "IX_DIYABET_DIYABET_KOMPLIKASYONLARI",
                schema: "Lbys",
                table: "DIYABET",
                column: "DIYABET_KOMPLIKASYONLARI");

            migrationBuilder.CreateIndex(
                name: "IX_DIYABET_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "DIYABET",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_AMELIYAT_KODU",
                schema: "Lbys",
                table: "DOGUM",
                column: "AMELIYAT_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_BIRIM_KODU",
                schema: "Lbys",
                table: "DOGUM",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_EBE_KODU",
                schema: "Lbys",
                table: "DOGUM",
                column: "EBE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "DOGUM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_HASTA_HIZMET_KODU",
                schema: "Lbys",
                table: "DOGUM",
                column: "HASTA_HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_HASTA_KODU",
                schema: "Lbys",
                table: "DOGUM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_HEKIM_KODU",
                schema: "Lbys",
                table: "DOGUM",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_KOMPLIKASYON_TANISI",
                schema: "Lbys",
                table: "DOGUM",
                column: "KOMPLIKASYON_TANISI");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_BEBEGIN_HEPATIT_ASI_DURUMU",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "BEBEGIN_HEPATIT_ASI_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_BEBEGIN_YASAM_DURUMU",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "BEBEGIN_YASAM_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_CINSIYET",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "CINSIYET");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_DOGUM_KODU",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "DOGUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_DOGUM_YONTEMI",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "DOGUM_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_HASTA_KODU",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_K_VITAMINI_UYGULANMA_DURUMU",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "K_VITAMINI_UYGULANMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_KOMPLIKASYON_TANISI",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "KOMPLIKASYON_TANISI");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_PROGNOZ_BILGISI",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "PROGNOZ_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_ROBSON_GRUBU",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "ROBSON_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_SEZARYEN_ENDIKASYONLAR",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "SEZARYEN_ENDIKASYONLAR");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_SURMATURE_BILGISI",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "SURMATURE_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_TOPUK_KANI",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "TOPUK_KANI");

            migrationBuilder.CreateIndex(
                name: "IX_DOGUM_DETAY_YENIDOGAN_ISITME_TARAMA_DURUMU",
                schema: "Lbys",
                table: "DOGUM_DETAY",
                column: "YENIDOGAN_ISITME_TARAMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_DOKTOR_MESAJI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "DOKTOR_MESAJI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_DOKTOR_MESAJI_HASTA_MESAJLARI_TURU",
                schema: "Lbys",
                table: "DOKTOR_MESAJI",
                column: "HASTA_MESAJLARI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_EK_ODEME_EK_ODEME_DONEM_KODU",
                schema: "Lbys",
                table: "EK_ODEME",
                column: "EK_ODEME_DONEM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_EK_ODEME_PERSONEL_KODU",
                schema: "Lbys",
                table: "EK_ODEME",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_EK_ODEME_DETAY_EK_ODEME_KODU",
                schema: "Lbys",
                table: "EK_ODEME_DETAY",
                column: "EK_ODEME_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_EK_ODEME_DETAY_KLINIK_KODU",
                schema: "Lbys",
                table: "EK_ODEME_DETAY",
                column: "KLINIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_AGRI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "AGRI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_AYDINLATMA",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "AYDINLATMA");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_BAKIM_VE_DESTEK_IHTIYACI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "BAKIM_VE_DESTEK_IHTIYACI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_BASI_DEGERLENDIRMESI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "BASI_DEGERLENDIRMESI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_BASVURU_TURU",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "BASVURU_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_BESLENME",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "BESLENME");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_BIR_SONRAKI_HIZMET_IHTIYACI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "BIR_SONRAKI_HIZMET_IHTIYACI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_ESH_ALINACAK_IL",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "ESH_ALINACAK_IL");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_ESH_ESAS_HASTALIK_GRUBU",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "ESH_ESAS_HASTALIK_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_ESH_HASTA_NAKLI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "ESH_HASTA_NAKLI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_ESH_SONLANDIRILMASI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "ESH_SONLANDIRILMASI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_EV_HIJYENI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "EV_HIJYENI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_GUVENLIK",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "GUVENLIK");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_HASTA_KODU",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_ISINMA",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "ISINMA");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_KISISEL_BAKIM",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "KISISEL_BAKIM");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_KISISEL_HIJYEN",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "KISISEL_HIJYEN");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_KONUT_TIPI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "KONUT_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_KULLANDIGI_YARDIMCI_ARACLAR",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "KULLANDIGI_YARDIMCI_ARACLAR");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_KULLANILAN_HELA_TIPI",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "KULLANILAN_HELA_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_PSIKOLOJIK_DURUM_DEGERLENDIRME",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "PSIKOLOJIK_DURUM_DEGERLENDIRME");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_VERILEN_EGITIMLER",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "VERILEN_EGITIMLER");

            migrationBuilder.CreateIndex(
                name: "IX_EVDE_SAGLIK_IZLEM_YATAGA_BAGIMLILIK",
                schema: "Lbys",
                table: "EVDE_SAGLIK_IZLEM",
                column: "YATAGA_BAGIMLILIK");

            migrationBuilder.CreateIndex(
                name: "IX_FATURA_FATURA_KESILEN_KURUM_KODU",
                schema: "Lbys",
                table: "FATURA",
                column: "FATURA_KESILEN_KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_FATURA_FATURA_TURU",
                schema: "Lbys",
                table: "FATURA",
                column: "FATURA_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_FATURA_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "FATURA",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_FATURA_HASTA_KODU",
                schema: "Lbys",
                table: "FATURA",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_FATURA_ICMAL_KODU",
                schema: "Lbys",
                table: "FATURA",
                column: "ICMAL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_BC_BEYIN_GELISIM_RISKLERI",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "BC_BEYIN_GELISIM_RISKLERI");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_DEMIR_LOJISTIGI_VE_DESTEGI",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "DEMIR_LOJISTIGI_VE_DESTEGI");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_DVITAMINI_LOJISTIGI_VE_DESTEGI",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "DVITAMINI_LOJISTIGI_VE_DESTEGI");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_GEBE_IZLEM_ISLEM_TURU",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "GEBE_IZLEM_ISLEM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_GEBELIKTE_RISK_FAKTORLERI",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "GEBELIKTE_RISK_FAKTORLERI");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_GESTASYONEL_DIYABET_TARAMASI",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "GESTASYONEL_DIYABET_TARAMASI");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_HASTA_KODU",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_IDRARDA_PROTEIN",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "IDRARDA_PROTEIN");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_KACINCI_GEBE_IZLEM",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "KACINCI_GEBE_IZLEM");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_KONJENITAL_ANOMALI_VARLIGI",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "KONJENITAL_ANOMALI_VARLIGI");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_ONCEKI_DOGUM_DURUMU",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "ONCEKI_DOGUM_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_PSIKOLOJIK_GELISIM_RISK_EGITIM",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "PSIKOLOJIK_GELISIM_RISK_EGITIM");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_RISK_ALTINDAKI_OLGU_TAKIBI",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "RISK_ALTINDAKI_OLGU_TAKIBI");

            migrationBuilder.CreateIndex(
                name: "IX_GEBE_IZLEM_RISK_FAKTORLERINE_MUDAHALE",
                schema: "Lbys",
                table: "GEBE_IZLEM",
                column: "RISK_FAKTORLERINE_MUDAHALE");

            migrationBuilder.CreateIndex(
                name: "IX_GETAT_GETAT_TEDAVI_SONUCU",
                schema: "Lbys",
                table: "GETAT",
                column: "GETAT_TEDAVI_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_GETAT_GETAT_UYGULAMA_BIRIMI",
                schema: "Lbys",
                table: "GETAT",
                column: "GETAT_UYGULAMA_BIRIMI");

            migrationBuilder.CreateIndex(
                name: "IX_GETAT_GETAT_UYGULAMA_BOLGESI",
                schema: "Lbys",
                table: "GETAT",
                column: "GETAT_UYGULAMA_BOLGESI");

            migrationBuilder.CreateIndex(
                name: "IX_GETAT_GETAT_UYGULAMA_TURU",
                schema: "Lbys",
                table: "GETAT",
                column: "GETAT_UYGULAMA_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_GETAT_GETAT_UYGULANDIGI_DURUMLAR",
                schema: "Lbys",
                table: "GETAT",
                column: "GETAT_UYGULANDIGI_DURUMLAR");

            migrationBuilder.CreateIndex(
                name: "IX_GETAT_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "GETAT",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_GETAT_HASTA_KODU",
                schema: "Lbys",
                table: "GETAT",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_GETAT_KOMPLIKASYON_TANISI",
                schema: "Lbys",
                table: "GETAT",
                column: "KOMPLIKASYON_TANISI");

            migrationBuilder.CreateIndex(
                name: "IX_GRUP_UYELIK_KULLANICI_GRUP_KODU",
                schema: "Lbys",
                table: "GRUP_UYELIK",
                column: "KULLANICI_GRUP_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_GRUP_UYELIK_KULLANICI_KODU",
                schema: "Lbys",
                table: "GRUP_UYELIK",
                column: "KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_CINSIYET",
                schema: "Lbys",
                table: "HASTA",
                column: "CINSIYET");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_KAN_GRUBU",
                schema: "Lbys",
                table: "HASTA",
                column: "KAN_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MEDENI_HAL",
                schema: "Lbys",
                table: "HASTA",
                column: "MEDENI_HAL");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SOSYAL_GUVENCE",
                schema: "Lbys",
                table: "HASTA",
                column: "SOSYAL_GUVENCE");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_ADLI_MUAYENE_RIZA_DURUMU",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "ADLI_MUAYENE_RIZA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_ADLI_RAPOR_TURU",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "ADLI_RAPOR_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_ELBISE_DURUMU",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "ELBISE_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_IPTAL_EDEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "IPTAL_EDEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_ISIK_REFLEKSI",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "ISIK_REFLEKSI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_ONAYLAYAN_KULLANICI_KODU",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "ONAYLAYAN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_PUPILLA_DEGERLENDIRMESI",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "PUPILLA_DEGERLENDIRMESI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_RIZA_VERENIN_YAKINLIK_DERECESI",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "RIZA_VERENIN_YAKINLIK_DERECESI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ADLI_RAPOR_TENDON_REFLEKSI",
                schema: "Lbys",
                table: "HASTA_ADLI_RAPOR",
                column: "TENDON_REFLEKSI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_ARSIV_DEFTER_TURU",
                schema: "Lbys",
                table: "HASTA_ARSIV",
                column: "ARSIV_DEFTER_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_ARSIV",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_DETAY_DOSYA_ALAN_BIRIM_KODU",
                schema: "Lbys",
                table: "HASTA_ARSIV_DETAY",
                column: "DOSYA_ALAN_BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_DETAY_DOSYA_ALAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "HASTA_ARSIV_DETAY",
                column: "DOSYA_ALAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_DETAY_DOSYA_VEREN_BIRIM_KODU",
                schema: "Lbys",
                table: "HASTA_ARSIV_DETAY",
                column: "DOSYA_VEREN_BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_DETAY_DOSYA_VEREN_KULLANICI_KODU",
                schema: "Lbys",
                table: "HASTA_ARSIV_DETAY",
                column: "DOSYA_VEREN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_DETAY_HASTA_ARSIV_KODU",
                schema: "Lbys",
                table: "HASTA_ARSIV_DETAY",
                column: "HASTA_ARSIV_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_DETAY_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_ARSIV_DETAY",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ARSIV_DETAY_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_ARSIV_DETAY",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_BASVURU_BASVURU_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "BASVURU_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_BASVURU_BASVURU_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "BASVURU_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_BASVURU_BIRIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_BASVURU_CIKIS_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "CIKIS_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_BASVURU_DOKTOR_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "DOKTOR_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_BASVURU_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_BORC_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_BORC",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_BORC_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_BORC",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_CENE_BOLGESI",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "CENE_BOLGESI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_DIS_ISLEM_TURU",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "DIS_ISLEM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_DIS_KODU",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "DIS_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_DIS_TAAHHUT_KODU",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "DIS_TAAHHUT_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_DISPROTEZ_KODU",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "DISPROTEZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_HASTA_HIZMET_KODU",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "HASTA_HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_DIS_MEVCUT_DIS_DURUMU",
                schema: "Lbys",
                table: "HASTA_DIS",
                column: "MEVCUT_DIS_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_EPIKRIZ_EPIKRIZ_BASLIK_BILGISI",
                schema: "Lbys",
                table: "HASTA_EPIKRIZ",
                column: "EPIKRIZ_BASLIK_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_EPIKRIZ_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_EPIKRIZ",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_EPIKRIZ_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_EPIKRIZ",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_EPIKRIZ_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_EPIKRIZ",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_FOTOGRAF_FOTOGRAF_TURU",
                schema: "Lbys",
                table: "HASTA_FOTOGRAF",
                column: "FOTOGRAF_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_FOTOGRAF_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_FOTOGRAF",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_FOTOGRAF_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_FOTOGRAF",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_GIZLILIK_GIZLILIK_NEDENI",
                schema: "Lbys",
                table: "HASTA_GIZLILIK",
                column: "GIZLILIK_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_GIZLILIK_GIZLILIK_TURU",
                schema: "Lbys",
                table: "HASTA_GIZLILIK",
                column: "GIZLILIK_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_GIZLILIK_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_GIZLILIK",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_GIZLILIK_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_GIZLILIK",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_FATURA_KODU",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "FATURA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_HASTA_HIZMET_DURUMU",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "HASTA_HIZMET_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_HIZMET_FATURA_DURUMU",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "HIZMET_FATURA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_HIZMET_KODU",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_ISTEYEN_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "ISTEYEN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_ONAYLAYAN_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "ONAYLAYAN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_TARAF_BILGISI",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "TARAF_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_HIZMET_TIBBI_ISLEM_PUAN_BILGISI",
                schema: "Lbys",
                table: "HASTA_HIZMET",
                column: "TIBBI_ISLEM_PUAN_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_ADRES_KODU_SEVIYESI",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "ADRES_KODU_SEVIYESI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_ADRES_TIPI",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "ADRES_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_BUCAK_KODU",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "BUCAK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_IL_KODU",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "IL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_ILCE_KODU",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "ILCE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_KOY_KODU",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "KOY_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_ILETISIM_MAHALLE_KODU",
                schema: "Lbys",
                table: "HASTA_ILETISIM",
                column: "MAHALLE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_AMELIYAT_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "AMELIYAT_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_DEPO_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_FATURA_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "FATURA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_ISTEYEN_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "ISTEYEN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_MALZEME_FATURA_DURUMU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "MALZEME_FATURA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_MEDULA_TAKIP_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "MEDULA_TAKIP_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_STOK_HAREKET_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "STOK_HAREKET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_MALZEME_STOK_KART_KODU",
                schema: "Lbys",
                table: "HASTA_MALZEME",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_NOTLARI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_NOTLARI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_NOTLARI_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_NOTLARI",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_ANNE_OLUM_NEDENI",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "ANNE_OLUM_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_EX_KARARINI_VEREN_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "EX_KARARINI_VEREN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_OLUM_BELGESI_PERSONEL_KODU",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "OLUM_BELGESI_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_OLUM_NEDENI_TANI_KODU",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "OLUM_NEDENI_TANI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_OLUM_NEDENI_TURU",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "OLUM_NEDENI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_OLUM_SEKLI",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "OLUM_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_OLUM_YERI",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "OLUM_YERI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_OTOPSI_DURUMU",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "OTOPSI_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_OLUM_TESLIM_EDEN_PERSONEL_KODU",
                schema: "Lbys",
                table: "HASTA_OLUM",
                column: "TESLIM_EDEN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_AGIRLIK_OLCUM_ZAMANI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "AGIRLIK_OLCUM_ZAMANI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_AKTIF_VITAMIN_D_KULLANIMI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "AKTIF_VITAMIN_D_KULLANIMI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_ANEMI_TEDAVISI_YONTEMI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "ANEMI_TEDAVISI_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_ANTIHIPERTANSIF_ILAC_DURUMU",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "ANTIHIPERTANSIF_ILAC_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_CIHAZ_KODU",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_DAMAR_ERISIM_YOLU",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "DAMAR_ERISIM_YOLU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_DIYALIZE_GIRME_SIKLIGI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "DIYALIZE_GIRME_SIKLIGI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_DIYALIZOR_ALANI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "DIYALIZOR_ALANI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_DIYALIZOR_TIPI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "DIYALIZOR_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_FOSFOR_BAGLAYICI_AJAN",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "FOSFOR_BAGLAYICI_AJAN");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_HEMODIYALIZE_GECME_NEDENLERI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "HEMODIYALIZE_GECME_NEDENLERI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_KAN_AKIM_HIZI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "KAN_AKIM_HIZI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_KULLANILAN_DIYALIZ_TEDAVISI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "KULLANILAN_DIYALIZ_TEDAVISI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_ONCEKI_RRT_YONTEMI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "ONCEKI_RRT_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_PERITON_KACINCI_KATETER",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "PERITON_KACINCI_KATETER");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_PERITON_KATETER_TIPI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "PERITON_KATETER_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_PERITON_KATETER_YONTEMI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "PERITON_KATETER_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_PERITON_KOMPLIKASYON",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "PERITON_KOMPLIKASYON");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_PERITON_TUNEL_YONU",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "PERITON_TUNEL_YONU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_PERITONEAL_GECIRGENLIK_DURUMU",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "PERITONEAL_GECIRGENLIK_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_SEANS_ISLEM_TURU",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "SEANS_ISLEM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_SINEKALSET",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "SINEKALSET");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEANS_TEDAVININ_SEYRI",
                schema: "Lbys",
                table: "HASTA_SEANS",
                column: "TEDAVININ_SEYRI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_EDEN_1_PERSONEL_KODU",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_EDEN_1_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_EDEN_2_PERSONEL_KODU",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_EDEN_2_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_EDEN_3_PERSONEL_KODU",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_EDEN_3_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_EDILEN_KURUM_KODU",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_EDILEN_KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_NEDENI",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_SEKLI",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_TANISI",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_TANISI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_TEDAVI_TIPI",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_TEDAVI_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_SEVK_SEVK_VASITASI_KODU",
                schema: "Lbys",
                table: "HASTA_SEVK",
                column: "SEVK_VASITASI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_TIBBI_BILGI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_TIBBI_BILGI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_TIBBI_BILGI_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_TIBBI_BILGI",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_TIBBI_BILGI_TIBBI_BILGI_ALT_TURU",
                schema: "Lbys",
                table: "HASTA_TIBBI_BILGI",
                column: "TIBBI_BILGI_ALT_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_TIBBI_BILGI_TIBBI_BILGI_TURU",
                schema: "Lbys",
                table: "HASTA_TIBBI_BILGI",
                column: "TIBBI_BILGI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_UYARI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_UYARI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_UYARI_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_UYARI",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_UYARI_UYARI_TURU",
                schema: "Lbys",
                table: "HASTA_UYARI",
                column: "UYARI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_VENTILATOR_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_VENTILATOR",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_VENTILATOR_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_VENTILATOR",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_VENTILATOR_VENTILATOR_CIHAZ_KODU",
                schema: "Lbys",
                table: "HASTA_VENTILATOR",
                column: "VENTILATOR_CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_VENTILATOR_YOGUN_BAKIM_SEVIYE_BILGISI",
                schema: "Lbys",
                table: "HASTA_VENTILATOR",
                column: "YOGUN_BAKIM_SEVIYE_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_VITAL_FIZIKI_BULGU_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_VITAL_FIZIKI_BULGU",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_VITAL_FIZIKI_BULGU_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_VITAL_FIZIKI_BULGU",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_VITAL_FIZIKI_BULGU_HEMSIRE_KODU",
                schema: "Lbys",
                table: "HASTA_VITAL_FIZIKI_BULGU",
                column: "HEMSIRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_YATAK_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_YATAK",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_YATAK_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA_YATAK",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HASTA_YATAK_YATAK_KODU",
                schema: "Lbys",
                table: "HASTA_YATAK",
                column: "YATAK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HEMOGLOBINOPATI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HEMOGLOBINOPATI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HEMOGLOBINOPATI_HEMOGLOBINOPATI_SONUC_HASTALIK",
                schema: "Lbys",
                table: "HEMOGLOBINOPATI",
                column: "HEMOGLOBINOPATI_SONUC_HASTALIK");

            migrationBuilder.CreateIndex(
                name: "IX_HEMOGLOBINOPATI_HEMOGLOBINOPATI_TARAMA_SONUCU",
                schema: "Lbys",
                table: "HEMOGLOBINOPATI",
                column: "HEMOGLOBINOPATI_TARAMA_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_HEMOGLOBINOPATI_HEMOGLOBINOPATI_TASIYICILIK",
                schema: "Lbys",
                table: "HEMOGLOBINOPATI",
                column: "HEMOGLOBINOPATI_TASIYICILIK");

            migrationBuilder.CreateIndex(
                name: "IX_HEMOGLOBINOPATI_HEMOGLOBINOPATI_TESTI_SONUCU",
                schema: "Lbys",
                table: "HEMOGLOBINOPATI",
                column: "HEMOGLOBINOPATI_TESTI_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_HEMSIRE_BAKIM_BAKIM_NEDENI",
                schema: "Lbys",
                table: "HEMSIRE_BAKIM",
                column: "BAKIM_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_HEMSIRE_BAKIM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "HEMSIRE_BAKIM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HEMSIRE_BAKIM_HASTA_KODU",
                schema: "Lbys",
                table: "HEMSIRE_BAKIM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HEMSIRE_BAKIM_HEMSIRE_BAKIM_HEDEF_SONUC",
                schema: "Lbys",
                table: "HEMSIRE_BAKIM",
                column: "HEMSIRE_BAKIM_HEDEF_SONUC");

            migrationBuilder.CreateIndex(
                name: "IX_HEMSIRE_BAKIM_HEMSIRE_DEGERLENDIRME_DURUMU",
                schema: "Lbys",
                table: "HEMSIRE_BAKIM",
                column: "HEMSIRE_DEGERLENDIRME_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_HEMSIRE_BAKIM_HEMSIRE_KODU",
                schema: "Lbys",
                table: "HEMSIRE_BAKIM",
                column: "HEMSIRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HEMSIRE_BAKIM_HEMSIRELIK_GIRISIMI",
                schema: "Lbys",
                table: "HEMSIRE_BAKIM",
                column: "HEMSIRELIK_GIRISIMI");

            migrationBuilder.CreateIndex(
                name: "IX_HEMSIRE_BAKIM_HEMSIRELIK_TANI_KODU",
                schema: "Lbys",
                table: "HEMSIRE_BAKIM",
                column: "HEMSIRELIK_TANI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_HIZMET_HIZMET_ISLEM_GRUBU",
                schema: "Lbys",
                table: "HIZMET",
                column: "HIZMET_ISLEM_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_HIZMET_HIZMET_ISLEM_TURU",
                schema: "Lbys",
                table: "HIZMET",
                column: "HIZMET_ISLEM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_HIZMET_TIBBI_ISLEM_PUAN_BILGISI",
                schema: "Lbys",
                table: "HIZMET",
                column: "TIBBI_ISLEM_PUAN_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_ICMAL_KURUM_KODU",
                schema: "Lbys",
                table: "ICMAL",
                column: "KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ILAC_UYUM_BESIN_KODU",
                schema: "Lbys",
                table: "ILAC_UYUM",
                column: "BESIN_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ILAC_UYUM_BIRINCI_ETKEN_MADDE_KODU",
                schema: "Lbys",
                table: "ILAC_UYUM",
                column: "BIRINCI_ETKEN_MADDE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ILAC_UYUM_BIRINCI_ILAC_BARKODU",
                schema: "Lbys",
                table: "ILAC_UYUM",
                column: "BIRINCI_ILAC_BARKODU");

            migrationBuilder.CreateIndex(
                name: "IX_ILAC_UYUM_CINSIYET",
                schema: "Lbys",
                table: "ILAC_UYUM",
                column: "CINSIYET");

            migrationBuilder.CreateIndex(
                name: "IX_ILAC_UYUM_IKINCI_ETKEN_MADDE_KODU",
                schema: "Lbys",
                table: "ILAC_UYUM",
                column: "IKINCI_ETKEN_MADDE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ILAC_UYUM_IKINCI_ILAC_BARKODU",
                schema: "Lbys",
                table: "ILAC_UYUM",
                column: "IKINCI_ILAC_BARKODU");

            migrationBuilder.CreateIndex(
                name: "IX_ILAC_UYUM_ILAC_UYUMSUZLUK_TURU",
                schema: "Lbys",
                table: "ILAC_UYUM",
                column: "ILAC_UYUMSUZLUK_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_ILAC_UYUM_RENK_SEVIYE_KODU",
                schema: "Lbys",
                table: "ILAC_UYUM",
                column: "RENK_SEVIYE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_INTIHAR_IZLEM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "INTIHAR_IZLEM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_INTIHAR_IZLEM_HASTA_KODU",
                schema: "Lbys",
                table: "INTIHAR_IZLEM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_INTIHAR_IZLEM_INTIHAR_GIRISIM_KRIZ_NEDENLERI",
                schema: "Lbys",
                table: "INTIHAR_IZLEM",
                column: "INTIHAR_GIRISIM_KRIZ_NEDENLERI");

            migrationBuilder.CreateIndex(
                name: "IX_INTIHAR_IZLEM_INTIHAR_GIRISIMI_YONTEMI",
                schema: "Lbys",
                table: "INTIHAR_IZLEM",
                column: "INTIHAR_GIRISIMI_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_INTIHAR_IZLEM_INTIHAR_KRIZ_VAKA_SONUCU",
                schema: "Lbys",
                table: "INTIHAR_IZLEM",
                column: "INTIHAR_KRIZ_VAKA_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_INTIHAR_IZLEM_INTIHAR_KRIZ_VAKA_TURU",
                schema: "Lbys",
                table: "INTIHAR_IZLEM",
                column: "INTIHAR_KRIZ_VAKA_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KADIN_IZLEM_AP_YONTEMI_LOJISTIGI",
                schema: "Lbys",
                table: "KADIN_IZLEM",
                column: "AP_YONTEMI_LOJISTIGI");

            migrationBuilder.CreateIndex(
                name: "IX_KADIN_IZLEM_BIR_ONCE_KULLANILAN_AP_YONTEMI",
                schema: "Lbys",
                table: "KADIN_IZLEM",
                column: "BIR_ONCE_KULLANILAN_AP_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_KADIN_IZLEM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KADIN_IZLEM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KADIN_IZLEM_HASTA_KODU",
                schema: "Lbys",
                table: "KADIN_IZLEM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KADIN_IZLEM_KADIN_SAGLIGI_ISLEMLERI",
                schema: "Lbys",
                table: "KADIN_IZLEM",
                column: "KADIN_SAGLIGI_ISLEMLERI");

            migrationBuilder.CreateIndex(
                name: "IX_KADIN_IZLEM_KONJENITAL_ANOMALI_VARLIGI",
                schema: "Lbys",
                table: "KADIN_IZLEM",
                column: "KONJENITAL_ANOMALI_VARLIGI");

            migrationBuilder.CreateIndex(
                name: "IX_KADIN_IZLEM_KULLANILAN_AP_YONTEMI",
                schema: "Lbys",
                table: "KADIN_IZLEM",
                column: "KULLANILAN_AP_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_KADIN_IZLEM_ONCEKI_DOGUM_DURUMU",
                schema: "Lbys",
                table: "KADIN_IZLEM",
                column: "ONCEKI_DOGUM_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_BAGISCI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "BAGISCI_HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_BAGISCI_HASTA_KODU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "BAGISCI_HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_BAGISCI_TURU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "BAGISCI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_BAGISLANAN_KAN_TURU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "BAGISLANAN_KAN_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_DEGERLENDIREN_PERSONEL_KODU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "DEGERLENDIREN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_KAN_BAGIS_DEGERLENDIRME_SONUCU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "KAN_BAGIS_DEGERLENDIRME_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_KAN_BAGISCISI_RET_NEDENLERI",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "KAN_BAGISCISI_RET_NEDENLERI");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_KAN_GRUBU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "KAN_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_REAKSIYON_TURU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "REAKSIYON_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_BAGISCI_REZERV_HASTA_KODU",
                schema: "Lbys",
                table: "KAN_BAGISCI",
                column: "REZERV_HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_CROSS_MATCH_CALISMA_YONTEMI",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "CROSS_MATCH_CALISMA_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_CROSS_MATCH_KULLANICI_KODU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "CROSS_MATCH_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_CROSS_MATCH_SONUCU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "CROSS_MATCH_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_HASTA_KODU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_KAN_CIKIS_PERSONEL_KODU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "KAN_CIKIS_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_KAN_STOK_KODU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "KAN_STOK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_KAN_TALEP_DETAY_KODU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "KAN_TALEP_DETAY_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_KURUM_KODU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_CIKIS_REZERVE_EDEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "KAN_CIKIS",
                column: "REZERVE_EDEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_STOK_BAGLI_KAN_STOK_KODU",
                schema: "Lbys",
                table: "KAN_STOK",
                column: "BAGLI_KAN_STOK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_STOK_BIRIM_KODU",
                schema: "Lbys",
                table: "KAN_STOK",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_STOK_KAN_BAGISCI_KODU",
                schema: "Lbys",
                table: "KAN_STOK",
                column: "KAN_BAGISCI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_STOK_KAN_GRUBU",
                schema: "Lbys",
                table: "KAN_STOK",
                column: "KAN_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_STOK_KAN_STOK_DURUMU",
                schema: "Lbys",
                table: "KAN_STOK",
                column: "KAN_STOK_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_STOK_KAN_URUN_KODU",
                schema: "Lbys",
                table: "KAN_STOK",
                column: "KAN_URUN_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_STOK_KURUM_KODU",
                schema: "Lbys",
                table: "KAN_STOK",
                column: "KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KAN_TALEP",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_HASTA_KODU",
                schema: "Lbys",
                table: "KAN_TALEP",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_ISTENEN_KAN_GRUBU",
                schema: "Lbys",
                table: "KAN_TALEP",
                column: "ISTENEN_KAN_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_ISTEYEN_HEKIM_KODU",
                schema: "Lbys",
                table: "KAN_TALEP",
                column: "ISTEYEN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_KAN_ENDIKASYON_TURU",
                schema: "Lbys",
                table: "KAN_TALEP",
                column: "KAN_ENDIKASYON_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_KAN_ISTEYEN_BIRIM_KODU",
                schema: "Lbys",
                table: "KAN_TALEP",
                column: "KAN_ISTEYEN_BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_KAN_TALEP_ACILIYET_SEVIYESI",
                schema: "Lbys",
                table: "KAN_TALEP",
                column: "KAN_TALEP_ACILIYET_SEVIYESI");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_KAN_TALEP_NEDENI",
                schema: "Lbys",
                table: "KAN_TALEP",
                column: "KAN_TALEP_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_DETAY_ISTENEN_KAN_GRUBU",
                schema: "Lbys",
                table: "KAN_TALEP_DETAY",
                column: "ISTENEN_KAN_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_DETAY_KAN_TALEP_KODU",
                schema: "Lbys",
                table: "KAN_TALEP_DETAY",
                column: "KAN_TALEP_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_DETAY_KAN_TALEP_RET_NEDENI",
                schema: "Lbys",
                table: "KAN_TALEP_DETAY",
                column: "KAN_TALEP_RET_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_DETAY_KAN_URUN_KODU",
                schema: "Lbys",
                table: "KAN_TALEP_DETAY",
                column: "KAN_URUN_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_TALEP_DETAY_RET_EDEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "KAN_TALEP_DETAY",
                column: "RET_EDEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_URUN_HIZMET_KODU",
                schema: "Lbys",
                table: "KAN_URUN",
                column: "HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_URUN_IMHA_KAN_IMHA_EDEN_PERSONEL_KODU",
                schema: "Lbys",
                table: "KAN_URUN_IMHA",
                column: "KAN_IMHA_EDEN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_URUN_IMHA_KAN_IMHA_NEDENI",
                schema: "Lbys",
                table: "KAN_URUN_IMHA",
                column: "KAN_IMHA_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_URUN_IMHA_KAN_IMHA_ONAYLAYAN_HEKIM",
                schema: "Lbys",
                table: "KAN_URUN_IMHA",
                column: "KAN_IMHA_ONAYLAYAN_HEKIM");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_URUN_IMHA_KAN_IMHA_ONAYLAYAN_TEKNISYEN",
                schema: "Lbys",
                table: "KAN_URUN_IMHA",
                column: "KAN_IMHA_ONAYLAYAN_TEKNISYEN");

            migrationBuilder.CreateIndex(
                name: "IX_KAN_URUN_IMHA_KAN_STOK_KODU",
                schema: "Lbys",
                table: "KAN_URUN_IMHA",
                column: "KAN_STOK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KLINIK_SEYIR_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KLINIK_SEYIR",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KLINIK_SEYIR_HASTA_KODU",
                schema: "Lbys",
                table: "KLINIK_SEYIR",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KLINIK_SEYIR_HEKIM_KODU",
                schema: "Lbys",
                table: "KLINIK_SEYIR",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KLINIK_SEYIR_SEPSIS_DURUMU",
                schema: "Lbys",
                table: "KLINIK_SEYIR",
                column: "SEPSIS_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_KLINIK_SEYIR_SEPTIK_SOK",
                schema: "Lbys",
                table: "KLINIK_SEYIR",
                column: "SEPTIK_SOK");

            migrationBuilder.CreateIndex(
                name: "IX_KLINIK_SEYIR_SEYIR_TIPI",
                schema: "Lbys",
                table: "KLINIK_SEYIR",
                column: "SEYIR_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_KONSULTASYON_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KONSULTASYON",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KONSULTASYON_HASTA_HIZMET_KODU",
                schema: "Lbys",
                table: "KONSULTASYON",
                column: "HASTA_HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KONSULTASYON_HASTA_KODU",
                schema: "Lbys",
                table: "KONSULTASYON",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KONSULTASYON_KONSULTASYON_BASVURU_KODU",
                schema: "Lbys",
                table: "KONSULTASYON",
                column: "KONSULTASYON_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KONSULTASYON_KONSULTASYON_YERI",
                schema: "Lbys",
                table: "KONSULTASYON",
                column: "KONSULTASYON_YERI");

            migrationBuilder.CreateIndex(
                name: "IX_KUDUZ_IZLEM_BEYAN_TSM_KURUM_KODU",
                schema: "Lbys",
                table: "KUDUZ_IZLEM",
                column: "BEYAN_TSM_KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KUDUZ_IZLEM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KUDUZ_IZLEM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KUDUZ_IZLEM_HASTA_KODU",
                schema: "Lbys",
                table: "KUDUZ_IZLEM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KUDUZ_IZLEM_PROFILAKSI_TAMAMLANMA_DURUMU",
                schema: "Lbys",
                table: "KUDUZ_IZLEM",
                column: "PROFILAKSI_TAMAMLANMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_KUDUZ_IZLEM_UYGULANAN_KUDUZ_PROFILAKSISI",
                schema: "Lbys",
                table: "KUDUZ_IZLEM",
                column: "UYGULANAN_KUDUZ_PROFILAKSISI");

            migrationBuilder.CreateIndex(
                name: "IX_KULLANICI_PERSONEL_KODU",
                schema: "Lbys",
                table: "KULLANICI",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_MEDULA_ALT_RAPOR_TURU",
                schema: "Lbys",
                table: "KURUL",
                column: "MEDULA_ALT_RAPOR_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_MEDULA_RAPOR_TURU",
                schema: "Lbys",
                table: "KURUL",
                column: "MEDULA_RAPOR_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_RAPOR_TURU",
                schema: "Lbys",
                table: "KURUL",
                column: "RAPOR_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_ALKOL_MADDE_BAGIMLILIGI",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "ALKOL_MADDE_BAGIMLILIGI");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_ASAL_HASTALIK",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "ASAL_HASTALIK");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_ASAL_HASTALIK_TIPI",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "ASAL_HASTALIK_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_BEDEN_RUH_ILERI_TETKIK_BULGUSU",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "BEDEN_RUH_ILERI_TETKIK_BULGUSU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_GECMIS_HASTALIGA_DAIR_KAYIT",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "GECMIS_HASTALIGA_DAIR_KAYIT");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_GORME_ISITME_KAYBI",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "GORME_ISITME_KAYBI");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_MEDULA_ALT_RAPOR_TURU",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "MEDULA_ALT_RAPOR_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_MEDULA_RAPOR_TURU",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "MEDULA_RAPOR_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_PSIKIYATRIK_RAHATSIZLIK",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "PSIKIYATRIK_RAHATSIZLIK");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ASKERI_UZUVKAYBI_ORTOPEDI_RAHATSIZLIK",
                schema: "Lbys",
                table: "KURUL_ASKERI",
                column: "UZUVKAYBI_ORTOPEDI_RAHATSIZLIK");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ENGELLI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KURUL_ENGELLI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ENGELLI_HASTA_KODU",
                schema: "Lbys",
                table: "KURUL_ENGELLI",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ENGELLI_KURUL_RAPOR_KODU",
                schema: "Lbys",
                table: "KURUL_ENGELLI",
                column: "KURUL_RAPOR_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ETKEN_MADDE_DOZ_BIRIM",
                schema: "Lbys",
                table: "KURUL_ETKEN_MADDE",
                column: "DOZ_BIRIM");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ETKEN_MADDE_ILAC_PERIYOT_BIRIMI",
                schema: "Lbys",
                table: "KURUL_ETKEN_MADDE",
                column: "ILAC_PERIYOT_BIRIMI");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_ETKEN_MADDE_KURUL_RAPOR_KODU",
                schema: "Lbys",
                table: "KURUL_ETKEN_MADDE",
                column: "KURUL_RAPOR_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_HEKIM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KURUL_HEKIM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_HEKIM_HASTA_KODU",
                schema: "Lbys",
                table: "KURUL_HEKIM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_HEKIM_HEKIM_KODU",
                schema: "Lbys",
                table: "KURUL_HEKIM",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_HEKIM_KURUL_RAPOR_KODU",
                schema: "Lbys",
                table: "KURUL_HEKIM",
                column: "KURUL_RAPOR_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_HEKIM_SISTEM_KODU",
                schema: "Lbys",
                table: "KURUL_HEKIM",
                column: "SISTEM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_RAPOR_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "KURUL_RAPOR",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_RAPOR_HASTA_KODU",
                schema: "Lbys",
                table: "KURUL_RAPOR",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_RAPOR_KARAR_ICERIK_FORMATI",
                schema: "Lbys",
                table: "KURUL_RAPOR",
                column: "KARAR_ICERIK_FORMATI");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_RAPOR_KURUL_KODU",
                schema: "Lbys",
                table: "KURUL_RAPOR",
                column: "KURUL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_TESHIS_KURUL_RAPOR_KODU",
                schema: "Lbys",
                table: "KURUL_TESHIS",
                column: "KURUL_RAPOR_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUL_TESHIS_TANI_KODU",
                schema: "Lbys",
                table: "KURUL_TESHIS",
                column: "TANI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUM_KURUM_TURU",
                schema: "Lbys",
                table: "KURUM",
                column: "KURUM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_DEMIR_LOJISTIGI_VE_DESTEGI",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "DEMIR_LOJISTIGI_VE_DESTEGI");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_DVITAMINI_LOJISTIGI_VE_DESTEGI",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "DVITAMINI_LOJISTIGI_VE_DESTEGI");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_HASTA_KODU",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_IZLEMIN_YAPILDIGI_YER",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "IZLEMIN_YAPILDIGI_YER");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_KACINCI_LOHUSA_IZLEM",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "KACINCI_LOHUSA_IZLEM");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_KADIN_SAGLIGI_ISLEMLERI",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "KADIN_SAGLIGI_ISLEMLERI");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_KOMPLIKASYON_TANISI",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "KOMPLIKASYON_TANISI");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_KONJENITAL_ANOMALI_VARLIGI",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "KONJENITAL_ANOMALI_VARLIGI");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_POSTPARTUM_DEPRESYON",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "POSTPARTUM_DEPRESYON");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_SEYIR_TEHLIKE_ISARETI",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "SEYIR_TEHLIKE_ISARETI");

            migrationBuilder.CreateIndex(
                name: "IX_LOHUSA_IZLEM_UTERUS_INVOLUSYON",
                schema: "Lbys",
                table: "LOHUSA_IZLEM",
                column: "UTERUS_INVOLUSYON");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_BASLANAN_TEDAVI_TIPI_BILGISI",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "BASLANAN_TEDAVI_TIPI_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_BILGI_ALINAN_KAYNAK",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "BILGI_ALINAN_KAYNAK");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_BIRINCIL_KULLANILAN_ESAS_MADDE",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "BIRINCIL_KULLANILAN_ESAS_MADDE");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_BULASICI_HASTALIK_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "BULASICI_HASTALIK_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_CEZAEVI_OYKUSU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "CEZAEVI_OYKUSU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_COCUKLARIYLA_YASAMA_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "COCUKLARIYLA_YASAMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_DANISMA_TEDAVI_HIZMET_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "DANISMA_TEDAVI_HIZMET_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_ENJEKSIYON_ILE_MADDE_KULLANIMI",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "ENJEKSIYON_ILE_MADDE_KULLANIMI");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_ENJEKTOR_PAYLASIM_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "ENJEKTOR_PAYLASIM_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_GONDEREN_BIRIM",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "GONDEREN_BIRIM");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_GORUSME_SONUCU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "GORUSME_SONUCU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_HBV_TEST_YAPILMA_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "HBV_TEST_YAPILMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_HCV_TEST_YAPILMA_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "HCV_TEST_YAPILMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_HIV_TEST_YAPILMA_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "HIV_TEST_YAPILMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_IKAME_TEDAVI_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "IKAME_TEDAVI_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_KULLANILAN_DIGER_MADDE",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "KULLANILAN_DIGER_MADDE");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_SOSYAL_YARDIM_ALMA_DURUMU",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "SOSYAL_YARDIM_ALMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_YASADIGI_BOLGE",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "YASADIGI_BOLGE");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_YASAM_BICIMI",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "YASAM_BICIMI");

            migrationBuilder.CreateIndex(
                name: "IX_MADDE_BAGIMLILIGI_YASAM_ORTAMI",
                schema: "Lbys",
                table: "MADDE_BAGIMLILIGI",
                column: "YASAM_ORTAMI");

            migrationBuilder.CreateIndex(
                name: "IX_MEDULA_TAKIP_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "MEDULA_TAKIP",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_MEDULA_TAKIP_HASTA_KODU",
                schema: "Lbys",
                table: "MEDULA_TAKIP",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_MEDULA_TAKIP_PROVIZYON_TURU",
                schema: "Lbys",
                table: "MEDULA_TAKIP",
                column: "PROVIZYON_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_MEDULA_TAKIP_TAKIP_TIPI",
                schema: "Lbys",
                table: "MEDULA_TAKIP",
                column: "TAKIP_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_MEDULA_TAKIP_TEDAVI_SEKLI",
                schema: "Lbys",
                table: "MEDULA_TAKIP",
                column: "TEDAVI_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_MEDULA_TAKIP_TEDAVI_TIPI",
                schema: "Lbys",
                table: "MEDULA_TAKIP",
                column: "TEDAVI_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_MEDULA_TAKIP_TEDAVI_TURU",
                schema: "Lbys",
                table: "MEDULA_TAKIP",
                column: "TEDAVI_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_NOBETCI_PERSONEL_BILGISI_GOREV_TURU",
                schema: "Lbys",
                table: "NOBETCI_PERSONEL_BILGISI",
                column: "GOREV_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_NOBETCI_PERSONEL_BILGISI_KLINIK_KODU",
                schema: "Lbys",
                table: "NOBETCI_PERSONEL_BILGISI",
                column: "KLINIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_NOBETCI_PERSONEL_BILGISI_PERSONEL_GOREV_KODU",
                schema: "Lbys",
                table: "NOBETCI_PERSONEL_BILGISI",
                column: "PERSONEL_GOREV_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_NOBETCI_PERSONEL_BILGISI_SKRS_KURUM_KODU",
                schema: "Lbys",
                table: "NOBETCI_PERSONEL_BILGISI",
                column: "SKRS_KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_OBEZITE_IZLEM_BIRLIKTE_GORULEN_EK_HASTALIK",
                schema: "Lbys",
                table: "OBEZITE_IZLEM",
                column: "BIRLIKTE_GORULEN_EK_HASTALIK");

            migrationBuilder.CreateIndex(
                name: "IX_OBEZITE_IZLEM_DIYET_TIBBI_BESLENME_TEDAVISI",
                schema: "Lbys",
                table: "OBEZITE_IZLEM",
                column: "DIYET_TIBBI_BESLENME_TEDAVISI");

            migrationBuilder.CreateIndex(
                name: "IX_OBEZITE_IZLEM_EGZERSIZ",
                schema: "Lbys",
                table: "OBEZITE_IZLEM",
                column: "EGZERSIZ");

            migrationBuilder.CreateIndex(
                name: "IX_OBEZITE_IZLEM_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "OBEZITE_IZLEM",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_OBEZITE_IZLEM_HASTA_KODU",
                schema: "Lbys",
                table: "OBEZITE_IZLEM",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_OBEZITE_IZLEM_MORBIT_OBEZ_LENFATIK_ODEM",
                schema: "Lbys",
                table: "OBEZITE_IZLEM",
                column: "MORBIT_OBEZ_LENFATIK_ODEM");

            migrationBuilder.CreateIndex(
                name: "IX_OBEZITE_IZLEM_OBEZITE_ILAC_TEDAVISI",
                schema: "Lbys",
                table: "OBEZITE_IZLEM",
                column: "OBEZITE_ILAC_TEDAVISI");

            migrationBuilder.CreateIndex(
                name: "IX_OBEZITE_IZLEM_PSIKOLOJIK_TEDAVI",
                schema: "Lbys",
                table: "OBEZITE_IZLEM",
                column: "PSIKOLOJIK_TEDAVI");

            migrationBuilder.CreateIndex(
                name: "IX_ODA_BIRIM_KODU",
                schema: "Lbys",
                table: "ODA",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_GOZLUK_RECETE_TIPI",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "GOZLUK_RECETE_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_GOZLUK_TURU",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "GOZLUK_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_HASTA_KODU",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_HEKIM_KODU",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_SAG_CAM_RENGI",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "SAG_CAM_RENGI");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_SAG_CAM_TIPI",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "SAG_CAM_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_SOL_CAM_RENGI",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "SOL_CAM_RENGI");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_SOL_CAM_TIPI",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "SOL_CAM_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_TELESKOPIK_GOZLUK_TIPI",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "TELESKOPIK_GOZLUK_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_OPTIK_RECETE_TELESKOPIK_GOZLUK_TURU",
                schema: "Lbys",
                table: "OPTIK_RECETE",
                column: "TELESKOPIK_GOZLUK_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_ORTODONTI_ICON_SKOR_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "ORTODONTI_ICON_SKOR",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ORTODONTI_ICON_SKOR_HASTA_KODU",
                schema: "Lbys",
                table: "ORTODONTI_ICON_SKOR",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ORTODONTI_ICON_SKOR_OIS_DEGERLENDIREN_1_HEKIM_KODU",
                schema: "Lbys",
                table: "ORTODONTI_ICON_SKOR",
                column: "OIS_DEGERLENDIREN_1_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ORTODONTI_ICON_SKOR_OIS_DEGERLENDIREN_2_HEKIM_KODU",
                schema: "Lbys",
                table: "ORTODONTI_ICON_SKOR",
                column: "OIS_DEGERLENDIREN_2_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_ORTODONTI_ICON_SKOR_OIS_DEGERLENDIREN_3_HEKIM_KODU",
                schema: "Lbys",
                table: "ORTODONTI_ICON_SKOR",
                column: "OIS_DEGERLENDIREN_3_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_ASISTAN_HEKIM_KODU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "ASISTAN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_DOKUNUN_TEMEL_OZELLIGI",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "DOKUNUN_TEMEL_OZELLIGI");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_HASTA_KODU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_NUMUNE_ALINMA_SEKLI",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "NUMUNE_ALINMA_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_NUMUNE_ALINMA_YERI",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "NUMUNE_ALINMA_YERI");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_ONAYLAYAN_HEKIM_KODU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "ONAYLAYAN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_PATOLOJI_DIGER_HEKIM_KODU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "PATOLOJI_DIGER_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_PATOLOJI_PREPARATI_DURUMU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "PATOLOJI_PREPARATI_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_PATOLOJI_RAPOR_TURU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "PATOLOJI_RAPOR_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_PATOLOJIK_TANI_MORFOLOJI_KODU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "PATOLOJIK_TANI_MORFOLOJI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_PATOLOJIK_TANI_YERLESIM_YERI",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "PATOLOJIK_TANI_YERLESIM_YERI");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_RAPOR_YAZAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "RAPOR_YAZAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_SONUC_ICERIK_TURU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "SONUC_ICERIK_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_PATOLOJI_TETKIK_NUMUNE_KODU",
                schema: "Lbys",
                table: "PATOLOJI",
                column: "TETKIK_NUMUNE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_CINSIYET",
                schema: "Lbys",
                table: "PERSONEL",
                column: "CINSIYET");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_UZMANLIK_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                column: "UZMANLIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BAKMAKLA_YUKUMLU_ENGELLILIK_DURUMU",
                schema: "Lbys",
                table: "PERSONEL_BAKMAKLA_YUKUMLU",
                column: "ENGELLILIK_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BAKMAKLA_YUKUMLU_OGRENIM_DURUMU",
                schema: "Lbys",
                table: "PERSONEL_BAKMAKLA_YUKUMLU",
                column: "OGRENIM_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BAKMAKLA_YUKUMLU_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_BAKMAKLA_YUKUMLU",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BAKMAKLA_YUKUMLU_PERSONEL_YAKINLIK_DERECESI",
                schema: "Lbys",
                table: "PERSONEL_BAKMAKLA_YUKUMLU",
                column: "PERSONEL_YAKINLIK_DERECESI");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BANKA_BANKA",
                schema: "Lbys",
                table: "PERSONEL_BANKA",
                column: "BANKA");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BANKA_BORDRO_TURU",
                schema: "Lbys",
                table: "PERSONEL_BANKA",
                column: "BORDRO_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BANKA_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_BANKA",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BORDRO_BES_FIRMA_KODU",
                schema: "Lbys",
                table: "PERSONEL_BORDRO",
                column: "BES_FIRMA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BORDRO_BORDRO_TURU",
                schema: "Lbys",
                table: "PERSONEL_BORDRO",
                column: "BORDRO_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BORDRO_ES_CALISMA_DURUMU",
                schema: "Lbys",
                table: "PERSONEL_BORDRO",
                column: "ES_CALISMA_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BORDRO_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_BORDRO",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BORDRO_SENDIKA_BILGISI",
                schema: "Lbys",
                table: "PERSONEL_BORDRO",
                column: "SENDIKA_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BORDRO_YABANCI_DIL_BILGISI",
                schema: "Lbys",
                table: "PERSONEL_BORDRO",
                column: "YABANCI_DIL_BILGISI");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BORDRO_SONDURUM_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_BORDRO_SONDURUM",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_EGITIM_ONAYLAYAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_EGITIM",
                column: "ONAYLAYAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_EGITIM_PERSONEL_EGITIM_TURU",
                schema: "Lbys",
                table: "PERSONEL_EGITIM",
                column: "PERSONEL_EGITIM_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_EGITIM_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_EGITIM",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_EGITIM_SERTIFIKA_TIPI",
                schema: "Lbys",
                table: "PERSONEL_EGITIM",
                column: "SERTIFIKA_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_GOREVLENDIRME_GOREV_TURU",
                schema: "Lbys",
                table: "PERSONEL_GOREVLENDIRME",
                column: "GOREV_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_GOREVLENDIRME_GOREVLENDIRILDIGI_KURUM_KODU",
                schema: "Lbys",
                table: "PERSONEL_GOREVLENDIRME",
                column: "GOREVLENDIRILDIGI_KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_GOREVLENDIRME_GOREVLENDIRME_IL_KODU",
                schema: "Lbys",
                table: "PERSONEL_GOREVLENDIRME",
                column: "GOREVLENDIRME_IL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_GOREVLENDIRME_GOREVLENDIRME_ILCE_KODU",
                schema: "Lbys",
                table: "PERSONEL_GOREVLENDIRME",
                column: "GOREVLENDIRME_ILCE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_GOREVLENDIRME_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_GOREVLENDIRME",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_IZIN_ONAYLAYAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_IZIN",
                column: "ONAYLAYAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_IZIN_PERSONEL_IZIN_TURU",
                schema: "Lbys",
                table: "PERSONEL_IZIN",
                column: "PERSONEL_IZIN_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_IZIN_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_IZIN",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_IZIN_SBYS_ENGELLEYEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "PERSONEL_IZIN",
                column: "SBYS_ENGELLEYEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_IZIN_DURUMU_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_IZIN_DURUMU",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_ODUL_CEZA_ODUL_CEZA_TURU",
                schema: "Lbys",
                table: "PERSONEL_ODUL_CEZA",
                column: "ODUL_CEZA_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_ODUL_CEZA_ODUL_CEZA_VEREN_KURUM_KODU",
                schema: "Lbys",
                table: "PERSONEL_ODUL_CEZA",
                column: "ODUL_CEZA_VEREN_KURUM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_ODUL_CEZA_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_ODUL_CEZA",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_OGRENIM_OGRENIM_DURUMU",
                schema: "Lbys",
                table: "PERSONEL_OGRENIM",
                column: "OGRENIM_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_OGRENIM_ONAYLAYAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_OGRENIM",
                column: "ONAYLAYAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_OGRENIM_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_OGRENIM",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_YANDAL_PERSONEL_KODU",
                schema: "Lbys",
                table: "PERSONEL_YANDAL",
                column: "PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_BIRIM_KODU",
                schema: "Lbys",
                table: "RADYOLOJI",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_CIHAZ_KODU",
                schema: "Lbys",
                table: "RADYOLOJI",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "RADYOLOJI",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_HASTA_HIZMET_KODU",
                schema: "Lbys",
                table: "RADYOLOJI",
                column: "HASTA_HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_HASTA_KODU",
                schema: "Lbys",
                table: "RADYOLOJI",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_KABUL_EDEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "RADYOLOJI",
                column: "KABUL_EDEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_TETKIK_CEKEN_TEKNISYEN_KODU",
                schema: "Lbys",
                table: "RADYOLOJI",
                column: "TETKIK_CEKEN_TEKNISYEN_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_TETKIK_ISTENME_DURUMU",
                schema: "Lbys",
                table: "RADYOLOJI",
                column: "TETKIK_ISTENME_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_SONUC_ONAYLAYAN_PERSONEL_KODU_1",
                schema: "Lbys",
                table: "RADYOLOJI_SONUC",
                column: "ONAYLAYAN_PERSONEL_KODU_1");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_SONUC_ONAYLAYAN_PERSONEL_KODU_2",
                schema: "Lbys",
                table: "RADYOLOJI_SONUC",
                column: "ONAYLAYAN_PERSONEL_KODU_2");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_SONUC_ONAYLAYAN_PERSONEL_KODU_3",
                schema: "Lbys",
                table: "RADYOLOJI_SONUC",
                column: "ONAYLAYAN_PERSONEL_KODU_3");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_SONUC_RADYOLOJI_KODU",
                schema: "Lbys",
                table: "RADYOLOJI_SONUC",
                column: "RADYOLOJI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_SONUC_RADYOLOJI_RAPOR_FORMATI",
                schema: "Lbys",
                table: "RADYOLOJI_SONUC",
                column: "RADYOLOJI_RAPOR_FORMATI");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_SONUC_RAPOR_TIPI",
                schema: "Lbys",
                table: "RADYOLOJI_SONUC",
                column: "RAPOR_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_RADYOLOJI_SONUC_RAPOR_YAZAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "RADYOLOJI_SONUC",
                column: "RAPOR_YAZAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_BIRIM_KODU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_CIHAZ_KODU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_CINSIYET",
                schema: "Lbys",
                table: "RANDEVU",
                column: "CINSIYET");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_HASTA_KODU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_HEKIM_KODU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_IPTAL_EDEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "IPTAL_EDEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_RANDEVU_ALT_TURU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "RANDEVU_ALT_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_RANDEVU_GELME_DURUMU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "RANDEVU_GELME_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_RANDEVU_RANDEVU_TURU",
                schema: "Lbys",
                table: "RANDEVU",
                column: "RANDEVU_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "RECETE",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_HASTA_KODU",
                schema: "Lbys",
                table: "RECETE",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_HEKIM_KODU",
                schema: "Lbys",
                table: "RECETE",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_RECETE_ALT_TURU",
                schema: "Lbys",
                table: "RECETE",
                column: "RECETE_ALT_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_RECETE_TURU",
                schema: "Lbys",
                table: "RECETE",
                column: "RECETE_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_ILAC_DOZ_BIRIM",
                schema: "Lbys",
                table: "RECETE_ILAC",
                column: "DOZ_BIRIM");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_ILAC_ILAC_KULLANIM_PERIYODU_BIRIMI",
                schema: "Lbys",
                table: "RECETE_ILAC",
                column: "ILAC_KULLANIM_PERIYODU_BIRIMI");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_ILAC_ILAC_KULLANIM_SEKLI",
                schema: "Lbys",
                table: "RECETE_ILAC",
                column: "ILAC_KULLANIM_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_ILAC_RECETE_KODU",
                schema: "Lbys",
                table: "RECETE_ILAC",
                column: "RECETE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_ILAC_ACIKLAMA_ILAC_ACIKLAMA_TURU",
                schema: "Lbys",
                table: "RECETE_ILAC_ACIKLAMA",
                column: "ILAC_ACIKLAMA_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_ILAC_ACIKLAMA_RECETE_ILAC_KODU",
                schema: "Lbys",
                table: "RECETE_ILAC_ACIKLAMA",
                column: "RECETE_ILAC_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RECETE_ILAC_ACIKLAMA_RECETE_KODU",
                schema: "Lbys",
                table: "RECETE_ILAC_ACIKLAMA",
                column: "RECETE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RISK_SKORLAMA_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "RISK_SKORLAMA",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RISK_SKORLAMA_HASTA_KODU",
                schema: "Lbys",
                table: "RISK_SKORLAMA",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RISK_SKORLAMA_RISK_SKORLAMA_TURU",
                schema: "Lbys",
                table: "RISK_SKORLAMA",
                column: "RISK_SKORLAMA_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_RISK_SKORLAMA_TIBBI_ORDER_DETAY_KODU",
                schema: "Lbys",
                table: "RISK_SKORLAMA",
                column: "TIBBI_ORDER_DETAY_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RISK_SKORLAMA_DETAY_RISK_SKORLAMA_ALT_TURU",
                schema: "Lbys",
                table: "RISK_SKORLAMA_DETAY",
                column: "RISK_SKORLAMA_ALT_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_RISK_SKORLAMA_DETAY_RISK_SKORLAMA_KODU",
                schema: "Lbys",
                table: "RISK_SKORLAMA_DETAY",
                column: "RISK_SKORLAMA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_CIKIS_CIKIS_YAPILAN_BIRIM_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_CIKIS",
                column: "CIKIS_YAPILAN_BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_CIKIS_DEPO_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_CIKIS",
                column: "DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_CIKIS_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_CIKIS",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_CIKIS_HASTA_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_CIKIS",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_CIKIS_STERILIZASYON_SET_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_CIKIS",
                column: "STERILIZASYON_SET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_CIKIS_TESLIM_ALAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_CIKIS",
                column: "TESLIM_ALAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_CIKIS_TESLIM_EDEN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_CIKIS",
                column: "TESLIM_EDEN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_GIRIS_DEPO_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_GIRIS",
                column: "DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_GIRIS_STOK_KART_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_GIRIS",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_GIRIS_TESLIM_ALAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_GIRIS",
                column: "TESLIM_ALAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_GIRIS_TESLIM_EDEN_BIRIM_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_GIRIS",
                column: "TESLIM_EDEN_BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_GIRIS_TESLIM_EDEN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_GIRIS",
                column: "TESLIM_EDEN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_PAKET_STERILIZASYON_PAKET_GRUBU",
                schema: "Lbys",
                table: "STERILIZASYON_PAKET",
                column: "STERILIZASYON_PAKET_GRUBU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_PAKET_STERILIZASYON_YONTEMI",
                schema: "Lbys",
                table: "STERILIZASYON_PAKET",
                column: "STERILIZASYON_YONTEMI");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_PAKET_DETAY_OLCU_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_PAKET_DETAY",
                column: "OLCU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_PAKET_DETAY_STERILIZASYON_PAKET_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_PAKET_DETAY",
                column: "STERILIZASYON_PAKET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_PAKET_DETAY_STOK_KART_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_PAKET_DETAY",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_BARKOD_BASAN_KULLANICI_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET",
                column: "BARKOD_BASAN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_CIHAZ_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_DEPO_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET",
                column: "DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_PAKETLEYEN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET",
                column: "PAKETLEYEN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_SET_IADE_ALAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET",
                column: "SET_IADE_ALAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_SET_IADE_EDEN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET",
                column: "SET_IADE_EDEN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_STERILIZASYON_PAKET_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET",
                column: "STERILIZASYON_PAKET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_STERILIZASYON_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET",
                column: "STERILIZASYON_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_DETAY_STERILIZASYON_SET_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET_DETAY",
                column: "STERILIZASYON_SET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_SET_DETAY_STOK_KART_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_SET_DETAY",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_STOK_DURUM_DEPO_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_STOK_DURUM",
                column: "DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_STOK_DURUM_STOK_KART_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_STOK_DURUM",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_YIKAMA_DEPO_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_YIKAMA",
                column: "DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_YIKAMA_STERILIZASYON_YIKAMA_TURU",
                schema: "Lbys",
                table: "STERILIZASYON_YIKAMA",
                column: "STERILIZASYON_YIKAMA_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_YIKAMA_STOK_KART_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_YIKAMA",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STERILIZASYON_YIKAMA_YIKAMA_YAPAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STERILIZASYON_YIKAMA",
                column: "YIKAMA_YAPAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_DURUM_DEPO_KODU",
                schema: "Lbys",
                table: "STOK_DURUM",
                column: "DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_DURUM_OLCU_KODU",
                schema: "Lbys",
                table: "STOK_DURUM",
                column: "OLCU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_DURUM_STOK_KART_KODU",
                schema: "Lbys",
                table: "STOK_DURUM",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_EHU_TAKIP_EHU_RET_NEDENI",
                schema: "Lbys",
                table: "STOK_EHU_TAKIP",
                column: "EHU_RET_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_EHU_TAKIP_EHU_RET_PERSONEL_KODU",
                schema: "Lbys",
                table: "STOK_EHU_TAKIP",
                column: "EHU_RET_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_EHU_TAKIP_ONAYLAYAN_HEKIM_KODU",
                schema: "Lbys",
                table: "STOK_EHU_TAKIP",
                column: "ONAYLAYAN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_EHU_TAKIP_STOK_ISTEK_HAREKET_KODU",
                schema: "Lbys",
                table: "STOK_EHU_TAKIP",
                column: "STOK_ISTEK_HAREKET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_EHU_TAKIP_STOK_ISTEK_KODU",
                schema: "Lbys",
                table: "STOK_EHU_TAKIP",
                column: "STOK_ISTEK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_EHU_TAKIP_STOK_KART_KODU",
                schema: "Lbys",
                table: "STOK_EHU_TAKIP",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_BAGLI_STOK_FIS_KODU",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "BAGLI_STOK_FIS_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_BUTCE_TURU",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "BUTCE_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_DEPO_KODU",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_FIRMA_KODU",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "FIRMA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_HAREKET_SEKLI",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "HAREKET_SEKLI");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_HASTA_KODU",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_IHALE_TURU",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "IHALE_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_FIS_ISLEMI_YAPAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STOK_FIS",
                column: "ISLEMI_YAPAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_HAREKET_BAGLI_STOK_HAREKET_KODU",
                schema: "Lbys",
                table: "STOK_HAREKET",
                column: "BAGLI_STOK_HAREKET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_HAREKET_CIHAZ_KODU",
                schema: "Lbys",
                table: "STOK_HAREKET",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_HAREKET_ILK_GIRIS_STOK_HAREKET_KODU",
                schema: "Lbys",
                table: "STOK_HAREKET",
                column: "ILK_GIRIS_STOK_HAREKET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_HAREKET_ISLEMI_YAPAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "STOK_HAREKET",
                column: "ISLEMI_YAPAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_HAREKET_OLCU_KODU",
                schema: "Lbys",
                table: "STOK_HAREKET",
                column: "OLCU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_HAREKET_STOK_FIS_KODU",
                schema: "Lbys",
                table: "STOK_HAREKET",
                column: "STOK_FIS_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_HAREKET_STOK_ISTEK_HAREKET_KODU",
                schema: "Lbys",
                table: "STOK_HAREKET",
                column: "STOK_ISTEK_HAREKET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_HAREKET_STOK_KART_KODU",
                schema: "Lbys",
                table: "STOK_HAREKET",
                column: "STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_AMELIYAT_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK",
                column: "AMELIYAT_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HASTA_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HEKIM_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_ISTEK_DEPO_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK",
                column: "ISTEK_DEPO_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_STOK_ISTEK_DURUMU",
                schema: "Lbys",
                table: "STOK_ISTEK",
                column: "STOK_ISTEK_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HAREKET_ISTENEN_ILAC_JENERIK_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK_HAREKET",
                column: "ISTENEN_ILAC_JENERIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HAREKET_ISTENEN_STOK_KART_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK_HAREKET",
                column: "ISTENEN_STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HAREKET_STOK_ISTEK_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK_HAREKET",
                column: "STOK_ISTEK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HAREKET_STOK_ISTEK_RET_KULLANICI_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK_HAREKET",
                column: "STOK_ISTEK_RET_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HAREKET_STOK_ISTEK_RET_NEDENI",
                schema: "Lbys",
                table: "STOK_ISTEK_HAREKET",
                column: "STOK_ISTEK_RET_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_HAREKET_VERILEN_STOK_KART_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK_HAREKET",
                column: "VERILEN_STOK_KART_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_UYGULAMA_IPTAL_EDEN_HEMSIRE_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK_UYGULAMA",
                column: "IPTAL_EDEN_HEMSIRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_UYGULAMA_ISTEK_IPTAL_NEDENI",
                schema: "Lbys",
                table: "STOK_ISTEK_UYGULAMA",
                column: "ISTEK_IPTAL_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_UYGULAMA_STOK_ISTEK_HAREKET_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK_UYGULAMA",
                column: "STOK_ISTEK_HAREKET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_ISTEK_UYGULAMA_UYGULAYAN_HEMSIRE_KODU",
                schema: "Lbys",
                table: "STOK_ISTEK_UYGULAMA",
                column: "UYGULAYAN_HEMSIRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_KART_MALZEME_TIPI",
                schema: "Lbys",
                table: "STOK_KART",
                column: "MALZEME_TIPI");

            migrationBuilder.CreateIndex(
                name: "IX_STOK_KART_RECETE_TURU",
                schema: "Lbys",
                table: "STOK_KART",
                column: "RECETE_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_PAKET_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "SYS_PAKET",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_PAKET_HASTA_KODU",
                schema: "Lbys",
                table: "SYS_PAKET",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_HIZMET_KODU",
                schema: "Lbys",
                table: "TETKIK",
                column: "HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_CIHAZ_ESLESME_CIHAZ_KODU",
                schema: "Lbys",
                table: "TETKIK_CIHAZ_ESLESME",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_CIHAZ_ESLESME_TETKIK_KODU",
                schema: "Lbys",
                table: "TETKIK_CIHAZ_ESLESME",
                column: "TETKIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_CIHAZ_ESLESME_TETKIK_PARAMETRE_KODU",
                schema: "Lbys",
                table: "TETKIK_CIHAZ_ESLESME",
                column: "TETKIK_PARAMETRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_NUMUNE_BIRIM_KODU",
                schema: "Lbys",
                table: "TETKIK_NUMUNE",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_NUMUNE_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "TETKIK_NUMUNE",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_NUMUNE_HASTA_KODU",
                schema: "Lbys",
                table: "TETKIK_NUMUNE",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_NUMUNE_KABUL_EDEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "TETKIK_NUMUNE",
                column: "KABUL_EDEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_NUMUNE_NUMUNE_ALAN_KULLANICI_KODU",
                schema: "Lbys",
                table: "TETKIK_NUMUNE",
                column: "NUMUNE_ALAN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_NUMUNE_NUMUNE_RET_NEDENI",
                schema: "Lbys",
                table: "TETKIK_NUMUNE",
                column: "NUMUNE_RET_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_NUMUNE_NUMUNE_TURU",
                schema: "Lbys",
                table: "TETKIK_NUMUNE",
                column: "NUMUNE_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_NUMUNE_RET_EDEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "TETKIK_NUMUNE",
                column: "RET_EDEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_PARAMETRE_CIHAZ_KODU",
                schema: "Lbys",
                table: "TETKIK_PARAMETRE",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_PARAMETRE_TETKIK_KODU",
                schema: "Lbys",
                table: "TETKIK_PARAMETRE",
                column: "TETKIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_REFERANS_ARALIK_CIHAZ_KODU",
                schema: "Lbys",
                table: "TETKIK_REFERANS_ARALIK",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_REFERANS_ARALIK_TETKIK_CINSIYET",
                schema: "Lbys",
                table: "TETKIK_REFERANS_ARALIK",
                column: "TETKIK_CINSIYET");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_REFERANS_ARALIK_TETKIK_KODU",
                schema: "Lbys",
                table: "TETKIK_REFERANS_ARALIK",
                column: "TETKIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_REFERANS_ARALIK_TETKIK_PARAMETRE_KODU",
                schema: "Lbys",
                table: "TETKIK_REFERANS_ARALIK",
                column: "TETKIK_PARAMETRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_CIHAZ_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_HASTA_HIZMET_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "HASTA_HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_NUMUNE_RET_NEDENI",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "NUMUNE_RET_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_ONAYLAYAN_HEKIM_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "ONAYLAYAN_HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_ONAYLAYAN_TEKNISYEN_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "ONAYLAYAN_TEKNISYEN_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_RAPOR_YAZAN_PERSONEL_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "RAPOR_YAZAN_PERSONEL_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_RET_EDEN_KULLANICI_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "RET_EDEN_KULLANICI_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_TETKIK_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "TETKIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_TETKIK_NUMUNE_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "TETKIK_NUMUNE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_TETKIK_PARAMETRE_KODU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "TETKIK_PARAMETRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TETKIK_SONUC_TETKIK_SONUCU_DURUMU",
                schema: "Lbys",
                table: "TETKIK_SONUC",
                column: "TETKIK_SONUCU_DURUMU");

            migrationBuilder.CreateIndex(
                name: "IX_TIBBI_ORDER_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "TIBBI_ORDER",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TIBBI_ORDER_HASTA_KODU",
                schema: "Lbys",
                table: "TIBBI_ORDER",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TIBBI_ORDER_HEKIM_KODU",
                schema: "Lbys",
                table: "TIBBI_ORDER",
                column: "HEKIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TIBBI_ORDER_TIBBI_ORDER_TURU",
                schema: "Lbys",
                table: "TIBBI_ORDER",
                column: "TIBBI_ORDER_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_TIBBI_ORDER_DETAY_IPTAL_EDEN_HEMSIRE_KODU",
                schema: "Lbys",
                table: "TIBBI_ORDER_DETAY",
                column: "IPTAL_EDEN_HEMSIRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TIBBI_ORDER_DETAY_TIBBI_ORDER_IPTAL_NEDENI",
                schema: "Lbys",
                table: "TIBBI_ORDER_DETAY",
                column: "TIBBI_ORDER_IPTAL_NEDENI");

            migrationBuilder.CreateIndex(
                name: "IX_TIBBI_ORDER_DETAY_TIBBI_ORDER_KODU",
                schema: "Lbys",
                table: "TIBBI_ORDER_DETAY",
                column: "TIBBI_ORDER_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_TIBBI_ORDER_DETAY_UYGULAYAN_HEMSIRE_KODU",
                schema: "Lbys",
                table: "TIBBI_ORDER_DETAY",
                column: "UYGULAYAN_HEMSIRE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VEZNE_FIRMA_KODU",
                schema: "Lbys",
                table: "VEZNE",
                column: "FIRMA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_VEZNE_HASTA_BASVURU_KODU",
                schema: "Lbys",
                table: "VEZNE",
                column: "HASTA_BASVURU_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_VEZNE_HASTA_KODU",
                schema: "Lbys",
                table: "VEZNE",
                column: "HASTA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_VEZNE_TAHSIL_TURU",
                schema: "Lbys",
                table: "VEZNE",
                column: "TAHSIL_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_VEZNE_VEZNE_BIRIM_KODU",
                schema: "Lbys",
                table: "VEZNE",
                column: "VEZNE_BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_VEZNE_DETAY_HASTA_HIZMET_KODU",
                schema: "Lbys",
                table: "VEZNE_DETAY",
                column: "HASTA_HIZMET_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_VEZNE_DETAY_HASTA_MALZEME_KODU",
                schema: "Lbys",
                table: "VEZNE_DETAY",
                column: "HASTA_MALZEME_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_VEZNE_DETAY_VEZNE_KODU",
                schema: "Lbys",
                table: "VEZNE_DETAY",
                column: "VEZNE_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_YATAK_ODA_KODU",
                schema: "Lbys",
                table: "YATAK",
                column: "ODA_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_YATAK_VENTILATOR_CIHAZ_KODU",
                schema: "Lbys",
                table: "YATAK",
                column: "VENTILATOR_CIHAZ_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_YATAK_YATAK_TURU",
                schema: "Lbys",
                table: "YATAK",
                column: "YATAK_TURU");

            migrationBuilder.CreateIndex(
                name: "IX_YATAK_YOGUN_BAKIM_YATAK_SEVIYESI",
                schema: "Lbys",
                table: "YATAK",
                column: "YOGUN_BAKIM_YATAK_SEVIYESI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AMELIYAT_EKIP",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "ANLIK_YATAN_HASTA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "ANTIBIYOTIK_SONUC",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "ASI_BILGISI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "AuditTrails",
                schema: "Auditing");

            migrationBuilder.DropTable(
                name: "BASVURU_TANI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "BASVURU_YEMEK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "BEBEK_COCUK_IZLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "BILDIRIMI_ZORUNLU",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "COCUK_DIYABET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DIS_TAAHHUT_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DISPROTEZ_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DIYABET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DOGUM_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DOKTOR_MESAJI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "EK_ODEME_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "EVDE_SAGLIK_IZLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "GEBE_IZLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "GETAT",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "GRUP_UYELIK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_ADLI_RAPOR",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_ARSIV_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_BORC",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_DIS",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_EPIKRIZ",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_FOTOGRAF",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_GIZLILIK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_ILETISIM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_NOTLARI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_OLUM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_SEANS",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_SEVK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_TIBBI_BILGI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_UYARI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_VENTILATOR",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_VITAL_FIZIKI_BULGU",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_YATAK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HEMOGLOBINOPATI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HEMSIRE_BAKIM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "ILAC_UYUM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "INTIHAR_IZLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KADIN_IZLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KAN_CIKIS",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KAN_URUN_IMHA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KLINIK_SEYIR",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KONSULTASYON",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KUDUZ_IZLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KURUL_ASKERI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KURUL_ENGELLI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KURUL_ETKEN_MADDE",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KURUL_HEKIM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KURUL_TESHIS",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "LOHUSA_IZLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "MADDE_BAGIMLILIGI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "NOBETCI_PERSONEL_BILGISI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "OBEZITE_IZLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "OPTIK_RECETE",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "ORTODONTI_ICON_SKOR",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PATOLOJI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_BAKMAKLA_YUKUMLU",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_BANKA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_BORDRO",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_BORDRO_SONDURUM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_EGITIM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_GOREVLENDIRME",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_IZIN",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_IZIN_DURUMU",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_ODUL_CEZA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_OGRENIM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL_YANDAL",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RADYOLOJI_SONUC",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RECETE_ILAC_ACIKLAMA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RISK_SKORLAMA_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SILINEN_KAYITLAR",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STERILIZASYON_CIKIS",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STERILIZASYON_GIRIS",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STERILIZASYON_PAKET_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STERILIZASYON_SET_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STERILIZASYON_STOK_DURUM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STERILIZASYON_YIKAMA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STOK_DURUM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STOK_EHU_TAKIP",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STOK_ISTEK_UYGULAMA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "SYS_PAKET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "TETKIK_CIHAZ_ESLESME",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "TETKIK_REFERANS_ARALIK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "VEZNE_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "AMELIYAT_ISLEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "BAKTERI_SONUC",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RANDEVU",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DOGUM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "EK_ODEME",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KULLANICI_GRUP",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_ARSIV",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DISPROTEZ",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DIS_TAAHHUT",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "YATAK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KAN_TALEP_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KAN_STOK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KURUL_RAPOR",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RADYOLOJI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RECETE_ILAC",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RISK_SKORLAMA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STERILIZASYON_SET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "HASTA_MALZEME",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "VEZNE",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "TETKIK_SONUC",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "EK_ODEME_DONEM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "ODA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KAN_TALEP",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KAN_BAGISCI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KAN_URUN",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KURUL",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "RECETE",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "TIBBI_ORDER_DETAY",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STERILIZASYON_PAKET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "MEDULA_TAKIP",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STOK_HAREKET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_HIZMET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "TETKIK_NUMUNE",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "TETKIK_PARAMETRE",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "TIBBI_ORDER",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STOK_FIS",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STOK_ISTEK_HAREKET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "FATURA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "TETKIK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "FIRMA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KULLANICI",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STOK_ISTEK",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "STOK_KART",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "ICMAL",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HIZMET",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "AMELIYAT",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "DEPO",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "CIHAZ",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA_BASVURU",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "BINA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "HASTA",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "PERSONEL",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "BIRIM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "KURUM",
                schema: "Lbys");

            migrationBuilder.DropTable(
                name: "REFERANS_KODLAR",
                schema: "Lbys");
        }
    }
}
