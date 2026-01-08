// PersonelGorevlendirme Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelGorevlendirmeDto extends VemBaseDto {
  personelGorevlendirmeKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  gorevTuru: string;
  gorevlendirmeBaslamaTarihi?: Date;
  gorevlendirmeBitisTarihi: Date;
  gorevlendirmeIlKodu: string;
  gorevlendirmeIlceKodu: string;
  gorevlendirildigiKurumKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelGorevlendirmeDto {
  id: string;
  personelGorevlendirmeKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  gorevTuru: string;
  gorevlendirmeBaslamaTarihi?: Date;
  gorevlendirmeBitisTarihi: Date;
  gorevlendirmeIlKodu: string;
  gorevlendirmeIlceKodu: string;
}

export interface CreatePersonelGorevlendirmeDto {
  personelGorevlendirmeKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  gorevTuru: string;
  gorevlendirmeBaslamaTarihi?: Date;
  gorevlendirmeBitisTarihi: Date;
  gorevlendirmeIlKodu: string;
  gorevlendirmeIlceKodu: string;
  gorevlendirildigiKurumKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelGorevlendirmeDto extends CreatePersonelGorevlendirmeDto {
  id: string;
}

export interface PersonelGorevlendirmeListFilter extends BaseListFilter {
  personelGorevlendirmeKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  gorevTuru?: string;
  gorevlendirmeIlKodu?: string;
}

export const newPersonelGorevlendirme: CreatePersonelGorevlendirmeDto = {
  personelGorevlendirmeKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  gorevTuru: '',
  gorevlendirmeBaslamaTarihi: undefined,
  gorevlendirmeBitisTarihi: undefined,
  gorevlendirmeIlKodu: '',
  gorevlendirmeIlceKodu: '',
  gorevlendirildigiKurumKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
