import { TestBed } from '@angular/core/testing';

import { SearchFiltersService } from './search-filters.service';

describe('SearchFilterService', () => {
  let service: SearchFiltersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchFiltersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
