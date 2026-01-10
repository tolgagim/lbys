-- =====================================================
-- LBYS Kalan Tablolar Seed Data Script - PART 5
-- IZLEM, TETKIK, KURUL, PATOLOJI, OPTIK, DIS, DIGER
-- =====================================================

USE TESTDATA;
GO

SET NOCOUNT ON;
GO

PRINT '=== IZLEM, TETKIK, KURUL VE DIGER TABLOLAR ===';

-- 50-56. IZLEM TABLOLARI
-- 50. BEBEK_COCUK_IZLEM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM BEBEK_COCUK_IZLEM WHERE BEBEK_COCUK_IZLEM_KODU LIKE 'BCI-SEED-%')
BEGIN
    PRINT 'BEBEK_COCUK_IZLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO BEBEK_COCUK_IZLEM (
            BEBEK_COCUK_IZLEM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, KACINCI_IZLEM, BAS_CEVRESI,
            DOGUM_AGIRLIGI, HEMOGLOBIN_DEGERI, IZLEMI_YAPAN_PERSONEL_KODU, IZLEM_TARIHI,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'BCI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            'IZLEM_' + CAST(1 + (@i % 5) AS NVARCHAR(2)),
            CAST(34 + (@i % 6) AS NVARCHAR(3)),
            CAST(3000 + (@i * 50) AS NVARCHAR(5)),
            CAST(11 + (CAST(@i AS FLOAT) / 10) AS NVARCHAR(5)),
            @personelKodu,
            DATEADD(DAY, -@i, GETDATE()),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'BEBEK_COCUK_IZLEM: 30 kayit eklendi.';
END;
GO

-- 51. EVDE_SAGLIK_IZLEM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM EVDE_SAGLIK_IZLEM WHERE EVDE_SAGLIK_IZLEM_KODU LIKE 'ESI-SEED-%')
BEGIN
    PRINT 'EVDE_SAGLIK_IZLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO EVDE_SAGLIK_IZLEM (
            EVDE_SAGLIK_IZLEM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, IZLEM_TARIHI, IZLEM_TURU,
            IZLEMI_YAPAN_PERSONEL_KODU, IZLEM_NOTU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'ESI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            DATEADD(DAY, -@i, GETDATE()),
            CASE @i % 3 WHEN 0 THEN 'RUTIN' WHEN 1 THEN 'ACIL' ELSE 'KONTROL' END,
            @personelKodu,
            'Evde sağlık izlem notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'EVDE_SAGLIK_IZLEM: 30 kayit eklendi.';
END;
GO

-- 52. INTIHAR_IZLEM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM INTIHAR_IZLEM WHERE INTIHAR_IZLEM_KODU LIKE 'INI-SEED-%')
BEGIN
    PRINT 'INTIHAR_IZLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO INTIHAR_IZLEM (
            INTIHAR_IZLEM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, IZLEM_TARIHI, RISK_DURUMU,
            IZLEMI_YAPAN_PERSONEL_KODU, IZLEM_NOTU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'INI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            DATEADD(DAY, -@i, GETDATE()),
            CASE @i % 3 WHEN 0 THEN 'DUSUK' WHEN 1 THEN 'ORTA' ELSE 'YUKSEK' END,
            @personelKodu,
            'İntihar izlem notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'INTIHAR_IZLEM: 30 kayit eklendi.';
END;
GO

-- 53. KADIN_IZLEM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KADIN_IZLEM WHERE KADIN_IZLEM_KODU LIKE 'KDI-SEED-%')
BEGIN
    PRINT 'KADIN_IZLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO KADIN_IZLEM (
            KADIN_IZLEM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, IZLEM_TARIHI, IZLEM_TURU,
            IZLEMI_YAPAN_PERSONEL_KODU, IZLEM_NOTU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'KDI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            DATEADD(DAY, -@i, GETDATE()),
            CASE @i % 4 WHEN 0 THEN 'SMEAR' WHEN 1 THEN 'MAMOGRAFI' WHEN 2 THEN 'KONTROL' ELSE 'GEBELIK' END,
            @personelKodu,
            'Kadın izlem notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'KADIN_IZLEM: 30 kayit eklendi.';
