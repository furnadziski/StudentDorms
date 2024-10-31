import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { BlockSearchModel } from '../../models/block-search-model';
import { BlockService } from '../../services/block.service';
import { BlocksDialogComponent } from '../blocks-dialog/blocks-dialog.component';
import { StudentDormSearchModel } from '../../models/student-dorm-search-model';
import { StudentDormService } from '../../services/studentdorm.service';

@Component({
  selector: 'app-blocks-list',
  templateUrl: './blocks-list.component.html',
  styleUrls: ['./blocks-list.component.scss']
})
export class BlocksListComponent implements OnInit {
  intSearchModel: IntSearchModel;
  studentDormSearchModel: StudentDormSearchModel;
  studentDorms: any = [];
  blockDataSource: any = { data: [], count: 0 };
  constructor(
    private studentDormService : StudentDormService,
    private fb : FormBuilder,
    private blockService : BlockService,
    private dialog: MatDialog
  ) { }

  searchForm:FormGroup;
 
  blockSearchModel: BlockSearchModel = new BlockSearchModel();
  displayBlockColumnItems : string[] = [ 'studentDorm','Name', 'Order', 'Actions'];
 ngOnInit(): void {
  this.studentDormSearchModel = new StudentDormSearchModel();

  this.searchForm = this.fb.group({
    searchText : [''],
    selectedDorm:['']

  });
  
  this.blockSearchModel = new BlockSearchModel();
  this.intSearchModel = new IntSearchModel();

  this.blockSearchModel.SearchText='';
  this.blockSearchModel.StudentDormId=null;
  this.blockSearchModel.OrderColumn='Name';
  this.blockSearchModel.OrderDirection='desc';
  this.blockSearchModel.RowsPerPage=10; 
  this.blockSearchModel.PageNumber=1;
  

  this.reloadBlockTable(this.blockSearchModel);
  this.loadStudentDorms(null);

}

    loadStudentDorms(any): void {
      this.studentDormService.GetStudentDormsForDropdown(any).subscribe((result) => {
    this.studentDorms = result; 
    });
    }
 reloadBlockTable(model: BlockSearchModel){
  this.blockService.getBlocksForGrid(model).subscribe((data) =>
    {
    this.blockDataSource = data;

  });
 }

filterBlocks(){
  this.blockSearchModel.SearchText = this.searchForm.value.searchText;
   this.blockSearchModel.StudentDormId = this.searchForm.value.selectedDorm != null && this.searchForm.value.selectedDorm != '' ?
  this.searchForm.value.selectedDorm.id :   null;
  this.reloadBlockTable(this.blockSearchModel);
}

pageEvent(event:any ){
  this.blockSearchModel.PageNumber = event.pageIndex + 1;
  this.blockSearchModel.RowsPerPage = event.pageSize;

  this.reloadBlockTable(this.blockSearchModel);
}

sortEvent(event:any){
  this.blockSearchModel.OrderDirection = event.direction;
  this.blockSearchModel.OrderColumn = event.active;

  this.reloadBlockTable(this.blockSearchModel);
}
clear() {
  this.searchForm.reset();
  }
openDialog(id: number){
  const dialogRef = this.dialog.open(BlocksDialogComponent, {
    data:id,
  });
  dialogRef.afterClosed().subscribe((result) => {
    if (result.event == 'Save')
      this.reloadBlockTable(this.blockSearchModel);
  });
}

async openDeleteBlockDailog(id : number, name : string){
  var message = "Дали сте сигурни дека сакате го избришете блокот  " + name + "?"
  const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
    data: message,
  });
  dialogRef.afterClosed().subscribe((result) =>{
    if(result.event == "Confirm"){
      this.deleteBlock(id);
    }
  });
}

deleteBlock(id : number){
  this.intSearchModel.Id = id;
  this.blockService.deleteBlockById(this.intSearchModel).subscribe(() => {
    this.reloadBlockTable(this.blockSearchModel);
  },
  (error : HttpErrorResponse) => { },
  (() => {}));
}

}
