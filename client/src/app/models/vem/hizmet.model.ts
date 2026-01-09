// Hizmet Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HizmetDto extends VemBaseDto {
  hizmetKodu: string;
  hizmetIslemGrubu?: string;
  hizmetIslemTuru?: string;
  sutKodu?: string;
  hizmetAdi?: string;
  tibbiIslemPuanBilgisi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHizmetDto {
  id: string;
  hizmetKodu: string;
  hizmetIslemGrubu?: string;
  hizmetIslemTuru?: string;
  sutKodu?: string;
  hizmetAdi?: string;
  tibbiIslemPuanBilgisi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
}

export interface CreateHizmetDto {
  hizmetKodu: string;
  hizmetIslemGrubu?: string;
  hizmetIslemTuru?: string;
  sutKodu?: string;
  hizmetAdi?: string;
  tibbiIslemPuanBilgisi?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHizmetDto extends CreateHizmetDto {
  id: string;
}

export interface HizmetListFilter extends BaseListFilter {
  hizmetKodu?: string;
  hizmetIslemGrubu?: string;
  hizmetIslemTuru?: string;
  sutKodu?: string;
  hizmetAdi?: string;
  AKTIFLIK_BILGISI?: string | null;
}

export const newHizmet: CreateHizmetDto = {
  hizmetKodu: '',
  hizmetIslemGrubu: '',
  hizmetIslemTuru: '',
  sutKodu: '',
  hizmetAdi: '',
  tibbiIslemPuanBilgisi: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
