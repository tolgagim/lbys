// RadyolojiSonuc Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface RadyolojiSonucDto extends VemBaseDto {
  radyolojiSonucKodu: string;
  referansTabloAdi: string;
  radyolojiKodu: string;
  tetkikSonucuMetin: string;
  radyolojiTetkikSonucu: string;
  radyolojiRaporFormati: string;
  raporTipi: string;
  raporYazanPersonelKodu: string;
  onaylayanPersonelKodu1: string;
  onaylayanPersonelKodu2: string;
  onaylayanPersonelKodu3: string;
  raporUzmanOnayZamani: Date;
  raporKayitZamani?: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListRadyolojiSonucDto {
  id: string;
  radyolojiSonucKodu: string;
  referansTabloAdi: string;
  radyolojiKodu: string;
  tetkikSonucuMetin: string;
  radyolojiTetkikSonucu: string;
  radyolojiRaporFormati: string;
  raporTipi: string;
  raporYazanPersonelKodu: string;
}

export interface CreateRadyolojiSonucDto {
  radyolojiSonucKodu: string;
  referansTabloAdi: string;
  radyolojiKodu: string;
  tetkikSonucuMetin: string;
  radyolojiTetkikSonucu: string;
  radyolojiRaporFormati: string;
  raporTipi: string;
  raporYazanPersonelKodu: string;
  onaylayanPersonelKodu1: string;
  onaylayanPersonelKodu2: string;
  onaylayanPersonelKodu3: string;
  raporUzmanOnayZamani: Date;
  raporKayitZamani?: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateRadyolojiSonucDto extends CreateRadyolojiSonucDto {
  id: string;
}

export interface RadyolojiSonucListFilter extends BaseListFilter {
  radyolojiSonucKodu?: string;
  referansTabloAdi?: string;
  radyolojiKodu?: string;
  tetkikSonucuMetin?: string;
  radyolojiTetkikSonucu?: string;
}

export const newRadyolojiSonuc: CreateRadyolojiSonucDto = {
  radyolojiSonucKodu: '',
  referansTabloAdi: '',
  radyolojiKodu: '',
  tetkikSonucuMetin: '',
  radyolojiTetkikSonucu: '',
  radyolojiRaporFormati: '',
  raporTipi: '',
  raporYazanPersonelKodu: '',
  onaylayanPersonelKodu1: '',
  onaylayanPersonelKodu2: '',
  onaylayanPersonelKodu3: '',
  raporUzmanOnayZamani: undefined,
  raporKayitZamani: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
