// SterilizasyonYikama Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SterilizasyonYikamaDto extends VemBaseDto {
  sterilizasyonYikamaKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  yikananAletMiktari: string;
  sterilizasyonYikamaTuru: string;
  yikamaYapanPersonelKodu: string;
  yikamaBaslamaZamani?: Date;
  yikamaBitisZamani: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSterilizasyonYikamaDto {
  id: string;
  sterilizasyonYikamaKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  yikananAletMiktari: string;
  sterilizasyonYikamaTuru: string;
  yikamaYapanPersonelKodu: string;
  yikamaBaslamaZamani?: Date;
}

export interface CreateSterilizasyonYikamaDto {
  sterilizasyonYikamaKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  yikananAletMiktari: string;
  sterilizasyonYikamaTuru: string;
  yikamaYapanPersonelKodu: string;
  yikamaBaslamaZamani?: Date;
  yikamaBitisZamani: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSterilizasyonYikamaDto extends CreateSterilizasyonYikamaDto {
  id: string;
}

export interface SterilizasyonYikamaListFilter extends BaseListFilter {
  sterilizasyonYikamaKodu?: string;
  referansTabloAdi?: string;
  depoKodu?: string;
  stokKartKodu?: string;
  yikananAletMiktari?: string;
}

export const newSterilizasyonYikama: CreateSterilizasyonYikamaDto = {
  sterilizasyonYikamaKodu: '',
  referansTabloAdi: '',
  depoKodu: '',
  stokKartKodu: '',
  yikananAletMiktari: '',
  sterilizasyonYikamaTuru: '',
  yikamaYapanPersonelKodu: '',
  yikamaBaslamaZamani: undefined,
  yikamaBitisZamani: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
