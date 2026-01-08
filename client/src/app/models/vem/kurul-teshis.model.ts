// KurulTeshis Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KurulTeshisDto extends VemBaseDto {
  kurulTeshisKodu: string;
  referansTabloAdi: string;
  kurulRaporKodu: string;
  ilacTeshisKodu: string;
  taniKodu: string;
  raporBaslamaTarihi: Date;
  raporBitisTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKurulTeshisDto {
  id: string;
  kurulTeshisKodu: string;
  referansTabloAdi: string;
  kurulRaporKodu: string;
  ilacTeshisKodu: string;
  taniKodu: string;
  raporBaslamaTarihi: Date;
  raporBitisTarihi: Date;
  ekleyenKullaniciKodu?: string;
}

export interface CreateKurulTeshisDto {
  kurulTeshisKodu: string;
  referansTabloAdi: string;
  kurulRaporKodu: string;
  ilacTeshisKodu: string;
  taniKodu: string;
  raporBaslamaTarihi: Date;
  raporBitisTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKurulTeshisDto extends CreateKurulTeshisDto {
  id: string;
}

export interface KurulTeshisListFilter extends BaseListFilter {
  kurulTeshisKodu?: string;
  referansTabloAdi?: string;
  kurulRaporKodu?: string;
  ilacTeshisKodu?: string;
  taniKodu?: string;
}

export const newKurulTeshis: CreateKurulTeshisDto = {
  kurulTeshisKodu: '',
  referansTabloAdi: '',
  kurulRaporKodu: '',
  ilacTeshisKodu: '',
  taniKodu: '',
  raporBaslamaTarihi: undefined,
  raporBitisTarihi: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
