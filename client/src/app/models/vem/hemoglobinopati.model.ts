// Hemoglobinopati Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HemoglobinopatiDto extends VemBaseDto {
  hemoglobinopatiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hemoglobinopatiTaramaSonucu: string;
  esAdayiTcKimlikNumarasi: string;
  esAdayiTelefonNumarasi: string;
  hemoglobinopatiTestiSonucu: string;
  hemoglobinopatiIslemTipi: string;
  hemoglobinopatiSonucHastalik: string;
  hemoglobinopatiTasiyicilik: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListHemoglobinopatiDto {
  id: string;
  hemoglobinopatiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hemoglobinopatiTaramaSonucu: string;
  esAdayiTcKimlikNumarasi: string;
  esAdayiTelefonNumarasi: string;
  hemoglobinopatiTestiSonucu: string;
  hemoglobinopatiIslemTipi: string;
}

export interface CreateHemoglobinopatiDto {
  hemoglobinopatiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hemoglobinopatiTaramaSonucu: string;
  esAdayiTcKimlikNumarasi: string;
  esAdayiTelefonNumarasi: string;
  hemoglobinopatiTestiSonucu: string;
  hemoglobinopatiIslemTipi: string;
  hemoglobinopatiSonucHastalik: string;
  hemoglobinopatiTasiyicilik: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateHemoglobinopatiDto extends CreateHemoglobinopatiDto {
  id: string;
}

export interface HemoglobinopatiListFilter extends BaseListFilter {
  hemoglobinopatiKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hemoglobinopatiTaramaSonucu?: string;
  esAdayiTcKimlikNumarasi?: string;
}

export const newHemoglobinopati: CreateHemoglobinopatiDto = {
  hemoglobinopatiKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hemoglobinopatiTaramaSonucu: '',
  esAdayiTcKimlikNumarasi: '',
  esAdayiTelefonNumarasi: '',
  hemoglobinopatiTestiSonucu: '',
  hemoglobinopatiIslemTipi: '',
  hemoglobinopatiSonucHastalik: '',
  hemoglobinopatiTasiyicilik: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
