// DisTaahhut Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DisTaahhutDto extends VemBaseDto {
  disTaahhutKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  hekimKodu: string;
  disTaahhutNumarasi: string;
  sgkTakipNumarasi: string;
  caddeSokak: string;
  disKapiNumarasi: string;
  epostaAdresi: string;
  icKapiNumarasi: string;
  ilKodu: string;
  telefonNumarasi: string;
  ilceKodu: string;
  medulaSonucKodu: string;
  medulaSonucMesaji: string;
  iptalDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListDisTaahhutDto {
  id: string;
  disTaahhutKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  hekimKodu: string;
  disTaahhutNumarasi: string;
  sgkTakipNumarasi: string;
  caddeSokak: string;
}

export interface CreateDisTaahhutDto {
  disTaahhutKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  hekimKodu: string;
  disTaahhutNumarasi: string;
  sgkTakipNumarasi: string;
  caddeSokak: string;
  disKapiNumarasi: string;
  epostaAdresi: string;
  icKapiNumarasi: string;
  ilKodu: string;
  telefonNumarasi: string;
  ilceKodu: string;
  medulaSonucKodu: string;
  medulaSonucMesaji: string;
  iptalDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateDisTaahhutDto extends CreateDisTaahhutDto {
  id: string;
}

export interface DisTaahhutListFilter extends BaseListFilter {
  disTaahhutKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  hekimKodu?: string;
}

export const newDisTaahhut: CreateDisTaahhutDto = {
  disTaahhutKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  hekimKodu: '',
  disTaahhutNumarasi: '',
  sgkTakipNumarasi: '',
  caddeSokak: '',
  disKapiNumarasi: '',
  epostaAdresi: '',
  icKapiNumarasi: '',
  ilKodu: '',
  telefonNumarasi: '',
  ilceKodu: '',
  medulaSonucKodu: '',
  medulaSonucMesaji: '',
  iptalDurumu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
