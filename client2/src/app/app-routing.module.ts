import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './infrastructure/auth/components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { LikesListComponent } from './components/likes-list/likes-list/likes-list.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile/edit-profile.component';
import { MemberDetailComponent } from './components/members-list/member-detail/member-detail.component';
import { SearchFiltersComponent } from './pages/searchFilters/search-filters/search-filters.component';
import { RateMembersComponent } from './pages/rate-members/rate-members/rate-members.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'searchMembers', component: RateMembersComponent },
  { path: 'filters', component: SearchFiltersComponent },
  { path: 'likesList', component: LikesListComponent },
  { path: 'member/edit', component: EditProfileComponent },
  { path: 'members/:username', component: MemberDetailComponent },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ],
})
export class AppRoutingModule { }
