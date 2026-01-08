// KuduzIzlem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KuduzIzlemDto extends VemBaseDto {
  kuduzIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  profilaksiTamamlanmaDurumu: string;
  uygulananKuduzProfilaksisi: string;
  beyanTsmKurumKodu: string;
  immunglobulinMiktari: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKuduzIzlemDto {
  id: string;
  kuduzIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  profilaksiTamamlanmaDurumu: string;
  uygulananKuduzProfilaksisi: string;
  beyanTsmKurumKodu: string;
  immunglobulinMiktari: string;
}

export interface CreateKuduzIzlemDto {
  kuduzIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  profilaksiTamamlanmaDurumu: string;
  uygulananKuduzProfilaksisi: string;
  beyanTsmKurumKodu: string;
  immunglobulinMiktari: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKuduzIzlemDto extends CreateKuduzIzlemDto {
  id: string;
}

export interface KuduzIzlemListFilter extends BaseListFilter {
  kuduzIzlemKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  profilaksiTamamlanmaDurumu?: string;
}

export const newKuduzIzlem: CreateKuduzIzlemDto = {
  kuduzIzlemKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  profilaksiTamamlanmaDurumu: '',
  uygulananKuduzProfilaksisi: '',
  beyanTsmKurumKodu: '',
  immunglobulinMiktari: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
