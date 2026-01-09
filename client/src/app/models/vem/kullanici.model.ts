// Kullanici Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KullaniciDto extends VemBaseDto {
  kullaniciKodu: string;
  personelKodu?: string;
  kullaniciAdi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKullaniciDto {
  id: string;
  kullaniciKodu: string;
  personelKodu?: string;
  kullaniciAdi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface CreateKullaniciDto {
  kullaniciKodu: string;
  personelKodu?: string;
  kullaniciAdi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKullaniciDto extends CreateKullaniciDto {
  id: string;
}

export interface KullaniciListFilter extends BaseListFilter {
  kullaniciKodu?: string;
  personelKodu?: string;
  kullaniciAdi?: string;
  ekleyenKullaniciKodu?: string;
  guncelleyenKullaniciKodu?: string;
  AD?: string | null;
  AKTIFLIK_BILGISI?: string | null;
  PAROLA?: string | null;
  PAROLA_SIFRELEME_TURU?: string | null;
  SOYADI?: string | null;
  TC_KIMLIK_NUMARASI?: string | null;
}

export const newKullanici: CreateKullaniciDto = {
  kullaniciKodu: '',
  personelKodu: '',
  kullaniciAdi: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
