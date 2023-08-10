import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryWallnameComponent } from './category-wallname.component';

describe('CategoryWallnameComponent', () => {
  let component: CategoryWallnameComponent;
  let fixture: ComponentFixture<CategoryWallnameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryWallnameComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryWallnameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
