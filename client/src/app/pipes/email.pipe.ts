import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'EmailPipe',
  standalone: true,
})
export class EmailPipe implements PipeTransform {
  transform(value: string): boolean {
    if (!value) return false;
    const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    return regex.test(value);
  }
}
