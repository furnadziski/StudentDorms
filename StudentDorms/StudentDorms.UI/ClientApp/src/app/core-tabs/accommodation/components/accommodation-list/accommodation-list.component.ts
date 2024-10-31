import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { RoomSearchModel } from '../../../configuration/models/room-search-model';
import { StudentDormSearchModel } from '../../../configuration/models/student-dorm-search-model';
import { BlockService } from '../../../configuration/services/block.service';
import { RoomService } from '../../../configuration/services/room.service';
import { StudentDormService } from '../../../configuration/services/studentdorm.service';
import { RoomsDialogComponent } from '../../../configuration/components/rooms-dialog/rooms-dialog.component';
import { AccommodationService } from '../../services/accommodation.service';
import { AccommodationSearchModel } from 'src/app/core-tabs/accommodation/models/accommodation-search-model';
import { UserWithRoleAndBlockSearchModel } from '../../models/User-With-Role-And-Block-Search-Model';
import { AccommodationDialogComponent } from '../accommodation-dialog/accommodation-dialog.component';

@Component({
  selector: 'app-accommodation-list',
  templateUrl: './accommodation-list.component.html',
  styleUrls: ['./accommodation-list.component.scss']
})
export class AccommodationListComponent implements OnInit {
  isDivVisible: boolean = false;
  intSearchModel: IntSearchModel;
  userWithRoleAndBlockSearchModel: UserWithRoleAndBlockSearchModel;
  studentDormSearchModel: StudentDormSearchModel;
  annualAccommodationSearchModel: AccommodationSearchModel;
  studentDorms: any = [];
  blocks: any = [];
  acc: any = [];
  rooms: any = [];
  students: any = [];
  selectedDorm:any;
  selectedBlock:any;
  annualAccommodations: any = [];
  accommodationDataSource: any = { data: [], count: 0 };
  constructor(
    private studentDormService : StudentDormService,
    private blockService:BlockService,
    private fb : FormBuilder,
    private roomService : RoomService,
    private accommodationService:AccommodationService,
    private dialog: MatDialog
  ) { }

  searchForm:FormGroup;
  secondSearchForm:FormGroup;
 
  roomSearchModel: RoomSearchModel = new RoomSearchModel();
  displayAccommodationColumnItems : string[] = [ 'Room','Gender','Capacity','Fullnes', 'Students', 'Actions'];
  ngOnInit(): void {
  this.studentDormSearchModel = new StudentDormSearchModel();
  this.annualAccommodationSearchModel = new AccommodationSearchModel();
  this.searchForm = this.fb.group({
    searchText : [''],
    selectedDorm:[''],
    selectedBlock: [{ value: '', disabled: true }]
  });
  this.secondSearchForm = this.fb.group({
    selectedRoom : [''],
    capacity:[''],
    Students:[''],
    isFree: [false]
  });
  
  this.roomSearchModel = new RoomSearchModel();
  this.intSearchModel = new IntSearchModel();
  this.userWithRoleAndBlockSearchModel=new UserWithRoleAndBlockSearchModel();

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

  this.annualAccommodationSearchModel.Year=2024;
  this.annualAccommodationSearchModel.BlockId=1;
  this.annualAccommodationSearchModel.StudentDormId=1;
  this.annualAccommodationSearchModel.HasFreeSpaceOnly=false;
  this.annualAccommodationSearchModel.CapacitySearch=null;
  this.annualAccommodationSearchModel.Userid=null;
  this.annualAccommodationSearchModel.RoomSearchText='';
  this.annualAccommodationSearchModel.OrderColumn='Name';
  this.annualAccommodationSearchModel.OrderDirection='desc';
  this.annualAccommodationSearchModel.RowsPerPage=10; 
  this.annualAccommodationSearchModel.PageNumber=1;

  this.loadStudentDorms(null);

  this.loadAnnualAccommodations(null);
 
}

    loadStudentDorms(any): void {
      this.studentDormService.GetStudentDormsForDropdown(any).subscribe((result) => {
    this.studentDorms = result; 
    });
    }

    getBlocksByStudentDorm(newValue): void {
      if (!newValue) return;
      this.searchForm.get('selectedBlock').enable();
      this.selectedDorm=newValue;
      this.intSearchModel.Id = this.selectedDorm.id;
      this.blockService.GetBlocksForDropdownByStudentDormId(this.intSearchModel,).subscribe((result) => {
    this.blocks = result; 
  
  });
  }

