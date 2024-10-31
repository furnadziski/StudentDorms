import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { StudentDormSearchModel } from '../../models/student-dorm-search-model';
import { StudentDormService } from '../../services/studentdorm.service';
import { RoomService } from '../../services/room.service';
import { RoomSearchModel } from '../../models/room-search-model';
import { RoomsDialogComponent } from '../rooms-dialog/rooms-dialog.component';
import { BlockService } from '../../services/block.service';

@Component({
  selector: 'app-rooms-list',
  templateUrl: './rooms-list.component.html',
  styleUrls: ['./rooms-list.component.scss']
})
export class RoomsListComponent implements OnInit {

  intSearchModel: IntSearchModel;
  studentDormSearchModel: StudentDormSearchModel;
  studentDorms: any = [];
  blocks: any = [];
  roomDataSource: any = { data: [], count: 0 };
  constructor(
    private studentDormService : StudentDormService,
    private blockService:BlockService,
    private fb : FormBuilder,
    private roomService : RoomService,
    private dialog: MatDialog
  ) { }

  searchForm:FormGroup;
 
  roomSearchModel: RoomSearchModel = new RoomSearchModel();
  displayRoomColumnItems : string[] = [ 'Name','BlockName','studentDorm','Capacity', 'Order', 'Actions'];
  ngOnInit(): void {
  this.studentDormSearchModel = new StudentDormSearchModel();
  this.searchForm = this.fb.group({
    searchText : [''],
    selectedDorm:[''],
    selectedBlock:['']
  });
  
  this.roomSearchModel = new RoomSearchModel();
  this.intSearchModel = new IntSearchModel();

  this.roomSearchModel.SearchText='';
  this.roomSearchModel.StudentDormId=null;
  this.roomSearchModel.BlockId=null;
  this.roomSearchModel.OrderColumn='Name';
  this.roomSearchModel.OrderDirection='desc';
  this.roomSearchModel.RowsPerPage=10; 
  this.roomSearchModel.PageNumber=1;
  
  this.studentDormSearchModel.SearchText='';
  this.studentDormSearchModel.OrderColumn='Name';
  this.studentDormSearchModel.OrderDirection='desc';
  this.studentDormSearchModel.RowsPerPage=10; 
  this.studentDormSearchModel.PageNumber=1;

  this.reloadRoomTable(this.roomSearchModel);
  this.loadStudentDorms(this.studentDormSearchModel);
  this.loadBlocks(null);

}

    loadStudentDorms(model: StudentDormSearchModel): void {
      this.studentDormService.GetStudentDormsForDropdown(this.studentDormSearchModel).subscribe((result) => {
    this.studentDorms = result; 
    });
    }

    loadBlocks(any): void {
      this.blockService.GetBlocksForDropdown(any).subscribe((result) => {
    this.blocks = result; 
  });
  }


    reloadRoomTable(model: RoomSearchModel){
  this.roomService.getRoomsForGrid(model).subscribe((data) =>
    {
    this.roomDataSource = data;

  });
 }


 
filterRoom(){
  this.roomSearchModel.SearchText = this.searchForm.value.searchText;
  this.roomSearchModel.BlockId=this.searchForm.value.selectedBlock != null  && this.searchForm.value.selectedBlock != ''? 
  this.searchForm.value.selectedBlock.id :null;
  this.roomSearchModel.StudentDormId = this.searchForm.value.selectedDorm != null && this.searchForm.value.selectedDorm != '' ?
   this.searchForm.value.selectedDorm.id :   null;

       


  this.reloadRoomTable(this.roomSearchModel);
}

pageEvent(event:any ){
  this.roomSearchModel.PageNumber = event.pageIndex + 1;
  this.roomSearchModel.RowsPerPage = event.pageSize;

  this.reloadRoomTable(this.roomSearchModel);
}

sortEvent(event:any){
  this.roomSearchModel.OrderDirection = event.direction;
  this.roomSearchModel.OrderColumn = event.active;

  this.reloadRoomTable(this.roomSearchModel);
}
clear() {
  this.searchForm.reset();
  }
openDialog(id: number){
  const dialogRef = this.dialog.open(RoomsDialogComponent, {
    data:id,
  });
  dialogRef.afterClosed().subscribe((result) => {
    if (result.event == 'Save')
      this.reloadRoomTable(this.roomSearchModel);
  });
}

async openDeleteRoomDailog(id : number, name : string){
  var message = "Дали сте сигурни дека сакате да ја  избришете собата  " + name + "?"
  const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
    data: message,
  });
  dialogRef.afterClosed().subscribe((result) =>{
    if(result.event == "Confirm"){
      this.deleteRoom(id);
    }
  });
}

deleteRoom(id : number){
     this.intSearchModel.Id = id;
  this.roomService.DeleteRoomById(this.intSearchModel).subscribe(() => {
     this.reloadRoomTable(this.roomSearchModel);
   },
   (error : HttpErrorResponse) => { },
   (() => {}));
}

}
