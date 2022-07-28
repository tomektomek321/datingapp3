import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './infrastructure/auth/components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { MembersListComponent } from './components/members-list/members-list/members-list.component';

const routes: Routes = [
    { path: 'register', component: RegisterComponent },
    { path: 'searchMembers', component: MembersListComponent },
    { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