  loadUserWithRoleAndBlock(any): void {
  this.userWithRoleAndBlockSearchModel.BlockId = this.searchForm.value.selectedBlock.id;
  this.userWithRoleAndBlockSearchModel.Year=this.annualAccommodationSearchModel.Year;
  this.accommodationService.GetUserWithRoleAndBlock(this.userWithRoleAndBlockSearchModel).subscribe((result) => {
  this.students = result; 
});
}
      getRoomsForDropdownByBlockId(newValue):void{
        if(!newValue) return;
        this.selectedBlock=newValue;
        this.intSearchModel.Id=this.selectedBlock.id;
        this.roomService.GetRoomsForDropdownByBlockId(this.intSearchModel).subscribe((result) => {
          this.rooms = result; 
           });
        }


loadAnnualAccommodations(model: AccommodationSearchModel): void {
  this.accommodationService.GetAnnualAccommodationsForGrid(this.annualAccommodationSearchModel).subscribe((result) => {
this.annualAccommodations = result; 
});
}

reloadAnnualAccommodations(model: AccommodationSearchModel){
  this.accommodationService.GetAnnualAccommodationsForGrid(model).subscribe((data) =>
    {
    this.accommodationDataSource = data;

  });
 }

 
 filterAccommodation(){

  if(this.searchForm.value.selectedDorm=='' 
    || this.searchForm.value.selectedDorm== null 
    || this.searchForm.value.selectedBlock==''
    || this.searchForm.value.selectedBlock==null){
      return;  
  }
  this.annualAccommodationSearchModel.Userid=this.secondSearchForm.value.Students != null && this.secondSearchForm.value.Students !=''?
  this.secondSearchForm.value.Students.id:null;
    this.annualAccommodationSearchModel.BlockId=this.searchForm.value.selectedBlock != null && this.searchForm.value.selectedBlock !=''?
    this.searchForm.value.selectedBlock.id:null;
    this.annualAccommodationSearchModel.BlockId=this.searchForm.value.selectedBlock != null && this.searchForm.value.selectedBlock !=''?
    this.searchForm.value.selectedBlock.id:null;
    this.annualAccommodationSearchModel.StudentDormId=this.searchForm.value.selectedDorm != null && this.searchForm.value.selectedDorm !=''?
    this.searchForm.value.selectedDorm.id:null;
    this.annualAccommodationSearchModel.RoomSearchText=this.secondSearchForm.value.selectedRoom != null && this.secondSearchForm.value.selectedRoom !=''?
    this.secondSearchForm.value.selectedRoom.title:''; 
    this.annualAccommodationSearchModel.CapacitySearch=this.secondSearchForm.value.capacity != null && this.secondSearchForm.value.capacity !=''?
    this.secondSearchForm.value.capacity:null;
    this.annualAccommodationSearchModel.HasFreeSpaceOnly=this.secondSearchForm.value.isFree != null && this.secondSearchForm.value.isFree !=''?
    this.secondSearchForm.value.isFree:false;

    this.loadUserWithRoleAndBlock(null);
    this.reloadAnnualAccommodations(this.annualAccommodationSearchModel);
  
    if(this.searchForm.value.selectedDorm==null && this.searchForm.value.selectedBlock==null){
        this.isDivVisible = false;
        }else
        this.isDivVisible = true;
}

pageEvent(event:any ){
  this.roomSearchModel.PageNumber = event.pageIndex + 1;
  this.roomSearchModel.RowsPerPage = event.pageSize;

  this.reloadAnnualAccommodations(this.annualAccommodationSearchModel);
}

sortEvent(event:any){
  this.roomSearchModel.OrderDirection = event.direction;
  this.roomSearchModel.OrderColumn = event.active;

  this.reloadAnnualAccommodations(this.annualAccommodationSearchModel);
}
clear() {
  this.searchForm.reset();
  this.secondSearchForm.reset();
   this.searchForm.get('selectedBlock').disable();
  this.isDivVisible = false;
  }
openDialog(id: number){
  const dialogRef = this.dialog.open(AccommodationDialogComponent, {
    data:id,
  });
  dialogRef.afterClosed().subscribe((result) => {
    if (result.event == 'Save')
      this.reloadAnnualAccommodations(this.annualAccommodationSearchModel);
  });
}

}
