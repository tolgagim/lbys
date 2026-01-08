// HemsireBakim Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HemsireBakimDto extends VemBaseDto {
  hemsireBakimKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hemsireDegerlendirmeZamani?: Date;
  hemsirelikTaniKodu: string;
  bakimNedeni: string;
  hemsireBakimHedefSonuc: string;
  hemsirelikGirisimi: string;
  hemsireDegerlendirmeDurumu: string;
  hemsireDegerlendirmeNotu: string;
  hemsireKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHemsireBakimDto {
  id: string;
  hemsireBakimKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hemsireDegerlendirmeZamani?: Date;
  hemsirelikTaniKodu: string;
  bakimNedeni: string;
  hemsireBakimHedefSonuc: string;
}

export interface CreateHemsireBakimDto {
  hemsireBakimKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hemsireDegerlendirmeZamani?: Date;
  hemsirelikTaniKodu: string;
  bakimNedeni: string;
  hemsireBakimHedefSonuc: string;
  hemsirelikGirisimi: string;
  hemsireDegerlendirmeDurumu: string;
  hemsireDegerlendirmeNotu: string;
  hemsireKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHemsireBakimDto extends CreateHemsireBakimDto {
  id: string;
}

export interface HemsireBakimListFilter extends BaseListFilter {
  hemsireBakimKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hemsirelikTaniKodu?: string;
}

export const newHemsireBakim: CreateHemsireBakimDto = {
  hemsireBakimKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  hemsireDegerlendirmeZamani: undefined,
  hemsirelikTaniKodu: '',
  bakimNedeni: '',
  hemsireBakimHedefSonuc: '',
  hemsirelikGirisimi: '',
  hemsireDegerlendirmeDurumu: '',
  hemsireDegerlendirmeNotu: '',
  hemsireKodu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
