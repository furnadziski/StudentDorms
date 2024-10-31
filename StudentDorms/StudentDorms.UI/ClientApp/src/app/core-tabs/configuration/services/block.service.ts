import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { SearchResult } from 'src/app/shared/models/search-result';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { BlockGridModel } from '../models/block-grid-model';
import { BlockSearchModel } from '../models/block-search-model';
import { BlockCreateUpdateModel } from '../models/block-create-update-model';

@Injectable({
  providedIn: 'root'
})
export class BlockService {

  constructor(private _repository: RepositoryService
  ) { }

  getBlocksForGrid(model: BlockSearchModel): Observable<SearchResult<BlockGridModel>> {
    return this._repository.ajaxCall("Config/GetBlocksForGrid", model, "POST");
  }

  updateBlock(model: BlockCreateUpdateModel) : Observable<void>{
    return this._repository.ajaxCall("Config/UpdateBlock", model, "POST");

  }
  createBlock(model: BlockCreateUpdateModel){
    return this._repository.ajaxCall("Config/CreateBlock", model, "POST");
  }

  GetBlockById(intSearchModel: IntSearchModel) : Observable<BlockCreateUpdateModel>{
    return this._repository.ajaxCall("Config/GetBlockById", intSearchModel, "POST");
  }
  deleteBlockById(intSearchModel: IntSearchModel){
    return this._repository.ajaxCall("Config/DeleteBlockById", intSearchModel, "POST");
  }
  GetBlocksForDropdown(any): Observable<any> {
    return this._repository.ajaxCall("Config/GetBlocksForDropdown",any,"POST");
}
GetBlocksForDropdownByStudentDormId(intSearchModel: IntSearchModel): Observable<any> {
  return this._repository.ajaxCall("Config/GetBlocksForDropdownByStudentDormId",intSearchModel,"POST");
}
}
