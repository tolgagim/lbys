import {
  Component,
  Input,
  ViewChild,
  Output,
  EventEmitter,
  HostListener,
  OnInit,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxButtonModule,
  DxToolbarModule,
  DxPopupModule,
  DxValidationGroupModule,
  DxValidationGroupComponent,
  DxLoadPanelModule,
} from 'devextreme-angular';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-form-popup',
  templateUrl: './form-popup.component.html',
  styleUrls: ['./form-popup.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    DxPopupModule,
    DxButtonModule,
    DxToolbarModule,
    DxValidationGroupModule,
    DxLoadPanelModule,
    TranslateModule
  ]
})
export class FormPopupComponent implements OnInit {
  @ViewChild('validationGroup', { static: false }) validationGroup!: DxValidationGroupComponent;

  // Loading & Display
  @Input() isLoading = false;
  @Input() fullwidth = false;
  @Input() titleText = '';
  @Input() width = 700;
  @Input() height: string | number = 550;
  @Input() visible = false;

  // Button Visibility
  @Input() showSaveButton = true;
  @Input() showCancelButton = true;
  @Input() showQuitButton = false;

  // Button Texts
  @Input() saveButtonText = 'Kaydet';
  @Input() cancelButtonText = 'Vazgec';
  @Input() quitButtonText = 'Cikis';

  // Behavior
  @Input() autoCloseOnSave = false;
  @Input() resizeEnabled = true;
  @Input() dragEnabled = true;
  @Input() showCloseButton = true;
  @Input() closeOnOutsideClick = false;

  // Events
  @Output() save = new EventEmitter();
  @Output() cancel = new EventEmitter();
  @Output() quit = new EventEmitter();
  @Output() visibleChange = new EventEmitter<boolean>();

  public windowWidth: number = window.innerWidth;

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.windowWidth = window.innerWidth;
  }

  constructor(private translate: TranslateService) {
    this.windowWidth = window.innerWidth;
  }

  ngOnInit(): void {
    this.onResize(null);
  }

  isValid(): boolean {
    if (!this.validationGroup) return true;
    return this.validationGroup.instance.validate().isValid;
  }

  onSaveClick(): void {
    if (!this.isValid()) {
      return;
    }
    this.save.emit();
    if (this.autoCloseOnSave) {
      this.close();
    }
  }

  onCancelClick(): void {
    this.cancel.emit();
    this.close();
  }

  onQuitClick(): void {
    this.quit.emit();
    this.visible = false;
    this.visibleChange.emit(false);
  }

  close(): void {
    this.visible = false;
    this.visibleChange.emit(false);
    if (this.validationGroup) {
      this.validationGroup.instance.reset();
    }
  }

  get responsiveWidth(): number | string {
    if (this.fullwidth) {
      return '100%';
    }
    const maxWidth = Math.min(this.windowWidth * 0.9, this.width);
    if (this.windowWidth <= 480) {
      return Math.max(480, this.windowWidth * 0.95);
    }
    return Math.max(480, maxWidth);
  }

  get responsiveHeight(): number | string {
    if (this.fullwidth) {
      return '100%';
    }
    if (typeof this.height === 'string') {
      return this.height;
    }
    if (this.windowWidth <= 768) {
      return Math.min(this.height, window.innerHeight * 0.9);
    }
    return this.height;
  }

  get isSmallScreen(): boolean {
    return this.windowWidth <= 576;
  }

  get loadingMessage(): string {
    return 'Yukleniyor...';
  }
}
