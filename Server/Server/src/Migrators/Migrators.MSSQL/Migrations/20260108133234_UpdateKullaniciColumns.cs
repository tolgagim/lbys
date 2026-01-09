using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKullaniciColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BIRIM_BIRIM_UST_BIRIM_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropForeignKey(
                name: "FK_BIRIM_KURUM_KURUM_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropForeignKey(
                name: "FK_HASTA_REFERANS_KODLAR_MEDENI_HAL",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropForeignKey(
                name: "FK_HASTA_REFERANS_KODLAR_SOSYAL_GUVENCE",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropForeignKey(
                name: "FK_HASTA_BASVURU_PERSONEL_DOKTOR_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropForeignKey(
                name: "FK_HASTA_BASVURU_REFERANS_KODLAR_BASVURU_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropForeignKey(
                name: "FK_HASTA_BASVURU_REFERANS_KODLAR_BASVURU_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropForeignKey(
                name: "FK_KURUM_REFERANS_KODLAR_KURUM_TURU",
                schema: "Lbys",
                table: "KURUM");

            migrationBuilder.DropForeignKey(
                name: "FK_PERSONEL_BIRIM_BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropForeignKey(
                name: "FK_PERSONEL_REFERANS_KODLAR_UZMANLIK_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropIndex(
                name: "IX_PERSONEL_BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropIndex(
                name: "IX_PERSONEL_UZMANLIK_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropIndex(
                name: "IX_KURUM_KURUM_TURU",
                schema: "Lbys",
                table: "KURUM");

            migrationBuilder.DropIndex(
                name: "IX_HASTA_BASVURU_BASVURU_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropIndex(
                name: "IX_HASTA_BASVURU_BASVURU_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropIndex(
                name: "IX_HASTA_MEDENI_HAL",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropIndex(
                name: "IX_BIRIM_KURUM_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "TETKIK_PARAMETRE");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "TETKIK");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "SOYAD",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "UZMANLIK_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "KURUM_TURU",
                schema: "Lbys",
                table: "KURUM");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "KULLANICI");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "HIZMET");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "BASVURU_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "BASVURU_TARIHI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "BASVURU_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "MEDENI_HAL",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "SOYAD",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "TC_KIMLIK_NO",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "DEPO");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "CIHAZ");

            migrationBuilder.DropColumn(
                name: "AKTIF",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropColumn(
                name: "KURUM_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.RenameColumn(
                name: "UNVAN",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "UNVAN_KODU");

            migrationBuilder.RenameColumn(
                name: "TELEFON",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "ULKE_KODU");

            migrationBuilder.RenameColumn(
                name: "TC_KIMLIK_NO",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "TC_KIMLIK_NUMARASI");

            migrationBuilder.RenameColumn(
                name: "ISE_BASLAMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "TERFI_TARIHI");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "TESCIL_NUMARASI");

            migrationBuilder.RenameColumn(
                name: "DIPLOMA_TESCIL_NO",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "SOYADI");

            migrationBuilder.RenameColumn(
                name: "DIPLOMA_NO",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "PERSONEL_SICIL_NUMARASI");

            migrationBuilder.RenameColumn(
                name: "VERGI_NO",
                schema: "Lbys",
                table: "KURUM",
                newName: "YATAN_BUTCE_KODU");

            migrationBuilder.RenameColumn(
                name: "VERGI_DAIRESI",
                schema: "Lbys",
                table: "KURUM",
                newName: "SKRS_KURUM_KODU");

            migrationBuilder.RenameColumn(
                name: "TELEFON",
                schema: "Lbys",
                table: "KURUM",
                newName: "KURUM_ADRESI");

            migrationBuilder.RenameColumn(
                name: "IL_KODU",
                schema: "Lbys",
                table: "KURUM",
                newName: "HASTA_KURUM_TURU");

            migrationBuilder.RenameColumn(
                name: "ILCE_KODU",
                schema: "Lbys",
                table: "KURUM",
                newName: "GUNUBIRLIK_BUTCE_KODU");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                schema: "Lbys",
                table: "KURUM",
                newName: "DEVREDILEN_KURUM");

            migrationBuilder.RenameColumn(
                name: "ADRES",
                schema: "Lbys",
                table: "KURUM",
                newName: "AYAKTAN_BUTCE_KODU");

            migrationBuilder.RenameColumn(
                name: "TANI_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "YATIS_PROTOKOL_NUMARASI");

            migrationBuilder.RenameColumn(
                name: "TAKIP_NO",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "YATIS_BILGISI");

            migrationBuilder.RenameColumn(
                name: "SONUC_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "YABANCI_HASTA_TURU");

            migrationBuilder.RenameColumn(
                name: "SIKAYET",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "VAKA_TURU");

            migrationBuilder.RenameColumn(
                name: "SEVK_EDEN_KURUM",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "TRIAJ_KODU");

            migrationBuilder.RenameColumn(
                name: "PROVIZYON_TIPI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "TAMAMLAYICI_KURUM_KODU");

            migrationBuilder.RenameColumn(
                name: "DOKTOR_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "HEKIM_KODU");

            migrationBuilder.RenameColumn(
                name: "CIKIS_TARIHI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "SEVK_ZAMANI");

            migrationBuilder.RenameIndex(
                name: "IX_HASTA_BASVURU_DOKTOR_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "IX_HASTA_BASVURU_HEKIM_KODU");

            migrationBuilder.RenameColumn(
                name: "TELEFON",
                schema: "Lbys",
                table: "HASTA",
                newName: "YUPASS_NUMARASI");

            migrationBuilder.RenameColumn(
                name: "SOSYAL_GUVENCE",
                schema: "Lbys",
                table: "HASTA",
                newName: "MEDENI_HALI");

            migrationBuilder.RenameColumn(
                name: "SIGORTA_NO",
                schema: "Lbys",
                table: "HASTA",
                newName: "TC_KIMLIK_NUMARASI");

            migrationBuilder.RenameColumn(
                name: "PROTOKOL_NO",
                schema: "Lbys",
                table: "HASTA",
                newName: "SOYADI");

            migrationBuilder.RenameColumn(
                name: "IL_KODU",
                schema: "Lbys",
                table: "HASTA",
                newName: "SON_KURUM_KODU");

            migrationBuilder.RenameColumn(
                name: "ILCE_KODU",
                schema: "Lbys",
                table: "HASTA",
                newName: "PASAPORT_NUMARASI");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                schema: "Lbys",
                table: "HASTA",
                newName: "OLUM_YERI");

            migrationBuilder.RenameColumn(
                name: "EGITIM_DURUMU",
                schema: "Lbys",
                table: "HASTA",
                newName: "OGRENIM_DURUMU");

            migrationBuilder.RenameColumn(
                name: "CEP_TELEFON",
                schema: "Lbys",
                table: "HASTA",
                newName: "KIMLIKSIZ_HASTA_BILGISI");

            migrationBuilder.RenameColumn(
                name: "ANA_ADI",
                schema: "Lbys",
                table: "HASTA",
                newName: "HASTA_TIPI");

            migrationBuilder.RenameColumn(
                name: "ADRES",
                schema: "Lbys",
                table: "HASTA",
                newName: "ENGELLILIK_DURUMU");

            migrationBuilder.RenameIndex(
                name: "IX_HASTA_SOSYAL_GUVENCE",
                schema: "Lbys",
                table: "HASTA",
                newName: "IX_HASTA_MEDENI_HALI");

            migrationBuilder.RenameColumn(
                name: "UST_BIRIM_KODU",
                schema: "Lbys",
                table: "BIRIM",
                newName: "BINA_KODU");

            migrationBuilder.RenameIndex(
                name: "IX_BIRIM_UST_BIRIM_KODU",
                schema: "Lbys",
                table: "BIRIM",
                newName: "IX_BIRIM_BINA_KODU");

            migrationBuilder.AddColumn<string>(
                name: "IPTAL_DURUMU",
                schema: "Lbys",
                table: "TETKIK_PARAMETRE",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPTAL_DURUMU",
                schema: "Lbys",
                table: "TETKIK",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ACIK_ADRES",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ADRES_KODU_SEVIYESI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ADRES_TIPI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AKADEMIK_UNVAN",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ANNE_ADI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ASALET_ALMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ASKERLIK_DURUMU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BABA_ADI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CALISMA_DURUMU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CALISTIGI_BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP_TELEFONU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DEVLET_HIZMET_YUKUMLULUK_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DIPLOMA_NUMARASI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DOGUM_YERI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMEKLI_SICIL_NUMARASI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EMEKLI_TERFI_TARIHI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ENGELLILIK_DURUMU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EPOSTA_ADRESI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EV_TELEFONU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FOTOGRAF_BILGISI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FOTOGRAF_DOSYA_YOLU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HEKIM_MEDULA_SIFRESI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ILCE_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ILK_ISE_BASLAMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IL_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMZA_UNVAN_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISTEN_AYRILMA_ACIKLAMASI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISTEN_AYRILMA_NEDENI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ISTEN_AYRILMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IS_DURUMU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KADROLU_GOREV_YERI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KADRO_UNVAN_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KAN_GRUBU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KLINIK_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MEDULA_BRANS_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MEMURIYETE_BASLAMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MEMURIYET_TIPI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OGRENIM_DURUMU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ONCEKI_SOYADI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PERSONEL_GOREV_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SAGLIK_TESISINE_BASLAMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "KURUM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AD",
                schema: "Lbys",
                table: "KULLANICI",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "KULLANICI",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PAROLA",
                schema: "Lbys",
                table: "KULLANICI",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PAROLA_SIFRELEME_TURU",
                schema: "Lbys",
                table: "KULLANICI",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SOYADI",
                schema: "Lbys",
                table: "KULLANICI",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TC_KIMLIK_NUMARASI",
                schema: "Lbys",
                table: "KULLANICI",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "HIZMET",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ADLI_VAKA_GELIS_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AMBULANS_PLAKA_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AMBULANS_TAKIP_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ARAC_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ASISTAN_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BAGLI_OLDUGU_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BASVURU_DURUMU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BASVURU_PROTOKOL_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CIKIS_VEREN_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CIKIS_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DEFTER_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DIYABET_EGITIMI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DIYABET_KOMPLIKASYONLARI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GEBLIZ_BILDIRIM_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GELDIGI_ULKE_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GENCLIK_SAGLIGI_ISLEMLERI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GUNLUK_SIRA_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HASTA_KABUL_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HAYATI_TEHLIKE_DURUMU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HEKIM_BASVURU_NOTU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HIZMET_SUNUCU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KABUL_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KAYIT_YERI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KURUM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MUAYENE_BASLAMA_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MUAYENE_BITIS_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MUAYENE_ONCELIK_SIRASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MUAYENE_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLAY_AFET_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ONLINE_PROTOKOL_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SAGLIK_TURIZMI_ULKE_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEVK_TANISI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SOSYAL_GUVENCE_DURUMU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SYS_REFERANS_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SYS_TAKIP_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ANNE_ADI",
                schema: "Lbys",
                table: "HASTA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ANNE_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ANNE_TC_KIMLIK_NUMARASI",
                schema: "Lbys",
                table: "HASTA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BABA_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BABA_TC_KIMLIK_NUMARASI",
                schema: "Lbys",
                table: "HASTA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BEYAN_DOGUM_TARIHI",
                schema: "Lbys",
                table: "HASTA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DOGUM_SIRASI",
                schema: "Lbys",
                table: "HASTA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MUAYENE_ONCELIK_SIRASI",
                schema: "Lbys",
                table: "HASTA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "DEPO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MKYS_KULLANICI_SIFRESI",
                schema: "Lbys",
                table: "DEPO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "CIHAZ",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "BIRIM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KLINIK_KODU",
                schema: "Lbys",
                table: "BIRIM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MEDULA_BRANS_KODU",
                schema: "Lbys",
                table: "BIRIM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MHRS_ADI",
                schema: "Lbys",
                table: "BIRIM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MHRS_KODU",
                schema: "Lbys",
                table: "BIRIM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MKYS_KODU",
                schema: "Lbys",
                table: "BIRIM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YATAK_SAYISI",
                schema: "Lbys",
                table: "BIRIM",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BIRIM_BINA_BINA_KODU",
                schema: "Lbys",
                table: "BIRIM",
                column: "BINA_KODU",
                principalSchema: "Lbys",
                principalTable: "BINA",
                principalColumn: "BINA_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HASTA_REFERANS_KODLAR_MEDENI_HALI",
                schema: "Lbys",
                table: "HASTA",
                column: "MEDENI_HALI",
                principalSchema: "Lbys",
                principalTable: "REFERANS_KODLAR",
                principalColumn: "REFERANS_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HASTA_BASVURU_PERSONEL_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "HEKIM_KODU",
                principalSchema: "Lbys",
                principalTable: "PERSONEL",
                principalColumn: "PERSONEL_KODU",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BIRIM_BINA_BINA_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropForeignKey(
                name: "FK_HASTA_REFERANS_KODLAR_MEDENI_HALI",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropForeignKey(
                name: "FK_HASTA_BASVURU_PERSONEL_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "IPTAL_DURUMU",
                schema: "Lbys",
                table: "TETKIK_PARAMETRE");

            migrationBuilder.DropColumn(
                name: "IPTAL_DURUMU",
                schema: "Lbys",
                table: "TETKIK");

            migrationBuilder.DropColumn(
                name: "ACIK_ADRES",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ADRES_KODU_SEVIYESI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ADRES_TIPI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "AKADEMIK_UNVAN",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ANNE_ADI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ASALET_ALMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ASKERLIK_DURUMU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "BABA_ADI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "CALISMA_DURUMU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "CALISTIGI_BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "CEP_TELEFONU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "DEVLET_HIZMET_YUKUMLULUK_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "DIPLOMA_NUMARASI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "DOGUM_YERI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "EMEKLI_SICIL_NUMARASI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "EMEKLI_TERFI_TARIHI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ENGELLILIK_DURUMU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "EPOSTA_ADRESI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "EV_TELEFONU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "FOTOGRAF_BILGISI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "FOTOGRAF_DOSYA_YOLU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "HEKIM_MEDULA_SIFRESI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ILCE_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ILK_ISE_BASLAMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "IL_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "IMZA_UNVAN_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ISTEN_AYRILMA_ACIKLAMASI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ISTEN_AYRILMA_NEDENI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ISTEN_AYRILMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "IS_DURUMU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "KADROLU_GOREV_YERI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "KADRO_UNVAN_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "KAN_GRUBU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "KLINIK_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "MEDULA_BRANS_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "MEMURIYETE_BASLAMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "MEMURIYET_TIPI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "OGRENIM_DURUMU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "ONCEKI_SOYADI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "PERSONEL_GOREV_KODU",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "SAGLIK_TESISINE_BASLAMA_TARIHI",
                schema: "Lbys",
                table: "PERSONEL");

            migrationBuilder.DropColumn(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "KURUM");

            migrationBuilder.DropColumn(
                name: "AD",
                schema: "Lbys",
                table: "KULLANICI");

            migrationBuilder.DropColumn(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "KULLANICI");

            migrationBuilder.DropColumn(
                name: "PAROLA",
                schema: "Lbys",
                table: "KULLANICI");

            migrationBuilder.DropColumn(
                name: "PAROLA_SIFRELEME_TURU",
                schema: "Lbys",
                table: "KULLANICI");

            migrationBuilder.DropColumn(
                name: "SOYADI",
                schema: "Lbys",
                table: "KULLANICI");

            migrationBuilder.DropColumn(
                name: "TC_KIMLIK_NUMARASI",
                schema: "Lbys",
                table: "KULLANICI");

            migrationBuilder.DropColumn(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "HIZMET");

            migrationBuilder.DropColumn(
                name: "ADLI_VAKA_GELIS_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "AMBULANS_PLAKA_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "AMBULANS_TAKIP_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "ARAC_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "ASISTAN_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "BAGLI_OLDUGU_BASVURU_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "BASVURU_DURUMU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "BASVURU_PROTOKOL_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "CIKIS_VEREN_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "CIKIS_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "DEFTER_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "DIYABET_EGITIMI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "DIYABET_KOMPLIKASYONLARI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "GEBLIZ_BILDIRIM_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "GELDIGI_ULKE_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "GENCLIK_SAGLIGI_ISLEMLERI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "GUNLUK_SIRA_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "HASTA_KABUL_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "HAYATI_TEHLIKE_DURUMU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "HEKIM_BASVURU_NOTU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "HIZMET_SUNUCU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "KABUL_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "KAYIT_YERI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "KURUM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "MUAYENE_BASLAMA_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "MUAYENE_BITIS_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "MUAYENE_ONCELIK_SIRASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "MUAYENE_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "OLAY_AFET_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "ONLINE_PROTOKOL_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "SAGLIK_TURIZMI_ULKE_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "SEVK_TANISI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "SOSYAL_GUVENCE_DURUMU",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "SYS_REFERANS_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "SYS_TAKIP_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU");

            migrationBuilder.DropColumn(
                name: "ANNE_ADI",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "ANNE_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "ANNE_TC_KIMLIK_NUMARASI",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "BABA_HASTA_KODU",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "BABA_TC_KIMLIK_NUMARASI",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "BEYAN_DOGUM_TARIHI",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "DOGUM_SIRASI",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "MUAYENE_ONCELIK_SIRASI",
                schema: "Lbys",
                table: "HASTA");

            migrationBuilder.DropColumn(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "DEPO");

            migrationBuilder.DropColumn(
                name: "MKYS_KULLANICI_SIFRESI",
                schema: "Lbys",
                table: "DEPO");

            migrationBuilder.DropColumn(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "CIHAZ");

            migrationBuilder.DropColumn(
                name: "AKTIFLIK_BILGISI",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropColumn(
                name: "KLINIK_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropColumn(
                name: "MEDULA_BRANS_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropColumn(
                name: "MHRS_ADI",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropColumn(
                name: "MHRS_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropColumn(
                name: "MKYS_KODU",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.DropColumn(
                name: "YATAK_SAYISI",
                schema: "Lbys",
                table: "BIRIM");

            migrationBuilder.RenameColumn(
                name: "UNVAN_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "UNVAN");

            migrationBuilder.RenameColumn(
                name: "ULKE_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "TELEFON");

            migrationBuilder.RenameColumn(
                name: "TESCIL_NUMARASI",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "TERFI_TARIHI",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "ISE_BASLAMA_TARIHI");

            migrationBuilder.RenameColumn(
                name: "TC_KIMLIK_NUMARASI",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "TC_KIMLIK_NO");

            migrationBuilder.RenameColumn(
                name: "SOYADI",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "DIPLOMA_TESCIL_NO");

            migrationBuilder.RenameColumn(
                name: "PERSONEL_SICIL_NUMARASI",
                schema: "Lbys",
                table: "PERSONEL",
                newName: "DIPLOMA_NO");

            migrationBuilder.RenameColumn(
                name: "YATAN_BUTCE_KODU",
                schema: "Lbys",
                table: "KURUM",
                newName: "VERGI_NO");

            migrationBuilder.RenameColumn(
                name: "SKRS_KURUM_KODU",
                schema: "Lbys",
                table: "KURUM",
                newName: "VERGI_DAIRESI");

            migrationBuilder.RenameColumn(
                name: "KURUM_ADRESI",
                schema: "Lbys",
                table: "KURUM",
                newName: "TELEFON");

            migrationBuilder.RenameColumn(
                name: "HASTA_KURUM_TURU",
                schema: "Lbys",
                table: "KURUM",
                newName: "IL_KODU");

            migrationBuilder.RenameColumn(
                name: "GUNUBIRLIK_BUTCE_KODU",
                schema: "Lbys",
                table: "KURUM",
                newName: "ILCE_KODU");

            migrationBuilder.RenameColumn(
                name: "DEVREDILEN_KURUM",
                schema: "Lbys",
                table: "KURUM",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "AYAKTAN_BUTCE_KODU",
                schema: "Lbys",
                table: "KURUM",
                newName: "ADRES");

            migrationBuilder.RenameColumn(
                name: "YATIS_PROTOKOL_NUMARASI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "TANI_KODU");

            migrationBuilder.RenameColumn(
                name: "YATIS_BILGISI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "TAKIP_NO");

            migrationBuilder.RenameColumn(
                name: "YABANCI_HASTA_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "SONUC_KODU");

            migrationBuilder.RenameColumn(
                name: "VAKA_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "SIKAYET");

            migrationBuilder.RenameColumn(
                name: "TRIAJ_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "SEVK_EDEN_KURUM");

            migrationBuilder.RenameColumn(
                name: "TAMAMLAYICI_KURUM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "PROVIZYON_TIPI");

            migrationBuilder.RenameColumn(
                name: "SEVK_ZAMANI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "CIKIS_TARIHI");

            migrationBuilder.RenameColumn(
                name: "HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "DOKTOR_KODU");

            migrationBuilder.RenameIndex(
                name: "IX_HASTA_BASVURU_HEKIM_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                newName: "IX_HASTA_BASVURU_DOKTOR_KODU");

            migrationBuilder.RenameColumn(
                name: "YUPASS_NUMARASI",
                schema: "Lbys",
                table: "HASTA",
                newName: "TELEFON");

            migrationBuilder.RenameColumn(
                name: "TC_KIMLIK_NUMARASI",
                schema: "Lbys",
                table: "HASTA",
                newName: "SIGORTA_NO");

            migrationBuilder.RenameColumn(
                name: "SOYADI",
                schema: "Lbys",
                table: "HASTA",
                newName: "PROTOKOL_NO");

            migrationBuilder.RenameColumn(
                name: "SON_KURUM_KODU",
                schema: "Lbys",
                table: "HASTA",
                newName: "IL_KODU");

            migrationBuilder.RenameColumn(
                name: "PASAPORT_NUMARASI",
                schema: "Lbys",
                table: "HASTA",
                newName: "ILCE_KODU");

            migrationBuilder.RenameColumn(
                name: "OLUM_YERI",
                schema: "Lbys",
                table: "HASTA",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "OGRENIM_DURUMU",
                schema: "Lbys",
                table: "HASTA",
                newName: "EGITIM_DURUMU");

            migrationBuilder.RenameColumn(
                name: "MEDENI_HALI",
                schema: "Lbys",
                table: "HASTA",
                newName: "SOSYAL_GUVENCE");

            migrationBuilder.RenameColumn(
                name: "KIMLIKSIZ_HASTA_BILGISI",
                schema: "Lbys",
                table: "HASTA",
                newName: "CEP_TELEFON");

            migrationBuilder.RenameColumn(
                name: "HASTA_TIPI",
                schema: "Lbys",
                table: "HASTA",
                newName: "ANA_ADI");

            migrationBuilder.RenameColumn(
                name: "ENGELLILIK_DURUMU",
                schema: "Lbys",
                table: "HASTA",
                newName: "ADRES");

            migrationBuilder.RenameIndex(
                name: "IX_HASTA_MEDENI_HALI",
                schema: "Lbys",
                table: "HASTA",
                newName: "IX_HASTA_SOSYAL_GUVENCE");

            migrationBuilder.RenameColumn(
                name: "BINA_KODU",
                schema: "Lbys",
                table: "BIRIM",
                newName: "UST_BIRIM_KODU");

            migrationBuilder.RenameIndex(
                name: "IX_BIRIM_BINA_KODU",
                schema: "Lbys",
                table: "BIRIM",
                newName: "IX_BIRIM_UST_BIRIM_KODU");

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "TETKIK_PARAMETRE",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "TETKIK",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "PERSONEL",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SOYAD",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UZMANLIK_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KURUM_TURU",
                schema: "Lbys",
                table: "KURUM",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "KULLANICI",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "HIZMET",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BASVURU_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BASVURU_TARIHI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BASVURU_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "HASTA",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MEDENI_HAL",
                schema: "Lbys",
                table: "HASTA",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SOYAD",
                schema: "Lbys",
                table: "HASTA",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TC_KIMLIK_NO",
                schema: "Lbys",
                table: "HASTA",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "DEPO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "CIHAZ",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AKTIF",
                schema: "Lbys",
                table: "BIRIM",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KURUM_KODU",
                schema: "Lbys",
                table: "BIRIM",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                column: "BIRIM_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_PERSONEL_UZMANLIK_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                column: "UZMANLIK_KODU");

            migrationBuilder.CreateIndex(
                name: "IX_KURUM_KURUM_TURU",
                schema: "Lbys",
                table: "KURUM",
                column: "KURUM_TURU");

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
                name: "IX_HASTA_MEDENI_HAL",
                schema: "Lbys",
                table: "HASTA",
                column: "MEDENI_HAL");

            migrationBuilder.CreateIndex(
                name: "IX_BIRIM_KURUM_KODU",
                schema: "Lbys",
                table: "BIRIM",
                column: "KURUM_KODU");

            migrationBuilder.AddForeignKey(
                name: "FK_BIRIM_BIRIM_UST_BIRIM_KODU",
                schema: "Lbys",
                table: "BIRIM",
                column: "UST_BIRIM_KODU",
                principalSchema: "Lbys",
                principalTable: "BIRIM",
                principalColumn: "BIRIM_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BIRIM_KURUM_KURUM_KODU",
                schema: "Lbys",
                table: "BIRIM",
                column: "KURUM_KODU",
                principalSchema: "Lbys",
                principalTable: "KURUM",
                principalColumn: "KURUM_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HASTA_REFERANS_KODLAR_MEDENI_HAL",
                schema: "Lbys",
                table: "HASTA",
                column: "MEDENI_HAL",
                principalSchema: "Lbys",
                principalTable: "REFERANS_KODLAR",
                principalColumn: "REFERANS_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HASTA_REFERANS_KODLAR_SOSYAL_GUVENCE",
                schema: "Lbys",
                table: "HASTA",
                column: "SOSYAL_GUVENCE",
                principalSchema: "Lbys",
                principalTable: "REFERANS_KODLAR",
                principalColumn: "REFERANS_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HASTA_BASVURU_PERSONEL_DOKTOR_KODU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "DOKTOR_KODU",
                principalSchema: "Lbys",
                principalTable: "PERSONEL",
                principalColumn: "PERSONEL_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HASTA_BASVURU_REFERANS_KODLAR_BASVURU_SEKLI",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "BASVURU_SEKLI",
                principalSchema: "Lbys",
                principalTable: "REFERANS_KODLAR",
                principalColumn: "REFERANS_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HASTA_BASVURU_REFERANS_KODLAR_BASVURU_TURU",
                schema: "Lbys",
                table: "HASTA_BASVURU",
                column: "BASVURU_TURU",
                principalSchema: "Lbys",
                principalTable: "REFERANS_KODLAR",
                principalColumn: "REFERANS_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KURUM_REFERANS_KODLAR_KURUM_TURU",
                schema: "Lbys",
                table: "KURUM",
                column: "KURUM_TURU",
                principalSchema: "Lbys",
                principalTable: "REFERANS_KODLAR",
                principalColumn: "REFERANS_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PERSONEL_BIRIM_BIRIM_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                column: "BIRIM_KODU",
                principalSchema: "Lbys",
                principalTable: "BIRIM",
                principalColumn: "BIRIM_KODU",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PERSONEL_REFERANS_KODLAR_UZMANLIK_KODU",
                schema: "Lbys",
                table: "PERSONEL",
                column: "UZMANLIK_KODU",
                principalSchema: "Lbys",
                principalTable: "REFERANS_KODLAR",
                principalColumn: "REFERANS_KODU",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
