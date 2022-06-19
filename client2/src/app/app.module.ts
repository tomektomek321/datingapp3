import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/libs/shared.module';
import { HeaderModule } from './components/header/header.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { SharedInputsModule } from './shared/shared-inputs/shared-inputs.module';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        RegisterComponent
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
        SharedInputsModule,

    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
