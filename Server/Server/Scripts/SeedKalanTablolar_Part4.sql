-- =====================================================
-- LBYS Kalan Tablolar Seed Data Script - PART 4
-- KAN, STERILIZASYON, STOK, IZLEM, TETKIK, DIGER
-- =====================================================

USE TESTDATA;
GO

SET NOCOUNT ON;
GO

PRINT '=== KAN, STERILIZASYON VE DIGER TABLOLAR ===';

-- 36. KAN_CIKIS (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KAN_CIKIS WHERE KAN_CIKIS_KODU LIKE 'KCK-SEED-%')
BEGIN
    PRINT 'KAN_CIKIS tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @kanStokKodu NVARCHAR(50);
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;

    WHILE @i <= 30
    BEGIN
        SET @kanStokKodu = 'KST-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO KAN_CIKIS (
            KAN_CIKIS_KODU, KAN_STOK_KODU, HASTA_KODU, HASTA_BASVURU_KODU, CIKIS_ZAMANI,
            CIKIS_NEDENI, CIKIS_MIKTARI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'KCK-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @kanStokKodu,
            @hastaKodu,
            @basvuruKodu,
            DATEADD(DAY, -@i, GETDATE()),
            CASE @i % 3 WHEN 0 THEN 'TRANSFUZYON' WHEN 1 THEN 'IMHA' ELSE 'TRANSFER' END,
            CAST(400 + (@i * 10) AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'KAN_CIKIS: 30 kayit eklendi.';
END;
GO

-- 37. KAN_URUN_IMHA (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KAN_URUN_IMHA WHERE KAN_URUN_IMHA_KODU LIKE 'KUI-SEED-%')
BEGIN
    PRINT 'KAN_URUN_IMHA tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @kanStokKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        SET @kanStokKodu = 'KST-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO KAN_URUN_IMHA (
            KAN_URUN_IMHA_KODU, KAN_STOK_KODU, IMHA_ZAMANI, IMHA_NEDENI, IMHA_EDEN_PERSONEL_KODU,
            IMHA_ACIKLAMA, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'KUI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @kanStokKodu,
            DATEADD(DAY, -@i, GETDATE()),
            CASE @i % 4 WHEN 0 THEN 'SON_KULLANMA_TARIHI_GECMIS' WHEN 1 THEN 'KONTAMINE' WHEN 2 THEN 'UYUMSUZ' ELSE 'DIGER' END,
            @personelKodu,
            'İmha açıklaması ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'KAN_URUN_IMHA: 30 kayit eklendi.';
END;
GO

-- 38-43. STERILIZASYON TABLOLARI
-- 38. STERILIZASYON_SET (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STERILIZASYON_SET WHERE STERILIZASYON_SET_KODU LIKE 'SST-SEED-%')
BEGIN
    PRINT 'STERILIZASYON_SET tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @birimKodu NVARCHAR(50);

    SELECT TOP 1 @birimKodu = BIRIM_KODU FROM BIRIM;

    WHILE @i <= 30
    BEGIN
        INSERT INTO STERILIZASYON_SET (
            STERILIZASYON_SET_KODU, SET_ADI, SET_TURU, BIRIM_KODU, AKTIF_DURUMU,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SST-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            CASE @i % 5 WHEN 0 THEN 'Cerrahi Set' WHEN 1 THEN 'Ortopedi Set' WHEN 2 THEN 'Göz Set' WHEN 3 THEN 'KBB Set' ELSE 'Genel Set' END + ' ' + CAST(@i AS NVARCHAR(5)),
            CASE @i % 3 WHEN 0 THEN 'CERRAHI' WHEN 1 THEN 'PANSUMAN' ELSE 'OZEL' END,
            @birimKodu,
            CASE @i % 5 WHEN 0 THEN 'PASIF' ELSE 'AKTIF' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STERILIZASYON_SET: 30 kayit eklendi.';
END;
GO

-- 39. STERILIZASYON_SET_DETAY (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STERILIZASYON_SET_DETAY WHERE STERILIZASYON_SET_DETAY_KODU LIKE 'SSD-SEED-%')
BEGIN
    PRINT 'STERILIZASYON_SET_DETAY tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @setKodu NVARCHAR(50);
    DECLARE @stokKartKodu NVARCHAR(50);

    SELECT TOP 1 @stokKartKodu = STOK_KART_KODU FROM STOK_KART;

    WHILE @i <= 30
    BEGIN
        SET @setKodu = 'SST-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM STERILIZASYON_SET WHERE STERILIZASYON_SET_KODU = @setKodu)
        BEGIN
            INSERT INTO STERILIZASYON_SET_DETAY (
                STERILIZASYON_SET_DETAY_KODU, STERILIZASYON_SET_KODU, STOK_KART_KODU, MIKTAR,
                EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'SSD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @setKodu,
                @stokKartKodu,
                CAST(1 + (@i % 10) AS NVARCHAR(5)),
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'STERILIZASYON_SET_DETAY: 30 kayit eklendi.';
END;
GO

-- 40. STERILIZASYON_GIRIS (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STERILIZASYON_GIRIS WHERE STERILIZASYON_GIRIS_KODU LIKE 'SGR-SEED-%')
BEGIN
    PRINT 'STERILIZASYON_GIRIS tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @setKodu NVARCHAR(50);
    DECLARE @birimKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @birimKodu = BIRIM_KODU FROM BIRIM;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        SET @setKodu = 'SST-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO STERILIZASYON_GIRIS (
            STERILIZASYON_GIRIS_KODU, STERILIZASYON_SET_KODU, GELEN_BIRIM_KODU, GIRIS_ZAMANI,
            TESLIM_ALAN_PERSONEL_KODU, GIRIS_NOTU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SGR-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @setKodu,
            @birimKodu,
            DATEADD(DAY, -@i, DATEADD(HOUR, 8, GETDATE())),
            @personelKodu,
            'Sterilizasyon giriş notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STERILIZASYON_GIRIS: 30 kayit eklendi.';
END;
GO

-- 41. STERILIZASYON_YIKAMA (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STERILIZASYON_YIKAMA WHERE STERILIZASYON_YIKAMA_KODU LIKE 'SYK-SEED-%')
BEGIN
    PRINT 'STERILIZASYON_YIKAMA tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @girisKodu NVARCHAR(50);
    DECLARE @cihazKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @cihazKodu = CIHAZ_KODU FROM CIHAZ;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        SET @girisKodu = 'SGR-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO STERILIZASYON_YIKAMA (
            STERILIZASYON_YIKAMA_KODU, STERILIZASYON_GIRIS_KODU, YIKAMA_CIHAZ_KODU, YIKAMA_BASLAMA_ZAMANI,
            YIKAMA_BITIS_ZAMANI, YIKAMA_PERSONEL_KODU, YIKAMA_DURUMU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SYK-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @girisKodu,
            @cihazKodu,
            DATEADD(DAY, -@i, DATEADD(HOUR, 9, GETDATE())),
            DATEADD(DAY, -@i, DATEADD(HOUR, 10, GETDATE())),
            @personelKodu,
            CASE @i % 3 WHEN 0 THEN 'TAMAMLANDI' WHEN 1 THEN 'DEVAM_EDIYOR' ELSE 'BEKLEMEDE' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STERILIZASYON_YIKAMA: 30 kayit eklendi.';
END;
GO

-- 42. STERILIZASYON_CIKIS (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STERILIZASYON_CIKIS WHERE STERILIZASYON_CIKIS_KODU LIKE 'SCK-SEED-%')
BEGIN
    PRINT 'STERILIZASYON_CIKIS tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @girisKodu NVARCHAR(50);
    DECLARE @birimKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @birimKodu = BIRIM_KODU FROM BIRIM;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        SET @girisKodu = 'SGR-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO STERILIZASYON_CIKIS (
            STERILIZASYON_CIKIS_KODU, STERILIZASYON_GIRIS_KODU, GIDEN_BIRIM_KODU, CIKIS_ZAMANI,
            TESLIM_EDEN_PERSONEL_KODU, CIKIS_NOTU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SCK-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @girisKodu,
            @birimKodu,
            DATEADD(DAY, -@i, DATEADD(HOUR, 14, GETDATE())),
            @personelKodu,
            'Sterilizasyon çıkış notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STERILIZASYON_CIKIS: 30 kayit eklendi.';
END;
GO

-- 43. STERILIZASYON_STOK_DURUM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STERILIZASYON_STOK_DURUM WHERE STERILIZASYON_STOK_DURUM_KODU LIKE 'SSD-SEED-%')
BEGIN
    PRINT 'STERILIZASYON_STOK_DURUM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @setKodu NVARCHAR(50);
    DECLARE @birimKodu NVARCHAR(50);

    SELECT TOP 1 @birimKodu = BIRIM_KODU FROM BIRIM;

    WHILE @i <= 30
    BEGIN
        SET @setKodu = 'SST-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO STERILIZASYON_STOK_DURUM (
            STERILIZASYON_STOK_DURUM_KODU, STERILIZASYON_SET_KODU, BIRIM_KODU, STOK_MIKTARI,
            SON_GUNCELLEME_ZAMANI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SSDD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @setKodu,
            @birimKodu,
            CAST(5 + (@i % 20) AS NVARCHAR(5)),
            GETDATE(),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STERILIZASYON_STOK_DURUM: 30 kayit eklendi.';
END;
GO

-- 44. STERILIZASYON_PAKET_DETAY (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STERILIZASYON_PAKET_DETAY WHERE STERILIZASYON_PAKET_DETAY_KODU LIKE 'SPD-SEED-%')
BEGIN
    PRINT 'STERILIZASYON_PAKET_DETAY tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @paketKodu NVARCHAR(50);
    DECLARE @setKodu NVARCHAR(50);

    SELECT TOP 1 @paketKodu = STERILIZASYON_PAKET_KODU FROM STERILIZASYON_PAKET;

    WHILE @i <= 30
    BEGIN
        SET @setKodu = 'SST-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO STERILIZASYON_PAKET_DETAY (
            STERILIZASYON_PAKET_DETAY_KODU, STERILIZASYON_PAKET_KODU, STERILIZASYON_SET_KODU,
            MIKTAR, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SPD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @paketKodu,
            @setKodu,
            CAST(1 + (@i % 5) AS NVARCHAR(3)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STERILIZASYON_PAKET_DETAY: 30 kayit eklendi.';
END;
GO

-- 45-48. STOK TABLOLARI
-- 45. STOK_DURUM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STOK_DURUM WHERE STOK_DURUM_KODU LIKE 'SD-SEED-%')
BEGIN
    PRINT 'STOK_DURUM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @stokKartKodu NVARCHAR(50);
    DECLARE @depoKodu NVARCHAR(50);

    SELECT TOP 1 @stokKartKodu = STOK_KART_KODU FROM STOK_KART;
    SELECT TOP 1 @depoKodu = DEPO_KODU FROM DEPO;

    WHILE @i <= 30
    BEGIN
        INSERT INTO STOK_DURUM (
            STOK_DURUM_KODU, STOK_KART_KODU, DEPO_KODU, MEVCUT_MIKTAR, MINIMUM_MIKTAR,
            MAKSIMUM_MIKTAR, SON_GUNCELLEME_ZAMANI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @stokKartKodu,
            @depoKodu,
            CAST(100 + (@i * 10) AS NVARCHAR(10)),
            CAST(10 AS NVARCHAR(10)),
            CAST(500 AS NVARCHAR(10)),
            GETDATE(),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STOK_DURUM: 30 kayit eklendi.';
END;
GO

-- 46. STOK_ISTEK_HAREKET (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STOK_ISTEK_HAREKET WHERE STOK_ISTEK_HAREKET_KODU LIKE 'SIH-SEED-%')
BEGIN
    PRINT 'STOK_ISTEK_HAREKET tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @istekKodu NVARCHAR(50);
    DECLARE @stokKartKodu NVARCHAR(50);
    DECLARE @kullaniciKodu NVARCHAR(50);

    SELECT TOP 1 @stokKartKodu = STOK_KART_KODU FROM STOK_KART;
    SELECT TOP 1 @kullaniciKodu = KULLANICI_KODU FROM KULLANICI;

    WHILE @i <= 30
    BEGIN
        SET @istekKodu = 'SI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM STOK_ISTEK WHERE STOK_ISTEK_KODU = @istekKodu)
        BEGIN
            INSERT INTO STOK_ISTEK_HAREKET (
                STOK_ISTEK_HAREKET_KODU, STOK_ISTEK_KODU, STOK_KART_KODU, ISTENEN_MIKTAR,
                VERILEN_MIKTAR, HAREKET_ZAMANI, ONAYLAYAN_KULLANICI_KODU,
                EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'SIH-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @istekKodu,
                @stokKartKodu,
                CAST(5 + (@i % 20) AS NVARCHAR(10)),
                CAST(5 + (@i % 15) AS NVARCHAR(10)),
                DATEADD(DAY, -@i, GETDATE()),
                @kullaniciKodu,
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'STOK_ISTEK_HAREKET: 30 kayit eklendi.';
END;
GO

-- 47. STOK_ISTEK_UYGULAMA (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STOK_ISTEK_UYGULAMA WHERE STOK_ISTEK_UYGULAMA_KODU LIKE 'SIU-SEED-%')
BEGIN
    PRINT 'STOK_ISTEK_UYGULAMA tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @istekHareketKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        SET @istekHareketKodu = 'SIH-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM STOK_ISTEK_HAREKET WHERE STOK_ISTEK_HAREKET_KODU = @istekHareketKodu)
        BEGIN
            INSERT INTO STOK_ISTEK_UYGULAMA (
                STOK_ISTEK_UYGULAMA_KODU, STOK_ISTEK_HAREKET_KODU, UYGULAYAN_PERSONEL_KODU,
                UYGULAMA_ZAMANI, UYGULAMA_NOTU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'SIU-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @istekHareketKodu,
                @personelKodu,
                DATEADD(DAY, -@i, DATEADD(HOUR, 2, GETDATE())),
                'Uygulama notu ' + CAST(@i AS NVARCHAR(5)),
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'STOK_ISTEK_UYGULAMA: 30 kayit eklendi.';
END;
GO

-- 48. STOK_HAREKET (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STOK_HAREKET WHERE STOK_HAREKET_KODU LIKE 'SH-SEED-%')
BEGIN
    PRINT 'STOK_HAREKET tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @stokFisKodu NVARCHAR(50);
    DECLARE @stokKartKodu NVARCHAR(50);
    DECLARE @istekHareketKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);
    DECLARE @cihazKodu NVARCHAR(50);

    SELECT TOP 1 @stokKartKodu = STOK_KART_KODU FROM STOK_KART;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;
    SELECT TOP 1 @cihazKodu = CIHAZ_KODU FROM CIHAZ;

    WHILE @i <= 30
    BEGIN
        SET @stokFisKodu = 'SF-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);
        SET @istekHareketKodu = 'SIH-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO STOK_HAREKET (
            STOK_HAREKET_KODU, BAGLI_STOK_HAREKET_KODU, ILK_GIRIS_STOK_HAREKET_KODU, STOK_ISTEK_HAREKET_KODU,
            STOK_FIS_KODU, STOK_KART_KODU, BARKOD, LOT_NUMARASI, SERI_SIRA_NUMARASI, FIRMA_TANIMLAYICI_NUMARASI,
            MALZEME_SUT_KODU, STOK_HAREKET_MIKTARI, TASINIR_NUMARASI, ALIS_BIRIM_FIYATI, SATIS_BIRIM_FIYATI,
            OLCU_KODU, ISLEMI_YAPAN_PERSONEL_KODU, KDV_ORANI, ISKONTO_ORANI, ISKONTO_TUTARI,
            SON_KULLANMA_TARIHI, MKYS_STOK_HAREKET_KODU, IPTAL_DURUMU, MKYS_KARSI_STOK_HAREKET_KODU,
            MKYS_KUNYE_NUMARASI, UTS_KAYIT_UDI, BAYILIK_NUMARASI, CIHAZ_KODU, ATS_SORGU_NUMARASI,
            ALLOGREFT_DONOR_KODU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SH-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            'SH-SEED-' + RIGHT('00000' + CAST((@i % 10) + 1 AS NVARCHAR(5)), 5),
            'SH-SEED-00001',
            @istekHareketKodu,
            @stokFisKodu,
            @stokKartKodu,
            'BC-' + RIGHT('00000000000' + CAST(@i AS NVARCHAR(11)), 11),
            'LOT-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            'SER-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            'FRM-' + RIGHT('0000' + CAST(@i AS NVARCHAR(4)), 4),
            'SUT-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            CAST(10 + (@i * 5) AS NVARCHAR(10)),
            'TSN-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            CAST(10.00 + @i AS NVARCHAR(10)),
            CAST(15.00 + @i AS NVARCHAR(10)),
            'OLCU_ADET',
            @personelKodu,
            '18',
            '5',
            CAST(@i * 2 AS NVARCHAR(10)),
            DATEADD(YEAR, 1, GETDATE()),
            'MKYS-' + RIGHT('00000000' + CAST(@i AS NVARCHAR(8)), 8),
            'HAYIR',
            'MKYSK-' + RIGHT('00000000' + CAST(@i AS NVARCHAR(8)), 8),
            'KNY-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            'UDI-' + RIGHT('00000000' + CAST(@i AS NVARCHAR(8)), 8),
            'BYL-' + RIGHT('0000' + CAST(@i AS NVARCHAR(4)), 4),
            @cihazKodu,
            'ATS-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            'ALG-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STOK_HAREKET: 30 kayit eklendi.';
END;
GO

-- 49. STOK_EHU_TAKIP (30 kayit)
IF NOT EXISTS (SELECT 1 FROM STOK_EHU_TAKIP WHERE STOK_EHU_TAKIP_KODU LIKE 'SET-SEED-%')
BEGIN
    PRINT 'STOK_EHU_TAKIP tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @stokKartKodu NVARCHAR(50);
    DECLARE @istekKodu NVARCHAR(50);
    DECLARE @istekHareketKodu NVARCHAR(50);

    SELECT TOP 1 @stokKartKodu = STOK_KART_KODU FROM STOK_KART;

    WHILE @i <= 30
    BEGIN
        SET @istekKodu = 'SI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);
        SET @istekHareketKodu = 'SIH-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO STOK_EHU_TAKIP (
            STOK_EHU_TAKIP_KODU, STOK_KART_KODU, STOK_ISTEK_KODU, STOK_ISTEK_HAREKET_KODU,
            EHU_DURUMU, TAKIP_TARIHI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'SET-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @stokKartKodu,
            @istekKodu,
            @istekHareketKodu,
            CASE @i % 3 WHEN 0 THEN 'BEKLEMEDE' WHEN 1 THEN 'TESLIM_EDILDI' ELSE 'IPTAL' END,
            DATEADD(DAY, -@i, GETDATE()),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'STOK_EHU_TAKIP: 30 kayit eklendi.';
END;
GO

PRINT '=== KAN, STERILIZASYON, STOK TABLOLARI TAMAMLANDI ===';
GO
