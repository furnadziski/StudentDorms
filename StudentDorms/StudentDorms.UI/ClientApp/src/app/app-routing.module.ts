import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnAuthorizedComponent } from './shared/error-handlers/un-authorized.component';

const routes: Routes = [

  { path: '', redirectTo: 'config', pathMatch: 'full' },
  {
    path: 'dashboard',
    loadChildren: () => import('./core-tabs/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path:'food',
    loadChildren: () => import('./core-tabs/food/food.module').then(m => m.FoodModule)
  },

  {
    path:'configuration',
    loadChildren: () => import('./core-tabs/configuration/configuration.module').then(m => m.ConfigurationModule)
  },
  {
    path:'tickets',
    loadChildren: () => import('./core-tabs/tickets/tickets.module').then(m => m.TicketsModule)
  },
  {
    path:'payments',
    loadChildren: () => import('./core-tabs/payments/payments.module').then(m => m.PaymentsModule)
  },
  {
    path:'myprofile',
    loadChildren: () => import('./core-tabs/myprofile/myprofile.module').then(m => m.MyprofileModule)
  },
  {
    path:'meals',
    loadChildren: () => import('./core-tabs/meals/meals.module').then(m => m.MealsModule)
  },
  {
    path:'accommodation',
    loadChildren: () => import('./core-tabs/accommodation/accommodation.module').then(m => m.AccommodationModule)
  },

  {
    path:'un-authorized',
    component: UnAuthorizedComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
