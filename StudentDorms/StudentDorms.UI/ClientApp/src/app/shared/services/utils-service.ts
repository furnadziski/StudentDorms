import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FieldPermissionModel } from "../models/field-permission-model";
import { PermissionLevelEnum } from "../models/permission-level-enum";
import { RedirectRuleEnum } from "../models/enums/redirect-rule.enum";
import { Router } from "@angular/router";
import { ErrorStatusCodeEnum } from "../models/error-status-code-enum";
import { ErrorDialogComponent } from "../components/error-dialog/error-dialog.component";
import { MatDialog } from "@angular/material/dialog";
import { throwError } from "rxjs";
import { ErrorModel } from "../models/shared/error.model";

@Injectable({
  providedIn: 'root',
})
export class UtilsService {

  public static fieldPermissions: Array<FieldPermissionModel> = [];
  public static systemFieldPermissions: Array<FieldPermissionModel> = [];

  constructor(private http: HttpClient,
              private router: Router,
              private dialog: MatDialog) { 
  }

  handleError(err: HttpErrorResponse, status: number) {
    var error = JSON.parse(err.error);

    if (typeof error === 'object') {

      if (error.hasOwnProperty('Message')) {

        switch (status) {
          case ErrorStatusCodeEnum.StudentDormsError:
          case ErrorStatusCodeEnum.InternalServerError: {
            this.dialog.open(ErrorDialogComponent, {
              width: '500px',
              disableClose: true,
              data: error.Message
            });
            break;
          }
          case ErrorStatusCodeEnum.TokenExpired: {
            location.href = "/Home/Index";
            break;
          }
          case ErrorStatusCodeEnum.UserNotActive: {
            this.router.navigate(['user-not-active']);
            break;
          }
          case ErrorStatusCodeEnum.UserNotRegistered: {
              this.router.navigate(['user-not-registered']);
              break;
          }
          case ErrorStatusCodeEnum.Unauthorized: {
              this.router.navigate(['un-authorized']);
              break;
          }
          default: {
            this.dialog.open(ErrorDialogComponent, {
              width: '500px',
              disableClose: true,
              data: error.Message
            });
            break;
          }
        }

      }
      else if (error.hasOwnProperty('Errors')) {

        // format model
        var errorModel: any = {};
        error.Errors.forEach(function (item: ErrorModel) {
          errorModel[item.Key] = item.Message;
        });

        return throwError(errorModel);

      }
      else {

        this.dialog.open(ErrorDialogComponent, {
          width: '500px',
          disableClose: true,
          data: error.Message
        });

      }
    }

    return throwError(err.error);
  }

  
}
