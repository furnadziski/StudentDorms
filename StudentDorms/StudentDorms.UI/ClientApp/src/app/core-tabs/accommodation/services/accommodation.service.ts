import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchResult } from 'src/app/shared/models/search-result';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { AccommodationSearchModel } from '../models/accommodation-search-model';
import { BlockGridModel } from '../../configuration/models/block-grid-model';
import { AccommodationGridModel } from '../models/accommodation-grid-model';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { UserWithRoleAndBlockSearchModel } from '../models/User-With-Role-And-Block-Search-Model';
import { AccommodationCreateUpdateModel } from '../models/accommodation-create-update-model';

@Injectable({
  providedIn: 'root'
})
export class AccommodationService {

  constructor(private _repository: RepositoryService
  ) { }

GetAnnualAccommodationsForGrid(model: AccommodationSearchModel): Observable<SearchResult<AccommodationGridModel>> {
  return this._repository.ajaxCall("AnnualAccommodation/GetAccommodationsForGrid", model, "POST");
}

GetUserWithRoleAndBlock(userWithRoleAndBlockSearchModel: UserWithRoleAndBlockSearchModel){
  return this._repository.ajaxCall("Config/GetUserWithRoleAndBlock", userWithRoleAndBlockSearchModel, "POST");
}
GetAccommodationById(intSearchModel: IntSearchModel) : Observable<AccommodationCreateUpdateModel>{
  return this._repository.ajaxCall("AnnualAccommodation/GetAccommodationById", intSearchModel, "POST");
}
updateAccommodation(model: AccommodationCreateUpdateModel) : Observable<void>{
  return this._repository.ajaxCall("AnnualAccommodation/UpdateAccommodation", model, "POST");

  

}

  }