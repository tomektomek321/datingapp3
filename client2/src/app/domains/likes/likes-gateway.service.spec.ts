import { TestBed } from '@angular/core/testing';

import { LikesGatewayService } from './likes-gateway.service';

describe('LikesGatewayService', () => {
  let service: LikesGatewayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LikesGatewayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
