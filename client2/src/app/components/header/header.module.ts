import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AuthModule } from 'src/app/infrastructure/auth/auth.module';


@NgModule({
  declarations: [
    HeaderComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    AppRoutingModule,
    AuthModule,
  ],
  exports: [
    HeaderComponent,
  ]
})
export class HeaderModule { }
