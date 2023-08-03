import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { FormsModule } from '@angular/forms';
import { SharedInputsModule } from 'src/app/shared/shared-inputs/shared-inputs.module';

@NgModule({
  declarations: [
    SearchBarComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    SharedInputsModule,
  ],
  exports: [
    SearchBarComponent,
  ],
})
export class SearchBarModule { }
