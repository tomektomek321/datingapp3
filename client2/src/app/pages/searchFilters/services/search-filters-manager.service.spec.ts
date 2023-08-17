import { TestBed } from '@angular/core/testing';

import { SearchFiltersManagerService } from './search-filters-manager.service';

describe('SearchFiltersManagerService', () => {
  let service: SearchFiltersManagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchFiltersManagerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
