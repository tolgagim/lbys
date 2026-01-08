// HastaMalzeme Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaMalzemeDto extends VemBaseDto {
  hastaMalzemeKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  stokKartKodu: string;
  stokHareketKodu: string;
  malzemeFaturaDurumu: string;
  islemZamani?: Date;
  islemGerceklesmeZamani?: Date;
  atsSorguNumarasi: string;
  allogreftDonorKodu: string;
  malzemeAdeti: string;
  faturaAdet: string;
  faturaKodu: string;
  faturaTutari: string;
  hastaTutari: string;
  kurumTutari: string;
  medulaTutari: string;
  medulaIslemSiraNumarasi: string;
  medulaHizmetRefNumarasi: string;
  sysReferansNumarasi: string;
  medulaTakipKodu: string;
  medulaOzelDurum: string;
  ameliyatKodu: string;
  isteyenHekimKodu: string;
  depoKodu: string;
  iptalDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaMalzemeDto {
  id: string;
  hastaMalzemeKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  stokKartKodu: string;
  stokHareketKodu: string;
  malzemeFaturaDurumu: string;
  islemZamani?: Date;
}

export interface CreateHastaMalzemeDto {
  hastaMalzemeKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  stokKartKodu: string;
  stokHareketKodu: string;
  malzemeFaturaDurumu: string;
  islemZamani?: Date;
  islemGerceklesmeZamani?: Date;
  atsSorguNumarasi: string;
  allogreftDonorKodu: string;
  malzemeAdeti: string;
  faturaAdet: string;
  faturaKodu: string;
  faturaTutari: string;
  hastaTutari: string;
  kurumTutari: string;
  medulaTutari: string;
  medulaIslemSiraNumarasi: string;
  medulaHizmetRefNumarasi: string;
  sysReferansNumarasi: string;
  medulaTakipKodu: string;
  medulaOzelDurum: string;
  ameliyatKodu: string;
  isteyenHekimKodu: string;
  depoKodu: string;
  iptalDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaMalzemeDto extends CreateHastaMalzemeDto {
  id: string;
}

export interface HastaMalzemeListFilter extends BaseListFilter {
  hastaMalzemeKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  stokKartKodu?: string;
}

export const newHastaMalzeme: CreateHastaMalzemeDto = {
  hastaMalzemeKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  stokKartKodu: '',
  stokHareketKodu: '',
  malzemeFaturaDurumu: '',
  islemZamani: undefined,
  islemGerceklesmeZamani: undefined,
  atsSorguNumarasi: '',
  allogreftDonorKodu: '',
  malzemeAdeti: '',
  faturaAdet: '',
  faturaKodu: '',
  faturaTutari: '',
  hastaTutari: '',
  kurumTutari: '',
  medulaTutari: '',
  medulaIslemSiraNumarasi: '',
  medulaHizmetRefNumarasi: '',
  sysReferansNumarasi: '',
  medulaTakipKodu: '',
  medulaOzelDurum: '',
  ameliyatKodu: '',
  isteyenHekimKodu: '',
  depoKodu: '',
  iptalDurumu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
