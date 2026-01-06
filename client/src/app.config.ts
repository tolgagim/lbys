import { APP_INITIALIZER, ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { HttpClient, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import config from 'devextreme/core/config';
import { BrowserModule } from '@angular/platform-browser';
import { routes } from './app/app-routing.module';
import { AppInfoService, AuthGuardService, AuthService, ScreenService, ThemeService } from './app/services';
import { authInterceptor } from './app/interceptors/auth.interceptor';
import { AppConfigService } from './app/services/app-config.service';

config({
  licenseKey: 'ewogICJmb3JtYXQiOiAxLAogICJjdXN0b21lcklkIjogImEwNjI0NDFiLWFiODUtMTFlNC04MGMyLTAwMjU5MGQ5ZDVmZiIsCiAgIm1heFZlcnNpb25BbGxvd2VkIjogMjMyCn0=.n3GgZxkDQwtgg01Gg8o5ZT0nxELOYRQAtN9Hr6QBbE6RdZJ8LhndXV8eHyoVX67j2OkM6GXW8hx7P/CKIKdRSwy30RYj7FbLwR2mSYxIFG4Zo4GX7DZWD8Rlvmu+AX8tJkHEeA=='
});


export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient, './assets/i18n/', '.json');
} 

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    importProvidersFrom(BrowserModule),
    importProvidersFrom(HttpClientModule),
    {
      provide: APP_INITIALIZER,
      useFactory: (appConfigService: AppConfigService) => {
        return () => appConfigService.loadConfigurations();
      },
      deps: [AppConfigService],
      multi: true
    },
    AuthService, ScreenService, AppInfoService, ThemeService, AuthGuardService,
    provideHttpClient(withInterceptors([authInterceptor])),
    importProvidersFrom([
      TranslateModule.forRoot({
        loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
        },
        defaultLanguage: "tr"
      })
    ])
  ]
};
