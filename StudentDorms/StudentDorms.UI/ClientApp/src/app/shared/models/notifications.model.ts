import { Guid } from 'guid-typescript';
import { DropdownViewModel } from './dropdown-view-model';
import { BaseSearchModel } from './base-search-model';

export class NotificationTemplateCreateUpdateModel{
    public Subject: string;
    public Body: string;
    public ObjectType: DropdownViewModel;
    public IsActive: boolean;
    public Id: Guid = null;
}

export class NotificationTemplateSearchModel extends BaseSearchModel{
    public SearchText: string;
    public ObjectTypeId: number = null;
    public IsActive: number = null;
}

export class NotificationTemplateGridModel{
    public Subject: string;
    public ObjectType: string;
    public IsActive: string;
    public Id: Guid;
}