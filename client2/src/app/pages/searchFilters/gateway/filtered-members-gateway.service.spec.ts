import { TestBed } from '@angular/core/testing';

import { FilteredMembersGatewayService } from './filtered-members-gateway.service';

describe('FilteredMembersGatewayService', () => {
  let service: FilteredMembersGatewayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FilteredMembersGatewayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
