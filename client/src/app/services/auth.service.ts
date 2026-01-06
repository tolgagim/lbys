import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { HttpService } from './http.service';
import { jwtDecode } from 'jwt-decode';
import { AuthModel } from '../models/auth.model';
import notify from 'devextreme/ui/notify';
import { TranslateService } from '@ngx-translate/core';
import { BehaviorSubject } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { UserDetailsDto } from '../models/user/userDetailsDto';
import { EncryptionService } from './encryption.service';
import { firstValueFrom } from 'rxjs';
import { TokenResponse } from '../models/tokenResponse';
import { Actions } from '../models/permission/actions';
import { AppConfigService } from './app-config.service';

export interface IResponse {
  isOk: boolean;
  data?: UserDetailsDto;
  message?: string;
}
const defaultPath = '/';

@Injectable()
export class AuthService {
  private languageSubject = new BehaviorSubject<string>('tr');
  language$ = this.languageSubject.asObservable();

  private _user: UserDetailsDto;
  authModel: AuthModel = new AuthModel();

  get loggedIn(): boolean {

    if (localStorage.getItem('userProfile')) {
      return true;
    }
    return false;
  }

  // get loggedIn(): boolean {
  //   return !!this._user;
  // }

  private _lastAuthenticatedPath: string = defaultPath;

  set lastAuthenticatedPath(value: string) {
    this._lastAuthenticatedPath = value;
  }

  constructor(
    private router: Router,
    private http: HttpService,
    private translate: TranslateService,
    private encryptionService: EncryptionService
  ) {
    const savedLang = localStorage.getItem('lang') || 'tr';
    this.setLanguage(savedLang);
  }

  getLanguage(): string {
    return this.languageSubject.value;
  }

  setLanguage(lang: string) {
    localStorage.setItem('lang', lang);
    this.translate.use(lang).subscribe(() => {
      this.languageSubject.next(lang);
    });
  }



