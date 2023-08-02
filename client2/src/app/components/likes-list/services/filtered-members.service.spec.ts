import { TestBed } from '@angular/core/testing';

import { FilteredMembersService } from './filtered-members.service';

describe('FilteredMembersService', () => {
  let service: FilteredMembersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FilteredMembersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
