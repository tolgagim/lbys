import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ErrorService } from './error.service';
import { AppConfigService } from './app-config.service';



@Injectable({
  providedIn: 'root'
})
export class HttpService {

  isLoading: boolean = false;
  api: string;

  constructor(
    private http: HttpClient,
    private error: ErrorService
  ) {
    this.api = AppConfigService.settings.apiEndpoint.endpoint1 + '/api';
  }


  get<T>(apiUrl: string): Observable<T> {
    return this.http.get<T>(`${this.api}/${apiUrl}`).pipe(
      catchError((err: HttpErrorResponse) => {
        this.error.errorHandler(err);
        // Observable akışını sonlandırmak yerine belki alternatif bir değer göndermek daha iyi olabilir.
        return throwError(err); // RxJS'nin throwError fonksiyonunu kullanarak hata fırlatıyoruz.
      })
    );
  }

  post<T>(apiUrl: string, data: any, headers?: HttpHeaders): Observable<T> {
    this.isLoading = true;

    const options = headers ? { headers } : {};

    return this.http.post<T>(`${this.api}/${apiUrl}`, data, options).pipe(
      tap(response => {
        // console.log('API Response:', response);
        this.isLoading = false;
      }),
      catchError((err: HttpErrorResponse) => {
        console.error('HTTP Error:', err);
        this.isLoading = false;
        this.error.errorHandler(err);
        return throwError(() => err);
      })
    );
  }


  put<T>(apiUrl: string, data: any, headers?: HttpHeaders): Observable<HttpResponse<T>> {
    this.isLoading = true;
    const options = headers ? { headers, observe: 'response' as 'body' } : { observe: 'response' as 'body' };

    return this.http.put<HttpResponse<T>>(`${this.api}/${apiUrl}`, data, options).pipe(
      tap((response: HttpResponse<T>) => {
        this.isLoading = false; // Set loading to false on success
      }),
      catchError((err: HttpErrorResponse) => {
        this.isLoading = false; // Ensure loading is set to false on error
        this.error.errorHandler(err);
        return throwError(() => err);
      })
    );
  }


  delete<T>(apiUrl: string, headers?: HttpHeaders): Observable<T> {
    this.isLoading = true;
    const options = headers ? { headers } : {};

    return this.http.delete<T>(`${this.api}/${apiUrl}`, options).pipe(
      tap(() => this.isLoading = false),
      catchError((err: HttpErrorResponse) => {
        this.isLoading = false;
        this.error.errorHandler(err);
        return throwError(() => err);
      })
    );
  }


}
