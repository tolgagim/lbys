// TetkikReferansAralik Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface TetkikReferansAralikDto extends VemBaseDto {
  tetkikReferansAralikKodu: string;
  referansTabloAdi: string;
  tetkikParametreKodu: string;
  tetkikKodu: string;
  cihazKodu: string;
  tetkikCinsiyet: string;
  yasAraligiBaslangicGun: string;
  yasAraligiBitisGun: string;
  referansBaslangicDegeri: string;
  referansBitisDegeri: string;
  altKritikDeger: string;
  ustKritikDeger: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListTetkikReferansAralikDto {
  id: string;
  tetkikReferansAralikKodu: string;
  referansTabloAdi: string;
  tetkikParametreKodu: string;
  tetkikKodu: string;
  cihazKodu: string;
  tetkikCinsiyet: string;
  yasAraligiBaslangicGun: string;
  yasAraligiBitisGun: string;
}

export interface CreateTetkikReferansAralikDto {
  tetkikReferansAralikKodu: string;
  referansTabloAdi: string;
  tetkikParametreKodu: string;
  tetkikKodu: string;
  cihazKodu: string;
  tetkikCinsiyet: string;
  yasAraligiBaslangicGun: string;
  yasAraligiBitisGun: string;
  referansBaslangicDegeri: string;
  referansBitisDegeri: string;
  altKritikDeger: string;
  ustKritikDeger: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateTetkikReferansAralikDto extends CreateTetkikReferansAralikDto {
  id: string;
}

export interface TetkikReferansAralikListFilter extends BaseListFilter {
  tetkikReferansAralikKodu?: string;
  referansTabloAdi?: string;
  tetkikParametreKodu?: string;
  tetkikKodu?: string;
  cihazKodu?: string;
}

export const newTetkikReferansAralik: CreateTetkikReferansAralikDto = {
  tetkikReferansAralikKodu: '',
  referansTabloAdi: '',
  tetkikParametreKodu: '',
  tetkikKodu: '',
  cihazKodu: '',
  tetkikCinsiyet: '',
  yasAraligiBaslangicGun: '',
  yasAraligiBitisGun: '',
  referansBaslangicDegeri: '',
  referansBitisDegeri: '',
  altKritikDeger: '',
  ustKritikDeger: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
