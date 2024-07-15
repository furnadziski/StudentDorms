import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'getDateFromYear'
})
export class GetDateFromYearPipe implements PipeTransform {

  transform(value: any): number {
    if (!!!value) {
        return null;
    }
    var dt = value.getFullYear();
    return dt;
}

}
