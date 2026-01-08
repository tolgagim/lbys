// StokHareket Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface StokHareketDto extends VemBaseDto {
  stokHareketKodu: string;
  referansTabloAdi: string;
  bagliStokHareketKodu: string;
  ilkGirisStokHareketKodu: string;
  stokIstekHareketKodu: string;
  stokFisKodu: string;
  stokKartKodu: string;
  barkod: string;
  lotNumarasi: string;
  seriSiraNumarasi: string;
  firmaTanimlayiciNumarasi: string;
  malzemeSutKodu: string;
  stokHareketMiktari: string;
  tasinirNumarasi: string;
  alisBirimFiyati: string;
  satisBirimFiyati: string;
  olcuKodu: string;
  islemiYapanPersonelKodu: string;
  kdvOrani: string;
  iskontoOrani: string;
  iskontoTutari: string;
  sonKullanmaTarihi: Date;
  mkysStokHareketKodu: string;
  iptalDurumu: string;
  mkysKarsiStokHareketKodu: string;
  mkysKunyeNumarasi: string;
  utsKayitUdi: string;
  bayilikNumarasi: string;
  cihazKodu: string;
  atsSorguNumarasi: string;
  allogreftDonorKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListStokHareketDto {
  id: string;
  stokHareketKodu: string;
  referansTabloAdi: string;
  bagliStokHareketKodu: string;
  ilkGirisStokHareketKodu: string;
  stokIstekHareketKodu: string;
  stokFisKodu: string;
  stokKartKodu: string;
  barkod: string;
}

export interface CreateStokHareketDto {
  stokHareketKodu: string;
  referansTabloAdi: string;
  bagliStokHareketKodu: string;
  ilkGirisStokHareketKodu: string;
  stokIstekHareketKodu: string;
  stokFisKodu: string;
  stokKartKodu: string;
  barkod: string;
  lotNumarasi: string;
  seriSiraNumarasi: string;
  firmaTanimlayiciNumarasi: string;
  malzemeSutKodu: string;
  stokHareketMiktari: string;
  tasinirNumarasi: string;
  alisBirimFiyati: string;
  satisBirimFiyati: string;
  olcuKodu: string;
  islemiYapanPersonelKodu: string;
  kdvOrani: string;
  iskontoOrani: string;
  iskontoTutari: string;
  sonKullanmaTarihi: Date;
  mkysStokHareketKodu: string;
  iptalDurumu: string;
  mkysKarsiStokHareketKodu: string;
  mkysKunyeNumarasi: string;
  utsKayitUdi: string;
  bayilikNumarasi: string;
  cihazKodu: string;
  atsSorguNumarasi: string;
  allogreftDonorKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateStokHareketDto extends CreateStokHareketDto {
  id: string;
}

export interface StokHareketListFilter extends BaseListFilter {
  stokHareketKodu?: string;
  referansTabloAdi?: string;
  bagliStokHareketKodu?: string;
  ilkGirisStokHareketKodu?: string;
  stokIstekHareketKodu?: string;
}

export const newStokHareket: CreateStokHareketDto = {
  stokHareketKodu: '',
  referansTabloAdi: '',
  bagliStokHareketKodu: '',
  ilkGirisStokHareketKodu: '',
  stokIstekHareketKodu: '',
  stokFisKodu: '',
  stokKartKodu: '',
  barkod: '',
  lotNumarasi: '',
  seriSiraNumarasi: '',
  firmaTanimlayiciNumarasi: '',
  malzemeSutKodu: '',
  stokHareketMiktari: '',
  tasinirNumarasi: '',
  alisBirimFiyati: '',
  satisBirimFiyati: '',
  olcuKodu: '',
  islemiYapanPersonelKodu: '',
  kdvOrani: '',
  iskontoOrani: '',
  iskontoTutari: '',
  sonKullanmaTarihi: undefined,
  mkysStokHareketKodu: '',
  iptalDurumu: '',
  mkysKarsiStokHareketKodu: '',
  mkysKunyeNumarasi: '',
  utsKayitUdi: '',
  bayilikNumarasi: '',
  cihazKodu: '',
  atsSorguNumarasi: '',
  allogreftDonorKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
