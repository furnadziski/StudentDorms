import { DropdownViewModel } from "src/app/shared/models/dropdown-view-model";

export class AccommodationCreateUpdateModel{
    public Id: number;
    public Year: number;
    public RoomId: number;
    public Users: DropdownViewModel[];
  }
