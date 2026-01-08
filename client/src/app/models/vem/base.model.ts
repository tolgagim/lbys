// VEM Base Model Definitions

export interface BaseDto {
  id: string;
}

export interface AuditableDto extends BaseDto {
  referansTabloyaAdi?: string;
  ekleyenKullaniciKodu?: string;
  kayitZamani?: Date;
  guncelleyenKullaniciKodu?: string;
  guncellemeZamani?: Date;
}

export interface VemBaseDto extends AuditableDto {
  // VEM specific base fields
}

// Search/Filter DTOs
export interface BaseListFilter {
  pageNumber: number;
  pageSize: number;
  keyword?: string;
  orderBy?: string[];
}

export interface VemListFilter extends BaseListFilter {
  // VEM specific filters can be added here
}

// Response Models
export interface PaginatedResponse<T> {
  data: T[];
  totalCount: number;
  currentPage: number;
  totalPages: number;
}

export interface ApiResponse<T> {
  data: T;
  succeeded: boolean;
  message?: string;
  errors?: string[];
}

// Code Parameter DTOs
export interface CodeParameterDto {
  // Base code parameter
}

// Generic Create/Update DTOs
export interface CreateVemDto {
  [key: string]: any;
}

export interface UpdateVemDto extends CreateVemDto {
  id: string;
}
