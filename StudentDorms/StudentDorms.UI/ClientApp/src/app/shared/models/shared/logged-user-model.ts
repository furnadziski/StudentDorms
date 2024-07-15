import { DropdownViewModel } from "../dropdown-view-model";

export class LoggedUserModel {
    public Id: number = 0;
    public FirstName: string = '';
    public LastName: string = '';
    public Username: string = '';
    public Email: string = '';
    // public DefaultLanguageId: number = 0;
    public Image: number[] = [];
    // public Image: string = ''
    // public ImageThumbnail: string = '';
    // public Department: number = 0;
    public Roles: string = '';
    // public Roles: DropdownViewModel[] = [];
}