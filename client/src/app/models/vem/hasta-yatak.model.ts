// HastaYatak Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaYatakDto extends VemBaseDto {
  hastaYatakKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  yatakKodu?: string;
  yatisBaslamaZamani?: Date;
  yatisBitisZamani?: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaYatakDto {
  id: string;
  hastaYatakKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  yatakKodu?: string;
  yatisBaslamaZamani?: Date;
  yatisBitisZamani?: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
}

export interface CreateHastaYatakDto {
  hastaYatakKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  yatakKodu?: string;
  yatisBaslamaZamani?: Date;
  yatisBitisZamani?: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaYatakDto extends CreateHastaYatakDto {
  id: string;
}

export interface HastaYatakListFilter extends BaseListFilter {
  hastaYatakKodu?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  yatakKodu?: string;
  ekleyenKullaniciKodu?: string;
}

export const newHastaYatak: CreateHastaYatakDto = {
  hastaYatakKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  yatakKodu: '',
  yatisBaslamaZamani: undefined,
  yatisBitisZamani: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
