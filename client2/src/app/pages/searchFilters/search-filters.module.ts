import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HobbyButtonComponent } from './search-filters/category-with-hobbies/hobby-button/hobby-button.component';
import { CategoryWallnameComponent } from './search-filters/category-with-hobbies/category-wallname/category-wallname.component';
import { CategoryWithHobbiesComponent } from './search-filters/category-with-hobbies/category-with-hobbies.component';
import { SearchFiltersComponent } from './search-filters/search-filters.component';
import { SharedModule } from 'src/app/shared/libs/shared.module';
import { SharedInputsModule } from 'src/app/shared/shared-inputs/shared-inputs.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    HobbyButtonComponent,
    CategoryWallnameComponent,
    CategoryWithHobbiesComponent,
    SearchFiltersComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedInputsModule,

    SharedModule,
  ],
  exports: [
    HobbyButtonComponent,
    CategoryWallnameComponent,
    CategoryWithHobbiesComponent,
    SearchFiltersComponent,
  ],
})
export class SearchFiltersModule { }
