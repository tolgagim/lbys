// HastaBasvuru Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaBasvuruDto extends VemBaseDto {
  hastaBasvuruKodu: string;
  hastaKodu: string;
  basvuruTarihi: Date;
  basvuruTuru?: string;
  basvuruSekli?: string;
  birimKodu?: string;
  doktorKodu?: string;
  sikayet?: string;
  taniKodu?: string;
  tedaviTuru?: string;
  sevkEdenKurum?: string;
  provizyonTipi?: string;
  takipNo?: string;
  cikisTarihi?: Date;
  cikisSekli?: string;
  sonucKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaBasvuruDto {
  id: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  basvuruTarihi: Date;
  basvuruTuru?: string;
  basvuruSekli?: string;
  birimKodu?: string;
  doktorKodu?: string;
  sikayet?: string;
}

export interface CreateHastaBasvuruDto {
  hastaBasvuruKodu: string;
  hastaKodu: string;
  basvuruTarihi: Date;
  basvuruTuru?: string;
  basvuruSekli?: string;
  birimKodu?: string;
  doktorKodu?: string;
  sikayet?: string;
  taniKodu?: string;
  tedaviTuru?: string;
  sevkEdenKurum?: string;
  provizyonTipi?: string;
  takipNo?: string;
  cikisTarihi?: Date;
  cikisSekli?: string;
  sonucKodu?: string;
  aktif: boolean;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaBasvuruDto extends CreateHastaBasvuruDto {
  id: string;
}

export interface HastaBasvuruListFilter extends BaseListFilter {
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  basvuruTuru?: string;
  basvuruSekli?: string;
  birimKodu?: string;
}

export const newHastaBasvuru: CreateHastaBasvuruDto = {
  hastaBasvuruKodu: '',
  hastaKodu: '',
  basvuruTarihi: undefined,
  basvuruTuru: '',
  basvuruSekli: '',
  birimKodu: '',
  doktorKodu: '',
  sikayet: '',
  taniKodu: '',
  tedaviTuru: '',
  sevkEdenKurum: '',
  provizyonTipi: '',
  takipNo: '',
  cikisTarihi: undefined,
  cikisSekli: '',
  sonucKodu: '',
  aktif: false,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
