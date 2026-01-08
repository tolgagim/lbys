// KanUrun Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KanUrunDto extends VemBaseDto {
  kanUrunKodu: string;
  referansTabloAdi: string;
  kanUrunAdi: string;
  hizmetKodu: string;
  kanMiatSuresi: string;
  kanMiatPeriyodu: string;
  kizilayBilesenTuru: string;
  kanFiltrelemeUygunluk: string;
  kanYikamaUygunlukDurumu: string;
  kanIsinlamaUygunlukDurumu: string;
  kanHavuzlamaUygunluk: string;
  kanAyirmaUygunluk: string;
  kanBolmeUygunluk: string;
  buffycoatUzaklastirmayaUygun: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKanUrunDto {
  id: string;
  kanUrunKodu: string;
  referansTabloAdi: string;
  kanUrunAdi: string;
  hizmetKodu: string;
  kanMiatSuresi: string;
  kanMiatPeriyodu: string;
  kizilayBilesenTuru: string;
  kanFiltrelemeUygunluk: string;
}

export interface CreateKanUrunDto {
  kanUrunKodu: string;
  referansTabloAdi: string;
  kanUrunAdi: string;
  hizmetKodu: string;
  kanMiatSuresi: string;
  kanMiatPeriyodu: string;
  kizilayBilesenTuru: string;
  kanFiltrelemeUygunluk: string;
  kanYikamaUygunlukDurumu: string;
  kanIsinlamaUygunlukDurumu: string;
  kanHavuzlamaUygunluk: string;
  kanAyirmaUygunluk: string;
  kanBolmeUygunluk: string;
  buffycoatUzaklastirmayaUygun: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKanUrunDto extends CreateKanUrunDto {
  id: string;
}

export interface KanUrunListFilter extends BaseListFilter {
  kanUrunKodu?: string;
  referansTabloAdi?: string;
  kanUrunAdi?: string;
  hizmetKodu?: string;
  kanMiatSuresi?: string;
}

export const newKanUrun: CreateKanUrunDto = {
  kanUrunKodu: '',
  referansTabloAdi: '',
  kanUrunAdi: '',
  hizmetKodu: '',
  kanMiatSuresi: '',
  kanMiatPeriyodu: '',
  kizilayBilesenTuru: '',
  kanFiltrelemeUygunluk: '',
  kanYikamaUygunlukDurumu: '',
  kanIsinlamaUygunlukDurumu: '',
  kanHavuzlamaUygunluk: '',
  kanAyirmaUygunluk: '',
  kanBolmeUygunluk: '',
  buffycoatUzaklastirmayaUygun: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
