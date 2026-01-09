// Birim Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface BirimDto extends VemBaseDto {
  birimKodu: string;
  birimAdi: string;
  birimTuru?: string;
  ustBirimKodu?: string;
  kurumKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListBirimDto {
  id: string;
  birimKodu: string;
  birimAdi: string;
  birimTuru?: string;
  ustBirimKodu?: string;
  kurumKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
}

export interface CreateBirimDto {
  birimKodu: string;
  birimAdi: string;
  birimTuru?: string;
  ustBirimKodu?: string;
  kurumKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateBirimDto extends CreateBirimDto {
  id: string;
}

export interface BirimListFilter extends BaseListFilter {
  birimKodu?: string;
  birimAdi?: string;
  birimTuru?: string;
  ustBirimKodu?: string;
  kurumKodu?: string;
  AKTIFLIK_BILGISI?: string | null;
  BINA_KODU?: string | null;
  KLINIK_KODU?: string | null;
  MEDULA_BRANS_KODU?: string | null;
  MHRS_ADI?: string | null;
  MHRS_KODU?: string | null;
  MKYS_KODU?: string | null;
  YATAK_SAYISI?: number | null;
}

export const newBirim: CreateBirimDto = {
  birimKodu: '',
  birimAdi: '',
  birimTuru: '',
  ustBirimKodu: '',
  kurumKodu: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
