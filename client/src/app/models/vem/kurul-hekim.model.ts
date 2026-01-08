// KurulHekim Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KurulHekimDto extends VemBaseDto {
  kurulHekimKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  kurulRaporKodu: string;
  hekimKodu: string;
  medulaBransKodu: string;
  sistemKodu: string;
  kurulSonuc: string;
  engellilikOrani: string;
  hekimKurulGorevi: string;
  hekimSiraNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKurulHekimDto {
  id: string;
  kurulHekimKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  kurulRaporKodu: string;
  hekimKodu: string;
  medulaBransKodu: string;
  sistemKodu: string;
}

export interface CreateKurulHekimDto {
  kurulHekimKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  kurulRaporKodu: string;
  hekimKodu: string;
  medulaBransKodu: string;
  sistemKodu: string;
  kurulSonuc: string;
  engellilikOrani: string;
  hekimKurulGorevi: string;
  hekimSiraNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKurulHekimDto extends CreateKurulHekimDto {
  id: string;
}

export interface KurulHekimListFilter extends BaseListFilter {
  kurulHekimKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  kurulRaporKodu?: string;
}

export const newKurulHekim: CreateKurulHekimDto = {
  kurulHekimKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  kurulRaporKodu: '',
  hekimKodu: '',
  medulaBransKodu: '',
  sistemKodu: '',
  kurulSonuc: '',
  engellilikOrani: '',
  hekimKurulGorevi: '',
  hekimSiraNumarasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
