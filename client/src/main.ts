import themes from 'devextreme/ui/themes';
import { enableProdMode } from '@angular/core';  
import { environment } from './environments/environment';
import { AppComponent } from './app/app.component';
import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app.config';

if (environment.production) {
  enableProdMode();
}

themes.initialized(() => {
  bootstrapApplication(AppComponent,appConfig)
    .catch((err) => console.error(err));

});

 
