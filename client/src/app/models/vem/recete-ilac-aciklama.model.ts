// ReceteIlacAciklama Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface ReceteIlacAciklamaDto extends VemBaseDto {
  receteIlacAciklamaKodu: string;
  referansTabloAdi: string;
  receteIlacKodu: string;
  receteKodu: string;
  ilacAciklamaTuru: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListReceteIlacAciklamaDto {
  id: string;
  receteIlacAciklamaKodu: string;
  referansTabloAdi: string;
  receteIlacKodu: string;
  receteKodu: string;
  ilacAciklamaTuru: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
}

export interface CreateReceteIlacAciklamaDto {
  receteIlacAciklamaKodu: string;
  referansTabloAdi: string;
  receteIlacKodu: string;
  receteKodu: string;
  ilacAciklamaTuru: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateReceteIlacAciklamaDto extends CreateReceteIlacAciklamaDto {
  id: string;
}

export interface ReceteIlacAciklamaListFilter extends BaseListFilter {
  receteIlacAciklamaKodu?: string;
  referansTabloAdi?: string;
  receteIlacKodu?: string;
  receteKodu?: string;
  ilacAciklamaTuru?: string;
}

export const newReceteIlacAciklama: CreateReceteIlacAciklamaDto = {
  receteIlacAciklamaKodu: '',
  referansTabloAdi: '',
  receteIlacKodu: '',
  receteKodu: '',
  ilacAciklamaTuru: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
