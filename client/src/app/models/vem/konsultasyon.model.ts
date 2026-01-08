// Konsultasyon Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KonsultasyonDto extends VemBaseDto {
  konsultasyonKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaHizmetKodu: string;
  konsultasyonBasvuruKodu: string;
  konsultasyonIstekNotu: string;
  konsultasyonCevapNotu: string;
  konsultasyonaCagrilmaZamani: Date;
  konsultasyonaGelisZamani: Date;
  konsultasyonYeri: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKonsultasyonDto {
  id: string;
  konsultasyonKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaHizmetKodu: string;
  konsultasyonBasvuruKodu: string;
  konsultasyonIstekNotu: string;
  konsultasyonCevapNotu: string;
}

export interface CreateKonsultasyonDto {
  konsultasyonKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  hastaHizmetKodu: string;
  konsultasyonBasvuruKodu: string;
  konsultasyonIstekNotu: string;
  konsultasyonCevapNotu: string;
  konsultasyonaCagrilmaZamani: Date;
  konsultasyonaGelisZamani: Date;
  konsultasyonYeri: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKonsultasyonDto extends CreateKonsultasyonDto {
  id: string;
}

export interface KonsultasyonListFilter extends BaseListFilter {
  konsultasyonKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  hastaHizmetKodu?: string;
}

export const newKonsultasyon: CreateKonsultasyonDto = {
  konsultasyonKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  hastaHizmetKodu: '',
  konsultasyonBasvuruKodu: '',
  konsultasyonIstekNotu: '',
  konsultasyonCevapNotu: '',
  konsultasyonaCagrilmaZamani: undefined,
  konsultasyonaGelisZamani: undefined,
  konsultasyonYeri: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
