// PersonelEgitim Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelEgitimDto extends VemBaseDto {
  personelEgitimKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelEgitimTuru: string;
  sertifikaTipi: string;
  sertifikaPuani: string;
  belgeNumarasi: string;
  egitimBaslangicZamani?: Date;
  egitimBitisZamani: Date;
  egitimVerenKisiBilgisi: string;
  egitimYeri: string;
  onaylayanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelEgitimDto {
  id: string;
  personelEgitimKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelEgitimTuru: string;
  sertifikaTipi: string;
  sertifikaPuani: string;
  belgeNumarasi: string;
  egitimBaslangicZamani?: Date;
}

export interface CreatePersonelEgitimDto {
  personelEgitimKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelEgitimTuru: string;
  sertifikaTipi: string;
  sertifikaPuani: string;
  belgeNumarasi: string;
  egitimBaslangicZamani?: Date;
  egitimBitisZamani: Date;
  egitimVerenKisiBilgisi: string;
  egitimYeri: string;
  onaylayanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelEgitimDto extends CreatePersonelEgitimDto {
  id: string;
}

export interface PersonelEgitimListFilter extends BaseListFilter {
  personelEgitimKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  personelEgitimTuru?: string;
  sertifikaTipi?: string;
}

export const newPersonelEgitim: CreatePersonelEgitimDto = {
  personelEgitimKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  personelEgitimTuru: '',
  sertifikaTipi: '',
  sertifikaPuani: '',
  belgeNumarasi: '',
  egitimBaslangicZamani: undefined,
  egitimBitisZamani: undefined,
  egitimVerenKisiBilgisi: '',
  egitimYeri: '',
  onaylayanPersonelKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
