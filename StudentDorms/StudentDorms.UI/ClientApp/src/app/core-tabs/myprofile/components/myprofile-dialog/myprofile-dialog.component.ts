import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import moment from 'moment';
import { MealService } from 'src/app/core-tabs/configuration/services/meal.service';

import { MealCategoriesEnum } from 'src/app/shared/models/enums/meal-categories.enum';
import { IntSearchModel } from 'src/app/shared/models/int-search-model';
import { weekDaysModel } from '../../models/weekDaysModel';
import { SaveMealVoteGridModel } from '../../models/saveMealVoteGridModel';
import { FilterMealVotingSearchModel } from '../../models/filterMealVotingSearchModel';

@Component({
  selector: 'app-myprofile-dialog',
  templateUrl: './myprofile-dialog.component.html',
  styleUrls: ['./myprofile-dialog.component.scss']
})
export class MyprofileDialogComponent implements OnInit {
  saveMealVoteGridModel: SaveMealVoteGridModel;
  filterMealVotingSearchModel: FilterMealVotingSearchModel;
  currentWeekStart: moment.Moment;
  weekRange: { start: string, end: string };
  deadlineDate: string; 
  weekDays: weekDaysModel[] = [];
  meals: { [key: number]: any[] } = {};
  intCategorySearchModel: IntSearchModel;

  breakfastid = MealCategoriesEnum.breakfast;
  lunchid = MealCategoriesEnum.lunch;
  dinnerid = MealCategoriesEnum.dinner;
  public MealCategoryId = {
    breakfast: this.breakfastid,
    lunch: this.lunchid,
    dinner: this.dinnerid
  };

  constructor(private mealService: MealService, private dialogRef: MatDialogRef<MyprofileDialogComponent>) {}

  ngOnInit(): void {
    this.saveMealVoteGridModel = new SaveMealVoteGridModel();
    this.filterMealVotingSearchModel = new FilterMealVotingSearchModel();
    this.currentWeekStart = moment().add(1, 'week').startOf('isoWeek');
    this.updateWeek();
    this.intCategorySearchModel = new IntSearchModel();
  
    this.loadMeals(this.MealCategoryId.breakfast);
    this.loadMeals(this.MealCategoryId.lunch);
    this.loadMeals(this.MealCategoryId.dinner);
    
    this.loadUserVotes();
  }

  updateWeek() {
    this.weekRange = {
      start: this.currentWeekStart.format('DD.MM.YYYY'), 
      end: this.currentWeekStart.clone().endOf('isoWeek').format('DD.MM.YYYY') 
    };
    this.deadlineDate = this.currentWeekStart.clone().isoWeekday(4).format('DD.MM.YYYY');
    this.generateWeekDays();
  }

  loadMeals(categoryId: number): void {
    this.intCategorySearchModel.Id = categoryId;
    this.mealService.GetMealsForDropdown(this.intCategorySearchModel).subscribe((result) => {
      this.meals[categoryId] = result; 
    });
  }

  generateWeekDays() {
    this.weekDays = [];
    for (let i = 0; i < 7; i++) {
      const day = this.currentWeekStart.clone().add(i, 'days');
      this.weekDays.push({
        name: day.format('dddd'),
        date: day.format('YYYY-MM-DDTHH:mm:ss'),
        breakfast: { id: null, title: '' },
        lunch: { id: null, title: '' },
        dinner: { id: null, title: '' },
      });
    }
  }

  loadUserVotes(): void {
    this.filterMealVotingSearchModel.UserId = this.getCurrentUserId();
    
    this.mealService.FilterMealVoting(this.filterMealVotingSearchModel).subscribe((response) => {
        if (response && response.mealDates && response.mealDates.mealDate) {
            const mealDates = response.mealDates.mealDate;      
            mealDates.forEach(vote => {                
                const voteDate = moment(vote.date).format('YYYY-MM-DD');
                const day = this.weekDays.find(d => moment(d.date).format('YYYY-MM-DD') === voteDate);

                if (day) {
                    if (vote.chosenMeals && vote.chosenMeals.chosenMeal) {
                        vote.chosenMeals.chosenMeal.forEach(chosenMeal => {
                            const meal = { id: chosenMeal.mealId, title: chosenMeal.mealName };

                            switch (chosenMeal.mealCategoryId) {
                                case this.breakfastid:
                                    day.breakfast = meal; 
                                    break;
                                case this.lunchid:
                                    day.lunch = meal; 
                                    break;
                                case this.dinnerid:
                                    day.dinner = meal;
                                    break;
                            }
                        });
                    }
                }
            });
        }
        
    });
}

  save() {
    const mealVoteGridModels: SaveMealVoteGridModel[] = [];
    this.weekDays.forEach(day => {
      if (day.breakfast && day.breakfast.id) {
        mealVoteGridModels.push({
          MealId: day.breakfast.id,
          MealCategoryId: this.breakfastid,
          UserId: this.getCurrentUserId(),
          Date: moment(day.date).toDate(),
        });
      }
  
      if (day.lunch && day.lunch.id) {
        mealVoteGridModels.push({
          MealId: day.lunch.id,
          MealCategoryId: this.lunchid,
          UserId: this.getCurrentUserId(),
          Date: moment(day.date).toDate(),
        });
      }
  
      if (day.dinner && day.dinner.id) {
        mealVoteGridModels.push({
          MealId: day.dinner.id,
          MealCategoryId: this.dinnerid,
          UserId: this.getCurrentUserId(),
          Date: moment(day.date).toDate(),
        });
      }
    });
    
    this.mealService.SaveMealVote(mealVoteGridModels).subscribe(() => {
      this.dialogRef.close({ event: 'Save' });
    });
  }

  close() {
    this.dialogRef.close({ event: 'Cancel' });
  }

  getCurrentUserId() {
    return 2; 
  }
}
