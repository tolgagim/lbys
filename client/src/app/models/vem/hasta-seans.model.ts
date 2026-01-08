// HastaSeans Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaSeansDto extends VemBaseDto {
  hastaSeansKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  seansIslemTuru: string;
  cihazKodu: string;
  planlananSeansTarihi?: Date;
  seansBaslamaZamani: Date;
  seansBitisZamani: Date;
  antihipertansifIlacDurumu: string;
  oncekiRrtYontemi: string;
  hemodiyalizeGecmeNedenleri: string;
  damarErisimYolu: string;
  diyalizeGirmeSikligi: string;
  diyalizorAlani: string;
  diyalizorTipi: string;
  kanAkimHizi: string;
  agirlikOlcumZamani: string;
  kullanilanDiyalizTedavisi: string;
  peritonealGecirgenlikDurumu: string;
  peritonKacinciKateter: string;
  peritonKateterTipi: string;
  peritonKateterYontemi: string;
  peritonTunelYonu: string;
  sinekalset: string;
  tedavininSeyri: string;
  aktifVitaminDKullanimi: string;
  anemiTedavisiYontemi: string;
  fosforBaglayiciAjan: string;
  peritonKomplikasyon: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaSeansDto {
  id: string;
  hastaSeansKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  seansIslemTuru: string;
  cihazKodu: string;
  planlananSeansTarihi?: Date;
  seansBaslamaZamani: Date;
}

export interface CreateHastaSeansDto {
  hastaSeansKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  seansIslemTuru: string;
  cihazKodu: string;
  planlananSeansTarihi?: Date;
  seansBaslamaZamani: Date;
  seansBitisZamani: Date;
  antihipertansifIlacDurumu: string;
  oncekiRrtYontemi: string;
  hemodiyalizeGecmeNedenleri: string;
  damarErisimYolu: string;
  diyalizeGirmeSikligi: string;
  diyalizorAlani: string;
  diyalizorTipi: string;
  kanAkimHizi: string;
  agirlikOlcumZamani: string;
  kullanilanDiyalizTedavisi: string;
  peritonealGecirgenlikDurumu: string;
  peritonKacinciKateter: string;
  peritonKateterTipi: string;
  peritonKateterYontemi: string;
  peritonTunelYonu: string;
  sinekalset: string;
  tedavininSeyri: string;
  aktifVitaminDKullanimi: string;
  anemiTedavisiYontemi: string;
  fosforBaglayiciAjan: string;
  peritonKomplikasyon: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaSeansDto extends CreateHastaSeansDto {
  id: string;
}

export interface HastaSeansListFilter extends BaseListFilter {
  hastaSeansKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  seansIslemTuru?: string;
}

export const newHastaSeans: CreateHastaSeansDto = {
  hastaSeansKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  seansIslemTuru: '',
  cihazKodu: '',
  planlananSeansTarihi: undefined,
  seansBaslamaZamani: undefined,
  seansBitisZamani: undefined,
  antihipertansifIlacDurumu: '',
  oncekiRrtYontemi: '',
  hemodiyalizeGecmeNedenleri: '',
  damarErisimYolu: '',
  diyalizeGirmeSikligi: '',
  diyalizorAlani: '',
  diyalizorTipi: '',
  kanAkimHizi: '',
  agirlikOlcumZamani: '',
  kullanilanDiyalizTedavisi: '',
  peritonealGecirgenlikDurumu: '',
  peritonKacinciKateter: '',
  peritonKateterTipi: '',
  peritonKateterYontemi: '',
  peritonTunelYonu: '',
  sinekalset: '',
  tedavininSeyri: '',
  aktifVitaminDKullanimi: '',
  anemiTedavisiYontemi: '',
  fosforBaglayiciAjan: '',
  peritonKomplikasyon: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
