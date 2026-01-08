// OptikRecete Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface OptikReceteDto extends VemBaseDto {
  optikReceteKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  gozlukReceteTipi: string;
  hekimKodu: string;
  receteZamani?: Date;
  gozlukTuru: string;
  sagCamTipi: string;
  sagCamRengi: string;
  sagCamSferik: string;
  sagCamSilindirik: string;
  sagCamAks: string;
  solCamTipi: string;
  solCamRengi: string;
  solCamSferik: string;
  solCamSilindirik: string;
  solCamAks: string;
  sagLensCamSferik: string;
  sagLensCamSilindirik: string;
  sagLensCamCap: string;
  sagLensCamEgim: string;
  sagLensCamAks: string;
  solLensCamSferik: string;
  solLensCamSilindirik: string;
  solLensCamCap: string;
  solLensCamEgim: string;
  solLensCamAks: string;
  sagKeratakonusCamSferik: string;
  sagKeratakonusCamSilindir: string;
  sagKeratakonusCamCap: string;
  sagKeratakonusCamEgim: string;
  sagKeratakonusCamAks: string;
  solKeratakonusCamSferik: string;
  solKeratakonusCamSilindir: string;
  solKeratakonusCamCap: string;
  solKeratakonusCamEgim: string;
  solKeratakonusCamAks: string;
  teleskopikGozlukTipi: string;
  teleskopikGozlukTuru: string;
  teleskopikSagCam: string;
  teleskopikSolCam: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListOptikReceteDto {
  id: string;
  optikReceteKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  gozlukReceteTipi: string;
  hekimKodu: string;
  receteZamani?: Date;
  gozlukTuru: string;
}

export interface CreateOptikReceteDto {
  optikReceteKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  gozlukReceteTipi: string;
  hekimKodu: string;
  receteZamani?: Date;
  gozlukTuru: string;
  sagCamTipi: string;
  sagCamRengi: string;
  sagCamSferik: string;
  sagCamSilindirik: string;
  sagCamAks: string;
  solCamTipi: string;
  solCamRengi: string;
  solCamSferik: string;
  solCamSilindirik: string;
  solCamAks: string;
  sagLensCamSferik: string;
  sagLensCamSilindirik: string;
  sagLensCamCap: string;
  sagLensCamEgim: string;
  sagLensCamAks: string;
  solLensCamSferik: string;
  solLensCamSilindirik: string;
  solLensCamCap: string;
  solLensCamEgim: string;
  solLensCamAks: string;
  sagKeratakonusCamSferik: string;
  sagKeratakonusCamSilindir: string;
  sagKeratakonusCamCap: string;
  sagKeratakonusCamEgim: string;
  sagKeratakonusCamAks: string;
  solKeratakonusCamSferik: string;
  solKeratakonusCamSilindir: string;
  solKeratakonusCamCap: string;
  solKeratakonusCamEgim: string;
  solKeratakonusCamAks: string;
  teleskopikGozlukTipi: string;
  teleskopikGozlukTuru: string;
  teleskopikSagCam: string;
  teleskopikSolCam: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateOptikReceteDto extends CreateOptikReceteDto {
  id: string;
}

export interface OptikReceteListFilter extends BaseListFilter {
  optikReceteKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  gozlukReceteTipi?: string;
}

export const newOptikRecete: CreateOptikReceteDto = {
  optikReceteKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  gozlukReceteTipi: '',
  hekimKodu: '',
  receteZamani: undefined,
  gozlukTuru: '',
  sagCamTipi: '',
  sagCamRengi: '',
  sagCamSferik: '',
  sagCamSilindirik: '',
  sagCamAks: '',
  solCamTipi: '',
  solCamRengi: '',
  solCamSferik: '',
  solCamSilindirik: '',
  solCamAks: '',
  sagLensCamSferik: '',
  sagLensCamSilindirik: '',
  sagLensCamCap: '',
  sagLensCamEgim: '',
  sagLensCamAks: '',
  solLensCamSferik: '',
  solLensCamSilindirik: '',
  solLensCamCap: '',
  solLensCamEgim: '',
  solLensCamAks: '',
  sagKeratakonusCamSferik: '',
  sagKeratakonusCamSilindir: '',
  sagKeratakonusCamCap: '',
  sagKeratakonusCamEgim: '',
  sagKeratakonusCamAks: '',
  solKeratakonusCamSferik: '',
  solKeratakonusCamSilindir: '',
  solKeratakonusCamCap: '',
  solKeratakonusCamEgim: '',
  solKeratakonusCamAks: '',
  teleskopikGozlukTipi: '',
  teleskopikGozlukTuru: '',
  teleskopikSagCam: '',
  teleskopikSolCam: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
