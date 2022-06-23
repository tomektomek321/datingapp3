import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MembersListComponent } from './members-list/members-list.component';
import { SearchBarModule } from '../search-bar/search-bar.module';
import { MemberCardComponent } from './member-card/member-card.component';



@NgModule({
    declarations: [
        MembersListComponent,
        MemberCardComponent,
    ],
    imports: [
        CommonModule,
        SearchBarModule,
    ],
    exports: [
        MembersListComponent,
    ]
})
export class MembersListModule { }
