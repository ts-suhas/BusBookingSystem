import { TestBed } from '@angular/core/testing';

import { BookingManagmentService } from './booking-managment.service';

describe('BookingManagmentService', () => {
  let service: BookingManagmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookingManagmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
