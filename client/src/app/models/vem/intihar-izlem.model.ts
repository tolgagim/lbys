// IntiharIzlem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface IntiharIzlemDto extends VemBaseDto {
  intiharIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  intiharKrizVakaTuru: string;
  intiharGirisimKrizNedenleri: string;
  intiharGirisimiYontemi: string;
  intiharKrizVakaSonucu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListIntiharIzlemDto {
  id: string;
  intiharIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  intiharKrizVakaTuru: string;
  intiharGirisimKrizNedenleri: string;
  intiharGirisimiYontemi: string;
  intiharKrizVakaSonucu: string;
}

export interface CreateIntiharIzlemDto {
  intiharIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  intiharKrizVakaTuru: string;
  intiharGirisimKrizNedenleri: string;
  intiharGirisimiYontemi: string;
  intiharKrizVakaSonucu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateIntiharIzlemDto extends CreateIntiharIzlemDto {
  id: string;
}

export interface IntiharIzlemListFilter extends BaseListFilter {
  intiharIzlemKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  intiharKrizVakaTuru?: string;
}

export const newIntiharIzlem: CreateIntiharIzlemDto = {
  intiharIzlemKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  intiharKrizVakaTuru: '',
  intiharGirisimKrizNedenleri: '',
  intiharGirisimiYontemi: '',
  intiharKrizVakaSonucu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
