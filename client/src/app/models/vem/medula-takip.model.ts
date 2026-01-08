// MedulaTakip Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface MedulaTakipDto extends VemBaseDto {
  medulaTakipKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  sgkTakipNumarasi: string;
  sgkIlktakipNumarasi: string;
  medulaTesisKodu: string;
  medulaBransKodu: string;
  provizyonTuru: string;
  provizyonTarihi?: Date;
  tcKimlikNumarasi: string;
  cinsiyet: string;
  medulaTutari: string;
  faturaTeslimNumarasi: string;
  faturaTeslimTarihi: Date;
  tedaviTuru: string;
  sigortaliTuru: string;
  devredilenKurum: string;
  sonucKodu: string;
  sonucMesaji: string;
  takipTipi: string;
  basvuruNumarasi: string;
  tedaviTipi: string;
  tedaviSekli: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListMedulaTakipDto {
  id: string;
  medulaTakipKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  sgkTakipNumarasi: string;
  sgkIlktakipNumarasi: string;
  medulaTesisKodu: string;
  medulaBransKodu: string;
}

export interface CreateMedulaTakipDto {
  medulaTakipKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  sgkTakipNumarasi: string;
  sgkIlktakipNumarasi: string;
  medulaTesisKodu: string;
  medulaBransKodu: string;
  provizyonTuru: string;
  provizyonTarihi?: Date;
  tcKimlikNumarasi: string;
  cinsiyet: string;
  medulaTutari: string;
  faturaTeslimNumarasi: string;
  faturaTeslimTarihi: Date;
  tedaviTuru: string;
  sigortaliTuru: string;
  devredilenKurum: string;
  sonucKodu: string;
  sonucMesaji: string;
  takipTipi: string;
  basvuruNumarasi: string;
  tedaviTipi: string;
  tedaviSekli: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateMedulaTakipDto extends CreateMedulaTakipDto {
  id: string;
}

export interface MedulaTakipListFilter extends BaseListFilter {
  medulaTakipKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  sgkTakipNumarasi?: string;
}

export const newMedulaTakip: CreateMedulaTakipDto = {
  medulaTakipKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  sgkTakipNumarasi: '',
  sgkIlktakipNumarasi: '',
  medulaTesisKodu: '',
  medulaBransKodu: '',
  provizyonTuru: '',
  provizyonTarihi: undefined,
  tcKimlikNumarasi: '',
  cinsiyet: '',
  medulaTutari: '',
  faturaTeslimNumarasi: '',
  faturaTeslimTarihi: undefined,
  tedaviTuru: '',
  sigortaliTuru: '',
  devredilenKurum: '',
  sonucKodu: '',
  sonucMesaji: '',
  takipTipi: '',
  basvuruNumarasi: '',
  tedaviTipi: '',
  tedaviSekli: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
