// KurulEtkenMadde Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KurulEtkenMaddeDto extends VemBaseDto {
  kurulEtkenMaddeKodu: string;
  referansTabloAdi: string;
  kurulRaporKodu: string;
  ilacEtkenMaddeKodu: string;
  dozSayisi: string;
  dozMiktari: string;
  dozBirim: string;
  ilacKullanimPeriyodu: string;
  ilacPeriyotBirimi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKurulEtkenMaddeDto {
  id: string;
  kurulEtkenMaddeKodu: string;
  referansTabloAdi: string;
  kurulRaporKodu: string;
  ilacEtkenMaddeKodu: string;
  dozSayisi: string;
  dozMiktari: string;
  dozBirim: string;
  ilacKullanimPeriyodu: string;
}

export interface CreateKurulEtkenMaddeDto {
  kurulEtkenMaddeKodu: string;
  referansTabloAdi: string;
  kurulRaporKodu: string;
  ilacEtkenMaddeKodu: string;
  dozSayisi: string;
  dozMiktari: string;
  dozBirim: string;
  ilacKullanimPeriyodu: string;
  ilacPeriyotBirimi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKurulEtkenMaddeDto extends CreateKurulEtkenMaddeDto {
  id: string;
}

export interface KurulEtkenMaddeListFilter extends BaseListFilter {
  kurulEtkenMaddeKodu?: string;
  referansTabloAdi?: string;
  kurulRaporKodu?: string;
  ilacEtkenMaddeKodu?: string;
  dozSayisi?: string;
}

export const newKurulEtkenMadde: CreateKurulEtkenMaddeDto = {
  kurulEtkenMaddeKodu: '',
  referansTabloAdi: '',
  kurulRaporKodu: '',
  ilacEtkenMaddeKodu: '',
  dozSayisi: '',
  dozMiktari: '',
  dozBirim: '',
  ilacKullanimPeriyodu: '',
  ilacPeriyotBirimi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
