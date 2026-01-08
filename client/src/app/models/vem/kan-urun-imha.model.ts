// KanUrunImha Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KanUrunImhaDto extends VemBaseDto {
  kanUrunImhaKodu: string;
  referansTabloAdi: string;
  kanStokKodu: string;
  kanImhaNedeni: string;
  kanImhaZamani?: Date;
  kanImhaOnaylayanHekim: string;
  kanImhaOnaylayanTeknisyen: string;
  kanImhaEdenPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKanUrunImhaDto {
  id: string;
  kanUrunImhaKodu: string;
  referansTabloAdi: string;
  kanStokKodu: string;
  kanImhaNedeni: string;
  kanImhaZamani?: Date;
  kanImhaOnaylayanHekim: string;
  kanImhaOnaylayanTeknisyen: string;
  kanImhaEdenPersonelKodu: string;
}

export interface CreateKanUrunImhaDto {
  kanUrunImhaKodu: string;
  referansTabloAdi: string;
  kanStokKodu: string;
  kanImhaNedeni: string;
  kanImhaZamani?: Date;
  kanImhaOnaylayanHekim: string;
  kanImhaOnaylayanTeknisyen: string;
  kanImhaEdenPersonelKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKanUrunImhaDto extends CreateKanUrunImhaDto {
  id: string;
}

export interface KanUrunImhaListFilter extends BaseListFilter {
  kanUrunImhaKodu?: string;
  referansTabloAdi?: string;
  kanStokKodu?: string;
  kanImhaNedeni?: string;
  kanImhaOnaylayanHekim?: string;
}

export const newKanUrunImha: CreateKanUrunImhaDto = {
  kanUrunImhaKodu: '',
  referansTabloAdi: '',
  kanStokKodu: '',
  kanImhaNedeni: '',
  kanImhaZamani: undefined,
  kanImhaOnaylayanHekim: '',
  kanImhaOnaylayanTeknisyen: '',
  kanImhaEdenPersonelKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
