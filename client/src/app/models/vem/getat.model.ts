// Getat Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface GetatDto extends VemBaseDto {
  getatKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  getatUygulamaBirimi: string;
  komplikasyonTanisi: string;
  getatTedaviSonucu: string;
  getatUygulamaTuru: string;
  getatUygulandigiDurumlar: string;
  getatUygulamaBolgesi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListGetatDto {
  id: string;
  getatKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  getatUygulamaBirimi: string;
  komplikasyonTanisi: string;
  getatTedaviSonucu: string;
  getatUygulamaTuru: string;
}

export interface CreateGetatDto {
  getatKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  getatUygulamaBirimi: string;
  komplikasyonTanisi: string;
  getatTedaviSonucu: string;
  getatUygulamaTuru: string;
  getatUygulandigiDurumlar: string;
  getatUygulamaBolgesi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateGetatDto extends CreateGetatDto {
  id: string;
}

export interface GetatListFilter extends BaseListFilter {
  getatKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  getatUygulamaBirimi?: string;
}

export const newGetat: CreateGetatDto = {
  getatKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  getatUygulamaBirimi: '',
  komplikasyonTanisi: '',
  getatTedaviSonucu: '',
  getatUygulamaTuru: '',
  getatUygulandigiDurumlar: '',
  getatUygulamaBolgesi: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
