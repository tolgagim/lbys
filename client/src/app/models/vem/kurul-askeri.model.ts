// KurulAskeri Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KurulAskeriDto extends VemBaseDto {
  kurulAskeriKodu: string;
  referansTabloAdi: string;
  kurulAdi: string;
  medulaRaporTuru: string;
  medulaAltRaporTuru: string;
  alkolMaddeBagimliligi: string;
  bedenRuhIleriTetkikBulgusu: string;
  gecmisHastaligaDairKayit: string;
  gormeIsitmeKaybi: string;
  psikiyatrikRahatsizlik: string;
  uzuvkaybiOrtopediRahatsizlik: string;
  asalHastalik: string;
  asalHastalikTipi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKurulAskeriDto {
  id: string;
  kurulAskeriKodu: string;
  referansTabloAdi: string;
  kurulAdi: string;
  medulaRaporTuru: string;
  medulaAltRaporTuru: string;
  alkolMaddeBagimliligi: string;
  bedenRuhIleriTetkikBulgusu: string;
  gecmisHastaligaDairKayit: string;
}

export interface CreateKurulAskeriDto {
  kurulAskeriKodu: string;
  referansTabloAdi: string;
  kurulAdi: string;
  medulaRaporTuru: string;
  medulaAltRaporTuru: string;
  alkolMaddeBagimliligi: string;
  bedenRuhIleriTetkikBulgusu: string;
  gecmisHastaligaDairKayit: string;
  gormeIsitmeKaybi: string;
  psikiyatrikRahatsizlik: string;
  uzuvkaybiOrtopediRahatsizlik: string;
  asalHastalik: string;
  asalHastalikTipi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKurulAskeriDto extends CreateKurulAskeriDto {
  id: string;
}

export interface KurulAskeriListFilter extends BaseListFilter {
  kurulAskeriKodu?: string;
  referansTabloAdi?: string;
  kurulAdi?: string;
  medulaRaporTuru?: string;
  medulaAltRaporTuru?: string;
}

export const newKurulAskeri: CreateKurulAskeriDto = {
  kurulAskeriKodu: '',
  referansTabloAdi: '',
  kurulAdi: '',
  medulaRaporTuru: '',
  medulaAltRaporTuru: '',
  alkolMaddeBagimliligi: '',
  bedenRuhIleriTetkikBulgusu: '',
  gecmisHastaligaDairKayit: '',
  gormeIsitmeKaybi: '',
  psikiyatrikRahatsizlik: '',
  uzuvkaybiOrtopediRahatsizlik: '',
  asalHastalik: '',
  asalHastalikTipi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
