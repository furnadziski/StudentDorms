import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentdormsComponent } from './student-dorms.component';

describe('StudentdormsComponent', () => {
  let component: StudentdormsComponent;
  let fixture: ComponentFixture<StudentdormsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentdormsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentdormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
