// Fatura Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface FaturaDto extends VemBaseDto {
  faturaKodu: string;
  hastaBasvuruKodu: string;
  hastaKodu?: string;
  faturaDonemi?: string;
  icmalKodu?: string;
  faturaTuru?: string;
  faturaAdi?: string;
  faturaZamani?: Date;
  faturaTutari?: number;
  faturaNumarasi?: string;
  medulaTeslimNumarasi?: string;
  faturaKesilenKurumKodu?: string;
  butceKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListFaturaDto {
  id: string;
  faturaKodu: string;
  hastaBasvuruKodu: string;
  hastaKodu?: string;
  faturaDonemi?: string;
  icmalKodu?: string;
  faturaTuru?: string;
  faturaAdi?: string;
  faturaZamani?: Date;
}

export interface CreateFaturaDto {
  faturaKodu: string;
  hastaBasvuruKodu: string;
  hastaKodu?: string;
  faturaDonemi?: string;
  icmalKodu?: string;
  faturaTuru?: string;
  faturaAdi?: string;
  faturaZamani?: Date;
  faturaTutari?: number;
  faturaNumarasi?: string;
  medulaTeslimNumarasi?: string;
  faturaKesilenKurumKodu?: string;
  butceKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateFaturaDto extends CreateFaturaDto {
  id: string;
}

export interface FaturaListFilter extends BaseListFilter {
  faturaKodu?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  faturaDonemi?: string;
  icmalKodu?: string;
}

export const newFatura: CreateFaturaDto = {
  faturaKodu: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  faturaDonemi: '',
  icmalKodu: '',
  faturaTuru: '',
  faturaAdi: '',
  faturaZamani: undefined,
  faturaTutari: 0,
  faturaNumarasi: '',
  medulaTeslimNumarasi: '',
  faturaKesilenKurumKodu: '',
  butceKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
