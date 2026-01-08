// KlinikSeyir Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KlinikSeyirDto extends VemBaseDto {
  klinikSeyirKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  seyirTipi: string;
  seyirZamani?: Date;
  seyirBilgisi: string;
  septikSok: string;
  sepsisDurumu: string;
  hekimKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKlinikSeyirDto {
  id: string;
  klinikSeyirKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  seyirTipi: string;
  seyirZamani?: Date;
  seyirBilgisi: string;
  septikSok: string;
}

export interface CreateKlinikSeyirDto {
  klinikSeyirKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  seyirTipi: string;
  seyirZamani?: Date;
  seyirBilgisi: string;
  septikSok: string;
  sepsisDurumu: string;
  hekimKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKlinikSeyirDto extends CreateKlinikSeyirDto {
  id: string;
}

export interface KlinikSeyirListFilter extends BaseListFilter {
  klinikSeyirKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  seyirTipi?: string;
}

export const newKlinikSeyir: CreateKlinikSeyirDto = {
  klinikSeyirKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  seyirTipi: '',
  seyirZamani: undefined,
  seyirBilgisi: '',
  septikSok: '',
  sepsisDurumu: '',
  hekimKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
