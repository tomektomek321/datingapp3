import { TestBed } from '@angular/core/testing';

import { LocalstoragePersistenceService } from './localstorage-persistence.service';

describe('LocalstoragePersistenceService', () => {
  let service: LocalstoragePersistenceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LocalstoragePersistenceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
