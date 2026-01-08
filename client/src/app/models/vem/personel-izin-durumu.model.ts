// PersonelIzinDurumu Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelIzinDurumuDto extends VemBaseDto {
  personelIzinDurumuKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  kalanIzin: string;
  yillikIzinHakki: string;
  personelIzinYili: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelIzinDurumuDto {
  id: string;
  personelIzinDurumuKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  kalanIzin: string;
  yillikIzinHakki: string;
  personelIzinYili: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
}

export interface CreatePersonelIzinDurumuDto {
  personelIzinDurumuKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  kalanIzin: string;
  yillikIzinHakki: string;
  personelIzinYili: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelIzinDurumuDto extends CreatePersonelIzinDurumuDto {
  id: string;
}

export interface PersonelIzinDurumuListFilter extends BaseListFilter {
  personelIzinDurumuKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  kalanIzin?: string;
  yillikIzinHakki?: string;
}

export const newPersonelIzinDurumu: CreatePersonelIzinDurumuDto = {
  personelIzinDurumuKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  kalanIzin: '',
  yillikIzinHakki: '',
  personelIzinYili: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
