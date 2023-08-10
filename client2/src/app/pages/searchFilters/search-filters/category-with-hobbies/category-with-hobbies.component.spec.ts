import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryWithHobbiesComponent } from './category-with-hobbies.component';

describe('CategoryWithHobbiesComponent', () => {
  let component: CategoryWithHobbiesComponent;
  let fixture: ComponentFixture<CategoryWithHobbiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryWithHobbiesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryWithHobbiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
