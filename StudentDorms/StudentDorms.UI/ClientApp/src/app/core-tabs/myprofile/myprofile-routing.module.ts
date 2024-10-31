import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyprofileHomeComponent } from './components/myprofile-home.component';
import { MealsComponent } from '../meals/components/meals.component';
import { PaymentsComponent } from '../payments/components/payment-home/payments.component';
import { RegistersComponent } from '../configuration/components/registers/registers.component';
import { ConfigurationHomeComponent } from '../configuration/components/configuration-home/configuration-home.component';
import { TicketsComponent } from '../tickets/components/tickets/tickets.component';

const routes: Routes = [
  {
    path: '' , component : MyprofileHomeComponent,
    children: [
      { path: '' , redirectTo:'meals', pathMatch:'full' },
      { path: 'meals', component: MealsComponent},
      { path: 'payments', component: PaymentsComponent},
      { path: 'tickets', component: TicketsComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyprofileRoutingModule { }
