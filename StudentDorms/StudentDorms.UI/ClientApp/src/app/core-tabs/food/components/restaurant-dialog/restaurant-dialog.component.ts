import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RestaurantCreateUpdateModel } from '../../models/restaurant-create-update-model';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { ErrorMessages } from 'src/app/shared/models/error-messages';
import { FoodService } from '../../services/food.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-restaurant-dialog',
  templateUrl: './restaurant-dialog.component.html',
  styleUrls: ['./restaurant-dialog.component.scss']
})
export class RestaurantDialogComponent implements OnInit {
  dataSource;
  restaurantUpdateForm: FormGroup;
  label:string;
  restaurantCreateUpdateModel: RestaurantCreateUpdateModel;
  intRestaurantSearchModel : IntSearchModel;
  intSearchModel: IntSearchModel;
  isLoaded: boolean = false;
  getErrorMessage= ErrorMessages.getErrorMessage;

  constructor(
    private FoodService: FoodService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<RestaurantDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public restaurantId: number
  ) { }

  ngOnInit(): void {
    this.dialogRef.disableClose = true;
    
    this.restaurantCreateUpdateModel = new RestaurantCreateUpdateModel();
    this.intRestaurantSearchModel = new IntSearchModel();
    this.intSearchModel = new IntSearchModel();
    this.restaurantUpdateForm = this.fb.group({
      restaurantName:['', [Validators.required, Validators.maxLength(50)]],
      order: ['',[Validators.required]],
      participation: ['', [Validators.required]],
    });

    if( this.restaurantId != null){   
      this.getRestaurantForUpdate(this.restaurantId);
      this.label = 'Измени ресторан'
    }
    else{
      this.label = 'Додади ресторан'
    }
  }
  getRestaurantForUpdate(id:number){
    this.intRestaurantSearchModel.Id = id;
    this.FoodService.getRestaurantForUpdate(this.intRestaurantSearchModel).subscribe((data)=>{
      this.dataSource = data
      this.restaurantUpdateForm.patchValue({
        restaurantName: this.dataSource.name,
        order: this.dataSource.order,
        participation: this.dataSource.participation
      });
      this.isLoaded = true;
    });
  }

  save(){
    
      this.restaurantCreateUpdateModel.Name = this.restaurantUpdateForm.value.restaurantName;
      this.restaurantCreateUpdateModel.Order = this.restaurantUpdateForm.value.order;
      this.restaurantCreateUpdateModel.Participation = this.restaurantUpdateForm.value.participation;

    if(this.restaurantId != null)
    {
      this.restaurantCreateUpdateModel.Id = this.dataSource.id;
          this.FoodService
            .updateRestaurant(this.restaurantCreateUpdateModel)
            .subscribe(()=> {
              this.dialogRef.close({event: 'Save'});
            });
    }
    else {
      this.FoodService
            .createRestaurant(this.restaurantCreateUpdateModel)
            .subscribe(()=>{
              this.dialogRef.close({event: 'Save'});
            });
    }
  }

  close(){
    this.dialogRef.close({event: 'Cancel'});
  }

}