END;
GO

-- 54. KUDUZ_IZLEM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KUDUZ_IZLEM WHERE KUDUZ_IZLEM_KODU LIKE 'KZI-SEED-%')
BEGIN
    PRINT 'KUDUZ_IZLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO KUDUZ_IZLEM (
            KUDUZ_IZLEM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, IZLEM_TARIHI, TEMAS_TARIHI,
            HAYVAN_TURU, ASI_UYGULAMA_DURUMU, IZLEMI_YAPAN_PERSONEL_KODU, IZLEM_NOTU,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'KZI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            DATEADD(DAY, -@i, GETDATE()),
            DATEADD(DAY, -@i - 1, GETDATE()),
            CASE @i % 4 WHEN 0 THEN 'KOPEK' WHEN 1 THEN 'KEDI' WHEN 2 THEN 'YARASA' ELSE 'DIGER' END,
            CASE @i % 2 WHEN 0 THEN 'UYGULANDI' ELSE 'UYGULANMADI' END,
            @personelKodu,
            'Kuduz izlem notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'KUDUZ_IZLEM: 30 kayit eklendi.';
END;
GO

-- 55. LOHUSA_IZLEM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM LOHUSA_IZLEM WHERE LOHUSA_IZLEM_KODU LIKE 'LHI-SEED-%')
BEGIN
    PRINT 'LOHUSA_IZLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO LOHUSA_IZLEM (
            LOHUSA_IZLEM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, IZLEM_TARIHI, DOGUM_TARIHI,
            KACINCI_IZLEM, IZLEMI_YAPAN_PERSONEL_KODU, IZLEM_NOTU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'LHI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            DATEADD(DAY, -@i, GETDATE()),
            DATEADD(DAY, -@i - 7, GETDATE()),
            'IZLEM_' + CAST(1 + (@i % 3) AS NVARCHAR(2)),
            @personelKodu,
            'Lohusa izlem notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'LOHUSA_IZLEM: 30 kayit eklendi.';
END;
GO

-- 56. OBEZITE_IZLEM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM OBEZITE_IZLEM WHERE OBEZITE_IZLEM_KODU LIKE 'OBI-SEED-%')
BEGIN
    PRINT 'OBEZITE_IZLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO OBEZITE_IZLEM (
            OBEZITE_IZLEM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, IZLEM_TARIHI, BOY, KILO, VKI,
            BEL_CEVRESI, KALCA_CEVRESI, IZLEMI_YAPAN_PERSONEL_KODU, IZLEM_NOTU,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'OBI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            DATEADD(DAY, -@i, GETDATE()),
            CAST(160 + (@i % 30) AS NVARCHAR(5)),
            CAST(70 + (@i % 50) AS NVARCHAR(5)),
            CAST(25 + (CAST(@i AS FLOAT) / 3) AS NVARCHAR(5)),
            CAST(80 + (@i % 30) AS NVARCHAR(5)),
            CAST(90 + (@i % 25) AS NVARCHAR(5)),
            @personelKodu,
            'Obezite izlem notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'OBEZITE_IZLEM: 30 kayit eklendi.';
END;
GO

