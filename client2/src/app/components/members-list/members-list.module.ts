import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MembersListComponent } from './members-list/members-list.component';
import { SearchBarModule } from '../search-bar/search-bar.module';
import { MemberCardComponent } from './member-card/member-card.component';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { SharedModule } from 'src/app/shared/libs/shared.module';
import { SharedInputsModule } from 'src/app/shared/shared-inputs/shared-inputs.module';
import { ChatMessagesComponent } from './member-detail/chat-messages/chat-messages.component';
import { FormsModule, } from '@angular/forms';

@NgModule({
  declarations: [
    MembersListComponent,
    MemberCardComponent,
    MemberDetailComponent,
    ChatMessagesComponent,
  ],
  imports: [
    CommonModule,
    SearchBarModule,
    AppRoutingModule,
    FormsModule,
    SharedModule,
    SharedInputsModule,
  ],
  exports: [
    MembersListComponent,
    MemberCardComponent,
  ]
})
export class MembersListModule { }
