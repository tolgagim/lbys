// Yatak Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface YatakDto extends VemBaseDto {
  yatakKodu: string;
  yatakAdi?: string;
  odaKodu?: string;
  yatakTuru?: string;
  yogunBakimYatakSeviyesi?: string;
  ventilatorCihazKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListYatakDto {
  id: string;
  yatakKodu: string;
  yatakAdi?: string;
  odaKodu?: string;
  yatakTuru?: string;
  yogunBakimYatakSeviyesi?: string;
  ventilatorCihazKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
}

export interface CreateYatakDto {
  yatakKodu: string;
  yatakAdi?: string;
  odaKodu?: string;
  yatakTuru?: string;
  yogunBakimYatakSeviyesi?: string;
  ventilatorCihazKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateYatakDto extends CreateYatakDto {
  id: string;
}

export interface YatakListFilter extends BaseListFilter {
  yatakKodu?: string;
  yatakAdi?: string;
  odaKodu?: string;
  yatakTuru?: string;
  yogunBakimYatakSeviyesi?: string;
}

export const newYatak: CreateYatakDto = {
  yatakKodu: '',
  yatakAdi: '',
  odaKodu: '',
  yatakTuru: '',
  yogunBakimYatakSeviyesi: '',
  ventilatorCihazKodu: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
