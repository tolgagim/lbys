// SterilizasyonStokDurum Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SterilizasyonStokDurumDto extends VemBaseDto {
  sterilizasyonStokDurumKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  stokMiktari: string;
  sterilOlmayanStokMiktari: string;
  sterilStokMiktari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSterilizasyonStokDurumDto {
  id: string;
  sterilizasyonStokDurumKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  stokMiktari: string;
  sterilOlmayanStokMiktari: string;
  sterilStokMiktari: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateSterilizasyonStokDurumDto {
  sterilizasyonStokDurumKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  stokMiktari: string;
  sterilOlmayanStokMiktari: string;
  sterilStokMiktari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSterilizasyonStokDurumDto extends CreateSterilizasyonStokDurumDto {
  id: string;
}

export interface SterilizasyonStokDurumListFilter extends BaseListFilter {
  sterilizasyonStokDurumKodu?: string;
  referansTabloAdi?: string;
  depoKodu?: string;
  stokKartKodu?: string;
  stokMiktari?: string;
}

export const newSterilizasyonStokDurum: CreateSterilizasyonStokDurumDto = {
  sterilizasyonStokDurumKodu: '',
  referansTabloAdi: '',
  depoKodu: '',
  stokKartKodu: '',
  stokMiktari: '',
  sterilOlmayanStokMiktari: '',
  sterilStokMiktari: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
