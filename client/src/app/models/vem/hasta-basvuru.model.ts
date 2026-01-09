// HastaBasvuru Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaBasvuruDto extends VemBaseDto {
  hastaBasvuruKodu: string;
  hastaKodu: string;
  basvuruTarihi: Date;
  basvuruTuru?: string;
  basvuruSekli?: string;
  birimKodu?: string;
  doktorKodu?: string;
  sikayet?: string;
  taniKodu?: string;
  tedaviTuru?: string;
  sevkEdenKurum?: string;
  provizyonTipi?: string;
  takipNo?: string;
  cikisTarihi?: Date;
  cikisSekli?: string;
  sonucKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaBasvuruDto {
  id: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  basvuruTarihi: Date;
  basvuruTuru?: string;
  basvuruSekli?: string;
  birimKodu?: string;
  doktorKodu?: string;
  sikayet?: string;
}

export interface CreateHastaBasvuruDto {
  hastaBasvuruKodu: string;
  hastaKodu: string;
  basvuruTarihi: Date;
  basvuruTuru?: string;
  basvuruSekli?: string;
  birimKodu?: string;
  doktorKodu?: string;
  sikayet?: string;
  taniKodu?: string;
  tedaviTuru?: string;
  sevkEdenKurum?: string;
  provizyonTipi?: string;
  takipNo?: string;
  cikisTarihi?: Date;
  cikisSekli?: string;
  sonucKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaBasvuruDto extends CreateHastaBasvuruDto {
  id: string;
}

export interface HastaBasvuruListFilter extends BaseListFilter {
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  basvuruTuru?: string;
  basvuruSekli?: string;
  birimKodu?: string;
  ADLI_VAKA_GELIS_SEKLI?: string | null;
  AMBULANS_PLAKA_NUMARASI?: string | null;
  AMBULANS_TAKIP_NUMARASI?: string | null;
  ARAC_TURU?: string | null;
  ASISTAN_HEKIM_KODU?: string | null;
  BAGLI_OLDUGU_BASVURU_KODU?: string | null;
  BASVURU_DURUMU?: string | null;
  BASVURU_PROTOKOL_NUMARASI?: string | null;
  CIKIS_VEREN_HEKIM_KODU?: string | null;
  CIKIS_ZAMANI?: Date | null;
  DEFTER_NUMARASI?: string | null;
  DIYABET_EGITIMI?: string | null;
  DIYABET_KOMPLIKASYONLARI?: string | null;
  GEBLIZ_BILDIRIM_NUMARASI?: string | null;
  GELDIGI_ULKE_KODU?: string | null;
  GENCLIK_SAGLIGI_ISLEMLERI?: string | null;
  GUNLUK_SIRA_NUMARASI?: string | null;
  HASTA_KABUL_ZAMANI?: Date | null;
  HAYATI_TEHLIKE_DURUMU?: string | null;
  HEKIM_BASVURU_NOTU?: string | null;
  HEKIM_KODU?: string | null;
  HIZMET_SUNUCU?: string | null;
  KABUL_SEKLI?: string | null;
  KAYIT_YERI?: string | null;
  KURUM_KODU?: string | null;
  MUAYENE_BASLAMA_ZAMANI?: Date | null;
  MUAYENE_BITIS_ZAMANI?: Date | null;
  MUAYENE_ONCELIK_SIRASI?: number | null;
  MUAYENE_TURU?: string | null;
  OLAY_AFET_KODU?: string | null;
  ONLINE_PROTOKOL_NUMARASI?: string | null;
  SAGLIK_TURIZMI_ULKE_KODU?: string | null;
  SEVK_TANISI?: string | null;
  SEVK_ZAMANI?: Date | null;
  SOSYAL_GUVENCE_DURUMU?: string | null;
  SYS_REFERANS_NUMARASI?: string | null;
  SYS_TAKIP_NUMARASI?: string | null;
  TAMAMLAYICI_KURUM_KODU?: string | null;
  TRIAJ_KODU?: string | null;
  VAKA_TURU?: string | null;
  YABANCI_HASTA_TURU?: string | null;
  YATIS_BILGISI?: string | null;
  YATIS_PROTOKOL_NUMARASI?: string | null;
}

export const newHastaBasvuru: CreateHastaBasvuruDto = {
  hastaBasvuruKodu: '',
  hastaKodu: '',
  basvuruTarihi: undefined,
  basvuruTuru: '',
  basvuruSekli: '',
  birimKodu: '',
  doktorKodu: '',
  sikayet: '',
  taniKodu: '',
  tedaviTuru: '',
  sevkEdenKurum: '',
  provizyonTipi: '',
  takipNo: '',
  cikisTarihi: undefined,
  cikisSekli: '',
  sonucKodu: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
