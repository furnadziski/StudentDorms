import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PaymentsRoutingModule } from './payments-routing.module';
import { PaymentsComponent } from './components/payment-home/payments.component';
import { PaymentService } from './services/payment.service';


@NgModule({
  declarations: [
    PaymentsComponent
    
  ],
  imports: [
    CommonModule,
    PaymentsRoutingModule
  ],
  providers: [
    PaymentService
  ]
})
export class PaymentsModule { }