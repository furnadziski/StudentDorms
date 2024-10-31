import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccommodationRoutingModule } from './accommodation-routing.module';
import { AccommodationHomeComponent } from './components/accommodation-home/accommodation-home.component';
import { AccommodationDialogComponent } from './components/accommodation-dialog/accommodation-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { FoodRoutingModule } from '../food/food-routing.module';
import { AccommodationListComponent } from './components/accommodation-list/accommodation-list.component';


@NgModule({
  declarations: [
    AccommodationHomeComponent,
        AccommodationListComponent,
        AccommodationDialogComponent
  ],
  imports: [
    CommonModule,
    AccommodationRoutingModule,
    MaterialModule,
    SharedModule,
    CommonModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    MatInputModule,
    MaterialModule,
    MatFormFieldModule,
    MatCheckboxModule

  ]
})
export class AccommodationModule { }
