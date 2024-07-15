import { Component, EventEmitter, Input, OnInit, Output, QueryList, ViewChild } from '@angular/core';
import { DropdownViewModel } from '../../models/dropdown-view-model';

@Component({
  selector: 'app-editable-multiple-select',
  templateUrl: './editable-multiple-select.component.html',
  styleUrls: ['./editable-multiple-select.component.scss']
})
export class EditableMultipleSelectComponent implements OnInit {


  @Input() attributeName: string;
  @Input() required: boolean = false;
  @Input() label: string = '';
  @Input() arrayValue: any = [];

  @Input() options: QueryList<DropdownViewModel>;

  @Output() saveFn: EventEmitter<any> = new EventEmitter();
  @Output() cancelFn: EventEmitter<any> = new EventEmitter();
  selected:DropdownViewModel[];
  private preValue: any = {};
  options1: any = [];
  public editing: boolean = false;
  public viewValue: string = '';
  public onChange: any = Function.prototype;
  public preViewValue;
   public a:any[];


  ngOnInit(): void {
    this.arrayValue = this.arrayValue != null ? this.arrayValue : '';
    this.viewValue = this.arrayValue.map(item => item.title).join(', ');
  }
            
  onSelectChange($event: any) {
    const selectedIds = $event.value.map(item => item.id);
    if (selectedIds.length > 0 && this.options.length > 0) {
      const intersectingOptions = this.options.filter(option => selectedIds.includes(option.id));
      this.viewValue = intersectingOptions.map(option => option.title).join(', ');
    } else {
      this.viewValue = '';
    }
  }
  
  edit(arrayValue: any) {
    this.editing = true;
    this.preValue = arrayValue;
    if (arrayValue && this.options.length > 0) {
      this.preViewValue = arrayValue;
      
    }
    this.arrayValue=[];
    arrayValue.forEach(option => {
      this.options.forEach(value => {
       if(option.id===value.id){
        this.arrayValue.push(value);
       }
      });
    });
    
  }

  cancel() {
    this.arrayValue = this.preValue;
    this.viewValue = this.arrayValue.map(x => {
      const words = x.title.split(' ');
      return words.slice(0, 2).join(' ');
  }).join(', ');    this.editing = false;
  }
  onOpen($event:any){

  }
  save(arrayValue: any) {
    let listOfIds = []; 
    for(let i = 0; i < arrayValue.length; i++){
     listOfIds.push(arrayValue[i]);
    }
    console.log(listOfIds);
    var data = {
      value: listOfIds,
      attributeName: this.attributeName,
    };
     if (this.options != null) {
      this.saveFn.emit(data);
      this.editing = false;
    }
    this.viewValue = this.arrayValue.map(x => {
      const words = x.title.split(' ');
      return words.slice(0, 2).join(' ');
  }).join(', ');
  }

}


