import { Injectable } from '@angular/core';
import { EncryptionService } from './encryption.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionsService {
  private permissions: Set<string> = new Set<string>();

  constructor(private encryptionService: EncryptionService) {
   
  }
 

  async getPermissions(): Promise<string[]> {
    try {
      if (localStorage.getItem('permissions')) {
        const encrypt = localStorage.getItem('permissions');
        var data = this.encryptionService.decryptData(encrypt);
        return data;
      }
    } catch (error) {
      console.error('Error fetching user permissions:', error);
      throw error;
    }
  }

  async loadPermissions() {
    this.permissions= new Set<string>();
    var permissions = await this.getPermissions();
    permissions.forEach(permission => {
      this.permissions.add(permission);
    });
  }

  hasPermission(permission: string): boolean {
    return this.permissions.has(permission);
  }
}
