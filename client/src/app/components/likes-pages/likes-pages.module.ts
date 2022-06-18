import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LikesListComponent } from './likes-list/likes-list.component';



@NgModule({
    declarations: [
        LikesListComponent,
    ],
    imports: [
        CommonModule
    ],
    exports: [
        LikesListComponent
    ]
})
export class LikesPagesModule { }
