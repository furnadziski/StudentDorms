import { Injectable } from '@angular/core';
import { RestaurantSearchModel } from '../models/restaurant-search-model';
import { RestaurantGridModel } from '../models/restaurant-grid-model';
import { Observable } from 'rxjs';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { RestaurantCreateUpdateModel } from '../models/restaurant-create-update-model';
import { DropdownViewModel } from 'src/app/shared/models/dropdown-view-model';
import { SearchResult } from 'src/app/shared/models/search-result';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Injectable({
  providedIn: 'root'
})
export class FoodService {

  constructor(private _repository: RepositoryService
  ) { }

  getRestaurantForGrid(model: RestaurantSearchModel): Observable<SearchResult<RestaurantGridModel>> {
    //return this._repository.ajaxCall("Restaurant/GetRestaurantsForGrid", model, "POST");
    return this._repository.ajaxCall("Restaurant/TestMethod", null, "POST");
  }

  getRestaurantForUpdate(intSearchModel: IntSearchModel) : Observable<RestaurantCreateUpdateModel>{
    return this._repository.ajaxCall("Restaurant/GetRestaurantById", intSearchModel, "POST");
  }

  updateRestaurant(model: RestaurantCreateUpdateModel) : Observable<void>{
    return this._repository.ajaxCall("Restaurant/UpdateRestaurant", model, "POST");
  }

  createRestaurant(model: RestaurantCreateUpdateModel){
    return this._repository.ajaxCall("Restaurant/CreateRestaurant", model, "POST");
  }

  deleteRestaurantById(intSearchModel: IntSearchModel){
    return this._repository.ajaxCall("Restaurant/DeleteRestaurantById", intSearchModel, "POST");
  }

  getRestaurantForDropdownAsync(): Observable<DropdownViewModel[]> {
    return this._repository.ajaxCall("Restaurant/GetRestaurantsForDropdown", null, "POST");
  }
}
