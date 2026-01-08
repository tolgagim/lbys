// Personel Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelDto extends VemBaseDto {
  personelKodu: string;
  tcKimlikNo: string;
  ad: string;
  soyad: string;
  unvan?: string;
  uzmanlikKodu?: string;
  birimKodu?: string;
  cinsiyet?: string;
  dogumTarihi?: Date;
  telefon?: string;
  email?: string;
  diplomaNo?: string;
  diplomaTescilNo?: string;
  iseBaslamaTarihi?: Date;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelDto {
  id: string;
  personelKodu: string;
  tcKimlikNo: string;
  ad: string;
  soyad: string;
  unvan?: string;
  uzmanlikKodu?: string;
  birimKodu?: string;
  cinsiyet?: string;
}

export interface CreatePersonelDto {
  personelKodu: string;
  tcKimlikNo: string;
  ad: string;
  soyad: string;
  unvan?: string;
  uzmanlikKodu?: string;
  birimKodu?: string;
  cinsiyet?: string;
  dogumTarihi?: Date;
  telefon?: string;
  email?: string;
  diplomaNo?: string;
  diplomaTescilNo?: string;
  iseBaslamaTarihi?: Date;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelDto extends CreatePersonelDto {
  id: string;
}

export interface PersonelListFilter extends BaseListFilter {
  personelKodu?: string;
  tcKimlikNo?: string;
  ad?: string;
  soyad?: string;
  unvan?: string;
}

export const newPersonel: CreatePersonelDto = {
  personelKodu: '',
  tcKimlikNo: '',
  ad: '',
  soyad: '',
  unvan: '',
  uzmanlikKodu: '',
  birimKodu: '',
  cinsiyet: '',
  dogumTarihi: undefined,
  telefon: '',
  email: '',
  diplomaNo: '',
  diplomaTescilNo: '',
  iseBaslamaTarihi: undefined,
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
