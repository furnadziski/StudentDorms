import { Inject, Injectable } from '@angular/core';
import { SESSION_STORAGE, StorageService } from 'ngx-webstorage-service';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SessionStorageService {

  loggedUserChange: Subject<any> = new Subject<any>();
  loggedUser: any;

  constructor(@Inject(SESSION_STORAGE) private _storage: StorageService) { 
  }

  getAccessToken() {
    return this._storage.get('access_token');
  }

  setAccessToken(result: any) {
    this._storage.set('access_token', result);
  }

  removeAccessToken(){
    this._storage.remove("access_token");
  }

  getAppSettings() {
    return this._storage.get('app_setting');
  }

  setAppSettings(result: any) {
    this._storage.set('app_setting', result);
  }

  getUser() {
    return this._storage.get("currentUser");
  }

  setUser(result: any) : any {
    this.loggedUser = result;
    this.loggedUserChange.next(this.loggedUser);
    return this._storage.set("currentUser", result);
  }

  removeUser(){
    this._storage.remove("currentUser");
  }
}
