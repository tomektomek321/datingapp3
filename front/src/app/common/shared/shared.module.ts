import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateInputComponent } from './date-input/date-input.component';
import { TextInputComponent } from './text-input/text-input.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';


@NgModule({
    declarations: [
        DateInputComponent,
        TextInputComponent
    ],
    imports: [
        CommonModule
    ]
})
export class SharedModule { }
