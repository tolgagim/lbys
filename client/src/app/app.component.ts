import { Component, HostBinding, HostListener, OnDestroy, } from '@angular/core';
import { AppInfoService, AuthService, ScreenService, ThemeService } from './services'; 
import { RouterOutlet } from '@angular/router';
import { CommonService } from './services/common.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-root',
    template: `
    @if(common.showLoading){
      <div style="background-color: #071635; width: 100%; height: 100vh; display: flex; align-items: center; justify-content: center;" class="text-center">
      <img src="assets/lognetloading.gif" style="max-width: 90%; max-height: 90%; margin: auto;">
  </div>

    }@else{
      <router-outlet></router-outlet>
    }`,
    styleUrls: ['./app.component.scss'],
    standalone: true,
    imports: [RouterOutlet],
})
 
export class AppComponent implements OnDestroy {
  @HostBinding('class') get getClass() {
    return Object.keys(this.screen.sizes).filter((cl) => this.screen.sizes[cl]).join(' ');
  }

  @HostListener('window:beforeunload', ['$event']) notify($event:any) {
    const confirmationMessage = 'sayfa yenilensin mi? Yaptığınız değişiklikler kaydedilmeyebilir.';
    $event.returnValue = confirmationMessage;
    return false;
  }

  constructor(private authService: AuthService,
    themeService: ThemeService,
    private screen: ScreenService,
    public appInfo: AppInfoService,
    public common: CommonService,
    private translate: TranslateService    
  ) {
    setTimeout(() => {
      this.common.showLoading = false;
    }, 1000);

    themeService.setAppTheme();

    this.translate.addLangs(["tr", "en"]);
    const savedLang = localStorage.getItem("lang") || 'tr';
    // this.translate.use(savedLang).subscribe(() => {
    //   console.log(`Language set to: ${savedLang}`);
    // });
  }

  isAuthenticated() { 
    return this.authService.loggedIn;
  }

  ngOnDestroy(): void { 
    this.screen.breakpointSubscription.unsubscribe();
  }
}