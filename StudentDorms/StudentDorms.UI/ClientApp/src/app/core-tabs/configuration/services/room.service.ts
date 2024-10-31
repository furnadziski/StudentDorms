import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchResult } from 'src/app/shared/models/search-result';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { RoomSearchModel } from '../models/room-search-model';
import { RoomGridModel } from '../models/room-grid-model';
import { RoomCreateUpdateModel } from '../models/room-create-update-model';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';


@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private _repository: RepositoryService
  ) { }
  
  getRoomsForGrid(model: RoomSearchModel): Observable<SearchResult<RoomGridModel>> {
    return this._repository.ajaxCall("Config/GetRoomsForGrid", model, "POST");
  }
  updateRoom(model: RoomCreateUpdateModel) : Observable<void>{
    return this._repository.ajaxCall("Config/UpdateRoom", model, "POST");

  }
  createRoom(model: RoomCreateUpdateModel){
    return this._repository.ajaxCall("Config/CreateRoom", model, "POST");
  }

  GetRoomById(intSearchModel: IntSearchModel) : Observable<RoomCreateUpdateModel>{
    return this._repository.ajaxCall("Config/GetRoomById", intSearchModel, "POST");
  }
  DeleteRoomById(intSearchModel: IntSearchModel){
    return this._repository.ajaxCall("Config/DeleteRoomById", intSearchModel, "POST");
  }
  GetRoomsForDropdown(any): Observable<any> {
    return this._repository.ajaxCall("Config/GetRoomsForDropdown",any,"POST");
}
GetRoomsForDropdownByBlockId(intSearchModel: IntSearchModel): Observable<any> {
  return this._repository.ajaxCall("Config/GetRoomsForDropdownByBlockId",intSearchModel,"POST");
}
  

}
