// GebeIzlem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface GebeIzlemDto extends VemBaseDto {
  gebeIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciGebeIzlem: string;
  sonAdetTarihi?: Date;
  oncekiDogumDurumu: string;
  gebeIzlemIslemTuru: string;
  gestasyonelDiyabetTaramasi: string;
  idrardaProtein: string;
  hemoglobinDegeri: string;
  demirLojistigiVeDestegi: string;
  dvitaminiLojistigiVeDestegi: string;
  konjenitalAnomaliVarligi: string;
  fetusKalpSesi: string;
  diastolikKanBasinciDegeri: string;
  sistolikKanBasinciDegeri: string;
  gebelikteRiskFaktorleri: string;
  bcBeyinGelisimRiskleri: string;
  psikolojikGelisimRiskEgitim: string;
  riskFaktorlerineMudahale: string;
  riskAltindakiOlguTakibi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListGebeIzlemDto {
  id: string;
  gebeIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciGebeIzlem: string;
  sonAdetTarihi?: Date;
  oncekiDogumDurumu: string;
  gebeIzlemIslemTuru: string;
}

export interface CreateGebeIzlemDto {
  gebeIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kacinciGebeIzlem: string;
  sonAdetTarihi?: Date;
  oncekiDogumDurumu: string;
  gebeIzlemIslemTuru: string;
  gestasyonelDiyabetTaramasi: string;
  idrardaProtein: string;
  hemoglobinDegeri: string;
  demirLojistigiVeDestegi: string;
  dvitaminiLojistigiVeDestegi: string;
  konjenitalAnomaliVarligi: string;
  fetusKalpSesi: string;
  diastolikKanBasinciDegeri: string;
  sistolikKanBasinciDegeri: string;
  gebelikteRiskFaktorleri: string;
  bcBeyinGelisimRiskleri: string;
  psikolojikGelisimRiskEgitim: string;
  riskFaktorlerineMudahale: string;
  riskAltindakiOlguTakibi: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateGebeIzlemDto extends CreateGebeIzlemDto {
  id: string;
}

export interface GebeIzlemListFilter extends BaseListFilter {
  gebeIzlemKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  kacinciGebeIzlem?: string;
}

export const newGebeIzlem: CreateGebeIzlemDto = {
  gebeIzlemKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  kacinciGebeIzlem: '',
  sonAdetTarihi: undefined,
  oncekiDogumDurumu: '',
  gebeIzlemIslemTuru: '',
  gestasyonelDiyabetTaramasi: '',
  idrardaProtein: '',
  hemoglobinDegeri: '',
  demirLojistigiVeDestegi: '',
  dvitaminiLojistigiVeDestegi: '',
  konjenitalAnomaliVarligi: '',
  fetusKalpSesi: '',
  diastolikKanBasinciDegeri: '',
  sistolikKanBasinciDegeri: '',
  gebelikteRiskFaktorleri: '',
  bcBeyinGelisimRiskleri: '',
  psikolojikGelisimRiskEgitim: '',
  riskFaktorlerineMudahale: '',
  riskAltindakiOlguTakibi: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
