// EvdeSaglikIzlem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface EvdeSaglikIzlemDto extends VemBaseDto {
  evdeSaglikIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  agri: string;
  aydinlatma: string;
  bakimVeDestekIhtiyaci: string;
  basiDegerlendirmesi: string;
  basvuruTuru: string;
  beslenme: string;
  eshEsasHastalikGrubu: string;
  evHijyeni: string;
  guvenlik: string;
  isinma: string;
  kisiselBakim: string;
  kisiselHijyen: string;
  konutTipi: string;
  kullanilanHelaTipi: string;
  yatagaBagimlilik: string;
  kullandigiYardimciAraclar: string;
  psikolojikDurumDegerlendirme: string;
  eshSonlandirilmasi: string;
  eshHastaNakli: string;
  eshAlinacakIl: string;
  birSonrakiHizmetIhtiyaci: string;
  verilenEgitimler: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListEvdeSaglikIzlemDto {
  id: string;
  evdeSaglikIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  agri: string;
  aydinlatma: string;
  bakimVeDestekIhtiyaci: string;
  basiDegerlendirmesi: string;
}

export interface CreateEvdeSaglikIzlemDto {
  evdeSaglikIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  agri: string;
  aydinlatma: string;
  bakimVeDestekIhtiyaci: string;
  basiDegerlendirmesi: string;
  basvuruTuru: string;
  beslenme: string;
  eshEsasHastalikGrubu: string;
  evHijyeni: string;
  guvenlik: string;
  isinma: string;
  kisiselBakim: string;
  kisiselHijyen: string;
  konutTipi: string;
  kullanilanHelaTipi: string;
  yatagaBagimlilik: string;
  kullandigiYardimciAraclar: string;
  psikolojikDurumDegerlendirme: string;
  eshSonlandirilmasi: string;
  eshHastaNakli: string;
  eshAlinacakIl: string;
  birSonrakiHizmetIhtiyaci: string;
  verilenEgitimler: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateEvdeSaglikIzlemDto extends CreateEvdeSaglikIzlemDto {
  id: string;
}

export interface EvdeSaglikIzlemListFilter extends BaseListFilter {
  evdeSaglikIzlemKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  agri?: string;
}

export const newEvdeSaglikIzlem: CreateEvdeSaglikIzlemDto = {
  evdeSaglikIzlemKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  agri: '',
  aydinlatma: '',
  bakimVeDestekIhtiyaci: '',
  basiDegerlendirmesi: '',
  basvuruTuru: '',
  beslenme: '',
  eshEsasHastalikGrubu: '',
  evHijyeni: '',
  guvenlik: '',
  isinma: '',
  kisiselBakim: '',
  kisiselHijyen: '',
  konutTipi: '',
  kullanilanHelaTipi: '',
  yatagaBagimlilik: '',
  kullandigiYardimciAraclar: '',
  psikolojikDurumDegerlendirme: '',
  eshSonlandirilmasi: '',
  eshHastaNakli: '',
  eshAlinacakIl: '',
  birSonrakiHizmetIhtiyaci: '',
  verilenEgitimler: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
