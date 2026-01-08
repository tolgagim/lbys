// SterilizasyonPaketDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SterilizasyonPaketDetayDto extends VemBaseDto {
  sterilizasyonPaketDetayKodu: string;
  referansTabloAdi: string;
  sterilizasyonPaketKodu: string;
  stokKartKodu: string;
  sterilizasyonMalzemeMiktari: string;
  olcuKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSterilizasyonPaketDetayDto {
  id: string;
  sterilizasyonPaketDetayKodu: string;
  referansTabloAdi: string;
  sterilizasyonPaketKodu: string;
  stokKartKodu: string;
  sterilizasyonMalzemeMiktari: string;
  olcuKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateSterilizasyonPaketDetayDto {
  sterilizasyonPaketDetayKodu: string;
  referansTabloAdi: string;
  sterilizasyonPaketKodu: string;
  stokKartKodu: string;
  sterilizasyonMalzemeMiktari: string;
  olcuKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSterilizasyonPaketDetayDto extends CreateSterilizasyonPaketDetayDto {
  id: string;
}

export interface SterilizasyonPaketDetayListFilter extends BaseListFilter {
  sterilizasyonPaketDetayKodu?: string;
  referansTabloAdi?: string;
  sterilizasyonPaketKodu?: string;
  stokKartKodu?: string;
  sterilizasyonMalzemeMiktari?: string;
}

export const newSterilizasyonPaketDetay: CreateSterilizasyonPaketDetayDto = {
  sterilizasyonPaketDetayKodu: '',
  referansTabloAdi: '',
  sterilizasyonPaketKodu: '',
  stokKartKodu: '',
  sterilizasyonMalzemeMiktari: '',
  olcuKodu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
