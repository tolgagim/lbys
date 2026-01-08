// Radyoloji Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface RadyolojiDto extends VemBaseDto {
  radyolojiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  birimKodu: string;
  tetkikCekimKabulZamani: Date;
  barkod: string;
  barkodZamani: Date;
  cihazKodu: string;
  calismaBaslamaZamani: Date;
  calismaBitisZamani: Date;
  kabulEdenKullaniciKodu: string;
  tetkikCekenTeknisyenKodu: string;
  hastaHizmetKodu: string;
  loincKodu: string;
  tetkikIstenmeDurumu: string;
  erisimNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListRadyolojiDto {
  id: string;
  radyolojiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  birimKodu: string;
  tetkikCekimKabulZamani: Date;
  barkod: string;
  barkodZamani: Date;
}

export interface CreateRadyolojiDto {
  radyolojiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  birimKodu: string;
  tetkikCekimKabulZamani: Date;
  barkod: string;
  barkodZamani: Date;
  cihazKodu: string;
  calismaBaslamaZamani: Date;
  calismaBitisZamani: Date;
  kabulEdenKullaniciKodu: string;
  tetkikCekenTeknisyenKodu: string;
  hastaHizmetKodu: string;
  loincKodu: string;
  tetkikIstenmeDurumu: string;
  erisimNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateRadyolojiDto extends CreateRadyolojiDto {
  id: string;
}

export interface RadyolojiListFilter extends BaseListFilter {
  radyolojiKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  birimKodu?: string;
}

export const newRadyoloji: CreateRadyolojiDto = {
  radyolojiKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  birimKodu: '',
  tetkikCekimKabulZamani: undefined,
  barkod: '',
  barkodZamani: undefined,
  cihazKodu: '',
  calismaBaslamaZamani: undefined,
  calismaBitisZamani: undefined,
  kabulEdenKullaniciKodu: '',
  tetkikCekenTeknisyenKodu: '',
  hastaHizmetKodu: '',
  loincKodu: '',
  tetkikIstenmeDurumu: '',
  erisimNumarasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
