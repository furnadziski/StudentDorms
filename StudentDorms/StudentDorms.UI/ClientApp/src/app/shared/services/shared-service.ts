import { HttpClient } from "@angular/common/http";
import { DropdownViewModel } from "../models/dropdown-view-model";
import { Observable, finalize } from "rxjs";
import { Injectable } from "@angular/core";
import { RepositoryService } from "./repository.service";

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor(private http: HttpClient,
    private _repository: RepositoryService
  ) { }

  getAllOptionsForDropdown(): Observable<DropdownViewModel[]> {
    return this._repository.ajaxCall("Shared/GetBooleanOptionsForDropdown", null, "POST");
  }


  getGroupingOptions(): Observable<any> {
    return this._repository.ajaxCall("Shared/GetGroupingOptions", null, "POST");
  }
}