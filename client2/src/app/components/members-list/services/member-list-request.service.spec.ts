import { TestBed } from '@angular/core/testing';

import { MemberListRequestService } from './member-list-request.service';

describe('MemberListRequestService', () => {
  let service: MemberListRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MemberListRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
