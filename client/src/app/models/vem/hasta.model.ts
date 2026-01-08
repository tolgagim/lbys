// Hasta Model Definitions
import { VemBaseDto, BaseListFilter } from './base.model';

export interface HastaDto extends VemBaseDto {
  hastaKodu: string;
  tcKimlikNumarasi?: string;
  ad: string;
  soyad: string;
  dogumTarihi?: Date;
  cinsiyet?: string;
  kanGrubu?: string;
  telefon?: string;
  eposta?: string;
  adres?: string;
}

export interface ListHastaDto {
  id: string;
  hastaKodu: string;
  tcKimlikNumarasi?: string;
  ad: string;
  soyad: string;
  dogumTarihi?: Date;
  cinsiyet?: string;
}

export interface CreateHastaDto {
  hastaKodu: string;
  tcKimlikNumarasi?: string;
  ad: string;
  soyad: string;
  dogumTarihi?: Date;
  cinsiyet?: string;
  kanGrubu?: string;
  telefon?: string;
  eposta?: string;
  adres?: string;
}

export interface UpdateHastaDto extends CreateHastaDto {
  id: string;
}

export interface HastaListFilter extends BaseListFilter {
  hastaKodu?: string;
  tcKimlikNumarasi?: string;
  ad?: string;
  soyad?: string;
}

export const newHasta: CreateHastaDto = {
  hastaKodu: '',
  tcKimlikNumarasi: '',
  ad: '',
  soyad: '',
  dogumTarihi: undefined,
  cinsiyet: '',
  kanGrubu: '',
  telefon: '',
  eposta: '',
  adres: ''
};