-- 57-60. TETKIK TABLOLARI
-- 57. TETKIK_NUMUNE (30 kayit)
IF NOT EXISTS (SELECT 1 FROM TETKIK_NUMUNE WHERE TETKIK_NUMUNE_KODU LIKE 'TNM-SEED-%')
BEGIN
    PRINT 'TETKIK_NUMUNE tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @tetkikKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @tetkikKodu = TETKIK_KODU FROM TETKIK;

    WHILE @i <= 30
    BEGIN
        INSERT INTO TETKIK_NUMUNE (
            TETKIK_NUMUNE_KODU, HASTA_KODU, HASTA_BASVURU_KODU, TETKIK_KODU, NUMUNE_TURU,
            NUMUNE_ALMA_ZAMANI, BARKOD, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'TNM-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            @tetkikKodu,
            CASE @i % 5 WHEN 0 THEN 'KAN' WHEN 1 THEN 'IDRAR' WHEN 2 THEN 'GAITA' WHEN 3 THEN 'BOS' ELSE 'BIYOPSI' END,
            DATEADD(DAY, -@i, DATEADD(HOUR, 8, GETDATE())),
            'BC-NMN-' + RIGHT('00000000' + CAST(@i AS NVARCHAR(8)), 8),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'TETKIK_NUMUNE: 30 kayit eklendi.';
END;
GO

-- 58. TETKIK_SONUC (30 kayit)
IF NOT EXISTS (SELECT 1 FROM TETKIK_SONUC WHERE TETKIK_SONUC_KODU LIKE 'TSN-SEED-%')
BEGIN
    PRINT 'TETKIK_SONUC tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @tetkikNumuneKodu NVARCHAR(50);
    DECLARE @tetkikParametreKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @tetkikParametreKodu = TETKIK_PARAMETRE_KODU FROM TETKIK_PARAMETRE;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        SET @tetkikNumuneKodu = 'TNM-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO TETKIK_SONUC (
            TETKIK_SONUC_KODU, TETKIK_NUMUNE_KODU, TETKIK_PARAMETRE_KODU, SONUC_DEGERI,
            SONUC_BIRIMI, REFERANS_ARALIK_ALT, REFERANS_ARALIK_UST, SONUC_DURUMU,
            ONAYLAYAN_PERSONEL_KODU, ONAY_ZAMANI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'TSN-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @tetkikNumuneKodu,
            @tetkikParametreKodu,
            CAST(10 + (@i * 2) AS NVARCHAR(10)),
            CASE @i % 4 WHEN 0 THEN 'mg/dL' WHEN 1 THEN 'U/L' WHEN 2 THEN 'mmol/L' ELSE 'g/dL' END,
            CAST(5 AS NVARCHAR(10)),
            CAST(100 AS NVARCHAR(10)),
            CASE @i % 3 WHEN 0 THEN 'NORMAL' WHEN 1 THEN 'YUKSEK' ELSE 'DUSUK' END,
            @personelKodu,
            DATEADD(DAY, -@i, DATEADD(HOUR, 12, GETDATE())),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'TETKIK_SONUC: 30 kayit eklendi.';
END;
GO

-- 59. TETKIK_REFERANS_ARALIK (30 kayit)
IF NOT EXISTS (SELECT 1 FROM TETKIK_REFERANS_ARALIK WHERE TETKIK_REFERANS_ARALIK_KODU LIKE 'TRA-SEED-%')
BEGIN
    PRINT 'TETKIK_REFERANS_ARALIK tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @tetkikParametreKodu NVARCHAR(50);

    SELECT TOP 1 @tetkikParametreKodu = TETKIK_PARAMETRE_KODU FROM TETKIK_PARAMETRE;

    WHILE @i <= 30
    BEGIN
        INSERT INTO TETKIK_REFERANS_ARALIK (
            TETKIK_REFERANS_ARALIK_KODU, TETKIK_PARAMETRE_KODU, CINSIYET, YAS_ALT, YAS_UST,
            REFERANS_ALT, REFERANS_UST, BIRIM, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'TRA-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @tetkikParametreKodu,
            CASE @i % 3 WHEN 0 THEN 'E' WHEN 1 THEN 'K' ELSE 'H' END,
            CAST(0 + ((@i - 1) * 3) AS NVARCHAR(5)),
            CAST(3 + ((@i - 1) * 3) AS NVARCHAR(5)),
            CAST(10 + (@i % 20) AS NVARCHAR(10)),
            CAST(100 + (@i % 50) AS NVARCHAR(10)),
            CASE @i % 4 WHEN 0 THEN 'mg/dL' WHEN 1 THEN 'U/L' WHEN 2 THEN 'mmol/L' ELSE 'g/dL' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'TETKIK_REFERANS_ARALIK: 30 kayit eklendi.';
END;
GO

-- 60. TETKIK_CIHAZ_ESLESME (30 kayit)
IF NOT EXISTS (SELECT 1 FROM TETKIK_CIHAZ_ESLESME WHERE TETKIK_CIHAZ_ESLESME_KODU LIKE 'TCE-SEED-%')
BEGIN
    PRINT 'TETKIK_CIHAZ_ESLESME tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @tetkikKodu NVARCHAR(50);
    DECLARE @cihazKodu NVARCHAR(50);

    SELECT TOP 1 @tetkikKodu = TETKIK_KODU FROM TETKIK;
    SELECT TOP 1 @cihazKodu = CIHAZ_KODU FROM CIHAZ;

    WHILE @i <= 30
    BEGIN
        INSERT INTO TETKIK_CIHAZ_ESLESME (
            TETKIK_CIHAZ_ESLESME_KODU, TETKIK_KODU, CIHAZ_KODU, AKTIF_DURUMU,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'TCE-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @tetkikKodu,
            @cihazKodu,
            CASE @i % 5 WHEN 0 THEN 'PASIF' ELSE 'AKTIF' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'TETKIK_CIHAZ_ESLESME: 30 kayit eklendi.';
END;
GO

-- 61-64. KURUL TABLOLARI
-- 61. KURUL_ASKERI (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KURUL_ASKERI WHERE KURUL_ASKERI_KODU LIKE 'KAS-SEED-%')
BEGIN
    PRINT 'KURUL_ASKERI tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @kurulRaporKodu NVARCHAR(50);

    SELECT TOP 1 @kurulRaporKodu = KURUL_RAPOR_KODU FROM KURUL_RAPOR;

    WHILE @i <= 30
    BEGIN
        INSERT INTO KURUL_ASKERI (
            KURUL_ASKERI_KODU, KURUL_RAPOR_KODU, ASKERLIK_DURUMU, ASKERLIK_SINIFI,
            KARAR, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'KAS-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @kurulRaporKodu,
            CASE @i % 4 WHEN 0 THEN 'MUAF' WHEN 1 THEN 'ERTELI' WHEN 2 THEN 'SINIRLI' ELSE 'TAM' END,
            CASE @i % 3 WHEN 0 THEN 'PIYADE' WHEN 1 THEN 'DENIZ' ELSE 'HAVA' END,
            'Askerlik kurul kararı ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'KURUL_ASKERI: 30 kayit eklendi.';
END;
GO

-- 62. KURUL_ETKEN_MADDE (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KURUL_ETKEN_MADDE WHERE KURUL_ETKEN_MADDE_KODU LIKE 'KEM-SEED-%')
BEGIN
    PRINT 'KURUL_ETKEN_MADDE tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @kurulRaporKodu NVARCHAR(50);

    SELECT TOP 1 @kurulRaporKodu = KURUL_RAPOR_KODU FROM KURUL_RAPOR;

    WHILE @i <= 30
    BEGIN
        INSERT INTO KURUL_ETKEN_MADDE (
            KURUL_ETKEN_MADDE_KODU, KURUL_RAPOR_KODU, ETKEN_MADDE_ADI, ETKEN_MADDE_KODU,
            DOZ, DOZ_BIRIMI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'KEM-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @kurulRaporKodu,
            CASE @i % 5 WHEN 0 THEN 'Metformin' WHEN 1 THEN 'Amlodipine' WHEN 2 THEN 'Atorvastatin' WHEN 3 THEN 'Omeprazol' ELSE 'Metoprolol' END,
            'ETK-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            CAST(100 + (@i * 50) AS NVARCHAR(10)),
            'mg',
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'KURUL_ETKEN_MADDE: 30 kayit eklendi.';
END;
GO

-- 63. KURUL_HEKIM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KURUL_HEKIM WHERE KURUL_HEKIM_KODU LIKE 'KHK-SEED-%')
BEGIN
    PRINT 'KURUL_HEKIM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @kurulRaporKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @kurulRaporKodu = KURUL_RAPOR_KODU FROM KURUL_RAPOR;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO KURUL_HEKIM (
            KURUL_HEKIM_KODU, KURUL_RAPOR_KODU, HEKIM_KODU, HEKIM_GORUSU, HEKIM_ROLU,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'KHK-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @kurulRaporKodu,
            @personelKodu,
            'Hekim görüşü ' + CAST(@i AS NVARCHAR(5)),
            CASE @i % 3 WHEN 0 THEN 'BASKAN' WHEN 1 THEN 'UYE' ELSE 'RAPORTER' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'KURUL_HEKIM: 30 kayit eklendi.';
END;
GO

-- 64-68. DIGER TABLOLAR
-- 64. PATOLOJI (30 kayit)
IF NOT EXISTS (SELECT 1 FROM PATOLOJI WHERE PATOLOJI_KODU LIKE 'PTL-SEED-%')
BEGIN
    PRINT 'PATOLOJI tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO PATOLOJI (
            PATOLOJI_KODU, HASTA_KODU, HASTA_BASVURU_KODU, NUMUNE_ALMA_TARIHI, NUMUNE_TURU,
            RAPOR_TARIHI, RAPOR_SONUCU, RAPORLAYAN_HEKIM_KODU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'PTL-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            DATEADD(DAY, -@i - 3, GETDATE()),
            CASE @i % 4 WHEN 0 THEN 'BIYOPSI' WHEN 1 THEN 'SITOLOJI' WHEN 2 THEN 'DONMUS_KESIT' ELSE 'OTOPSI' END,
            DATEADD(DAY, -@i, GETDATE()),
            CASE @i % 3 WHEN 0 THEN 'BENIGN' WHEN 1 THEN 'MALIGN' ELSE 'SUPHELI' END,
            @personelKodu,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'PATOLOJI: 30 kayit eklendi.';
END;
GO

-- 65. OPTIK_RECETE (30 kayit)
IF NOT EXISTS (SELECT 1 FROM OPTIK_RECETE WHERE OPTIK_RECETE_KODU LIKE 'OPT-SEED-%')
BEGIN
    PRINT 'OPTIK_RECETE tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @hekimKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @hekimKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO OPTIK_RECETE (
            OPTIK_RECETE_KODU, HASTA_KODU, HASTA_BASVURU_KODU, HEKIM_KODU, RECETE_ZAMANI,
            SAG_GOZ_SFER, SAG_GOZ_SILINDIR, SAG_GOZ_AKS, SOL_GOZ_SFER, SOL_GOZ_SILINDIR,
            SOL_GOZ_AKS, YAKIN_ILAVE, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'OPT-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            @hekimKodu,
            DATEADD(DAY, -@i, GETDATE()),
            CAST(-2.00 + (CAST(@i AS FLOAT) / 10) AS NVARCHAR(10)),
            CAST(-0.50 + (CAST(@i AS FLOAT) / 20) AS NVARCHAR(10)),
            CAST(90 + (@i % 90) AS NVARCHAR(5)),
            CAST(-1.50 + (CAST(@i AS FLOAT) / 10) AS NVARCHAR(10)),
            CAST(-0.75 + (CAST(@i AS FLOAT) / 20) AS NVARCHAR(10)),
            CAST(85 + (@i % 95) AS NVARCHAR(5)),
            CAST(1.00 + (CAST(@i AS FLOAT) / 15) AS NVARCHAR(10)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'OPTIK_RECETE: 30 kayit eklendi.';
END;
GO

-- 66. ORTODONTI_ICON_SKOR (30 kayit)
IF NOT EXISTS (SELECT 1 FROM ORTODONTI_ICON_SKOR WHERE ORTODONTI_ICON_SKOR_KODU LIKE 'OIS-SEED-%')
BEGIN
    PRINT 'ORTODONTI_ICON_SKOR tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;

    WHILE @i <= 30
    BEGIN
        INSERT INTO ORTODONTI_ICON_SKOR (
            ORTODONTI_ICON_SKOR_KODU, HASTA_KODU, HASTA_BASVURU_KODU, ICON_SKORU, DEGERLENDIRME_TARIHI,
            DENTAL_ESTETIK, OVERJET, OVERBITE, CAPRAZLIK, CONTACT_POINT, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'OIS-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            CAST(20 + (@i * 2) AS NVARCHAR(5)),
            DATEADD(DAY, -@i, GETDATE()),
            CAST(1 + (@i % 10) AS NVARCHAR(3)),
            CAST(@i % 5 AS NVARCHAR(3)),
            CAST(@i % 4 AS NVARCHAR(3)),
            CAST(@i % 3 AS NVARCHAR(3)),
            CAST(@i % 5 AS NVARCHAR(3)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'ORTODONTI_ICON_SKOR: 30 kayit eklendi.';
END;
GO

-- 67. DIS_TAAHHUT_DETAY (30 kayit)
IF NOT EXISTS (SELECT 1 FROM DIS_TAAHHUT_DETAY WHERE DIS_TAAHHUT_DETAY_KODU LIKE 'DTD-SEED-%')
BEGIN
    PRINT 'DIS_TAAHHUT_DETAY tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @disTaahhutKodu NVARCHAR(50);

    SELECT TOP 1 @disTaahhutKodu = DIS_TAAHHUT_KODU FROM DIS_TAAHHUT;

    WHILE @i <= 30
    BEGIN
        INSERT INTO DIS_TAAHHUT_DETAY (
            DIS_TAAHHUT_DETAY_KODU, DIS_TAAHHUT_KODU, DIS_NUMARASI, ISLEM_TURU, ISLEM_TUTARI,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'DTD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @disTaahhutKodu,
            CAST(11 + (@i % 32) AS NVARCHAR(3)),
            CASE @i % 4 WHEN 0 THEN 'DOLGU' WHEN 1 THEN 'CEKIM' WHEN 2 THEN 'KANAL' ELSE 'PROTEZ' END,
            CAST(100 + (@i * 50) AS NVARCHAR(10)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'DIS_TAAHHUT_DETAY: 30 kayit eklendi.';
END;
GO

-- 68. DISPROTEZ_DETAY (30 kayit)
IF NOT EXISTS (SELECT 1 FROM DISPROTEZ_DETAY WHERE DISPROTEZ_DETAY_KODU LIKE 'DPD-SEED-%')
BEGIN
    PRINT 'DISPROTEZ_DETAY tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @disprotezKodu NVARCHAR(50);

    SELECT TOP 1 @disprotezKodu = DISPROTEZ_KODU FROM DISPROTEZ;

    WHILE @i <= 30
    BEGIN
        INSERT INTO DISPROTEZ_DETAY (
            DISPROTEZ_DETAY_KODU, DISPROTEZ_KODU, DIS_NUMARASI, PROTEZ_TURU, PROTEZ_MALZEMESI,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'DPD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @disprotezKodu,
            CAST(11 + (@i % 32) AS NVARCHAR(3)),
            CASE @i % 3 WHEN 0 THEN 'SABIT' WHEN 1 THEN 'HAREKETLI' ELSE 'IMPLANT' END,
            CASE @i % 4 WHEN 0 THEN 'METAL' WHEN 1 THEN 'PORSELEN' WHEN 2 THEN 'ZIRKONYUM' ELSE 'AKRILIK' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'DISPROTEZ_DETAY: 30 kayit eklendi.';
END;
GO

PRINT '=== IZLEM, TETKIK, KURUL VE DIGER TABLOLAR TAMAMLANDI ===';
GO
