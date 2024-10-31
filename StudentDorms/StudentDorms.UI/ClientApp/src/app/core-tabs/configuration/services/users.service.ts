import { Injectable } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { UserSearchModel } from '../models/user-search-model';
import { Observable } from 'rxjs';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { SearchResult } from 'src/app/shared/models/search-result';
import { RoomCreateUpdateModel } from '../models/room-create-update-model';
import { UserGridModel } from '../models/user-grid-model';
import { UserCreateUpdateModel } from '../models/user-create-update-model';
import { MyProfileGridModel } from '../models/my-profile-grid-model';
import { MyProfileSearchModel } from '../models/my-profile-search-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private _repository: RepositoryService  ) { }
  
  getUsersForGrid(model: UserSearchModel): Observable<SearchResult<UserGridModel>> {
    return this._repository.ajaxCall("Config/GetUsersForGrid", model, "POST");
  }

  GetRolesForDropdown(any): Observable<any> {
    return this._repository.ajaxCall("Config/GetRolesForDropdown",any,"POST");
  }

  GetGendersForDropdown(any): Observable<any> {
   return this._repository.ajaxCall("Config/GetGendersForDropdown",any,"POST");
} 
  GetStudentsForDropDown(any): Observable<any> {
  return this._repository.ajaxCall("Config/GetStudentsForDropDown",any,"POST");
} 


  updateUser(model: UserCreateUpdateModel) : Observable<void>{
    return this._repository.ajaxCall("Config/UpdateUser", model, "POST");

  }
  createUser(model: UserCreateUpdateModel){
    return this._repository.ajaxCall("Config/createUser", model, "POST");
  }

  GetUserById(intSearchModel: IntSearchModel) : Observable<UserCreateUpdateModel>{
    return this._repository.ajaxCall("Config/GetUserById", intSearchModel, "POST");
  }
 
  GetUserForMyProfile(myProfileSearchModel: MyProfileSearchModel) : Observable<MyProfileGridModel>{
    return this._repository.ajaxCall("Config/GetUserForMyProfile", myProfileSearchModel, "POST");
  }
  

}
