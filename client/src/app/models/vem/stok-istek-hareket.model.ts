// StokIstekHareket Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface StokIstekHareketDto extends VemBaseDto {
  stokIstekHareketKodu: string;
  referansTabloAdi: string;
  stokIstekKodu: string;
  istenenStokKartKodu: string;
  istenenIlacJenerikKodu: string;
  verilenStokKartKodu: string;
  istekGereklilikDurumu: string;
  tedavideKullanilanIlac: string;
  istenenMiktar: string;
  aciklama: string;
  depodanVerilenMiktar: string;
  stokIstekRetNedeni: string;
  stokIstekRetZamani: Date;
  stokIstekRetKullaniciKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListStokIstekHareketDto {
  id: string;
  stokIstekHareketKodu: string;
  referansTabloAdi: string;
  stokIstekKodu: string;
  istenenStokKartKodu: string;
  istenenIlacJenerikKodu: string;
  verilenStokKartKodu: string;
  istekGereklilikDurumu: string;
  tedavideKullanilanIlac: string;
}

export interface CreateStokIstekHareketDto {
  stokIstekHareketKodu: string;
  referansTabloAdi: string;
  stokIstekKodu: string;
  istenenStokKartKodu: string;
  istenenIlacJenerikKodu: string;
  verilenStokKartKodu: string;
  istekGereklilikDurumu: string;
  tedavideKullanilanIlac: string;
  istenenMiktar: string;
  aciklama: string;
  depodanVerilenMiktar: string;
  stokIstekRetNedeni: string;
  stokIstekRetZamani: Date;
  stokIstekRetKullaniciKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateStokIstekHareketDto extends CreateStokIstekHareketDto {
  id: string;
}

export interface StokIstekHareketListFilter extends BaseListFilter {
  stokIstekHareketKodu?: string;
  referansTabloAdi?: string;
  stokIstekKodu?: string;
  istenenStokKartKodu?: string;
  istenenIlacJenerikKodu?: string;
}

export const newStokIstekHareket: CreateStokIstekHareketDto = {
  stokIstekHareketKodu: '',
  referansTabloAdi: '',
  stokIstekKodu: '',
  istenenStokKartKodu: '',
  istenenIlacJenerikKodu: '',
  verilenStokKartKodu: '',
  istekGereklilikDurumu: '',
  tedavideKullanilanIlac: '',
  istenenMiktar: '',
  aciklama: '',
  depodanVerilenMiktar: '',
  stokIstekRetNedeni: '',
  stokIstekRetZamani: undefined,
  stokIstekRetKullaniciKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
