import { BaseSearchModel } from "src/app/shared/models/base-search-model";

export class AccommodationSearchModel extends BaseSearchModel{
  public Year: number;
  public BlockId: number;
  public StudentDormId: number;
  public HasFreeSpaceOnly: boolean;
  public CapacitySearch: number;
  public Userid: number;
  public RoomSearchText:string;
 
}
