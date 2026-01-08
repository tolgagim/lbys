// HastaOlum Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaOlumDto extends VemBaseDto {
  hastaOlumKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  olumZamani?: Date;
  olumYeri: string;
  anneOlumNedeni: string;
  aciklama: string;
  otopsiDurumu: string;
  olumBelgesiPersonelKodu: string;
  olumNedeniTaniKodu: string;
  olumNedeniTuru: string;
  olumSekli: string;
  exKarariniVerenHekimKodu: string;
  tutanakZamani: Date;
  teslimAlanTcKimlikNumarasi: string;
  teslimAlanAdiSoyadi: string;
  teslimAlanTelefonBilgisi: string;
  teslimAlanAdresi: string;
  teslimEdenPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaOlumDto {
  id: string;
  hastaOlumKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  olumZamani?: Date;
  olumYeri: string;
  anneOlumNedeni: string;
  aciklama: string;
}

export interface CreateHastaOlumDto {
  hastaOlumKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  olumZamani?: Date;
  olumYeri: string;
  anneOlumNedeni: string;
  aciklama: string;
  otopsiDurumu: string;
  olumBelgesiPersonelKodu: string;
  olumNedeniTaniKodu: string;
  olumNedeniTuru: string;
  olumSekli: string;
  exKarariniVerenHekimKodu: string;
  tutanakZamani: Date;
  teslimAlanTcKimlikNumarasi: string;
  teslimAlanAdiSoyadi: string;
  teslimAlanTelefonBilgisi: string;
  teslimAlanAdresi: string;
  teslimEdenPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaOlumDto extends CreateHastaOlumDto {
  id: string;
}

export interface HastaOlumListFilter extends BaseListFilter {
  hastaOlumKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  olumYeri?: string;
}

export const newHastaOlum: CreateHastaOlumDto = {
  hastaOlumKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  olumZamani: undefined,
  olumYeri: '',
  anneOlumNedeni: '',
  aciklama: '',
  otopsiDurumu: '',
  olumBelgesiPersonelKodu: '',
  olumNedeniTaniKodu: '',
  olumNedeniTuru: '',
  olumSekli: '',
  exKarariniVerenHekimKodu: '',
  tutanakZamani: undefined,
  teslimAlanTcKimlikNumarasi: '',
  teslimAlanAdiSoyadi: '',
  teslimAlanTelefonBilgisi: '',
  teslimAlanAdresi: '',
  teslimEdenPersonelKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
