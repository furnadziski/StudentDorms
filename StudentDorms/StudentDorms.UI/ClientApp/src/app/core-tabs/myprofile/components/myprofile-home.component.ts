import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RouteLink } from 'src/app/shared/models/route-link.interface';
import { UserSearchModel } from '../../configuration/models/user-search-model';
import { UserService } from '../../configuration/services/users.service';
import { MyProfileSearchModel } from '../../configuration/models/my-profile-search-model';
import { MealService } from '../../configuration/services/meal.service';
import moment from 'moment';
import { FilterMealSearchModel } from '../../configuration/models/filter-meal-search-model';
import { MyprofileDialogComponent } from './myprofile-dialog/myprofile-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-myprofile-home',
  templateUrl: './myprofile-home.component.html',
  styleUrls: ['./myprofile-home.component.scss']
})
export class MyprofileHomeComponent implements OnInit {
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
  routeLinks: RouteLink[] = [];
  routerLinkActive: string = "routerlinkActive";
  myProfileSearchModel :MyProfileSearchModel;
   profile: any = { data: [], count: 0 };
  
  constructor(private route: ActivatedRoute,
    private router: Router,
    private userService : UserService,
    private mealService: MealService,
    private dialog: MatDialog) { 
          
     }

     
  ngOnInit(): void {
    this.myProfileSearchModel=new MyProfileSearchModel();
    this.loadTabs();
    this.myProfileSearchModel.UserId=1;
    this.loadUser(this.myProfileSearchModel);

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

  loadUser(model: MyProfileSearchModel): void {
    this.userService.GetUserForMyProfile(this.myProfileSearchModel).subscribe((data) => {
  this.profile = data; 
   });
  }

  setActiveTab(index){
    this.routeLinks.forEach((link, i) => {
      link.isActive = i === index;
    });
  }

  loadTabs() {
    this.routeLinks.push({ routerLink: "meals", routerLinkActive: "routerLinkActive", title: "Оброци", isActive: true, name: "tab_Meals", order: 1 })
     this.routeLinks.push({ routerLink: "payments", routerLinkActive: "routerLinkActive", title: "Плаќања", isActive: true, name: "tab_Departments", order: 2 })
     this.routeLinks.push({ routerLink: "tickets", routerLinkActive: "routerLinkActive", title: "Тикети", isActive: true, name: "tab_Roles", order: 3 })
   
  }

  openDialog(){
    const dialogRef = this.dialog.open(MyprofileDialogComponent, {
      
    });
      }
}