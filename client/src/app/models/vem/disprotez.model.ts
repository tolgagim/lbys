// Disprotez Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DisprotezDto extends VemBaseDto {
  disprotezKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  disprotezBaslamaTarihi?: Date;
  teknisyenKodu: string;
  hekimKodu: string;
  birimKodu: string;
  disprotezIsTuruKodu: string;
  disprotezIsTuruAltKodu: string;
  parcaSayisi: string;
  disprotezAyakSayisi: string;
  disprotezGovdeSayisi: string;
  aciklama: string;
  disprotezBirimKodu: string;
  rptSebebi: string;
  rptZamani: Date;
  rptEdenPersonelKodu: string;
  barkodZamani: Date;
  disprotezKasikTuru: string;
  disprotezRengi: string;
  disBoyutBilgisi: string;
  disprotezAciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListDisprotezDto {
  id: string;
  disprotezKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  disprotezBaslamaTarihi?: Date;
  teknisyenKodu: string;
  hekimKodu: string;
  birimKodu: string;
}

export interface CreateDisprotezDto {
  disprotezKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  disprotezBaslamaTarihi?: Date;
  teknisyenKodu: string;
  hekimKodu: string;
  birimKodu: string;
  disprotezIsTuruKodu: string;
  disprotezIsTuruAltKodu: string;
  parcaSayisi: string;
  disprotezAyakSayisi: string;
  disprotezGovdeSayisi: string;
  aciklama: string;
  disprotezBirimKodu: string;
  rptSebebi: string;
  rptZamani: Date;
  rptEdenPersonelKodu: string;
  barkodZamani: Date;
  disprotezKasikTuru: string;
  disprotezRengi: string;
  disBoyutBilgisi: string;
  disprotezAciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateDisprotezDto extends CreateDisprotezDto {
  id: string;
}

export interface DisprotezListFilter extends BaseListFilter {
  disprotezKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  teknisyenKodu?: string;
}

export const newDisprotez: CreateDisprotezDto = {
  disprotezKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  disprotezBaslamaTarihi: undefined,
  teknisyenKodu: '',
  hekimKodu: '',
  birimKodu: '',
  disprotezIsTuruKodu: '',
  disprotezIsTuruAltKodu: '',
  parcaSayisi: '',
  disprotezAyakSayisi: '',
  disprotezGovdeSayisi: '',
  aciklama: '',
  disprotezBirimKodu: '',
  rptSebebi: '',
  rptZamani: undefined,
  rptEdenPersonelKodu: '',
  barkodZamani: undefined,
  disprotezKasikTuru: '',
  disprotezRengi: '',
  disBoyutBilgisi: '',
  disprotezAciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
