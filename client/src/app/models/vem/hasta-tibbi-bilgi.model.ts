// HastaTibbiBilgi Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaTibbiBilgiDto extends VemBaseDto {
  hastaTibbiBilgiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  tibbiBilgiTuru: string;
  tibbiBilgiAltTuru: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaTibbiBilgiDto {
  id: string;
  hastaTibbiBilgiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  tibbiBilgiTuru: string;
  tibbiBilgiAltTuru: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateHastaTibbiBilgiDto {
  hastaTibbiBilgiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  tibbiBilgiTuru: string;
  tibbiBilgiAltTuru: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaTibbiBilgiDto extends CreateHastaTibbiBilgiDto {
  id: string;
}

export interface HastaTibbiBilgiListFilter extends BaseListFilter {
  hastaTibbiBilgiKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  tibbiBilgiTuru?: string;
}

export const newHastaTibbiBilgi: CreateHastaTibbiBilgiDto = {
  hastaTibbiBilgiKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  tibbiBilgiTuru: '',
  tibbiBilgiAltTuru: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
