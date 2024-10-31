import { Injectable } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { StudentDormSearchModel } from '../models/student-dorm-search-model';
import { Observable } from 'rxjs';
import { SearchResult } from 'src/app/shared/models/search-result';
import { StudentDormGridModel } from '../models/student-dorm-grid-model';
import { StudentDormCreateUpdateModel } from '../models/student-dorm-create-update-model';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { RestaurantCreateUpdateModel } from '../../food/models/restaurant-create-update-model';




@Injectable({
  providedIn: 'root'
})
export class StudentDormService {
 
  constructor(private _repository: RepositoryService
  ) { }

  getStudentDormsForGrid(model: StudentDormSearchModel): Observable<SearchResult<StudentDormGridModel>> {
    return this._repository.ajaxCall("Config/GetStudentDormsForGrid", model, "POST");
  }

  updateStudentDorm(model: StudentDormCreateUpdateModel) : Observable<void>{
    return this._repository.ajaxCall("Config/UpdateStudentDorm", model, "POST");

  }
  createStudentDorm(model: StudentDormCreateUpdateModel){
    return this._repository.ajaxCall("Config/CreateStudentDorm", model, "POST");
  }

  GetStudentDormById(intSearchModel: IntSearchModel) : Observable<StudentDormCreateUpdateModel>{
    return this._repository.ajaxCall("Config/GetStudentDormById", intSearchModel, "POST");
  }
  deleteStudentDormById(intSearchModel: IntSearchModel){
    return this._repository.ajaxCall("Config/DeleteStudentDormById", intSearchModel, "POST");
  }
 
  GetStudentDormsForDropdown(any): Observable<any> {
    return this._repository.ajaxCall("Config/GetStudentDormsForDropdown",any,"POST");

}
}