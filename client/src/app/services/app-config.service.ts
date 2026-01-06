import { Injectable } from "@angular/core";
import { IAppConfig } from "../models/IAppConfig";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
  static settings: IAppConfig;

  constructor(private httpClient: HttpClient) { }

  loadConfigurations(): Promise<void> {
    const configFile = 'assets/config/appconfig.json';

    return new Promise<void>((resolve, reject) => {
      this.httpClient.get<IAppConfig>(configFile).subscribe({
        next: (configs: IAppConfig) => {
          AppConfigService.settings = configs;
          console.log(AppConfigService.settings);
          resolve();
        },
        error: (err) => {
          console.error("Failed to load configuration file", err);
          reject(err);
        }
      });
    });
  }
}
