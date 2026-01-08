// Ameliyat Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface AmeliyatDto extends VemBaseDto {
  ameliyatKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  ameliyatAdi: string;
  ameliyatTuru: string;
  ameliyatBaslamaZamani?: Date;
  ameliyatBitisZamani?: Date;
  masaCihazKodu?: string;
  birimKodu?: string;
  defterNumarasi?: string;
  ameliyatDurumu?: string;
  anesteziTuru?: string;
  anesteziNotu?: string;
  anesteziBaslamaZamani?: Date;
  anesteziBitisZamani?: Date;
  ameliyatTipi?: string;
  skopiSuresi?: string;
  profilaksiPeriyodu?: string;
  profilaksiKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListAmeliyatDto {
  id: string;
  ameliyatKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  ameliyatAdi: string;
  ameliyatTuru: string;
  ameliyatBaslamaZamani?: Date;
  ameliyatBitisZamani?: Date;
  masaCihazKodu?: string;
}

export interface CreateAmeliyatDto {
  ameliyatKodu: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  ameliyatAdi: string;
  ameliyatTuru: string;
  ameliyatBaslamaZamani?: Date;
  ameliyatBitisZamani?: Date;
  masaCihazKodu?: string;
  birimKodu?: string;
  defterNumarasi?: string;
  ameliyatDurumu?: string;
  anesteziTuru?: string;
  anesteziNotu?: string;
  anesteziBaslamaZamani?: Date;
  anesteziBitisZamani?: Date;
  ameliyatTipi?: string;
  skopiSuresi?: string;
  profilaksiPeriyodu?: string;
  profilaksiKodu?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateAmeliyatDto extends CreateAmeliyatDto {
  id: string;
}

export interface AmeliyatListFilter extends BaseListFilter {
  ameliyatKodu?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  ameliyatAdi?: string;
  ameliyatTuru?: string;
}

export const newAmeliyat: CreateAmeliyatDto = {
  ameliyatKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  ameliyatAdi: '',
  ameliyatTuru: '',
  ameliyatBaslamaZamani: undefined,
  ameliyatBitisZamani: undefined,
  masaCihazKodu: '',
  birimKodu: '',
  defterNumarasi: '',
  ameliyatDurumu: '',
  anesteziTuru: '',
  anesteziNotu: '',
  anesteziBaslamaZamani: undefined,
  anesteziBitisZamani: undefined,
  ameliyatTipi: '',
  skopiSuresi: '',
  profilaksiPeriyodu: '',
  profilaksiKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
