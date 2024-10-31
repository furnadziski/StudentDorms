import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccommodationListComponent } from './components/accommodation-list/accommodation-list.component';
import { AccommodationHomeComponent } from './components/accommodation-home/accommodation-home.component';
const routes: Routes = [
  {
    path: '' , component : AccommodationListComponent,
    children:[
          { path: 'accommodation' , component : AccommodationListComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccommodationRoutingModule { }
