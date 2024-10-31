import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentDormsListComponent } from './student-dorms-list.component';

describe('StudentDormsListComponent', () => {
  let component: StudentDormsListComponent;
  let fixture: ComponentFixture<StudentDormsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentDormsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentDormsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
