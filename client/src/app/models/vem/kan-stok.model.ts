// KanStok Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KanStokDto extends VemBaseDto {
  kanStokKodu: string;
  referansTabloAdi: string;
  kanStokDurumu: string;
  kanStokGirisTarihi?: Date;
  defterNumarasi: string;
  kanGrubu: string;
  kanUrunKodu: string;
  kanBagisciKodu: string;
  kurumKodu: string;
  birimKodu: string;
  bagliKanStokKodu: string;
  isbtUniteNumarasi: string;
  isbtBilesenNumarasi: string;
  kanHacim: string;
  kanBagisZamani: Date;
  kanFiltrelemeZamani: Date;
  kanIsinlamaZamani: Date;
  kanYikamaZamani: Date;
  kanAyirmaZamani: Date;
  kanBolmeZamani: Date;
  buffycoatUzaklastirmaZamani: Date;
  kanHavuzlamaZamani: Date;
  sonKullanmaTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKanStokDto {
  id: string;
  kanStokKodu: string;
  referansTabloAdi: string;
  kanStokDurumu: string;
  kanStokGirisTarihi?: Date;
  defterNumarasi: string;
  kanGrubu: string;
  kanUrunKodu: string;
  kanBagisciKodu: string;
}

export interface CreateKanStokDto {
  kanStokKodu: string;
  referansTabloAdi: string;
  kanStokDurumu: string;
  kanStokGirisTarihi?: Date;
  defterNumarasi: string;
  kanGrubu: string;
  kanUrunKodu: string;
  kanBagisciKodu: string;
  kurumKodu: string;
  birimKodu: string;
  bagliKanStokKodu: string;
  isbtUniteNumarasi: string;
  isbtBilesenNumarasi: string;
  kanHacim: string;
  kanBagisZamani: Date;
  kanFiltrelemeZamani: Date;
  kanIsinlamaZamani: Date;
  kanYikamaZamani: Date;
  kanAyirmaZamani: Date;
  kanBolmeZamani: Date;
  buffycoatUzaklastirmaZamani: Date;
  kanHavuzlamaZamani: Date;
  sonKullanmaTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKanStokDto extends CreateKanStokDto {
  id: string;
}

export interface KanStokListFilter extends BaseListFilter {
  kanStokKodu?: string;
  referansTabloAdi?: string;
  kanStokDurumu?: string;
  defterNumarasi?: string;
  kanGrubu?: string;
}

export const newKanStok: CreateKanStokDto = {
  kanStokKodu: '',
  referansTabloAdi: '',
  kanStokDurumu: '',
  kanStokGirisTarihi: undefined,
  defterNumarasi: '',
  kanGrubu: '',
  kanUrunKodu: '',
  kanBagisciKodu: '',
  kurumKodu: '',
  birimKodu: '',
  bagliKanStokKodu: '',
  isbtUniteNumarasi: '',
  isbtBilesenNumarasi: '',
  kanHacim: '',
  kanBagisZamani: undefined,
  kanFiltrelemeZamani: undefined,
  kanIsinlamaZamani: undefined,
  kanYikamaZamani: undefined,
  kanAyirmaZamani: undefined,
  kanBolmeZamani: undefined,
  buffycoatUzaklastirmaZamani: undefined,
  kanHavuzlamaZamani: undefined,
  sonKullanmaTarihi: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
