import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/libs/shared.module';
import { HeaderModule } from './components/header/header.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';
import { SharedInputsModule } from './shared/shared-inputs/shared-inputs.module';
import { MembersListModule } from './components/members-list/members-list.module';
import { LikesListModule } from './components/likes-list/likes-list.module';
import { EditProfileModule } from './components/edit-profile/edit-profile.module';
import { JwtInterceptor } from './infrastructure/interceptors/jwt.interceptor';
import { SearchFiltersComponent } from './pages/searchFilters/search-filters/search-filters.component';
import { RateMembersModule } from './pages/rate-members/rate-members.module';
import { CategoryWithHobbiesComponent } from './pages/searchFilters/search-filters/category-with-hobbies/category-with-hobbies.component';
import { CategoryWallnameComponent } from './pages/searchFilters/search-filters/category-with-hobbies/category-wallname/category-wallname.component';
import { HobbyButtonComponent } from './pages/searchFilters/search-filters/category-with-hobbies/hobby-button/hobby-button.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SearchFiltersComponent,
    CategoryWithHobbiesComponent,
    CategoryWallnameComponent,
    HobbyButtonComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,

    HeaderModule,
    MembersListModule,
    LikesListModule,
    EditProfileModule,

    SharedInputsModule,

    RateMembersModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [ AppComponent ],
})
export class AppModule { }
