import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from '../auth/login/login.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from 'src/app/app-routing.module';


@NgModule({
    declarations: [
        HeaderComponent,
        LoginComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,

        AppRoutingModule,
    ],
    exports: [
        HeaderComponent,
    ]
})
export class HeaderModule { }
