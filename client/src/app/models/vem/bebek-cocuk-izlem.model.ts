// BebekCocukIzlem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface BebekCocukIzlemDto extends VemBaseDto {
  bebekCocukIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciIzlem: string;
  agizdanSiviTedavisi: string;
  basCevresi: string;
  demirLojistigiVeDestegi: string;
  dogumAgirligi: string;
  dvitaminiLojistigiVeDestegi: string;
  gkdTaramaSonucu: string;
  hematokritDegeri: string;
  hemoglobinDegeri: string;
  topukKani: string;
  topukKaniAlinmaZamani: Date;
  izleminYapildigiYer: string;
  izlemiYapanPersonelKodu: string;
  bilgiAlinanKisiAdSoyadi: string;
  bilgiAlinanKisiTelefon: string;
  bebekteRiskFaktorleri: string;
  taramaSonucu: string;
  anneSutundenKesildigiAy: string;
  bebeginBeslenmeDurumu: string;
  ekGidayaBasladigiAy: string;
  sadeceAnneSutuAldigiSure: string;
  gelisimTablosuBilgileri: string;
  ntpTakipBilgisi: string;
  bcBeyinGelisimRiskleri: string;
  ebeveynDestekAktiviteleri: string;
  bcPsikolojikRiskEgitim: string;
  bcRiskYapilanMudahale: string;
  bcRiskliOlguTakibi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListBebekCocukIzlemDto {
  id: string;
  bebekCocukIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciIzlem: string;
  agizdanSiviTedavisi: string;
  basCevresi: string;
  demirLojistigiVeDestegi: string;
}

export interface CreateBebekCocukIzlemDto {
  bebekCocukIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciIzlem: string;
  agizdanSiviTedavisi: string;
  basCevresi: string;
  demirLojistigiVeDestegi: string;
  dogumAgirligi: string;
  dvitaminiLojistigiVeDestegi: string;
  gkdTaramaSonucu: string;
  hematokritDegeri: string;
  hemoglobinDegeri: string;
  topukKani: string;
  topukKaniAlinmaZamani: Date;
  izleminYapildigiYer: string;
  izlemiYapanPersonelKodu: string;
  bilgiAlinanKisiAdSoyadi: string;
  bilgiAlinanKisiTelefon: string;
  bebekteRiskFaktorleri: string;
  taramaSonucu: string;
  anneSutundenKesildigiAy: string;
  bebeginBeslenmeDurumu: string;
  ekGidayaBasladigiAy: string;
  sadeceAnneSutuAldigiSure: string;
  gelisimTablosuBilgileri: string;
  ntpTakipBilgisi: string;
  bcBeyinGelisimRiskleri: string;
  ebeveynDestekAktiviteleri: string;
  bcPsikolojikRiskEgitim: string;
  bcRiskYapilanMudahale: string;
  bcRiskliOlguTakibi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateBebekCocukIzlemDto extends CreateBebekCocukIzlemDto {
  id: string;
}

export interface BebekCocukIzlemListFilter extends BaseListFilter {
  bebekCocukIzlemKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  kacinciIzlem?: string;
}

export const newBebekCocukIzlem: CreateBebekCocukIzlemDto = {
  bebekCocukIzlemKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  kacinciIzlem: '',
  agizdanSiviTedavisi: '',
  basCevresi: '',
  demirLojistigiVeDestegi: '',
  dogumAgirligi: '',
  dvitaminiLojistigiVeDestegi: '',
  gkdTaramaSonucu: '',
  hematokritDegeri: '',
  hemoglobinDegeri: '',
  topukKani: '',
  topukKaniAlinmaZamani: undefined,
  izleminYapildigiYer: '',
  izlemiYapanPersonelKodu: '',
  bilgiAlinanKisiAdSoyadi: '',
  bilgiAlinanKisiTelefon: '',
  bebekteRiskFaktorleri: '',
  taramaSonucu: '',
  anneSutundenKesildigiAy: '',
  bebeginBeslenmeDurumu: '',
  ekGidayaBasladigiAy: '',
  sadeceAnneSutuAldigiSure: '',
  gelisimTablosuBilgileri: '',
  ntpTakipBilgisi: '',
  bcBeyinGelisimRiskleri: '',
  ebeveynDestekAktiviteleri: '',
  bcPsikolojikRiskEgitim: '',
  bcRiskYapilanMudahale: '',
  bcRiskliOlguTakibi: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
