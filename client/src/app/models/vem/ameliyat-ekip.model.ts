// AmeliyatEkip Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface AmeliyatEkipDto extends VemBaseDto {
  ameliyatEkipKodu: string;
  referansTabloAdi: string;
  ameliyatKodu: string;
  ameliyatIslemKodu: string;
  ekipNumarasi: string;
  personelKodu: string;
  ameliyatPersonelGorev: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListAmeliyatEkipDto {
  id: string;
  ameliyatEkipKodu: string;
  referansTabloAdi: string;
  ameliyatKodu: string;
  ameliyatIslemKodu: string;
  ekipNumarasi: string;
  personelKodu: string;
  ameliyatPersonelGorev: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateAmeliyatEkipDto {
  ameliyatEkipKodu: string;
  referansTabloAdi: string;
  ameliyatKodu: string;
  ameliyatIslemKodu: string;
  ekipNumarasi: string;
  personelKodu: string;
  ameliyatPersonelGorev: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateAmeliyatEkipDto extends CreateAmeliyatEkipDto {
  id: string;
}

export interface AmeliyatEkipListFilter extends BaseListFilter {
  ameliyatEkipKodu?: string;
  referansTabloAdi?: string;
  ameliyatKodu?: string;
  ameliyatIslemKodu?: string;
  ekipNumarasi?: string;
}

export const newAmeliyatEkip: CreateAmeliyatEkipDto = {
  ameliyatEkipKodu: '',
  referansTabloAdi: '',
  ameliyatKodu: '',
  ameliyatIslemKodu: '',
  ekipNumarasi: '',
  personelKodu: '',
  ameliyatPersonelGorev: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
