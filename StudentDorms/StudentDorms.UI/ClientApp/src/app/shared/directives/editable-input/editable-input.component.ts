import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-editable-input',
  templateUrl: './editable-input.component.html',
  styleUrls: ['./editable-input.component.scss'],
})
export class EditableInputComponent implements OnInit {
  @Input() value: any;
  @Input() inputType: string = 'text';
  @Input() attributeName: string;
  @Input() required: boolean = false;
  @Input() disabled: boolean = false;
  @Input() rowId: string = '';
  @Input() min: number = 0;
  @Input() max: number = 10000000;

  @Output() saveFn: EventEmitter<any> = new EventEmitter();
  @Output() cancelFn: EventEmitter<any> = new EventEmitter();

  previousValue: any;
  edit: boolean = false;

  constructor() {}

  ngOnInit(): void {
    if (this.inputType == 'number') this.inputType = 'number';
    if (this.inputType == 'String') this.inputType = 'text';
  }


  editValue(value: any) {
    this.previousValue = value;
    this.edit = true;
  }

  save(value: any) {
    var data = {
      value: value,
      attributeName: this.attributeName,
      rowId : this.rowId
    };
    this.saveFn.emit(data);
    this.edit = false;
  }

  cancel() {
    this.value = this.previousValue;
    this.edit = false;
    this.cancelFn.emit('');
  }
}
