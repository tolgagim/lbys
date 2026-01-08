// StokEhuTakip Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface StokEhuTakipDto extends VemBaseDto {
  stokEhuTakipKodu: string;
  referansTabloAdi: string;
  stokIstekKodu: string;
  stokIstekHareketKodu: string;
  stokKartKodu: string;
  ehuOnayBaslamaZamani?: Date;
  ehuOnayBitisZamani?: Date;
  ehuIlacMaksimumMiktar: string;
  aciklama: string;
  ehuOnaylamaZamani: Date;
  onaylayanHekimKodu: string;
  ehuRetNedeni: string;
  ehuRetZamani: Date;
  ehuRetPersonelKodu: string;
  ehuRetAciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListStokEhuTakipDto {
  id: string;
  stokEhuTakipKodu: string;
  referansTabloAdi: string;
  stokIstekKodu: string;
  stokIstekHareketKodu: string;
  stokKartKodu: string;
  ehuOnayBaslamaZamani?: Date;
  ehuOnayBitisZamani?: Date;
  ehuIlacMaksimumMiktar: string;
}

export interface CreateStokEhuTakipDto {
  stokEhuTakipKodu: string;
  referansTabloAdi: string;
  stokIstekKodu: string;
  stokIstekHareketKodu: string;
  stokKartKodu: string;
  ehuOnayBaslamaZamani?: Date;
  ehuOnayBitisZamani?: Date;
  ehuIlacMaksimumMiktar: string;
  aciklama: string;
  ehuOnaylamaZamani: Date;
  onaylayanHekimKodu: string;
  ehuRetNedeni: string;
  ehuRetZamani: Date;
  ehuRetPersonelKodu: string;
  ehuRetAciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateStokEhuTakipDto extends CreateStokEhuTakipDto {
  id: string;
}

export interface StokEhuTakipListFilter extends BaseListFilter {
  stokEhuTakipKodu?: string;
  referansTabloAdi?: string;
  stokIstekKodu?: string;
  stokIstekHareketKodu?: string;
  stokKartKodu?: string;
}

export const newStokEhuTakip: CreateStokEhuTakipDto = {
  stokEhuTakipKodu: '',
  referansTabloAdi: '',
  stokIstekKodu: '',
  stokIstekHareketKodu: '',
  stokKartKodu: '',
  ehuOnayBaslamaZamani: undefined,
  ehuOnayBitisZamani: undefined,
  ehuIlacMaksimumMiktar: '',
  aciklama: '',
  ehuOnaylamaZamani: undefined,
  onaylayanHekimKodu: '',
  ehuRetNedeni: '',
  ehuRetZamani: undefined,
  ehuRetPersonelKodu: '',
  ehuRetAciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
