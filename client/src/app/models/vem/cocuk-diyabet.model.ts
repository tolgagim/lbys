// CocukDiyabet Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface CocukDiyabetDto extends VemBaseDto {
  cocukDiyabetKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  ilkTaniTarihi?: Date;
  agirlik: string;
  boy: string;
  diyabetTipi: string;
  kizCocuklardaMenarsYasi: string;
  beyinOdemiDurumu: string;
  ketoasidozDurumu: string;
  diyabetSikayet: string;
  sikayetinSuresi: string;
  aksillerKillanmaDurumu: string;
  pubikKillanmaDurumu: string;
  memeEvre: string;
  testisVolumSag: string;
  testisVolumSol: string;
  eslikedenHastalik: string;
  eslikedenHastalikTaniTarihi: Date;
  diyabetIlacTedaviSekli: string;
  diyetTibbiBeslenmeTedavisi: string;
  diyabetliHastaAileOykusu: string;
  diyabetEgitimiVerilmeDurumu: string;
  tiroidMuayenesi: string;
  diyabetKomplikasyonlari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListCocukDiyabetDto {
  id: string;
  cocukDiyabetKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  ilkTaniTarihi?: Date;
  agirlik: string;
  boy: string;
  diyabetTipi: string;
  kizCocuklardaMenarsYasi: string;
}

export interface CreateCocukDiyabetDto {
  cocukDiyabetKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  ilkTaniTarihi?: Date;
  agirlik: string;
  boy: string;
  diyabetTipi: string;
  kizCocuklardaMenarsYasi: string;
  beyinOdemiDurumu: string;
  ketoasidozDurumu: string;
  diyabetSikayet: string;
  sikayetinSuresi: string;
  aksillerKillanmaDurumu: string;
  pubikKillanmaDurumu: string;
  memeEvre: string;
  testisVolumSag: string;
  testisVolumSol: string;
  eslikedenHastalik: string;
  eslikedenHastalikTaniTarihi: Date;
  diyabetIlacTedaviSekli: string;
  diyetTibbiBeslenmeTedavisi: string;
  diyabetliHastaAileOykusu: string;
  diyabetEgitimiVerilmeDurumu: string;
  tiroidMuayenesi: string;
  diyabetKomplikasyonlari: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateCocukDiyabetDto extends CreateCocukDiyabetDto {
  id: string;
}

export interface CocukDiyabetListFilter extends BaseListFilter {
  cocukDiyabetKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  agirlik?: string;
  boy?: string;
}

export const newCocukDiyabet: CreateCocukDiyabetDto = {
  cocukDiyabetKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  ilkTaniTarihi: undefined,
  agirlik: '',
  boy: '',
  diyabetTipi: '',
  kizCocuklardaMenarsYasi: '',
  beyinOdemiDurumu: '',
  ketoasidozDurumu: '',
  diyabetSikayet: '',
  sikayetinSuresi: '',
  aksillerKillanmaDurumu: '',
  pubikKillanmaDurumu: '',
  memeEvre: '',
  testisVolumSag: '',
  testisVolumSol: '',
  eslikedenHastalik: '',
  eslikedenHastalikTaniTarihi: undefined,
  diyabetIlacTedaviSekli: '',
  diyetTibbiBeslenmeTedavisi: '',
  diyabetliHastaAileOykusu: '',
  diyabetEgitimiVerilmeDurumu: '',
  tiroidMuayenesi: '',
  diyabetKomplikasyonlari: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
