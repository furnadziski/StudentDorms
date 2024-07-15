import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RepositoryService } from './shared/services/repository.service';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  private wfCommentByTransition: string;

  constructor(private http: HttpClient,
    private _repository: RepositoryService
  ) { }



  //#region AppSettings
    getAppSettings(data: any, successcb: any) {
      this._repository.syncAjaxLocal("Home/GetAppSettings", data, function (result: any) {
        successcb(result);
      }, "GET");
    }
  //#endregion


}
