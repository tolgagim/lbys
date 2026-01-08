-- =============================================================================
-- VEM Demo Veri Seed Script
-- Tum bos tablolara 20-30 kayit ekler
-- =============================================================================

USE TESTDATA;
GO

-- =============================================================================
-- 1. HASTA_ILETISIM - Her hasta icin iletisim bilgisi
-- =============================================================================
INSERT INTO [Lbys].[HASTA_ILETISIM]
(HASTA_ILETISIM_KODU, REFERANS_TABLO_ADI, HASTA_KODU, ADRES_TIPI, TELEFON_NUMARASI, EMAIL_ADRESI, ADRES, IL_KODU, ILCE_KODU, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT
    N'HI-' + CAST(ROW_NUMBER() OVER (ORDER BY HASTA_KODU) AS NVARCHAR(10)),
    N'HASTA_ILETISIM',
    HASTA_KODU,
    N'1',
    N'05' + RIGHT('00000000' + CAST(ABS(CHECKSUM(NEWID())) % 100000000 AS NVARCHAR(8)), 8),
    LOWER(REPLACE(AD, ' ', '')) + '.' + LOWER(REPLACE(SOYAD, ' ', '')) + '@email.com',
    N'Ornek Mahallesi No:' + CAST(ABS(CHECKSUM(NEWID())) % 100 AS NVARCHAR(3)),
    N'34',
    N'1',
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA]
WHERE HASTA_KODU NOT IN (SELECT HASTA_KODU FROM [Lbys].[HASTA_ILETISIM]);
GO

-- =============================================================================
-- 2. ASI_BILGISI - Her hasta icin asi kaydi
-- =============================================================================
INSERT INTO [Lbys].[ASI_BILGISI]
(ASI_BILGISI_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, ASI_KODU, ASININ_DOZU, ASININ_UYGULAMA_SEKLI, ASI_UYGULAMA_YERI, ASI_ISLEM_TURU, ASI_YAPILMA_ZAMANI, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 25
    N'ASI-' + CAST(ROW_NUMBER() OVER (ORDER BY h.HASTA_KODU) AS NVARCHAR(10)),
    N'ASI_BILGISI',
    h.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    N'1',
    N'1',
    N'1',
    N'1',
    N'1',
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE()),
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA] h
INNER JOIN [Lbys].[HASTA_BASVURU] b ON h.HASTA_KODU = b.HASTA_KODU
WHERE h.HASTA_KODU NOT IN (SELECT HASTA_KODU FROM [Lbys].[ASI_BILGISI]);
GO

-- =============================================================================
-- 3. GEBE_IZLEM - Kadin hastalar icin gebe izlem
-- =============================================================================
INSERT INTO [Lbys].[GEBE_IZLEM]
(GEBE_IZLEM_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, HEKIM_KODU, BIRIM_KODU, IZLEM_TARIHI, GEBELIK_HAFTASI, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 20
    N'GI-' + CAST(ROW_NUMBER() OVER (ORDER BY h.HASTA_KODU) AS NVARCHAR(10)),
    N'GEBE_IZLEM',
    h.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    (SELECT TOP 1 PERSONEL_KODU FROM [Lbys].[PERSONEL] ORDER BY NEWID()),
    (SELECT TOP 1 BIRIM_KODU FROM [Lbys].[BIRIM] ORDER BY NEWID()),
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 180, GETDATE()),
    ABS(CHECKSUM(NEWID())) % 40 + 1,
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA] h
INNER JOIN [Lbys].[HASTA_BASVURU] b ON h.HASTA_KODU = b.HASTA_KODU
WHERE h.CINSIYET = N'K' OR h.CINSIYET = N'KADIN' OR h.CINSIYET IS NULL
GROUP BY h.HASTA_KODU, b.HASTA_BASVURU_KODU;
GO

