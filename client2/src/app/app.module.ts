import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
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

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
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
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
