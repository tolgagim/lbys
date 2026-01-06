import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class EncryptionService {
  private secretKey = 'c%12#73302f23c43f3@88?90a45abbb0aa34*'; // Güçlü ve güvenli bir anahtar kullanın

  constructor() { }

  // Veriyi şifreleyin ve şifrelenmiş veriyi döndürün
  encryptData(data: any): string {
    const dataString = JSON.stringify(data);
    const encryptedData = CryptoJS.AES.encrypt(dataString, this.secretKey).toString();
    return encryptedData;
  }

  // Şifrelenmiş veriyi alın, şifresini çözün ve orijinal veriyi döndürün
  decryptData(encryptedData: string): any {
    const bytes = CryptoJS.AES.decrypt(encryptedData, this.secretKey);
    const decryptedData = JSON.parse(bytes.toString(CryptoJS.enc.Utf8));
    return decryptedData;
  }
}
