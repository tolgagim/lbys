// StokIstek Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface StokIstekDto extends VemBaseDto {
  stokIstekKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  istekZamani?: Date;
  istekDepoKodu: string;
  hekimKodu: string;
  stokIstekDurumu: string;
  stokIstekHekimAciklama: string;
  ameliyatKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListStokIstekDto {
  id: string;
  stokIstekKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  istekZamani?: Date;
  istekDepoKodu: string;
  hekimKodu: string;
  stokIstekDurumu: string;
}

export interface CreateStokIstekDto {
  stokIstekKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  istekZamani?: Date;
  istekDepoKodu: string;
  hekimKodu: string;
  stokIstekDurumu: string;
  stokIstekHekimAciklama: string;
  ameliyatKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateStokIstekDto extends CreateStokIstekDto {
  id: string;
}

export interface StokIstekListFilter extends BaseListFilter {
  stokIstekKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  istekDepoKodu?: string;
}

export const newStokIstek: CreateStokIstekDto = {
  stokIstekKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  istekZamani: undefined,
  istekDepoKodu: '',
  hekimKodu: '',
  stokIstekDurumu: '',
  stokIstekHekimAciklama: '',
  ameliyatKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
