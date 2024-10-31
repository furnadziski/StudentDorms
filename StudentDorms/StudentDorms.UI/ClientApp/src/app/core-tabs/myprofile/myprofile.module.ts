import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MyprofileRoutingModule } from './myprofile-routing.module';
import { MyprofileHomeComponent } from './components/myprofile-home.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { MyprofileDialogComponent } from './components/myprofile-dialog/myprofile-dialog.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [MyprofileHomeComponent, MyprofileDialogComponent],
  imports: [
    CommonModule,
    MyprofileRoutingModule,
    MaterialModule,
    SharedModule,
    FormsModule
  ]
})
export class MyprofileModule { }
