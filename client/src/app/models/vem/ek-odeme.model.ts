// EkOdeme Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface EkOdemeDto extends VemBaseDto {
  ekOdemeKodu: string;
  referansTabloAdi: string;
  ekOdemeDonemKodu: string;
  personelKodu: string;
  hesaplamaYontemi: string;
  maasDerecesi: string;
  maasKademesi: string;
  maasGostergesi: string;
  aylikTutari: string;
  ozelHizmetTutari: string;
  ekGostergeTutari: string;
  yanOdemeTutari: string;
  doguTazminatiTutari: string;
  ekOdemeMatrahi: string;
  baskaKurumdakiEkodemeTutari: string;
  dssoTutari: string;
  engellilikIndirimOrani: string;
  komisyonEkPuaniOrani: string;
  ekPuanOrani: string;
  birimPerformansKatsayisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListEkOdemeDto {
  id: string;
  ekOdemeKodu: string;
  referansTabloAdi: string;
  ekOdemeDonemKodu: string;
  personelKodu: string;
  hesaplamaYontemi: string;
  maasDerecesi: string;
  maasKademesi: string;
  maasGostergesi: string;
}

export interface CreateEkOdemeDto {
  ekOdemeKodu: string;
  referansTabloAdi: string;
  ekOdemeDonemKodu: string;
  personelKodu: string;
  hesaplamaYontemi: string;
  maasDerecesi: string;
  maasKademesi: string;
  maasGostergesi: string;
  aylikTutari: string;
  ozelHizmetTutari: string;
  ekGostergeTutari: string;
  yanOdemeTutari: string;
  doguTazminatiTutari: string;
  ekOdemeMatrahi: string;
  baskaKurumdakiEkodemeTutari: string;
  dssoTutari: string;
  engellilikIndirimOrani: string;
  komisyonEkPuaniOrani: string;
  ekPuanOrani: string;
  birimPerformansKatsayisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateEkOdemeDto extends CreateEkOdemeDto {
  id: string;
}

export interface EkOdemeListFilter extends BaseListFilter {
  ekOdemeKodu?: string;
  referansTabloAdi?: string;
  ekOdemeDonemKodu?: string;
  personelKodu?: string;
  hesaplamaYontemi?: string;
}

export const newEkOdeme: CreateEkOdemeDto = {
  ekOdemeKodu: '',
  referansTabloAdi: '',
  ekOdemeDonemKodu: '',
  personelKodu: '',
  hesaplamaYontemi: '',
  maasDerecesi: '',
  maasKademesi: '',
  maasGostergesi: '',
  aylikTutari: '',
  ozelHizmetTutari: '',
  ekGostergeTutari: '',
  yanOdemeTutari: '',
  doguTazminatiTutari: '',
  ekOdemeMatrahi: '',
  baskaKurumdakiEkodemeTutari: '',
  dssoTutari: '',
  engellilikIndirimOrani: '',
  komisyonEkPuaniOrani: '',
  ekPuanOrani: '',
  birimPerformansKatsayisi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
