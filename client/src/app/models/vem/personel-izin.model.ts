// PersonelIzin Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelIzinDto extends VemBaseDto {
  personelIzinKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelIzinTuru: string;
  kullanilanIzin: string;
  gecenYildanKullanilanIzin: string;
  aktifYildanKullanilanIzin: string;
  izinBaslamaTarihi?: Date;
  izinBitisTarihi: Date;
  personelIzinYili: string;
  personelDonusTarihi: Date;
  izinAdresi: string;
  aciklama: string;
  sbysEngellenmeDurumu: string;
  sbysKullanimEngellemeZamani: Date;
  sbysEngelleyenKullaniciKodu: string;
  onaylayanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelIzinDto {
  id: string;
  personelIzinKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelIzinTuru: string;
  kullanilanIzin: string;
  gecenYildanKullanilanIzin: string;
  aktifYildanKullanilanIzin: string;
  izinBaslamaTarihi?: Date;
}

export interface CreatePersonelIzinDto {
  personelIzinKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  personelIzinTuru: string;
  kullanilanIzin: string;
  gecenYildanKullanilanIzin: string;
  aktifYildanKullanilanIzin: string;
  izinBaslamaTarihi?: Date;
  izinBitisTarihi: Date;
  personelIzinYili: string;
  personelDonusTarihi: Date;
  izinAdresi: string;
  aciklama: string;
  sbysEngellenmeDurumu: string;
  sbysKullanimEngellemeZamani: Date;
  sbysEngelleyenKullaniciKodu: string;
  onaylayanPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelIzinDto extends CreatePersonelIzinDto {
  id: string;
}

export interface PersonelIzinListFilter extends BaseListFilter {
  personelIzinKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  personelIzinTuru?: string;
  kullanilanIzin?: string;
}

export const newPersonelIzin: CreatePersonelIzinDto = {
  personelIzinKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  personelIzinTuru: '',
  kullanilanIzin: '',
  gecenYildanKullanilanIzin: '',
  aktifYildanKullanilanIzin: '',
  izinBaslamaTarihi: undefined,
  izinBitisTarihi: undefined,
  personelIzinYili: '',
  personelDonusTarihi: undefined,
  izinAdresi: '',
  aciklama: '',
  sbysEngellenmeDurumu: '',
  sbysKullanimEngellemeZamani: undefined,
  sbysEngelleyenKullaniciKodu: '',
  onaylayanPersonelKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
