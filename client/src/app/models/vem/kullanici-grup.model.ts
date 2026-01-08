// KullaniciGrup Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KullaniciGrupDto extends VemBaseDto {
  kullaniciGrupKodu: string;
  referansTabloAdi: string;
  kullaniciGrupAdi: string;
  aktiflikBilgisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKullaniciGrupDto {
  id: string;
  kullaniciGrupKodu: string;
  referansTabloAdi: string;
  kullaniciGrupAdi: string;
  aktiflikBilgisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface CreateKullaniciGrupDto {
  kullaniciGrupKodu: string;
  referansTabloAdi: string;
  kullaniciGrupAdi: string;
  aktiflikBilgisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKullaniciGrupDto extends CreateKullaniciGrupDto {
  id: string;
}

export interface KullaniciGrupListFilter extends BaseListFilter {
  kullaniciGrupKodu?: string;
  referansTabloAdi?: string;
  kullaniciGrupAdi?: string;
  aktiflikBilgisi?: string;
  ekleyenKullaniciKodu?: string;
}

export const newKullaniciGrup: CreateKullaniciGrupDto = {
  kullaniciGrupKodu: '',
  referansTabloAdi: '',
  kullaniciGrupAdi: '',
  aktiflikBilgisi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
