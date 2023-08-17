import { TestBed } from '@angular/core/testing';

import { SearchFilterRqService } from './search-filter-rq.service';

describe('SearchFilterRqService', () => {
  let service: SearchFilterRqService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchFilterRqService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
