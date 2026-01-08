// Diyabet Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DiyabetDto extends VemBaseDto {
  diyabetKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  ilkTaniTarihi?: Date;
  agirlik: string;
  boy: string;
  diyabetEgitimi: string;
  diyabetKomplikasyonlari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListDiyabetDto {
  id: string;
  diyabetKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  ilkTaniTarihi?: Date;
  agirlik: string;
  boy: string;
  diyabetEgitimi: string;
  diyabetKomplikasyonlari: string;
}

export interface CreateDiyabetDto {
  diyabetKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  ilkTaniTarihi?: Date;
  agirlik: string;
  boy: string;
  diyabetEgitimi: string;
  diyabetKomplikasyonlari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateDiyabetDto extends CreateDiyabetDto {
  id: string;
}

export interface DiyabetListFilter extends BaseListFilter {
  diyabetKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  agirlik?: string;
  boy?: string;
}

export const newDiyabet: CreateDiyabetDto = {
  diyabetKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  ilkTaniTarihi: undefined,
  agirlik: '',
  boy: '',
  diyabetEgitimi: '',
  diyabetKomplikasyonlari: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
