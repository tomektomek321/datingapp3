import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputWithHintsComponent } from './text-input-with-hints/text-input-with-hints.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './text-input/text-input.component';
import { DateInputComponent } from './date-input/date-input.component';
import { SharedModule } from 'src/app/shared/libs/shared.module';

@NgModule({
    declarations: [
        TextInputWithHintsComponent,
        TextInputComponent,
        DateInputComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule,
    ],
    exports: [
        TextInputWithHintsComponent,
        TextInputComponent,
        DateInputComponent,
    ]
})
export class SharedInputsModule { }
