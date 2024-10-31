import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { RoomSearchModel } from '../../models/room-search-model';
import { StudentDormSearchModel } from '../../models/student-dorm-search-model';
import { BlockService } from '../../services/block.service';
import { RoomService } from '../../services/room.service';
import { StudentDormService } from '../../services/studentdorm.service';
import { RoomsDialogComponent } from '../rooms-dialog/rooms-dialog.component';
import { UserService } from '../../services/users.service';
import { UserSearchModel } from '../../models/user-search-model';
import { UserDialogComponent } from '../users-dialog/user-dialog.component';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  intSearchModel: IntSearchModel;
   userSearchModel :UserSearchModel;
   activity:any=[];
  genders: any = [];
  roles: any = [];
  userDataSource: any = { data: [], count: 0 };
  constructor(
    private userService : UserService,
    private fb : FormBuilder,
    private dialog: MatDialog
  ) { }

  searchForm:FormGroup;
     displayRoomColumnItems : string[] = [ 'Name','Email','Username','Gender', 'isActive','Roles', 'Actions'];
  ngOnInit(): void {
  
  this.searchForm = this.fb.group({
    searchText : [''],
    selectedRole:[''],
    selectedGender:[''],
    selectedActivity:['']
  });
  
   this.userSearchModel=new UserSearchModel();
  this.intSearchModel = new IntSearchModel();

  this.userSearchModel.SearchText='';
  this.userSearchModel.GenderId=null;
  this.userSearchModel.IsActive=null;
  this.userSearchModel.RoleId=null;
  this.userSearchModel.OrderColumn='FullName';
  this.userSearchModel.OrderDirection='desc';
  this.userSearchModel.RowsPerPage=10;  
  this.userSearchModel.PageNumber=1;
  
  this.loadUsers(this.userSearchModel);
  this.loadRoles(null);
  this.loadGenders(null);
  this.loadActivity(null);
}

  loadUsers(model: UserSearchModel): void {
      this.userService.getUsersForGrid(this.userSearchModel).subscribe((result) => {
    this.userDataSource = result; 
     });
    }

  loadRoles(any): void {
      this.userService.GetRolesForDropdown(any).subscribe((result) => {
    this.roles = result; 
   });
  }

  loadGenders(any): void {
    this.userService.GetGendersForDropdown(any).subscribe((result) => {
  this.genders = result; 
});
}
loadActivity(any): void {
  this.activity = [
    { text: 'Active', value: 1 },
    { text: 'Inactive', value: 0 }
  ];
}

reloadUserTable(model: UserSearchModel){
  this.userService.getUsersForGrid(model).subscribe((data) =>
    {
    this.userDataSource = data;

  });
 }
 
 filterUser(){
  this.userSearchModel.SearchText = this.searchForm.value.searchText;
  this.userSearchModel.GenderId=this.searchForm.value.selectedGender != null  && this.searchForm.value.selectedGender != ''? 
  this.searchForm.value.selectedGender.id :null;
  this.userSearchModel.RoleId = this.searchForm.value.selectedRole != null && this.searchForm.value.selectedRole != '' ?
  this.searchForm.value.selectedRole.id :   null;
  this.userSearchModel.IsActive=this.searchForm.value.selectedActivity != null && this.searchForm.value.selectedActivity != '' ?
  this.searchForm.value.selectedActivity.value :   null;

  this.reloadUserTable(this.userSearchModel);
}

pageEvent(event:any ){
  this.userSearchModel.PageNumber = event.pageIndex + 1;
  this.userSearchModel.RowsPerPage = event.pageSize;
  this.reloadUserTable(this.userSearchModel);
}

sortEvent(event:any){
  this.userSearchModel.OrderDirection = event.direction;
  this.userSearchModel.OrderColumn = event.active;
  this.reloadUserTable(this.userSearchModel);
}

clear() {
  this.searchForm.reset();
  }
  
openDialog(id: number){
  const dialogRef = this.dialog.open(UserDialogComponent, {
    data:id,
  });
  dialogRef.afterClosed().subscribe((result) => {
    if (result.event == 'Save')
      this.loadUsers(this.userSearchModel);
  });
}



}
