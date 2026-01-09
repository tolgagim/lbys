// TetkikParametre Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface TetkikParametreDto extends VemBaseDto {
  tetkikParametreKodu: string;
  tetkikParametreAdi?: string;
  tetkikParametreBirimi?: string;
  tetkikKodu?: string;
  cihazKodu?: string;
  medulaParametreKodu?: string;
  loincKodu?: string;
  raporSonucSirasi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListTetkikParametreDto {
  id: string;
  tetkikParametreKodu: string;
  tetkikParametreAdi?: string;
  tetkikParametreBirimi?: string;
  tetkikKodu?: string;
  cihazKodu?: string;
  medulaParametreKodu?: string;
  loincKodu?: string;
  raporSonucSirasi?: string;
}

export interface CreateTetkikParametreDto {
  tetkikParametreKodu: string;
  tetkikParametreAdi?: string;
  tetkikParametreBirimi?: string;
  tetkikKodu?: string;
  cihazKodu?: string;
  medulaParametreKodu?: string;
  loincKodu?: string;
  raporSonucSirasi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateTetkikParametreDto extends CreateTetkikParametreDto {
  id: string;
}

export interface TetkikParametreListFilter extends BaseListFilter {
  tetkikParametreKodu?: string;
  tetkikParametreAdi?: string;
  tetkikParametreBirimi?: string;
  tetkikKodu?: string;
  cihazKodu?: string;
  IPTAL_DURUMU?: string | null;
}

export const newTetkikParametre: CreateTetkikParametreDto = {
  tetkikParametreKodu: '',
  tetkikParametreAdi: '',
  tetkikParametreBirimi: '',
  tetkikKodu: '',
  cihazKodu: '',
  medulaParametreKodu: '',
  loincKodu: '',
  raporSonucSirasi: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
