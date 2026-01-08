// KanTalepDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KanTalepDetayDto extends VemBaseDto {
  kanTalepDetayKodu: string;
  referansTabloAdi: string;
  kanTalepKodu: string;
  kanUrunKodu: string;
  istenenKanGrubu: string;
  retTarihi: Date;
  retEdenKullaniciKodu: string;
  kanTalepRetNedeni: string;
  kanTalepMiktari: string;
  kanHacim: string;
  aciklama: string;
  buffycoatUzaklastirmaDurumu: string;
  kanFiltrelemeDurumu: string;
  kanIsinlamaDurumu: string;
  kanYikamaDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKanTalepDetayDto {
  id: string;
  kanTalepDetayKodu: string;
  referansTabloAdi: string;
  kanTalepKodu: string;
  kanUrunKodu: string;
  istenenKanGrubu: string;
  retTarihi: Date;
  retEdenKullaniciKodu: string;
  kanTalepRetNedeni: string;
}

export interface CreateKanTalepDetayDto {
  kanTalepDetayKodu: string;
  referansTabloAdi: string;
  kanTalepKodu: string;
  kanUrunKodu: string;
  istenenKanGrubu: string;
  retTarihi: Date;
  retEdenKullaniciKodu: string;
  kanTalepRetNedeni: string;
  kanTalepMiktari: string;
  kanHacim: string;
  aciklama: string;
  buffycoatUzaklastirmaDurumu: string;
  kanFiltrelemeDurumu: string;
  kanIsinlamaDurumu: string;
  kanYikamaDurumu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKanTalepDetayDto extends CreateKanTalepDetayDto {
  id: string;
}

export interface KanTalepDetayListFilter extends BaseListFilter {
  kanTalepDetayKodu?: string;
  referansTabloAdi?: string;
  kanTalepKodu?: string;
  kanUrunKodu?: string;
  istenenKanGrubu?: string;
}

export const newKanTalepDetay: CreateKanTalepDetayDto = {
  kanTalepDetayKodu: '',
  referansTabloAdi: '',
  kanTalepKodu: '',
  kanUrunKodu: '',
  istenenKanGrubu: '',
  retTarihi: undefined,
  retEdenKullaniciKodu: '',
  kanTalepRetNedeni: '',
  kanTalepMiktari: '',
  kanHacim: '',
  aciklama: '',
  buffycoatUzaklastirmaDurumu: '',
  kanFiltrelemeDurumu: '',
  kanIsinlamaDurumu: '',
  kanYikamaDurumu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
