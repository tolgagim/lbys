// DisprotezDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DisprotezDetayDto extends VemBaseDto {
  disprotezDetayKodu: string;
  referansTabloAdi: string;
  disprotezKodu: string;
  disprotezPlanlamaZamani?: Date;
  disprotezIsTuruAsamaKodu: string;
  disprotezAsamaBitisZamani: Date;
  firmaKodu: string;
  firmaDisprotezAlimZamani: Date;
  planlananBitisTarihi: Date;
  firmaTeslimZamani: Date;
  disprotezAsamaOnayZamani: Date;
  rptOnayDurumu: string;
  randevuKodu: string;
  asamaRptZamani: Date;
  asamaRptSebebi: string;
  asamaRptKullaniciKodu: string;
  olcuDokumZamani: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListDisprotezDetayDto {
  id: string;
  disprotezDetayKodu: string;
  referansTabloAdi: string;
  disprotezKodu: string;
  disprotezPlanlamaZamani?: Date;
  disprotezIsTuruAsamaKodu: string;
  disprotezAsamaBitisZamani: Date;
  firmaKodu: string;
  firmaDisprotezAlimZamani: Date;
}

export interface CreateDisprotezDetayDto {
  disprotezDetayKodu: string;
  referansTabloAdi: string;
  disprotezKodu: string;
  disprotezPlanlamaZamani?: Date;
  disprotezIsTuruAsamaKodu: string;
  disprotezAsamaBitisZamani: Date;
  firmaKodu: string;
  firmaDisprotezAlimZamani: Date;
  planlananBitisTarihi: Date;
  firmaTeslimZamani: Date;
  disprotezAsamaOnayZamani: Date;
  rptOnayDurumu: string;
  randevuKodu: string;
  asamaRptZamani: Date;
  asamaRptSebebi: string;
  asamaRptKullaniciKodu: string;
  olcuDokumZamani: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateDisprotezDetayDto extends CreateDisprotezDetayDto {
  id: string;
}

export interface DisprotezDetayListFilter extends BaseListFilter {
  disprotezDetayKodu?: string;
  referansTabloAdi?: string;
  disprotezKodu?: string;
  disprotezIsTuruAsamaKodu?: string;
  firmaKodu?: string;
}

export const newDisprotezDetay: CreateDisprotezDetayDto = {
  disprotezDetayKodu: '',
  referansTabloAdi: '',
  disprotezKodu: '',
  disprotezPlanlamaZamani: undefined,
  disprotezIsTuruAsamaKodu: '',
  disprotezAsamaBitisZamani: undefined,
  firmaKodu: '',
  firmaDisprotezAlimZamani: undefined,
  planlananBitisTarihi: undefined,
  firmaTeslimZamani: undefined,
  disprotezAsamaOnayZamani: undefined,
  rptOnayDurumu: '',
  randevuKodu: '',
  asamaRptZamani: undefined,
  asamaRptSebebi: '',
  asamaRptKullaniciKodu: '',
  olcuDokumZamani: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
