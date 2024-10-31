
import { DropdownViewModel, DropdownViewModelGuid } from "src/app/shared/models/dropdown-view-model";

export class UserCreateUpdateModel{
    public Id: number;
    public FirstName: string;
    public LastName: string;
    public Username: string;
    public Email: string;
    public Roles: DropdownViewModel[];
    public GenderId: number;
    public IsActive: boolean;
    
    
}
