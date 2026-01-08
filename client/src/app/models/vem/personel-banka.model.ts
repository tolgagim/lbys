// PersonelBanka Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelBankaDto extends VemBaseDto {
  personelBankaKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  banka: string;
  hesapNumarasi: string;
  subeKodu: string;
  ibanNumarasi: string;
  bordroTuru: string;
  hesapAktiflikBilgisi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelBankaDto {
  id: string;
  personelBankaKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  banka: string;
  hesapNumarasi: string;
  subeKodu: string;
  ibanNumarasi: string;
  bordroTuru: string;
}

export interface CreatePersonelBankaDto {
  personelBankaKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  banka: string;
  hesapNumarasi: string;
  subeKodu: string;
  ibanNumarasi: string;
  bordroTuru: string;
  hesapAktiflikBilgisi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelBankaDto extends CreatePersonelBankaDto {
  id: string;
}

export interface PersonelBankaListFilter extends BaseListFilter {
  personelBankaKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  banka?: string;
  hesapNumarasi?: string;
}

export const newPersonelBanka: CreatePersonelBankaDto = {
  personelBankaKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  banka: '',
  hesapNumarasi: '',
  subeKodu: '',
  ibanNumarasi: '',
  bordroTuru: '',
  hesapAktiflikBilgisi: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
