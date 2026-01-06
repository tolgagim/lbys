import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import notify from 'devextreme/ui/notify';
import { Message } from '../types/messages';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private translate: TranslateService,
    private router: Router
  ) { }

  errorHandler(err: HttpErrorResponse) {
    let errorMessage: string = "";

    switch (err.status) {
      case 200:
        errorMessage = this.translate.instant(err.error.text);
        notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'success');
        break;
      case 0:
        errorMessage = this.translate.instant("Error.APIIsNotAvaliable");
        notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
        break;
      case 400:
        
        if (Array.isArray(err.error.errorMessages)) {
          for (let message of err.error.errorMessages) {
            errorMessage = this.translate.instant(message);
            notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
          }
        }
        else  if (Array.isArray(err.error.messages)) {
          for (let message of err.error.messages) {
            errorMessage = this.translate.instant(message);
            notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
          }
        }
        break;
      case 401:
        errorMessage = this.translate.instant("Error.OnAuthorized");
        notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
        this.router.navigateByUrl("/login");
        break;
      case 409:
        if (Array.isArray(err.error.messages)) {
          for (let message of err.error.messages) {
            errorMessage = this.translate.instant(message);
            notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
          }
        }
        break;
      case 404:
        errorMessage = this.translate.instant("Error.APINotFound");
        notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
        break;
      case 422:
        if (Array.isArray(err.error.Errors)) {
          for (let e of err.error.Errors) {
            errorMessage = this.translate.instant(e);
            notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
          }
        }
        break;
      case 500:
        if (Array.isArray(err.error.messages)) {
          for (let message of err.error.messages) {
            errorMessage = this.translate.instant(message);
            notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
          }
        } else if (err.error.message) {
          errorMessage = this.translate.instant(err.error.message);
          notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
        }
        break;
      default:
        errorMessage = err.message;
        notify({ message: errorMessage, position: { at: 'bottom center', my: 'bottom center' } }, 'error');
        break;
    }
  }
}