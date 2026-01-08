// HastaDis Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaDisDto extends VemBaseDto {
  hastaDisKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  disIslemTuru: string;
  hastaHizmetKodu: string;
  disTaahhutKodu: string;
  mevcutDisDurumu: string;
  disKodu: string;
  ceneBolgesi: string;
  ceneBolgesiDisleri: string;
  disprotezKodu: string;
  sonucKodu: string;
  sonucMesaji: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaDisDto {
  id: string;
  hastaDisKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  disIslemTuru: string;
  hastaHizmetKodu: string;
  disTaahhutKodu: string;
  mevcutDisDurumu: string;
}

export interface CreateHastaDisDto {
  hastaDisKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  disIslemTuru: string;
  hastaHizmetKodu: string;
  disTaahhutKodu: string;
  mevcutDisDurumu: string;
  disKodu: string;
  ceneBolgesi: string;
  ceneBolgesiDisleri: string;
  disprotezKodu: string;
  sonucKodu: string;
  sonucMesaji: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaDisDto extends CreateHastaDisDto {
  id: string;
}

export interface HastaDisListFilter extends BaseListFilter {
  hastaDisKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  disIslemTuru?: string;
}

export const newHastaDis: CreateHastaDisDto = {
  hastaDisKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  disIslemTuru: '',
  hastaHizmetKodu: '',
  disTaahhutKodu: '',
  mevcutDisDurumu: '',
  disKodu: '',
  ceneBolgesi: '',
  ceneBolgesiDisleri: '',
  disprotezKodu: '',
  sonucKodu: '',
  sonucMesaji: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
