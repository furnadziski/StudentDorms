import { Component, Inject, OnInit } from '@angular/core';
import { BlockCreateUpdateModel } from '../../models/block-create-update-model';
import { BlockService } from '../../services/block.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ErrorMessages } from 'src/app/shared/models/error-messages';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { StudentDormService } from '../../services/studentdorm.service';
import { StudentDormGridModel } from '../../models/student-dorm-grid-model';
import { StudentDormSearchModel } from '../../models/student-dorm-search-model';

@Component({
  selector: 'app-blocks-dialog',
  templateUrl: './blocks-dialog.component.html',
  styleUrls: ['./blocks-dialog.component.scss']
})
export class BlocksDialogComponent implements OnInit {
  dataSource;
  blockUpdateForm: FormGroup;
  label: string;
blockCreateUpdateModel: BlockCreateUpdateModel;
  intBlockSearchModel: IntSearchModel;
  studentDormSearchModel: StudentDormSearchModel;
  isLoaded: boolean = false;
  studentDorms:  any = [];
  getErrorMessage = ErrorMessages.getErrorMessage;

  constructor(
    private blockService: BlockService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<BlocksDialogComponent>,
    private studentDormService: StudentDormService,
    @Inject(MAT_DIALOG_DATA) public blockId: number
  ) { }

  ngOnInit(): void {
    this.dialogRef.disableClose = true;
    this.blockCreateUpdateModel = new BlockCreateUpdateModel();
    this.intBlockSearchModel = new IntSearchModel();
    this.studentDormSearchModel = new StudentDormSearchModel();
    this.blockUpdateForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      order: ['', [Validators.required]],
      selectedDorm: [null, [Validators.required]],
     
    });
    
  this.studentDormSearchModel.SearchText='';
  this.studentDormSearchModel.OrderColumn='Name';
  this.studentDormSearchModel.OrderDirection='desc';
  this.studentDormSearchModel.RowsPerPage=10; 
  this.studentDormSearchModel.PageNumber=1;

    

    if (this.blockId != null) {
      this.label = 'Измени блок';
      this.getBlockForUpdate(this.blockId);
    } else {
      this.loadStudentDorms(null);
      this.label = 'Додади блок';
     
    }
  }

  loadStudentDorms(any): void {
        this.studentDormService.GetStudentDormsForDropdown(any).subscribe((result) => {
      this.studentDorms = result; 
    });
  }

  getBlockForUpdate(id: number) {
    this.intBlockSearchModel.Id = id;
    this.loadStudentDorms(null);
    
       this.blockService.GetBlockById(this.intBlockSearchModel).subscribe((data) => {
      this.dataSource = data;
     
      this.blockUpdateForm.patchValue({
        name: this.dataSource.name,
        order: this.dataSource.order,
        selectedDorm : this.dataSource.studentDorm
       
      });
      
      this.isLoaded = true;
    });
  }

  compareFn(r1: any, r2: any): boolean {
    return r1 && r2 ? r1.id === r2.id : r1 === r2;
  }

  save() {
    this.loadStudentDorms(null);
    this.blockCreateUpdateModel.StudentDormId = this.blockUpdateForm.value.selectedDorm.id
    this.blockCreateUpdateModel.Order = this.blockUpdateForm.value.order;
    this.blockCreateUpdateModel.Name = this.blockUpdateForm.value.name;

    

    if (this.blockId != null) {
      this.blockCreateUpdateModel.Id = this.dataSource.id;
      this.blockService.updateBlock(this.blockCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    } else {
      this.blockService.createBlock(this.blockCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    }
  }

  close() {
    this.dialogRef.close({ event: 'Cancel' });
  }
}
