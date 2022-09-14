import { Component, OnInit, ViewChild } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { NgxGalleryOptions, NgxGalleryImage } from '@kolkov/ngx-gallery';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { UserManagerService } from 'src/app/infrastructure/identity/user-manager.service';
import { LikedMembersService } from '../../likes-list/services/liked-members.service';

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
        private userManagerService: UserManagerService,
        private likedMembersService: LikedMembersService,
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

    selectTab(num: number) {

    }

    toggleLike() {
        if(this.member) {
            this.likedMembersService.toggleLike(this.member.id);
        }
    }

    isUserLiked(): string {
        if(this.member) {
            const liked = this.userManagerService.isLikedByUser(this.member.id);
            return liked ? "Unlike" : "Like";
        }

        return "Like";
    }

}
