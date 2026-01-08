// BasvuruYemek Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface BasvuruYemekDto extends VemBaseDto {
  basvuruYemekKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  yemekTuru: string;
  yemekZamaniTuru: string;
  yemekZamani?: Date;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListBasvuruYemekDto {
  id: string;
  basvuruYemekKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  yemekTuru: string;
  yemekZamaniTuru: string;
  yemekZamani?: Date;
  aciklama: string;
}

export interface CreateBasvuruYemekDto {
  basvuruYemekKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  yemekTuru: string;
  yemekZamaniTuru: string;
  yemekZamani?: Date;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateBasvuruYemekDto extends CreateBasvuruYemekDto {
  id: string;
}

export interface BasvuruYemekListFilter extends BaseListFilter {
  basvuruYemekKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  yemekTuru?: string;
}

export const newBasvuruYemek: CreateBasvuruYemekDto = {
  basvuruYemekKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  yemekTuru: '',
  yemekZamaniTuru: '',
  yemekZamani: undefined,
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
