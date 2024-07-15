import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FoodHomeComponent } from './components/food-home/food-home.component';
import { RestaurantComponent } from './components/restaurant/restaurant.component';


const routes: Routes = [
  {
    path: '' , component : FoodHomeComponent,
    children:[
      { path: '' , redirectTo:'restaurants', pathMatch:'full' },
      { path: 'restaurants' , component : RestaurantComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FoodRoutingModule { }
