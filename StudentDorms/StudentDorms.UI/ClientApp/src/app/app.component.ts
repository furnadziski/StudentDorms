import { Component, OnInit } from '@angular/core';
import { UtilsService } from './shared/services/utils-service';
import { AppService } from './app.service';
import { SessionStorageService } from './shared/services/session-storage.service';
import { LoggedUserModel } from './shared/models/shared/logged-user-model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  public isExpanded = false;
  public isLoadedPermissions = false;
  loggedUser: LoggedUserModel;
  userContextLoaded: boolean = false;

  public constructor(private _appService: AppService,
    private _sessionStorageService: SessionStorageService){

  }
  ngOnInit(): void {
  }

  public toggleMenu() {
    this.isExpanded = !this.isExpanded;
  }
  


  getAppSettings() {
    

    var self = this;
    var appSettings = self._sessionStorageService.getAppSettings();

    if (!!!appSettings) {
      this._appService.getAppSettings(null, function (
        result: any
      ) {
        self._sessionStorageService.setAppSettings(result.appSettings);
      });
    }
  }


}
