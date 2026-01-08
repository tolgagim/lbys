// PersonelBakmaklaYukumlu Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelBakmaklaYukumluDto extends VemBaseDto {
  personelBakmaklaYukumluKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelYakinlikDerecesi: string;
  tcKimlikNumarasi: string;
  ad: string;
  soyadi: string;
  dogumTarihi?: Date;
  ogrenimDurumu: string;
  engellilikDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelBakmaklaYukumluDto {
  id: string;
  personelBakmaklaYukumluKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelYakinlikDerecesi: string;
  tcKimlikNumarasi: string;
  ad: string;
  soyadi: string;
  dogumTarihi?: Date;
}

export interface CreatePersonelBakmaklaYukumluDto {
  personelBakmaklaYukumluKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelYakinlikDerecesi: string;
  tcKimlikNumarasi: string;
  ad: string;
  soyadi: string;
  dogumTarihi?: Date;
  ogrenimDurumu: string;
  engellilikDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelBakmaklaYukumluDto extends CreatePersonelBakmaklaYukumluDto {
  id: string;
}

export interface PersonelBakmaklaYukumluListFilter extends BaseListFilter {
  personelBakmaklaYukumluKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  personelYakinlikDerecesi?: string;
  tcKimlikNumarasi?: string;
}

export const newPersonelBakmaklaYukumlu: CreatePersonelBakmaklaYukumluDto = {
  personelBakmaklaYukumluKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  personelYakinlikDerecesi: '',
  tcKimlikNumarasi: '',
  ad: '',
  soyadi: '',
  dogumTarihi: undefined,
  ogrenimDurumu: '',
  engellilikDurumu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
