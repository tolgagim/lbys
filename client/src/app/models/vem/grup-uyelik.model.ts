// GrupUyelik Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface GrupUyelikDto extends VemBaseDto {
  grupUyelikKodu: string;
  referansTabloAdi: string;
  kullaniciGrupKodu: string;
  kullaniciKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListGrupUyelikDto {
  id: string;
  grupUyelikKodu: string;
  referansTabloAdi: string;
  kullaniciGrupKodu: string;
  kullaniciKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface CreateGrupUyelikDto {
  grupUyelikKodu: string;
  referansTabloAdi: string;
  kullaniciGrupKodu: string;
  kullaniciKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateGrupUyelikDto extends CreateGrupUyelikDto {
  id: string;
}

export interface GrupUyelikListFilter extends BaseListFilter {
  grupUyelikKodu?: string;
  referansTabloAdi?: string;
  kullaniciGrupKodu?: string;
  kullaniciKodu?: string;
  ekleyenKullaniciKodu?: string;
}

export const newGrupUyelik: CreateGrupUyelikDto = {
  grupUyelikKodu: '',
  referansTabloAdi: '',
  kullaniciGrupKodu: '',
  kullaniciKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
