// HastaGizlilik Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaGizlilikDto extends VemBaseDto {
  hastaGizlilikKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  gizlilikNedeni: string;
  gorunecekHastaAdi: string;
  gorunecekHastaSoyadi: string;
  gizlilikTuru: string;
  gizlilikBaslamaZamani?: Date;
  gizlilikBitisZamani: Date;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaGizlilikDto {
  id: string;
  hastaGizlilikKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  gizlilikNedeni: string;
  gorunecekHastaAdi: string;
  gorunecekHastaSoyadi: string;
  gizlilikTuru: string;
}

export interface CreateHastaGizlilikDto {
  hastaGizlilikKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  gizlilikNedeni: string;
  gorunecekHastaAdi: string;
  gorunecekHastaSoyadi: string;
  gizlilikTuru: string;
  gizlilikBaslamaZamani?: Date;
  gizlilikBitisZamani: Date;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaGizlilikDto extends CreateHastaGizlilikDto {
  id: string;
}

export interface HastaGizlilikListFilter extends BaseListFilter {
  hastaGizlilikKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  gizlilikNedeni?: string;
}

export const newHastaGizlilik: CreateHastaGizlilikDto = {
  hastaGizlilikKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  gizlilikNedeni: '',
  gorunecekHastaAdi: '',
  gorunecekHastaSoyadi: '',
  gizlilikTuru: '',
  gizlilikBaslamaZamani: undefined,
  gizlilikBitisZamani: undefined,
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
