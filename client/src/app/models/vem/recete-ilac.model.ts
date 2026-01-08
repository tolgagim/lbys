// ReceteIlac Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface ReceteIlacDto extends VemBaseDto {
  receteIlacKodu: string;
  referansTabloAdi: string;
  receteKodu: string;
  dozBirim: string;
  barkod: string;
  ilacAdi: string;
  kutuAdeti: string;
  ilacKullanimSekli: string;
  ilacKullanimSayisi: string;
  ilacKullanimDozu: string;
  ilacKullanimPeriyodu: string;
  ilacKullanimPeriyoduBirimi: string;
  ilacAciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListReceteIlacDto {
  id: string;
  receteIlacKodu: string;
  referansTabloAdi: string;
  receteKodu: string;
  dozBirim: string;
  barkod: string;
  ilacAdi: string;
  kutuAdeti: string;
  ilacKullanimSekli: string;
}

export interface CreateReceteIlacDto {
  receteIlacKodu: string;
  referansTabloAdi: string;
  receteKodu: string;
  dozBirim: string;
  barkod: string;
  ilacAdi: string;
  kutuAdeti: string;
  ilacKullanimSekli: string;
  ilacKullanimSayisi: string;
  ilacKullanimDozu: string;
  ilacKullanimPeriyodu: string;
  ilacKullanimPeriyoduBirimi: string;
  ilacAciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateReceteIlacDto extends CreateReceteIlacDto {
  id: string;
}

export interface ReceteIlacListFilter extends BaseListFilter {
  receteIlacKodu?: string;
  referansTabloAdi?: string;
  receteKodu?: string;
  dozBirim?: string;
  barkod?: string;
}

export const newReceteIlac: CreateReceteIlacDto = {
  receteIlacKodu: '',
  referansTabloAdi: '',
  receteKodu: '',
  dozBirim: '',
  barkod: '',
  ilacAdi: '',
  kutuAdeti: '',
  ilacKullanimSekli: '',
  ilacKullanimSayisi: '',
  ilacKullanimDozu: '',
  ilacKullanimPeriyodu: '',
  ilacKullanimPeriyoduBirimi: '',
  ilacAciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
