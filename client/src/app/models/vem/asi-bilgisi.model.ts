// AsiBilgisi Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface AsiBilgisiDto extends VemBaseDto {
  asiBilgisiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  asiKodu: string;
  asininDozu: string;
  asininUygulamaSekli: string;
  asiUygulamaYeri: string;
  asiSorguNumarasi: string;
  asiIslemTuru: string;
  bilgiAlinanKisiAdSoyadi: string;
  bilgiAlinanKisiTelefon: string;
  asiYapilmaZamani?: Date;
  asiOzelDurumNedeni: string;
  asieOrtayaCikisZamani: Date;
  asieNedenleri: string;
  asiErtelemeSuresi: string;
  asiYapilmamaDurumu: string;
  asiYapilmamaNedeni: string;
  alttaYatanHastalik: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListAsiBilgisiDto {
  id: string;
  asiBilgisiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  asiKodu: string;
  asininDozu: string;
  asininUygulamaSekli: string;
  asiUygulamaYeri: string;
}

export interface CreateAsiBilgisiDto {
  asiBilgisiKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  asiKodu: string;
  asininDozu: string;
  asininUygulamaSekli: string;
  asiUygulamaYeri: string;
  asiSorguNumarasi: string;
  asiIslemTuru: string;
  bilgiAlinanKisiAdSoyadi: string;
  bilgiAlinanKisiTelefon: string;
  asiYapilmaZamani?: Date;
  asiOzelDurumNedeni: string;
  asieOrtayaCikisZamani: Date;
  asieNedenleri: string;
  asiErtelemeSuresi: string;
  asiYapilmamaDurumu: string;
  asiYapilmamaNedeni: string;
  alttaYatanHastalik: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateAsiBilgisiDto extends CreateAsiBilgisiDto {
  id: string;
}

export interface AsiBilgisiListFilter extends BaseListFilter {
  asiBilgisiKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  asiKodu?: string;
}

export const newAsiBilgisi: CreateAsiBilgisiDto = {
  asiBilgisiKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  asiKodu: '',
  asininDozu: '',
  asininUygulamaSekli: '',
  asiUygulamaYeri: '',
  asiSorguNumarasi: '',
  asiIslemTuru: '',
  bilgiAlinanKisiAdSoyadi: '',
  bilgiAlinanKisiTelefon: '',
  asiYapilmaZamani: undefined,
  asiOzelDurumNedeni: '',
  asieOrtayaCikisZamani: undefined,
  asieNedenleri: '',
  asiErtelemeSuresi: '',
  asiYapilmamaDurumu: '',
  asiYapilmamaNedeni: '',
  alttaYatanHastalik: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
