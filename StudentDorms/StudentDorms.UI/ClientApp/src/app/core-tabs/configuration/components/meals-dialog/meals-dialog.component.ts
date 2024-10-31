import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MealService } from '../../services/meal.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { MealSearchModel } from '../../models/meal-search-model';
import { MealCategorySearchModel } from '../../models/meal-category-search-model';
import { MealCreateUpdateModel } from '../../models/meal-create-update-model';
import { ErrorMessages } from 'src/app/shared/models/error-messages';

@Component({
  selector: 'app-meals-dialog',
  templateUrl: './meals-dialog.component.html',
  styleUrls: ['./meals-dialog.component.scss']
})
export class MealsDialogComponent implements OnInit {
  dataSource;
  mealUpdateForm: FormGroup;
  label: string;
  mealCreateUpdateModel: MealCreateUpdateModel;
  intMealSearchModel: IntSearchModel;
  mealCategorySearchModel: MealCategorySearchModel;
  mealSearchModel:MealSearchModel;
  isLoaded: boolean = false;
  mealCategories:  any = [];
  getErrorMessage = ErrorMessages.getErrorMessage;

  constructor(
    private mealService: MealService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<MealsDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public mealId: number
  ) { }

  ngOnInit(): void {
    this.dialogRef.disableClose = true;
    this.mealCreateUpdateModel = new MealCreateUpdateModel();
    this.intMealSearchModel = new IntSearchModel();
    this.mealSearchModel=new MealSearchModel();
    this.mealCategorySearchModel = new MealCategorySearchModel();
    this.mealUpdateForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      order: ['', [Validators.required]],
      selectedCategory: [null, [Validators.required]],
     
    });
    
  this.mealSearchModel.SearchText='';
  this.mealSearchModel.MealCategoryId=null;
  this.mealSearchModel.OrderColumn='Name';
  this.mealSearchModel.OrderDirection='desc';
  this.mealSearchModel.RowsPerPage=10; 
  this.mealSearchModel.PageNumber=1;

    

    if (this.mealId != null) {
      this.label = 'Измени оброк';
      this.getMealForUpdate(this.mealId);
    } else {
      this.loadMealCategories(null);
      this.label = 'Додади блок';
     
    }
  }

  loadMealCategories(any): void {
        this.mealService.GetMealCategoriesForDropdown(any).subscribe((result) => {
      this.mealCategories = result; 
    });
  }

  getMealForUpdate(id: number) {
    this.intMealSearchModel.Id = id;
    this.loadMealCategories(null);
    
       this.mealService.GetMealById(this.intMealSearchModel).subscribe((data) => {
      this.dataSource = data;
     
      this.mealUpdateForm.patchValue({
        name: this.dataSource.name,
        order: this.dataSource.order,
        selectedCategory :this.dataSource.mealCategory
       
      });
      
      this.isLoaded = true;
    });
  }

  compareFn(r1: any, r2: any): boolean {
    return r1 && r2 ? r1.id === r2.id : r1 === r2;
  }

  save() {
    this.loadMealCategories(null);
    this.mealCreateUpdateModel.MealCategoryId = this.mealUpdateForm.value.selectedCategory.id
    this.mealCreateUpdateModel.Order = this.mealUpdateForm.value.order;
    this.mealCreateUpdateModel.Name = this.mealUpdateForm.value.name;

    

    if (this.mealId != null) {
      this.mealCreateUpdateModel.Id = this.dataSource.id;
      this.mealService.updateMeal(this.mealCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    } else {
      this.mealService.createMeal(this.mealCreateUpdateModel).subscribe(() => {
        this.dialogRef.close({ event: 'Save' });
      });
    }
  }

  close() {
    this.dialogRef.close({ event: 'Cancel' });
  }
}