  async logIn(email: string, password: string): Promise<{ isOk: boolean, data?: any, message?: string }> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'tenant': 'root'
    });
    const authModel = { email, password };

    try {
      const res = await firstValueFrom(this.http.post<TokenResponse>('tokens', authModel, headers));
      const encrypted = this.encryptionService.encryptData(res.token);
      localStorage.setItem('authToken', encrypted);
      localStorage.setItem('refreshToken', JSON.stringify(res.refreshToken));

      await this.setPermissions();
      this._user = await this.setUserProfile();


      const decodedToken = jwtDecode(res.token) as any;  // Token'ı decode et
      const nameIdentifier = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
      const encryptedUserId = this.encryptionService.encryptData(nameIdentifier);
      localStorage.setItem('userId', encryptedUserId);

      const message: string = this.translate.instant("Success.LoginIsSuccessful");
      notify({ message: message, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
      // this.router.navigate([this._lastAuthenticatedPath]); 
      this.router.navigate([this._lastAuthenticatedPath]);
      // this.router.navigate(['/home']);
      return {
        isOk: true,
        data: this._user
      };
    } catch (error) {
      console.error("login error:", error.message);
      return {
        isOk: false,
        message: 'Authentication failed: ' + error.message
      };
    }
  }


  async getPermissions(): Promise<string[]> {
    try {
      if (localStorage.getItem('permissions')) {
        const encrypt = localStorage.getItem('permissions');
        return this.encryptionService.decryptData(encrypt);
      }
    } catch (error) {
      console.error('Error fetching user permissions:', error);
      throw error;
    }
  }

  async setPermissions(): Promise<string[]> {
    try {
      const res = await firstValueFrom(this.http.get<string[]>('personal/permissions'));
      const encrypted = this.encryptionService.encryptData(res);
      localStorage.setItem('permissions', encrypted);
      return res;
    } catch (error) {
      console.error('Error fetching user permissions:', error);
      throw error;
    }
  }


  async getUserProfile(): Promise<UserDetailsDto> {
    try {
      if (localStorage.getItem('userProfile')) {
        const encrypt = localStorage.getItem('userProfile');
        var data = this.encryptionService.decryptData(encrypt);
        return data;
      }
    } catch (error) {
      console.error('Error fetching user userProfile:', error);
      throw error;
    }
  }

  async setUserProfile(): Promise<UserDetailsDto> {
    try {
      const res = await firstValueFrom(this.http.get<UserDetailsDto>('personal/profile'));
      if (res.imageUrl == null) {
        res.imageUrl = '../../../../assets/images/no-user-image.gif';
      }
      else {
        res.imageUrl = AppConfigService.settings.apiEndpoint.endpoint1 + "/" + res.imageUrl;
      }
      const encrypted = this.encryptionService.encryptData(res);
      localStorage.setItem('userProfile', encrypted);
      return res;
    } catch (error) {
      console.error('Error fetching user profile:', error);
      throw error;
    }
  }


  isPageAuthenticated() {
    if (localStorage.getItem("authToken")) {
      const tokenEncrypted = localStorage.getItem('authToken');
      const token = this.encryptionService.decryptData(tokenEncrypted);
      const tokenString: any = token;
      const decode: any = jwtDecode(tokenString);
      const date = new Date().getTime() / 1000;
      if (decode.exp < date) {
        this.router.navigate(['/auth/login']);
      }
      return true;
    } else {
      this.router.navigate(['/auth/login']);
      return false;
    }
  }


  async getUser() {
    try {
      if (localStorage.getItem("authToken")) {
        const tokenEncrypted = localStorage.getItem('authToken');
        const token = this.encryptionService.decryptData(tokenEncrypted);
        const tokenString: any = token;
        const decode: any = jwtDecode(tokenString);
        const date = new Date().getTime() / 1000;
        if (decode.exp < date) {
          this.router.navigate(['/auth/login']);
        }
        this._user = await this.getUserProfile();
      }
      return {
        isOk: true,
        data: this._user,
      };
    } catch (error) {
      console.error("Error in getUser:", error.message);
      return {
        isOk: false,
        data: null,
      };
    }
  }

  async createAccount(email: string, password: string) {
    try {
      this.router.navigate(['/create-account']);
      return {
        isOk: true,
      };
    } catch {
      return {
        isOk: false,
        message: 'Failed to create account',
      };
    }
  }

  async changePassword(email: string, recoveryCode: string) {
    try {
      return {
        isOk: true,
      };
    } catch {
      return {
        isOk: false,
        message: 'Failed to change password',
      };
    }
  }

  async resetPassword(email: string) {
    try {
      return {
        isOk: true,
      };
    } catch {
      return {
        isOk: false,
        message: 'Failed to reset password',
      };
    }
  }

  async logOut() {
    localStorage.removeItem("authToken");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("userProfile");
    localStorage.removeItem("permissions");
    localStorage.removeItem("userId");
    localStorage.removeItem("userId");
    this.router.navigate(['/auth/login']);
  }

  // async hasPermission(permission: string): Promise<boolean> {
  //   let permissions = this.getPermissions(); // Kullanıcının yetkilerini döndüren bir metot
  //   return (await permissions).includes(permission);
  // }

  async hasPermission(permission: string): Promise<boolean> {
    let permissions = await this.getPermissions(); // Kullanıcının yetkilerini çekiyoruz.
    permission = permission.charAt(0).toUpperCase() + permission.slice(1).toLowerCase(); // İlk harfi büyük, diğerlerini küçük yapma 
    var yetki = 'Permissions.' + permission + '.' + Actions.View;
    var sonuc = permissions.includes(yetki);
    if (!sonuc) {
      const methodToCheck = permission.toLowerCase(); // Aramak istediğimiz metodun küçük harfe çevrilmiş hali 
      // Actions içindeki tüm değerleri küçük harfe çevirerek kontrol edelim
      const isMethodPresent = Object.values(Actions).map(value => value.toLowerCase()).includes(methodToCheck);
      if (isMethodPresent) {
        sonuc = true;
      }
    }
    return sonuc;
  }
}

@Injectable()
export class AuthGuardService implements CanActivate {
  responseModel: UserDetailsDto;

  constructor(private router: Router, private authService: AuthService, private encryptionService: EncryptionService) { }


  async canActivate(route: ActivatedRouteSnapshot): Promise<boolean> {
    const defaultPath = '/';

    const routePath = route.routeConfig?.path || defaultPath;
    const isLoggedIn = this.authService.loggedIn;

    const isAuthForm = [
      'login',
      'reset-password',
      'create-account',
      'change-password/:recoveryCode',
    ].includes(routePath);

    if (routePath !== 'home') {
      if (!isAuthForm && await this.authService.hasPermission(routePath) === false) {
        // Eğer gerekli yetki yoksa kullanıcıyı ana sayfaya yönlendir.

        notify({ message: 'Access denied.', position: { at: 'bottom center', my: 'bottom center' } }, 'error');
        this.router.navigate(['/home']);
        return isLoggedIn || isAuthForm;
      }

    }

    if (isLoggedIn) {
      this.authService.lastAuthenticatedPath = routePath; // Son geçerli oturum açma yolu güncelleniyor. 
    }

    return isLoggedIn || isAuthForm;
  }
}
