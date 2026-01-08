// HastaArsivDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaArsivDetayDto extends VemBaseDto {
  hastaArsivDetayKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaArsivKodu: string;
  dosyaAlanBirimKodu: string;
  dosyaninAlindigiZaman: Date;
  dosyaAlanPersonelKodu: string;
  dosyaVerenBirimKodu: string;
  dosyaninVerildigiZaman: Date;
  dosyaVerenKullaniciKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaArsivDetayDto {
  id: string;
  hastaArsivDetayKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaArsivKodu: string;
  dosyaAlanBirimKodu: string;
  dosyaninAlindigiZaman: Date;
  dosyaAlanPersonelKodu: string;
}

export interface CreateHastaArsivDetayDto {
  hastaArsivDetayKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaArsivKodu: string;
  dosyaAlanBirimKodu: string;
  dosyaninAlindigiZaman: Date;
  dosyaAlanPersonelKodu: string;
  dosyaVerenBirimKodu: string;
  dosyaninVerildigiZaman: Date;
  dosyaVerenKullaniciKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaArsivDetayDto extends CreateHastaArsivDetayDto {
  id: string;
}

export interface HastaArsivDetayListFilter extends BaseListFilter {
  hastaArsivDetayKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hastaArsivKodu?: string;
}

export const newHastaArsivDetay: CreateHastaArsivDetayDto = {
  hastaArsivDetayKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  hastaArsivKodu: '',
  dosyaAlanBirimKodu: '',
  dosyaninAlindigiZaman: undefined,
  dosyaAlanPersonelKodu: '',
  dosyaVerenBirimKodu: '',
  dosyaninVerildigiZaman: undefined,
  dosyaVerenKullaniciKodu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
