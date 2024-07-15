import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RestaurantSearchModel } from '../../models/restaurant-search-model';
import { FoodService } from '../../services/food.service';
import { MatDialog } from '@angular/material/dialog';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { RestaurantDialogComponent } from '../restaurant-dialog/restaurant-dialog.component';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {
  searchForm:FormGroup;
  restaurantSearchModel: RestaurantSearchModel;
  intSearchModel: IntSearchModel;
  restaurantDataSource:any;
  displayRestaurantColumnItems : string[] = ['Name', 'Order', 'Participation', 'Actions'];


  constructor(private fb : FormBuilder,
              private foodService : FoodService,
              private dialog: MatDialog) { }

  ngOnInit(): void {
    this.searchForm = this.fb.group({
      searchText : [''],
    });

    this.restaurantSearchModel = new RestaurantSearchModel();
    this.intSearchModel = new IntSearchModel();

    this.restaurantSearchModel.SearchText='';
    this.restaurantSearchModel.OrderColumn='Participation';
    this.restaurantSearchModel.OrderDirection='desc';
    this.restaurantSearchModel.RowsPerPage=10; 
    this.restaurantSearchModel.PageNumber=1;

    this.reloadRestaurantTable(this.restaurantSearchModel);

  }

  async reloadRestaurantTable(model: RestaurantSearchModel){
    await this.foodService.getRestaurantForGrid(model).subscribe((data) => {
      this.restaurantDataSource = data;
    });
  }

  filterRestaurant(){
    this.restaurantSearchModel.SearchText = this.searchForm.value.searchText;
    this.reloadRestaurantTable(this.restaurantSearchModel);
  }

  pageEvent(event:any ){
    this.restaurantSearchModel.PageNumber = event.pageIndex + 1;
    this.restaurantSearchModel.RowsPerPage = event.pageSize;

    this.reloadRestaurantTable(this.restaurantSearchModel);
  }

  sortEvent(event:any){
    this.restaurantSearchModel.OrderDirection = event.direction;
    this.restaurantSearchModel.OrderColumn = event.active;

    this.reloadRestaurantTable(this.restaurantSearchModel);
  }

  async openDialog(id: number){
    const dialogRef = this.dialog.open(RestaurantDialogComponent, {
      data:id,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result.event == 'Save')
        this.reloadRestaurantTable(this.restaurantSearchModel);
    });
  }

  async openDeleteRestaurantDailog(id : number, name : string){
    var message = "Дали сте сигурни дека сакате го избришете соодветниот ресторан " + name + "?"
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: message,
    });
    dialogRef.afterClosed().subscribe((result) =>{
      if(result.event == "Confirm"){
        this.deleteRestaurant(id);
      }
    });
  }

  deleteRestaurant(id : number){
    this.intSearchModel.Id = id;
    this.foodService.deleteRestaurantById(this.intSearchModel).subscribe(() => {
      this.reloadRestaurantTable(this.restaurantSearchModel);
    },
    (error : HttpErrorResponse) => { },
    (() => {}));
  }

  clear() {
    this.searchForm.reset();
  }

}
