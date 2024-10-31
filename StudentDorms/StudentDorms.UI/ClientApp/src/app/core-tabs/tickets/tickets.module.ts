import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TicketsComponent } from './components/tickets/tickets.component';
import { TicketService } from './services/ticket.service';
import { TicketsRoutingModule } from './tickets-routing.module';




@NgModule({
  declarations: [
    TicketsComponent
    
  ],
  imports: [
    CommonModule,
    TicketsRoutingModule
  ],
  providers: [
    TicketService
  ]
})
export class TicketsModule { }
