// SterilizasyonSet Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SterilizasyonSetDto extends VemBaseDto {
  sterilizasyonSetKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  sterilizasyonPaketKodu: string;
  barkod: string;
  barkodBasanKullaniciKodu: string;
  barkodZamani: Date;
  cihazKodu: string;
  sterilizasyonCevrimNumarasi: string;
  setIadeDurumu: string;
  setIadeZamani: Date;
  setIadeEdenPersonelKodu: string;
  setIadeAlanPersonelKodu: string;
  paketRafOmruBitisTarihi: Date;
  paketleyenPersonelKodu: string;
  islemZamani?: Date;
  sterilizasyonBaslamaZamani?: Date;
  sterilizasyonBitisZamani: Date;
  sterilizasyonPersonelKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSterilizasyonSetDto {
  id: string;
  sterilizasyonSetKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  sterilizasyonPaketKodu: string;
  barkod: string;
  barkodBasanKullaniciKodu: string;
  barkodZamani: Date;
  cihazKodu: string;
}

export interface CreateSterilizasyonSetDto {
  sterilizasyonSetKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  sterilizasyonPaketKodu: string;
  barkod: string;
  barkodBasanKullaniciKodu: string;
  barkodZamani: Date;
  cihazKodu: string;
  sterilizasyonCevrimNumarasi: string;
  setIadeDurumu: string;
  setIadeZamani: Date;
  setIadeEdenPersonelKodu: string;
  setIadeAlanPersonelKodu: string;
  paketRafOmruBitisTarihi: Date;
  paketleyenPersonelKodu: string;
  islemZamani?: Date;
  sterilizasyonBaslamaZamani?: Date;
  sterilizasyonBitisZamani: Date;
  sterilizasyonPersonelKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSterilizasyonSetDto extends CreateSterilizasyonSetDto {
  id: string;
}

export interface SterilizasyonSetListFilter extends BaseListFilter {
  sterilizasyonSetKodu?: string;
  referansTabloAdi?: string;
  depoKodu?: string;
  sterilizasyonPaketKodu?: string;
  barkod?: string;
}

export const newSterilizasyonSet: CreateSterilizasyonSetDto = {
  sterilizasyonSetKodu: '',
  referansTabloAdi: '',
  depoKodu: '',
  sterilizasyonPaketKodu: '',
  barkod: '',
  barkodBasanKullaniciKodu: '',
  barkodZamani: undefined,
  cihazKodu: '',
  sterilizasyonCevrimNumarasi: '',
  setIadeDurumu: '',
  setIadeZamani: undefined,
  setIadeEdenPersonelKodu: '',
  setIadeAlanPersonelKodu: '',
  paketRafOmruBitisTarihi: undefined,
  paketleyenPersonelKodu: '',
  islemZamani: undefined,
  sterilizasyonBaslamaZamani: undefined,
  sterilizasyonBitisZamani: undefined,
  sterilizasyonPersonelKodu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
