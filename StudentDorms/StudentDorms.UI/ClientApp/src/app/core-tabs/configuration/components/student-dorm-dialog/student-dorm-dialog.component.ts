import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ErrorMessages } from 'src/app/shared/models/error-messages';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { StudentDormService } from '../../services/studentdorm.service';
import { StudentDormCreateUpdateModel } from '../../models/student-dorm-create-update-model';

@Component({
  selector: 'app-student-dorm-dialog',
  templateUrl: './student-dorm-dialog.component.html',
  styleUrls: ['./student-dorm-dialog.component.scss']
})
export class StudentDormDialogComponent implements OnInit {
    dataSource;
    studentDormUpdateForm: FormGroup;
    label:string;
    studentDormCreateUpdateModel: StudentDormCreateUpdateModel;
    intStudentDormSearchModel : IntSearchModel;
    intSearchModel: IntSearchModel;
    isLoaded: boolean = false;
    getErrorMessage= ErrorMessages.getErrorMessage;
   
    constructor(
      private StudentDormService: StudentDormService,
      private fb: FormBuilder,
      private dialogRef: MatDialogRef<StudentDormDialogComponent>,
      @Inject(MAT_DIALOG_DATA) public studentDormId: number
    ) { }
  
    ngOnInit(): void {
      this.dialogRef.disableClose = true;
      this.studentDormCreateUpdateModel = new StudentDormCreateUpdateModel();
      this.intStudentDormSearchModel = new IntSearchModel();
      this.studentDormUpdateForm = this.fb.group
      ({
        name:['', [Validators.required, Validators.maxLength(50)]],
        order: ['',[Validators.required]]
      });
  
      if( this.studentDormId != null){          
             this.label = 'Измени студентски дом';
             this.getStudentDormForUpdate(this.studentDormId)
      }
      else{
        this.label = 'Додади студентски дом';
      }
    }

    getStudentDormForUpdate(id:number){

      this.intStudentDormSearchModel.Id = id;
      this.StudentDormService.GetStudentDormById(this.intStudentDormSearchModel).subscribe((data)=>{
        this.dataSource = data;
        this.studentDormUpdateForm.patchValue({
          name: this.dataSource.name,
          order: this.dataSource.order,
           });
        this.isLoaded = true;
      });
    }
  
  
    save(){
      
        this.studentDormCreateUpdateModel.Name = this.studentDormUpdateForm.value.name;
        this.studentDormCreateUpdateModel.Order = this.studentDormUpdateForm.value.order;
        
  
      if(this.studentDormId != null)
      {
        this.studentDormCreateUpdateModel.Id = this.dataSource.id;
            this.StudentDormService
              .updateStudentDorm(this.studentDormCreateUpdateModel)
              .subscribe(()=> {
                this.dialogRef.close({event: 'Save'});
              });
      }
      else {
        this.StudentDormService
              .createStudentDorm(this.studentDormCreateUpdateModel)
              .subscribe(()=>{
                this.dialogRef.close({event: 'Save'});
              });
      }
    }
  
    close(){
      this.dialogRef.close({event: 'Cancel'});
    }
  
  }
