// PersonelBordroSondurum Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelBordroSondurumDto extends VemBaseDto {
  personelSondurumKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelKademesi: string;
  personelDerecesi: string;
  emekliDerecesi: string;
  emekliKademesi: string;
  sendikaBilgisi: string;
  kidemYili: string;
  kidemAyi: string;
  kidemGunu: string;
  ekGosterge: string;
  emekliEkGostergesi: string;
  gosterge: string;
  emekliGostergesi: string;
  yanOdemePuani: string;
  ozelHizmetPuani: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelBordroSondurumDto {
  id: string;
  personelSondurumKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelKademesi: string;
  personelDerecesi: string;
  emekliDerecesi: string;
  emekliKademesi: string;
  sendikaBilgisi: string;
}

export interface CreatePersonelBordroSondurumDto {
  personelSondurumKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelKademesi: string;
  personelDerecesi: string;
  emekliDerecesi: string;
  emekliKademesi: string;
  sendikaBilgisi: string;
  kidemYili: string;
  kidemAyi: string;
  kidemGunu: string;
  ekGosterge: string;
  emekliEkGostergesi: string;
  gosterge: string;
  emekliGostergesi: string;
  yanOdemePuani: string;
  ozelHizmetPuani: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelBordroSondurumDto extends CreatePersonelBordroSondurumDto {
  id: string;
}

export interface PersonelBordroSondurumListFilter extends BaseListFilter {
  personelSondurumKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  personelKademesi?: string;
  personelDerecesi?: string;
}

export const newPersonelBordroSondurum: CreatePersonelBordroSondurumDto = {
  personelSondurumKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  personelKademesi: '',
  personelDerecesi: '',
  emekliDerecesi: '',
  emekliKademesi: '',
  sendikaBilgisi: '',
  kidemYili: '',
  kidemAyi: '',
  kidemGunu: '',
  ekGosterge: '',
  emekliEkGostergesi: '',
  gosterge: '',
  emekliGostergesi: '',
  yanOdemePuani: '',
  ozelHizmetPuani: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
