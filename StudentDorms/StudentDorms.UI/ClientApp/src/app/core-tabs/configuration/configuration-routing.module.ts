import { NgModule } from '@angular/core';

import { ConfigurationHomeComponent } from './components/configuration-home/configuration-home.component';
import { RouterModule, Routes } from '@angular/router';
import { StudentdormsComponent } from './components/student-dorms/student-dorms.component';
import { RegistersComponent } from './components/registers/registers.component';
import { MealsComponent } from '../meals/components/meals.component';
import { PaymentsComponent } from '../payments/components/payment-home/payments.component';
import { UsersListComponent } from './components/users-list/users-list.component';

const routes: Routes = [
  {
    path: '' , component : ConfigurationHomeComponent,
    children: [
      { path: '' , redirectTo:'users', pathMatch:'full' },
      { path: 'users' , component: UsersListComponent },
      { path: 'student-dorms' , component: StudentdormsComponent},
      { path: 'registers' , component: RegistersComponent},
       ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfigurationRoutingModule { }
