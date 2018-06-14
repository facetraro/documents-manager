import { TestBed, inject } from '@angular/core/testing';

import { GetAllUsersService } from './get-all-users.service';

describe('GetAllUsersService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GetAllUsersService]
    });
  });

  it('should be created', inject([GetAllUsersService], (service: GetAllUsersService) => {
    expect(service).toBeTruthy();
  }));
});
