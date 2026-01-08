// PersonelOgrenim Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelOgrenimDto extends VemBaseDto {
  personelOgrenimKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  ogrenimDurumu: string;
  okulAdi: string;
  okulaBaslangicTarihi: Date;
  mezuniyetTarihi: Date;
  belgeNumarasi: string;
  onaylayanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelOgrenimDto {
  id: string;
  personelOgrenimKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  ogrenimDurumu: string;
  okulAdi: string;
  okulaBaslangicTarihi: Date;
  mezuniyetTarihi: Date;
  belgeNumarasi: string;
}

export interface CreatePersonelOgrenimDto {
  personelOgrenimKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  ogrenimDurumu: string;
  okulAdi: string;
  okulaBaslangicTarihi: Date;
  mezuniyetTarihi: Date;
  belgeNumarasi: string;
  onaylayanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelOgrenimDto extends CreatePersonelOgrenimDto {
  id: string;
}

export interface PersonelOgrenimListFilter extends BaseListFilter {
  personelOgrenimKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  ogrenimDurumu?: string;
  okulAdi?: string;
}

export const newPersonelOgrenim: CreatePersonelOgrenimDto = {
  personelOgrenimKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  ogrenimDurumu: '',
  okulAdi: '',
  okulaBaslangicTarihi: undefined,
  mezuniyetTarihi: undefined,
  belgeNumarasi: '',
  onaylayanPersonelKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
