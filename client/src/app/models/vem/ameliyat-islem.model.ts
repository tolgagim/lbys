// AmeliyatIslem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface AmeliyatIslemDto extends VemBaseDto {
  ameliyatIslemKodu: string;
  referansTabloAdi: string;
  ameliyatKodu: string;
  ameliyatGrubu: string;
  hastaHizmetKodu: string;
  kesiSayisi: string;
  kesiOrani: string;
  kesiSeansBilgisi: string;
  tarafBilgisi: string;
  komplikasyon: string;
  ameliyatSonucu: string;
  ameliyatNotu: string;
  asaSkoru: string;
  euroscore: string;
  yaraSinifi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListAmeliyatIslemDto {
  id: string;
  ameliyatIslemKodu: string;
  referansTabloAdi: string;
  ameliyatKodu: string;
  ameliyatGrubu: string;
  hastaHizmetKodu: string;
  kesiSayisi: string;
  kesiOrani: string;
  kesiSeansBilgisi: string;
}

export interface CreateAmeliyatIslemDto {
  ameliyatIslemKodu: string;
  referansTabloAdi: string;
  ameliyatKodu: string;
  ameliyatGrubu: string;
  hastaHizmetKodu: string;
  kesiSayisi: string;
  kesiOrani: string;
  kesiSeansBilgisi: string;
  tarafBilgisi: string;
  komplikasyon: string;
  ameliyatSonucu: string;
  ameliyatNotu: string;
  asaSkoru: string;
  euroscore: string;
  yaraSinifi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateAmeliyatIslemDto extends CreateAmeliyatIslemDto {
  id: string;
}

export interface AmeliyatIslemListFilter extends BaseListFilter {
  ameliyatIslemKodu?: string;
  referansTabloAdi?: string;
  ameliyatKodu?: string;
  ameliyatGrubu?: string;
  hastaHizmetKodu?: string;
}

export const newAmeliyatIslem: CreateAmeliyatIslemDto = {
  ameliyatIslemKodu: '',
  referansTabloAdi: '',
  ameliyatKodu: '',
  ameliyatGrubu: '',
  hastaHizmetKodu: '',
  kesiSayisi: '',
  kesiOrani: '',
  kesiSeansBilgisi: '',
  tarafBilgisi: '',
  komplikasyon: '',
  ameliyatSonucu: '',
  ameliyatNotu: '',
  asaSkoru: '',
  euroscore: '',
  yaraSinifi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
