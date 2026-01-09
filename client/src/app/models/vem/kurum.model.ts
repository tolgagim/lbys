// Kurum Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KurumDto extends VemBaseDto {
  kurumKodu: string;
  kurumAdi: string;
  kurumTuru?: string;
  ilKodu?: string;
  ilceKodu?: string;
  adres?: string;
  telefon?: string;
  email?: string;
  vergiNo?: string;
  vergiDairesi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKurumDto {
  id: string;
  kurumKodu: string;
  kurumAdi: string;
  kurumTuru?: string;
  ilKodu?: string;
  ilceKodu?: string;
  adres?: string;
  telefon?: string;
  email?: string;
}

export interface CreateKurumDto {
  kurumKodu: string;
  kurumAdi: string;
  kurumTuru?: string;
  ilKodu?: string;
  ilceKodu?: string;
  adres?: string;
  telefon?: string;
  email?: string;
  vergiNo?: string;
  vergiDairesi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKurumDto extends CreateKurumDto {
  id: string;
}

export interface KurumListFilter extends BaseListFilter {
  kurumKodu?: string;
  kurumAdi?: string;
  kurumTuru?: string;
  ilKodu?: string;
  ilceKodu?: string;
  AKTIFLIK_BILGISI?: string | null;
  AYAKTAN_BUTCE_KODU?: string | null;
  DEVREDILEN_KURUM?: string | null;
  GUNUBIRLIK_BUTCE_KODU?: string | null;
  HASTA_KURUM_TURU?: string | null;
  KURUM_ADRESI?: string | null;
  SKRS_KURUM_KODU?: string | null;
  YATAN_BUTCE_KODU?: string | null;
}

export const newKurum: CreateKurumDto = {
  kurumKodu: '',
  kurumAdi: '',
  kurumTuru: '',
  ilKodu: '',
  ilceKodu: '',
  adres: '',
  telefon: '',
  email: '',
  vergiNo: '',
  vergiDairesi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
