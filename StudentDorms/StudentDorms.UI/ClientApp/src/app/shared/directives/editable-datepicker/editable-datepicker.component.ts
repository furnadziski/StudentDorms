import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-editable-datepicker',
  templateUrl: './editable-datepicker.component.html',
  styleUrls: ['./editable-datepicker.component.scss']
})
export class EditableDatepickerComponent implements OnInit {

  @Input() value: any;
  @Input() required: boolean = false;
  @Input() attributeName: string;
  @Input() rowId: string;
  @Input() min: any = null;
  @Input() max: any =  null;

  @Output() saveFn: EventEmitter<any> = new EventEmitter();
  @Output() cancelFn: EventEmitter<any> = new EventEmitter();

  previousValue: any;
  edit: boolean = false;

  ngOnInit(): void {
  }

  editValue(value: any) {
          this.previousValue = value;
          this.edit = true;
  }

  save(value: any) {
      var data = {
          value: value ? this.convert(value.toString()) : '',
          attributeName: this.attributeName,
          rowId: this.rowId
      };
      this.saveFn.emit(data);
      this.edit = false;
  }

  cancel() {
      this.value = this.previousValue;
      this.edit = false;
      this.cancelFn.emit("");
  }

  convert(str) {
      var date = new Date(str),
          mnth = ("0" + (date.getMonth() + 1)).slice(-2),
          day = ("0" + date.getDate()).slice(-2);
      return [date.getFullYear(), mnth, day].join("-");
  }
}
