import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HobbyButtonComponent } from './hobby-button.component';

describe('HobbyButtonComponent', () => {
  let component: HobbyButtonComponent;
  let fixture: ComponentFixture<HobbyButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HobbyButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HobbyButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
