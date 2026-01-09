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
  ACIK_ADRES?: string | null;
  ADRES_KODU_SEVIYESI?: string | null;
  ADRES_TIPI?: string | null;
  AKADEMIK_UNVAN?: string | null;
  AKTIFLIK_BILGISI?: string | null;
  ANNE_ADI?: string | null;
  ASALET_ALMA_TARIHI?: Date | null;
  ASKERLIK_DURUMU?: string | null;
  BABA_ADI?: string | null;
  CALISMA_DURUMU?: string | null;
  CALISTIGI_BIRIM_KODU?: string | null;
  CEP_TELEFONU?: string | null;
  DEVLET_HIZMET_YUKUMLULUK_KODU?: string | null;
  DIPLOMA_NUMARASI?: string | null;
  DOGUM_YERI?: string | null;
  EMEKLI_SICIL_NUMARASI?: string | null;
  EMEKLI_TERFI_TARIHI?: Date | null;
  ENGELLILIK_DURUMU?: string | null;
  EPOSTA_ADRESI?: string | null;
  EV_TELEFONU?: string | null;
  FOTOGRAF_BILGISI?: string | null;
  FOTOGRAF_DOSYA_YOLU?: string | null;
  HEKIM_MEDULA_SIFRESI?: string | null;
  IL_KODU?: string | null;
  ILCE_KODU?: string | null;
  ILK_ISE_BASLAMA_TARIHI?: Date | null;
  IMZA_UNVAN_KODU?: string | null;
  IS_DURUMU?: string | null;
  ISTEN_AYRILMA_ACIKLAMASI?: string | null;
  ISTEN_AYRILMA_NEDENI?: string | null;
  ISTEN_AYRILMA_TARIHI?: Date | null;
  KADRO_UNVAN_KODU?: string | null;
  KADROLU_GOREV_YERI?: string | null;
  KAN_GRUBU?: string | null;
  KLINIK_KODU?: string | null;
  MEDULA_BRANS_KODU?: string | null;
  MEMURIYET_TIPI?: string | null;
  MEMURIYETE_BASLAMA_TARIHI?: Date | null;
  OGRENIM_DURUMU?: string | null;
  ONCEKI_SOYADI?: string | null;
  PERSONEL_GOREV_KODU?: string | null;
  PERSONEL_SICIL_NUMARASI?: string | null;
  SAGLIK_TESISINE_BASLAMA_TARIHI?: Date | null;
  SOYADI?: string | null;
  TC_KIMLIK_NUMARASI?: string | null;
  TERFI_TARIHI?: Date | null;
  TESCIL_NUMARASI?: string | null;
  ULKE_KODU?: string | null;
  UNVAN_KODU?: string | null;
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
