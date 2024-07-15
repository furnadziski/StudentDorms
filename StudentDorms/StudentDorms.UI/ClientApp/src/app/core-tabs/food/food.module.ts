import { NgModule , CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantComponent } from './components/restaurant/restaurant.component';
import { FoodHomeComponent } from './components/food-home/food-home.component';
import { FoodRoutingModule } from './food-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatInputModule } from '@angular/material/input';
import { MaterialModule } from 'src/app/shared/material.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FoodService } from './services/food.service';
import { RestaurantDialogComponent } from './components/restaurant-dialog/restaurant-dialog.component';
import { MatCheckboxModule } from '@angular/material/checkbox';




@NgModule({
  declarations: [
    FoodHomeComponent,
    RestaurantComponent, 
    RestaurantDialogComponent
  ],
  imports: [
    CommonModule,
    FoodRoutingModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    MatInputModule,
    MaterialModule,
    MatFormFieldModule,
    MatCheckboxModule,
  ],
  providers: [
    , FoodService
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
})
export class FoodModule { }
