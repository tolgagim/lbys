// KanTalep Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KanTalepDto extends VemBaseDto {
  kanTalepKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kanTalepZamani?: Date;
  kanTalepAciklama: string;
  kanTalepNedeni: string;
  kanIsteyenBirimKodu: string;
  isteyenHekimKodu: string;
  istenenKanGrubu: string;
  planlananTransfuzyonZamani: Date;
  planlananTransfuzyonSuresi: string;
  kanTalepAciliyetSeviyesi: string;
  crossMatchYapilmaDurumu: string;
  kanAcilAciklama: string;
  kanAntikorDurumu: string;
  transplantasyonGecirmeDurumu: string;
  transfuzyonGecirmeDurumu: string;
  transfuzyonReaksiyonDurumu: string;
  gebelikGecirmeDurumu: string;
  fetomaternalUyusmazlikDurumu: string;
  kanTalepOzelDurum: string;
  hematokritOrani: string;
  trombositSayisi: string;
  kanEndikasyonTuru: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKanTalepDto {
  id: string;
  kanTalepKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kanTalepZamani?: Date;
  kanTalepAciklama: string;
  kanTalepNedeni: string;
  kanIsteyenBirimKodu: string;
}

export interface CreateKanTalepDto {
  kanTalepKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  kanTalepZamani?: Date;
  kanTalepAciklama: string;
  kanTalepNedeni: string;
  kanIsteyenBirimKodu: string;
  isteyenHekimKodu: string;
  istenenKanGrubu: string;
  planlananTransfuzyonZamani: Date;
  planlananTransfuzyonSuresi: string;
  kanTalepAciliyetSeviyesi: string;
  crossMatchYapilmaDurumu: string;
  kanAcilAciklama: string;
  kanAntikorDurumu: string;
  transplantasyonGecirmeDurumu: string;
  transfuzyonGecirmeDurumu: string;
  transfuzyonReaksiyonDurumu: string;
  gebelikGecirmeDurumu: string;
  fetomaternalUyusmazlikDurumu: string;
  kanTalepOzelDurum: string;
  hematokritOrani: string;
  trombositSayisi: string;
  kanEndikasyonTuru: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKanTalepDto extends CreateKanTalepDto {
  id: string;
}

export interface KanTalepListFilter extends BaseListFilter {
  kanTalepKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  kanTalepAciklama?: string;
}

export const newKanTalep: CreateKanTalepDto = {
  kanTalepKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  kanTalepZamani: undefined,
  kanTalepAciklama: '',
  kanTalepNedeni: '',
  kanIsteyenBirimKodu: '',
  isteyenHekimKodu: '',
  istenenKanGrubu: '',
  planlananTransfuzyonZamani: undefined,
  planlananTransfuzyonSuresi: '',
  kanTalepAciliyetSeviyesi: '',
  crossMatchYapilmaDurumu: '',
  kanAcilAciklama: '',
  kanAntikorDurumu: '',
  transplantasyonGecirmeDurumu: '',
  transfuzyonGecirmeDurumu: '',
  transfuzyonReaksiyonDurumu: '',
  gebelikGecirmeDurumu: '',
  fetomaternalUyusmazlikDurumu: '',
  kanTalepOzelDurum: '',
  hematokritOrani: '',
  trombositSayisi: '',
  kanEndikasyonTuru: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
