// SterilizasyonPaket Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SterilizasyonPaketDto extends VemBaseDto {
  sterilizasyonPaketKodu: string;
  referansTabloAdi: string;
  sterilizasyonPaketAdi: string;
  paketKodu: string;
  aciklama: string;
  sterilizasyonYontemi: string;
  sterilizasyonPaketGrubu: string;
  paketRafOmruBitisGun: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSterilizasyonPaketDto {
  id: string;
  sterilizasyonPaketKodu: string;
  referansTabloAdi: string;
  sterilizasyonPaketAdi: string;
  paketKodu: string;
  aciklama: string;
  sterilizasyonYontemi: string;
  sterilizasyonPaketGrubu: string;
  paketRafOmruBitisGun: string;
}

export interface CreateSterilizasyonPaketDto {
  sterilizasyonPaketKodu: string;
  referansTabloAdi: string;
  sterilizasyonPaketAdi: string;
  paketKodu: string;
  aciklama: string;
  sterilizasyonYontemi: string;
  sterilizasyonPaketGrubu: string;
  paketRafOmruBitisGun: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSterilizasyonPaketDto extends CreateSterilizasyonPaketDto {
  id: string;
}

export interface SterilizasyonPaketListFilter extends BaseListFilter {
  sterilizasyonPaketKodu?: string;
  referansTabloAdi?: string;
  sterilizasyonPaketAdi?: string;
  paketKodu?: string;
  aciklama?: string;
}

export const newSterilizasyonPaket: CreateSterilizasyonPaketDto = {
  sterilizasyonPaketKodu: '',
  referansTabloAdi: '',
  sterilizasyonPaketAdi: '',
  paketKodu: '',
  aciklama: '',
  sterilizasyonYontemi: '',
  sterilizasyonPaketGrubu: '',
  paketRafOmruBitisGun: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
