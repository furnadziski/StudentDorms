import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyprofileHomeComponent } from './myprofile-home.component';

describe('MyprofileHomeComponent', () => {
  let component: MyprofileHomeComponent;
  let fixture: ComponentFixture<MyprofileHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyprofileHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyprofileHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
