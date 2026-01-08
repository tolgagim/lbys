// HastaArsiv Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaArsivDto extends VemBaseDto {
  hastaArsivKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  arsivNumarasi: string;
  eskiArsivNumarasi: string;
  arsivDefterTuru: string;
  arsivYeri: string;
  aciklama: string;
  arsivIlkGirisTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHastaArsivDto {
  id: string;
  hastaArsivKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  arsivNumarasi: string;
  eskiArsivNumarasi: string;
  arsivDefterTuru: string;
  arsivYeri: string;
  aciklama: string;
}

export interface CreateHastaArsivDto {
  hastaArsivKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  arsivNumarasi: string;
  eskiArsivNumarasi: string;
  arsivDefterTuru: string;
  arsivYeri: string;
  aciklama: string;
  arsivIlkGirisTarihi: Date;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHastaArsivDto extends CreateHastaArsivDto {
  id: string;
}

export interface HastaArsivListFilter extends BaseListFilter {
  hastaArsivKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  arsivNumarasi?: string;
  eskiArsivNumarasi?: string;
}

export const newHastaArsiv: CreateHastaArsivDto = {
  hastaArsivKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  arsivNumarasi: '',
  eskiArsivNumarasi: '',
  arsivDefterTuru: '',
  arsivYeri: '',
  aciklama: '',
  arsivIlkGirisTarihi: undefined,
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
