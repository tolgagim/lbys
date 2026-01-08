// Recete Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface ReceteDto extends VemBaseDto {
  receteKodu: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  receteZamani?: Date;
  receteTuru?: string;
  receteAltTuru?: string;
  hekimKodu?: string;
  defterNumarasi?: string;
  medulaEReceteNumarasi?: string;
  renkliReceteNumarasi?: string;
  seriNumarasi?: string;
  receteEImzaDurumu?: string;
  sgkTakipNumarasi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListReceteDto {
  id: string;
  receteKodu: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  receteZamani?: Date;
  receteTuru?: string;
  receteAltTuru?: string;
  hekimKodu?: string;
  defterNumarasi?: string;
}

export interface CreateReceteDto {
  receteKodu: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  receteZamani?: Date;
  receteTuru?: string;
  receteAltTuru?: string;
  hekimKodu?: string;
  defterNumarasi?: string;
  medulaEReceteNumarasi?: string;
  renkliReceteNumarasi?: string;
  seriNumarasi?: string;
  receteEImzaDurumu?: string;
  sgkTakipNumarasi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateReceteDto extends CreateReceteDto {
  id: string;
}

export interface ReceteListFilter extends BaseListFilter {
  receteKodu?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  receteTuru?: string;
  receteAltTuru?: string;
}

export const newRecete: CreateReceteDto = {
  receteKodu: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  receteZamani: undefined,
  receteTuru: '',
  receteAltTuru: '',
  hekimKodu: '',
  defterNumarasi: '',
  medulaEReceteNumarasi: '',
  renkliReceteNumarasi: '',
  seriNumarasi: '',
  receteEImzaDurumu: '',
  sgkTakipNumarasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
