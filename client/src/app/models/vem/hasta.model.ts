// Hasta Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaDto extends VemBaseDto {
  hastaKodu: string;
  tcKimlikNumarasi?: string;
  ad: string;
  soyad: string;
  dogumTarihi?: Date;
  cinsiyet?: string;
  kanGrubu?: string;
  telefon?: string;
  eposta?: string;
  adres?: string;
}

export interface ListHastaDto {
  id: string;
  hastaKodu: string;
  tcKimlikNumarasi?: string;
  ad: string;
  soyad: string;
  dogumTarihi?: Date;
  cinsiyet?: string;
}

export interface CreateHastaDto {
  hastaKodu: string;
  tcKimlikNumarasi?: string;
  ad: string;
  soyad: string;
  dogumTarihi?: Date;
  cinsiyet?: string;
  kanGrubu?: string;
  telefon?: string;
  eposta?: string;
  adres?: string;
}

export interface UpdateHastaDto extends CreateHastaDto {
  id: string;
}

export interface HastaListFilter extends BaseListFilter {
  hastaKodu?: string;
  tcKimlikNumarasi?: string;
  ad?: string;
  soyad?: string;
  ANNE_ADI?: string | null;
  ANNE_HASTA_KODU?: string | null;
  ANNE_TC_KIMLIK_NUMARASI?: string | null;
  BABA_HASTA_KODU?: string | null;
  BABA_TC_KIMLIK_NUMARASI?: string | null;
  BEYAN_DOGUM_TARIHI?: Date | null;
  DOGUM_SIRASI?: number | null;
  ENGELLILIK_DURUMU?: string | null;
  HASTA_TIPI?: string | null;
  KIMLIKSIZ_HASTA_BILGISI?: string | null;
  MEDENI_HALI?: string | null;
  MUAYENE_ONCELIK_SIRASI?: number | null;
  OGRENIM_DURUMU?: string | null;
  OLUM_YERI?: string | null;
  PASAPORT_NUMARASI?: string | null;
  SON_KURUM_KODU?: string | null;
  SOYADI?: string | null;
  TC_KIMLIK_NUMARASI?: string | null;
  YUPASS_NUMARASI?: string | null;
}

export const newHasta: CreateHastaDto = {
  hastaKodu: '',
  tcKimlikNumarasi: '',
  ad: '',
  soyad: '',
  dogumTarihi: undefined,
  cinsiyet: '',
  kanGrubu: '',
  telefon: '',
  eposta: '',
  adres: ''
};
