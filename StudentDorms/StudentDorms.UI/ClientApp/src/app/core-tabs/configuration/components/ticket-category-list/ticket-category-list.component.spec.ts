import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketCategoryListComponent } from './ticket-category-list.component';

describe('TicketCategoryListComponent', () => {
  let component: TicketCategoryListComponent;
  let fixture: ComponentFixture<TicketCategoryListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TicketCategoryListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketCategoryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
