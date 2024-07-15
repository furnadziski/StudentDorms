import { Component, EventEmitter, Input, OnInit, Output, QueryList } from '@angular/core';
import { DropdownViewModel } from '../../models/dropdown-view-model';

@Component({
  selector: 'app-editable-select',
  templateUrl: './editable-select.component.html',
  styleUrls: ['./editable-select.component.scss'],
})
export class EditableSelectComponent implements OnInit {
  @Input() attributeName: string;
  @Input() required: boolean = false;
  @Input() label: string = '';
  @Input() value: any = {};

  @Input() options: QueryList<DropdownViewModel>;

  @Output() saveFn: EventEmitter<any> = new EventEmitter();
  @Output() cancelFn: EventEmitter<any> = new EventEmitter();

  private preValue: any = {};

  public editing: boolean = false;
  public viewValue: string = '';
  public onChange: any = Function.prototype;
  public preViewValue;

  ngOnInit(): void {
    this.value = this.value != null ? this.value : '';
    this.viewValue = this.value.title;
  }

  onSelectChange($event: any) {
    let id = $event.value.id;
    if (id && this.options.length > 0) {
      this.viewValue = $event.value.title;
    }
  }

  edit(value: any) {
    this.editing = true;
    this.preValue = value;
    if (value && this.options.length > 0) {
      this.preViewValue = value;
    }
    if (this.options.find((x) => x.title === this.value.title))
      this.value = this.options.find((x) => x.title === this.value.title);
  }

  cancel() {
    this.value = this.preValue;
    this.viewValue = this.preViewValue.title;
    this.editing = false;
  }

  save(value: any) {
    var data = {
      value: value.id,
      attributeName: this.attributeName,
    };

     if (this.options != null) {
      this.saveFn.emit(data);
      this.editing = false;
    }
  }
}