-- =============================================================================
-- 4. HASTA_SEVK - Bazi basvurular icin sevk
-- =============================================================================
INSERT INTO [Lbys].[HASTA_SEVK]
(HASTA_SEVK_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, SEVK_EDEN_BIRIM_KODU, SEVK_EDILEN_BIRIM_KODU, SEVK_TARIHI, SEVK_NEDENI, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 20
    N'SVK-' + CAST(ROW_NUMBER() OVER (ORDER BY HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    N'HASTA_SEVK',
    HASTA_KODU,
    HASTA_BASVURU_KODU,
    BIRIM_KODU,
    (SELECT TOP 1 BIRIM_KODU FROM [Lbys].[BIRIM] ORDER BY NEWID()),
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 90, GETDATE()),
    N'1',
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA_BASVURU] b
WHERE HASTA_BASVURU_KODU NOT IN (SELECT HASTA_BASVURU_KODU FROM [Lbys].[HASTA_SEVK]);
GO

-- =============================================================================
-- 5. HEMSIRE_BAKIM - Yatan hastalar icin bakim kaydi
-- =============================================================================
INSERT INTO [Lbys].[HEMSIRE_BAKIM]
(HEMSIRE_BAKIM_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, HEMSIRE_KODU, BIRIM_KODU, BAKIM_TARIHI, HEMSIRELIK_TANI_KODU, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 25
    N'HB-' + CAST(ROW_NUMBER() OVER (ORDER BY b.HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    N'HEMSIRE_BAKIM',
    b.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    (SELECT TOP 1 PERSONEL_KODU FROM [Lbys].[PERSONEL] ORDER BY NEWID()),
    b.BIRIM_KODU,
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 30, GETDATE()),
    N'1',
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA_BASVURU] b
WHERE b.BIRIM_KODU IS NOT NULL;
GO

-- =============================================================================
-- 6. RADYOLOJI - Radyoloji istekleri
-- =============================================================================
INSERT INTO [Lbys].[RADYOLOJI]
(RADYOLOJI_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, HEKIM_KODU, BIRIM_KODU, ISLEM_TARIHI, RADYOLOJI_TURU, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 25
    N'RAD-' + CAST(ROW_NUMBER() OVER (ORDER BY b.HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    N'RADYOLOJI',
    b.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    b.HEKIM_KODU,
    b.BIRIM_KODU,
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 60, GETDATE()),
    N'RONTGEN',
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA_BASVURU] b
WHERE b.HEKIM_KODU IS NOT NULL;
GO

-- =============================================================================
-- 7. PATOLOJI - Patoloji istekleri
-- =============================================================================
INSERT INTO [Lbys].[PATOLOJI]
(PATOLOJI_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, HEKIM_KODU, BIRIM_KODU, ISLEM_TARIHI, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 20
    N'PAT-' + CAST(ROW_NUMBER() OVER (ORDER BY b.HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    N'PATOLOJI',
    b.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    b.HEKIM_KODU,
    b.BIRIM_KODU,
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 90, GETDATE()),
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA_BASVURU] b
WHERE b.HEKIM_KODU IS NOT NULL;
GO

-- =============================================================================
-- 8. HASTA_MALZEME - Kullanilan malzemeler
-- =============================================================================
INSERT INTO [Lbys].[HASTA_MALZEME]
(HASTA_MALZEME_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, STOK_KART_KODU, MIKTAR, BIRIM_FIYAT, HIZMET_FATURA_DURUMU, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 25
    N'HM-' + CAST(ROW_NUMBER() OVER (ORDER BY b.HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    N'HASTA_MALZEME',
    b.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    (SELECT TOP 1 STOK_KART_KODU FROM [Lbys].[STOK_KART] ORDER BY NEWID()),
    1,
    100.00,
    N'1',
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA_BASVURU] b;
GO

-- =============================================================================
-- 9. ANLIK_YATAN_HASTA - Yatan hastalar
-- =============================================================================
INSERT INTO [Lbys].[ANLIK_YATAN_HASTA]
(ANLIK_YATAN_HASTA_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, HEKIM_KODU, YATIS_PROTOKOL_NUMARASI, BIRIM_KODU, YATIS_ZAMANI)
SELECT TOP 20
    N'AYH-' + CAST(ROW_NUMBER() OVER (ORDER BY b.HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    N'ANLIK_YATAN_HASTA',
    b.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    b.HEKIM_KODU,
    N'YP-' + CAST(ROW_NUMBER() OVER (ORDER BY b.HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    b.BIRIM_KODU,
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 10, GETDATE())
FROM [Lbys].[HASTA_BASVURU] b
WHERE b.HEKIM_KODU IS NOT NULL AND b.BIRIM_KODU IS NOT NULL;
GO

-- =============================================================================
-- 10. VEZNE - Odeme kayitlari
-- =============================================================================
INSERT INTO [Lbys].[VEZNE]
(VEZNE_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, ISLEM_TURU, TUTAR, ODEME_TARIHI, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 25
    N'VZN-' + CAST(ROW_NUMBER() OVER (ORDER BY b.HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    N'VEZNE',
    b.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    N'TAHSILAT',
    CAST(ABS(CHECKSUM(NEWID())) % 500 + 50 AS DECIMAL(18,2)),
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 30, GETDATE()),
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA_BASVURU] b;
GO

-- =============================================================================
-- 11. STOK_HAREKET - Stok hareketleri
-- =============================================================================
INSERT INTO [Lbys].[STOK_HAREKET]
(STOK_HAREKET_KODU, REFERANS_TABLO_ADI, STOK_KART_KODU, DEPO_KODU, HAREKET_TARIHI, HAREKET_TURU, MIKTAR, BIRIM_FIYAT, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 25
    N'SH-' + CAST(ROW_NUMBER() OVER (ORDER BY s.STOK_KART_KODU) AS NVARCHAR(10)),
    N'STOK_HAREKET',
    s.STOK_KART_KODU,
    (SELECT TOP 1 DEPO_KODU FROM [Lbys].[DEPO] ORDER BY NEWID()),
    DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 60, GETDATE()),
    N'GIRIS',
    ABS(CHECKSUM(NEWID())) % 100 + 1,
    CAST(ABS(CHECKSUM(NEWID())) % 100 + 10 AS DECIMAL(18,2)),
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[STOK_KART] s;
GO

-- =============================================================================
-- 12. HASTA_DIS - Dis muayene kayitlari
-- =============================================================================
INSERT INTO [Lbys].[HASTA_DIS]
(HASTA_DIS_KODU, REFERANS_TABLO_ADI, HASTA_KODU, HASTA_BASVURU_KODU, DIS_ISLEM_TURU, MEVCUT_DIS_DURUMU, DIS_KODU, CENE_BOLGESI, KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU)
SELECT TOP 20
    N'HD-' + CAST(ROW_NUMBER() OVER (ORDER BY b.HASTA_BASVURU_KODU) AS NVARCHAR(10)),
    N'HASTA_DIS',
    b.HASTA_KODU,
    b.HASTA_BASVURU_KODU,
    N'1',
    N'1',
    N'1',
    N'1',
    GETDATE(),
    N'SYSTEM'
FROM [Lbys].[HASTA_BASVURU] b;
GO

PRINT 'Demo veri seed islemi tamamlandi!';
GO
