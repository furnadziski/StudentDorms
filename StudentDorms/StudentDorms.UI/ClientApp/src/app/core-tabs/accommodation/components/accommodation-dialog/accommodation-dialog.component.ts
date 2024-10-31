import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ErrorMessages } from 'src/app/shared/models/error-messages';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { AccommodationCreateUpdateModel } from '../../models/accommodation-create-update-model';
import { AccommodationSearchModel } from '../../models/accommodation-search-model';
import { AccommodationService } from '../../services/accommodation.service';
import { UserWithRoleAndBlockSearchModel } from '../../models/User-With-Role-And-Block-Search-Model';
import { UserService } from 'src/app/core-tabs/configuration/services/users.service';

@Component({
  selector: 'app-accommodation-dialog',
  templateUrl: './accommodation-dialog.component.html',
  styleUrls: ['./accommodation-dialog.component.scss']
})
export class AccommodationDialogComponent implements OnInit {
  dataSource;
  accommodationUpdateForm: FormGroup;
  label: string;
  accommodationCreateUpdateModel: AccommodationCreateUpdateModel;
  intAccommodationSearchModel: IntSearchModel;
  accommodationSearchModel: AccommodationSearchModel;
    students:  any = [];
  getErrorMessage = ErrorMessages.getErrorMessage;
  userWithRoleAndBlockSearchModel: UserWithRoleAndBlockSearchModel;
  
  constructor(
        private fb: FormBuilder,
    private dialogRef: MatDialogRef<AccommodationDialogComponent>,
    private accommodationService:AccommodationService,
    private userService: UserService,
    @Inject(MAT_DIALOG_DATA) public accId: number
    
  ) { }

  ngOnInit(): void {
    this.dialogRef.disableClose = true;
    this.accommodationCreateUpdateModel = new AccommodationCreateUpdateModel();
    this.intAccommodationSearchModel = new IntSearchModel();
    this.accommodationSearchModel = new AccommodationSearchModel();
    this.userWithRoleAndBlockSearchModel=new UserWithRoleAndBlockSearchModel();
    this.accommodationUpdateForm = this.fb.group({
    
      selectedStudents: [[]],
      capacity: [ Validators.required],
      room: [ Validators.required],
      id:[]
       
        });

    this.accommodationSearchModel.Year=2024;
    this.accommodationSearchModel.BlockId=1;
    this.accommodationSearchModel.StudentDormId=1;
    this.accommodationSearchModel.HasFreeSpaceOnly=false;
    this.accommodationSearchModel.CapacitySearch=null;
    this.accommodationSearchModel.Userid=null;
    this.accommodationSearchModel.RoomSearchText='';
    this.accommodationSearchModel.OrderColumn='FullName';
    this.accommodationSearchModel.OrderDirection='desc';
    this.accommodationSearchModel.RowsPerPage=10;  
    this.accommodationSearchModel.PageNumber=1;
    
 this.getStudentsForDropDown(null);
    if (this.accId != null) {
          this.label = 'Распредели студенти';
      this.getAccommodationForUpdate(this.accId);
    }

  }

  getStudentsForDropDown(any): void {
   
    this.userService.GetStudentsForDropDown(any).subscribe((result) => {
    this.students = result; 
  });
  }


  compareFn(r1: any, r2: any): boolean {
    return r1 && r2 ? r1.id === r2.id : r1 === r2;
  }

  getAccommodationForUpdate(id: number) {
    this.intAccommodationSearchModel.Id = id;
         this.accommodationService.GetAccommodationById(this.intAccommodationSearchModel).subscribe((data) => {
      this.dataSource = data;
      
      
      this.accommodationUpdateForm.patchValue({
               selectedStudents:this.dataSource.students,
               capacity:this.dataSource.capacity,
               room:this.dataSource.room,
               id: this.dataSource.id
        
       
      });
            
    });
  }

  save() {
    this.accommodationCreateUpdateModel.Users = this.accommodationUpdateForm.value.selectedStudents;
    this.accommodationCreateUpdateModel.Id = this.accommodationUpdateForm.value.id;
    if (this.accId != null) {
                  this.accommodationService.updateAccommodation(this.accommodationCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    } else {
      this.accommodationService.updateAccommodation(this.accommodationCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    }
  }

  close() {
    this.dialogRef.close({ event: 'Cancel' });
  }
}
