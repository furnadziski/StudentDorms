import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { MealCategoryService } from '../../services/mealcategory.service';
import { MealCategorySearchModel } from '../../models/meal-category-search-model';

@Component({
  selector: 'app-meal-category-list',
  templateUrl: './meal-category-list.component.html',
  styleUrls: ['./meal-category-list.component.scss']
})
export class MealCategoryListComponent implements OnInit {
  intSearchModel: IntSearchModel;
  constructor(
    private fb : FormBuilder,
    private mealCategoryService : MealCategoryService,
    private dialog: MatDialog
  ) { }

  searchForm:FormGroup;
  mealCategoryDataSource: any = { data: [], count: 0 };
  mealCategorySearchModel: MealCategorySearchModel = new MealCategorySearchModel();
  displayMealCategoriesColumnItems : string[] = ['Name', 'Order'];
 ngOnInit(): void {
  this.searchForm = this.fb.group({
    searchText : [''],
  });
  
  this.mealCategorySearchModel = new MealCategorySearchModel();
  this.intSearchModel = new IntSearchModel();

  this.mealCategorySearchModel.SearchText='';
  this.mealCategorySearchModel.OrderColumn='Name';
  this.mealCategorySearchModel.OrderDirection='desc';
  this.mealCategorySearchModel.RowsPerPage=10; 
  this.mealCategorySearchModel.PageNumber=1;

  this.reloadMealCategoryTable(this.mealCategorySearchModel);

}
reloadMealCategoryTable(model: MealCategorySearchModel){
  this.mealCategoryService.getMealCategoriesForGrid(model).subscribe((data) => {
    this.mealCategoryDataSource = data;

  });
}

filterMealCategories(){
  this.mealCategorySearchModel.SearchText = this.searchForm.value.searchText;
  this.reloadMealCategoryTable(this.mealCategorySearchModel);
}

pageEvent(event:any ){
  this.mealCategorySearchModel.PageNumber = event.pageIndex + 1;
  this.mealCategorySearchModel.RowsPerPage = event.pageSize;

  this.reloadMealCategoryTable(this.mealCategorySearchModel);
}

sortEvent(event:any){
  this.mealCategorySearchModel.OrderDirection = event.direction;
  this.mealCategorySearchModel.OrderColumn = event.active;

  this.reloadMealCategoryTable(this.mealCategorySearchModel);
}
clear() {
  this.searchForm.reset();
}


}


