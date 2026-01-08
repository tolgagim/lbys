// StokFis Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface StokFisDto extends VemBaseDto {
  stokFisKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  bagliStokFisKodu: string;
  depoKodu: string;
  hareketTuru: string;
  mkysAyniyatMakbuzKodu: string;
  hareketTarihi?: Date;
  shcekPayi: string;
  hazinePayi: string;
  saglikBakanligiPayi: string;
  bedelsizFis: string;
  fisTutari: string;
  hareketSekli: string;
  islemiYapanPersonelKodu: string;
  islemZamani?: Date;
  firmaKodu: string;
  ihaleNumarasi: string;
  ihaleTarihi: Date;
  ihaleTuru: string;
  muayeneKabulNumarasi: string;
  muayeneTarihi: Date;
  teslimEdenKisi: string;
  teslimEdenKisiUnvani: string;
  butceTuru: string;
  faturaNumarasi: string;
  faturaZamani: Date;
  irsaliyeNumarasi: string;
  irsaliyeTarihi: Date;
  mkysKurumKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListStokFisDto {
  id: string;
  stokFisKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  bagliStokFisKodu: string;
  depoKodu: string;
  hareketTuru: string;
  mkysAyniyatMakbuzKodu: string;
}

export interface CreateStokFisDto {
  stokFisKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  bagliStokFisKodu: string;
  depoKodu: string;
  hareketTuru: string;
  mkysAyniyatMakbuzKodu: string;
  hareketTarihi?: Date;
  shcekPayi: string;
  hazinePayi: string;
  saglikBakanligiPayi: string;
  bedelsizFis: string;
  fisTutari: string;
  hareketSekli: string;
  islemiYapanPersonelKodu: string;
  islemZamani?: Date;
  firmaKodu: string;
  ihaleNumarasi: string;
  ihaleTarihi: Date;
  ihaleTuru: string;
  muayeneKabulNumarasi: string;
  muayeneTarihi: Date;
  teslimEdenKisi: string;
  teslimEdenKisiUnvani: string;
  butceTuru: string;
  faturaNumarasi: string;
  faturaZamani: Date;
  irsaliyeNumarasi: string;
  irsaliyeTarihi: Date;
  mkysKurumKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateStokFisDto extends CreateStokFisDto {
  id: string;
}

export interface StokFisListFilter extends BaseListFilter {
  stokFisKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  bagliStokFisKodu?: string;
}

export const newStokFis: CreateStokFisDto = {
  stokFisKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  bagliStokFisKodu: '',
  depoKodu: '',
  hareketTuru: '',
  mkysAyniyatMakbuzKodu: '',
  hareketTarihi: undefined,
  shcekPayi: '',
  hazinePayi: '',
  saglikBakanligiPayi: '',
  bedelsizFis: '',
  fisTutari: '',
  hareketSekli: '',
  islemiYapanPersonelKodu: '',
  islemZamani: undefined,
  firmaKodu: '',
  ihaleNumarasi: '',
  ihaleTarihi: undefined,
  ihaleTuru: '',
  muayeneKabulNumarasi: '',
  muayeneTarihi: undefined,
  teslimEdenKisi: '',
  teslimEdenKisiUnvani: '',
  butceTuru: '',
  faturaNumarasi: '',
  faturaZamani: undefined,
  irsaliyeNumarasi: '',
  irsaliyeTarihi: undefined,
  mkysKurumKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
