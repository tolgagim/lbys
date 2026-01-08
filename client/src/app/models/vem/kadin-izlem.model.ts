// KadinIzlem Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KadinIzlemDto extends VemBaseDto {
  kadinIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  konjenitalAnomaliVarligi: string;
  canliDoganBebekSayisi: string;
  oluDoganBebekSayisi: string;
  hemoglobinDegeri: string;
  oncekiDogumDurumu: string;
  izleminYapildigiYer: string;
  kullanilanApYontemi: string;
  birOnceKullanilanApYontemi: string;
  apYontemiLojistigi: string;
  kadinSagligiIslemleri: string;
  apYontemiKullanmamaNedeni: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKadinIzlemDto {
  id: string;
  kadinIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  konjenitalAnomaliVarligi: string;
  canliDoganBebekSayisi: string;
  oluDoganBebekSayisi: string;
  hemoglobinDegeri: string;
}

export interface CreateKadinIzlemDto {
  kadinIzlemKodu: string;
  referansTabloAdi: string;
  hastaKodu: string;
  hastaBasvuruKodu: string;
  konjenitalAnomaliVarligi: string;
  canliDoganBebekSayisi: string;
  oluDoganBebekSayisi: string;
  hemoglobinDegeri: string;
  oncekiDogumDurumu: string;
  izleminYapildigiYer: string;
  kullanilanApYontemi: string;
  birOnceKullanilanApYontemi: string;
  apYontemiLojistigi: string;
  kadinSagligiIslemleri: string;
  apYontemiKullanmamaNedeni: string;
  aciklama: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKadinIzlemDto extends CreateKadinIzlemDto {
  id: string;
}

export interface KadinIzlemListFilter extends BaseListFilter {
  kadinIzlemKodu?: string;
  referansTabloAdi?: string;
  hastaKodu?: string;
  hastaBasvuruKodu?: string;
  konjenitalAnomaliVarligi?: string;
}

export const newKadinIzlem: CreateKadinIzlemDto = {
  kadinIzlemKodu: '',
  referansTabloAdi: '',
  hastaKodu: '',
  hastaBasvuruKodu: '',
  konjenitalAnomaliVarligi: '',
  canliDoganBebekSayisi: '',
  oluDoganBebekSayisi: '',
  hemoglobinDegeri: '',
  oncekiDogumDurumu: '',
  izleminYapildigiYer: '',
  kullanilanApYontemi: '',
  birOnceKullanilanApYontemi: '',
  apYontemiLojistigi: '',
  kadinSagligiIslemleri: '',
  apYontemiKullanmamaNedeni: '',
  aciklama: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
