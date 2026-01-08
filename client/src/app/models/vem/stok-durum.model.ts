// StokDurum Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface StokDurumDto extends VemBaseDto {
  stokDurumKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  maksimumStok: string;
  minimumStok: string;
  kritikStok: string;
  toplamGirisMiktari: string;
  toplamCikisMiktari: string;
  stokMiktari: string;
  olcuKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListStokDurumDto {
  id: string;
  stokDurumKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  maksimumStok: string;
  minimumStok: string;
  kritikStok: string;
  toplamGirisMiktari: string;
}

export interface CreateStokDurumDto {
  stokDurumKodu: string;
  referansTabloAdi: string;
  depoKodu: string;
  stokKartKodu: string;
  maksimumStok: string;
  minimumStok: string;
  kritikStok: string;
  toplamGirisMiktari: string;
  toplamCikisMiktari: string;
  stokMiktari: string;
  olcuKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateStokDurumDto extends CreateStokDurumDto {
  id: string;
}

export interface StokDurumListFilter extends BaseListFilter {
  stokDurumKodu?: string;
  referansTabloAdi?: string;
  depoKodu?: string;
  stokKartKodu?: string;
  maksimumStok?: string;
}

export const newStokDurum: CreateStokDurumDto = {
  stokDurumKodu: '',
  referansTabloAdi: '',
  depoKodu: '',
  stokKartKodu: '',
  maksimumStok: '',
  minimumStok: '',
  kritikStok: '',
  toplamGirisMiktari: '',
  toplamCikisMiktari: '',
  stokMiktari: '',
  olcuKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
