// Vezne Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface VezneDto extends VemBaseDto {
  vezneKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  makbuzNumarasi: string;
  vezneOzelNumarasi: string;
  vezneGirisCikisBilgisi: string;
  makbuzZamani?: Date;
  vezneBirimKodu: string;
  makbuzSeriNumarasi: string;
  iptalDurumu: string;
  iptalZamani: Date;
  iptalAciklama: string;
  tahsilTuru: string;
  makbuzTutari: string;
  aciklama: string;
  makbuzSahibiAdresi: string;
  firmaAdi: string;
  firmaKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListVezneDto {
  id: string;
  vezneKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  makbuzNumarasi: string;
  vezneOzelNumarasi: string;
  vezneGirisCikisBilgisi: string;
  makbuzZamani?: Date;
}

export interface CreateVezneDto {
  vezneKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  makbuzNumarasi: string;
  vezneOzelNumarasi: string;
  vezneGirisCikisBilgisi: string;
  makbuzZamani?: Date;
  vezneBirimKodu: string;
  makbuzSeriNumarasi: string;
  iptalDurumu: string;
  iptalZamani: Date;
  iptalAciklama: string;
  tahsilTuru: string;
  makbuzTutari: string;
  aciklama: string;
  makbuzSahibiAdresi: string;
  firmaAdi: string;
  firmaKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateVezneDto extends CreateVezneDto {
  id: string;
}

export interface VezneListFilter extends BaseListFilter {
  vezneKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  makbuzNumarasi?: string;
}

export const newVezne: CreateVezneDto = {
  vezneKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  makbuzNumarasi: '',
  vezneOzelNumarasi: '',
  vezneGirisCikisBilgisi: '',
  makbuzZamani: undefined,
  vezneBirimKodu: '',
  makbuzSeriNumarasi: '',
  iptalDurumu: '',
  iptalZamani: undefined,
  iptalAciklama: '',
  tahsilTuru: '',
  makbuzTutari: '',
  aciklama: '',
  makbuzSahibiAdresi: '',
  firmaAdi: '',
  firmaKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
