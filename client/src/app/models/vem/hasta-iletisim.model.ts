// HastaIletisim Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaIletisimDto extends VemBaseDto {
  hastaIletisimKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  adresTipi: string;
  adresKoduSeviyesi: string;
  beyanAdresi: string;
  nviAdres: string;
  adresNumarasi: string;
  ilKodu: string;
  ilceKodu: string;
  bucakKodu: string;
  koyKodu: string;
  mahalleKodu: string;
  csbmKodu: string;
  disKapiNumarasi: string;
  icKapiNumarasi: string;
  evTelefonu: string;
  cepTelefonu: string;
  isTelefonu: string;
  epostaAdresi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaIletisimDto {
  id: string;
  hastaIletisimKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  adresTipi: string;
  adresKoduSeviyesi: string;
  beyanAdresi: string;
  nviAdres: string;
}

export interface CreateHastaIletisimDto {
  hastaIletisimKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  adresTipi: string;
  adresKoduSeviyesi: string;
  beyanAdresi: string;
  nviAdres: string;
  adresNumarasi: string;
  ilKodu: string;
  ilceKodu: string;
  bucakKodu: string;
  koyKodu: string;
  mahalleKodu: string;
  csbmKodu: string;
  disKapiNumarasi: string;
  icKapiNumarasi: string;
  evTelefonu: string;
  cepTelefonu: string;
  isTelefonu: string;
  epostaAdresi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaIletisimDto extends CreateHastaIletisimDto {
  id: string;
}

export interface HastaIletisimListFilter extends BaseListFilter {
  hastaIletisimKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  adresTipi?: string;
}

export const newHastaIletisim: CreateHastaIletisimDto = {
  hastaIletisimKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  adresTipi: '',
  adresKoduSeviyesi: '',
  beyanAdresi: '',
  nviAdres: '',
  adresNumarasi: '',
  ilKodu: '',
  ilceKodu: '',
  bucakKodu: '',
  koyKodu: '',
  mahalleKodu: '',
  csbmKodu: '',
  disKapiNumarasi: '',
  icKapiNumarasi: '',
  evTelefonu: '',
  cepTelefonu: '',
  isTelefonu: '',
  epostaAdresi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
