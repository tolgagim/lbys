 
import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { PermissionsService } from '../services';

@Directive({
    selector: '[hasRole]',
    standalone: true
  })
  export class HasRoleDirective {
    private currentUserRole: string[] = [];
    private permissionsLoaded: boolean = false; // Flag to check if permissions are loaded
    private currentRole: string;
    constructor(
      private permissionsService: PermissionsService,
      private templateRef: TemplateRef<any>,
      private viewContainer: ViewContainerRef
    ) {
      this.initializePermissions();
    }
  

    
    async initializePermissions() {
      try {
        this.currentUserRole = await this.permissionsService.getPermissions();
        this.permissionsLoaded = true; // Set the flag to true after loading permissions
        this.updateView(); // Call to update view once permissions are loaded
      } catch (error) {
        console.error('Error initializing permissions:', error);
        this.permissionsLoaded = false;
      }
    }
 
    
  
    @Input() set hasRole(role: string) {
      this.currentRole = role;
      this.updateView();
    }
  
    private updateView() {
      if (!this.permissionsLoaded) return; // Do nothing if permissions aren't loaded yet
  
      if (this.currentUserRole && this.currentUserRole.find(p => p === this.currentRole)) {
        this.viewContainer.createEmbeddedView(this.templateRef);
      } else {
        this.viewContainer.clear();
      }
    }
  }