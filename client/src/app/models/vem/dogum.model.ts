// Dogum Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DogumDto extends VemBaseDto {
  dogumKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaHizmetKodu: string;
  ameliyatKodu: string;
  babaTcKimlikNumarasi: string;
  komplikasyonTanisi: string;
  dogumNotu: string;
  dogumBaslamaZamani?: Date;
  dogumBitisZamani: Date;
  hekimKodu: string;
  ebeKodu: string;
  birimKodu: string;
  defterNumarasi: string;
  guncelleyenKullaniciKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncellemeZamani?: Date;
}

export interface ListDogumDto {
  id: string;
  dogumKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaHizmetKodu: string;
  ameliyatKodu: string;
  babaTcKimlikNumarasi: string;
  komplikasyonTanisi: string;
}

export interface CreateDogumDto {
  dogumKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaHizmetKodu: string;
  ameliyatKodu: string;
  babaTcKimlikNumarasi: string;
  komplikasyonTanisi: string;
  dogumNotu: string;
  dogumBaslamaZamani?: Date;
  dogumBitisZamani: Date;
  hekimKodu: string;
  ebeKodu: string;
  birimKodu: string;
  defterNumarasi: string;
  guncelleyenKullaniciKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncellemeZamani?: Date;
}

export interface UpdateDogumDto extends CreateDogumDto {
  id: string;
}

export interface DogumListFilter extends BaseListFilter {
  dogumKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hastaHizmetKodu?: string;
}

export const newDogum: CreateDogumDto = {
  dogumKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  hastaHizmetKodu: '',
  ameliyatKodu: '',
  babaTcKimlikNumarasi: '',
  komplikasyonTanisi: '',
  dogumNotu: '',
  dogumBaslamaZamani: undefined,
  dogumBitisZamani: undefined,
  hekimKodu: '',
  ebeKodu: '',
  birimKodu: '',
  defterNumarasi: '',
  guncelleyenKullaniciKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncellemeZamani: undefined,
};
