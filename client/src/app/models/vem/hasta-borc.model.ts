// HastaBorc Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaBorcDto extends VemBaseDto {
  hastaBorcKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  odenenBorc: string;
  toplamBorc: string;
  kalanBorc: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaBorcDto {
  id: string;
  hastaBorcKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  odenenBorc: string;
  toplamBorc: string;
  kalanBorc: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateHastaBorcDto {
  hastaBorcKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  odenenBorc: string;
  toplamBorc: string;
  kalanBorc: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaBorcDto extends CreateHastaBorcDto {
  id: string;
}

export interface HastaBorcListFilter extends BaseListFilter {
  hastaBorcKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  odenenBorc?: string;
}

export const newHastaBorc: CreateHastaBorcDto = {
  hastaBorcKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  odenenBorc: '',
  toplamBorc: '',
  kalanBorc: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
