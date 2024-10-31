import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigurationRoutingModule } from './configuration-routing.module';
import { ConfigurationHomeComponent } from './components/configuration-home/configuration-home.component';
import { ConfigurationService } from './services/configuration.service';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { StudentdormsComponent } from './components/student-dorms/student-dorms.component';
import { RegistersComponent } from './components/registers/registers.component';
import { StudentDormsListComponent } from './components/student-dorms-list/student-dorms-list.component';
import { RoomsListComponent } from './components/rooms-list/rooms-list.component';
import { MealsListComponent } from './components/meals-list/meals-list.component';
import { BlocksListComponent } from './components/blocks-list/blocks-list.component';
import { MealCategoryListComponent } from './components/meal-category-list/meal-category-list.component';
import { TicketCategoryListComponent } from './components/ticket-category-list/ticket-category-list.component';
import { TicketPriorityListComponent } from './components/ticket-priority-list/ticket-priority-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FoodRoutingModule } from '../food/food-routing.module';
import { StudentDormDialogComponent } from './components/student-dorm-dialog/student-dorm-dialog.component';
import { BlocksDialogComponent } from './components/blocks-dialog/blocks-dialog.component';
import { RoomsDialogComponent } from './components/rooms-dialog/rooms-dialog.component';
import { MealsDialogComponent } from './components/meals-dialog/meals-dialog.component';
import { UsersListComponent } from './components/users-list/users-list.component';
import { UserDialogComponent } from './components/users-dialog/user-dialog.component';


@NgModule({
  declarations: [
    ConfigurationHomeComponent,
    StudentdormsComponent,
    RegistersComponent,
    StudentDormsListComponent,
    RoomsListComponent,
    MealsListComponent,
    BlocksListComponent,
    MealCategoryListComponent,
    TicketCategoryListComponent,
    TicketPriorityListComponent,
    StudentDormDialogComponent,
    BlocksDialogComponent,
    RoomsDialogComponent,
    MealsDialogComponent,
    UsersListComponent,
    UserDialogComponent,
              ],
  imports: [
    CommonModule,
    ConfigurationRoutingModule,
    MaterialModule,
    SharedModule,
    CommonModule,
    FoodRoutingModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    MatInputModule,
    MaterialModule,
    MatFormFieldModule,
    MatCheckboxModule
  ],
  providers: [
    ConfigurationService
  ]
})
export class ConfigurationModule { }
