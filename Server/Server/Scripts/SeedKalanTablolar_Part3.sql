-- =====================================================
-- LBYS Kalan Tablolar Seed Data Script - PART 3
-- Izlem, Personel, Sterilizasyon, Diger Tablolar
-- =====================================================

USE TESTDATA;
GO

SET NOCOUNT ON;
GO

PRINT '=== DIGER TABLOLAR BASLIYOR ===';

-- 19. ANLIK_YATAN_HASTA (30 kayit)
IF NOT EXISTS (SELECT 1 FROM ANLIK_YATAN_HASTA WHERE ANLIK_YATAN_HASTA_KODU LIKE 'AYH-SEED-%')
BEGIN
    PRINT 'ANLIK_YATAN_HASTA tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;

    WHILE @i <= 30
    BEGIN
        INSERT INTO ANLIK_YATAN_HASTA (
            ANLIK_YATAN_HASTA_KODU, HASTA_KODU, HASTA_BASVURU_KODU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'AYH-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'ANLIK_YATAN_HASTA: 30 kayit eklendi.';
END;
GO

-- 20. GEBE_IZLEM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM GEBE_IZLEM WHERE GEBE_IZLEM_KODU LIKE 'GBI-SEED-%')
BEGIN
    PRINT 'GEBE_IZLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;

    WHILE @i <= 30
    BEGIN
        INSERT INTO GEBE_IZLEM (
            GEBE_IZLEM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, KACINCI_GEBE_IZLEM, SON_ADET_TARIHI,
            ONCEKI_DOGUM_DURUMU, GEBE_IZLEM_ISLEM_TURU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'GBI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            'IZLEM_' + CAST(1 + (@i % 8) AS NVARCHAR(2)),
            DATEADD(WEEK, -(@i + 10), GETDATE()),
            'ONCEKI_DOGUM_ILK',
            'GEBE_IZLEM_RUTIN',
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'GEBE_IZLEM: 30 kayit eklendi.';
END;
GO

-- 21. HASTA_ILETISIM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM HASTA_ILETISIM WHERE HASTA_ILETISIM_KODU LIKE 'HI-SEED-%')
BEGIN
    PRINT 'HASTA_ILETISIM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;

    WHILE @i <= 30
    BEGIN
        INSERT INTO HASTA_ILETISIM (
            HASTA_ILETISIM_KODU, HASTA_KODU, CEP_TELEFON_NUMARASI, EV_TELEFON_NUMARASI,
            IS_TELEFON_NUMARASI, E_POSTA_ADRESI, ADRES, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'HI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            '555' + RIGHT('0000000' + CAST(1000000 + @i AS NVARCHAR(7)), 7),
            '312' + RIGHT('0000000' + CAST(2000000 + @i AS NVARCHAR(7)), 7),
            '312' + RIGHT('0000000' + CAST(3000000 + @i AS NVARCHAR(7)), 7),
            'hasta' + CAST(@i AS NVARCHAR(5)) + '@test.com',
            'Test Adresi Sokak No:' + CAST(@i AS NVARCHAR(5)) + ' Ankara',
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'HASTA_ILETISIM: 30 kayit eklendi.';
END;
GO

-- 22. HASTA_SEVK (30 kayit)
IF NOT EXISTS (SELECT 1 FROM HASTA_SEVK WHERE HASTA_SEVK_KODU LIKE 'HS-SEED-%')
BEGIN
    PRINT 'HASTA_SEVK tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @birimKodu NVARCHAR(50);
    DECLARE @hekimKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @birimKodu = BIRIM_KODU FROM BIRIM;
    SELECT TOP 1 @hekimKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO HASTA_SEVK (
            HASTA_SEVK_KODU, HASTA_KODU, HASTA_BASVURU_KODU, SEVK_EDEN_BIRIM_KODU, SEVK_EDILEN_BIRIM_KODU,
            SEVK_EDEN_HEKIM_KODU, SEVK_NEDENI, SEVK_TURU, SEVK_ZAMANI, SEVK_ACIKLAMA,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'HS-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            @birimKodu,
            @birimKodu,
            @hekimKodu,
            'SEVK_NEDENI_UZMANLIK',
            'SEVK_TURU_ACIL',
            DATEADD(DAY, -@i, GETDATE()),
            'Sevk açıklaması ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'HASTA_SEVK: 30 kayit eklendi.';
END;
GO

-- 23. HASTA_SEANS (30 kayit)
IF NOT EXISTS (SELECT 1 FROM HASTA_SEANS WHERE HASTA_SEANS_KODU LIKE 'HSN-SEED-%')
BEGIN
    PRINT 'HASTA_SEANS tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;

    WHILE @i <= 30
    BEGIN
        INSERT INTO HASTA_SEANS (
            HASTA_SEANS_KODU, HASTA_KODU, HASTA_BASVURU_KODU, SEANS_NUMARASI, SEANS_TARIHI,
            SEANS_DURUMU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'HSN-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            CAST(@i AS NVARCHAR(5)),
            DATEADD(DAY, -@i, GETDATE()),
            CASE @i % 3 WHEN 0 THEN 'TAMAMLANDI' WHEN 1 THEN 'BEKLEMEDE' ELSE 'IPTAL' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'HASTA_SEANS: 30 kayit eklendi.';
END;
GO

-- 24. HASTA_VITAL_FIZIKI_BULGU (30 kayit)
IF NOT EXISTS (SELECT 1 FROM HASTA_VITAL_FIZIKI_BULGU WHERE HASTA_VITAL_FIZIKI_BULGU_KODU LIKE 'HVF-SEED-%')
BEGIN
    PRINT 'HASTA_VITAL_FIZIKI_BULGU tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;

    WHILE @i <= 30
    BEGIN
        INSERT INTO HASTA_VITAL_FIZIKI_BULGU (
            HASTA_VITAL_FIZIKI_BULGU_KODU, HASTA_KODU, HASTA_BASVURU_KODU, VUCUT_SICAKLIGI,
            NABIZ, TANSIYON_SISTOLIK, TANSIYON_DIASTOLIK, SOLUNUM_SAYISI, BOY, KILO, VKI,
            OLCUM_ZAMANI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'HVF-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            CAST(36.0 + (CAST(@i AS FLOAT) / 10) AS NVARCHAR(5)),
            CAST(60 + (@i % 40) AS NVARCHAR(5)),
            CAST(110 + (@i % 30) AS NVARCHAR(5)),
            CAST(70 + (@i % 20) AS NVARCHAR(5)),
            CAST(14 + (@i % 6) AS NVARCHAR(5)),
            CAST(160 + (@i % 30) AS NVARCHAR(5)),
            CAST(60 + (@i % 40) AS NVARCHAR(5)),
            CAST(22 + (CAST(@i AS FLOAT) / 5) AS NVARCHAR(5)),
            DATEADD(DAY, -@i, GETDATE()),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'HASTA_VITAL_FIZIKI_BULGU: 30 kayit eklendi.';
END;
GO

-- 25. HASTA_ADLI_RAPOR (30 kayit)
IF NOT EXISTS (SELECT 1 FROM HASTA_ADLI_RAPOR WHERE HASTA_ADLI_RAPOR_KODU LIKE 'HAR-SEED-%')
BEGIN
    PRINT 'HASTA_ADLI_RAPOR tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @hekimKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @hekimKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO HASTA_ADLI_RAPOR (
            HASTA_ADLI_RAPOR_KODU, HASTA_KODU, HASTA_BASVURU_KODU, HEKIM_KODU, RAPOR_TARIHI,
            RAPOR_NUMARASI, RAPOR_ACIKLAMA, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'HAR-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            @hekimKodu,
            DATEADD(DAY, -@i, GETDATE()),
            'ADL-' + RIGHT('00000000' + CAST(@i AS NVARCHAR(8)), 8),
            'Adli rapor açıklaması ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'HASTA_ADLI_RAPOR: 30 kayit eklendi.';
END;
GO

-- 26. HASTA_MALZEME (30 kayit)
IF NOT EXISTS (SELECT 1 FROM HASTA_MALZEME WHERE HASTA_MALZEME_KODU LIKE 'HM-SEED-%')
BEGIN
    PRINT 'HASTA_MALZEME tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @stokKartKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @stokKartKodu = STOK_KART_KODU FROM STOK_KART;

    WHILE @i <= 30
    BEGIN
        INSERT INTO HASTA_MALZEME (
            HASTA_MALZEME_KODU, HASTA_KODU, HASTA_BASVURU_KODU, STOK_KART_KODU, MIKTAR,
            KULLANIM_TARIHI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'HM-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            @stokKartKodu,
            CAST(1 + (@i % 5) AS NVARCHAR(5)),
            DATEADD(DAY, -@i, GETDATE()),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'HASTA_MALZEME: 30 kayit eklendi.';
END;
GO

-- 27. HASTA_DIS (30 kayit)
IF NOT EXISTS (SELECT 1 FROM HASTA_DIS WHERE HASTA_DIS_KODU LIKE 'HD-SEED-%')
BEGIN
    PRINT 'HASTA_DIS tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;

    WHILE @i <= 30
    BEGIN
        INSERT INTO HASTA_DIS (
            HASTA_DIS_KODU, HASTA_KODU, HASTA_BASVURU_KODU, DIS_NUMARASI, DIS_DURUMU,
            ISLEM_TURU, ISLEM_TARIHI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'HD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            CAST(11 + (@i % 32) AS NVARCHAR(3)),
            CASE @i % 4 WHEN 0 THEN 'SAGLIKLI' WHEN 1 THEN 'CURUK' WHEN 2 THEN 'DOLGULU' ELSE 'CEKILMIS' END,
            CASE @i % 3 WHEN 0 THEN 'DOLGU' WHEN 1 THEN 'CEKIM' ELSE 'KANAL' END,
            DATEADD(DAY, -@i, GETDATE()),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'HASTA_DIS: 30 kayit eklendi.';
END;
GO

-- 28. HEMSIRE_BAKIM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM HEMSIRE_BAKIM WHERE HEMSIRE_BAKIM_KODU LIKE 'HB-SEED-%')
BEGIN
    PRINT 'HEMSIRE_BAKIM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO HEMSIRE_BAKIM (
            HEMSIRE_BAKIM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, HEMSIRE_KODU, BAKIM_TARIHI,
            BAKIM_TURU, BAKIM_NOTU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'HB-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            @personelKodu,
            DATEADD(DAY, -@i, GETDATE()),
            CASE @i % 4 WHEN 0 THEN 'PANSUMAN' WHEN 1 THEN 'ENJEKSIYON' WHEN 2 THEN 'SERUM' ELSE 'GENEL_BAKIM' END,
            'Hemşire bakım notu ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'HEMSIRE_BAKIM: 30 kayit eklendi.';
END;
GO

-- 29-34. PERSONEL TABLOLARI
-- 29. PERSONEL_BAKMAKLA_YUKUMLU (30 kayit)
IF NOT EXISTS (SELECT 1 FROM PERSONEL_BAKMAKLA_YUKUMLU WHERE PERSONEL_BAKMAKLA_YUKUMLU_KODU LIKE 'PBY-SEED-%')
BEGIN
    PRINT 'PERSONEL_BAKMAKLA_YUKUMLU tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO PERSONEL_BAKMAKLA_YUKUMLU (
            PERSONEL_BAKMAKLA_YUKUMLU_KODU, PERSONEL_KODU, AD, SOYADI, TC_KIMLIK_NUMARASI,
            YAKINLIK_DERECESI, DOGUM_TARIHI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'PBY-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @personelKodu,
            CASE @i % 4 WHEN 0 THEN 'Eş' WHEN 1 THEN 'Çocuk' WHEN 2 THEN 'Anne' ELSE 'Baba' END + ' ' + CAST(@i AS NVARCHAR(5)),
            'Yılmaz',
            '3' + RIGHT('0000000000' + CAST(30000000000 + @i AS NVARCHAR(11)), 10),
            CASE @i % 4 WHEN 0 THEN 'ES' WHEN 1 THEN 'COCUK' WHEN 2 THEN 'ANNE' ELSE 'BABA' END,
            DATEADD(YEAR, -(20 + @i), GETDATE()),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'PERSONEL_BAKMAKLA_YUKUMLU: 30 kayit eklendi.';
END;
GO

-- 30. PERSONEL_EGITIM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM PERSONEL_EGITIM WHERE PERSONEL_EGITIM_KODU LIKE 'PEG-SEED-%')
BEGIN
    PRINT 'PERSONEL_EGITIM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO PERSONEL_EGITIM (
            PERSONEL_EGITIM_KODU, PERSONEL_KODU, EGITIM_ADI, EGITIM_TURU, EGITIM_BASLAMA_TARIHI,
            EGITIM_BITIS_TARIHI, SERTIFIKA_NUMARASI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'PEG-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @personelKodu,
            CASE @i % 5 WHEN 0 THEN 'Temel Yaşam Desteği' WHEN 1 THEN 'İleri Kardiyak Yaşam Desteği' WHEN 2 THEN 'Enfeksiyon Kontrolü' WHEN 3 THEN 'İş Güvenliği' ELSE 'Mesleki Gelişim' END,
            CASE @i % 3 WHEN 0 THEN 'ZORUNLU' WHEN 1 THEN 'GONULLU' ELSE 'MESLEKI' END,
            DATEADD(MONTH, -@i, GETDATE()),
            DATEADD(MONTH, -@i + 1, GETDATE()),
            'SRT-' + RIGHT('00000000' + CAST(@i AS NVARCHAR(8)), 8),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'PERSONEL_EGITIM: 30 kayit eklendi.';
END;
GO

-- 31. PERSONEL_GOREVLENDIRME (30 kayit)
IF NOT EXISTS (SELECT 1 FROM PERSONEL_GOREVLENDIRME WHERE PERSONEL_GOREVLENDIRME_KODU LIKE 'PGR-SEED-%')
BEGIN
    PRINT 'PERSONEL_GOREVLENDIRME tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @personelKodu NVARCHAR(50);
    DECLARE @birimKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;
    SELECT TOP 1 @birimKodu = BIRIM_KODU FROM BIRIM;

    WHILE @i <= 30
    BEGIN
        INSERT INTO PERSONEL_GOREVLENDIRME (
            PERSONEL_GOREVLENDIRME_KODU, PERSONEL_KODU, GOREVLENDIRILEN_BIRIM_KODU,
            GOREVLENDIRME_BASLAMA_TARIHI, GOREVLENDIRME_BITIS_TARIHI, GOREVLENDIRME_NEDENI,
            EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'PGR-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @personelKodu,
            @birimKodu,
            DATEADD(DAY, -@i * 7, GETDATE()),
            DATEADD(DAY, -@i * 7 + 30, GETDATE()),
            CASE @i % 3 WHEN 0 THEN 'GECICI' WHEN 1 THEN 'SUREKLI' ELSE 'NOBET' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'PERSONEL_GOREVLENDIRME: 30 kayit eklendi.';
END;
GO

-- 32. PERSONEL_IZIN_DURUMU (30 kayit)
IF NOT EXISTS (SELECT 1 FROM PERSONEL_IZIN_DURUMU WHERE PERSONEL_IZIN_DURUMU_KODU LIKE 'PID-SEED-%')
BEGIN
    PRINT 'PERSONEL_IZIN_DURUMU tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO PERSONEL_IZIN_DURUMU (
            PERSONEL_IZIN_DURUMU_KODU, PERSONEL_KODU, IZIN_TURU, IZIN_BASLAMA_TARIHI,
            IZIN_BITIS_TARIHI, IZIN_GUN_SAYISI, IZIN_DURUMU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'PID-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @personelKodu,
            CASE @i % 5 WHEN 0 THEN 'YILLIK' WHEN 1 THEN 'SAGLIK' WHEN 2 THEN 'MAZERET' WHEN 3 THEN 'DOGUM' ELSE 'UCRETSIZ' END,
            DATEADD(DAY, -@i * 10, GETDATE()),
            DATEADD(DAY, -@i * 10 + 5, GETDATE()),
            CAST(1 + (@i % 14) AS NVARCHAR(3)),
            CASE @i % 3 WHEN 0 THEN 'ONAYLANDI' WHEN 1 THEN 'BEKLEMEDE' ELSE 'REDDEDILDI' END,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'PERSONEL_IZIN_DURUMU: 30 kayit eklendi.';
END;
GO

-- 33. PERSONEL_ODUL_CEZA (30 kayit)
IF NOT EXISTS (SELECT 1 FROM PERSONEL_ODUL_CEZA WHERE PERSONEL_ODUL_CEZA_KODU LIKE 'POC-SEED-%')
BEGIN
    PRINT 'PERSONEL_ODUL_CEZA tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO PERSONEL_ODUL_CEZA (
            PERSONEL_ODUL_CEZA_KODU, PERSONEL_KODU, ODUL_CEZA_TURU, ODUL_CEZA_TARIHI,
            ODUL_CEZA_ACIKLAMA, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'POC-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @personelKodu,
            CASE @i % 2 WHEN 0 THEN 'ODUL' ELSE 'CEZA' END,
            DATEADD(MONTH, -@i, GETDATE()),
            CASE @i % 2 WHEN 0 THEN 'Başarılı performans ödülü' ELSE 'Disiplin cezası' END + ' - ' + CAST(@i AS NVARCHAR(5)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'PERSONEL_ODUL_CEZA: 30 kayit eklendi.';
END;
GO

-- 34. PERSONEL_BORDRO_SONDURUM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM PERSONEL_BORDRO_SONDURUM WHERE PERSONEL_BORDRO_SONDURUM_KODU LIKE 'PBS-SEED-%')
BEGIN
    PRINT 'PERSONEL_BORDRO_SONDURUM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO PERSONEL_BORDRO_SONDURUM (
            PERSONEL_BORDRO_SONDURUM_KODU, PERSONEL_KODU, DONEM, BRUT_MAAS, NET_MAAS,
            KESINTILER, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'PBS-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @personelKodu,
            FORMAT(DATEADD(MONTH, -@i, GETDATE()), 'yyyy-MM'),
            CAST(15000 + (@i * 500) AS NVARCHAR(10)),
            CAST(12000 + (@i * 400) AS NVARCHAR(10)),
            CAST(3000 + (@i * 100) AS NVARCHAR(10)),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'PERSONEL_BORDRO_SONDURUM: 30 kayit eklendi.';
END;
GO

-- 35. PERSONEL_YANDAL (30 kayit)
IF NOT EXISTS (SELECT 1 FROM PERSONEL_YANDAL WHERE PERSONEL_YANDAL_KODU LIKE 'PYD-SEED-%')
BEGIN
    PRINT 'PERSONEL_YANDAL tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        INSERT INTO PERSONEL_YANDAL (
            PERSONEL_YANDAL_KODU, PERSONEL_KODU, YANDAL_ADI, YANDAL_BASLAMA_TARIHI,
            YANDAL_BITIS_TARIHI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'PYD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @personelKodu,
            CASE @i % 5 WHEN 0 THEN 'Gastroenteroloji' WHEN 1 THEN 'Kardiyoloji' WHEN 2 THEN 'Nefroloji' WHEN 3 THEN 'Endokrinoloji' ELSE 'Romatoloji' END,
            DATEADD(YEAR, -5 - (@i % 3), GETDATE()),
            DATEADD(YEAR, -2 - (@i % 2), GETDATE()),
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'PERSONEL_YANDAL: 30 kayit eklendi.';
END;
GO

PRINT '=== PERSONEL TABLOLARI TAMAMLANDI ===';
GO
