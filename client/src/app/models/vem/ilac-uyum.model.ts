// IlacUyum Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface IlacUyumDto extends VemBaseDto {
  ilacUyumKodu: string;
  referansTabloAdi: string;
  ilacUyumsuzlukTuru: string;
  birinciIlacBarkodu: string;
  birinciEtkenMaddeKodu: string;
  ikinciIlacBarkodu: string;
  ikinciEtkenMaddeKodu: string;
  besinKodu: string;
  yasBaslangic: string;
  yasBitis: string;
  cinsiyet: string;
  renkSeviyeKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListIlacUyumDto {
  id: string;
  ilacUyumKodu: string;
  referansTabloAdi: string;
  ilacUyumsuzlukTuru: string;
  birinciIlacBarkodu: string;
  birinciEtkenMaddeKodu: string;
  ikinciIlacBarkodu: string;
  ikinciEtkenMaddeKodu: string;
  besinKodu: string;
}

export interface CreateIlacUyumDto {
  ilacUyumKodu: string;
  referansTabloAdi: string;
  ilacUyumsuzlukTuru: string;
  birinciIlacBarkodu: string;
  birinciEtkenMaddeKodu: string;
  ikinciIlacBarkodu: string;
  ikinciEtkenMaddeKodu: string;
  besinKodu: string;
  yasBaslangic: string;
  yasBitis: string;
  cinsiyet: string;
  renkSeviyeKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateIlacUyumDto extends CreateIlacUyumDto {
  id: string;
}

export interface IlacUyumListFilter extends BaseListFilter {
  ilacUyumKodu?: string;
  referansTabloAdi?: string;
  ilacUyumsuzlukTuru?: string;
  birinciIlacBarkodu?: string;
  birinciEtkenMaddeKodu?: string;
}

export const newIlacUyum: CreateIlacUyumDto = {
  ilacUyumKodu: '',
  referansTabloAdi: '',
  ilacUyumsuzlukTuru: '',
  birinciIlacBarkodu: '',
  birinciEtkenMaddeKodu: '',
  ikinciIlacBarkodu: '',
  ikinciEtkenMaddeKodu: '',
  besinKodu: '',
  yasBaslangic: '',
  yasBitis: '',
  cinsiyet: '',
  renkSeviyeKodu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
