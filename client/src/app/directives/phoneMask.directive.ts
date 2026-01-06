import { Directive, HostListener, ElementRef } from '@angular/core';

@Directive({
  selector: '[appPhoneMask]',
  standalone: true
})
export class PhoneMaskDirective {
  constructor(private el: ElementRef) {}

  // eslint-disable-next-line @typescript-eslint/member-ordering
  @HostListener('input', ['$event'])
  onInputChange(event: any) {
    const initialValue = this.el.nativeElement.value;
    const cursorPosition = event.target.selectionStart;  // İmleç pozisyonunu al

    this.el.nativeElement.value = this.formatPhoneNumber(initialValue);
    if (initialValue !== this.el.nativeElement.value) {
      event.stopPropagation();
    }

    event.target.selectionStart = cursorPosition;  // İmleç pozisyonunu koru
    event.target.selectionEnd = cursorPosition;
  }

  private formatPhoneNumber(value: string): string {
    value = value.replace(/\D/g, '');
    if (value.length > 13) {  // Uzun numaralar için sınırı 13'e çıkar
      value = value.substring(0, 13);
    }
    const areaCode = value.substring(0, 3);
    const middle = value.substring(3, 6);
    const last = value.substring(6, 10);
    return `${areaCode}${middle ? '-' + middle : ''}${last ? '-' + last : ''}`;
  }
}
