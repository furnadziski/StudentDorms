import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditableMultipleSelectComponent } from './editable-multiple-select.component';

describe('EditableMultipleSelectComponent', () => {
  let component: EditableMultipleSelectComponent;
  let fixture: ComponentFixture<EditableMultipleSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditableMultipleSelectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditableMultipleSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
