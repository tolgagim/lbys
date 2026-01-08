// KanBagisci Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface KanBagisciDto extends VemBaseDto {
  kanBagisciKodu: string;
  referansTabloAdi: string;
  bagisciHastaBasvuruKodu: string;
  bagisciHastaKodu: string;
  kanBagisZamani?: Date;
  kanGrubu: string;
  aciklama: string;
  rezervHastaKodu: string;
  bagislananKanTuru: string;
  reaksiyonDurumu: string;
  reaksiyonTuru: string;
  reaksiyonAciklama: string;
  kizilayIzinNumarasi: string;
  sistolikKanBasinciDegeri: string;
  diastolikKanBasinciDegeri: string;
  ates: string;
  boy: string;
  agirlik: string;
  uzmanDegerlendirme: string;
  lotNumarasi: string;
  kanHacim: string;
  segmentNumarasi: string;
  bagisciTuru: string;
  kanBagisDegerlendirmeSonucu: string;
  degerlendirenPersonelKodu: string;
  kanBagisDegerlendirmeZamani: Date;
  kanBagiscisiRetNedenleri: string;
  retSuresi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface ListKanBagisciDto {
  id: string;
  kanBagisciKodu: string;
  referansTabloAdi: string;
  bagisciHastaBasvuruKodu: string;
  bagisciHastaKodu: string;
  kanBagisZamani?: Date;
  kanGrubu: string;
  aciklama: string;
  rezervHastaKodu: string;
}

export interface CreateKanBagisciDto {
  kanBagisciKodu: string;
  referansTabloAdi: string;
  bagisciHastaBasvuruKodu: string;
  bagisciHastaKodu: string;
  kanBagisZamani?: Date;
  kanGrubu: string;
  aciklama: string;
  rezervHastaKodu: string;
  bagislananKanTuru: string;
  reaksiyonDurumu: string;
  reaksiyonTuru: string;
  reaksiyonAciklama: string;
  kizilayIzinNumarasi: string;
  sistolikKanBasinciDegeri: string;
  diastolikKanBasinciDegeri: string;
  ates: string;
  boy: string;
  agirlik: string;
  uzmanDegerlendirme: string;
  lotNumarasi: string;
  kanHacim: string;
  segmentNumarasi: string;
  bagisciTuru: string;
  kanBagisDegerlendirmeSonucu: string;
  degerlendirenPersonelKodu: string;
  kanBagisDegerlendirmeZamani: Date;
  kanBagiscisiRetNedenleri: string;
  retSuresi: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface UpdateKanBagisciDto extends CreateKanBagisciDto {
  id: string;
}

export interface KanBagisciListFilter extends BaseListFilter {
  kanBagisciKodu?: string;
  referansTabloAdi?: string;
  bagisciHastaBasvuruKodu?: string;
  bagisciHastaKodu?: string;
  kanGrubu?: string;
}

export const newKanBagisci: CreateKanBagisciDto = {
  kanBagisciKodu: '',
  referansTabloAdi: '',
  bagisciHastaBasvuruKodu: '',
  bagisciHastaKodu: '',
  kanBagisZamani: undefined,
  kanGrubu: '',
  aciklama: '',
  rezervHastaKodu: '',
  bagislananKanTuru: '',
  reaksiyonDurumu: '',
  reaksiyonTuru: '',
  reaksiyonAciklama: '',
  kizilayIzinNumarasi: '',
  sistolikKanBasinciDegeri: '',
  diastolikKanBasinciDegeri: '',
  ates: '',
  boy: '',
  agirlik: '',
  uzmanDegerlendirme: '',
  lotNumarasi: '',
  kanHacim: '',
  segmentNumarasi: '',
  bagisciTuru: '',
  kanBagisDegerlendirmeSonucu: '',
  degerlendirenPersonelKodu: '',
  kanBagisDegerlendirmeZamani: undefined,
  kanBagiscisiRetNedenleri: '',
  retSuresi: '',
  ekleyenKullaniciKodu: '',
  kayitZamani: undefined,
  guncelleyenKullaniciKodu: '',
  guncellemeZamani: undefined,
};
