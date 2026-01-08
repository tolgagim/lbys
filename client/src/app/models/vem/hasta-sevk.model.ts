// HastaSevk Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaSevkDto extends VemBaseDto {
  hastaSevkKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  sevkTakipNumarasi: string;
  sevkNedeni: string;
  sevkEdilenBransKodu: string;
  sevkEdilenKurumKodu: string;
  sevkZamani?: Date;
  sevkTanisi: string;
  sevkSekli: string;
  sevkVasitasiKodu: string;
  sevkTedaviTipi: string;
  sevkAciklama: string;
  sevkEden1PersonelKodu: string;
  sevkEden2PersonelKodu: string;
  sevkEden3PersonelKodu: string;
  refakatciDurumu: string;
  medulaESevkNumarasi: string;
  ambulansProtokolNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaSevkDto {
  id: string;
  hastaSevkKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  sevkTakipNumarasi: string;
  sevkNedeni: string;
  sevkEdilenBransKodu: string;
  sevkEdilenKurumKodu: string;
}

export interface CreateHastaSevkDto {
  hastaSevkKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  sevkTakipNumarasi: string;
  sevkNedeni: string;
  sevkEdilenBransKodu: string;
  sevkEdilenKurumKodu: string;
  sevkZamani?: Date;
  sevkTanisi: string;
  sevkSekli: string;
  sevkVasitasiKodu: string;
  sevkTedaviTipi: string;
  sevkAciklama: string;
  sevkEden1PersonelKodu: string;
  sevkEden2PersonelKodu: string;
  sevkEden3PersonelKodu: string;
  refakatciDurumu: string;
  medulaESevkNumarasi: string;
  ambulansProtokolNumarasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaSevkDto extends CreateHastaSevkDto {
  id: string;
}

export interface HastaSevkListFilter extends BaseListFilter {
  hastaSevkKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  sevkTakipNumarasi?: string;
}

export const newHastaSevk: CreateHastaSevkDto = {
  hastaSevkKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  sevkTakipNumarasi: '',
  sevkNedeni: '',
  sevkEdilenBransKodu: '',
  sevkEdilenKurumKodu: '',
  sevkZamani: undefined,
  sevkTanisi: '',
  sevkSekli: '',
  sevkVasitasiKodu: '',
  sevkTedaviTipi: '',
  sevkAciklama: '',
  sevkEden1PersonelKodu: '',
  sevkEden2PersonelKodu: '',
  sevkEden3PersonelKodu: '',
  refakatciDurumu: '',
  medulaESevkNumarasi: '',
  ambulansProtokolNumarasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
