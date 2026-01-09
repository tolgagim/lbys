import { Component, ViewChild, OnInit, OnDestroy, AfterViewInit, ChangeDetectorRef, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { DxTreeViewComponent, DxTreeViewModule, DxTreeViewTypes } from 'devextreme-angular/ui/tree-view';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from 'src/app/services/auth.service';
import { Subscription } from 'rxjs';
import { navigation } from '../../../app-navigation';
import * as events from 'devextreme/events'; 
import { PermissionsService } from 'src/app/services';
@Component({
  selector: 'side-navigation-menu',
  templateUrl: './side-navigation-menu.component.html',
  styleUrls: ['./side-navigation-menu.component.scss'],
  standalone: true,
  imports: [DxTreeViewModule],
})
export class SideNavigationMenuComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild(DxTreeViewComponent, { static: true }) menu!: DxTreeViewComponent;

  @Output() selectedItemChanged = new EventEmitter<DxTreeViewTypes.ItemClickEvent>();
  @Output() openMenu = new EventEmitter<any>();

  private _selectedItem!: String;
  public _items: any[] = [];
  private _compactMode = false;
  private langChangeSubscription!: Subscription;

  @Input()
  get compactMode(): boolean {
    return this._compactMode;
  }

  set compactMode(value: boolean) {
    this._compactFeedback(value);
  }

  get selectedItem(): String {
    return this._selectedItem;
  }
  
  

  @Input()
  set selectedItem(value: String) {
    this._selectedItem = value;
    this.setSelectedItem();
  }

  constructor(
    private elementRef: ElementRef,
    private translate: TranslateService, 
    private authService: AuthService,
    private cdr: ChangeDetectorRef,
    private permissionsService: PermissionsService
    ) {
      this.permissionsService.loadPermissions();
    }

    ngOnInit() { 
      this.langChangeSubscription = this.translate.onLangChange.subscribe(() => {
        this.loadItems();
      });
      this.loadItems();
     
    }

   
  
   
    loadItems() {
      Promise.all(navigation.map(item => this.translateItem(item))).then(translatedItems => {
        this._items = translatedItems.filter(item => item != null);  
        this.updateMenuItems();
      });
    }
    

   
    translateItem(item: any): Promise<any> {
      return this.translate.get(item.text).toPromise().then(translatedText => {
        // Ana öğe için permission kontrolü
        if (item.permission && !this.permissionsService.hasPermission(item.permission)) {
          return null;
        }
    
        let newItem = { ...item, text: translatedText };
        let filteredSubItems = [];
    
        // Alt öğeler varsa ve permission kontrolünden geçtiyse
        if (item.items && item.items.length > 0) {
          for (let i = 0; i < item.items.length; i++) {
            let subItem = item.items[i];
            // Alt öğe için permission kontrolü - permission yoksa veya izin varsa ekle
            if (!subItem.permission || this.permissionsService.hasPermission(subItem.permission)) {
              filteredSubItems.push(subItem);
            }
          }
    
          // Alt öğeleri kontrol et, eğer hiçbiri izinli değilse ana öğeyi de gizle
          if (filteredSubItems.length === 0) {
            return null;
          }
    
          // Rekürsif işlem için translateItem çağrısı ve sonuçların işlenmesi
          return Promise.all(filteredSubItems.map(subItem => this.translateItem(subItem)))
            .then(translatedSubItems => {
              // Tüm çevrilen alt öğeleri newItem'a ata
              newItem.items = translatedSubItems.filter(subItem => subItem != null);
              return newItem;
            });
        }
    
        return newItem;
      });
    }
    
    

 

    updateMenuItems() {
      if (this.menu.instance) {
        this.menu.instance.option('items', this._items);
        this.menu.instance.repaint();
      }
      this.cdr.detectChanges();
    }
    
    
    
     
  
   
  setSelectedItem() {
    if (this.menu.instance) {
      this.menu.instance.selectItem(this.selectedItem);
    }
  }

  onItemClick(event: DxTreeViewTypes.ItemClickEvent) {
    this.selectedItemChanged.emit(event);
  }


  
  ngAfterViewInit() {
    this.setSelectedItem();
    events.on(this.elementRef.nativeElement, 'dxclick', (e: Event) => {
      this.openMenu.next(e);
    });
  }

  ngOnDestroy() {
    events.off(this.elementRef.nativeElement, 'dxclick');
  }

  _compactFeedback(value: boolean) {
    this._compactMode = value;
    if (this.menu.instance) {
      if (value) {
        this.menu.instance.collapseAll();
      } else {
        this.menu.instance.expandItem(this.selectedItem);
      }
    }
  } 

}
