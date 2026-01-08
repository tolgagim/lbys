import { Injectable } from '@angular/core';
import { firstValueFrom, timeout } from 'rxjs';
import { HttpService } from '../http.service';
import { PaginatedResponse, BaseListFilter } from '../../models/vem/base.model';
import notify from 'devextreme/ui/notify';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';

@Injectable()
export abstract class BaseVemService<
  TDto,
  TListDto,
  TCreateDto,
  TUpdateDto,
  TListFilter extends BaseListFilter
> {
  protected abstract apiUrl: string;

  constructor(protected http: HttpService) {}

  // Get by ID
  async getById(id: string): Promise<TDto> {
    return await firstValueFrom(
      this.http.get<TDto>(`${this.apiUrl}/${id}`)
    );
  }

  // Search with pagination (POST to /search endpoint)
  search(filter: TListFilter): Promise<PaginatedResponse<TListDto>> {
    const searchUrl = `${this.apiUrl}/search`;

    return new Promise((resolve, reject) => {
      this.http.post<PaginatedResponse<TListDto>>(searchUrl, filter).pipe(
        timeout(30000)
      ).subscribe({
        next: (response) => {
          resolve(response);
        },
        error: (err) => {
          console.error('Search API Error:', err);
          reject(err);
        }
      });
    });
  }

  // Build query string from filter object
  protected buildQueryParams(filter: any): string {
    const params: string[] = [];
    for (const key in filter) {
      if (filter.hasOwnProperty(key) && filter[key] !== null && filter[key] !== undefined && filter[key] !== '') {
        if (Array.isArray(filter[key])) {
          filter[key].forEach((value: any) => {
            params.push(`${encodeURIComponent(key)}=${encodeURIComponent(value)}`);
          });
        } else {
          params.push(`${encodeURIComponent(key)}=${encodeURIComponent(filter[key])}`);
        }
      }
    }
    return params.join('&');
  }

  // Create
  async create(data: TCreateDto): Promise<TDto> {
    return await firstValueFrom(
      this.http.post<TDto>(this.apiUrl, data)
    );
  }

  // Update
  async update(id: string, data: TUpdateDto): Promise<TDto> {
    await firstValueFrom(
      this.http.put<void>(`${this.apiUrl}/${id}`, data)
    );
    return await this.getById(id);
  }

  // Delete
  async delete(id: string): Promise<void> {
    await firstValueFrom(
      this.http.delete<void>(`${this.apiUrl}/${id}`)
    );
  }

  // Helper for DataGrid - returns DataSource with CustomStore
  createCustomStore(): DataSource {
    const self = this;

    const store = new CustomStore({
      key: 'id',
      load: (loadOptions: any) => {
        const pageSize = loadOptions.take || 50;
        const pageNumber = Math.floor((loadOptions.skip || 0) / pageSize) + 1;

        const filter: any = {
          pageNumber,
          pageSize,
          keyword: loadOptions.searchValue || '',
          orderBy: self.getOrderBy(loadOptions)
        };

        return self.search(filter).then(response => {
          return {
            data: response.data || [],
            totalCount: response.totalCount || 0
          };
        }).catch(error => {
          const errorMsg = error?.error?.exception || error?.error?.message || error?.message || 'Veri yuklenemedi';
          notify(errorMsg, 'error', 3000);
          return { data: [], totalCount: 0 };
        });
      },
      byKey: (key: string) => {
        return self.getById(key);
      }
    });

    return new DataSource({
      store: store,
      paginate: true,
      pageSize: 50
    });
  }

  protected getOrderBy(loadOptions: any): string[] {
    if (loadOptions.sort && loadOptions.sort.length > 0) {
      return loadOptions.sort.map((sortOption: any) =>
        `${sortOption.selector} ${sortOption.desc ? 'desc' : 'asc'}`
      );
    }
    return [];
  }
}
