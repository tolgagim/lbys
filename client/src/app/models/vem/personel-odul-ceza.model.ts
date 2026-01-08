// PersonelOdulCeza Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PersonelOdulCezaDto extends VemBaseDto {
  personelOdulCezaKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  odulCezaDurumu: string;
  odulCezaTuru: string;
  cezaBaslangicTarihi: Date;
  cezaBitisTarihi: Date;
  odulCezaVerenKurumKodu: string;
  odulCezaAciklama: string;
  tebligTarihi?: Date;
  tebligEvrakTarihi: Date;
  tebligEvrakNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPersonelOdulCezaDto {
  id: string;
  personelOdulCezaKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  odulCezaDurumu: string;
  odulCezaTuru: string;
  cezaBaslangicTarihi: Date;
  cezaBitisTarihi: Date;
  odulCezaVerenKurumKodu: string;
}

export interface CreatePersonelOdulCezaDto {
  personelOdulCezaKodu: string;
  referansTabloAdi: string;
  personelKodu: string;
  odulCezaDurumu: string;
  odulCezaTuru: string;
  cezaBaslangicTarihi: Date;
  cezaBitisTarihi: Date;
  odulCezaVerenKurumKodu: string;
  odulCezaAciklama: string;
  tebligTarihi?: Date;
  tebligEvrakTarihi: Date;
  tebligEvrakNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePersonelOdulCezaDto extends CreatePersonelOdulCezaDto {
  id: string;
}

export interface PersonelOdulCezaListFilter extends BaseListFilter {
  personelOdulCezaKodu?: string;
  referansTabloAdi?: string;
  personelKodu?: string;
  odulCezaDurumu?: string;
  odulCezaTuru?: string;
}

export const newPersonelOdulCeza: CreatePersonelOdulCezaDto = {
  personelOdulCezaKodu: '',
  referansTabloAdi: '',
  personelKodu: '',
  odulCezaDurumu: '',
  odulCezaTuru: '',
  cezaBaslangicTarihi: undefined,
  cezaBitisTarihi: undefined,
  odulCezaVerenKurumKodu: '',
  odulCezaAciklama: '',
  tebligTarihi: undefined,
  tebligEvrakTarihi: undefined,
  tebligEvrakNumarasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
