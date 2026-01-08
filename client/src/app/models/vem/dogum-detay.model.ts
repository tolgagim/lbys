// DogumDetay Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface DogumDetayDto extends VemBaseDto {
  dogumDetayKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  dogumKodu: string;
  dogumZamani?: Date;
  cinsiyet: string;
  dogumYontemi: string;
  agirlik: string;
  boy: string;
  basCevresi: string;
  apgar1: string;
  apgar5: string;
  apgarNotu: string;
  komplikasyonTanisi: string;
  dogumSirasi: string;
  gogusCevresi: string;
  prognozBilgisi: string;
  surmatureBilgisi: string;
  kVitaminiUygulanmaDurumu: string;
  bebeginHepatitAsiDurumu: string;
  yenidoganIsitmeTaramaDurumu: string;
  ilkBeslenmeZamani: Date;
  topukKani: string;
  topukKaniAlinmaZamani: Date;
  bebekAdi: string;
  babaTcKimlikNumarasi: string;
  bebeginYasamDurumu: string;
  sezaryenEndikasyonlar: string;
  robsonGrubu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListDogumDetayDto {
  id: string;
  dogumDetayKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  dogumKodu: string;
  dogumZamani?: Date;
  cinsiyet: string;
  dogumYontemi: string;
}

export interface CreateDogumDetayDto {
  dogumDetayKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  dogumKodu: string;
  dogumZamani?: Date;
  cinsiyet: string;
  dogumYontemi: string;
  agirlik: string;
  boy: string;
  basCevresi: string;
  apgar1: string;
  apgar5: string;
  apgarNotu: string;
  komplikasyonTanisi: string;
  dogumSirasi: string;
  gogusCevresi: string;
  prognozBilgisi: string;
  surmatureBilgisi: string;
  kVitaminiUygulanmaDurumu: string;
  bebeginHepatitAsiDurumu: string;
  yenidoganIsitmeTaramaDurumu: string;
  ilkBeslenmeZamani: Date;
  topukKani: string;
  topukKaniAlinmaZamani: Date;
  bebekAdi: string;
  babaTcKimlikNumarasi: string;
  bebeginYasamDurumu: string;
  sezaryenEndikasyonlar: string;
  robsonGrubu: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateDogumDetayDto extends CreateDogumDetayDto {
  id: string;
}

export interface DogumDetayListFilter extends BaseListFilter {
  dogumDetayKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  dogumKodu?: string;
}

export const newDogumDetay: CreateDogumDetayDto = {
  dogumDetayKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  dogumKodu: '',
  dogumZamani: undefined,
  cinsiyet: '',
  dogumYontemi: '',
  agirlik: '',
  boy: '',
  basCevresi: '',
  apgar1: '',
  apgar5: '',
  apgarNotu: '',
  komplikasyonTanisi: '',
  dogumSirasi: '',
  gogusCevresi: '',
  prognozBilgisi: '',
  surmatureBilgisi: '',
  kVitaminiUygulanmaDurumu: '',
  bebeginHepatitAsiDurumu: '',
  yenidoganIsitmeTaramaDurumu: '',
  ilkBeslenmeZamani: undefined,
  topukKani: '',
  topukKaniAlinmaZamani: undefined,
  bebekAdi: '',
  babaTcKimlikNumarasi: '',
  bebeginYasamDurumu: '',
  sezaryenEndikasyonlar: '',
  robsonGrubu: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
