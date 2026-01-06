import { HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EncryptionService } from '../services/encryption.service';
 

// Örnek bir HttpHandlerFn tip tanımı
export type HttpHandlerFn = (req: HttpRequest<any>) => Observable<HttpEvent<any>>;

// HttpInterceptorFn tipi, HttpRequest ve HttpHandlerFn alıp, Observable<HttpEvent<any>> döndürmelidir
export type HttpInterceptorFn = (req: HttpRequest<any>, next: HttpHandlerFn) => Observable<HttpEvent<any>>;

// EncryptionService örneği yarat
const encryptionService = new EncryptionService();

// Fonksiyonel interceptor tanımı
export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const storedEncryptedProfile = localStorage.getItem('authToken'); 
  if (storedEncryptedProfile) {
    const authToken = encryptionService.decryptData(storedEncryptedProfile);  
    const cloneReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${authToken.replace(/"/g, '')}`)
    });
    return next(cloneReq);
  }
  return next(req);
};
