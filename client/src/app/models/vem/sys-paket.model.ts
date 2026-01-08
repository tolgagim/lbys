// SysPaket Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface SysPaketDto extends VemBaseDto {
  sysPaketKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  veriPaketiNumarasi: string;
  veriPaketiGonderilmeZamani: Date;
  veriPaketiGonderimDurumu: string;
  gonderilenPaketBilgisi: string;
  gelenCevapBilgisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListSysPaketDto {
  id: string;
  sysPaketKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  veriPaketiNumarasi: string;
  veriPaketiGonderilmeZamani: Date;
  veriPaketiGonderimDurumu: string;
  gonderilenPaketBilgisi: string;
}

export interface CreateSysPaketDto {
  sysPaketKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  hastaKodu: string;
  veriPaketiNumarasi: string;
  veriPaketiGonderilmeZamani: Date;
  veriPaketiGonderimDurumu: string;
  gonderilenPaketBilgisi: string;
  gelenCevapBilgisi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateSysPaketDto extends CreateSysPaketDto {
  id: string;
}

export interface SysPaketListFilter extends BaseListFilter {
  sysPaketKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  hastaKodu?: string;
  veriPaketiNumarasi?: string;
}

export const newSysPaket: CreateSysPaketDto = {
  sysPaketKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  hastaKodu: '',
  veriPaketiNumarasi: '',
  veriPaketiGonderilmeZamani: undefined,
  veriPaketiGonderimDurumu: '',
  gonderilenPaketBilgisi: '',
  gelenCevapBilgisi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
