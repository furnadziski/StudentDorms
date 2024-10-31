import { Component, OnInit } from '@angular/core';
import { MealService } from '../../configuration/services/meal.service';
import * as moment from 'moment';
import { FilterMealSearchModel } from '../../configuration/models/filter-meal-search-model';

@Component({
  selector: 'app-meals',
  templateUrl: './meals.component.html',
  styleUrls: ['./meals.component.scss']
})
export class MealsComponent implements OnInit {
  currentWeekStart: moment.Moment;
  weekRange: { start: string, end: string };
  weekDays = [
    { name: 'Понеделник', date: '', breakfast: '', lunch: '', dinner: '', breakfastPercent: 0, lunchPercent: 0, dinnerPercent: 0 },
    { name: 'Вторник', date: '', breakfast: '', lunch: '', dinner: '', breakfastPercent: 0, lunchPercent: 0, dinnerPercent: 0 },
    { name: 'Среда', date: '', breakfast: '', lunch: '', dinner: '', breakfastPercent: 0, lunchPercent: 0, dinnerPercent: 0 },
    { name: 'Четврток', date: '', breakfast: '', lunch: '', dinner: '', breakfastPercent: 0, lunchPercent: 0, dinnerPercent: 0 },
    { name: 'Петок', date: '', breakfast: '', lunch: '', dinner: '', breakfastPercent: 0, lunchPercent: 0, dinnerPercent: 0 },
    { name: 'Сабота', date: '', breakfast: '', lunch: '', dinner: '', breakfastPercent: 0, lunchPercent: 0, dinnerPercent: 0 },
    { name: 'Недела', date: '', breakfast: '', lunch: '', dinner: '', breakfastPercent: 0, lunchPercent: 0, dinnerPercent: 0 }
  ];

  constructor(private mealService: MealService) { }

  ngOnInit() {
    this.currentWeekStart = moment().startOf('isoWeek'); // Monday as start of week
    this.updateWeek();
  }

  updateWeek() {
    this.weekRange = {
      start: this.currentWeekStart.format('DD.MM.YYYY'),
      end: this.currentWeekStart.clone().endOf('isoWeek').format('DD.MM.YYYY')
    };
    this.loadMeals();
  }

  loadMeals() {
    const filter: FilterMealSearchModel = {
      startDateTime: this.currentWeekStart.toDate(),
      endDateTime: this.currentWeekStart.clone().endOf('isoWeek').toDate()
    };

    this.mealService.FilterMealSchedule(filter).subscribe(response => {
      const meals = response.mealDates.mealDate; 

      this.weekDays.forEach((day, index) => {
        const meal = meals[index];
        if (meal) {
          day.date = meal.date;
          day.breakfast = this.getMealName(meal.chosenMeals, 'Доручек');
          day.lunch = this.getMealName(meal.chosenMeals, 'Ручек');
          day.dinner = this.getMealName(meal.chosenMeals, 'Вечера');
          day.breakfastPercent = this.getMealPercent(meal.chosenMeals, 'Доручек');
          day.lunchPercent = this.getMealPercent(meal.chosenMeals, 'Ручек');
          day.dinnerPercent = this.getMealPercent(meal.chosenMeals, 'Вечера');
        } else {
          day.date = '';
          day.breakfast = 'Нема податоци';
          day.lunch = 'Нема податоци';
          day.dinner = 'Нема податоци';
          day.breakfastPercent = 0;
          day.lunchPercent = 0;
          day.dinnerPercent = 0;
        }
      });
    });
  }

  getMealName(chosenMeals: any, mealType: string): string {
    if (!chosenMeals) return 'Нема податоци';
    const meal = chosenMeals.chosenMeal.find((m: any) => m.mealCategoryName === mealType);
    return meal ? meal.name : 'Нема податоци';
  }

  getMealPercent(chosenMeals: any, mealType: string): number {
    if (!chosenMeals) return 0;
    const meal = chosenMeals.chosenMeal.find((m: any) => m.mealCategoryName === mealType);
    return meal ? parseFloat(meal.percents) : 0;
  }

  nextWeek() {
    this.currentWeekStart.add(1, 'week');
    this.updateWeek();
  }

  previousWeek() {
    this.currentWeekStart.subtract(1, 'week');
    this.updateWeek();
  }
}
