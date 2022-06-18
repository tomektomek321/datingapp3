import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListsComponent } from './likesList/lists.component';



@NgModule({
    declarations: [
        ListsComponent,
    ],
    imports: [
        CommonModule
    ],
    exports: [
        ListsComponent,
    ]
})
export class LikesPageModule { }
