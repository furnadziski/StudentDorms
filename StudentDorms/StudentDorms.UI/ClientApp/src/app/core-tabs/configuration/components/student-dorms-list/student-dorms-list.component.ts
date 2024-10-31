import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { StudentDormSearchModel } from '../../models/student-dorm-search-model';
import { StudentDormService } from '../../services/studentdorm.service';
import { StudentDormDialogComponent } from '../student-dorm-dialog/student-dorm-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { HttpErrorResponse } from '@angular/common/http';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';


@Component({
  selector: 'app-student-dorms-list',
  templateUrl: './student-dorms-list.component.html',
  styleUrls: ['./student-dorms-list.component.scss']
})
export class StudentDormsListComponent implements OnInit {
  intSearchModel: IntSearchModel;
  constructor(
    private fb : FormBuilder,
    private studentDormService : StudentDormService,
    private dialog: MatDialog
  ) { }

  searchForm:FormGroup;
  studentDormDataSource: any = { data: [], count: 0 };
  studentDormSearchModel: StudentDormSearchModel = new StudentDormSearchModel();
  displayStudentDormColumnItems : string[] = ['Name', 'Order', 'Actions'];
 ngOnInit(): void {
  this.searchForm = this.fb.group({
    searchText : [''],
  });
  
  this.studentDormSearchModel = new StudentDormSearchModel();
  this.intSearchModel = new IntSearchModel();

  this.studentDormSearchModel.SearchText='';
  this.studentDormSearchModel.OrderColumn='Name';
  this.studentDormSearchModel.OrderDirection='desc';
  this.studentDormSearchModel.RowsPerPage=10; 
  this.studentDormSearchModel.PageNumber=1;

  this.reloadStudentDormTable(this.studentDormSearchModel);

}
 reloadStudentDormTable(model: StudentDormSearchModel){
  this.studentDormService.getStudentDormsForGrid(model).subscribe((data) => {
    this.studentDormDataSource = data;

  });
}

filterStudentDorms(){
  this.studentDormSearchModel.SearchText = this.searchForm.value.searchText;
  this.reloadStudentDormTable(this.studentDormSearchModel);
}

pageEvent(event:any ){
  this.studentDormSearchModel.PageNumber = event.pageIndex + 1;
  this.studentDormSearchModel.RowsPerPage = event.pageSize;

  this.reloadStudentDormTable(this.studentDormSearchModel);
}

sortEvent(event:any){
  this.studentDormSearchModel.OrderDirection = event.direction;
  this.studentDormSearchModel.OrderColumn = event.active;

  this.reloadStudentDormTable(this.studentDormSearchModel);
}
clear() {
  this.searchForm.reset();
}
openDialog(id: number){
  const dialogRef = this.dialog.open(StudentDormDialogComponent, {
    data:id,
  });
  dialogRef.afterClosed().subscribe((result) => {
    if (result.event == 'Save')
      this.reloadStudentDormTable(this.studentDormSearchModel);
  });
}

async openDeleteStudentDormDailog(id : number, name : string){
  var message = "Дали сте сигурни дека сакате го избришете студентскиод дом  " + name + "?"
  const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
    data: message,
  });
  dialogRef.afterClosed().subscribe((result) =>{
    if(result.event == "Confirm"){
      this.deleteStudentDorm(id);
    }
  });
}

deleteStudentDorm(id : number){
  this.intSearchModel.Id = id;
  this.studentDormService.deleteStudentDormById(this.intSearchModel).subscribe(() => {
    this.reloadStudentDormTable(this.studentDormSearchModel);
  },
  (error : HttpErrorResponse) => { },
  (() => {}));
}

}


