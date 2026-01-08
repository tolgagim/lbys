// HastaVitalFizikiBulgu Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaVitalFizikiBulguDto extends VemBaseDto {
  hastaVitalFizikiBulguKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  islemZamani?: Date;
  sistolikKanBasinciDegeri: string;
  diastolikKanBasinciDegeri: string;
  nabiz: string;
  solunum: string;
  ates: string;
  basCevresi: string;
  boy: string;
  agirlik: string;
  saturasyon: string;
  belCevresi: string;
  kalcaCevresi: string;
  kolCevresi: string;
  karinCevresi: string;
  hemsireKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaVitalFizikiBulguDto {
  id: string;
  hastaVitalFizikiBulguKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  islemZamani?: Date;
  sistolikKanBasinciDegeri: string;
  diastolikKanBasinciDegeri: string;
  nabiz: string;
}

export interface CreateHastaVitalFizikiBulguDto {
  hastaVitalFizikiBulguKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  islemZamani?: Date;
  sistolikKanBasinciDegeri: string;
  diastolikKanBasinciDegeri: string;
  nabiz: string;
  solunum: string;
  ates: string;
  basCevresi: string;
  boy: string;
  agirlik: string;
  saturasyon: string;
  belCevresi: string;
  kalcaCevresi: string;
  kolCevresi: string;
  karinCevresi: string;
  hemsireKodu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaVitalFizikiBulguDto extends CreateHastaVitalFizikiBulguDto {
  id: string;
}

export interface HastaVitalFizikiBulguListFilter extends BaseListFilter {
  hastaVitalFizikiBulguKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  sistolikKanBasinciDegeri?: string;
}

export const newHastaVitalFizikiBulgu: CreateHastaVitalFizikiBulguDto = {
  hastaVitalFizikiBulguKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  islemZamani: undefined,
  sistolikKanBasinciDegeri: '',
  diastolikKanBasinciDegeri: '',
  nabiz: '',
  solunum: '',
  ates: '',
  basCevresi: '',
  boy: '',
  agirlik: '',
  saturasyon: '',
  belCevresi: '',
  kalcaCevresi: '',
  kolCevresi: '',
  karinCevresi: '',
  hemsireKodu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
