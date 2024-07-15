import { Injectable } from '@angular/core';
import * as $ from 'jquery';
import { Observable, catchError, tap } from 'rxjs';
import { SessionStorageService } from './session-storage.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UtilsService } from './utils-service';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  @BlockUI() blockUI: NgBlockUI;

  constructor(private _sessionStorageService: SessionStorageService,
    private _http: HttpClient,
    private _utils: UtilsService
  ) { }

  blockUIChangeState(){
    if (!this.blockUI.isActive)
        this.blockUI.start();
    else if (this.blockUI.isActive)
        this.blockUI.stop();
  }

  syncAjaxLocal(url: string, data: any, success: any, method: any) {
    var self = this;
    if (method == undefined)
        method = "POST";

    if (method == "GET")
        data = data;
    else
        data = JSON.stringify(data);

    var ajaxSettings = {
        mode: "queue",
        url: url,
        async: false,
        cache: false,
        contentType: "application/json; charset=utf-8",
        type: method,
        data: data,
        dataType: "json",
        success: function (d: any, s: any, x: any) {
            self.blockUIChangeState();

            if (d == null) {
                response = d;
            }
            else if (d.hasOwnProperty("d")) {
                var response = JSON.parse(d.d);
            } else {
                response = d;
            }
            success(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            self.blockUIChangeState();
            self._utils.handleError(xhr.responseJSON, xhr.status);
        }
    };

    $.ajax(ajaxSettings);
}

ajaxCall(url: string, dataForSend: any, method: string, local: boolean = false): Observable<any>{

    this.blockUIChangeState();

    if (method == undefined)
        method = "POST";

    if(method == "GET"){
        return this._http.get<any>("http://api-coms.test/" + url, { params: dataForSend }).pipe(
            tap(data => {
                this.blockUIChangeState();
                return data;
            }),
            catchError(err => {
               this.blockUIChangeState();
                return this._utils.handleError(err.error, err.status);
           })
        );
    }
    else if(method == "POST"){
        return this._http.post<any>("http://api-coms.test/" + url, dataForSend).pipe(
            tap(data => {
                this.blockUIChangeState();
                return data;
            }),
            catchError(err => {
                this.blockUIChangeState();
                return this._utils.handleError(err.error, err.status);
            })
        );
    }
    return null;
  }
}
