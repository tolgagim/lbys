-- =====================================================
-- LBYS Kalan Tablolar Seed Data Script - PART 2
-- Level 2 ve Level 3 Tablolar
-- =====================================================

USE TESTDATA;
GO

SET NOCOUNT ON;
GO

PRINT '=== LEVEL 2 TABLOLAR BASLIYOR ===';

-- 9. AMELIYAT_ISLEM (30 kayit) - AMELIYAT'a bagli
IF NOT EXISTS (SELECT 1 FROM AMELIYAT_ISLEM WHERE AMELIYAT_ISLEM_KODU LIKE 'AMI-SEED-%')
BEGIN
    PRINT 'AMELIYAT_ISLEM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @ameliyatKodu NVARCHAR(50);
    DECLARE @hastaHizmetKodu NVARCHAR(50);

    SELECT TOP 1 @hastaHizmetKodu = HASTA_HIZMET_KODU FROM HASTA_HIZMET;

    WHILE @i <= 30
    BEGIN
        SET @ameliyatKodu = 'AML-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM AMELIYAT WHERE AMELIYAT_KODU = @ameliyatKodu)
        BEGIN
            INSERT INTO AMELIYAT_ISLEM (
                AMELIYAT_ISLEM_KODU, AMELIYAT_KODU, AMELIYAT_GRUBU, HASTA_HIZMET_KODU, KESI_SAYISI,
                KESI_ORANI, KESI_SEANS_BILGISI, TARAF_BILGISI, KOMPLIKASYON, AMELIYAT_SONUCU,
                AMELIYAT_NOTU, ASA_SKORU, EUROSCORE, YARA_SINIFI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'AMI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @ameliyatKodu,
                CASE @i % 5 WHEN 0 THEN 'A1' WHEN 1 THEN 'A2' WHEN 2 THEN 'B1' WHEN 3 THEN 'B2' ELSE 'C1' END,
                @hastaHizmetKodu,
                CAST(1 + (@i % 3) AS NVARCHAR(5)),
                'KESI_ORANI_TAM',
                'KESI_SEANS_TEK',
                CASE @i % 3 WHEN 0 THEN 'TARAF_SAG' WHEN 1 THEN 'TARAF_SOL' ELSE 'TARAF_BILATERAL' END,
                'Komplikasyon gözlenmedi',
                CASE @i % 3 WHEN 0 THEN 'Başarılı' WHEN 1 THEN 'Takip gerekli' ELSE 'Sorunsuz' END,
                'Ameliyat notu: İşlem ' + CAST(@i AS NVARCHAR(5)) + ' sorunsuz tamamlandı.',
                CASE @i % 2 WHEN 0 THEN 'ASA_1' ELSE 'ASA_2' END,
                'EUROSCORE_DUSUK',
                'YARA_TEMIZ',
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'AMELIYAT_ISLEM: 30 kayit eklendi.';
END;
GO

-- 10. AMELIYAT_EKIP (60 kayit) - Her ameliyat icin 2 personel
IF NOT EXISTS (SELECT 1 FROM AMELIYAT_EKIP WHERE AMELIYAT_EKIP_KODU LIKE 'AEK-SEED-%')
BEGIN
    PRINT 'AMELIYAT_EKIP tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @ekipNo INT = 1;
    DECLARE @ameliyatKodu NVARCHAR(50);
    DECLARE @ameliyatIslemKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        SET @ameliyatKodu = 'AML-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);
        SET @ameliyatIslemKodu = 'AMI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM AMELIYAT WHERE AMELIYAT_KODU = @ameliyatKodu) AND
           EXISTS (SELECT 1 FROM AMELIYAT_ISLEM WHERE AMELIYAT_ISLEM_KODU = @ameliyatIslemKodu)
        BEGIN
            -- Cerrah
            INSERT INTO AMELIYAT_EKIP (
                AMELIYAT_EKIP_KODU, AMELIYAT_KODU, AMELIYAT_ISLEM_KODU, EKIP_NUMARASI, PERSONEL_KODU,
                AMELIYAT_PERSONEL_GOREV, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'AEK-SEED-' + RIGHT('00000' + CAST(@ekipNo AS NVARCHAR(5)), 5),
                @ameliyatKodu,
                @ameliyatIslemKodu,
                '1',
                @personelKodu,
                'GOREV_CERRAH',
                'KLN-ADMIN',
                GETDATE()
            );
            SET @ekipNo = @ekipNo + 1;

            -- Hemsire
            INSERT INTO AMELIYAT_EKIP (
                AMELIYAT_EKIP_KODU, AMELIYAT_KODU, AMELIYAT_ISLEM_KODU, EKIP_NUMARASI, PERSONEL_KODU,
                AMELIYAT_PERSONEL_GOREV, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'AEK-SEED-' + RIGHT('00000' + CAST(@ekipNo AS NVARCHAR(5)), 5),
                @ameliyatKodu,
                @ameliyatIslemKodu,
                '2',
                @personelKodu,
                'GOREV_HEMSIRE',
                'KLN-ADMIN',
                GETDATE()
            );
            SET @ekipNo = @ekipNo + 1;
        END;
        SET @i = @i + 1;
    END;
    PRINT 'AMELIYAT_EKIP: 60 kayit eklendi.';
END;
GO

-- 11. RECETE_ILAC (60 kayit) - Her recete icin 2 ilac
IF NOT EXISTS (SELECT 1 FROM RECETE_ILAC WHERE RECETE_ILAC_KODU LIKE 'RCI-SEED-%')
BEGIN
    PRINT 'RECETE_ILAC tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @ilacNo INT = 1;
    DECLARE @receteKodu NVARCHAR(50);

    WHILE @i <= 30
    BEGIN
        SET @receteKodu = 'RCT-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM RECETE WHERE RECETE_KODU = @receteKodu)
        BEGIN
            -- Ilac 1
            INSERT INTO RECETE_ILAC (
                RECETE_ILAC_KODU, RECETE_KODU, DOZ_BIRIM, BARKOD, ILAC_ADI, KUTU_ADETI,
                ILAC_KULLANIM_SEKLI, ILAC_KULLANIM_SAYISI, ILAC_KULLANIM_DOZU, ILAC_KULLANIM_PERIYODU,
                ILAC_KULLANIM_PERIYODU_BIRIMI, ILAC_ACIKLAMA, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'RCI-SEED-' + RIGHT('00000' + CAST(@ilacNo AS NVARCHAR(5)), 5),
                @receteKodu,
                'DOZ_BIRIM_MG',
                'BC-ILC-' + RIGHT('00000000' + CAST(@ilacNo AS NVARCHAR(8)), 8),
                CASE @i % 5 WHEN 0 THEN 'Parol 500mg' WHEN 1 THEN 'Augmentin 1000mg' WHEN 2 THEN 'Majezik 100mg' WHEN 3 THEN 'Nurofen 400mg' ELSE 'Cipro 500mg' END,
                CAST(1 + (@i % 3) AS NVARCHAR(3)),
                'KULLANIM_ORAL',
                '2',
                '1',
                '7',
                'PERIYOT_GUN',
                'Yemeklerden sonra alınmalıdır.',
                'KLN-ADMIN',
                GETDATE()
            );
            SET @ilacNo = @ilacNo + 1;

            -- Ilac 2
            INSERT INTO RECETE_ILAC (
                RECETE_ILAC_KODU, RECETE_KODU, DOZ_BIRIM, BARKOD, ILAC_ADI, KUTU_ADETI,
                ILAC_KULLANIM_SEKLI, ILAC_KULLANIM_SAYISI, ILAC_KULLANIM_DOZU, ILAC_KULLANIM_PERIYODU,
                ILAC_KULLANIM_PERIYODU_BIRIMI, ILAC_ACIKLAMA, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'RCI-SEED-' + RIGHT('00000' + CAST(@ilacNo AS NVARCHAR(5)), 5),
                @receteKodu,
                'DOZ_BIRIM_ML',
                'BC-ILC-' + RIGHT('00000000' + CAST(@ilacNo AS NVARCHAR(8)), 8),
                CASE @i % 4 WHEN 0 THEN 'Ventolin İnhaler' WHEN 1 THEN 'Gaviscon Şurup' WHEN 2 THEN 'Sudafed Şurup' ELSE 'Tylol Hot' END,
                '1',
                CASE @i % 2 WHEN 0 THEN 'KULLANIM_ORAL' ELSE 'KULLANIM_IV' END,
                '3',
                '5',
                '5',
                'PERIYOT_GUN',
                'Gerektiğinde kullanılacak.',
                'KLN-ADMIN',
                GETDATE()
            );
            SET @ilacNo = @ilacNo + 1;
        END;
        SET @i = @i + 1;
    END;
    PRINT 'RECETE_ILAC: 60 kayit eklendi.';
END;
GO

-- 12. RECETE_ILAC_ACIKLAMA (30 kayit)
IF NOT EXISTS (SELECT 1 FROM RECETE_ILAC_ACIKLAMA WHERE RECETE_ILAC_ACIKLAMA_KODU LIKE 'RIA-SEED-%')
BEGIN
    PRINT 'RECETE_ILAC_ACIKLAMA tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @receteIlacKodu NVARCHAR(50);
    DECLARE @receteKodu NVARCHAR(50);

    WHILE @i <= 30
    BEGIN
        SET @receteIlacKodu = 'RCI-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);
        SET @receteKodu = 'RCT-SEED-' + RIGHT('00000' + CAST(((@i - 1) / 2) + 1 AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM RECETE_ILAC WHERE RECETE_ILAC_KODU = @receteIlacKodu)
        BEGIN
            INSERT INTO RECETE_ILAC_ACIKLAMA (
                RECETE_ILAC_ACIKLAMA_KODU, RECETE_ILAC_KODU, RECETE_KODU, ACIKLAMA,
                EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'RIA-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @receteIlacKodu,
                @receteKodu,
                'İlaç açıklaması: ' + CASE @i % 3 WHEN 0 THEN 'Aç karnına alınmamalı.' WHEN 1 THEN 'Süt ile birlikte alınabilir.' ELSE 'Alkol ile birlikte alınmamalı.' END,
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'RECETE_ILAC_ACIKLAMA: 30 kayit eklendi.';
END;
GO

-- 13. KAN_STOK (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KAN_STOK WHERE KAN_STOK_KODU LIKE 'KST-SEED-%')
BEGIN
    PRINT 'KAN_STOK tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @bagisciKodu NVARCHAR(50);
    DECLARE @birimKodu NVARCHAR(50);
    DECLARE @kurumKodu NVARCHAR(50);
    DECLARE @kanUrunKodu NVARCHAR(50);

    SELECT TOP 1 @birimKodu = BIRIM_KODU FROM BIRIM;
    SELECT TOP 1 @kurumKodu = KURUM_KODU FROM KURUM;
    SELECT TOP 1 @kanUrunKodu = KAN_URUN_KODU FROM KAN_URUN;

    WHILE @i <= 30
    BEGIN
        SET @bagisciKodu = 'KBG-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM KAN_BAGISCI WHERE KAN_BAGISCI_KODU = @bagisciKodu)
        BEGIN
            INSERT INTO KAN_STOK (
                KAN_STOK_KODU, KAN_STOK_DURUMU, KAN_STOK_GIRIS_TARIHI, DEFTER_NUMARASI, KAN_GRUBU,
                KAN_URUN_KODU, KAN_BAGISCI_KODU, KURUM_KODU, BIRIM_KODU, BAGLI_KAN_STOK_KODU,
                ISBT_UNITE_NUMARASI, ISBT_BILESEN_NUMARASI, KAN_HACIM, KAN_BAGIS_ZAMANI,
                SON_KULLANMA_TARIHI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'KST-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                'KAN_STOK_MEVCUT',
                DATEADD(DAY, -@i, GETDATE()),
                'KS-DEF-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                CASE @i % 4 WHEN 0 THEN 'KAN_GRUBU_A_RH_POZ' WHEN 1 THEN 'KAN_GRUBU_B_RH_POZ' WHEN 2 THEN 'KAN_GRUBU_0_RH_POZ' ELSE 'KAN_GRUBU_AB_RH_POZ' END,
                @kanUrunKodu,
                @bagisciKodu,
                @kurumKodu,
                @birimKodu,
                'KST-SEED-' + RIGHT('00000' + CAST((@i % 10) + 1 AS NVARCHAR(5)), 5),
                'ISBT-' + RIGHT('00000000' + CAST(10000000 + @i AS NVARCHAR(8)), 8),
                'BLS-' + RIGHT('0000' + CAST(@i AS NVARCHAR(4)), 4),
                CAST(400 + (@i * 10) AS NVARCHAR(5)),
                DATEADD(DAY, -@i, GETDATE()),
                DATEADD(DAY, 35 - @i, GETDATE()),
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'KAN_STOK: 30 kayit eklendi.';
END;
GO

-- 14. KAN_TALEP_DETAY (30 kayit)
IF NOT EXISTS (SELECT 1 FROM KAN_TALEP_DETAY WHERE KAN_TALEP_DETAY_KODU LIKE 'KTD-SEED-%')
BEGIN
    PRINT 'KAN_TALEP_DETAY tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @kanTalepKodu NVARCHAR(50);
    DECLARE @kanUrunKodu NVARCHAR(50);
    DECLARE @kullaniciKodu NVARCHAR(50);

    SELECT TOP 1 @kanUrunKodu = KAN_URUN_KODU FROM KAN_URUN;
    SELECT TOP 1 @kullaniciKodu = KULLANICI_KODU FROM KULLANICI;

    WHILE @i <= 30
    BEGIN
        SET @kanTalepKodu = 'KTL-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM KAN_TALEP WHERE KAN_TALEP_KODU = @kanTalepKodu)
        BEGIN
            INSERT INTO KAN_TALEP_DETAY (
                KAN_TALEP_DETAY_KODU, KAN_TALEP_KODU, KAN_URUN_KODU, ISTENEN_KAN_GRUBU, RET_TARIHI,
                RET_EDEN_KULLANICI_KODU, KAN_TALEP_RET_NEDENI, KAN_TALEP_MIKTARI, KAN_HACIM, ACIKLAMA,
                EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'KTD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @kanTalepKodu,
                @kanUrunKodu,
                CASE @i % 4 WHEN 0 THEN 'KAN_GRUBU_A_RH_POZ' WHEN 1 THEN 'KAN_GRUBU_B_RH_POZ' WHEN 2 THEN 'KAN_GRUBU_0_RH_POZ' ELSE 'KAN_GRUBU_AB_RH_POZ' END,
                DATEADD(DAY, -@i + 5, GETDATE()),
                @kullaniciKodu,
                CASE @i % 5 WHEN 0 THEN 'KAN_RET_STOK_YOK' ELSE NULL END,
                CAST(1 + (@i % 4) AS NVARCHAR(3)),
                CAST(450 AS NVARCHAR(5)),
                'Talep detay açıklaması ' + CAST(@i AS NVARCHAR(5)),
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'KAN_TALEP_DETAY: 30 kayit eklendi.';
END;
GO

-- 15. RADYOLOJI_SONUC (30 kayit)
IF NOT EXISTS (SELECT 1 FROM RADYOLOJI_SONUC WHERE RADYOLOJI_SONUC_KODU LIKE 'RAS-SEED-%')
BEGIN
    PRINT 'RADYOLOJI_SONUC tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @radyolojiKodu NVARCHAR(50);
    DECLARE @personelKodu NVARCHAR(50);

    SELECT TOP 1 @personelKodu = PERSONEL_KODU FROM PERSONEL;

    WHILE @i <= 30
    BEGIN
        SET @radyolojiKodu = 'RAD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM RADYOLOJI WHERE RADYOLOJI_KODU = @radyolojiKodu)
        BEGIN
            INSERT INTO RADYOLOJI_SONUC (
                RADYOLOJI_SONUC_KODU, RADYOLOJI_KODU, TETKIK_SONUCU_METIN, RADYOLOJI_TETKIK_SONUCU,
                RADYOLOJI_RAPOR_FORMATI, RAPOR_TIPI, RAPOR_YAZAN_PERSONEL_KODU, ONAYLAYAN_PERSONEL_KODU_1,
                ONAYLAYAN_PERSONEL_KODU_2, ONAYLAYAN_PERSONEL_KODU_3, RAPOR_UZMAN_ONAY_ZAMANI,
                RAPOR_KAYIT_ZAMANI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'RAS-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @radyolojiKodu,
                'Tetkik sonucu metin: ' + CASE @i % 3 WHEN 0 THEN 'Normal bulgular.' WHEN 1 THEN 'Patolojik bulgu saptanmadı.' ELSE 'Ek inceleme önerilir.' END,
                CASE @i % 4 WHEN 0 THEN 'Normal' WHEN 1 THEN 'Patolojik' WHEN 2 THEN 'Sınırda' ELSE 'Takip Önerilir' END,
                'RAPOR_FORMAT_METIN',
                'RAPOR_TIP_ANA',
                @personelKodu,
                @personelKodu,
                @personelKodu,
                @personelKodu,
                DATEADD(DAY, -@i, DATEADD(HOUR, 14, GETDATE())),
                DATEADD(DAY, -@i, DATEADD(HOUR, 12, GETDATE())),
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'RADYOLOJI_SONUC: 30 kayit eklendi.';
END;
GO

-- 16. VEZNE_DETAY (30 kayit)
IF NOT EXISTS (SELECT 1 FROM VEZNE_DETAY WHERE VEZNE_DETAY_KODU LIKE 'VZD-SEED-%')
BEGIN
    PRINT 'VEZNE_DETAY tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @vezneKodu NVARCHAR(50);
    DECLARE @hastaHizmetKodu NVARCHAR(50);
    DECLARE @hastaMalzemeKodu NVARCHAR(50);

    SELECT TOP 1 @hastaHizmetKodu = HASTA_HIZMET_KODU FROM HASTA_HIZMET;
    SELECT TOP 1 @hastaMalzemeKodu = HASTA_MALZEME_KODU FROM HASTA_MALZEME;

    -- Eger HASTA_MALZEME bossa dummy deger kullanalim
    IF @hastaMalzemeKodu IS NULL SET @hastaMalzemeKodu = 'HM-SEED-00001';

    WHILE @i <= 30
    BEGIN
        SET @vezneKodu = 'VZN-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM VEZNE WHERE VEZNE_KODU = @vezneKodu)
        BEGIN
            INSERT INTO VEZNE_DETAY (
                VEZNE_DETAY_KODU, VEZNE_KODU, HASTA_HIZMET_KODU, HASTA_MALZEME_KODU, BUTCE_KODU,
                MAKBUZ_KALEM_TUTARI, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'VZD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @vezneKodu,
                @hastaHizmetKodu,
                @hastaMalzemeKodu,
                'BTC-' + RIGHT('000' + CAST(@i AS NVARCHAR(3)), 3),
                CAST(50 + (@i * 25) AS NVARCHAR(10)),
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'VEZNE_DETAY: 30 kayit eklendi.';
END;
GO

-- 17. DOGUM (30 kayit)
IF NOT EXISTS (SELECT 1 FROM DOGUM WHERE DOGUM_KODU LIKE 'DGM-SEED-%')
BEGIN
    PRINT 'DOGUM tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);
    DECLARE @hastaHizmetKodu NVARCHAR(50);
    DECLARE @ameliyatKodu NVARCHAR(50);
    DECLARE @hekimKodu NVARCHAR(50);
    DECLARE @ebeKodu NVARCHAR(50);
    DECLARE @birimKodu NVARCHAR(50);
    DECLARE @kullaniciKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;
    SELECT TOP 1 @hastaHizmetKodu = HASTA_HIZMET_KODU FROM HASTA_HIZMET;
    SELECT TOP 1 @hekimKodu = PERSONEL_KODU FROM PERSONEL;
    SELECT TOP 1 @ebeKodu = PERSONEL_KODU FROM PERSONEL;
    SELECT TOP 1 @birimKodu = BIRIM_KODU FROM BIRIM;
    SELECT TOP 1 @kullaniciKodu = KULLANICI_KODU FROM KULLANICI;

    WHILE @i <= 30
    BEGIN
        SET @ameliyatKodu = 'AML-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        INSERT INTO DOGUM (
            DOGUM_KODU, HASTA_KODU, HASTA_BASVURU_KODU, HASTA_HIZMET_KODU, AMELIYAT_KODU,
            BABA_TC_KIMLIK_NUMARASI, KOMPLIKASYON_TANISI, DOGUM_NOTU, DOGUM_BASLAMA_ZAMANI,
            DOGUM_BITIS_ZAMANI, HEKIM_KODU, EBE_KODU, BIRIM_KODU, DEFTER_NUMARASI,
            GUNCELLEYEN_KULLANICI_KODU, EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
        )
        VALUES (
            'DGM-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @hastaKodu,
            @basvuruKodu,
            @hastaHizmetKodu,
            @ameliyatKodu,
            '2' + RIGHT('0000000000' + CAST(20000000000 + @i AS NVARCHAR(11)), 10),
            'KOMPLIKASYON_YOK',
            'Doğum notu: İşlem ' + CAST(@i AS NVARCHAR(5)) + ' sorunsuz gerçekleşti.',
            DATEADD(DAY, -@i, DATEADD(HOUR, 6, GETDATE())),
            DATEADD(DAY, -@i, DATEADD(HOUR, 12, GETDATE())),
            @hekimKodu,
            @ebeKodu,
            @birimKodu,
            'DGM-DEF-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
            @kullaniciKodu,
            'KLN-ADMIN',
            GETDATE()
        );
        SET @i = @i + 1;
    END;
    PRINT 'DOGUM: 30 kayit eklendi.';
END;
GO

-- 18. DOGUM_DETAY (30 kayit)
IF NOT EXISTS (SELECT 1 FROM DOGUM_DETAY WHERE DOGUM_DETAY_KODU LIKE 'DGD-SEED-%')
BEGIN
    PRINT 'DOGUM_DETAY tablosu seed ediliyor...';

    DECLARE @i INT = 1;
    DECLARE @dogumKodu NVARCHAR(50);
    DECLARE @hastaKodu NVARCHAR(50);
    DECLARE @basvuruKodu NVARCHAR(50);

    SELECT TOP 1 @hastaKodu = HASTA_KODU FROM HASTA;
    SELECT TOP 1 @basvuruKodu = HASTA_BASVURU_KODU FROM HASTA_BASVURU;

    WHILE @i <= 30
    BEGIN
        SET @dogumKodu = 'DGM-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5);

        IF EXISTS (SELECT 1 FROM DOGUM WHERE DOGUM_KODU = @dogumKodu)
        BEGIN
            INSERT INTO DOGUM_DETAY (
                DOGUM_DETAY_KODU, HASTA_KODU, HASTA_BASVURU_KODU, DOGUM_KODU, DOGUM_ZAMANI,
                CINSIYET, DOGUM_YONTEMI, AGIRLIK, BOY, BAS_CEVRESI, APGAR_1, APGAR_5, APGAR_NOTU,
                KOMPLIKASYON_TANISI, DOGUM_SIRASI, GOGUS_CEVRESI, PROGNOZ_BILGISI, SURMATURE_BILGISI,
                K_VITAMINI_UYGULANMA_DURUMU, BEBEGIN_HEPATIT_ASI_DURUMU, YENIDOGAN_ISITME_TARAMA_DURUMU,
                ILK_BESLENME_ZAMANI, TOPUK_KANI, TOPUK_KANI_ALINMA_ZAMANI, BEBEK_ADI,
                BABA_TC_KIMLIK_NUMARASI, BEBEGIN_YASAM_DURUMU, SEZARYEN_ENDIKASYONLAR, ROBSON_GRUBU,
                EKLEYEN_KULLANICI_KODU, KAYIT_ZAMANI
            )
            VALUES (
                'DGD-SEED-' + RIGHT('00000' + CAST(@i AS NVARCHAR(5)), 5),
                @hastaKodu,
                @basvuruKodu,
                @dogumKodu,
                DATEADD(DAY, -@i, DATEADD(HOUR, 10, GETDATE())),
                CASE @i % 2 WHEN 0 THEN 'CINSIYET_ERKEK' ELSE 'CINSIYET_KADIN' END,
                CASE @i % 2 WHEN 0 THEN 'DOGUM_NORMAL' ELSE 'DOGUM_SEZARYEN' END,
                CAST(2800 + (@i * 50) AS NVARCHAR(5)),
                CAST(48 + (@i % 5) AS NVARCHAR(3)),
                CAST(33 + (@i % 4) AS NVARCHAR(3)),
                CAST(7 + (@i % 3) AS NVARCHAR(2)),
                CAST(8 + (@i % 2) AS NVARCHAR(2)),
                'APGAR değerlendirmesi: Normal',
                'KOMPLIKASYON_YOK',
                CAST(1 + (@i % 3) AS NVARCHAR(2)),
                CAST(32 + (@i % 3) AS NVARCHAR(3)),
                'PROGNOZ_IYI',
                'SURMATURE_YOK',
                'K_VIT_UYGULANDI',
                'HEPATIT_YAPILDI',
                'ISITME_NORMAL',
                DATEADD(DAY, -@i, DATEADD(HOUR, 12, GETDATE())),
                'TOPUK_ALINDI',
                DATEADD(DAY, -@i + 3, GETDATE()),
                CASE @i % 5 WHEN 0 THEN 'Bebek Ali' WHEN 1 THEN 'Bebek Ayşe' WHEN 2 THEN 'Bebek Mehmet' WHEN 3 THEN 'Bebek Zeynep' ELSE 'Bebek Can' END,
                '2' + RIGHT('0000000000' + CAST(20000000000 + @i AS NVARCHAR(11)), 10),
                'BEBEK_CANLI',
                'SEZARYEN_YOK',
                'ROBSON_1',
                'KLN-ADMIN',
                GETDATE()
            );
        END;
        SET @i = @i + 1;
    END;
    PRINT 'DOGUM_DETAY: 30 kayit eklendi.';
END;
GO

PRINT '=== LEVEL 2 TABLOLAR TAMAMLANDI ===';
GO
