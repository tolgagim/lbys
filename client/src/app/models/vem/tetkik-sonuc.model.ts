// TetkikSonuc Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface TetkikSonucDto extends VemBaseDto {
  tetkikSonucKodu: string;
  tetkikNumuneKodu?: string;
  tetkikParametreKodu?: string;
  tetkikKodu?: string;
  tetkikAdi?: string;
  hastaHizmetKodu?: string;
  tetkikSonucu?: string;
  sonucZamani?: Date;
  tetkikSonucGizlenmeDurumu?: string;
  webSonucGizlenmeDurumu?: string;
  numuneRetNedeni?: string;
  retEdenKullaniciKodu?: string;
  retZamani?: Date;
  kritikDegerAraligi?: string;
  calismaBaslamaZamani?: Date;
  calismaBitisZamani?: Date;
  onaylayanTeknisyenKodu?: string;
  teknisyenOnayZamani?: Date;
  onaylayanHekimKodu?: string;
  tetkikUzmanOnayZamani?: Date;
  loincKodu?: string;
  tekrarCalismaDurumu?: string;
  manuelTetkikSonucDurumu?: string;
  uremeDurumu?: string;
  cihazKodu?: string;
  cihazTetkikSonucu?: string;
  tetkikSonucuBirimi?: string;
  tetkikSonucuReferansDegeri?: string;
  tetkikSonucuDurumu?: string;
  tetkikSonucAciklama?: string;
  raporYazanPersonelKodu?: string;
  sonucDisErisimBilgisi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListTetkikSonucDto {
  id: string;
  tetkikSonucKodu: string;
  tetkikNumuneKodu?: string;
  tetkikParametreKodu?: string;
  tetkikKodu?: string;
  tetkikAdi?: string;
  hastaHizmetKodu?: string;
  tetkikSonucu?: string;
  sonucZamani?: Date;
}

export interface CreateTetkikSonucDto {
  tetkikSonucKodu: string;
  tetkikNumuneKodu?: string;
  tetkikParametreKodu?: string;
  tetkikKodu?: string;
  tetkikAdi?: string;
  hastaHizmetKodu?: string;
  tetkikSonucu?: string;
  sonucZamani?: Date;
  tetkikSonucGizlenmeDurumu?: string;
  webSonucGizlenmeDurumu?: string;
  numuneRetNedeni?: string;
  retEdenKullaniciKodu?: string;
  retZamani?: Date;
  kritikDegerAraligi?: string;
  calismaBaslamaZamani?: Date;
  calismaBitisZamani?: Date;
  onaylayanTeknisyenKodu?: string;
  teknisyenOnayZamani?: Date;
  onaylayanHekimKodu?: string;
  tetkikUzmanOnayZamani?: Date;
  loincKodu?: string;
  tekrarCalismaDurumu?: string;
  manuelTetkikSonucDurumu?: string;
  uremeDurumu?: string;
  cihazKodu?: string;
  cihazTetkikSonucu?: string;
  tetkikSonucuBirimi?: string;
  tetkikSonucuReferansDegeri?: string;
  tetkikSonucuDurumu?: string;
  tetkikSonucAciklama?: string;
  raporYazanPersonelKodu?: string;
  sonucDisErisimBilgisi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateTetkikSonucDto extends CreateTetkikSonucDto {
  id: string;
}

export interface TetkikSonucListFilter extends BaseListFilter {
  tetkikSonucKodu?: string;
  tetkikNumuneKodu?: string;
  tetkikParametreKodu?: string;
  tetkikKodu?: string;
  tetkikAdi?: string;
}

export const newTetkikSonuc: CreateTetkikSonucDto = {
  tetkikSonucKodu: '',
  tetkikNumuneKodu: '',
  tetkikParametreKodu: '',
  tetkikKodu: '',
  tetkikAdi: '',
  hastaHizmetKodu: '',
  tetkikSonucu: '',
  sonucZamani: undefined,
  tetkikSonucGizlenmeDurumu: '',
  webSonucGizlenmeDurumu: '',
  numuneRetNedeni: '',
  retEdenKullaniciKodu: '',
  retZamani: undefined,
  kritikDegerAraligi: '',
  calismaBaslamaZamani: undefined,
  calismaBitisZamani: undefined,
  onaylayanTeknisyenKodu: '',
  teknisyenOnayZamani: undefined,
  onaylayanHekimKodu: '',
  tetkikUzmanOnayZamani: undefined,
  loincKodu: '',
  tekrarCalismaDurumu: '',
  manuelTetkikSonucDurumu: '',
  uremeDurumu: '',
  cihazKodu: '',
  cihazTetkikSonucu: '',
  tetkikSonucuBirimi: '',
  tetkikSonucuReferansDegeri: '',
  tetkikSonucuDurumu: '',
  tetkikSonucAciklama: '',
  raporYazanPersonelKodu: '',
  sonucDisErisimBilgisi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
