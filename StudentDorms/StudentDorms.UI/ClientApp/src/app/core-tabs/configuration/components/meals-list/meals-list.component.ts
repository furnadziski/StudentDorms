import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { MealSearchModel } from '../../models/meal-search-model';
import { MealService } from '../../services/meal.service';
import { MealCategorySearchModel } from '../../models/meal-category-search-model';
import { MealsDialogComponent } from '../meals-dialog/meals-dialog.component';

@Component({
  selector: 'app-meals-list',
  templateUrl: './meals-list.component.html',
  styleUrls: ['./meals-list.component.scss']
})
export class MealsListComponent implements OnInit {
  intSearchModel: IntSearchModel;
  mealCategories: any = [];
  mealDataSource: any = { data: [], count: 0 };
  constructor(
    private fb : FormBuilder,
    private mealService : MealService,
    private dialog: MatDialog
  ) { }

  searchForm:FormGroup;
  mealCategorySearchModel: MealCategorySearchModel=new MealCategorySearchModel();
  mealSearchModel: MealSearchModel = new MealSearchModel();
  displayMealColumnItems : string[] = [ 'Meal','Name', 'Order', 'Actions'];
 ngOnInit(): void {


  this.searchForm = this.fb.group({
    searchText : [''],
    selectedCategory:['']

  });
  this.mealCategorySearchModel= new MealCategorySearchModel();
  this.mealSearchModel = new MealSearchModel();
  this.intSearchModel = new IntSearchModel();

  this.mealSearchModel.SearchText='';
  this.mealSearchModel.MealCategoryId=null;
  this.mealSearchModel.OrderColumn='Name';
  this.mealSearchModel.OrderDirection='desc';
  this.mealSearchModel.RowsPerPage=10; 
  this.mealSearchModel.PageNumber=1;

  this.reloadMealTable(this.mealSearchModel);
  this.loadMealCategories(this.mealSearchModel)

}

    loadMealCategories(model: MealSearchModel): void {
      this.mealService.GetMealCategoriesForDropdown(this.mealCategorySearchModel).subscribe((result) => {
    this.mealCategories = result; 
    });
    }

    reloadMealTable(model: MealSearchModel){
    this.mealService.getMealsForGrid(model).subscribe((data) =>
    {
    this.mealDataSource = data;

    });
    }

    filterMeals(){
    this.mealSearchModel.SearchText = this.searchForm.value.searchText;
    this.mealSearchModel.MealCategoryId =this.searchForm.value.selectedCategory != null && this.searchForm.value.selectedCategory != '' ? 
        this.searchForm.value.selectedCategory.id :   null;
        
    this.reloadMealTable(this.mealSearchModel);
    }

    pageEvent(event:any ){
    this.mealSearchModel.PageNumber = event.pageIndex + 1;
    this.mealSearchModel.RowsPerPage = event.pageSize;

    this.reloadMealTable(this.mealSearchModel);
    }

    sortEvent(event:any){
    this.mealSearchModel.OrderDirection = event.direction;
    this.mealSearchModel.OrderColumn = event.active;

    this.reloadMealTable(this.mealSearchModel);
    }
    
    clear() {
    this.searchForm.reset();
    }

openDialog(id: number){
  const dialogRef = this.dialog.open(MealsDialogComponent, {
    data:id,
  });
  dialogRef.afterClosed().subscribe((result) => {
    if (result.event == 'Save')
      this.reloadMealTable(this.mealSearchModel);
  });
}

async openDeleteMealDailog(id : number, name : string){
  var message = "Дали сте сигурни дека сакате го избришете оброкот " + name + "?"
  const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
    data: message,
  });
  dialogRef.afterClosed().subscribe((result) =>{
    if(result.event == "Confirm"){
      this.deleteMeal(id);
    }
  });
}

deleteMeal(id : number){
  this.intSearchModel.Id = id;
  this.mealService.deleteMealById(this.intSearchModel).subscribe(() => {
    this.reloadMealTable(this.mealSearchModel);
  },
  (error : HttpErrorResponse) => { },
  (() => {}));
}

}
