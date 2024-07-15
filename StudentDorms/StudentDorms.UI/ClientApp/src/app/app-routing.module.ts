import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnAuthorizedComponent } from './shared/error-handlers/un-authorized.component';

const routes: Routes = [

  { path: '', redirectTo: 'configuration', pathMatch: 'full' },
  {
    path: 'dashboard',
    loadChildren: () => import('./core-tabs/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path:'food',
    loadChildren: () => import('./core-tabs/food/food.module').then(m => m.FoodModule)
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
