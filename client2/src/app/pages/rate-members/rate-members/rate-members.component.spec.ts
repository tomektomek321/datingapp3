import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RateMembersComponent } from './rate-members.component';

describe('RateMembersComponent', () => {
  let component: RateMembersComponent;
  let fixture: ComponentFixture<RateMembersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RateMembersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RateMembersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
