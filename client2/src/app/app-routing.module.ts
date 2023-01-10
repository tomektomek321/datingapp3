import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './infrastructure/auth/components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { MembersListComponent } from './components/members-list/members-list/members-list.component';
import { LikesListComponent } from './components/likes-list/likes-list/likes-list.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile/edit-profile.component';
import { MemberDetailComponent } from './components/members-list/member-detail/member-detail.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'searchMembers', component: MembersListComponent },
  { path: 'likesList', component: LikesListComponent },
  { path: 'member/edit', component: EditProfileComponent },
  { path: 'members/:username', component: MemberDetailComponent },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
