import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { TabsModule } from 'ngx-bootstrap/tabs';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        ToastrModule.forRoot({
            positionClass: 'toast-bottom-right'
        }),
        BsDropdownModule.forRoot(),
        TabsModule.forRoot(),
        NgxGalleryModule,

    ],
    exports: [
        ToastrModule,
        BsDropdownModule,
        TabsModule,
        NgxGalleryModule,
    ]
})
export class SharedModule { }
