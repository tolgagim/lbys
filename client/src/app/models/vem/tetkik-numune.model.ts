// TetkikNumune Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface TetkikNumuneDto extends VemBaseDto {
  tetkikNumuneKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  numuneNumarasi?: string;
  numuneTuru?: string;
  birimKodu?: string;
  numuneAlmaZamani?: Date;
  numuneKabulZamani?: Date;
  barkod?: string;
  barkodZamani?: Date;
  numuneAlanKullaniciKodu?: string;
  kabulEdenKullaniciKodu?: string;
  numuneRetNedeni?: string;
  retEdenKullaniciKodu?: string;
  retZamani?: Date;
  numuneAciliyetDurumu?: string;
  entegrasyonNumarasi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListTetkikNumuneDto {
  id: string;
  tetkikNumuneKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  numuneNumarasi?: string;
  numuneTuru?: string;
  birimKodu?: string;
  numuneAlmaZamani?: Date;
  numuneKabulZamani?: Date;
}

export interface CreateTetkikNumuneDto {
  tetkikNumuneKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  numuneNumarasi?: string;
  numuneTuru?: string;
  birimKodu?: string;
  numuneAlmaZamani?: Date;
  numuneKabulZamani?: Date;
  barkod?: string;
  barkodZamani?: Date;
  numuneAlanKullaniciKodu?: string;
  kabulEdenKullaniciKodu?: string;
  numuneRetNedeni?: string;
  retEdenKullaniciKodu?: string;
  retZamani?: Date;
  numuneAciliyetDurumu?: string;
  entegrasyonNumarasi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateTetkikNumuneDto extends CreateTetkikNumuneDto {
  id: string;
}

export interface TetkikNumuneListFilter extends BaseListFilter {
  tetkikNumuneKodu?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  numuneNumarasi?: string;
  numuneTuru?: string;
}

export const newTetkikNumune: CreateTetkikNumuneDto = {
  tetkikNumuneKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  numuneNumarasi: '',
  numuneTuru: '',
  birimKodu: '',
  numuneAlmaZamani: undefined,
  numuneKabulZamani: undefined,
  barkod: '',
  barkodZamani: undefined,
  numuneAlanKullaniciKodu: '',
  kabulEdenKullaniciKodu: '',
  numuneRetNedeni: '',
  retEdenKullaniciKodu: '',
  retZamani: undefined,
  numuneAciliyetDurumu: '',
  entegrasyonNumarasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
