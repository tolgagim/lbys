// Patoloji Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface PatolojiDto extends VemBaseDto {
  patolojiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  patolojiRaporTuru: string;
  dokununTemelOzelligi: string;
  numuneAlinmaSekli: string;
  patolojiPreparatiDurumu: string;
  patolojiDefterNumarasi: string;
  tetkikNumuneKodu: string;
  patolojiMateryali: string;
  organ: string;
  numuneAlinmaYeri: string;
  patolojikBulgu: string;
  patolojikTaniMorfolojiKodu: string;
  patolojikTaniYerlesimYeri: string;
  makroskopiSonucu: string;
  mikroskopiSonucu: string;
  sonucIcerikTuru: string;
  raporYazanPersonelKodu: string;
  parcaKabulZamani: Date;
  raporZamani: Date;
  patolojiAciklama: string;
  histopatolojikTani: string;
  sitopatolojikTani: string;
  histokimyasalBoyama: string;
  immunhistokimyaBoyama: string;
  frozenTani: string;
  numuneBoyamaYontemi: string;
  onaylayanHekimKodu: string;
  asistanHekimKodu: string;
  patolojiDigerHekimKodu: string;
  yorum: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListPatolojiDto {
  id: string;
  patolojiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  patolojiRaporTuru: string;
  dokununTemelOzelligi: string;
  numuneAlinmaSekli: string;
  patolojiPreparatiDurumu: string;
}

export interface CreatePatolojiDto {
  patolojiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  patolojiRaporTuru: string;
  dokununTemelOzelligi: string;
  numuneAlinmaSekli: string;
  patolojiPreparatiDurumu: string;
  patolojiDefterNumarasi: string;
  tetkikNumuneKodu: string;
  patolojiMateryali: string;
  organ: string;
  numuneAlinmaYeri: string;
  patolojikBulgu: string;
  patolojikTaniMorfolojiKodu: string;
  patolojikTaniYerlesimYeri: string;
  makroskopiSonucu: string;
  mikroskopiSonucu: string;
  sonucIcerikTuru: string;
  raporYazanPersonelKodu: string;
  parcaKabulZamani: Date;
  raporZamani: Date;
  patolojiAciklama: string;
  histopatolojikTani: string;
  sitopatolojikTani: string;
  histokimyasalBoyama: string;
  immunhistokimyaBoyama: string;
  frozenTani: string;
  numuneBoyamaYontemi: string;
  onaylayanHekimKodu: string;
  asistanHekimKodu: string;
  patolojiDigerHekimKodu: string;
  yorum: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdatePatolojiDto extends CreatePatolojiDto {
  id: string;
}

export interface PatolojiListFilter extends BaseListFilter {
  patolojiKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  patolojiRaporTuru?: string;
}

export const newPatoloji: CreatePatolojiDto = {
  patolojiKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  patolojiRaporTuru: '',
  dokununTemelOzelligi: '',
  numuneAlinmaSekli: '',
  patolojiPreparatiDurumu: '',
  patolojiDefterNumarasi: '',
  tetkikNumuneKodu: '',
  patolojiMateryali: '',
  organ: '',
  numuneAlinmaYeri: '',
  patolojikBulgu: '',
  patolojikTaniMorfolojiKodu: '',
  patolojikTaniYerlesimYeri: '',
  makroskopiSonucu: '',
  mikroskopiSonucu: '',
  sonucIcerikTuru: '',
  raporYazanPersonelKodu: '',
  parcaKabulZamani: undefined,
  raporZamani: undefined,
  patolojiAciklama: '',
  histopatolojikTani: '',
  sitopatolojikTani: '',
  histokimyasalBoyama: '',
  immunhistokimyaBoyama: '',
  frozenTani: '',
  numuneBoyamaYontemi: '',
  onaylayanHekimKodu: '',
  asistanHekimKodu: '',
  patolojiDigerHekimKodu: '',
  yorum: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
