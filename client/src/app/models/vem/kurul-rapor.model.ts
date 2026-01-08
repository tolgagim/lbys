// KurulRapor Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KurulRaporDto extends VemBaseDto {
  kurulRaporKodu: string;
  referansTabloAdi: string;
  kurulKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  raporAdi: string;
  raporZamani?: Date;
  aciklama: string;
  raporKararNumarasi: string;
  raporSiraNumarasi: string;
  raporTakipNumarasi: string;
  kurulRaporNumarasi: string;
  raporBaslamaTarihi?: Date;
  raporBitisTarihi: Date;
  laboratuvarBulgu: string;
  kurulRaporMuayeneBulgusu: string;
  kurulTaniBilgisi: string;
  kurulRaporKarari: string;
  kararIcerikFormati: string;
  muracaatDurumu: string;
  engellilikOrani: string;
  ilacRaporDuzeltmeAciklamasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKurulRaporDto {
  id: string;
  kurulRaporKodu: string;
  referansTabloAdi: string;
  kurulKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  raporAdi: string;
  raporZamani?: Date;
  aciklama: string;
}

export interface CreateKurulRaporDto {
  kurulRaporKodu: string;
  referansTabloAdi: string;
  kurulKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  raporAdi: string;
  raporZamani?: Date;
  aciklama: string;
  raporKararNumarasi: string;
  raporSiraNumarasi: string;
  raporTakipNumarasi: string;
  kurulRaporNumarasi: string;
  raporBaslamaTarihi?: Date;
  raporBitisTarihi: Date;
  laboratuvarBulgu: string;
  kurulRaporMuayeneBulgusu: string;
  kurulTaniBilgisi: string;
  kurulRaporKarari: string;
  kararIcerikFormati: string;
  muracaatDurumu: string;
  engellilikOrani: string;
  ilacRaporDuzeltmeAciklamasi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKurulRaporDto extends CreateKurulRaporDto {
  id: string;
}

export interface KurulRaporListFilter extends BaseListFilter {
  kurulRaporKodu?: string;
  referansTabloAdi?: string;
  kurulKodu?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
}

export const newKurulRapor: CreateKurulRaporDto = {
  kurulRaporKodu: '',
  referansTabloAdi: '',
  kurulKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  raporAdi: '',
  raporZamani: undefined,
  aciklama: '',
  raporKararNumarasi: '',
  raporSiraNumarasi: '',
  raporTakipNumarasi: '',
  kurulRaporNumarasi: '',
  raporBaslamaTarihi: undefined,
  raporBitisTarihi: undefined,
  laboratuvarBulgu: '',
  kurulRaporMuayeneBulgusu: '',
  kurulTaniBilgisi: '',
  kurulRaporKarari: '',
  kararIcerikFormati: '',
  muracaatDurumu: '',
  engellilikOrani: '',
  ilacRaporDuzeltmeAciklamasi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
