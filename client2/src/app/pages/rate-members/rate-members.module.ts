import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RateMembersComponent } from './rate-members/rate-members.component';
import { RateMemberCardComponent } from './rate-members/rate-member-card/rate-member-card.component';

@NgModule({
  declarations: [
    RateMembersComponent,
    RateMemberCardComponent,
  ],
  imports: [
    CommonModule,
  ],
  exports: [
    RateMembersComponent,
    RateMemberCardComponent,
  ],
})
export class RateMembersModule { }
