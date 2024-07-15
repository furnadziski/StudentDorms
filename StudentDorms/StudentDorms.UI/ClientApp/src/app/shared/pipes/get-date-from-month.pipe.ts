import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'getDateFromMonth'
})
export class GetDateFromMonthPipe implements PipeTransform {

  transform(value: any): string {
    if (!value) {
        return null;
    }
    const monthNames = ["January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"];
    
    const monthIndex = value.getMonth();
    
    return monthNames[monthIndex];
  }
}
