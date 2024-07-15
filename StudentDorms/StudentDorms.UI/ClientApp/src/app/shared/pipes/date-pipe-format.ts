import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'customDateFormat'
})
export class CustomDateFormatPipe implements PipeTransform {
  transform(value: string, format: string = 'dd/MM/yyyy'): string {
    if (!value) return '';
    const datePipe = new DatePipe('en-US');
    const date = new Date(value);
    return datePipe.transform(date, format);
  }
}
