import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LikesListComponent } from './likes-list/likes-list.component';
import { MembersListModule } from '../members-list/members-list.module';

@NgModule({
  declarations: [
    LikesListComponent
  ],
  imports: [
    CommonModule,
    MembersListModule,
  ],
  exports: [
    LikesListComponent,
  ]
})
export class LikesListModule { }
