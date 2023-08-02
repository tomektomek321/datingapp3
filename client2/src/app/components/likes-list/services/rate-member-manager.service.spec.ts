import { TestBed } from '@angular/core/testing';

import { RateMemberManagerService } from './rate-member-manager.service';

describe('RateMemberManagerService', () => {
  let service: RateMemberManagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RateMemberManagerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
