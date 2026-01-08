// HastaHizmet Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaHizmetDto extends VemBaseDto {
  hastaHizmetKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hizmetKodu?: string;
  dogumKodu?: string;
  ameliyatIslemKodu?: string;
  hastaHizmetDurumu?: string;
  hizmetFaturaDurumu?: string;
  tibbiIslemPuanBilgisi?: string;
  tarafBilgisi?: string;
  hizmetPuanBilgisi?: string;
  islemGerceklesmeZamani?: Date;
  puanHakedisZamani?: Date;
  islemZamani?: Date;
  randevuZamani?: Date;
  cihazKunyeNumarasi?: string;
  hizmetAdeti?: number;
  faturaAdet?: number;
  hastaTutari?: number;
  kurumTutari?: number;
  medulaTutari?: number;
  medulaIslemSiraNumarasi?: string;
  medulaHizmetRefNumarasi?: string;
  sysReferansNumarasi?: string;
  medulaTakipKodu?: string;
  medulaOzelDurum?: string;
  onaylayanHekimKodu?: string;
  isteyenHekimKodu?: string;
  faturaKodu?: string;
  faturaTutari?: number;
  isbtUniteNumarasi?: string;
  isbtBilesenNumarasi?: string;
  iptalDurumu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaHizmetDto {
  id: string;
  hastaHizmetKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hizmetKodu?: string;
  dogumKodu?: string;
  ameliyatIslemKodu?: string;
  hastaHizmetDurumu?: string;
  hizmetFaturaDurumu?: string;
}

export interface CreateHastaHizmetDto {
  hastaHizmetKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hizmetKodu?: string;
  dogumKodu?: string;
  ameliyatIslemKodu?: string;
  hastaHizmetDurumu?: string;
  hizmetFaturaDurumu?: string;
  tibbiIslemPuanBilgisi?: string;
  tarafBilgisi?: string;
  hizmetPuanBilgisi?: string;
  islemGerceklesmeZamani?: Date;
  puanHakedisZamani?: Date;
  islemZamani?: Date;
  randevuZamani?: Date;
  cihazKunyeNumarasi?: string;
  hizmetAdeti?: number;
  faturaAdet?: number;
  hastaTutari?: number;
  kurumTutari?: number;
  medulaTutari?: number;
  medulaIslemSiraNumarasi?: string;
  medulaHizmetRefNumarasi?: string;
  sysReferansNumarasi?: string;
  medulaTakipKodu?: string;
  medulaOzelDurum?: string;
  onaylayanHekimKodu?: string;
  isteyenHekimKodu?: string;
  faturaKodu?: string;
  faturaTutari?: number;
  isbtUniteNumarasi?: string;
  isbtBilesenNumarasi?: string;
  iptalDurumu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaHizmetDto extends CreateHastaHizmetDto {
  id: string;
}

export interface HastaHizmetListFilter extends BaseListFilter {
  hastaHizmetKodu?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hizmetKodu?: string;
  dogumKodu?: string;
}

export const newHastaHizmet: CreateHastaHizmetDto = {
  hastaHizmetKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  hizmetKodu: '',
  dogumKodu: '',
  ameliyatIslemKodu: '',
  hastaHizmetDurumu: '',
  hizmetFaturaDurumu: '',
  tibbiIslemPuanBilgisi: '',
  tarafBilgisi: '',
  hizmetPuanBilgisi: '',
  islemGerceklesmeZamani: undefined,
  puanHakedisZamani: undefined,
  islemZamani: undefined,
  randevuZamani: undefined,
  cihazKunyeNumarasi: '',
  hizmetAdeti: 0,
  faturaAdet: 0,
  hastaTutari: 0,
  kurumTutari: 0,
  medulaTutari: 0,
  medulaIslemSiraNumarasi: '',
  medulaHizmetRefNumarasi: '',
  sysReferansNumarasi: '',
  medulaTakipKodu: '',
  medulaOzelDurum: '',
  onaylayanHekimKodu: '',
  isteyenHekimKodu: '',
  faturaKodu: '',
  faturaTutari: 0,
  isbtUniteNumarasi: '',
  isbtBilesenNumarasi: '',
  iptalDurumu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
