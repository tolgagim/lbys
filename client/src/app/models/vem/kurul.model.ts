// Kurul Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KurulDto extends VemBaseDto {
  kurulKodu: string;
  referansTabloAdi: string;
  kurulAdi: string;
  raporTuru: string;
  medulaRaporTuru: string;
  medulaAltRaporTuru: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKurulDto {
  id: string;
  kurulKodu: string;
  referansTabloAdi: string;
  kurulAdi: string;
  raporTuru: string;
  medulaRaporTuru: string;
  medulaAltRaporTuru: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
}

export interface CreateKurulDto {
  kurulKodu: string;
  referansTabloAdi: string;
  kurulAdi: string;
  raporTuru: string;
  medulaRaporTuru: string;
  medulaAltRaporTuru: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKurulDto extends CreateKurulDto {
  id: string;
}

export interface KurulListFilter extends BaseListFilter {
  kurulKodu?: string;
  referansTabloAdi?: string;
  kurulAdi?: string;
  raporTuru?: string;
  medulaRaporTuru?: string;
}

export const newKurul: CreateKurulDto = {
  kurulKodu: '',
  referansTabloAdi: '',
  kurulAdi: '',
  raporTuru: '',
  medulaRaporTuru: '',
  medulaAltRaporTuru: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
