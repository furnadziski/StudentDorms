import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketsHomeComponent } from './tickets.component';

describe('TicketsHomeComponent', () => {
  let component: TicketsHomeComponent;
  let fixture: ComponentFixture<TicketsHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketsHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketsHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
