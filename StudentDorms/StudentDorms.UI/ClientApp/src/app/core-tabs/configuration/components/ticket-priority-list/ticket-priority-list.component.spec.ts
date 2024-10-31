import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketPriorityListComponent } from './ticket-priority-list.component';

describe('TicketPriorityListComponent', () => {
  let component: TicketPriorityListComponent;
  let fixture: ComponentFixture<TicketPriorityListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketPriorityListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketPriorityListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
