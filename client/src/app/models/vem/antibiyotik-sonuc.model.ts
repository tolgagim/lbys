// AntibiyotikSonuc Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface AntibiyotikSonucDto extends VemBaseDto {
  antibiyotikSonucKodu: string;
  referansTabloAdi: string;
  bakteriSonucKodu: string;
  antibiyotikKodu: string;
  tetkikSonucu: string;
  zonCapi: string;
  aciklama: string;
  rapordaGorulmeDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListAntibiyotikSonucDto {
  id: string;
  antibiyotikSonucKodu: string;
  referansTabloAdi: string;
  bakteriSonucKodu: string;
  antibiyotikKodu: string;
  tetkikSonucu: string;
  zonCapi: string;
  aciklama: string;
  rapordaGorulmeDurumu: string;
}

export interface CreateAntibiyotikSonucDto {
  antibiyotikSonucKodu: string;
  referansTabloAdi: string;
  bakteriSonucKodu: string;
  antibiyotikKodu: string;
  tetkikSonucu: string;
  zonCapi: string;
  aciklama: string;
  rapordaGorulmeDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateAntibiyotikSonucDto extends CreateAntibiyotikSonucDto {
  id: string;
}

export interface AntibiyotikSonucListFilter extends BaseListFilter {
  antibiyotikSonucKodu?: string;
  referansTabloAdi?: string;
  bakteriSonucKodu?: string;
  antibiyotikKodu?: string;
  tetkikSonucu?: string;
}

export const newAntibiyotikSonuc: CreateAntibiyotikSonucDto = {
  antibiyotikSonucKodu: '',
  referansTabloAdi: '',
  bakteriSonucKodu: '',
  antibiyotikKodu: '',
  tetkikSonucu: '',
  zonCapi: '',
  aciklama: '',
  rapordaGorulmeDurumu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
