// StokKart Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface StokKartDto extends VemBaseDto {
  stokKartKodu: string;
  malzemeAdi?: string;
  mkysMalzemeKodu?: string;
  tasinirKodu?: string;
  malzemeTipi?: string;
  barkod?: string;
  malzemeSutKodu?: string;
  receteTuru?: string;
  medulaCarpani?: string;
  ehuIlacGunMiktari?: string;
  ehuIlacMaksimumAdet?: string;
  ehuOnayDurumu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListStokKartDto {
  id: string;
  stokKartKodu: string;
  malzemeAdi?: string;
  mkysMalzemeKodu?: string;
  tasinirKodu?: string;
  malzemeTipi?: string;
  barkod?: string;
  malzemeSutKodu?: string;
  receteTuru?: string;
}

export interface CreateStokKartDto {
  stokKartKodu: string;
  malzemeAdi?: string;
  mkysMalzemeKodu?: string;
  tasinirKodu?: string;
  malzemeTipi?: string;
  barkod?: string;
  malzemeSutKodu?: string;
  receteTuru?: string;
  medulaCarpani?: string;
  ehuIlacGunMiktari?: string;
  ehuIlacMaksimumAdet?: string;
  ehuOnayDurumu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateStokKartDto extends CreateStokKartDto {
  id: string;
}

export interface StokKartListFilter extends BaseListFilter {
  stokKartKodu?: string;
  malzemeAdi?: string;
  mkysMalzemeKodu?: string;
  tasinirKodu?: string;
  malzemeTipi?: string;
}

export const newStokKart: CreateStokKartDto = {
  stokKartKodu: '',
  malzemeAdi: '',
  mkysMalzemeKodu: '',
  tasinirKodu: '',
  malzemeTipi: '',
  barkod: '',
  malzemeSutKodu: '',
  receteTuru: '',
  medulaCarpani: '',
  ehuIlacGunMiktari: '',
  ehuIlacMaksimumAdet: '',
  ehuOnayDurumu: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
