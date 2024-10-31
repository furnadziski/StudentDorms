import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchResult } from 'src/app/shared/models/search-result';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { MealGridModel } from '../models/meal-grid-model';
import { MealSearchModel } from '../models/meal-search-model';
import { MealCreateUpdateModel } from '../models/meal-create-update-model';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { FilterMealSearchModel } from '../models/filter-meal-search-model';
import { FilterMealVotingSearchModel } from '../../myprofile/models/filterMealVotingSearchModel';

@Injectable({
  providedIn: 'root'
})
export class MealService {
  constructor(private _repository: RepositoryService
  ) { }

  getMealsForGrid(model: MealSearchModel): Observable<SearchResult<MealGridModel>> {
    return this._repository.ajaxCall("Config/GetMealsForGrid", model, "POST");
  }

  updateMeal(model: MealCreateUpdateModel) : Observable<void>{
    return this._repository.ajaxCall("Config/UpdateMeal", model, "POST");

  }
  createMeal(model: MealCreateUpdateModel){
    return this._repository.ajaxCall("Config/CreateMeal", model, "POST");
  }

  GetMealById(intSearchModel: IntSearchModel) : Observable<MealCreateUpdateModel>{
    return this._repository.ajaxCall("Config/GetMealById", intSearchModel, "POST");
  }
  deleteMealById(intSearchModel: IntSearchModel){
    return this._repository.ajaxCall("Config/DeleteMealById", intSearchModel, "POST");
  }
  GetMealCategoriesForDropdown(any): Observable<any> {
    return this._repository.ajaxCall("Config/GetMealCategoriesForDropdown",any,"POST");
}
GetMealsForDropdown(intSearchModel: IntSearchModel): Observable<any> {
  return this._repository.ajaxCall("Config/GetMealsForDropdown",intSearchModel,"POST");
}

FilterMealSchedule(model: FilterMealSearchModel){
  return this._repository.ajaxCall("Config/FilterMealSchedule", model, "POST");
}
FilterMealVoting(model: FilterMealVotingSearchModel){
  return this._repository.ajaxCall("Config/FilterMealVoting", model, "POST");
}

SaveMealVote(any): Observable<any> {
  return this._repository.ajaxCall("Config/SaveMealVote",any,"POST");
}

}


