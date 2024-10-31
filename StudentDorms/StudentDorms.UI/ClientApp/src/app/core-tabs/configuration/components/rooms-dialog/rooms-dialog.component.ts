import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ErrorMessages } from 'src/app/shared/models/error-messages';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';

import { StudentDormSearchModel } from '../../models/student-dorm-search-model';

import { StudentDormService } from '../../services/studentdorm.service';
import { RoomCreateUpdateModel } from '../../models/room-create-update-model';
import { RoomService } from '../../services/room.service';
import { BlockService } from '../../services/block.service';

@Component({
  selector: 'app-rooms-dialog',
  templateUrl: './rooms-dialog.component.html',
  styleUrls: ['./rooms-dialog.component.scss']
})
export class RoomsDialogComponent implements OnInit {
  dataSource;
  roomUpdateForm: FormGroup;
  label: string;
  roomCreateUpdateModel: RoomCreateUpdateModel;
  intRoomSearchModel: IntSearchModel;
  studentDormSearchModel: StudentDormSearchModel;
  isLoaded: boolean = false;
  studentDorms:  any = [];
  blocks:  any = [];
  getErrorMessage = ErrorMessages.getErrorMessage;

  constructor(
    private roomService: RoomService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<RoomsDialogComponent>,
    private studentDormService: StudentDormService,
    private blockService:BlockService,
    @Inject(MAT_DIALOG_DATA) public roomId: number
  ) { }

  ngOnInit(): void {
    this.dialogRef.disableClose = true;
    this.roomCreateUpdateModel = new RoomCreateUpdateModel();
    this.intRoomSearchModel = new IntSearchModel();
    this.studentDormSearchModel = new StudentDormSearchModel();
    this.roomUpdateForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      order: ['', [Validators.required]],
      capacity:['', [Validators.required]],
      selectedDorm: [null, [Validators.required]],
      block: [null, [Validators.required]],
     
    });
    
  this.studentDormSearchModel.SearchText='';
  this.studentDormSearchModel.OrderColumn='Name';
  this.studentDormSearchModel.OrderDirection='desc';
  this.studentDormSearchModel.RowsPerPage=10; 
  this.studentDormSearchModel.PageNumber=1;

    

    if (this.roomId != null) {
      this.loadStudentDorms(null);
      this.loadBlocks(null);
      this.label = 'Измени соба';
      this.getRoomForUpdate(this.roomId);
    } else {
      this.loadStudentDorms(null);
      this.loadBlocks(null);
      this.label = 'Додади соба';
     
    }
  }

  loadStudentDorms(any): void {
        this.studentDormService.GetStudentDormsForDropdown(any).subscribe((result) => {

      this.studentDorms = result; 
    });
  }

  loadBlocks(any): void {
    this.blockService.GetBlocksForDropdown(any).subscribe((result) => {
  this.blocks = result; 
});
}

  compareFn(r1: any, r2: any): boolean {
    return r1 && r2 ? r1.id === r2.id : r1 === r2;
  }

  getRoomForUpdate(id: number) {
    this.intRoomSearchModel.Id = id;
         this.roomService.GetRoomById(this.intRoomSearchModel).subscribe((data) => {
      this.dataSource = data;
     
      this.roomUpdateForm.patchValue({
        name: this.dataSource.roomNo,
        order: this.dataSource.order,
        capacity:this.dataSource.capacity,
        selectedDorm : this.dataSource.studentDorm,
        block:this.dataSource.block
       
      });
      
      this.isLoaded = true;
    });
  }

 

  save() {
    this.roomCreateUpdateModel.StudentDormId = this.roomUpdateForm.value.selectedDorm.id
    this.roomCreateUpdateModel.BlockId=this.roomUpdateForm.value.block.id
    this.roomCreateUpdateModel.Order = this.roomUpdateForm.value.order;
    this.roomCreateUpdateModel.RoomNo = this.roomUpdateForm.value.roomNo;
    this.roomCreateUpdateModel.Capacity=this.roomUpdateForm.value.capacity;
 
    if (this.roomId != null) {
      this.roomCreateUpdateModel.Id = this.dataSource.id;
      this.roomService.updateRoom(this.roomCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    } else {
      this.roomService.createRoom(this.roomCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    }
  }

  close() {
    this.dialogRef.close({ event: 'Cancel' });
  }
}

