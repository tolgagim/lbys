// DoktorMesaji Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DoktorMesajiDto extends VemBaseDto {
  doktorMesajiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaMesajlariTuru: string;
  mesajDetayi: string;
  mesajTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListDoktorMesajiDto {
  id: string;
  doktorMesajiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaMesajlariTuru: string;
  mesajDetayi: string;
  mesajTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
}

export interface CreateDoktorMesajiDto {
  doktorMesajiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaMesajlariTuru: string;
  mesajDetayi: string;
  mesajTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateDoktorMesajiDto extends CreateDoktorMesajiDto {
  id: string;
}

export interface DoktorMesajiListFilter extends BaseListFilter {
  doktorMesajiKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaMesajlariTuru?: string;
  mesajDetayi?: string;
}

export const newDoktorMesaji: CreateDoktorMesajiDto = {
  doktorMesajiKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaMesajlariTuru: '',
  mesajDetayi: '',
  mesajTarihi: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
