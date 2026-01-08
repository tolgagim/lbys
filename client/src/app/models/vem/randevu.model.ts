// Randevu Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface RandevuDto extends VemBaseDto {
  randevuKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  randevuTuru?: string;
  randevuAltTuru?: string;
  randevuZamani?: Date;
  randevuKayitZamani?: Date;
  hastaHizmetKodu?: string;
  birimKodu?: string;
  hekimKodu?: string;
  mhrsHrnKodu?: string;
  mhrsRandevuNotu?: string;
  randevuGelmeDurumu?: string;
  cihazKodu?: string;
  tcKimlikNumarasi?: string;
  ad?: string;
  soyadi?: string;
  cinsiyet?: string;
  telefonNumarasi?: string;
  iptalDurumu?: string;
  iptalEdenKullaniciKodu?: string;
  iptalZamani?: Date;
  iptalAciklama?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListRandevuDto {
  id: string;
  randevuKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  randevuTuru?: string;
  randevuAltTuru?: string;
  randevuZamani?: Date;
  randevuKayitZamani?: Date;
  hastaHizmetKodu?: string;
}

export interface CreateRandevuDto {
  randevuKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  randevuTuru?: string;
  randevuAltTuru?: string;
  randevuZamani?: Date;
  randevuKayitZamani?: Date;
  hastaHizmetKodu?: string;
  birimKodu?: string;
  hekimKodu?: string;
  mhrsHrnKodu?: string;
  mhrsRandevuNotu?: string;
  randevuGelmeDurumu?: string;
  cihazKodu?: string;
  tcKimlikNumarasi?: string;
  ad?: string;
  soyadi?: string;
  cinsiyet?: string;
  telefonNumarasi?: string;
  iptalDurumu?: string;
  iptalEdenKullaniciKodu?: string;
  iptalZamani?: Date;
  iptalAciklama?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateRandevuDto extends CreateRandevuDto {
  id: string;
}

export interface RandevuListFilter extends BaseListFilter {
  randevuKodu?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  randevuTuru?: string;
  randevuAltTuru?: string;
}

export const newRandevu: CreateRandevuDto = {
  randevuKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  randevuTuru: '',
  randevuAltTuru: '',
  randevuZamani: undefined,
  randevuKayitZamani: undefined,
  hastaHizmetKodu: '',
  birimKodu: '',
  hekimKodu: '',
  mhrsHrnKodu: '',
  mhrsRandevuNotu: '',
  randevuGelmeDurumu: '',
  cihazKodu: '',
  tcKimlikNumarasi: '',
  ad: '',
  soyadi: '',
  cinsiyet: '',
  telefonNumarasi: '',
  iptalDurumu: '',
  iptalEdenKullaniciKodu: '',
  iptalZamani: undefined,
  iptalAciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
