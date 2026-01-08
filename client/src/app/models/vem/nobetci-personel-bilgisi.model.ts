// NobetciPersonelBilgisi Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface NobetciPersonelBilgisiDto extends VemBaseDto {
  nobetciPersonelBilgisiKodu: string;
  referansTabloAdi: string;
  skrsKurumKodu: string;
  personelTcKimlikNumarasi: string;
  klinikKodu: string;
  gorevTuru: string;
  personelGorevKodu: string;
  nobetBaslangicTarihi: Date;
  nobetBitisTarihi: Date;
  telefonNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListNobetciPersonelBilgisiDto {
  id: string;
  nobetciPersonelBilgisiKodu: string;
  referansTabloAdi: string;
  skrsKurumKodu: string;
  personelTcKimlikNumarasi: string;
  klinikKodu: string;
  gorevTuru: string;
  personelGorevKodu: string;
  nobetBaslangicTarihi: Date;
}

export interface CreateNobetciPersonelBilgisiDto {
  nobetciPersonelBilgisiKodu: string;
  referansTabloAdi: string;
  skrsKurumKodu: string;
  personelTcKimlikNumarasi: string;
  klinikKodu: string;
  gorevTuru: string;
  personelGorevKodu: string;
  nobetBaslangicTarihi: Date;
  nobetBitisTarihi: Date;
  telefonNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateNobetciPersonelBilgisiDto extends CreateNobetciPersonelBilgisiDto {
  id: string;
}

export interface NobetciPersonelBilgisiListFilter extends BaseListFilter {
  nobetciPersonelBilgisiKodu?: string;
  referansTabloAdi?: string;
  skrsKurumKodu?: string;
  personelTcKimlikNumarasi?: string;
  klinikKodu?: string;
}

export const newNobetciPersonelBilgisi: CreateNobetciPersonelBilgisiDto = {
  nobetciPersonelBilgisiKodu: '',
  referansTabloAdi: '',
  skrsKurumKodu: '',
  personelTcKimlikNumarasi: '',
  klinikKodu: '',
  gorevTuru: '',
  personelGorevKodu: '',
  nobetBaslangicTarihi: undefined,
  nobetBitisTarihi: undefined,
  telefonNumarasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
