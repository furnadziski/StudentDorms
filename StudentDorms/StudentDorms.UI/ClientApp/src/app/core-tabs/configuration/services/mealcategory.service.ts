import { Injectable } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { MealCategorySearchModel } from '../models/meal-category-search-model';
import { MealCategoryGridModel } from '../models/meal-category-grid-model';
import { SearchResult } from 'src/app/shared/models/search-result';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MealCategoryService {
  constructor(private _repository: RepositoryService
  ) { }

  getMealCategoriesForGrid(model: MealCategorySearchModel): Observable<SearchResult<MealCategoryGridModel>> {
    return this._repository.ajaxCall("Config/GetMealCategoriesForGrid", model, "POST");
  }
}
