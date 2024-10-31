import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentDormDialogComponent } from './student-dorm-dialog.component';

describe('StudentDormDialogComponent', () => {
  let component: StudentDormDialogComponent;
  let fixture: ComponentFixture<StudentDormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentDormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentDormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
