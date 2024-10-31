import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ErrorMessages } from 'src/app/shared/models/error-messages';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { RoomsDialogComponent } from '../rooms-dialog/rooms-dialog.component';
import { UserSearchModel } from '../../models/user-search-model';
import { UserService } from '../../services/users.service';
import { UserCreateUpdateModel } from '../../models/user-create-update-model';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.scss']
})
export class UserDialogComponent implements OnInit {
  dataSource;
  userUpdateForm: FormGroup;
  label: string;
  userCreateUpdateModel: UserCreateUpdateModel;
  intUserSearchModel: IntSearchModel;
  userSearchModel: UserSearchModel;
  isLoaded: boolean = false;
  users:  any = [];
  roles:  any = [];
  genders:  any = [];
  getErrorMessage = ErrorMessages.getErrorMessage;

  constructor(
        private fb: FormBuilder,
    private dialogRef: MatDialogRef<UserDialogComponent>,
    private userService:UserService,
    @Inject(MAT_DIALOG_DATA) public userId: number
  ) { }

  ngOnInit(): void {
    this.dialogRef.disableClose = true;
    this.userCreateUpdateModel = new UserCreateUpdateModel();
    this.intUserSearchModel = new IntSearchModel();
    this.userSearchModel = new UserSearchModel();
    this.userUpdateForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      username: ['', [Validators.required]],
      email:['', [Validators.required]],
      selectedRoles: [[], Validators.required],
        gender: [null, [Validators.required]],
        checkboxActive: [false]
        });

    this.userSearchModel.SearchText='';
    this.userSearchModel.GenderId=null;
    this.userSearchModel.IsActive=null;
    this.userSearchModel.RoleId=null;
    this.userSearchModel.OrderColumn='FullName';
    this.userSearchModel.OrderDirection='desc';
    this.userSearchModel.RowsPerPage=10;  
    this.userSearchModel.PageNumber=1;
    
    this.loadUsers(null);
    this.loadGenders(null);
    this.loadRoles(null);
    if (this.userId != null) {
          this.label = 'Измени корисник';
      this.getUserForUpdate(this.userId);
    } else {
            this.label = 'Додади корисник';
     
    }
  }


  loadUsers(model: UserSearchModel): void {
    this.userService.getUsersForGrid(this.userSearchModel).subscribe((result) => {
  this.users = result; 
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

  compareFn(r1: any, r2: any): boolean {
    return r1 && r2 ? r1.id === r2.id : r1 === r2;
  }

  getUserForUpdate(id: number) {
    this.intUserSearchModel.Id = id;
         this.userService.GetUserById(this.intUserSearchModel).subscribe((data) => {
      this.dataSource = data;
      
      this.userUpdateForm.patchValue({
        username: this.dataSource.username,
        email: this.dataSource.email,
        lastName:this.dataSource.lastName,
        firstName:this.dataSource.firstName,
        gender :this.dataSource.gender,
        selectedRoles:this.dataSource.roles,
        checkboxActive:this.dataSource.isActive
       
      });
      
      this.isLoaded = true;
    });
  }

 

  save() {
    this.userCreateUpdateModel.FirstName = this.userUpdateForm.value.firstName
    this.userCreateUpdateModel.LastName = this.userUpdateForm.value.lastName
    this.userCreateUpdateModel.Email = this.userUpdateForm.value.email;
    this.userCreateUpdateModel.GenderId = this.userUpdateForm.value.gender.id;
    this.userCreateUpdateModel.Username = this.userUpdateForm.value.username;
    this.userCreateUpdateModel.Roles=this.userUpdateForm.value.selectedRoles;
    this.userCreateUpdateModel.IsActive = this.userUpdateForm.value.checkboxActive;
 
    if (this.userId != null) {
      this.userCreateUpdateModel.Id = this.dataSource.id;
      this.userService.updateUser(this.userCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    } else {
      this.userService.createUser(this.userCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    }
  }

  close() {
    this.dialogRef.close({ event: 'Cancel' });
  }
}
