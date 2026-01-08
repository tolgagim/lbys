// LohusaIzlem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface LohusaIzlemDto extends VemBaseDto {
  lohusaIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciLohusaIzlem: string;
  izleminYapildigiYer: string;
  demirLojistigiVeDestegi: string;
  dvitaminiLojistigiVeDestegi: string;
  gebelikSonlanmaTarihi?: Date;
  postpartumDepresyon: string;
  uterusInvolusyon: string;
  bilgiAlinanKisiAdSoyadi: string;
  bilgiAlinanKisiTelefon: string;
  konjenitalAnomaliVarligi: string;
  hemoglobinDegeri: string;
  komplikasyonTanisi: string;
  seyirTehlikeIsareti: string;
  kadinSagligiIslemleri: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListLohusaIzlemDto {
  id: string;
  lohusaIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciLohusaIzlem: string;
  izleminYapildigiYer: string;
  demirLojistigiVeDestegi: string;
  dvitaminiLojistigiVeDestegi: string;
}

export interface CreateLohusaIzlemDto {
  lohusaIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciLohusaIzlem: string;
  izleminYapildigiYer: string;
  demirLojistigiVeDestegi: string;
  dvitaminiLojistigiVeDestegi: string;
  gebelikSonlanmaTarihi?: Date;
  postpartumDepresyon: string;
  uterusInvolusyon: string;
  bilgiAlinanKisiAdSoyadi: string;
  bilgiAlinanKisiTelefon: string;
  konjenitalAnomaliVarligi: string;
  hemoglobinDegeri: string;
  komplikasyonTanisi: string;
  seyirTehlikeIsareti: string;
  kadinSagligiIslemleri: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateLohusaIzlemDto extends CreateLohusaIzlemDto {
  id: string;
}

export interface LohusaIzlemListFilter extends BaseListFilter {
  lohusaIzlemKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  kacinciLohusaIzlem?: string;
}

export const newLohusaIzlem: CreateLohusaIzlemDto = {
  lohusaIzlemKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  kacinciLohusaIzlem: '',
  izleminYapildigiYer: '',
  demirLojistigiVeDestegi: '',
  dvitaminiLojistigiVeDestegi: '',
  gebelikSonlanmaTarihi: undefined,
  postpartumDepresyon: '',
  uterusInvolusyon: '',
  bilgiAlinanKisiAdSoyadi: '',
  bilgiAlinanKisiTelefon: '',
  konjenitalAnomaliVarligi: '',
  hemoglobinDegeri: '',
  komplikasyonTanisi: '',
  seyirTehlikeIsareti: '',
  kadinSagligiIslemleri: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
