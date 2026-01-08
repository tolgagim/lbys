// BasvuruTani Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface BasvuruTaniDto extends VemBaseDto {
  basvuruTaniKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  taniKodu?: string;
  taniTuru?: string;
  birincilTani?: string;
  taniZamani?: Date;
  hekimKodu?: string;
  kurulRaporKodu?: string;
  hastaSevkKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListBasvuruTaniDto {
  id: string;
  basvuruTaniKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  taniKodu?: string;
  taniTuru?: string;
  birincilTani?: string;
  taniZamani?: Date;
  hekimKodu?: string;
}

export interface CreateBasvuruTaniDto {
  basvuruTaniKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  taniKodu?: string;
  taniTuru?: string;
  birincilTani?: string;
  taniZamani?: Date;
  hekimKodu?: string;
  kurulRaporKodu?: string;
  hastaSevkKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateBasvuruTaniDto extends CreateBasvuruTaniDto {
  id: string;
}

export interface BasvuruTaniListFilter extends BaseListFilter {
  basvuruTaniKodu?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  taniKodu?: string;
  taniTuru?: string;
}

export const newBasvuruTani: CreateBasvuruTaniDto = {
  basvuruTaniKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  taniKodu: '',
  taniTuru: '',
  birincilTani: '',
  taniZamani: undefined,
  hekimKodu: '',
  kurulRaporKodu: '',
  hastaSevkKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
