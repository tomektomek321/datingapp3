import { Component, OnInit, ViewChild } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { NgxGalleryOptions, NgxGalleryImage } from '@kolkov/ngx-gallery';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})
export class MemberDetailComponent implements OnInit {
    @ViewChild('memberTabs', {static: true}) memberTabs!: TabsetComponent;
    member?: Member;
    galleryOptions?: NgxGalleryOptions[];
    galleryImages?: NgxGalleryImage[];
    activeTab?: TabDirective;
    //messages: Message[] = [];

    constructor(
        private http: HttpClient,
        private router: Router,
    ) {

    }

    ngOnInit(): void {

        const Username = this.router.url.split("/")[2];

        this.http.post('https://localhost:7089/Member/GetUserProfileByUsername', { Username }).subscribe( (response: any) => {
            console.log(response);
            this.member = response.data;
        });

    }


    onTabActivated(event: any) {

    }

}
