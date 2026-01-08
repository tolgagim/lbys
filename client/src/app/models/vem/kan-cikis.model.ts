// KanCikis Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KanCikisDto extends VemBaseDto {
  kanCikisKodu: string;
  referansTabloAdi: string;
  kanTalepDetayKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kanStokKodu: string;
  kaniTeslimAlanKisi: string;
  kanCikisZamani?: Date;
  kurumKodu: string;
  kanCikisPersonelKodu: string;
  rezerveZamani: Date;
  rezerveEdenKullaniciKodu: string;
  crossMatchKullaniciKodu: string;
  crossMatchCalismaZamani: Date;
  crossMatchCalismaYontemi: string;
  crossMatchSonucu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKanCikisDto {
  id: string;
  kanCikisKodu: string;
  referansTabloAdi: string;
  kanTalepDetayKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kanStokKodu: string;
  kaniTeslimAlanKisi: string;
  kanCikisZamani?: Date;
}

export interface CreateKanCikisDto {
  kanCikisKodu: string;
  referansTabloAdi: string;
  kanTalepDetayKodu: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kanStokKodu: string;
  kaniTeslimAlanKisi: string;
  kanCikisZamani?: Date;
  kurumKodu: string;
  kanCikisPersonelKodu: string;
  rezerveZamani: Date;
  rezerveEdenKullaniciKodu: string;
  crossMatchKullaniciKodu: string;
  crossMatchCalismaZamani: Date;
  crossMatchCalismaYontemi: string;
  crossMatchSonucu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKanCikisDto extends CreateKanCikisDto {
  id: string;
}

export interface KanCikisListFilter extends BaseListFilter {
  kanCikisKodu?: string;
  referansTabloAdi?: string;
  kanTalepDetayKodu?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
}

export const newKanCikis: CreateKanCikisDto = {
  kanCikisKodu: '',
  referansTabloAdi: '',
  kanTalepDetayKodu: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  kanStokKodu: '',
  kaniTeslimAlanKisi: '',
  kanCikisZamani: undefined,
  kurumKodu: '',
  kanCikisPersonelKodu: '',
  rezerveZamani: undefined,
  rezerveEdenKullaniciKodu: '',
  crossMatchKullaniciKodu: '',
  crossMatchCalismaZamani: undefined,
  crossMatchCalismaYontemi: '',
  crossMatchSonucu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
