import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './shared/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardModule } from './core-tabs/dashboard/dashboard.module';
import { SharedModule } from './shared/shared.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorDialogComponent } from './shared/components/error-dialog/error-dialog.component';
import { ErrorDialogService } from './shared/services/error.dialog.service';
import { EditableInputComponent } from './shared/directives/editable-input/editable-input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatChipsModule } from '@angular/material/chips';
import { MatAutocomplete} from '@angular/material/autocomplete';
import { FoodModule } from './core-tabs/food/food.module';
import { FilterService, GroupService, PageService, SortService } from '@syncfusion/ej2-angular-grids';
import { BlockUIModule } from 'ng-block-ui';
import { ConfigurationHomeComponent } from './core-tabs/configuration/components/configuration-home/configuration-home.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from './shared/components/confirmation-dialog/confirmation-dialog.component';
import { PaymentsComponent } from './core-tabs/payments/components/payment-home/payments.component';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';




@NgModule({
  declarations: [
    AppComponent,
    ErrorDialogComponent,
    ConfirmationDialogComponent,
    

 ],
  imports: [
    BrowserModule,
    HttpClientModule ,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    DashboardModule,
    NgbModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    FoodModule,  
    MaterialModule,
    MatToolbarModule, MatButtonModule, MatIconModule,
      BlockUIModule.forRoot({
      delayStart: 300,
      delayStop: 0
    }),
  ],
  entryComponents: [ErrorDialogComponent, ConfirmationDialogComponent],
  exports: [
    
  ],
  // providers: [{ provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },
  //   ErrorDialogService],
  providers: [PageService, GroupService, SortService, FilterService],
  bootstrap: [AppComponent]
})
export class AppModule { }
