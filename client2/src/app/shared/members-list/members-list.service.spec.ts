import { TestBed } from '@angular/core/testing';

import { MembersListService } from './members-list.service';

describe('MembersListService', () => {
  let service: MembersListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MembersListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
