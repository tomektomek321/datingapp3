import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RateMemberCardComponent } from './rate-member-card.component';

describe('RateMemberCardComponent', () => {
  let component: RateMemberCardComponent;
  let fixture: ComponentFixture<RateMemberCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RateMemberCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RateMemberCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
