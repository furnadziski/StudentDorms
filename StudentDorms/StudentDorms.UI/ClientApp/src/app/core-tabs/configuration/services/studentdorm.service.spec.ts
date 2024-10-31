import { TestBed } from '@angular/core/testing';

import { StudentDormService } from './studentdorm.service';

describe('StudentdormService', () => {
  let service: StudentDormService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentDormService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
