// MaddeBagimliligi Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface MaddeBagimliligiDto extends VemBaseDto {
  maddeBagimliligiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  bilgiAlinanKaynak: string;
  danismaTedaviHizmetDurumu: string;
  danismaTedaviHizmetZamani: Date;
  ikameTedaviDurumu: string;
  sonIkameTedaviZamani: Date;
  cezaeviOykusu: string;
  sosyalYardimAlmaDurumu: string;
  yasadigiBolge: string;
  yasamBicimi: string;
  cocuklariylaYasamaDurumu: string;
  enjeksiyonIleMaddeKullanimi: string;
  enjeksiyonIlkKullanimYasi: string;
  enjektorPaylasimDurumu: string;
  ilkEnjektorPaylasimYasi: string;
  hivTestYapilmaDurumu: string;
  hcvTestYapilmaDurumu: string;
  hbvTestYapilmaDurumu: string;
  gorusmeSonucu: string;
  gonderenBirim: string;
  yasamOrtami: string;
  bulasiciHastalikDurumu: string;
  baslananTedaviTipiBilgisi: string;
  birincilKullanilanEsasMadde: string;
  kullanilanDigerMadde: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListMaddeBagimliligiDto {
  id: string;
  maddeBagimliligiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  bilgiAlinanKaynak: string;
  danismaTedaviHizmetDurumu: string;
  danismaTedaviHizmetZamani: Date;
  ikameTedaviDurumu: string;
  sonIkameTedaviZamani: Date;
}

export interface CreateMaddeBagimliligiDto {
  maddeBagimliligiKodu: string;
  referansTabloAdi: string;
  hastaBasvuruKodu: string;
  bilgiAlinanKaynak: string;
  danismaTedaviHizmetDurumu: string;
  danismaTedaviHizmetZamani: Date;
  ikameTedaviDurumu: string;
  sonIkameTedaviZamani: Date;
  cezaeviOykusu: string;
  sosyalYardimAlmaDurumu: string;
  yasadigiBolge: string;
  yasamBicimi: string;
  cocuklariylaYasamaDurumu: string;
  enjeksiyonIleMaddeKullanimi: string;
  enjeksiyonIlkKullanimYasi: string;
  enjektorPaylasimDurumu: string;
  ilkEnjektorPaylasimYasi: string;
  hivTestYapilmaDurumu: string;
  hcvTestYapilmaDurumu: string;
  hbvTestYapilmaDurumu: string;
  gorusmeSonucu: string;
  gonderenBirim: string;
  yasamOrtami: string;
  bulasiciHastalikDurumu: string;
  baslananTedaviTipiBilgisi: string;
  birincilKullanilanEsasMadde: string;
  kullanilanDigerMadde: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateMaddeBagimliligiDto extends CreateMaddeBagimliligiDto {
  id: string;
}

export interface MaddeBagimliligiListFilter extends BaseListFilter {
  maddeBagimliligiKodu?: string;
  referansTabloAdi?: string;
  hastaBasvuruKodu?: string;
  bilgiAlinanKaynak?: string;
  danismaTedaviHizmetDurumu?: string;
}

export const newMaddeBagimliligi: CreateMaddeBagimliligiDto = {
  maddeBagimliligiKodu: '',
  referansTabloAdi: '',
  hastaBasvuruKodu: '',
  bilgiAlinanKaynak: '',
  danismaTedaviHizmetDurumu: '',
  danismaTedaviHizmetZamani: undefined,
  ikameTedaviDurumu: '',
  sonIkameTedaviZamani: undefined,
  cezaeviOykusu: '',
  sosyalYardimAlmaDurumu: '',
  yasadigiBolge: '',
  yasamBicimi: '',
  cocuklariylaYasamaDurumu: '',
  enjeksiyonIleMaddeKullanimi: '',
  enjeksiyonIlkKullanimYasi: '',
  enjektorPaylasimDurumu: '',
  ilkEnjektorPaylasimYasi: '',
  hivTestYapilmaDurumu: '',
  hcvTestYapilmaDurumu: '',
  hbvTestYapilmaDurumu: '',
  gorusmeSonucu: '',
  gonderenBirim: '',
  yasamOrtami: '',
  bulasiciHastalikDurumu: '',
  baslananTedaviTipiBilgisi: '',
  birincilKullanilanEsasMadde: '',
  kullanilanDigerMadde: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
