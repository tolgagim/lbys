// HastaEpikriz Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaEpikrizDto extends VemBaseDto {
  hastaEpikrizKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  epikrizZamani?: Date;
  epikrizBaslikBilgisi: string;
  epikrizBilgisiAciklama: string;
  hekimKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaEpikrizDto {
  id: string;
  hastaEpikrizKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  epikrizZamani?: Date;
  epikrizBaslikBilgisi: string;
  epikrizBilgisiAciklama: string;
  hekimKodu: string;
}

export interface CreateHastaEpikrizDto {
  hastaEpikrizKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  epikrizZamani?: Date;
  epikrizBaslikBilgisi: string;
  epikrizBilgisiAciklama: string;
  hekimKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaEpikrizDto extends CreateHastaEpikrizDto {
  id: string;
}

export interface HastaEpikrizListFilter extends BaseListFilter {
  hastaEpikrizKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  epikrizBaslikBilgisi?: string;
}

export const newHastaEpikriz: CreateHastaEpikrizDto = {
  hastaEpikrizKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  epikrizZamani: undefined,
  epikrizBaslikBilgisi: '',
  epikrizBilgisiAciklama: '',
  hekimKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
