import {
  Component,
  EventEmitter,
  Input,
  Output, 
  ViewChild,
} from '@angular/core';
import {
  DxSelectBoxModule,
  DxTextBoxModule,
  DxValidatorComponent,
  DxValidatorModule
} from 'devextreme-angular';
import { ValidationRule, EditorStyle } from 'devextreme-angular/common';




@Component({
    selector: 'password-text-box',
    templateUrl: 'password-text-box.component.html',
    styles: [],
    standalone: true,
    imports: [
        DxTextBoxModule,
        DxSelectBoxModule,
        DxValidatorModule,
    ],
})
export class PasswordTextBoxComponent {
  @ViewChild('validator', { static: true }) validator: DxValidatorComponent;

  @Input() value: string;

  @Input() placeholder = '';

  @Input() stylingMode: EditorStyle = 'outlined';

  @Input() validators: ValidationRule[] = [];

  @Output() valueChange = new EventEmitter<string>();

  @Output() valueChanged = new EventEmitter<string>();

  isPasswordMode = true;

  constructor() {
  }

  switchMode = () => {
    this.isPasswordMode = !this.isPasswordMode;
  }

  onValueChange(value) {
    this.value = value;
    this.valueChange.emit(value);
    this.valueChanged.emit(value);
  }

  revalidate() {
    this.validator?.instance.validate();
  }
}


