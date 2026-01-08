// OrtodontiIconSkor Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface OrtodontiIconSkorDto extends VemBaseDto {
  ortodontiIconSkorKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  oisDegerlendirmeZamani?: Date;
  oisEstetikBozuklukBilgisi: string;
  oisEstetikPuanKatsayisi: string;
  oisEstetikPuani: string;
  ustDisArkaCaprasiklik: string;
  ustArkaCaprasiklikKatsayisi: string;
  ustArkaCaprasiklikPuani: string;
  ustDisArkaBosluk: string;
  ustArkaBoslukKatsayisi: string;
  ustArkaBoslukPuani: string;
  disCaprazlikDurumu: string;
  disCaprazlikKatsayisi: string;
  disCaprazlikPuani: string;
  onAcikKapanis: string;
  onAcikKapanisKatsayisi: string;
  onAcikKapanisPuani: string;
  onDerinKapanis: string;
  onDerinKapanisKatsayisi: string;
  onDerinKapanisPuani: string;
  bukkalBolgeSag: string;
  bukkalBolgeSagKatsayisi: string;
  bukkalBolgeSagPuani: string;
  bukkalBolgeSol: string;
  bukkalBolgeSolKatsayisi: string;
  bukkalBolgeSolPuani: string;
  bukkalToplamPuani: string;
  toplamIconSkorPuani: string;
  oisDegerlendiren1HekimKodu: string;
  oisDegerlendiren2HekimKodu: string;
  oisDegerlendiren3HekimKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListOrtodontiIconSkorDto {
  id: string;
  ortodontiIconSkorKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  oisDegerlendirmeZamani?: Date;
  oisEstetikBozuklukBilgisi: string;
  oisEstetikPuanKatsayisi: string;
  oisEstetikPuani: string;
}

export interface CreateOrtodontiIconSkorDto {
  ortodontiIconSkorKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  oisDegerlendirmeZamani?: Date;
  oisEstetikBozuklukBilgisi: string;
  oisEstetikPuanKatsayisi: string;
  oisEstetikPuani: string;
  ustDisArkaCaprasiklik: string;
  ustArkaCaprasiklikKatsayisi: string;
  ustArkaCaprasiklikPuani: string;
  ustDisArkaBosluk: string;
  ustArkaBoslukKatsayisi: string;
  ustArkaBoslukPuani: string;
  disCaprazlikDurumu: string;
  disCaprazlikKatsayisi: string;
  disCaprazlikPuani: string;
  onAcikKapanis: string;
  onAcikKapanisKatsayisi: string;
  onAcikKapanisPuani: string;
  onDerinKapanis: string;
  onDerinKapanisKatsayisi: string;
  onDerinKapanisPuani: string;
  bukkalBolgeSag: string;
  bukkalBolgeSagKatsayisi: string;
  bukkalBolgeSagPuani: string;
  bukkalBolgeSol: string;
  bukkalBolgeSolKatsayisi: string;
  bukkalBolgeSolPuani: string;
  bukkalToplamPuani: string;
  toplamIconSkorPuani: string;
  oisDegerlendiren1HekimKodu: string;
  oisDegerlendiren2HekimKodu: string;
  oisDegerlendiren3HekimKodu: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateOrtodontiIconSkorDto extends CreateOrtodontiIconSkorDto {
  id: string;
}

export interface OrtodontiIconSkorListFilter extends BaseListFilter {
  ortodontiIconSkorKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  oisEstetikBozuklukBilgisi?: string;
}

export const newOrtodontiIconSkor: CreateOrtodontiIconSkorDto = {
  ortodontiIconSkorKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  oisDegerlendirmeZamani: undefined,
  oisEstetikBozuklukBilgisi: '',
  oisEstetikPuanKatsayisi: '',
  oisEstetikPuani: '',
  ustDisArkaCaprasiklik: '',
  ustArkaCaprasiklikKatsayisi: '',
  ustArkaCaprasiklikPuani: '',
  ustDisArkaBosluk: '',
  ustArkaBoslukKatsayisi: '',
  ustArkaBoslukPuani: '',
  disCaprazlikDurumu: '',
  disCaprazlikKatsayisi: '',
  disCaprazlikPuani: '',
  onAcikKapanis: '',
  onAcikKapanisKatsayisi: '',
  onAcikKapanisPuani: '',
  onDerinKapanis: '',
  onDerinKapanisKatsayisi: '',
  onDerinKapanisPuani: '',
  bukkalBolgeSag: '',
  bukkalBolgeSagKatsayisi: '',
  bukkalBolgeSagPuani: '',
  bukkalBolgeSol: '',
  bukkalBolgeSolKatsayisi: '',
  bukkalBolgeSolPuani: '',
  bukkalToplamPuani: '',
  toplamIconSkorPuani: '',
  oisDegerlendiren1HekimKodu: '',
  oisDegerlendiren2HekimKodu: '',
  oisDegerlendiren3HekimKodu: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
