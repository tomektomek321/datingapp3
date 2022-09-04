import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/shared/models/Member';
import { LikedMembersService } from '../services/liked-members.service';

@Component({
    selector: 'app-likes-list',
    templateUrl: './likes-list.component.html',
    styleUrls: ['./likes-list.component.scss']
})
export class LikesListComponent implements OnInit {

    predicate = 'liked';

    likedMembers: Member[] = [];

    constructor(
        private likedMembersService: LikedMembersService,
    ) { }

    ngOnInit(): void {
        this.loadLikes();

        this.likedMembersService.getLikedMembers$().subscribe((response: any) => {
            this.likedMembers = response;
        });
    }

    loadLikes(): void {
        this.predicate = 'liked';
        this.likedMembersService.getLikedMembers();
    }

}
