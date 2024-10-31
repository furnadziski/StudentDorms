import { TestBed } from '@angular/core/testing';

import { MealCategoryService } from './mealcategory.service';

describe('MealCategoryService', () => {
  let service: MealCategoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MealCategoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
