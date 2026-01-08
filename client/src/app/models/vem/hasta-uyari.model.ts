// HastaUyari Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaUyariDto extends VemBaseDto {
  hastaUyariKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  uyariTuru: string;
  islemeIzinVermeDurumu: string;
  hastaUyariBaslamaZamani?: Date;
  hastaUyariBitisZamani: Date;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaUyariDto {
  id: string;
  hastaUyariKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  uyariTuru: string;
  islemeIzinVermeDurumu: string;
  hastaUyariBaslamaZamani?: Date;
  hastaUyariBitisZamani: Date;
}

export interface CreateHastaUyariDto {
  hastaUyariKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  uyariTuru: string;
  islemeIzinVermeDurumu: string;
  hastaUyariBaslamaZamani?: Date;
  hastaUyariBitisZamani: Date;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaUyariDto extends CreateHastaUyariDto {
  id: string;
}

export interface HastaUyariListFilter extends BaseListFilter {
  hastaUyariKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  uyariTuru?: string;
}

export const newHastaUyari: CreateHastaUyariDto = {
  hastaUyariKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  uyariTuru: '',
  islemeIzinVermeDurumu: '',
  hastaUyariBaslamaZamani: undefined,
  hastaUyariBitisZamani: undefined,
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
