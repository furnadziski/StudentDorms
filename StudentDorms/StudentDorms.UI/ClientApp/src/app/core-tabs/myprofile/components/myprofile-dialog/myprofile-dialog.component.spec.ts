import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyprofileDialogComponent } from './myprofile-dialog.component';

describe('MyprofileDialogComponent', () => {
  let component: MyprofileDialogComponent;
  let fixture: ComponentFixture<MyprofileDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyprofileDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyprofileDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
