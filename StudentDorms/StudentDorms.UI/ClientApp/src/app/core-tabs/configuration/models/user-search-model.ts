import { BaseSearchModel } from "src/app/shared/models/base-search-model";

export class UserSearchModel extends BaseSearchModel{
    public SearchText:string;
     RoleId: number;
     GenderId: number;
     IsActive: number;
}
