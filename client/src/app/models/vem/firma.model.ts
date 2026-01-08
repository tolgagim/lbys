// Firma Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface FirmaDto extends VemBaseDto {
  firmaKodu: string;
  referansTabloAdi: string;
  firmaAdi: string;
  telefonNumarasi: string;
  yetkiliKisi: string;
  firmaAdresi: string;
  aktiflikBilgisi: string;
  vergiDairesi: string;
  vergiNumarasi: string;
  epostaAdresi: string;
  ibanNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListFirmaDto {
  id: string;
  firmaKodu: string;
  referansTabloAdi: string;
  firmaAdi: string;
  telefonNumarasi: string;
  yetkiliKisi: string;
  firmaAdresi: string;
  aktiflikBilgisi: string;
  vergiDairesi: string;
}

export interface CreateFirmaDto {
  firmaKodu: string;
  referansTabloAdi: string;
  firmaAdi: string;
  telefonNumarasi: string;
  yetkiliKisi: string;
  firmaAdresi: string;
  aktiflikBilgisi: string;
  vergiDairesi: string;
  vergiNumarasi: string;
  epostaAdresi: string;
  ibanNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateFirmaDto extends CreateFirmaDto {
  id: string;
}

export interface FirmaListFilter extends BaseListFilter {
  firmaKodu?: string;
  referansTabloAdi?: string;
  firmaAdi?: string;
  telefonNumarasi?: string;
  yetkiliKisi?: string;
}

export const newFirma: CreateFirmaDto = {
  firmaKodu: '',
  referansTabloAdi: '',
  firmaAdi: '',
  telefonNumarasi: '',
  yetkiliKisi: '',
  firmaAdresi: '',
  aktiflikBilgisi: '',
  vergiDairesi: '',
  vergiNumarasi: '',
  epostaAdresi: '',
  ibanNumarasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
