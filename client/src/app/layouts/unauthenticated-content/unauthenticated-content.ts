import { CommonModule } from '@angular/common';
import { Component, NgModule } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';

import { Router } from '@angular/router';
import { SingleCardComponent } from '../single-card/single-card.component';

@Component({
    selector: 'app-unauthenticated-content',
    template: `
    <app-single-card [title]="title" [description]="description">
      <router-outlet></router-outlet>
    </app-single-card>
  `,
    styles: [`
    :host {
      width: 100%;
      height: 100%;
    }
  `],
    standalone: true,
    imports: [SingleCardComponent, RouterOutlet],
})
export class UnauthenticatedContentComponent {
  constructor(private router: Router) { }

  get description() {
    const path = this.router.url.split('/').at(-1);
    switch (path) {
      case 'reset-password': return 'Lütfen kaydolurken kullandığınız e-posta adresini girin; size e-posta yoluyla şifrenizi sıfırlamanız için bir bağlantı göndereceğiz.';
      default: return '';
    }
  }

  get title() {
    const path = this.router.url.split('/').at(-1);
    switch (path) {
      case 'login': return 'Kullanıcı Girişi';
      case 'reset-password': return 'Sifre Sıfırlama';
      case 'create-account': return 'Kayıt Ol';
      case 'change-password': return 'Şifre Değiştir';
      default: return '';
    }
  }
}

