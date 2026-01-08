// BakteriSonuc Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface BakteriSonucDto extends VemBaseDto {
  bakteriSonucKodu: string;
  referansTabloAdi: string;
  tetkikSonucKodu: string;
  bakteriKodu: string;
  koloniSayisi: string;
  raporSonucSirasi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListBakteriSonucDto {
  id: string;
  bakteriSonucKodu: string;
  referansTabloAdi: string;
  tetkikSonucKodu: string;
  bakteriKodu: string;
  koloniSayisi: string;
  raporSonucSirasi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
}

export interface CreateBakteriSonucDto {
  bakteriSonucKodu: string;
  referansTabloAdi: string;
  tetkikSonucKodu: string;
  bakteriKodu: string;
  koloniSayisi: string;
  raporSonucSirasi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateBakteriSonucDto extends CreateBakteriSonucDto {
  id: string;
}

export interface BakteriSonucListFilter extends BaseListFilter {
  bakteriSonucKodu?: string;
  referansTabloAdi?: string;
  tetkikSonucKodu?: string;
  bakteriKodu?: string;
  koloniSayisi?: string;
}

export const newBakteriSonuc: CreateBakteriSonucDto = {
  bakteriSonucKodu: '',
  referansTabloAdi: '',
  tetkikSonucKodu: '',
  bakteriKodu: '',
  koloniSayisi: '',
  raporSonucSirasi: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
