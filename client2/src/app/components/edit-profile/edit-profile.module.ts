import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedInputsModule } from 'src/app/shared/shared-inputs/shared-inputs.module';



@NgModule({
  declarations: [
    EditProfileComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedInputsModule,
  ],
  exports: [
    EditProfileComponent,
  ]
})
export class EditProfileModule { }
