import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { MaterialModule } from './material.module';
import { RouterModule } from '@angular/router';
import { EditableInputComponent } from './directives/editable-input/editable-input.component';
import { FormsModule, NgModel, ReactiveFormsModule } from '@angular/forms';
import { EditableSelectComponent } from './directives/editable-select/editable-select.component';
import { EditableDatepickerComponent } from './directives/editable-datepicker/editable-datepicker.component';
import { HeaderComponent } from './components/header/header.component';
import { EditableMultipleSelectComponent } from './directives/editable-multiple-select/editable-multiple-select.component';
import { GetDateFromYearPipe } from './pipes/get-date-from-year.pipe';
import { SharedService } from './services/shared-service';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { UtilsService } from './services/utils-service';
import { GetDateFromMonthPipe } from './pipes/get-date-from-month.pipe'; // Import the pipe here
import { UnAuthorizedComponent } from './error-handlers/un-authorized.component';
import { ConfirmationDialogComponent } from './dialogs/confirmation-dialog.component';
import { TabsComponent } from './components/tabs/tabs.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { GridModule } from '@syncfusion/ej2-angular-grids';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';

@NgModule({
  declarations: [
    NavMenuComponent,
    EditableInputComponent,
    EditableSelectComponent,
    EditableDatepickerComponent,
    HeaderComponent,
    EditableMultipleSelectComponent,
    GetDateFromYearPipe,
    GetDateFromMonthPipe,
    UnAuthorizedComponent,
    ConfirmationDialogComponent,
    TabsComponent
  ],
    imports: [CommonModule, MaterialModule, RouterModule, FormsModule, MatDatepickerModule, ReactiveFormsModule, GridModule, AngularEditorModule,MatDialogModule],
  exports: [
    NavMenuComponent,
    MaterialModule,
    EditableInputComponent,
    EditableSelectComponent,
    EditableDatepickerComponent,
    EditableMultipleSelectComponent,
    HeaderComponent,
    GetDateFromYearPipe,
    GetDateFromMonthPipe,
    UnAuthorizedComponent,
    TabsComponent,
    ConfirmationDialogComponent,
    AngularEditorModule
  ],
  providers: [
    SharedService, UtilsService, FormsModule, NgModel,MatDialog
   ]
})
export class SharedModule {}
