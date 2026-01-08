// ObeziteIzlem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface ObeziteIzlemDto extends VemBaseDto {
  obeziteIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  diyetTibbiBeslenmeTedavisi: string;
  ilkTaniTarihi: Date;
  morbitObezLenfatikOdem: string;
  obeziteIlacTedavisi: string;
  psikolojikTedavi: string;
  birlikteGorulenEkHastalik: string;
  egzersiz: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListObeziteIzlemDto {
  id: string;
  obeziteIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  diyetTibbiBeslenmeTedavisi: string;
  ilkTaniTarihi: Date;
  morbitObezLenfatikOdem: string;
  obeziteIlacTedavisi: string;
}

export interface CreateObeziteIzlemDto {
  obeziteIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  diyetTibbiBeslenmeTedavisi: string;
  ilkTaniTarihi: Date;
  morbitObezLenfatikOdem: string;
  obeziteIlacTedavisi: string;
  psikolojikTedavi: string;
  birlikteGorulenEkHastalik: string;
  egzersiz: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateObeziteIzlemDto extends CreateObeziteIzlemDto {
  id: string;
}

export interface ObeziteIzlemListFilter extends BaseListFilter {
  obeziteIzlemKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  diyetTibbiBeslenmeTedavisi?: string;
}

export const newObeziteIzlem: CreateObeziteIzlemDto = {
  obeziteIzlemKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  diyetTibbiBeslenmeTedavisi: '',
  ilkTaniTarihi: undefined,
  morbitObezLenfatikOdem: '',
  obeziteIlacTedavisi: '',
  psikolojikTedavi: '',
  birlikteGorulenEkHastalik: '',
  egzersiz: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
