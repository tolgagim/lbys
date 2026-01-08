// KurulEngelli Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KurulEngelliDto extends VemBaseDto {
  kurulEngelliKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kurulRaporKodu: string;
  calistirilamayacakIsniteligi: string;
  engelliSureklilikDurumu: string;
  agirEngelli: string;
  engelliGrubu: string;
  engelliRaporKullanimAmaci: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKurulEngelliDto {
  id: string;
  kurulEngelliKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kurulRaporKodu: string;
  calistirilamayacakIsniteligi: string;
  engelliSureklilikDurumu: string;
  agirEngelli: string;
}

export interface CreateKurulEngelliDto {
  kurulEngelliKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kurulRaporKodu: string;
  calistirilamayacakIsniteligi: string;
  engelliSureklilikDurumu: string;
  agirEngelli: string;
  engelliGrubu: string;
  engelliRaporKullanimAmaci: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKurulEngelliDto extends CreateKurulEngelliDto {
  id: string;
}

export interface KurulEngelliListFilter extends BaseListFilter {
  kurulEngelliKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  kurulRaporKodu?: string;
}

export const newKurulEngelli: CreateKurulEngelliDto = {
  kurulEngelliKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  kurulRaporKodu: '',
  calistirilamayacakIsniteligi: '',
  engelliSureklilikDurumu: '',
  agirEngelli: '',
  engelliGrubu: '',
  engelliRaporKullanimAmaci: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
